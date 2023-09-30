#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
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

namespace App.Application.Managements.UserContacts.Commands.CreateUserContact
{
    /// <summary>
    /// 建立 UserContact
    /// </summary>

    public class CreateUserContactCommand :  UserContactBase, IRequest<UserContactView>
    {
        //public long UserId { get; set; }
        //public string Name { get; set; }
        public string Relative { get; set; }
        //public string Phone { get; set; }
        public string Memo { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateUserContactCommandHandler : IRequestHandler<CreateUserContactCommand, UserContactView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateUserContactCommandHandler(
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
            CreateUserContactCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<UserContact>(command);

            await this.appDbContext.UserContacts.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<UserContactView>(entity);
        }
    }
}
