#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.MessageInformations.Dtos;
using App.Application.Managements.MessageInformationUsers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.MessageInformations.Queries.FetchAllMessageInformation
{
    /// <summary>
    /// 查詢  MessageInformation 所有資料
    /// </summary>

    public class FetchAllMessageInformationRequest 
        : IRequest<List<MessageInformationView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllMessageInformationHandler 
        : IRequestHandler<FetchAllMessageInformationRequest, List<MessageInformationView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllMessageInformationHandler(
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
        public async Task<List<MessageInformationView>> Handle(
            FetchAllMessageInformationRequest request,
            CancellationToken cancellationToken
        )
        {
            var result = await this.appDbContext
               .MessageInformations
               .ApplyLimitConstraint(request)
               .ProjectTo<MessageInformationView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

            var ids = result.Select(c => c.Id);

            var details = await this.appDbContext.MessageInformationUsers
                                    .Where(c => ids.Contains(c.MessageInformationId))
                                    .ProjectTo<MessageInformationUserView>(this.mapper.ConfigurationProvider)
                                    .ToListAsync();
            foreach (var obj in result)
            {
                obj.messageInformationUserViews = details.Where(c => c.MessageInformationId == obj.Id).ToList();
            }

            return result;

        }
    }
}
