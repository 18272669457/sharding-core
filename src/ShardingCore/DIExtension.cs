using System;
using Microsoft.Extensions.DependencyInjection;
using ShardingCore.Core.Internal.RoutingRuleEngines;
using ShardingCore.Core.Internal.StreamMerge;
using ShardingCore.Core.ShardingAccessors;
using ShardingCore.Core.VirtualDataSources;
using ShardingCore.Core.VirtualRoutes.DataSourceRoutes.RoutingRuleEngine;
using ShardingCore.Core.VirtualTables;
using ShardingCore.DbContexts;
using ShardingCore.DbContexts.VirtualDbContexts;
using ShardingCore.TableCreator;

namespace ShardingCore
{
/*
* @Author: xjm
* @Description:
* @Date: Thursday, 28 January 2021 13:32:18
* @Email: 326308290@qq.com
*/
    public static class DIExtension
    {
        
        public static IServiceCollection AddShardingCore(this IServiceCollection services)
        {
            services.AddSingleton<IStreamMergeContextFactory, StreamMergeContextFactory>();
            services.AddScoped<IVirtualDbContext, VirtualDbContext>();

            services.AddSingleton<IShardingDbContextFactory, ShardingDbContextFactory>();
            services.AddSingleton<IShardingTableCreator, ShardingTableCreator>();
            //�ֿ�
            services.AddSingleton<IVirtualDataSourceManager, VirtualDataSourceManager>();
            //�ֿ�·�����湤��
            services.AddSingleton<IDataSourceRoutingRuleEngineFactory, DataSourceRoutingRuleEngineFactory>();
            //�ֿ�����
            services.AddSingleton<IDataSourceRoutingRuleEngine, DataSourceRoutingRuleEngine>();
            //�ֱ�
            services.AddSingleton<IVirtualTableManager, OneDbVirtualTableManager>();
            //�ֱ����湤��
            services.AddSingleton<IRoutingRuleEngineFactory, RoutingRuleEngineFactory>();
            //�ֱ�����
            services.AddSingleton<IRouteRuleEngine, QueryRouteRuleEngines>();
            //services.AddSingleton(typeof(IVirtualTable<>), typeof(OneDbVirtualTable<>));
            services.AddSingleton<IShardingAccessor, ShardingAccessor>();
            services.AddSingleton<IShardingScopeFactory, ShardingScopeFactory>();
            return services;
        }
    }
}