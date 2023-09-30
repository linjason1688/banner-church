#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwOrderRecords.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwOrderRecords.Commands.UpdateVwOrderRecord
{
    /// <summary>
    /// 更新  VwOrderRecord
    /// </summary>

    public class UpdateVwOrderRecordCommand : VwOrderRecordBase,IRequest<VwOrderRecordView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwOrderRecordCommandHandler : IRequestHandler<UpdateVwOrderRecordCommand, VwOrderRecordView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateVwOrderRecordCommandHandler(
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
        public async Task<VwOrderRecordView> Handle(
            UpdateVwOrderRecordCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.VwOrderRecords.FindOneAsync(
               //e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwOrderRecordView>(entity);
        }
    }
}
