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
using App.Application.Managements.CourseManagementFilters.Dtos;
using App.Application.Managements.CourseOrganizations.Dtos;
using App.Application.Managements.Courses.Dtos;
using App.Application.Managements.CourseTimeSchedules.Dtos;
using App.Application.Managements.RoleUserMappings.Dtos;
using App.Application.Managements.Users.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Features;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.Users.Queries.FindUser
{
    /// <summary>
    /// 取得  User 單筆明細
    /// </summary>

    public class FindUserRequest
        : IRequest<UserView>
    {

        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindUserRequestHandler
        : IRequestHandler<FindUserRequest, UserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindUserRequestHandler(
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
            FindUserRequest request,
            CancellationToken cancellationToken
        )
        {



            //TODO：要取回RoleUserMappings的資料

            var result = await this.appDbContext.Users
                                   .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)
                                   .ProjectTo<UserView>(this.mapper.ConfigurationProvider)
                                   .FindOneAsync(cancellationToken);




            //抓User 角色 權限檔 
            //var RUMst = this.appDbContext.RoleUserMappings.WhereWhen(1 == 1, c => lst.Select(c => c.Id).Contains(c.UserId));

            //RoleUserMappingView


            if (result != null)
            {
               
            }
                if (result != null)
            {
                result.RoleUserMappingViews = await this.appDbContext.RoleUserMappings
                                                        .Where(c => result.Id == c.UserId)
                                                        .ProjectTo<RoleUserMappingView>(this.mapper.ConfigurationProvider)
                                                        .ToListAsync(cancellationToken);

                //串入父母配偶名稱
                if (result.ParentUserId != 0)
                {
                    var UserFamily = this.appDbContext.UserFamilies
                                                            .Where(c => result.ParentUserId == c.UserId)
                                                            .Where(c => "0" == c.RelativeType) //配偶
                                                            .SingleOrDefault();
                    if (UserFamily != null)
                    {
                        result.ParentSpouseName = UserFamily.Name;
                    }
                }

            }
            /*
            var result = from m in lst
                         join sod in RUMst on m.Id equals sod.UserId into lst1
                         select new UserView
                         {
                             Id = m.Id,
                             AnotherChurchName = m.AnotherChurchName,
                              CellAreaCode1 = m.CellAreaCode1,
                              CellAreaCode2 = m.CellAreaCode2,
                              
                              


                             DateCreate = m.DateCreate,
                          
                             Name = m.Name,
                           
                           


                             //關聯子表
                             RoleUserMappingViews = RUMst,

                         };

            */
            return result;
        }
    }
}
