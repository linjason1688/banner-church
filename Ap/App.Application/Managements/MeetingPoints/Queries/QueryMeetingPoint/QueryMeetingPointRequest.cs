using System;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.MeetingPoints.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Yozian.Extension;
using Yozian.Extension.Pagination;

namespace App.Application.Managements.MeetingPoints.Queries.QueryMeetingPoint
{
    /// <summary>
    /// 分頁查詢 MeetingPoint
    /// </summary>
    public class QueryMeetingPointRequest
        : PageableQuery, IRequest<Page<MeetingPointView>>
    {
        /// <summary>
        /// id
        /// </summary>
        public long? Id { get; set; }

      

        /// <summary>
        /// 聚會點名稱
        /// </summary>
        public string Name { get; set; }

     
    }

    /// <summary>
    ///  分頁查詢 MeetingPoint
    /// </summary>
    public class QueryMeetingPointRequestHandler
        : IRequestHandler<QueryMeetingPointRequest, Page<MeetingPointView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryMeetingPointRequestHandler(
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
        public async Task<Page<MeetingPointView>> Handle(
            QueryMeetingPointRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .MeetingPoints
               .WhereWhen(Convert.ToInt64(request.Id) != 0, c => c.Id == request.Id) //id

               .WhereWhenNotEmpty(request.Name, c => c.Name == request.Name) //名稱
             
               .ProjectTo<MeetingPointView>(this.mapper.ConfigurationProvider)
               // .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);
        }
    }
}
