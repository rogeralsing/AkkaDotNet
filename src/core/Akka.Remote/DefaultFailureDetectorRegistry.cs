﻿//-----------------------------------------------------------------------
// <copyright file="DefaultFailureDetectorRegistry.cs" company="Akka.NET Project">
//     Copyright (C) 2009-2018 Lightbend Inc. <http://www.lightbend.com>
//     Copyright (C) 2013-2018 .NET Foundation <https://github.com/akkadotnet/akka.net>
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Akka.Util;

namespace Akka.Remote
{
    /// <summary>
    /// A lock-less, thread-safe implementation of <see cref="IFailureDetectorRegistry{T}"/>.
    /// </summary>
    /// <typeparam name="T">TBD</typeparam>
    public class DefaultFailureDetectorRegistry<T> : IFailureDetectorRegistry<T>
    {
        /// <summary>
        /// Instantiates the DefaultFailureDetectorRegistry an uses a factory method for creating new instances
        /// </summary>
        /// <param name="factory">TBD</param>
        public DefaultFailureDetectorRegistry(Func<FailureDetector> factory)
        {
            _factory = factory;
        }

        #region Internal State

        private readonly Func<FailureDetector> _factory;

        private AtomicReference<ImmutableDictionary<T, FailureDetector>> _resourceToFailureDetector = 
            new AtomicReference<ImmutableDictionary<T, FailureDetector>>(ImmutableDictionary<T, FailureDetector>.Empty);

        private readonly object _failureDetectorCreationLock = new object();

        private ImmutableDictionary<T, FailureDetector> ResourceToFailureDetector
        {
            get => _resourceToFailureDetector;
            set => _resourceToFailureDetector = value;
        }

        #endregion

        #region IFailureDetectorRegistry<T> members

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="resource">TBD</param>
        /// <returns>TBD</returns>
        public bool IsAvailable(T resource) => 
            !ResourceToFailureDetector.TryGetValue(resource, out var failureDetector) || failureDetector.IsAvailable;

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="resource">TBD</param>
        /// <returns>TBD</returns>
        public bool IsMonitoring(T resource) => 
            ResourceToFailureDetector.TryGetValue(resource, out var failureDetector) && failureDetector.IsMonitoring;

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="resource">TBD</param>
        public void Heartbeat(T resource)
        {
            if (ResourceToFailureDetector.TryGetValue(resource, out var failureDetector))
                failureDetector.HeartBeat();
            else
            {
                //First one wins and creates the new FailureDetector
                lock (_failureDetectorCreationLock)
                {
                    // First check for non-existing key wa outside the lock, and a second thread might just have released the lock
                    // when this one acquired it, so the second check is needed (double-check locking pattern)
                    var oldTable = ResourceToFailureDetector;
                    if (oldTable.TryGetValue(resource, out failureDetector))
                        failureDetector.HeartBeat();
                    else
                    {
                        var newDetector = _factory();
                        newDetector.HeartBeat();
                        ResourceToFailureDetector = oldTable.Add(resource, newDetector);
                    }
                }
            }
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="resource">TBD</param>
        public void Remove(T resource)
        {
            while (true)
            {
                var oldTable = ResourceToFailureDetector;
                if (oldTable.ContainsKey(resource))
                {
                    var newTable = oldTable.Remove(resource); //if we won the race then update else try again
                    if (!_resourceToFailureDetector.CompareAndSet(oldTable, newTable)) continue;
                }
                break;
            }
        }

        /// <summary>
        /// TBD
        /// </summary>
        public void Reset()
        {
            while (true)
            {
                var oldTable = ResourceToFailureDetector;
                // if we won the race then update else try again
                if (!_resourceToFailureDetector.CompareAndSet(oldTable, ImmutableDictionary<T, FailureDetector>.Empty)) continue;
                break;
            }
        }

        #endregion

        #region INTERNAL API

        /// <summary>
        /// Get the underlying <see cref="FailureDetector"/> for a resource.
        /// </summary>
        internal bool TryGetFailureDetector(T resource, out FailureDetector failureDetector) => 
            ResourceToFailureDetector.TryGetValue(resource, out failureDetector);

        #endregion
    }
}

