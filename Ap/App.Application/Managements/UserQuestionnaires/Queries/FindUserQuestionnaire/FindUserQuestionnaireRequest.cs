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
using App.Application.Managements.UserQuestionnaires.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.UserQuestionnaires.Queries.FindUserQuestionnaire
{
    /// <summary>
    /// 取得  UserQuestionnaire 單筆明細
    /// </summary>

    public class FindUserQuestionnaireRequest 
        : IRequest<UserQuestionnaireView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindUserQuestionnaireRequestHandler 
        : IRequestHandler<FindUserQuestionnaireRequest, UserQuestionnaireView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindUserQuestionnaireRequestHandler(
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
            FindUserQuestionnaireRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .UserQuestionnaires
               .Where(e => e.Id == request.Id)
               .ProjectTo<UserQuestionnaireView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
