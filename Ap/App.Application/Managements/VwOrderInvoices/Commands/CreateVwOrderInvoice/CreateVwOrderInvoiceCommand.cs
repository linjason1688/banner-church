#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwOrderInvoices.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwOrderInvoices.Commands.CreateVwOrderInvoice
{
    /// <summary>
    /// 建立 VwOrderInvoice
    /// </summary>

    public class CreateVwOrderInvoiceCommand :  VwOrderInvoiceBase, IRequest<VwOrderInvoiceView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateVwOrderInvoiceCommandHandler : IRequestHandler<CreateVwOrderInvoiceCommand, VwOrderInvoiceView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateVwOrderInvoiceCommandHandler(
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
        public async Task<VwOrderInvoiceView> Handle(
            CreateVwOrderInvoiceCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<VwOrderInvoice>(command);

            await this.appDbContext.VwOrderInvoices.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwOrderInvoiceView>(entity);
        }
    }
}
