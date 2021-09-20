using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShardingCore.Core.VirtualDatabase.VirtualTables;
using ShardingCore.Core.VirtualTables;
using ShardingCore.Sharding.Abstractions;

namespace ShardingCore.Core.VirtualRoutes.TableRoutes.RoutingRuleEngine
{
    /*
    * @Author: xjm
    * @Description:
    * @Date: Thursday, 28 January 2021 13:31:06
    * @Email: 326308290@qq.com
    */
    /// <summary>
    /// ��·�ɹ������湤��
    /// </summary>
    public class TableRouteRuleEngineFactory<TShardingDbContext> : ITableRouteRuleEngineFactory<TShardingDbContext> where TShardingDbContext : DbContext, IShardingDbContext
    {
        private readonly ITableRouteRuleEngine<TShardingDbContext> _tableRouteRuleEngine;

        public TableRouteRuleEngineFactory(ITableRouteRuleEngine<TShardingDbContext> tableRouteRuleEngine)
        {
            _tableRouteRuleEngine = tableRouteRuleEngine;
        }
        /// <summary>
        /// ������·��������
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dsname"></param>
        /// <param name="queryable"></param>
        /// <returns></returns>
        public TableRouteRuleContext<T> CreateContext<T>(IQueryable<T> queryable)
        {
            return new TableRouteRuleContext<T>(queryable);
        }

        public IEnumerable<TableRouteResult> Route<T>(IQueryable<T> queryable)
        {
            var ruleContext = CreateContext<T>(queryable);
            return _tableRouteRuleEngine.Route(ruleContext);
        }

        public IEnumerable<TableRouteResult> Route<T>(TableRouteRuleContext<T> ruleContext)
        {
            return _tableRouteRuleEngine.Route(ruleContext);
        }
    }
}