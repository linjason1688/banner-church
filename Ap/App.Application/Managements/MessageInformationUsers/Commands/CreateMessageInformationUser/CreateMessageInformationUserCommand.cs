#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.MessageInformationUsers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.MessageInformationUsers.Commands.CreateMessageInformationUser
{
    /// <summary>
    /// 建立 MessageInformationUser
    /// </summary>

    public class CreateMessageInformationUserCommand :  MessageInformationUserBase, IRequest<MessageInformationUserView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateMessageInformationUserCommandHandler : IRequestHandler<CreateMessageInformationUserCommand, MessageInformationUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateMessageInformationUserCommandHandler(
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
        public async Task<MessageInformationUserView> Handle(
            CreateMessageInformationUserCommand command,
            CancellationToken cancellationToken
        )
        {
            //新增的時候
            //select * from  User where 


            var entity = this.mapper.Map<MessageInformationUser>(command);

            await this.appDbContext.MessageInformationUsers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<MessageInformationUserView>(entity);
        }
    }
}
