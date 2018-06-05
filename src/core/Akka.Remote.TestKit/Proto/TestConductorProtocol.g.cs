﻿//-----------------------------------------------------------------------
// <copyright file="TestConductorProtocol.g.cs" company="Akka.NET Project">
//     Copyright (C) 2009-2018 Lightbend Inc. <http://www.lightbend.com>
//     Copyright (C) 2013-2018 .NET Foundation <https://github.com/akkadotnet/akka.net>
// </copyright>
//-----------------------------------------------------------------------

// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: TestConductorProtocol.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Akka.Remote.TestKit.Proto.Msg {

  /// <summary>Holder for reflection information generated from TestConductorProtocol.proto</summary>
  internal static partial class TestConductorProtocolReflection {

    #region Descriptor
    /// <summary>File descriptor for TestConductorProtocol.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static TestConductorProtocolReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChtUZXN0Q29uZHVjdG9yUHJvdG9jb2wucHJvdG8SHUFra2EuUmVtb3RlLlRl",
            "c3RLaXQuUHJvdG8uTXNnGhZDb250YWluZXJGb3JtYXRzLnByb3RvIoYCCgdX",
            "cmFwcGVyEjMKBWhlbGxvGAEgASgLMiQuQWtrYS5SZW1vdGUuVGVzdEtpdC5Q",
            "cm90by5Nc2cuSGVsbG8SPAoHYmFycmllchgCIAEoCzIrLkFra2EuUmVtb3Rl",
            "LlRlc3RLaXQuUHJvdG8uTXNnLkVudGVyQmFycmllchI9CgdmYWlsdXJlGAMg",
            "ASgLMiwuQWtrYS5SZW1vdGUuVGVzdEtpdC5Qcm90by5Nc2cuSW5qZWN0RmFp",
            "bHVyZRIMCgRkb25lGAQgASgJEjsKBGFkZHIYBSABKAsyLS5Ba2thLlJlbW90",
            "ZS5UZXN0S2l0LlByb3RvLk1zZy5BZGRyZXNzUmVxdWVzdCJYCgVIZWxsbxIM",
            "CgRuYW1lGAEgASgJEkEKB2FkZHJlc3MYAiABKAsyMC5Ba2thLlJlbW90ZS5T",
            "ZXJpYWxpemF0aW9uLlByb3RvLk1zZy5BZGRyZXNzRGF0YSKtAQoMRW50ZXJC",
            "YXJyaWVyEgwKBG5hbWUYASABKAkSQQoCb3AYAiABKA4yNS5Ba2thLlJlbW90",
            "ZS5UZXN0S2l0LlByb3RvLk1zZy5FbnRlckJhcnJpZXIuQmFycmllck9wEg8K",
            "B3RpbWVvdXQYAyABKAMiOwoJQmFycmllck9wEgkKBUVudGVyEAASCAoERmFp",
            "bBABEg0KCVN1Y2NlZWRlZBACEgoKBkZhaWxlZBADIl4KDkFkZHJlc3NSZXF1",
            "ZXN0EgwKBG5vZGUYASABKAkSPgoEYWRkchgCIAEoCzIwLkFra2EuUmVtb3Rl",
            "LlNlcmlhbGl6YXRpb24uUHJvdG8uTXNnLkFkZHJlc3NEYXRhIpkDCg1Jbmpl",
            "Y3RGYWlsdXJlEkYKB2ZhaWx1cmUYASABKA4yNS5Ba2thLlJlbW90ZS5UZXN0",
            "S2l0LlByb3RvLk1zZy5JbmplY3RGYWlsdXJlLkZhaWxUeXBlEkkKCWRpcmVj",
            "dGlvbhgCIAEoDjI2LkFra2EuUmVtb3RlLlRlc3RLaXQuUHJvdG8uTXNnLklu",
            "amVjdEZhaWx1cmUuRGlyZWN0aW9uEkEKB2FkZHJlc3MYAyABKAsyMC5Ba2th",
            "LlJlbW90ZS5TZXJpYWxpemF0aW9uLlByb3RvLk1zZy5BZGRyZXNzRGF0YRIQ",
            "CghyYXRlTUJpdBgGIAEoAhIRCglleGl0VmFsdWUYByABKAUiXwoIRmFpbFR5",
            "cGUSDAoIVGhyb3R0bGUQABIOCgpEaXNjb25uZWN0EAESCQoFQWJvcnQQAhII",
            "CgRFeGl0EAMSDAoIU2h1dGRvd24QBBISCg5TaHV0ZG93bkFicnVwdBAFIiwK",
            "CURpcmVjdGlvbhIICgRTZW5kEAASCwoHUmVjZWl2ZRABEggKBEJvdGgQAmIG",
            "cHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Akka.Remote.Serialization.Proto.Msg.ContainerFormatsReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Akka.Remote.TestKit.Proto.Msg.Wrapper), global::Akka.Remote.TestKit.Proto.Msg.Wrapper.Parser, new[]{ "Hello", "Barrier", "Failure", "Done", "Addr" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Akka.Remote.TestKit.Proto.Msg.Hello), global::Akka.Remote.TestKit.Proto.Msg.Hello.Parser, new[]{ "Name", "Address" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Akka.Remote.TestKit.Proto.Msg.EnterBarrier), global::Akka.Remote.TestKit.Proto.Msg.EnterBarrier.Parser, new[]{ "Name", "Op", "Timeout" }, null, new[]{ typeof(global::Akka.Remote.TestKit.Proto.Msg.EnterBarrier.Types.BarrierOp) }, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Akka.Remote.TestKit.Proto.Msg.AddressRequest), global::Akka.Remote.TestKit.Proto.Msg.AddressRequest.Parser, new[]{ "Node", "Addr" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Akka.Remote.TestKit.Proto.Msg.InjectFailure), global::Akka.Remote.TestKit.Proto.Msg.InjectFailure.Parser, new[]{ "Failure", "Direction", "Address", "RateMBit", "ExitValue" }, null, new[]{ typeof(global::Akka.Remote.TestKit.Proto.Msg.InjectFailure.Types.FailType), typeof(global::Akka.Remote.TestKit.Proto.Msg.InjectFailure.Types.Direction) }, null)
          }));
    }
    #endregion

  }
  #region Messages
  internal sealed partial class Wrapper : pb::IMessage<Wrapper> {
    private static readonly pb::MessageParser<Wrapper> _parser = new pb::MessageParser<Wrapper>(() => new Wrapper());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Wrapper> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Akka.Remote.TestKit.Proto.Msg.TestConductorProtocolReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Wrapper() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Wrapper(Wrapper other) : this() {
      Hello = other.hello_ != null ? other.Hello.Clone() : null;
      Barrier = other.barrier_ != null ? other.Barrier.Clone() : null;
      Failure = other.failure_ != null ? other.Failure.Clone() : null;
      done_ = other.done_;
      Addr = other.addr_ != null ? other.Addr.Clone() : null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Wrapper Clone() {
      return new Wrapper(this);
    }

    /// <summary>Field number for the "hello" field.</summary>
    public const int HelloFieldNumber = 1;
    private global::Akka.Remote.TestKit.Proto.Msg.Hello hello_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Akka.Remote.TestKit.Proto.Msg.Hello Hello {
      get { return hello_; }
      set {
        hello_ = value;
      }
    }

    /// <summary>Field number for the "barrier" field.</summary>
    public const int BarrierFieldNumber = 2;
    private global::Akka.Remote.TestKit.Proto.Msg.EnterBarrier barrier_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Akka.Remote.TestKit.Proto.Msg.EnterBarrier Barrier {
      get { return barrier_; }
      set {
        barrier_ = value;
      }
    }

    /// <summary>Field number for the "failure" field.</summary>
    public const int FailureFieldNumber = 3;
    private global::Akka.Remote.TestKit.Proto.Msg.InjectFailure failure_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Akka.Remote.TestKit.Proto.Msg.InjectFailure Failure {
      get { return failure_; }
      set {
        failure_ = value;
      }
    }

    /// <summary>Field number for the "done" field.</summary>
    public const int DoneFieldNumber = 4;
    private string done_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Done {
      get { return done_; }
      set {
        done_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "addr" field.</summary>
    public const int AddrFieldNumber = 5;
    private global::Akka.Remote.TestKit.Proto.Msg.AddressRequest addr_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Akka.Remote.TestKit.Proto.Msg.AddressRequest Addr {
      get { return addr_; }
      set {
        addr_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Wrapper);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Wrapper other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Hello, other.Hello)) return false;
      if (!object.Equals(Barrier, other.Barrier)) return false;
      if (!object.Equals(Failure, other.Failure)) return false;
      if (Done != other.Done) return false;
      if (!object.Equals(Addr, other.Addr)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (hello_ != null) hash ^= Hello.GetHashCode();
      if (barrier_ != null) hash ^= Barrier.GetHashCode();
      if (failure_ != null) hash ^= Failure.GetHashCode();
      if (Done.Length != 0) hash ^= Done.GetHashCode();
      if (addr_ != null) hash ^= Addr.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (hello_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Hello);
      }
      if (barrier_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Barrier);
      }
      if (failure_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(Failure);
      }
      if (Done.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Done);
      }
      if (addr_ != null) {
        output.WriteRawTag(42);
        output.WriteMessage(Addr);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (hello_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Hello);
      }
      if (barrier_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Barrier);
      }
      if (failure_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Failure);
      }
      if (Done.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Done);
      }
      if (addr_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Addr);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Wrapper other) {
      if (other == null) {
        return;
      }
      if (other.hello_ != null) {
        if (hello_ == null) {
          hello_ = new global::Akka.Remote.TestKit.Proto.Msg.Hello();
        }
        Hello.MergeFrom(other.Hello);
      }
      if (other.barrier_ != null) {
        if (barrier_ == null) {
          barrier_ = new global::Akka.Remote.TestKit.Proto.Msg.EnterBarrier();
        }
        Barrier.MergeFrom(other.Barrier);
      }
      if (other.failure_ != null) {
        if (failure_ == null) {
          failure_ = new global::Akka.Remote.TestKit.Proto.Msg.InjectFailure();
        }
        Failure.MergeFrom(other.Failure);
      }
      if (other.Done.Length != 0) {
        Done = other.Done;
      }
      if (other.addr_ != null) {
        if (addr_ == null) {
          addr_ = new global::Akka.Remote.TestKit.Proto.Msg.AddressRequest();
        }
        Addr.MergeFrom(other.Addr);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            if (hello_ == null) {
              hello_ = new global::Akka.Remote.TestKit.Proto.Msg.Hello();
            }
            input.ReadMessage(hello_);
            break;
          }
          case 18: {
            if (barrier_ == null) {
              barrier_ = new global::Akka.Remote.TestKit.Proto.Msg.EnterBarrier();
            }
            input.ReadMessage(barrier_);
            break;
          }
          case 26: {
            if (failure_ == null) {
              failure_ = new global::Akka.Remote.TestKit.Proto.Msg.InjectFailure();
            }
            input.ReadMessage(failure_);
            break;
          }
          case 34: {
            Done = input.ReadString();
            break;
          }
          case 42: {
            if (addr_ == null) {
              addr_ = new global::Akka.Remote.TestKit.Proto.Msg.AddressRequest();
            }
            input.ReadMessage(addr_);
            break;
          }
        }
      }
    }

  }

  internal sealed partial class Hello : pb::IMessage<Hello> {
    private static readonly pb::MessageParser<Hello> _parser = new pb::MessageParser<Hello>(() => new Hello());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Hello> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Akka.Remote.TestKit.Proto.Msg.TestConductorProtocolReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Hello() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Hello(Hello other) : this() {
      name_ = other.name_;
      Address = other.address_ != null ? other.Address.Clone() : null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Hello Clone() {
      return new Hello(this);
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 1;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "address" field.</summary>
    public const int AddressFieldNumber = 2;
    private global::Akka.Remote.Serialization.Proto.Msg.AddressData address_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Akka.Remote.Serialization.Proto.Msg.AddressData Address {
      get { return address_; }
      set {
        address_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Hello);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Hello other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Name != other.Name) return false;
      if (!object.Equals(Address, other.Address)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (address_ != null) hash ^= Address.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Name.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Name);
      }
      if (address_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Address);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (address_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Address);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Hello other) {
      if (other == null) {
        return;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.address_ != null) {
        if (address_ == null) {
          address_ = new global::Akka.Remote.Serialization.Proto.Msg.AddressData();
        }
        Address.MergeFrom(other.Address);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Name = input.ReadString();
            break;
          }
          case 18: {
            if (address_ == null) {
              address_ = new global::Akka.Remote.Serialization.Proto.Msg.AddressData();
            }
            input.ReadMessage(address_);
            break;
          }
        }
      }
    }

  }

  internal sealed partial class EnterBarrier : pb::IMessage<EnterBarrier> {
    private static readonly pb::MessageParser<EnterBarrier> _parser = new pb::MessageParser<EnterBarrier>(() => new EnterBarrier());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<EnterBarrier> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Akka.Remote.TestKit.Proto.Msg.TestConductorProtocolReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EnterBarrier() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EnterBarrier(EnterBarrier other) : this() {
      name_ = other.name_;
      op_ = other.op_;
      timeout_ = other.timeout_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EnterBarrier Clone() {
      return new EnterBarrier(this);
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 1;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "op" field.</summary>
    public const int OpFieldNumber = 2;
    private global::Akka.Remote.TestKit.Proto.Msg.EnterBarrier.Types.BarrierOp op_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Akka.Remote.TestKit.Proto.Msg.EnterBarrier.Types.BarrierOp Op {
      get { return op_; }
      set {
        op_ = value;
      }
    }

    /// <summary>Field number for the "timeout" field.</summary>
    public const int TimeoutFieldNumber = 3;
    private long timeout_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long Timeout {
      get { return timeout_; }
      set {
        timeout_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as EnterBarrier);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(EnterBarrier other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Name != other.Name) return false;
      if (Op != other.Op) return false;
      if (Timeout != other.Timeout) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Op != 0) hash ^= Op.GetHashCode();
      if (Timeout != 0L) hash ^= Timeout.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Name.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Name);
      }
      if (Op != 0) {
        output.WriteRawTag(16);
        output.WriteEnum((int) Op);
      }
      if (Timeout != 0L) {
        output.WriteRawTag(24);
        output.WriteInt64(Timeout);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Op != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Op);
      }
      if (Timeout != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(Timeout);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(EnterBarrier other) {
      if (other == null) {
        return;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Op != 0) {
        Op = other.Op;
      }
      if (other.Timeout != 0L) {
        Timeout = other.Timeout;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Name = input.ReadString();
            break;
          }
          case 16: {
            op_ = (global::Akka.Remote.TestKit.Proto.Msg.EnterBarrier.Types.BarrierOp) input.ReadEnum();
            break;
          }
          case 24: {
            Timeout = input.ReadInt64();
            break;
          }
        }
      }
    }

    #region Nested types
    /// <summary>Container for nested types declared in the EnterBarrier message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      internal enum BarrierOp {
        [pbr::OriginalName("Enter")] Enter = 0,
        [pbr::OriginalName("Fail")] Fail = 1,
        [pbr::OriginalName("Succeeded")] Succeeded = 2,
        [pbr::OriginalName("Failed")] Failed = 3,
      }

    }
    #endregion

  }

  internal sealed partial class AddressRequest : pb::IMessage<AddressRequest> {
    private static readonly pb::MessageParser<AddressRequest> _parser = new pb::MessageParser<AddressRequest>(() => new AddressRequest());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<AddressRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Akka.Remote.TestKit.Proto.Msg.TestConductorProtocolReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AddressRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AddressRequest(AddressRequest other) : this() {
      node_ = other.node_;
      Addr = other.addr_ != null ? other.Addr.Clone() : null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AddressRequest Clone() {
      return new AddressRequest(this);
    }

    /// <summary>Field number for the "node" field.</summary>
    public const int NodeFieldNumber = 1;
    private string node_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Node {
      get { return node_; }
      set {
        node_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "addr" field.</summary>
    public const int AddrFieldNumber = 2;
    private global::Akka.Remote.Serialization.Proto.Msg.AddressData addr_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Akka.Remote.Serialization.Proto.Msg.AddressData Addr {
      get { return addr_; }
      set {
        addr_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as AddressRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(AddressRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Node != other.Node) return false;
      if (!object.Equals(Addr, other.Addr)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Node.Length != 0) hash ^= Node.GetHashCode();
      if (addr_ != null) hash ^= Addr.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Node.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Node);
      }
      if (addr_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Addr);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Node.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Node);
      }
      if (addr_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Addr);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(AddressRequest other) {
      if (other == null) {
        return;
      }
      if (other.Node.Length != 0) {
        Node = other.Node;
      }
      if (other.addr_ != null) {
        if (addr_ == null) {
          addr_ = new global::Akka.Remote.Serialization.Proto.Msg.AddressData();
        }
        Addr.MergeFrom(other.Addr);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Node = input.ReadString();
            break;
          }
          case 18: {
            if (addr_ == null) {
              addr_ = new global::Akka.Remote.Serialization.Proto.Msg.AddressData();
            }
            input.ReadMessage(addr_);
            break;
          }
        }
      }
    }

  }

  internal sealed partial class InjectFailure : pb::IMessage<InjectFailure> {
    private static readonly pb::MessageParser<InjectFailure> _parser = new pb::MessageParser<InjectFailure>(() => new InjectFailure());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<InjectFailure> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Akka.Remote.TestKit.Proto.Msg.TestConductorProtocolReflection.Descriptor.MessageTypes[4]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public InjectFailure() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public InjectFailure(InjectFailure other) : this() {
      failure_ = other.failure_;
      direction_ = other.direction_;
      Address = other.address_ != null ? other.Address.Clone() : null;
      rateMBit_ = other.rateMBit_;
      exitValue_ = other.exitValue_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public InjectFailure Clone() {
      return new InjectFailure(this);
    }

    /// <summary>Field number for the "failure" field.</summary>
    public const int FailureFieldNumber = 1;
    private global::Akka.Remote.TestKit.Proto.Msg.InjectFailure.Types.FailType failure_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Akka.Remote.TestKit.Proto.Msg.InjectFailure.Types.FailType Failure {
      get { return failure_; }
      set {
        failure_ = value;
      }
    }

    /// <summary>Field number for the "direction" field.</summary>
    public const int DirectionFieldNumber = 2;
    private global::Akka.Remote.TestKit.Proto.Msg.InjectFailure.Types.Direction direction_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Akka.Remote.TestKit.Proto.Msg.InjectFailure.Types.Direction Direction {
      get { return direction_; }
      set {
        direction_ = value;
      }
    }

    /// <summary>Field number for the "address" field.</summary>
    public const int AddressFieldNumber = 3;
    private global::Akka.Remote.Serialization.Proto.Msg.AddressData address_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Akka.Remote.Serialization.Proto.Msg.AddressData Address {
      get { return address_; }
      set {
        address_ = value;
      }
    }

    /// <summary>Field number for the "rateMBit" field.</summary>
    public const int RateMBitFieldNumber = 6;
    private float rateMBit_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float RateMBit {
      get { return rateMBit_; }
      set {
        rateMBit_ = value;
      }
    }

    /// <summary>Field number for the "exitValue" field.</summary>
    public const int ExitValueFieldNumber = 7;
    private int exitValue_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int ExitValue {
      get { return exitValue_; }
      set {
        exitValue_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as InjectFailure);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(InjectFailure other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Failure != other.Failure) return false;
      if (Direction != other.Direction) return false;
      if (!object.Equals(Address, other.Address)) return false;
      if (RateMBit != other.RateMBit) return false;
      if (ExitValue != other.ExitValue) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Failure != 0) hash ^= Failure.GetHashCode();
      if (Direction != 0) hash ^= Direction.GetHashCode();
      if (address_ != null) hash ^= Address.GetHashCode();
      if (RateMBit != 0F) hash ^= RateMBit.GetHashCode();
      if (ExitValue != 0) hash ^= ExitValue.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Failure != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Failure);
      }
      if (Direction != 0) {
        output.WriteRawTag(16);
        output.WriteEnum((int) Direction);
      }
      if (address_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(Address);
      }
      if (RateMBit != 0F) {
        output.WriteRawTag(53);
        output.WriteFloat(RateMBit);
      }
      if (ExitValue != 0) {
        output.WriteRawTag(56);
        output.WriteInt32(ExitValue);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Failure != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Failure);
      }
      if (Direction != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Direction);
      }
      if (address_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Address);
      }
      if (RateMBit != 0F) {
        size += 1 + 4;
      }
      if (ExitValue != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ExitValue);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(InjectFailure other) {
      if (other == null) {
        return;
      }
      if (other.Failure != 0) {
        Failure = other.Failure;
      }
      if (other.Direction != 0) {
        Direction = other.Direction;
      }
      if (other.address_ != null) {
        if (address_ == null) {
          address_ = new global::Akka.Remote.Serialization.Proto.Msg.AddressData();
        }
        Address.MergeFrom(other.Address);
      }
      if (other.RateMBit != 0F) {
        RateMBit = other.RateMBit;
      }
      if (other.ExitValue != 0) {
        ExitValue = other.ExitValue;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            failure_ = (global::Akka.Remote.TestKit.Proto.Msg.InjectFailure.Types.FailType) input.ReadEnum();
            break;
          }
          case 16: {
            direction_ = (global::Akka.Remote.TestKit.Proto.Msg.InjectFailure.Types.Direction) input.ReadEnum();
            break;
          }
          case 26: {
            if (address_ == null) {
              address_ = new global::Akka.Remote.Serialization.Proto.Msg.AddressData();
            }
            input.ReadMessage(address_);
            break;
          }
          case 53: {
            RateMBit = input.ReadFloat();
            break;
          }
          case 56: {
            ExitValue = input.ReadInt32();
            break;
          }
        }
      }
    }

    #region Nested types
    /// <summary>Container for nested types declared in the InjectFailure message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      internal enum FailType {
        [pbr::OriginalName("Throttle")] Throttle = 0,
        [pbr::OriginalName("Disconnect")] Disconnect = 1,
        [pbr::OriginalName("Abort")] Abort = 2,
        [pbr::OriginalName("Exit")] Exit = 3,
        [pbr::OriginalName("Shutdown")] Shutdown = 4,
        [pbr::OriginalName("ShutdownAbrupt")] ShutdownAbrupt = 5,
      }

      internal enum Direction {
        [pbr::OriginalName("Send")] Send = 0,
        [pbr::OriginalName("Receive")] Receive = 1,
        [pbr::OriginalName("Both")] Both = 2,
      }

    }
    #endregion

  }

  #endregion

}

#endregion Designer generated code
