﻿using System;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Configuration;
using Akka.Remote.TestKit;
using Akka.Util;

namespace Akka.Remote.Tests.MultiNode
{
    public class TransportFailSpecConfig : MultiNodeConfig
    {
        public RoleName First { get; }
        public RoleName Second { get; }

        public TransportFailSpecConfig()
        {
            First = Role("first");
            Second = Role("second");

            CommonConfig = DebugConfig(false).WithFallback(ConfigurationFactory.ParseString(@"
              akka.loglevel = INFO
              akka.remote{
                 transport-failure-detector {
                  implementation-class = """+ typeof(TestFailureDetector).AssemblyQualifiedName +@"""
                  heartbeat-interval = 1 s
                }
                # Don't trigger watch Terminated
                watch-failure-detector.acceptable-heartbeat-pause = 60 s
                #use-passive-connections = off
              }
            "));
        }

        internal static AtomicBoolean FdAvailable = new AtomicBoolean(true);

        /// <summary>
        /// Failure detector implementation that will fail when <see cref="FdAvailable"/> is false.
        /// </summary>
        public class TestFailureDetector : FailureDetector
        {
            private volatile bool _active = false;

            public override bool IsAvailable => _active ? FdAvailable.Value : true;

            public override bool IsMonitoring => _active;

            public override void HeartBeat()
            {
                _active = true;
            }
        }

        public class Subject : ReceiveActor
        {
            public Subject()
            {
                ReceiveAny(_ => Sender.Tell(_));
            }
        }
    }

    public class TransportFailSpec : MultiNodeSpec
    {
        private readonly TransportFailSpecConfig _config;

        public TransportFailSpec() : this(new TransportFailSpecConfig()) { }

        private TransportFailSpec(TransportFailSpecConfig config) : base(config, typeof(TransportFailSpecConfig))
        {
            _config = config;
        }

        protected override int InitialParticipantsValueFactory => 2;

        private IActorRef Identify(RoleName role, string actorName)
        {
            var p = CreateTestProbe();
            Sys.ActorSelection(Node(role) / "user" / actorName).Tell(new Identify(actorName), p.Ref);
            return p.ExpectMsg<ActorIdentity>(RemainingOrDefault).Subject;
        }

        [MultiNodeFact]
        public void TransportFail_should_reconnect()
        {
            RunOn(() =>
            {
                EnterBarrier("actors-started");
                var subject = Identify(_config.Second, "subject");
                Watch(subject);
                subject.Tell("hello");
                ExpectMsg("hello");
            }, _config.First);

            RunOn(() =>
            {
                Sys.ActorOf(Props.Create(() => new TransportFailSpecConfig.Subject()), "subject");
                EnterBarrier("actors-started");
            }, _config.Second);

            EnterBarrier("watch-established");

            // trigger transport failure detector
            TransportFailSpecConfig.FdAvailable.GetAndSet(false);

            // wait for ungated (also later awaitAssert retry)
            Task.Delay(RARP.For(Sys).Provider.RemoteSettings.RetryGateClosedFor).Wait();
            TransportFailSpecConfig.FdAvailable.GetAndSet(true);

            RunOn(() =>
            {
                EnterBarrier("actors-started2");
                var quarantineProbe = CreateTestProbe();
                Sys.EventStream.Subscribe(quarantineProbe.Ref, typeof(QuarantinedEvent));

                IActorRef subject2 = null;
                AwaitAssert(() =>
                {
                    Within(TimeSpan.FromSeconds(1), () =>
                    {
                        subject2 = Identify(_config.Second, "subject2");
                    });
                }, TimeSpan.FromSeconds(5));
                Watch(subject2);
                quarantineProbe.ExpectNoMsg(TimeSpan.FromSeconds(1));
                subject2.Tell("hello2");
                ExpectMsg("hello2");
                EnterBarrier("watch-established2");
                ExpectTerminated(subject2);
            }, _config.First);

            RunOn(() =>
            {
                var subject2 = Sys.ActorOf(Props.Create(() => new TransportFailSpecConfig.Subject()), "subject2");
                EnterBarrier("actors-started2");
                EnterBarrier("watch-established2");
                subject2.Tell(PoisonPill.Instance);
            }, _config.Second);

            EnterBarrier("done");
        }
    }
}
