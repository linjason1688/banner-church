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
using App.Application.Managements.Pastorals.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.Pastorals.Queries.FindPastoral
{
    /// <summary>
    /// 取得  Pastoral 單筆明細
    /// </summary>

    public class FindPastoralRequest 
        : IRequest<PastoralView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindPastoralRequestHandler 
        : IRequestHandler<FindPastoralRequest, PastoralView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindPastoralRequestHandler(
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
        public async Task<PastoralView> Handle(
            FindPastoralRequest request,
            CancellationToken cancellationToken
        )
        {
            var obj =  await this.appDbContext
               .Pastorals
               .Where(e => e.Id == request.Id)
               .ProjectTo<PastoralView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);

            obj.SubCounter = await this.appDbContext.Pastorals.Where(c => c.UpperPastoralId == obj.Id).CountAsync();

            return obj;
        }
    }
}
