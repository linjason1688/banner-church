#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Teachers.Dtos;
using App.Application.Managements.Users.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.Teachers.Queries.FetchAllTeacher
{
    /// <summary>
    /// 查詢  Teacher 所有資料 透過User去串
    /// </summary>

    public class FetchAllTeacherRequest 
        : IRequest<List<UserView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
        /// <summary>
        /// User.Id
        /// </summary>
        public long? UserId { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllTeacherHandler 
        : IRequestHandler<FetchAllTeacherRequest, List<UserView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllTeacherHandler(
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
        public async Task<List<UserView>> Handle(
            FetchAllTeacherRequest request,
            CancellationToken cancellationToken
        )
        {
            //先抓角色檔的Id
            var Rst = this.appDbContext.Roles
                 .WhereWhen(1 == 1, c => c.Name == "講師");    
            
            //抓User權限檔 是講師的角色
            var RUMst = this.appDbContext.RoleUserMappings.WhereWhen(1==1 ,c=> Rst.Select(c => c.Id).Contains(c.RoleId));

            return await this.appDbContext
               .Users               
               .WhereWhen(Convert.ToInt64(request.UserId) > 0, c => c.UserId == request.UserId.ToString())//User.Id
               .WhereWhen(1 == 1, c => RUMst.Select(c => c.UserId).Contains(c.Id))//必須有講師角色的權限的User
               .ApplyLimitConstraint(request)
               .ProjectTo<UserView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
