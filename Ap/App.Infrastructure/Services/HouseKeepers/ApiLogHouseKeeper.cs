using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Application.Common.Interfaces;
using App.Domain.Entities.Core;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.DependencyInjectionPlus.Attributes;

namespace App.Infrastructure.Services.HouseKeepers
{
    /// <summary>
    /// </summary>
    [TransientService]
    public class ApiLogHouseKeeper
    {
        private readonly IAppDbContext appDbContext;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        public ApiLogHouseKeeper(
            IMapper mapper,
            ILogger<ApiLogHouseKeeper> logger,
            IAppDbContext appDbContext
        )
        {
            this.mapper = mapper;
            this.logger = logger;
            this.appDbContext = appDbContext;
        }


        /// <summary>
        /// 清理 api log 檔
        /// </summary>
        /// <param name="date">該日期前之 log 資料都會被清掉</param>
        /// <returns>總刪除筆數</returns>
        public async Task<int> CleanupAsync(DateTime date)
        {
            if (!this.appDbContext.IsRelational())
            {
                return -1;
            }

            var targetDate = date.ToString("yyyy-MM-dd 00:00:00");

            var tableName = this.appDbContext.ApiAuditLog.EntityType.GetTableName();

            var effectCount = await this.appDbContext
               .ExecuteRawSqlNoneQueryAsync(
                    $"DELETE FROM [dbo].[{tableName}] WHERE [{nameof(ApiAuditLog.DateCreate)}] < '{targetDate}'"
                );

            return effectCount;
        }
    }
}
