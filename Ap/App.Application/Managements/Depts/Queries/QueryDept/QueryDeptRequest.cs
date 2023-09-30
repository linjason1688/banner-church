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
using App.Application.Managements.Depts.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.Depts.Queries.QueryDept
{
    /// <summary>
    /// 分頁查詢 Dept
    /// </summary>

    public class QueryDeptRequest 
        : PageableQuery, IRequest<Page<DeptView>>
    {

        /// <summary>
        ///  Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        ///  以前欄位Id
        /// </summary>
        public long DeptId { get; set; }
        /// <summary>
        ///  上層
        /// </summary>
        public long UpperDeptId { get; set; }
        /// <summary>
        ///  舊欄位對應部門id Portal.Id        
        /// </summary>
        public long PastoralId { get; set; }

        /// <summary>
        ///  部門名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  部門主管職稱
        /// </summary>
        public string Title { get; set; }



    
    }

    /// <summary>
    ///  分頁查詢 Dept
    /// </summary>
    public class QueryDeptRequestHandler 
        : IRequestHandler<QueryDeptRequest, Page<DeptView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryDeptRequestHandler(
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
        public async Task<Page<DeptView>> Handle(
            QueryDeptRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .Depts
                .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)//
                .WhereWhenNotEmpty(request.Name?.ToString(), c => c.Name == request.Name)//顯示資訊
                .WhereWhenNotEmpty(request.Title?.ToString(), c => c.Title == request.Title)//顯示資訊
               .ProjectTo<DeptView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
