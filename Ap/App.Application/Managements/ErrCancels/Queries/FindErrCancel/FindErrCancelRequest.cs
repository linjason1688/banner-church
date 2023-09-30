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
using App.Application.Managements.ErrCancels.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.ErrCancels.Queries.FindErrCancel
{
    /// <summary>
    /// 取得  ErrCancel 單筆明細
    /// </summary>

    public class FindErrCancelRequest 
        : IRequest<ErrCancelView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindErrCancelRequestHandler 
        : IRequestHandler<FindErrCancelRequest, ErrCancelView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindErrCancelRequestHandler(
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
        public async Task<ErrCancelView> Handle(
            FindErrCancelRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ErrCancels
               //.Where(e => e.Id == request.Id)
               .ProjectTo<ErrCancelView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
