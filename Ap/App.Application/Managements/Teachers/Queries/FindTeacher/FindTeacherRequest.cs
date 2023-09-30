#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
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
using Microsoft.Extensions.Logging;
using Yozian.Extension;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.Teachers.Queries.FindTeacher
{
    /// <summary>
    /// 取得  Teacher 單筆明細
    /// </summary>

    public class FindTeacherRequest 
        : IRequest<UserView>
    {
    
        public long Id { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class FindTeacherRequestHandler 
        : IRequestHandler<FindTeacherRequest, UserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindTeacherRequestHandler(
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
        public async Task<UserView> Handle(
            FindTeacherRequest request,
            CancellationToken cancellationToken
        )
        {
            //先抓角色檔的Id
            var Rst = this.appDbContext.Roles
                 .WhereWhen(1 == 1, c => c.Name == "講師");

            //抓User權限檔 是講師的角色
            var RUMst = this.appDbContext.RoleUserMappings.WhereWhen(1 == 1, c => Rst.Select(c => c.Id).Contains(c.RoleId));

            return await this.appDbContext
               .Users
              
               .WhereWhen(1 == 1, c => RUMst.Select(c => c.UserId).Contains(c.Id))//必須有講師角色的權限的User
               .Where(e => e.Id == request.Id)
               .ProjectTo<UserView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
