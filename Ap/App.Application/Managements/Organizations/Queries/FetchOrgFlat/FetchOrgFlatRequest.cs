using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.Organizations.Dtos;
using App.Application.Managements.Organizations.Queries.FindOrganization;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Managements.Organizations.Queries.FetchOrganizationFlat
{
    public class FetchOrgFlatRequest : IRequest<List<OrganizationView>>
    {
        public long Id { get; set; }
    }

    public class FetchOrganizationFlatRequestHandler
    : IRequestHandler<FetchOrgFlatRequest, List<OrganizationView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchOrganizationFlatRequestHandler(
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
        public async Task<List<OrganizationView>> Handle(
            FetchOrgFlatRequest request,
            CancellationToken cancellationToken
        )
        {
            var result = new List<OrganizationView>();

            var obj = await this.appDbContext.Organizations.Where(c => c.Id == request.Id)
                                .ProjectTo<OrganizationView>(this.mapper.ConfigurationProvider)
                                .FindOneAsync(cancellationToken);

            if (obj != null)
            {
                await this.FlatBuilder(obj, result, "Up");
                await this.FlatBuilder(obj, result, "Down");

                obj.SubCounter = await this.appDbContext.Organizations.Where(c => c.UpperOrganizationId == obj.Id).CountAsync();
            }
            return result;
        }




        private async Task FlatBuilder(OrganizationView obj, List<OrganizationView> result, string mode)
        {
            if (mode == "Up")
            {
                var parent = await this.appDbContext.Organizations
                                    .Where(c => c.Id == obj.UpperOrganizationId)
                                    .ProjectTo<OrganizationView>(this.mapper.ConfigurationProvider)
                                    .FirstOrDefaultAsync();
                if (parent != null)
                {
                    result.Add(parent);
                    await FlatBuilder(parent, result, mode);
                }
            }
            else
            {
                if (obj == null) return;
                result.Add(obj);
                var lst = await this.appDbContext.Organizations
                                    .Where(c => c.UpperOrganizationId == obj.Id)
                                    .ProjectTo<OrganizationView>(this.mapper.ConfigurationProvider)
                                    .ToListAsync();
                foreach (var past in lst)
                {
                    await this.FlatBuilder(past, result, mode);
                }
            }
        }
    }

}
