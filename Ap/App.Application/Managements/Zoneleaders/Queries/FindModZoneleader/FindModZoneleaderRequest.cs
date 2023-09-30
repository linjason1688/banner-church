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
using App.Application.Managements.Zoneleaders.ModZoneleaders.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.Zoneleaders.ModZoneleaders.Queries.FindModZoneleader
{
    /// <summary>
    /// 取得  ModZoneleader 單筆明細
    /// </summary>

    public class FindModZoneleaderRequest 
        : IRequest<ModZoneleaderView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindModZoneleaderRequestHandler 
        : IRequestHandler<FindModZoneleaderRequest, ModZoneleaderView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindModZoneleaderRequestHandler(
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
        public async Task<ModZoneleaderView> Handle(
            FindModZoneleaderRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModZoneleaders
               //.Where(e => e.Id == request.Id)
               .ProjectTo<ModZoneleaderView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
