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
using App.Application.Managements.CourseAppendixs.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.CourseAppendixs.Queries.QueryCourseAppendix
{
    /// <summary>
    /// 分頁查詢 CourseAppendix
    /// </summary>

    public class QueryCourseAppendixRequest 
        : PageableQuery, IRequest<Page<CourseAppendixView>>
    {

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }


        ///  <summary>
        ///課程類別CourseManagement.Id
        /// </summary>
        public long CourseId { get; set; }
        ///  <summary>
        ///附件類別對應type=AppendixType顯示 namevalue存此欄位0：文件1：影音
        /// </summary>
        public string AppendixType { get; set; }
        ///  <summary>
        ///存放網路路徑
        /// </summary>
        public string Path { get; set; }
    }

    /// <summary>
    ///  分頁查詢 CourseAppendix
    /// </summary>
    public class QueryCourseAppendixRequestHandler 
        : IRequestHandler<QueryCourseAppendixRequest, Page<CourseAppendixView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryCourseAppendixRequestHandler(
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
        public async Task<Page<CourseAppendixView>> Handle(
            QueryCourseAppendixRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .CourseAppendixs
               .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)//教會開課主檔
               .WhereWhen(Convert.ToInt64(request.CourseId) != 0, c => c.CourseId == request.CourseId)
                .WhereWhenNotEmpty(request.AppendixType?.ToString(), c => c.AppendixType == request.AppendixType)//附件類別對應type=AppendixType顯示 namevalue存此欄位0：文件1：影音
                .WhereWhenNotEmpty(request.Path?.ToString(), c => c.Path == request.Path)//存放網路路徑

               .ProjectTo<CourseAppendixView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
