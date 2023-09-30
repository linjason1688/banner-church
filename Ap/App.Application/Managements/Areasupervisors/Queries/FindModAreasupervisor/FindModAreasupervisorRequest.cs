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
using App.Application.Managements.Areasupervisors.ModAreasupervisors.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.Areasupervisors.ModAreasupervisors.Queries.FindModAreasupervisor
{
    /// <summary>
    /// 取得  ModAreasupervisor 單筆明細
    /// </summary>

    public class FindModAreasupervisorRequest 
        : IRequest<ModAreasupervisorView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindModAreasupervisorRequestHandler 
        : IRequestHandler<FindModAreasupervisorRequest, ModAreasupervisorView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindModAreasupervisorRequestHandler(
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
        public async Task<ModAreasupervisorView> Handle(
            FindModAreasupervisorRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModAreasupervisors
               //.Where(e => e.Id == request.Id)
               .ProjectTo<ModAreasupervisorView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
