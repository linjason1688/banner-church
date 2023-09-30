using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.Pastorals.Dtos;
using App.Application.Managements.Pastorals.Queries.FindPastoral;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Managements.Pastorals.Queries.FetchPastoralFlat
{
    public class FetchPastoralFlatRequest : IRequest<List<PastoralView>>
    {
        public long Id { get; set; }
    }

    public class FetchPastoralFlatRequestHandler
    : IRequestHandler<FetchPastoralFlatRequest, List<PastoralView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchPastoralFlatRequestHandler(
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
        public async Task<List<PastoralView>> Handle(
            FetchPastoralFlatRequest request,
            CancellationToken cancellationToken
        )
        {
            var result = new List<PastoralView>();

            var obj = await this.appDbContext.Pastorals.Where(c => c.Id == request.Id)
                                .ProjectTo<PastoralView>(this.mapper.ConfigurationProvider)
                                .FindOneAsync(cancellationToken);

            if (obj != null)
            {
                await this.FlatBuilder(obj, result, "Up");
                await this.FlatBuilder(obj, result, "Down");
                obj.SubCounter = await this.appDbContext.Pastorals.Where(c => c.UpperPastoralId == obj.Id).CountAsync();
            }



            return result;
        }




        private async Task FlatBuilder(PastoralView obj, List<PastoralView> result, string mode)
        {
            if (mode == "Up")
            {
                var parent = await this.appDbContext.Pastorals
                                    .Where(c => c.Id == obj.UpperPastoralId)
                                    .ProjectTo<PastoralView>(this.mapper.ConfigurationProvider)
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
                var lst = await this.appDbContext.Pastorals
                                    .Where(c => c.UpperPastoralId == obj.Id)
                                    .ProjectTo<PastoralView>(this.mapper.ConfigurationProvider)
                                    .ToListAsync();
                foreach (var past in lst)
                {
                    await this.FlatBuilder(past, result, mode);
                }
            }
        }
    }

}
