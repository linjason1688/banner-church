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
using App.Application.Managements.MemberClassDayTerms.ModMemberClassDayTerms.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.MemberClassDayTerms.ModMemberClassDayTerms.Queries.FindModMemberClassDayTerm
{
    /// <summary>
    /// 取得  ModMemberClassDayTerm 單筆明細
    /// </summary>

    public class FindModMemberClassDayTermRequest 
        : IRequest<ModMemberClassDayTermView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindModMemberClassDayTermRequestHandler 
        : IRequestHandler<FindModMemberClassDayTermRequest, ModMemberClassDayTermView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindModMemberClassDayTermRequestHandler(
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
        public async Task<ModMemberClassDayTermView> Handle(
            FindModMemberClassDayTermRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModMemberClassDayTerms
               .Where(e => e.Id == request.Id)
               .ProjectTo<ModMemberClassDayTermView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
