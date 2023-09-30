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
using App.Application.Managements.ActivityWorkShares.ModActivityWorkShares.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.ActivityWorkShares.ModActivityWorkShares.Queries.FindModActivityWorkShare
{
    /// <summary>
    /// 取得  ModActivityWorkShare 單筆明細
    /// </summary>

    public class FindModActivityWorkShareRequest 
        : IRequest<ModActivityWorkShareView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindModActivityWorkShareRequestHandler 
        : IRequestHandler<FindModActivityWorkShareRequest, ModActivityWorkShareView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindModActivityWorkShareRequestHandler(
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
        public async Task<ModActivityWorkShareView> Handle(
            FindModActivityWorkShareRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModActivityWorkShares
               //.Where(e => e.Id == request.Id)
               .ProjectTo<ModActivityWorkShareView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
