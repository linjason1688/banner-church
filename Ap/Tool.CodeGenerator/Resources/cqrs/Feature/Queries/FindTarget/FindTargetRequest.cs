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
using App.Application.$BaseNamespace$$Feature$.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.$BaseNamespace$$Feature$.Queries.Find$Target$
{
    /// <summary>
    /// 取得  $Target$ 單筆明細
    /// </summary>

    public class Find$Target$Request 
        : IRequest<$Target$View>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Find$Target$RequestHandler 
        : IRequestHandler<Find$Target$Request, $Target$View>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public Find$Target$RequestHandler(
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
        public async Task<$Target$View> Handle(
            Find$Target$Request request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .$Feature$
               .Where(e => e.Id == request.Id)
               .ProjectTo<$Target$View>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
