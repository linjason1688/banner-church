#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.UserExpertises.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.UserExpertises.Commands.CreateUserExpertise
{
    /// <summary>
    /// 建立 UserExpertise
    /// </summary>

    public class CreateUserExpertiseCommand :  UserExpertiseBase, IRequest<UserExpertiseView>
    {
        //public string Id { get; set; }
        //public string UserId { get; set; }
        //public string Name { get; set; }
        public string Memo { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateUserExpertiseCommandHandler : IRequestHandler<CreateUserExpertiseCommand, UserExpertiseView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateUserExpertiseCommandHandler(
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
        public async Task<UserExpertiseView> Handle(
            CreateUserExpertiseCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<UserExpertise>(command);

            await this.appDbContext.UserExpertises.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<UserExpertiseView>(entity);
        }
    }
}
