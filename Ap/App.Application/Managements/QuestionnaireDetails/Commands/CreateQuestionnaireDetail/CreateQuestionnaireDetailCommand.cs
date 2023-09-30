#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.QuestionnaireDetails.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.QuestionnaireDetails.Commands.CreateQuestionnaireDetail
{
    /// <summary>
    /// 建立 QuestionnaireDetail
    /// </summary>

    public class CreateQuestionnaireDetailCommand :  QuestionnaireDetailBase, IRequest<QuestionnaireDetailView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateQuestionnaireDetailCommandHandler : IRequestHandler<CreateQuestionnaireDetailCommand, QuestionnaireDetailView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateQuestionnaireDetailCommandHandler(
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
        public async Task<QuestionnaireDetailView> Handle(
            CreateQuestionnaireDetailCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<QuestionnaireDetail>(command);

            await this.appDbContext.QuestionnaireDetails.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<QuestionnaireDetailView>(entity);
        }
    }
}
