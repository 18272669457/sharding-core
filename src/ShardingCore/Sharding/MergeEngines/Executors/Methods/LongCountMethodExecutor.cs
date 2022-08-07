﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShardingCore.Extensions.InternalExtensions;
using ShardingCore.Sharding.MergeEngines.Executors.Abstractions;
using ShardingCore.Sharding.MergeEngines.Executors.CircuitBreakers;
using ShardingCore.Sharding.MergeEngines.Executors.Methods.Abstractions;
using ShardingCore.Sharding.MergeEngines.Executors.ShardingMergers;
using ShardingCore.Sharding.MergeEngines.ShardingMergeEngines.Abstractions;
using ShardingCore.Sharding.StreamMergeEngines;

namespace ShardingCore.Sharding.MergeEngines.Executors.Methods
{
    /// <summary>
    /// 
    /// </summary>
    /// Author: xjm
    /// Created: 2022/5/7 8:26:46
    /// Email: 326308290@qq.com
    internal class LongCountMethodExecutor<TEntity> : AbstractMethodWrapExecutor<long>
    {
        public LongCountMethodExecutor(StreamMergeContext streamMergeContext) : base(streamMergeContext)
        {
        }

        public override ICircuitBreaker CreateCircuitBreaker()
        {
            var circuitBreaker = new NoTripCircuitBreaker(GetStreamMergeContext());
            circuitBreaker.Register(() =>
            {
                Cancel();
            });
            return circuitBreaker;
        }

        public override IShardingMerger<RouteQueryResult<long>> GetShardingMerger()
        {
            return new LongCountMethodShardingMerger(GetStreamMergeContext());
        }

        protected override Task<long> EFCoreQueryAsync(IQueryable queryable, CancellationToken cancellationToken = new CancellationToken())
        {
            return queryable.As<IQueryable<TEntity>>().LongCountAsync(cancellationToken);
        }
    }
}
