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
using App.Application.Managements.Rollcalls.ModRollcalls.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.Rollcalls.ModRollcalls.Queries.FindModRollcall
{
    /// <summary>
    /// 取得  ModRollcall 單筆明細
    /// </summary>

    public class FindModRollcallRequest 
        : IRequest<ModRollcallView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindModRollcallRequestHandler 
        : IRequestHandler<FindModRollcallRequest, ModRollcallView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindModRollcallRequestHandler(
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
        public async Task<ModRollcallView> Handle(
            FindModRollcallRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModRollcalls
               .Where(e => e.Id == request.Id)
               .ProjectTo<ModRollcallView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
