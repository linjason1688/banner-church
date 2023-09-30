using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Application.Common.Interfaces;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetTopologySuite.Utilities;
using Yozian.DependencyInjectionPlus.Attributes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace App.Infrastructure.Services.HouseKeepers
{
    /// <summary>
    /// </summary>
    [TransientService]
    public class UserInfoTransferKeeper
    {
        private readonly IAppDbContext appDbContext;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        public UserInfoTransferKeeper(
            IMapper mapper,
            ILogger<UserInfoTransferKeeper> logger,
            IAppDbContext appDbContext
        )
        {
            this.mapper = mapper;
            this.logger = logger;
            this.appDbContext = appDbContext;
        }


        /// <summary>
        /// 轉移外部User資料進來
        /// </summary>
        /// <param name="date">轉移外部User資料進來</param>
        /// <returns>總筆數</returns>
        //1.從另一個連線字串抓取資料庫 跟資料表
        //        var connectionString = "Server=119.14.168.195,1433;Database=HRMS;user id=gamma;password=2022@gamma;TrustServerCertificate=true";
        //        Dt_vw_EmpDataPublicType221= select* from vw_EmpDataPublicType221 ;
        //  Dt_Department=  select distinct[部門]  FROM[HRMS].[dbo].[vw_EmpDataPublicType221]
        //2. for loop比對一次抓出來的部門是否有沒有在現今資料庫內的部門資訊
        //foreach(department in Dt_Department)
        //{
        //	department= //架設資料為：客服事業組織 客服營運一處 客服五部 第2組
        //      //要去Itsm.Department抓看是否有
        //      select* from Department where Department =N'第2組' 
        //      and ParentDepartmentId in (select id from Department where Department =N'客服五部'   
        //      and ParentDepartmentId in (select id from Department where Department =N'客服營運一處'  
        // 	and ParentDepartmentId in (select id from Department where Department =N'客服事業組織')      
        //	//就要在Department 看是哪一層沒有 從最高層開始
        //      select count(*) from Department where Department = N'客服事業組織'
        //      //If count=0 表示沒有 就直接從這層開始建每一層的部門資訊
        //      Insert into Department(ParentDepartmentId, Name)(0,'客服事業組織');
        //      Insert into Department(ParentDepartmentId, Name)(select id from Department where Name=N'客服事業組織' and ParentDepartmentId = (select id from from Department where Name = N'客服事業組織') ,'客服營運一處');
        //        Insert into Department(ParentDepartmentId, Name)(select id from Department where Name=N'客服營運一處' and ParentDepartmentId = (select id from from Department where Name = N'客服營運一處' and ParentDepartmentId = (select id from from Department where Name = N'客服事業組織')) ,'客服五部');
        //        Insert into Department(ParentDepartmentId, Name)(select id from Department where Name=N'客服五部' and ParentDepartmentId = (select id from from Department where Name = N'客服五部' and ParentDepartmentId = (select id from from Department where Name = N'客服營運一處')) ,'第2組');

        //      ...............

        //      確認完部門主檔後 再更新User

        //      select* from User where JobNo=Dt_vw_EmpDataPublicType221["員工編號"]
        //      IF Count>0 :
        //		Update User set Position = Dt_vw_EmpDataPublicType221["職稱"], UserStatus = Dt_vw_EmpDataPublicType221["在職狀態"], Email = Dt_vw_EmpDataPublicType221["Email"] where JobNo = Dt_vw_EmpDataPublicType221["員工編號"], DepartmentId = 上面比對到的DepartmentId(最後一階的Id) //此例子為第2組Id 
        //      else :
        //            insert into User........................
        //}




        public async Task<int> TransferUserInfoAsync(DateTime date)
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
