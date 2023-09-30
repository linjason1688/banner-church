#region

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.MinistryRespUsers.Dtos;
using AutoMapper;
using MediatR;
using Yozian.Extension.Pagination;
using Yozian.Extension;
using App.Application.Managements.Users.Dtos;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

#endregion

namespace App.Application.Managements.MinistryRespUsers.Queries.QueryMinistryRespUser
{
    /// <summary>
    /// 分頁查詢 MinistryRespUser
    /// </summary>
    public class QueryMinistryRespUserRequest 
        : PageableQuery, IRequest<Page<MinistryRespUserView>>
    {
        /// <summary>
        /// id
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        public long? UserId { get; set; }

        /// <summary>
        /// 事工團職分明細主檔id
        /// </summary>
        public long? MinistryRespId { get; set; }
    }

    /// <summary>
    ///  分頁查詢 MinistryRespUser
    /// </summary>
    public class QueryMinistryRespUserRequestHandler 
        : IRequestHandler<QueryMinistryRespUserRequest, Page<MinistryRespUserView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryMinistryRespUserRequestHandler(
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
        public async Task<Page<MinistryRespUserView>> Handle(
            QueryMinistryRespUserRequest request,
            CancellationToken cancellationToken
        )
        {
            var lst = from u in this.appDbContext.MinistryRespUsers

                      join r in this.appDbContext.MinistryResps on u.MinistryRespId equals r.Id into subR
                      from result1 in subR.DefaultIfEmpty()

                      join r in this.appDbContext.Ministries on result1.MinistryId equals r.Id into subM
                      from result2 in subM.DefaultIfEmpty()

                      join p in this.appDbContext.MinistryDefs on result2.MinistryDefId equals p.Id into subP
                      from result3 in subP.DefaultIfEmpty()
                      select new MinistryRespUserView
                      {
                          Id = u.Id,
                          MinistryName = result2.Name,
                          MinistryDefName = result3.Name,
                          MinistryRespName = result1.Name,
                          HandledId = u.HandledId,
                          Comment = u.Comment,
                          DateCreate = u.DateCreate,
                          UserCreate = u.UserCreate,
                          DateUpdate = u.DateUpdate,
                          UserUpdate = u.UserUpdate,
                          MinistryRespId = u.MinistryRespId,
                          UserId = u.UserId,
                          MinistryRespUserStatus = u.MinistryRespUserStatus,
                          StatusCd = u.StatusCd
                      };

            var result = await lst
               .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)
               .WhereWhen(Convert.ToInt64(request.UserId) > 0, c => c.UserId == request.UserId)
               .WhereWhen(Convert.ToInt64(request.MinistryRespId) > 0, c => c.MinistryRespId == request.MinistryRespId)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);


            var ids = result.Records.Select(c => c.UserId).Distinct();

            var userLst = await this.appDbContext.Users.Where(c => ids.Contains(c.Id))
                                    .ProjectTo<UserView>(this.mapper.ConfigurationProvider)
                                    .ToListAsync(cancellationToken);

            foreach (var obj in result.Records)
            {
                obj.userView = userLst.FirstOrDefault(c => c.Id == obj.UserId);
            }

            return result;

        }
    }
}
