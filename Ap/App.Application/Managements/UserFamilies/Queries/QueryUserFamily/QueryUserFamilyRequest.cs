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
using App.Application.Managements.UserFamilies.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.UserFamilies.Queries.QueryUserFamily
{
    /// <summary>
    /// 分頁查詢 UserFamily
    /// </summary>

    public class QueryUserFamilyRequest 
        : PageableQuery, IRequest<Page<UserFamilyView>>
    {

        /// <summary>
        ///  Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 建立時間 User.Id
        /// </summary>
        public long UserId { get; set; }//建立時間 User.Id
        /// <summary>
        /// 關係類別 對應SystemConfig        type=RelativeType       顯示 name       value存此欄位0：配偶1：父母2：子女
        /// </summary>
        public string RelativeType { get; set; }//關係類別 對應SystemConfig        type=RelativeType       顯示 name       value存此欄位0：配偶1：父母2：子女
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }//姓名
    }

    /// <summary>
    ///  分頁查詢 UserFamily
    /// </summary>
    public class QueryUserFamilyRequestHandler 
        : IRequestHandler<QueryUserFamilyRequest, Page<UserFamilyView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryUserFamilyRequestHandler(
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
        public async Task<Page<UserFamilyView>> Handle(
            QueryUserFamilyRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
              .UserFamilies
              .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)//id
              .WhereWhen(Convert.ToInt64(request.UserId) > 0, c => c.UserId == request.UserId)//User.Id
              .WhereWhenNotEmpty(request.RelativeType.ToString(), c => c.RelativeType == request.RelativeType.ToString())//關係類別 對應SystemConfigtype=RelativeType顯示 namevalue存此欄位0：配偶1：父母2：子女
               .ProjectTo<UserFamilyView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
