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
using App.Application.Managements.Groupleaders.ModGroupleaders.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.Groupleaders.ModGroupleaders.Queries.FindModGroupleader
{
    /// <summary>
    /// 取得  ModGroupleader 單筆明細
    /// </summary>

    public class FindModGroupleaderRequest 
        : IRequest<ModGroupleaderView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindModGroupleaderRequestHandler 
        : IRequestHandler<FindModGroupleaderRequest, ModGroupleaderView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindModGroupleaderRequestHandler(
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
        public async Task<ModGroupleaderView> Handle(
            FindModGroupleaderRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModGroupleaders
               //.Where(e => e.Id == request.Id)
               .ProjectTo<ModGroupleaderView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
