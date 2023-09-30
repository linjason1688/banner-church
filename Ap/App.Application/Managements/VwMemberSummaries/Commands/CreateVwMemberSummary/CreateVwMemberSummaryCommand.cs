#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwMemberSummaries.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwMemberSummaries.Commands.CreateVwMemberSummary
{
    /// <summary>
    /// 建立 VwMemberSummary
    /// </summary>

    public class CreateVwMemberSummaryCommand :  VwMemberSummaryBase, IRequest<VwMemberSummaryView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateVwMemberSummaryCommandHandler : IRequestHandler<CreateVwMemberSummaryCommand, VwMemberSummaryView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateVwMemberSummaryCommandHandler(
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
        public async Task<VwMemberSummaryView> Handle(
            CreateVwMemberSummaryCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<VwMemberSummary>(command);

            await this.appDbContext.VwMemberSummaries.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwMemberSummaryView>(entity);
        }
    }
}
