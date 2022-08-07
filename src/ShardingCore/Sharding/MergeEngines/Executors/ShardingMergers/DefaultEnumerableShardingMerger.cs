using System.Collections.Generic;
using ShardingCore.Sharding.Enumerators;
using ShardingCore.Sharding.Enumerators.StreamMergeAsync;

namespace ShardingCore.Sharding.MergeEngines.Executors.ShardingMergers
{
    internal class DefaultEnumerableShardingMerger<TEntity>:AbstractEnumerableShardingMerger<TEntity>
    {
        public DefaultEnumerableShardingMerger(StreamMergeContext streamMergeContext,bool async) : base(streamMergeContext,async)
        {
        }

        protected override IStreamMergeAsyncEnumerator<TEntity> StreamInMemoryMerge(List<IStreamMergeAsyncEnumerator<TEntity>> parallelResults)
        {
            if (GetStreamMergeContext().IsPaginationQuery())
                return new PaginationStreamMergeAsyncEnumerator<TEntity>(GetStreamMergeContext(), parallelResults, 0, GetStreamMergeContext().GetPaginationReWriteTake());//�ڴ�ۺϷ�ҳ������ֱ�ӻ�ȡskip�����ȡskip+take����Ŀ

            return base.StreamInMemoryMerge(parallelResults);
        }
    } 
}
