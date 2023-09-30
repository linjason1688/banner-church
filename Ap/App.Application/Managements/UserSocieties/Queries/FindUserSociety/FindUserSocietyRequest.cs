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
using App.Application.Managements.UserSocieties.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.UserSocieties.Queries.FindUserSociety
{
    /// <summary>
    /// 取得  UserSociety 單筆明細
    /// </summary>

    public class FindUserSocietyRequest 
        : IRequest<UserSocietyView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindUserSocietyRequestHandler 
        : IRequestHandler<FindUserSocietyRequest, UserSocietyView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindUserSocietyRequestHandler(
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
        public async Task<UserSocietyView> Handle(
            FindUserSocietyRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .UserSocieties
               .Where(e => e.Id == request.Id)
               .ProjectTo<UserSocietyView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
