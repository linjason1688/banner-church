using System;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.Ministries.Dtos;
using AutoMapper;
using MediatR;
using Yozian.Extension;
using Yozian.Extension.Pagination;
using System.Linq;
using App.Application.Common.Constants;

namespace App.Application.Managements.Ministries.Queries.QueryMinistry
{
    /// <summary>
    /// 分頁查詢 Ministry
    /// </summary>
    public class QueryMinistryRequest
        : PageableQuery, IRequest<Page<MinistryView>>
    {
        /// <summary>
        /// id
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// 堂點
        /// </summary>
        public long? OrganizationId { get; set; }

        /// <summary>
        /// 事工團分類id
        /// </summary>
        public long? MinistryDefId { get; set; }

        /// <summary>
        /// 事工團編號
        /// </summary>
        public string MinistryNo { get; set; }


        /// <summary>
        /// 事工團名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否兒童事工團
        /// </summary>
        public string ChildMinistry { get; set; }

        /// <summary>
        /// 事工團狀態
        /// </summary>
        public string MinistryStatus { get; set; }
    }

    /// <summary>
    ///  分頁查詢 Ministry
    /// </summary>
    public class QueryMinistryRequestHandler
        : IRequestHandler<QueryMinistryRequest, Page<MinistryView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryMinistryRequestHandler(
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
        public async Task<Page<MinistryView>> Handle(
            QueryMinistryRequest request,
            CancellationToken cancellationToken
        )
        {
            #region 子表查詢，先Join一個IQueryable<MinistryView>，再加條件
            var lst = from m in this.appDbContext.Ministries
                      join r in this.appDbContext.MinistryResps on m.Id equals r.MinistryId into subR from result1 in subR.DefaultIfEmpty()
                      join u in this.appDbContext.MinistryRespUsers on result1.Id equals u.MinistryRespId into subU from result2 in subU.DefaultIfEmpty()
                      join ou in this.appDbContext.OrganizationUsers on result2.UserId equals ou.OrganizationId into subOu from result3 in subOu.DefaultIfEmpty()
                      join o in this.appDbContext.Organizations on result3.OrganizationId equals o.Id into subO from result4 in subO.DefaultIfEmpty()
                      select new MinistryView
                      {
                          Id = m.Id,
                          OrganizationId = result3 != null ? result3.OrganizationId : 0L,
                          OrganizationName = result4 != null ? result4!.Name : "",
                          MinistryDefId = m.MinistryDefId,
                          MinistryNo = m.MinistryNo,
                          Name = m.Name,
                          ChildMinistry = m.ChildMinistry,
                          MinistryStatus = m.MinistryStatus,
                          Nature = m.Nature,
                          Comment = m.Comment,
                          DateCreate = m.DateCreate,
                          UserCreate = m.UserCreate,
                          DateUpdate = m.DateUpdate,
                          UserUpdate = m.UserUpdate
                      };

            return await lst
                        .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)
                        .WhereWhen(Convert.ToInt64(request.MinistryDefId) > 0, c => c.MinistryDefId == request.MinistryDefId)
                        .WhereWhenNotEmpty(request.MinistryNo, c => c.MinistryNo == request.MinistryNo)
                        .WhereWhenNotEmpty(request.Name, c => c.Name == request.Name)
                        .WhereWhenNotEmpty(request.ChildMinistry, c => c.ChildMinistry == request.ChildMinistry)
                        .WhereWhenNotEmpty(request.MinistryStatus, c => c.MinistryStatus == request.MinistryStatus)
                        .WhereWhen(Convert.ToInt64(request.OrganizationId) > 0, c => c.OrganizationId == request.OrganizationId)
                        .Distinct()
                        .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
                        .ToPageAsync(request);
            #endregion
        }
    }
}
