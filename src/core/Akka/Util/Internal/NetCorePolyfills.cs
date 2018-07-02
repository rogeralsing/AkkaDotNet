﻿//-----------------------------------------------------------------------
// <copyright file="NetCorePolyfills.cs" company="Akka.NET Project">
//     Copyright (C) 2009-2018 Lightbend Inc. <http://www.lightbend.com>
//     Copyright (C) 2013-2018 .NET Foundation <https://github.com/akkadotnet/akka.net>
// </copyright>
//-----------------------------------------------------------------------

#if !SERIALIZATION
namespace System
{
    public class SerializableAttribute : Attribute
    {
    }

    public class NonSerializedAttribute : Attribute
    {
    }
}
#endif
