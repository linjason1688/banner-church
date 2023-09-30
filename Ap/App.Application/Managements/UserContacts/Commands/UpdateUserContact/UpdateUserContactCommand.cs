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
using App.Application.Managements.UserContacts.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.UserContacts.Commands.UpdateUserContact
{
    /// <summary>
    /// 更新  UserContact
    /// </summary>

    public class UpdateUserContactCommand : UserContactBase,IRequest<UserContactView>
    {
    
        //public long Id { get; set; }
        //public long UserId { get; set; }
        //public string Name { get; set; }
        public string Relative { get; set; }
        //public string Phone { get; set; }
        public string Memo { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateUserContactCommandHandler : IRequestHandler<UpdateUserContactCommand, UserContactView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateUserContactCommandHandler(
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
        public async Task<UserContactView> Handle(
            UpdateUserContactCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.UserContacts.FindOneAsync(
                e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<UserContactView>(entity);
        }
    }
}
