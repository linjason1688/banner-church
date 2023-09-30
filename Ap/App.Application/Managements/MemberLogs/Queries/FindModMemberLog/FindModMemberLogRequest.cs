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
using App.Application.Managements.MemberLogs.ModMemberLogs.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.MemberLogs.ModMemberLogs.Queries.FindModMemberLog
{
    /// <summary>
    /// 取得  ModMemberLog 單筆明細
    /// </summary>

    public class FindModMemberLogRequest 
        : IRequest<ModMemberLogView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindModMemberLogRequestHandler 
        : IRequestHandler<FindModMemberLogRequest, ModMemberLogView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindModMemberLogRequestHandler(
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
        public async Task<ModMemberLogView> Handle(
            FindModMemberLogRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModMemberLogs
               .Where(e => e.Id == request.Id)
               .ProjectTo<ModMemberLogView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
