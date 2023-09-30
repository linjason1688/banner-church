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
using App.Application.Managements.VwRollCalls.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwRollCalls.Queries.FindVwRollCall
{
    /// <summary>
    /// 取得  VwRollCall 單筆明細
    /// </summary>

    public class FindVwRollCallRequest 
        : IRequest<VwRollCallView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindVwRollCallRequestHandler 
        : IRequestHandler<FindVwRollCallRequest, VwRollCallView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindVwRollCallRequestHandler(
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
        public async Task<VwRollCallView> Handle(
            FindVwRollCallRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwRollCalls
               .Where(e => e.Id == request.Id)
               .ProjectTo<VwRollCallView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
