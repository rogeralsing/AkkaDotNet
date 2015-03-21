﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Akka.Actor;
using Akka.Configuration;
using Akka.Configuration.Hocon;
using Akka.Event;
using Akka.TestKit;
using Akka.TestKit.Xunit;
using Akka.Util;
using Akka.Util.Internal;
using Helios.Topology;

namespace Akka.Remote.TestKit
{
    /// <summary>
    /// Configure the role names and participants of the test, including configuration settings
    /// </summary>
    public abstract class MultiNodeConfig
    {
        Config _commonConf = null;
        ImmutableDictionary<RoleName, Config> _nodeConf = ImmutableDictionary.Create<RoleName, Config>();
        ImmutableList<RoleName> _roles = ImmutableList.Create<RoleName>();
        ImmutableDictionary<RoleName, ImmutableList<string>> _deployments = ImmutableDictionary.Create<RoleName, ImmutableList<string>>();
        ImmutableList<string> _allDeploy = ImmutableList.Create<string>();
        bool _testTransport = false;

        /// <summary>
        /// Register a common base config for all test participants, if so desired.
        /// </summary>
        public Config CommonConfig
        {
            set { _commonConf = value; }
        }

        /// <summary>
        /// Register a config override for a specific participant.
        /// </summary>
        public void NodeConfig(IEnumerable<RoleName> roles, IEnumerable<Config> configs)
        {
            var c = configs.Aggregate((a, b) => a.WithFallback(b));
            _nodeConf = _nodeConf.AddRange(roles.Select(r => new KeyValuePair<RoleName, Config>(r, c)));
        }

        /// <summary>
        /// Include for verbose debug logging
        /// </summary>
        /// <param name="on">when `true` debug Config is returned, otherwise config with info logging</param>
        public Config DebugConfig(bool on)
        {
            if (on)
                return ConfigurationFactory.ParseString(@"
                    akka.loglevel = DEBUG
                    akka.remote {
                        log-received-messages = on
                        log-sent-messages = on
                    }
                    akka.actor.debug {
                        receive = on
                        fsm = on
                    }
                    akka.remote.log-remote-lifecycle-events = on
                    akka.log-dead-letters = on
                ");
            return ConfigurationFactory.Empty;
        }

        public RoleName Role(string name)
        {
            if (_roles.Exists(r => r.Name == name)) throw new ArgumentException("non-unique role name " + name);
            var roleName = new RoleName(name);
            _roles = _roles.Add(roleName);
            return roleName;
        }

        public void DeployOn(RoleName role, string deployment)
        {
            ImmutableList<string> roleDeployments;
            _deployments.TryGetValue(role, out roleDeployments);
            _deployments = _deployments.SetItem(role,
                roleDeployments == null ? ImmutableList.Create(deployment) : roleDeployments.Add(deployment));
        }

        public void DeployOnAll(string deployment)
        {
            _allDeploy = _allDeploy.Add(deployment);
        }

        /// <summary>
        /// To be able to use `blackhole`, `passThrough`, and `throttle` you must
        /// activate the failure injector and throttler transport adapters by
        /// specifying `testTransport(on = true)` in your MultiNodeConfig.
        /// </summary>
        public bool TestTransport
        {
            set { _testTransport = value; }
        }

        readonly Lazy<RoleName> _myself;

        protected MultiNodeConfig()
        {
            _myself = new Lazy<RoleName>(() =>
            {
                if (MultiNodeSpec.SelfIndex > _roles.Count) throw new ArgumentException("not enough roles declared for this test");
                return _roles[MultiNodeSpec.SelfIndex];
            });
        }

        public RoleName Myself
        {
            get { return _myself.Value; }
        }

        internal Config Config
        {
            get
            {
                //TODO: Equivalent in Helios?
                var transportConfig = _testTransport ?
                    ConfigurationFactory.ParseString("akka.remote.helios.tcp.applied-adapters = []")
                        : ConfigurationFactory.Empty;

                var builder = ImmutableList.CreateBuilder<Config>();
                Config nodeConfig;
                if (_nodeConf.TryGetValue(Myself, out nodeConfig)) builder.Add(nodeConfig);
                builder.Add(_commonConf);
                builder.Add(transportConfig);
                builder.Add(MultiNodeSpec.NodeConfig);
                builder.Add(MultiNodeSpec.BaseConfig);

                return builder.ToImmutable().Aggregate((a, b) => a.WithFallback(b));
            }
        }

        internal ImmutableList<string> Deployments(RoleName node)
        {
            ImmutableList<string> deployments;
            _deployments.TryGetValue(node, out deployments);
            return deployments == null ? _allDeploy : deployments.AddRange(_allDeploy);
        }

        internal ImmutableList<RoleName> Roles
        {
            get { return _roles; }
        }
    }

    //TODO: Applicable?
    /// <summary>
    /// Note: To be able to run tests with everything ignored or excluded by tags
    /// you must not use `testconductor`, or helper methods that use `testconductor`,
    /// from the constructor of your test class. Otherwise the controller node might
    /// be shutdown before other nodes have completed and you will see errors like:
    /// `AskTimeoutException: sending to terminated ref breaks promises`. Using lazy
    /// val is fine.
    /// </summary>
    public abstract class MultiNodeSpec : TestKitBase, IMultiNodeSpecCallbacks
    {
        //TODO: Sort out references to Java classes in 

        /// <summary>
        /// Marker used to indicate that <see cref="MaxNodes"/> has not been set yet.
        /// </summary>
        private const int MaxNodesUnset = -1;
        private static int _maxNodes = MaxNodesUnset;

        /// <summary>
        /// Number of nodes node taking part in this test.
        /// -Dmultinode.max-nodes=4
        /// </summary>
        public static int MaxNodes
        {
            get
            {
                if (_maxNodes == MaxNodesUnset)
                {
                    _maxNodes = CommandLine.GetInt32("multinode.max-nodes");
                }

                Guard.Assert(_maxNodes > 0, "multinode.max-nodes must be greater than 0");
                return _maxNodes;
            }
        }

        private static string _multiNodeHost;

        /// <summary>
        /// Name (or IP address; must be resolvable)
        /// of the host this node is running on
        /// 
        /// <code>-Dmultinode.host=host.example.com</code>
        /// 
        /// InetAddress.getLocalHost.getHostAddress is used if empty or "localhost"
        /// is defined as system property "multinode.host".
        /// </summary>
        public static string SelfName
        {
            get
            {
                if (string.IsNullOrEmpty(_multiNodeHost))
                {
                    _multiNodeHost = CommandLine.GetProperty("multinode.host");
                }

                //Run this assertion every time. Consistency is more important than performance.
                Guard.Assert(!string.IsNullOrEmpty(_multiNodeHost), "multinode.host must not be empty");
                return _multiNodeHost;
            }
        }

        /// <summary>
        /// Marker used to indicate what the "not been set" value of <see cref="SelfPort"/> is.
        /// </summary>
        private const int SelfPortUnsetValue = -1;
        private static int _selfPort = SelfPortUnsetValue;


        /// <summary>
        /// Port number of this node. Defaults to 0 which means a random port.
        /// 
        /// <code>-Dmultinode.port=0</code>
        /// </summary>
        public static int SelfPort
        {
            get
            {
                if (_selfPort == SelfPortUnsetValue) //unset
                {
                    var selfPortStr = CommandLine.GetProperty("multinode.port");
                    _selfPort = string.IsNullOrEmpty(selfPortStr) ? 0 : Int32.Parse(selfPortStr);
                }

                Guard.Assert(_selfPort >= 0 && _selfPort < 65535, "multinode.port is out of bounds: " + _selfPort);
                return _selfPort;
            }
        }

        private static string _serverName;
        /// <summary>
        /// Name (or IP address; must be resolvable using InetAddress.getByName)
        /// of the host that the server node is running on.
        /// 
        /// <code>-Dmultinode.server-host=server.example.com</code>
        /// </summary>
        public static string ServerName
        {
            get
            {
                if (string.IsNullOrEmpty(_serverName))
                {
                    _serverName = CommandLine.GetProperty("multinode.server-host");
                }
                Guard.Assert(!string.IsNullOrEmpty(_serverName), "multinode.server-host must not be empty");
                return _serverName;
            }
        }

        /// <summary>
        /// Marker used to indicate what the "not been set" value of <see cref="ServerPort"/> is.
        /// </summary>
        private const int ServerPortUnsetValue = -1;

        /// <summary>
        /// Default value for <see cref="ServerPort"/>
        /// </summary>
        private const int ServerPortDefault = 4711;

        private static int _serverPort = ServerPortUnsetValue;

        /// <summary>
        /// Port number of the node that's running the server system. Defaults to 4711.
        /// 
        /// <code>-Dmultinode.server-port=4711</code>
        /// </summary>
        public static int ServerPort
        {
            get
            {
                if (_serverPort == ServerPortUnsetValue)
                {
                    var serverPortStr = CommandLine.GetProperty("multinode.server-port");
                    _serverPort = string.IsNullOrEmpty(serverPortStr) ? ServerPortDefault : Int32.Parse(serverPortStr);
                }

                Guard.Assert(_serverPort > 0 && _serverPort < 65535, "multinode.server-port is out of bounds: " + _serverPort);
                return _serverPort;
            }
        }

        /// <summary>
        /// Marker value used to indicate that <see cref="SelfIndex"/> has not been set yet.
        /// </summary>
        private const int SelfIndexUnset = -1;

        private static int _selfIndex = SelfIndexUnset;

        /// <summary>
        /// Index of this node in the roles sequence. The TestConductor
        /// is started in “controller” mode on selfIndex 0, i.e. there you can inject
        /// failures and shutdown other nodes etc.
        /// </summary>
        public static int SelfIndex
        {
            get
            {
                if (_selfIndex == SelfIndexUnset)
                {
                    _selfIndex = CommandLine.GetInt32("multinode.index");
                }

                Guard.Assert(_selfIndex >= 0 && _selfIndex < MaxNodes, "multinode.index is out of bounds: " + _selfIndex);
                return _selfIndex;
            }
        }

        public static Config NodeConfig
        {
            get
            {
                const string config = @"
                akka.actor.provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
                akka.remote.helios.tcp.hostname = ""{0}""
                akka.remote.helios.tcp.port = {1}";

                return ConfigurationFactory.ParseString(String.Format(config, SelfName, SelfPort));
            }
        }

        public static Config BaseConfig
        {
            get
            {
                return ConfigurationFactory.ParseString(
                      @"akka {
                        loglevel = ""WARNING""
                        stdout-loglevel = ""WARNING""
                        actor {
                          default-dispatcher {
                            executor = ""fork-join-executor""
                            fork-join-executor {
                              parallelism-min = 8
                              parallelism-factor = 2.0
                              parallelism-max = 8
                            }
                          }
                        }
                      }").WithFallback(TestKitBase.DefaultConfig);
            }
        }

        private static string GetCallerName()
        {
            var @this = typeof(MultiNodeSpec).Name;
            var trace = new StackTrace();
            var frames = trace.GetFrames();
            if (frames != null)
            {
                for (var i = 1; i < frames.Length; i++)
                {
                    var t = frames[i].GetMethod().DeclaringType;
                    if (t != null && t.Name != @this) return t.Name;
                }
            }
            throw new InvalidOperationException("Unable to find calling type");
        }

        readonly RoleName _myself;
        public RoleName Myself { get { return _myself; } }
        readonly LoggingAdapter _log;
        readonly ImmutableList<RoleName> _roles;
        readonly Func<RoleName, ImmutableList<string>> _deployments;
        readonly ImmutableDictionary<RoleName, Replacement> _replacements;
        readonly Address _myAddress;

        protected MultiNodeSpec(MultiNodeConfig config) :
            this(config.Myself, ActorSystem.Create(GetCallerName(), config.Config), config.Roles, config.Deployments)
        {
        }

        protected MultiNodeSpec(
            RoleName myself,
            ActorSystem system,
            ImmutableList<RoleName> roles,
            Func<RoleName, ImmutableList<string>> deployments)
            : base(new XunitAssertions(), system)
        {
            _myself = myself;
            _log = Logging.GetLogger(Sys, this);
            _roles = roles;
            _deployments = deployments;
            var node = new Node()
            {
                Host = Dns.GetHostEntry(ServerName).AddressList.First(a => a.AddressFamily == AddressFamily.InterNetwork),
                Port = ServerPort
            };
            _controllerAddr = node;

            AttachConductor(new TestConductor(system));

            _replacements = _roles.ToImmutableDictionary(r => r, r => new Replacement("@" + r.Name + "@", r, this));

            InjectDeployments(system, myself);

            _myAddress = system.AsInstanceOf<ExtendedActorSystem>().Provider.DefaultAddress;

            Log.Info("Role [{0}] started with address [{1}]", myself.Name, _myAddress);
        }

        public void MultiNodeSpecBeforeAll()
        {
            AtStartup();
        }

        public void MultiNodeSpecAfterAll()
        {
            // wait for all nodes to remove themselves before we shut the conductor down
            if (SelfIndex == 0)
            {
                TestConductor.RemoveNode(_myself);
                Within(TestConductor.Settings.BarrierTimeout, () => 
                    AwaitCondition(() => TestConductor.GetNodes().Result.Any(n => !n.Equals(_myself))));
              
            }
            Shutdown(Sys);
            AfterTermination();
        }

        protected virtual TimeSpan ShutdownTimeout { get { return TimeSpan.FromSeconds(5); } }

        /// <summary>
        /// Override this and return `true` to assert that the
        /// shutdown of the `ActorSystem` was done properly.
        /// </summary>
        protected virtual bool VerifySystemShutdown { get { return false; } }

        //Test Class Interface

        /// <summary>
        /// Override this method to do something when the whole test is starting up.
        /// </summary>
        protected virtual void AtStartup()
        {
        }

        /// <summary>
        /// Override this method to do something when the whole test is terminating.
        /// </summary>
        protected virtual void AfterTermination()
        {
        }

        /// <summary>
        /// All registered roles
        /// </summary>
        public ImmutableList<RoleName> Roles { get { return _roles; } }

        /// <summary>
        /// MUST BE DEFINED BY USER.
        /// 
        /// Defines the number of participants required for starting the test. This
        /// might not be equals to the number of nodes available to the test.
        /// </summary>
        public int InitialParticipants
        {
            get
            {
                var initialParticipants = InitialParticipantsValueFactory;
                Guard.Assert(initialParticipants > 0, "InitialParticipantsValueFactory must be populated early on, and it must be greater zero");
                Guard.Assert(initialParticipants <= MaxNodes, "not enough nodes to run this test");
                return initialParticipants;
            }

        }

        /// <summary>
        /// Must be defined by user. Creates the values used by <see cref="InitialParticipants"/>
        /// </summary>
        protected abstract int InitialParticipantsValueFactory { get; }

        protected TestConductor TestConductor;

        /// <summary>
        /// Execute the given block of code only on the given nodes (names according
        /// to the `roleMap`).
        /// </summary>
        public void RunOn(Action thunk, params RoleName[] nodes)
        {
            if (nodes.Length == 0) throw new ArgumentException("No node given to run on.");
            if (IsNode(nodes)) thunk();
        }

        /// <summary>
        /// Verify that the running node matches one of the given nodes
        /// </summary>
        public bool IsNode(params RoleName[] nodes)
        {
            return nodes.Contains(_myself);
        }

        /// <summary>
        /// Enter the named barriers in the order given. Use the remaining duration from
        /// the innermost enclosing `within` block or the default `BarrierTimeout`
        /// </summary>
        public void EnterBarrier(params string[] name)
        {
            TestConductor.Enter(RemainingOr(TestConductor.Settings.BarrierTimeout), name.ToImmutableList());
        }

        /// <summary>
        /// Query the controller for the transport address of the given node (by role name) and
        /// return that as an ActorPath for easy composition:
        /// 
        /// <code>var serviceA = Sys.ActorSelection(Node(new RoleName("master")) / "user" / "serviceA");</code>
        /// </summary>
        public ActorPath Node(RoleName role)
        {
            //TODO: Async stuff here 
            return new RootActorPath(TestConductor.GetAddressFor(role).Result);
        }

        public void MuteDeadLetters(ActorSystem system = null, params Type[] messageClasses)
        {
            if (system == null) system = Sys;
            if (!system.Log.IsDebugEnabled)
            {
                if (messageClasses.Any())
                    foreach (var @class in messageClasses) EventFilter.DeadLetter(@class).Mute();
                else EventFilter.DeadLetter(typeof(object)).Mute();
            }
        }

        /*
        * Implementation (i.e. wait for start etc.)
        */

        readonly INode _controllerAddr;

        protected void AttachConductor(TestConductor tc)
        {
            var timeout = tc.Settings.BarrierTimeout;
            try
            {
                //TODO: Async stuff
                if (SelfIndex == 0)
                    tc.StartController(InitialParticipants, _myself, _controllerAddr).Wait(timeout);
                else
                    tc.StartClient(_myself, _controllerAddr).Wait(timeout);
            }
            catch (Exception e)
            {
                throw new Exception("failure while attaching new conductor", e);
            }
            TestConductor = tc;
        }

        // now add deployments, if so desired

        sealed class Replacement
        {
            readonly string _tag;
            public string Tag { get { return _tag; } }
            readonly RoleName _role;
            public RoleName Role { get { return _role; } }
            readonly Lazy<string> _addr;
            public string Addr { get { return _addr.Value; } }

            public Replacement(string tag, RoleName role, MultiNodeSpec spec)
            {
                _tag = tag;
                _role = role;
                _addr = new Lazy<string>(() => spec.Node(role).Address.ToString());
            }
        }

        protected void InjectDeployments(ActorSystem system, RoleName role)
        {
            var deployer = Sys.AsInstanceOf<ExtendedActorSystem>().Provider.Deployer;
            foreach (var str in _deployments(role))
            {
                var deployString = _replacements.Values.Aggregate(str, (@base, r) =>
                {
                    var indexOf = @base.IndexOf(r.Tag, StringComparison.Ordinal);
                    if (indexOf == -1) return @base;
                    string replaceWith;
                    try
                    {
                        replaceWith = r.Addr;
                    }
                    catch (Exception e)
                    {
                        // might happen if all test cases are ignored (excluded) and
                        // controller node is finished/exited before r.addr is run
                        // on the other nodes
                        var unresolved = "akka://unresolved-replacement-" + r.Role.Name;
                        Log.Warning(unresolved + " due to: " + e.ToString());
                        replaceWith = unresolved;
                    }
                    return @base.Replace(r.Tag, replaceWith);
                });
                foreach (var pair in ConfigurationFactory.ParseString(deployString).AsEnumerable())
                {
                    if (pair.Value.IsObject())
                    {
                        var deploy =
                            deployer.ParseConfig(pair.Key, new Config(new HoconRoot(pair.Value)));
                        deployer.SetDeploy(deploy);
                    }
                    else
                    {
                        throw new ArgumentException(String.Format("key {0} must map to deployment section, not simple value {1}",
                            pair.Key, pair.Value));
                    }
                }
            }
        }

        protected ActorSystem StartNewSystem()
        {
            var config =
                ConfigurationFactory
                .ParseString(String.Format(@"helios.tcp{port={0}\nhostname=""{1}""",
                    _myAddress.Host,
                    _myAddress.Port))
                .WithFallback(Sys.Settings.Config);

            var system = ActorSystem.Create(Sys.Name, config);
            InjectDeployments(system, _myself);
            AttachConductor(new TestConductor(system));
            return system;
        }
    }

    //TODO: Improve docs
    /// <summary>
    /// Use this to hook <see cref="MultiNodeSpec"/> into your test framework lifecycle
    /// </summary>
    public interface IMultiNodeSpecCallbacks
    {
        /// <summary>
        /// Call this before the start of the test run. NOT before every test case.
        /// </summary>
        void MultiNodeSpecBeforeAll();

        /// <summary>
        /// Call this after the all test cases have run. NOT after every test case.
        /// </summary>
        void MultiNodeSpecAfterAll();
    }
}