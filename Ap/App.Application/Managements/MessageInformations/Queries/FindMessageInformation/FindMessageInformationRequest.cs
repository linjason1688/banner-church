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

namespace App.Application.Managements.MessageInformations.Queries.FindMessageInformation
{
    /// <summary>
    /// 取得  MessageInformation 單筆明細
    /// </summary>

    public class FindMessageInformationRequest
        : IRequest<MessageInformationView>
    {

        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindMessageInformationRequestHandler
        : IRequestHandler<FindMessageInformationRequest, MessageInformationView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindMessageInformationRequestHandler(
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
        public async Task<MessageInformationView> Handle(
            FindMessageInformationRequest request,
            CancellationToken cancellationToken
        )
        {
            var result = await this.appDbContext
               .MessageInformations
               .Where(e => e.Id == request.Id)
               .ProjectTo<MessageInformationView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);


            result.messageInformationUserViews = await this.appDbContext.MessageInformationUsers
                                    .Where(c => c.MessageInformationId == result.Id)
                                    .ProjectTo<MessageInformationUserView>(this.mapper.ConfigurationProvider)
                                    .ToListAsync();
            return result; ;

        }
    }
}
