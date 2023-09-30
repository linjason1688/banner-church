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
using App.Application.Managements.StatisticDetails.ModStatisticDetails.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.StatisticDetails.ModStatisticDetails.Queries.FindModStatisticDetail
{
    /// <summary>
    /// 取得  ModStatisticDetail 單筆明細
    /// </summary>

    public class FindModStatisticDetailRequest 
        : IRequest<ModStatisticDetailView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindModStatisticDetailRequestHandler 
        : IRequestHandler<FindModStatisticDetailRequest, ModStatisticDetailView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindModStatisticDetailRequestHandler(
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
        public async Task<ModStatisticDetailView> Handle(
            FindModStatisticDetailRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModStatisticDetails
               //.Where(e => e.Id == request.Id)
               .ProjectTo<ModStatisticDetailView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
