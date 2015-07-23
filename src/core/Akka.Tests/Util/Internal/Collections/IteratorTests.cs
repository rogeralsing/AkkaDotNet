﻿//-----------------------------------------------------------------------
// <copyright file="IteratorTests.cs" company="Akka.NET Project">
//     Copyright (C) 2009-2015 Typesafe Inc. <http://www.typesafe.com>
//     Copyright (C) 2013-2015 Akka.NET project <https://github.com/akkadotnet/akka.net>
// </copyright>
//-----------------------------------------------------------------------

using Akka.Util.Internal.Collections;
using FluentAssertions;
using Xunit;

namespace Akka.Tests.Util.Internal.Collections
{
    /*TODO: this class is not used*/public class IteratorTests
    {
        [Fact]
        public void Should_provide_next_for_elements()
        {
            var iter = new[] {8, 2, 5}.Iterator();

            iter.Next().Should().Be(8);
            iter.Next().Should().Be(2);
            iter.Next().Should().Be(5);
        }

        [Fact]
        public void Should_provide_isempty()
        {
            var iter = new[] { 8, 2}.Iterator();

            iter.Next().Should().Be(8);
            iter.IsEmpty().Should().BeFalse();

            iter.Next().Should().Be(2);
            iter.IsEmpty().Should().BeTrue();
        }

        [Fact]
        public void Should_provide_vector_of_remaining_elements()
        {
            var iter = new[] { 8, 2, 8, 5, 23 }.Iterator();

            iter.Next().Should().Be(8);
            iter.Next().Should().Be(2);


            var vector = iter.ToVector();
            vector.ShouldBeEquivalentTo(new[] { 8, 5, 23 });
        }
    }
}
