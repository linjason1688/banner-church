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
using App.Application.Managements.Organizations.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.Organizations.Queries.QueryOrganization
{
    /// <summary>
    /// 分頁查詢 Organization
    /// </summary>

    public class QueryOrganizationRequest
        : PageableQuery, IRequest<Page<OrganizationView>>
    {

        /// <summary>
        ///  Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        ///  以前欄位Id
        /// </summary>
        public long OrganizationId { get; set; }
        /// <summary>
        ///  上層
        /// </summary>
        public long UpperOrganizationId { get; set; }
        /// <summary>
        ///  舊欄位對應部門id Portal.Id        
        /// </summary>
        public long PastoralId { get; set; }

        /// <summary>
        ///  組織名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  主任牧師名稱
        /// </summary>
        public string PastorName { get; set; }

        /// <summary>
        ///  主任牧師User.Id
        /// </summary>
        public long PastorId { get; set; }

        /// <summary>
        ///  主任牧師身分證
        /// </summary>
        public string Pastor { get; set; }
        /// <summary>
        ///  主任牧師電話
        /// </summary>
        public string Pastorphone { get; set; }


        /// <summary>
        ///  
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        ///  教會電話
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        ///  教會傳真
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        ///  教會Email
        /// </summary>
        public string Site { get; set; }
        /// <summary>
        ///  教會網址
        /// </summary>
        public string Zip { get; set; }
        /// <summary>
        ///  教會郵遞區號
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        ///  教會地址
        /// </summary>
        public string InvoiceIdentifier { get; set; }
        /// <summary>
        ///  教會統一編號抬頭
        /// </summary>
        public string InvoiceTitle { get; set; }

        /// <summary>
        /// 是否需要發票抬頭        對應SystemConfig        type = IsYN顯示 namevalue存此欄位0：N1：Y
        /// </summary>
        public string? IsInvoiceTitle { get; set; }

        /// <summary>
        /// 組織狀態        對應SystemConfig        type =OrgStatus顯示 namevalue存此欄位0：停用 1：正常
        /// </summary>
        public string? OrgStatus { get; set; }


        public string DeptName { get; set; }

        /// <summary>
        ///  DeptId
        /// </summary>
        public long DeptId { get; set; }
    }

    /// <summary>
    ///  分頁查詢 Organization
    /// </summary>
    public class QueryOrganizationRequestHandler
        : IRequestHandler<QueryOrganizationRequest, Page<OrganizationView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryOrganizationRequestHandler(
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
        public async Task<Page<OrganizationView>> Handle(
            QueryOrganizationRequest request,
            CancellationToken cancellationToken
        )
        {

            var deptIds = new List<long>();

            if (!string.IsNullOrEmpty(request.DeptName))
            {
                deptIds = await this.appDbContext.Depts.Where(c => c.Name == request.DeptName).Select(c => c.Id).ToListAsync();
            }

            var result = await this.appDbContext
               .Organizations
                .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)//
                .WhereWhenNotEmpty(request.Name?.ToString(), c => c.Name == request.Name)//顯示資訊
                .WhereWhenNotEmpty(request.PastorName?.ToString(), c => c.PastorName == request.PastorName)//主任牧師名稱
                 .WhereWhen(Convert.ToInt64(request.DeptId) != 0, c => c.DeptId == request.DeptId)//DeptId
                .WhereWhen(Convert.ToInt64(request.PastorId) != 0, c => c.PastorId == request.PastorId)//主任牧師UserId
                .WhereWhenNotEmpty(request.Pastor?.ToString(), c => c.Pastor == request.Pastor)//主任牧師身分證
                .WhereWhenNotEmpty(request.Pastorphone?.ToString(), c => c.Pastorphone == request.Pastorphone)//主任牧師電話
                .WhereWhenNotEmpty(request.Phone?.ToString(), c => c.Phone == request.Phone)//教會電話
                .WhereWhenNotEmpty(request.Fax?.ToString(), c => c.Fax == request.Fax)//教會傳真
                .WhereWhenNotEmpty(request.Email?.ToString(), c => c.Email == request.Email)//教會Email
                .WhereWhenNotEmpty(request.Site?.ToString(), c => c.Site == request.Site)//教會網址
                .WhereWhenNotEmpty(request.Zip?.ToString(), c => c.Zip == request.Zip)//教會郵遞區號
                .WhereWhenNotEmpty(request.Address?.ToString(), c => c.Address == request.Address)//教會地址
                .WhereWhenNotEmpty(request.InvoiceIdentifier?.ToString(), c => c.InvoiceIdentifier == request.InvoiceIdentifier)//教會統一編號
                .WhereWhenNotEmpty(request.InvoiceTitle?.ToString(), c => c.InvoiceTitle == request.InvoiceTitle)//教會抬頭
                .WhereWhenNotEmpty(request.IsInvoiceTitle, c => c.IsInvoiceTitle == request.IsInvoiceTitle)//是否需要發票抬頭對應SystemConfigtype=IsYN顯示 namevalue存此欄位0：N1：Y
                .WhereWhenNotEmpty(request.OrgStatus, c => c.OrgStatus == request.OrgStatus)
                .WhereWhen(deptIds.Count > 0, c => deptIds.Contains(c.DeptId))
               .ProjectTo<OrganizationView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);


            foreach (var obj in result.Records)
            {
                obj.SubCounter = await this.appDbContext.Organizations.Where(c => c.UpperOrganizationId == obj.Id).CountAsync();
                var list = new List<string>();
                await this.SearchParentNode(obj.DeptId, list);
                list.Reverse();
                if (list.Count > 0)
                {
                    obj.DeptTreeName = String.Join("/", list);
                }

            }

            return result;

        }

        public async Task<string> SearchParentNode(long deptId, List<string> list)
        {
            var self = await this.appDbContext.Depts.Where(c => c.Id == deptId).FirstOrDefaultAsync();
            if (self != null)
            {
                list.Add(self.Name);
                if (self.UpperDeptId != 0)
                {
                    await SearchParentNode(self.UpperDeptId, list);
                }
            }
            return "";
        }
    }
}
