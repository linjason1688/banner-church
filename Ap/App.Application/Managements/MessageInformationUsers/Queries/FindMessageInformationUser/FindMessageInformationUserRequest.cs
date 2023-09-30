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
using App.Application.Managements.MessageInformationUsers.Dtos;
using App.Application.Managements.MessageInformationUsers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.MessageInformationUsers.Queries.FindMessageInformationUser
{
    /// <summary>
    /// 取得  MessageInformationUser 單筆明細
    /// </summary>

    public class FindMessageInformationUserRequest 
        : IRequest<MessageInformationUserView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindMessageInformationUserRequestHandler 
        : IRequestHandler<FindMessageInformationUserRequest, MessageInformationUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindMessageInformationUserRequestHandler(
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
        public async Task<MessageInformationUserView> Handle(
            FindMessageInformationUserRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .MessageInformationUsers
               .Where(e => e.Id == request.Id)
               .ProjectTo<MessageInformationUserView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
