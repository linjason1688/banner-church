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
using App.Application.Managements.QuestionnaireSatisfyUsers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.QuestionnaireSatisfyUsers.Queries.FindQuestionnaireSatisfyUser
{
    /// <summary>
    /// 取得  QuestionnaireSatisfyUser 單筆明細
    /// </summary>

    public class FindQuestionnaireSatisfyUserRequest 
        : IRequest<QuestionnaireSatisfyUserView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindQuestionnaireSatisfyUserRequestHandler 
        : IRequestHandler<FindQuestionnaireSatisfyUserRequest, QuestionnaireSatisfyUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindQuestionnaireSatisfyUserRequestHandler(
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
        public async Task<QuestionnaireSatisfyUserView> Handle(
            FindQuestionnaireSatisfyUserRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .QuestionnaireSatisfyUsers
               .Where(e => e.Id == request.Id)
               .ProjectTo<QuestionnaireSatisfyUserView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
