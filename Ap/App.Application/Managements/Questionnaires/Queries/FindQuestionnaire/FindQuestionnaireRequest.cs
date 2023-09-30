#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Questionnaires.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.Questionnaires.Queries.FindQuestionnaire
{
    /// <summary>
    /// 取得  Questionnaire 單筆明細
    /// </summary>

    public class FindQuestionnaireRequest 
        : IRequest<QuestionnaireView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindQuestionnaireRequestHandler 
        : IRequestHandler<FindQuestionnaireRequest, QuestionnaireView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindQuestionnaireRequestHandler(
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
            FindQuestionnaireRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .Questionnaires
               .Where(e => e.Id == request.Id)
               .ProjectTo<QuestionnaireView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
