#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Features.SignUp;
using App.Application.Managements.QuestionnaireDetails.Commands.CreateQuestionnaireDetail;
using App.Application.Managements.Questionnaires.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Questionnaires.Commands.CreateQuestionnaire
{
    /// <summary>
    /// 建立 Questionnaire
    /// </summary>

    public class CreateQuestionnaireCommand : QuestionnaireBase, IRequest<QuestionnaireView>
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateQuestionnaireCommandHandler : IRequestHandler<CreateQuestionnaireCommand, QuestionnaireView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateQuestionnaireCommandHandler(
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
        public async Task<QuestionnaireView> Handle(
            CreateQuestionnaireCommand command,
            CancellationToken cancellationToken
        )
        {

            return await this.appDbContext.ExecuteTransactionAsync(async Task<QuestionnaireView> () =>
             {
                 var entity = this.mapper.Map<Questionnaire>(command);

                 await this.appDbContext.Questionnaires.AddAsync(entity, cancellationToken);

                 await this.appDbContext.SaveChangesAsync(cancellationToken);

                 if (entity.Id > 0)
                 {
                     foreach (var d in command.QuestionnaireDetailsViews)
                     {
                         var detail = this.mapper.Map<QuestionnaireDetail>(d);
                         detail.QuestionnaireId = entity.Id;
                         await this.appDbContext.QuestionnaireDetails.AddAsync(detail, cancellationToken);
                     }
                     await this.appDbContext.SaveChangesAsync(cancellationToken);
                 }

                 return this.mapper.Map<QuestionnaireView>(entity);

             });



           
        }
    }
}
