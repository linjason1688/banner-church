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
using App.Application.Managements.UserExpertises.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.UserExpertises.Queries.FindUserExpertise
{
    /// <summary>
    /// 取得  UserExpertise 單筆明細
    /// </summary>

    public class FindUserExpertiseRequest 
        : IRequest<UserExpertiseView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindUserExpertiseRequestHandler 
        : IRequestHandler<FindUserExpertiseRequest, UserExpertiseView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindUserExpertiseRequestHandler(
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
        public async Task<UserExpertiseView> Handle(
            FindUserExpertiseRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .UserExpertises
               .Where(e => e.Id == request.Id)
               .ProjectTo<UserExpertiseView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
