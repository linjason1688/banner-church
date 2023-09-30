#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.MessageInformations.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.MessageInformations.Commands.CreateMessageInformation
{
    /// <summary>
    /// 建立 MessageInformation
    /// </summary>

    public class CreateMessageInformationCommand :  MessageInformationBase, IRequest<MessageInformationView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateMessageInformationCommandHandler : IRequestHandler<CreateMessageInformationCommand, MessageInformationView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateMessageInformationCommandHandler(
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
        public async Task<MessageInformationView> Handle(
            CreateMessageInformationCommand command,
            CancellationToken cancellationToken
        )
        {
            //新增的時候
            //select * from  User where 


            var entity = this.mapper.Map<MessageInformation>(command);

            await this.appDbContext.MessageInformations.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<MessageInformationView>(entity);
        }
    }
}
