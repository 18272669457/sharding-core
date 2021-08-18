﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sample.SqlServer.DbContexts;
using Sample.SqlServer.Domain.Entities;
using ShardingCore.DbContexts.VirtualDbContexts;
using ShardingCore.Extensions;

namespace Sample.SqlServer.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ValuesController : ControllerBase
    {

        private readonly DefaultShardingDbContext _defaultTableDbContext;

        public ValuesController(DefaultShardingDbContext defaultTableDbContext)
        {
            _defaultTableDbContext = defaultTableDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resultx1121 = await _defaultTableDbContext.Set<SysUserMod>().Where(o => o.Id == "198").SumAsync(o=>o.Age);
            var resultx111 = await _defaultTableDbContext.Set<SysUserMod>().FirstOrDefaultAsync(o => o.Id == "198");
            var resultx2 = await _defaultTableDbContext.Set<SysUserMod>().CountAsync(o => o.Age<=10);
            var resultx = await _defaultTableDbContext.Set<SysUserMod>().Where(o => o.Id == "198").FirstOrDefaultAsync();
            var resultx33 = await _defaultTableDbContext.Set<SysUserMod>().Where(o => o.Id == "198").Select(o=>o.Id).FirstOrDefaultAsync();
            var result = await _defaultTableDbContext.Set<SysUserMod>().ToListAsync();

            var sysUserMod98 = result.FirstOrDefault(o => o.Id == "98");
            sysUserMod98.Name = "name_update"+new Random().Next(1,99)+"_98";
            await _defaultTableDbContext.SaveChangesAsync();
            return Ok(result);
        }
    }
} 