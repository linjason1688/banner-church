#region

using System;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.Pastorals.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Yozian.Extension.Pagination;
using Yozian.Extension;
using System.Linq;
using Microsoft.EntityFrameworkCore;

#endregion

namespace App.Application.Managements.Pastorals.Queries.QueryPastoral
{
    /// <summary>
    /// 分頁查詢 Pastoral
    /// </summary>
    public class QueryPastoralRequest 
        : PageableQuery, IRequest<Page<PastoralView>>
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 組織上層Id (分多階層)        堂點       牧區 督區 區 小組
        /// </summary>
        public long UpperPastoralId { get; set; }

        /// <summary>
        /// 分組區域名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 分組區域職稱
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 小組編號//八碼數字 系統自動產生(為小組時才需填入)
        /// </summary>
        public string GroupNo { get; set; }

        /// <summary>
        /// 領導人 UserId
        /// </summary>
        public long? LeaderId { get; set; }
        /// <summary>
        /// 領導人身分證
        /// </summary>
        public string LeaderIdnumber { get; set; }

        /// <summary>
        /// 領導人2 UserId
        /// </summary>
        public long? Leader2Id { get; set; }

        /// <summary>
        /// 領導人2身分證
        /// </summary>
        public string Leader2Idnumber { get; set; }

        /// <summary>
        /// 領導人3 UserId
        /// </summary>
        public long? Leader3Id { get; set; }

        /// <summary>
        /// 領導人3身分證
        /// </summary>
        public string Leader3Idnumber { get; set; }

        /// <summary>
        /// 最大權限人UserId
        /// </summary>
        public long? SupervisorId { get; set; }

        public int? UpperOrganizationId { get; set; }
        public int OrgId { get; set; }
        public int? TypeId { get; set; }
    }

    /// <summary>
    ///  分頁查詢 Pastoral
    /// </summary>
    public class QueryPastoralRequestHandler 
        : IRequestHandler<QueryPastoralRequest, Page<PastoralView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryPastoralRequestHandler(
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
        public async Task<Page<PastoralView>> Handle(
            QueryPastoralRequest request,
            CancellationToken cancellationToken
        )
        {
            var result = await this.appDbContext
               .Pastorals
               .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)//id
               .WhereWhen(Convert.ToInt64(request.UpperPastoralId ) != 0, c => c.UpperPastoralId == request.UpperPastoralId )//組織上層Id (分多階層)堂點牧區督區區小組
               .WhereWhenNotEmpty(request.Name, c => c.Name == request.Name)//分組區域名稱
               .WhereWhenNotEmpty(request.Title, c => c.Title == request.Title)//分組區域職稱
               .WhereWhenNotEmpty(request.GroupNo, c => c.GroupNo == request.GroupNo)//小組編號//八碼數字系統自動產生(為小組時才需填入)"
               .WhereWhen(Convert.ToInt64(request.LeaderId) > 0, c => c.LeaderId == request.LeaderId)//領導人 UserId
               .WhereWhenNotEmpty(request.LeaderIdnumber, c => c.LeaderIdNumber == request.LeaderIdnumber)//領導人身分證
               .WhereWhen(Convert.ToInt64(request.Leader2Id) > 0, c => c.Leader2Id == request.Leader2Id)//領導人 2UserId
               .WhereWhenNotEmpty(request.Leader2Idnumber, c => c.Leader2IdNumber == request.Leader2Idnumber)//領導人 2身分證
               .WhereWhen(Convert.ToInt64(request.Leader3Id) > 0, c => c.Leader3Id == request.Leader3Id)//領導人 3UserId
               .WhereWhenNotEmpty(request.Leader3Idnumber, c => c.Leader3IdNumber == request.Leader3Idnumber)//領導人 3身分證
               .WhereWhen(Convert.ToInt64(request.SupervisorId) > 0, c => c.SupervisorId == request.SupervisorId)//最大權限人UserId
               .ProjectTo<PastoralView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

            foreach (var obj in result.Records)
            {
                obj.SubCounter = await this.appDbContext.Pastorals.Where(c => c.UpperPastoralId == obj.Id).CountAsync();
            }


            return result;
        }
    }
}
