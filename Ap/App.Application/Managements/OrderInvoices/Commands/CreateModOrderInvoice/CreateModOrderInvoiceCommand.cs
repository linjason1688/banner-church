#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.OrderInvoices.ModOrderInvoices.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.OrderInvoices.ModOrderInvoices.Commands.CreateModOrderInvoice
{
    /// <summary>
    /// 建立 ModOrderInvoice
    /// </summary>

    public class CreateModOrderInvoiceCommand :  ModOrderInvoiceBase, IRequest<ModOrderInvoiceView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModOrderInvoiceCommandHandler : IRequestHandler<CreateModOrderInvoiceCommand, ModOrderInvoiceView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModOrderInvoiceCommandHandler(
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
        public async Task<ModOrderInvoiceView> Handle(
            CreateModOrderInvoiceCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModOrderInvoice>(command);

            await this.appDbContext.ModOrderInvoices.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModOrderInvoiceView>(entity);
        }
    }
}
