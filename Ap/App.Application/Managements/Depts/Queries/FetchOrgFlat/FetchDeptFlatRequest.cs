using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.Depts.Dtos;
using App.Application.Managements.Depts.Queries.FindDept;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Managements.Depts.Queries.FetchDeptFlat
{
    public class FetchDeptFlatRequest : IRequest<List<DeptView>>
    {
        public long Id { get; set; }
    }

    public class FetchDeptFlatRequestHandler
    : IRequestHandler<FetchDeptFlatRequest, List<DeptView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchDeptFlatRequestHandler(
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
        public async Task<List<DeptView>> Handle(
            FetchDeptFlatRequest request,
            CancellationToken cancellationToken
        )
        {
            var result = new List<DeptView>();

            var obj = await this.appDbContext.Depts.Where(c => c.Id == request.Id)
                                .ProjectTo<DeptView>(this.mapper.ConfigurationProvider)
                                .FindOneAsync(cancellationToken);

            if (obj != null)
            {
                await this.FlatBuilder(obj, result, "Up");
                await this.FlatBuilder(obj, result, "Down");

            }
            return result;
        }




        private async Task FlatBuilder(DeptView obj, List<DeptView> result, string mode)
        {
            if (mode == "Up")
            {
                var parent = await this.appDbContext.Depts
                                    .Where(c => c.Id == obj.UpperDeptId)
                                    .ProjectTo<DeptView>(this.mapper.ConfigurationProvider)
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
                var lst = await this.appDbContext.Depts
                                    .Where(c => c.UpperDeptId == obj.Id)
                                    .ProjectTo<DeptView>(this.mapper.ConfigurationProvider)
                                    .ToListAsync();
                foreach (var past in lst)
                {
                    await this.FlatBuilder(past, result, mode);
                }
            }
        }
    }

}
