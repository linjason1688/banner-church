#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.UserFamilies.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.UserFamilies.Commands.CreateUserFamily
{
    /// <summary>
    /// 建立 UserFamily
    /// </summary>

    public class CreateUserFamilyCommand :  UserFamilyBase, IRequest<UserFamilyView>
    {
        //public long Id { get; set; }
        //public long UserId { get; set; }
        //public string RelativeType { get; set; }
        //public string Name { get; set; }
        public string Memo { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateUserFamilyCommandHandler : IRequestHandler<CreateUserFamilyCommand, UserFamilyView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateUserFamilyCommandHandler(
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
        public async Task<UserFamilyView> Handle(
            CreateUserFamilyCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<UserFamily>(command);

            await this.appDbContext.UserFamilies.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<UserFamilyView>(entity);
        }
    }
}
