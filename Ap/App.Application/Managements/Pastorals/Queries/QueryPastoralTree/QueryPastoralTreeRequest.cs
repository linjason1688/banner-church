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
using RestEase.Implementation;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.Pastorals.Queries.FindPastoral
{
    /// <summary>
    /// 取得  Pastoral 單筆明細
    /// </summary>

    public class QueryPastoralTreeRequest
        : IRequest<PastoralTreeView>
    {

        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class QueryPastoralTreeRequestHandler
        : IRequestHandler<QueryPastoralTreeRequest, PastoralTreeView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryPastoralTreeRequestHandler(
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
        public async Task<PastoralTreeView> Handle(
            QueryPastoralTreeRequest request,
            CancellationToken cancellationToken
        )
        {
            var obj = await this.appDbContext.Pastorals.Where(c => c.Id == request.Id)
                                .ProjectTo<PastoralTreeView>(this.mapper.ConfigurationProvider)
                                .FindOneAsync(cancellationToken);

            if (obj != null)
            {
                obj.SubCounter = await this.appDbContext.Pastorals.Where(c => c.UpperPastoralId == obj.Id).CountAsync();
                var parent = await this.UpBuilder(obj, cancellationToken);
                await this.DownBuilder(obj, cancellationToken);
                return parent;

            }
            return obj;
        }

        private async Task<PastoralTreeView> UpBuilder(PastoralTreeView obj, CancellationToken cancellationToken)
        {
            if (obj == null || obj?.UpperPastoralId == 0) return obj;
            obj.Parent = await this.appDbContext.Pastorals.Where(c => c.Id == obj.UpperPastoralId)
                             .ProjectTo<PastoralTreeView>(this.mapper.ConfigurationProvider)
                             .FindOneAsync(cancellationToken);
            obj.Parent.Nodes.Add(obj);
            return await UpBuilder(obj.Parent, cancellationToken);
        }

        private async Task DownBuilder(PastoralTreeView obj, CancellationToken cancellationToken)
        {
            if (obj == null) return;

            obj.Nodes = await this.appDbContext.Pastorals
                                .Where(c => c.UpperPastoralId == obj.Id)
                                .ProjectTo<PastoralTreeView>(this.mapper.ConfigurationProvider)
                                .ToListAsync();
            foreach (var past in obj.Nodes)
            {
                past.Parent = obj;
                await this.DownBuilder(past, cancellationToken);
            }
        }
    }
}
