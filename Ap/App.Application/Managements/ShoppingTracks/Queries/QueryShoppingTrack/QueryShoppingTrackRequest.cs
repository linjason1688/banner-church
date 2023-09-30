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
using App.Application.Managements.ShoppingTracks.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.ShoppingTracks.Queries.QueryShoppingTrack
{
    /// <summary>
    /// 分頁查詢 ShoppingTrack
    /// </summary>

    public class QueryShoppingTrackRequest
        : PageableQuery, IRequest<Page<ShoppingTrackView>>
    {

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }


        ///  <summary>
        ///User.Id
        /// </summary>
        public long UserId { get; set; }


        ///  <summary>
        ///課程類別Course.Id
        /// </summary>
        public long CourseId { get; set; }


      
    }

    /// <summary>
    ///  分頁查詢 ShoppingTrack
    /// </summary>
    public class QueryShoppingTrackRequestHandler
        : IRequestHandler<QueryShoppingTrackRequest, Page<ShoppingTrackView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryShoppingTrackRequestHandler(
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
        public async Task<Page<ShoppingTrackView>> Handle(
            QueryShoppingTrackRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ShoppingTracks                   
               .WhereWhen(Convert.ToInt64(request.Id) != 0, c => c.Id == request.Id) ////購物車主檔                 
               .WhereWhen(Convert.ToInt64(request.UserId) != 0, c => c.UserId == request.UserId) //User.Id                  
               .WhereWhen(Convert.ToInt64(request.CourseId) != 0, c => c.CourseId == request.CourseId)
               .ProjectTo<ShoppingTrackView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
