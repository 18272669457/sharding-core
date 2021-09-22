using System;
using System.Collections.Generic;
using ShardingCore.Core.PhysicTables;
using ShardingCore.Core.VirtualDatabase;
using ShardingCore.Core.VirtualDatabase.VirtualDataSources;
using ShardingCore.Core.VirtualRoutes.TableRoutes;
using ShardingCore.Sharding.PaginationConfigurations;

namespace ShardingCore.Core.VirtualTables
{
    /*
    * @Author: xjm
    * @Description:虚拟表在系统里面被映射为ef-core的表
    * @Date: Friday, 18 December 2020 14:06:31
    * @Email: 326308290@qq.com
    */
    /// <summary>
    /// 虚拟表
    /// </summary>
    public interface IVirtualTable
    {
        /// <summary>
        /// 分表的类型
        /// </summary>
        Type EntityType { get; }
        /// <summary>
        /// 分表配置
        /// </summary>
        ShardingEntityConfig ShardingConfig { get; }
        /// <summary>
        /// 分页配置
        /// </summary>
        PaginationMetadata PaginationMetadata { get; }
        /// <summary>
        /// 是否启用分页配置
        /// </summary>
        bool EnablePagination { get; }

        /// <summary>
        /// 获取所有的物理表
        /// </summary>
        /// <returns></returns>
        List<IPhysicTable> GetAllPhysicTables();

        /// <summary>
        /// 路由到具体的物理表 which physic table route
        /// </summary>
        /// <param name="tableRouteConfig"></param>
        /// <returns></returns>
        List<IPhysicTable> RouteTo(ShardingTableRouteConfig tableRouteConfig);

        /// <summary>
        /// 添加物理表 add physic table
        /// </summary>
        /// <param name="physicTable"></param>
        /// <returns>添加成功</returns>
        bool AddPhysicTable(IPhysicTable physicTable);

        /// <summary>
        /// 设置原始表名 get original table name when app start
        /// <see cref="ShardingBootstrapper"/>
        /// </summary>
        /// <param name="originalTableName"></param>
        void SetVirtualTableName(string originalTableName);
        /// <summary>
        /// 获取原始表名 get original table name
        /// </summary>
        /// <returns></returns>
        string GetVirtualTableName();
        /// <summary>
        /// 获取当前虚拟表的路由 get this virtual table route
        /// </summary>
        /// <returns></returns>
        IVirtualTableRoute GetVirtualRoute();
        /// <summary>
        /// 获取启动时已经存在的表后缀 get this virtual table exists tails when app start
        /// <see cref="ShardingBootstrapper"/> CreateDateTables
        /// </summary>
        /// <returns></returns>
        List<string> GetTaleAllTails();
    }

    public interface IVirtualTable<T> : IVirtualTable where T : class,IShardingTable
    {
        new IVirtualTableRoute<T> GetVirtualRoute();
    }
}