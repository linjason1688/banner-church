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
using App.Application.Managements.CoursePrices.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.CoursePrices.Queries.QueryCoursePrice
{
    /// <summary>
    /// 分頁查詢 CoursePrice
    /// </summary>

    public class QueryCoursePriceRequest 
        : PageableQuery, IRequest<Page<CoursePriceView>>
    {

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }


        ///  <summary>
        ///課程類別Course.Id
        /// </summary>
        public long CourseId { get; set; }
        ///  <summary>
        ///價格名稱
        /// </summary>
        public string PriceName { get; set; }
        ///  <summary>
        ///價格
        /// </summary>
        public int Price { get; set; }
        ///  <summary>
        ///是否公開對應type=IsYN顯示 namevalue存此欄位0：N1：Y
        /// </summary>
        public string IsPublic { get; set; }
        ///  <summary>
        ///是否超過優惠日期後關閉對應type=IsYN顯示 namevalue存此欄0N1Yif1ThendataTimeCourse.DiscountSignUpDate關閉此選項
        /// </summary>
        public string IsDueDate { get; set; }
    }

    /// <summary>
    ///  分頁查詢 CoursePrice
    /// </summary>
    public class QueryCoursePriceRequestHandler 
        : IRequestHandler<QueryCoursePriceRequest, Page<CoursePriceView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryCoursePriceRequestHandler(
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
        public async Task<Page<CoursePriceView>> Handle(
            QueryCoursePriceRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .CoursePrices
               .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)//開課價格主檔
                .WhereWhen(Convert.ToInt64(request.CourseId) != 0, c => c.CourseId == request.CourseId)//課程類別Course.Id
                .WhereWhenNotEmpty(request.PriceName?.ToString(), c => c.PriceName == request.PriceName)//價格名稱
                .WhereWhenNotEmpty(request.Price.ToString(), c => c.Price == request.Price)//存放網路路徑
                .WhereWhenNotEmpty(request.IsPublic, c => c.IsPublic == request.IsPublic)//是否公開對應type=IsYN顯示 namevalue存此欄位0：N1：Y
                .WhereWhenNotEmpty(request.IsDueDate, c => c.IsDueDate == request.IsDueDate)//是否超過優惠日期後關閉對應type=IsYN顯示 namevalue存此欄0N1Yif1ThendataTimeCourse.DiscountSignUpDate關閉此選項

               .ProjectTo<CoursePriceView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
