#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Constants;
using App.Application.Common.Attributes;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.MinistrySchedules.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.MinistrySchedules.Queries.QueryMinistrySchedule
{
    /// <summary>
    /// 分頁查詢 MinistrySchedule
    /// </summary>

    public class QueryMinistryScheduleRequest 
        : PageableQuery, IRequest<Page<MinistryScheduleView>>
    {



        /// <summary>
        ///  Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///  Ministry.Id
        /// </summary>
        public long MinistryId { get; set; }

        /// <summary>
        ///  排程名稱
        /// </summary>
        public string Name { get; set; }



        /// <summary>
        ///  週期類別        對應type=CycleType        顯示 name         value存此欄位 0：固定週期 1：非固定週期(偶發類型)
        /// </summary>
        public string CycleType { get; set; }

        /// <summary>
        ///  重複間隔
        /// </summary>
        public string RepeatTime { get; set; }

        /// <summary>
        ///  重複間隔單位        對應type=RepeatTimeUnit        顯示 name        value存此欄位 0：日 1：週 2：月 3：年
        /// </summary>
        public string RepeatTimeUnit { get; set; }

        /// <summary>
        ///  結束時間類別        對應type=EndDateType        顯示 name        value存此欄位 0：持續不停 1：於 2：重複
        /// </summary>
        public string EndDateType { get; set; }

        /// <summary>
        /// 結束時間日期
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// 結束時間日期
        /// </summary>
        public string RepeaTimes { get; set; }
    }

    /// <summary>
    ///  分頁查詢 MinistrySchedule
    /// </summary>
    public class QueryMinistryScheduleRequestHandler 
        : IRequestHandler<QueryMinistryScheduleRequest, Page<MinistryScheduleView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryMinistryScheduleRequestHandler(
            IMapper mapper,
            IAppDbContext appDbContext
        )
        {
            this.mapper = mapper;

            this.appDbContext = appDbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        
        
        /// <returns></returns>
        public async Task<Page<MinistryScheduleView>> Handle(
            QueryMinistryScheduleRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .MinistrySchedules
               .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)//事工團職分明細主檔id
                 .WhereWhen(Convert.ToInt64(request.MinistryId ) != 0, c => c.MinistryId == request.MinistryId )//事工團.Id
                .WhereWhenNotEmpty(request.Name?.ToString(), c => c.Name == request.Name)//排程名稱
                .WhereWhenNotEmpty(request.CycleType.ToString(), c => c.CycleType == request.CycleType)//週期類別對應type=CycleType顯示 namevalue存此欄位0：固定週期1：非固定週期(偶發類型)
                .WhereWhenNotEmpty(request.RepeatTime.ToString(), c => c.RepeatTime == request.RepeatTime)//重複間隔
                .WhereWhenNotEmpty(request.RepeatTimeUnit.ToString(), c => c.RepeatTimeUnit == request.RepeatTimeUnit)//重複間隔單位對應type=RepeatTimeUnit顯示 namevalue存此欄位0：日1：週2：月3：年
                .WhereWhenNotEmpty(request.EndDateType.ToString(), c => c.EndDateType == request.EndDateType)//結束時間類別對應type=EndDateType顯示 namevalue存此欄位0：持續不停1：於2：重複
                .WhereWhenNotEmpty(request.EndDate?.ToString(), c => c.EndDate == request.EndDate)//結束時間日期
                .WhereWhenNotEmpty(request.RepeaTimes?.ToString(), c => c.RepeaTimes == request.RepeaTimes)//結束時間日期

               .ProjectTo<MinistryScheduleView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
