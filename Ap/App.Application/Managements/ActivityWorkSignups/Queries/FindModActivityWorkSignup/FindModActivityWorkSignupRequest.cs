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
using App.Application.Managements.ActivityWorkSignups.ModActivityWorkSignups.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.ActivityWorkSignups.ModActivityWorkSignups.Queries.FindModActivityWorkSignup
{
    /// <summary>
    /// 取得  ModActivityWorkSignup 單筆明細
    /// </summary>

    public class FindModActivityWorkSignupRequest 
        : IRequest<ModActivityWorkSignupView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindModActivityWorkSignupRequestHandler 
        : IRequestHandler<FindModActivityWorkSignupRequest, ModActivityWorkSignupView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindModActivityWorkSignupRequestHandler(
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
        public async Task<ModActivityWorkSignupView> Handle(
            FindModActivityWorkSignupRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModActivityWorkSignups
               //.Where(e => e.Id == request.Id)
               .ProjectTo<ModActivityWorkSignupView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
