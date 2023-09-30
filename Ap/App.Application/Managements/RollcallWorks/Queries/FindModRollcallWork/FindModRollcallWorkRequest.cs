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
using App.Application.Managements.RollcallWorks.ModRollcallWorks.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.RollcallWorks.ModRollcallWorks.Queries.FindModRollcallWork
{
    /// <summary>
    /// 取得  ModRollcallWork 單筆明細
    /// </summary>

    public class FindModRollcallWorkRequest 
        : IRequest<ModRollcallWorkView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindModRollcallWorkRequestHandler 
        : IRequestHandler<FindModRollcallWorkRequest, ModRollcallWorkView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindModRollcallWorkRequestHandler(
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
        public async Task<ModRollcallWorkView> Handle(
            FindModRollcallWorkRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModRollcallWorks
               //.Where(e => e.Id == request.Id)
               .ProjectTo<ModRollcallWorkView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
