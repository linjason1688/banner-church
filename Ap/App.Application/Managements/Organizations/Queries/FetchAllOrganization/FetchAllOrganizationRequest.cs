#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Organizations.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.Organizations.Queries.FetchAllOrganization
{
    /// <summary>
    /// 查詢  Organization 所有資料
    /// </summary>

    public class FetchAllOrganizationRequest 
        : IRequest<List<OrganizationView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllOrganizationHandler 
        : IRequestHandler<FetchAllOrganizationRequest, List<OrganizationView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllOrganizationHandler(
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
            FetchAllOrganizationRequest request,
            CancellationToken cancellationToken
        )
        {
            var result = await this.appDbContext
               .Organizations
               .ApplyLimitConstraint(request)
               .ProjectTo<OrganizationView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

            foreach (var obj in result)
            {
                obj.SubCounter = await this.appDbContext.Organizations.Where(c => c.UpperOrganizationId == obj.Id).CountAsync();
            }

            return result;
        }
    }
}
