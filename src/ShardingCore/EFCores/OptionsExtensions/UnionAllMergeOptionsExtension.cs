﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace ShardingCore.EFCores.OptionsExtensions
{
    /*
    * @Author: xjm
    * @Description:
    * @Date: 2021/10/17 20:27:12
    * @Ver: 1.0
    * @Email: 326308290@qq.com
    */

#if !NETCOREAPP2_0 && !NETSTANDARD2_0 && !NETCOREAPP3_0 && !NETSTANDARD2_1 && !NET5_0 && !NET6_0
    error
#endif
#if NET6_0
    public class UnionAllMergeOptionsExtension : IDbContextOptionsExtension
    {
        public void ApplyServices(IServiceCollection services)
        {
        }

        public void Validate(IDbContextOptions options)
        {
        }


        public DbContextOptionsExtensionInfo Info => new UnionAllMergeDbContextOptionsExtensionInfo(this);

        private class UnionAllMergeDbContextOptionsExtensionInfo : DbContextOptionsExtensionInfo
        {
            public UnionAllMergeDbContextOptionsExtensionInfo(IDbContextOptionsExtension extension) : base(extension)
            {
            }

            public override int GetServiceProviderHashCode() => 0;

            public override bool ShouldUseSameServiceProvider(DbContextOptionsExtensionInfo other) => true;

            public override void PopulateDebugInfo(IDictionary<string, string> debugInfo)
            {
            }

            public override bool IsDatabaseProvider => false;
            public override string LogFragment => "UnionAllMergeOptionsExtension";
        }
    }
#endif
#if NETCOREAPP3_0 || NETSTANDARD2_0 || NET5_0 || NETSTANDARD2_1

     public class UnionAllMergeOptionsExtension: IDbContextOptionsExtension
    {
        public void ApplyServices(IServiceCollection services)
        {
        }

        public void Validate(IDbContextOptions options)
        {
        }


        public DbContextOptionsExtensionInfo Info => new UnionAllMergeDbContextOptionsExtensionInfo(this);

        private class UnionAllMergeDbContextOptionsExtensionInfo : DbContextOptionsExtensionInfo
        {
            public UnionAllMergeDbContextOptionsExtensionInfo(IDbContextOptionsExtension extension) : base(extension) { }

            public override long GetServiceProviderHashCode() => 0;

            public override void PopulateDebugInfo(IDictionary<string, string> debugInfo) { }

            public override bool IsDatabaseProvider => false;
            public override string LogFragment => "UnionAllMergeOptionsExtension";
        }
    }

#endif
#if NETCOREAPP2_0

    public class UnionAllMergeOptionsExtension: IDbContextOptionsExtension
    {
        public bool ApplyServices(IServiceCollection services)
        {
            return false;
        }

        public long GetServiceProviderHashCode() => 0;

        public void Validate(IDbContextOptions options)
        {
        }

        public string LogFragment => "UnionAllMergeOptionsExtension";
    }
#endif
}
