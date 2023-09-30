#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.QrCodes.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.QrCodes.Commands.CreateQrCode
{
    /// <summary>
    /// 建立 QrCode
    /// </summary>

    public class CreateQrCodeCommand :  QrCodeBase, IRequest<QrCodeView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateQrCodeCommandHandler : IRequestHandler<CreateQrCodeCommand, QrCodeView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateQrCodeCommandHandler(
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
        public async Task<QrCodeView> Handle(
            CreateQrCodeCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<QrCode>(command);

            await this.appDbContext.QrCodes.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<QrCodeView>(entity);
        }
    }
}
