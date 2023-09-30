#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.UserQuestionnaires.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.UserQuestionnaires.Commands.CreateUserQuestionnaire
{
    /// <summary>
    /// 建立 UserQuestionnaire
    /// </summary>

    public class CreateUserQuestionnaireCommand :  UserQuestionnaireBase, IRequest<UserQuestionnaireView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateUserQuestionnaireCommandHandler : IRequestHandler<CreateUserQuestionnaireCommand, UserQuestionnaireView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateUserQuestionnaireCommandHandler(
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
        public async Task<UserQuestionnaireView> Handle(
            CreateUserQuestionnaireCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<UserQuestionnaire>(command);

            await this.appDbContext.UserQuestionnaires.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<UserQuestionnaireView>(entity);
        }
    }
}
