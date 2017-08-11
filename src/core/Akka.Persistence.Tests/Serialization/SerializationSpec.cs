﻿// <copyright file="SerializationSpec.cs" company="Copaco B.V.">
//        Copyright (c) 2015 - 2017 All Right Reserved
//        Author: Arjen Smits
// </copyright>

using Akka.Actor;
using Akka.Configuration;
using Akka.TestKit;
using Xunit;

namespace Akka.Persistence.Tests.Serialization
{


    public class SerializationSpec : AkkaSpec
    {
        private class TestMessage
        {
            public string Message { get; set; }

            public TestMessage(string message)
            {
                Message = message;
            }
        }

        private readonly Akka.Serialization.Serialization _serialization;

        public SerializationSpec() : base(
            Configs.Config(
                Configs.CustomSerializers,
                ConfigurationFactory.FromResource<Persistence>("Akka.Persistence.persistence.conf") // for akka-persistence-message
            ))
        {
            _serialization = Sys.Serialization;  
        }

        [Fact]
        public void Serialization_respects_default_serializer_parameter()
        {
            var message = new TestMessage("this is my test message");
            var serializer = _serialization.FindSerializerFor(message, "json");
            Assert.True(serializer.Identifier == 1); //by default configuration the serializer id for json == newtonsoft == 1
        }

        [Fact]
        public void Serialization_falls_back_to_system_default_if_unknown_serializer_parameter()
        {
            var message = new TestMessage("this is my test message");
            var serializer = _serialization.FindSerializerFor(message, "unicorn");
            //since unicorn is an unknown serializer, the system default will be used
            //which incedentally is JSON at the moment
            Assert.True(serializer.Identifier == 1); //by default configuration the serializer id for json == newtonsoft == 1
        }
    }
}