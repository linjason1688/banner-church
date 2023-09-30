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
using App.Application.Managements.Teachers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;
using App.Application.Managements.Users.Dtos;

#endregion

namespace App.Application.Managements.Teachers.Queries.QueryTeacher
{
    /// <summary>
    /// 分頁查詢 Teacher
    /// </summary>

    public class QueryTeacherRequest 
        : PageableQuery, IRequest<Page<UserView>>
    {


        /// <summary>
        /// id
        /// </summary>
        public long? Id { get; set; }

        ///  <summary>
        ///      堂點Id Organization.Id
        /// </summary>
        public long? OrganizationId { get; set; }

        ///  <summary>
        ///講師姓名
        /// </summary>
        public string? Name { get; set; }

        ///  <summary>
        ///講師電話
        /// </summary>
        public string? Phone { get; set; }

        ///  <summary>
        ///性別 對應SystemConfigtype=GenderType顯示 namevalue存此欄位0：女姓1：男性
        /// </summary>
        public string? GenderType { get; set; }


        /*
        ///  <summary>
        ///組識主檔.Id
        /// </summary>
        public long OrganizationId { get; set; }

        /// <summary>
        /// userId 講師對應使用者主檔Id
        /// </summary>
        public long UserId { get; set; }

        ///  <summary>
        ///講師姓名
        /// </summary>
        public string TeacherName { get; set; }


        ///  <summary>
        ///連絡電話
        /// </summary>
        public string ContactPhone { get; set; }
        ///  <summary>
        ///聯絡手機
        /// </summary>
        public string ContactCellPhone { get; set; }
        ///  <summary>
        ///聯絡Email
        /// </summary>
        public string ContactEmail { get; set; }
        ///  <summary>
        ///備註
        /// </summary>
        public string Comment { get; set; }
        */
    }

    /// <summary>
    ///  分頁查詢 Teacher
    /// </summary>
    public class QueryTeacherRequestHandler 
        : IRequestHandler<QueryTeacherRequest, Page<UserView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryTeacherRequestHandler(
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
        public async Task<Page<UserView>> Handle(
            QueryTeacherRequest request,
            CancellationToken cancellationToken
        )
        {  //先抓角色檔的Id
            var Rst = this.appDbContext.Roles
                 .WhereWhen(1 == 1, c => c.Name.Contains("講師"));

            //抓User權限檔 是講師的角色
            var RUMst = this.appDbContext.RoleUserMappings.WhereWhen(1 == 1, c => Rst.Select(c => c.Id).Contains(c.RoleId));

            //從OrgUser抓User是哪一個Org
            var OrgUserLst = this.appDbContext.OrganizationUsers;

            return await this.appDbContext
               .Users
               .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.UserId == request.Id.ToString())//User.Id                                 
               .WhereWhenNotEmpty(request.GenderType?.ToString(), c => c.GenderType == request.GenderType)//性別 對應SystemConfigtype=GenderType顯示 namevalue存此欄位0：女姓1：男性
               .WhereWhenNotEmpty(request.Name, c => c.FirstName.Contains(request.Name) || c.LastName.Contains(request.Name) || c.Name.Contains(request.Name))
               .WhereWhenNotEmpty(request.Phone?.ToString(), c => c.CellPhone == request.Phone || c.CellPhone1 == request.Phone|| c.CellPhone1 == request.Phone)//電話

               .WhereWhen(1 == 1, c => RUMst.Select(c => c.UserId).Contains(c.Id))//必須有講師角色的權限的User         

               //過濾出來的User必須為該堂點的講師 OrganizationUsers
               //.WhereWhen(Convert.ToInt64(request.OrganizationId) != 0, c => OrgUserLst.Select(c => c.UserId).Contains(c.Id))
                .WhereWhen(request.OrganizationId.HasValue, c => OrgUserLst.Select(c => c.UserId).Contains(c.Id) )//堂點

               .ProjectTo<UserView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
