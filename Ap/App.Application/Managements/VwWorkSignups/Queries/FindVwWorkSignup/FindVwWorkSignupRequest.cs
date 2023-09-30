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
using App.Application.Managements.VwWorkSignups.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwWorkSignups.Queries.FindVwWorkSignup
{
    /// <summary>
    /// 取得  VwWorkSignup 單筆明細
    /// </summary>

    public class FindVwWorkSignupRequest 
        : IRequest<VwWorkSignupView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindVwWorkSignupRequestHandler 
        : IRequestHandler<FindVwWorkSignupRequest, VwWorkSignupView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindVwWorkSignupRequestHandler(
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
        public async Task<VwWorkSignupView> Handle(
            FindVwWorkSignupRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwWorkSignups
               .Where(e => e.Id == request.Id)
               .ProjectTo<VwWorkSignupView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
