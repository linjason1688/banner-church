#region

using System;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.MessageInformationUsers.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Yozian.Extension.Pagination;
using Yozian.Extension;
using System.Linq;

#endregion

namespace App.Application.Managements.MessageInformationUsers.Queries.QueryMessageInformationUser
{
    /// <summary>
    /// 分頁查詢 MessageInformationUser
    /// </summary>
    public class QueryMessageInformationUserRequest
        : PageableQuery, IRequest<Page<MessageInformationUserView>>
    {

        /// <summary>
        /// id
        /// </summary>
        public long? Id { get; set; }

        ///  <summary>
        ///User.Id Userid
        /// </summary>
        public long? UserId { get; set; }

        ///  <summary>
        /// User.LineId
        /// </summary>
        public string? LineId { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        public string StatusCd { get; set; }


        /// <summary>
        /// Head Id
        /// </summary>
        public long? MessageInformationId { get; set; }
    }

    /// <summary>
    ///  分頁查詢 MessageInformationUser
    /// </summary>
    public class QueryMessageInformationUserRequestHandler
        : IRequestHandler<QueryMessageInformationUserRequest, Page<MessageInformationUserView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryMessageInformationUserRequestHandler(
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
        public async Task<Page<MessageInformationUserView>> Handle(
            QueryMessageInformationUserRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .MessageInformationUsers
               .WhereWhen(request.MessageInformationId.HasValue, c => c.MessageInformationId == request.MessageInformationId)
               .WhereWhen(Convert.ToInt64(request.Id) != 0, c => c.Id == request.Id) //id
               .WhereWhenNotEmpty(request.StatusCd, c => c.StatusCd == request.StatusCd)
               .ProjectTo<MessageInformationUserView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);
        }
    }
}
