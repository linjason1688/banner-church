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
using App.Application.Managements.ClassTerms.ModClassTerms.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.ClassTerms.ModClassTerms.Queries.FindModClassTerm
{
    /// <summary>
    /// 取得  ModClassTerm 單筆明細
    /// </summary>

    public class FindModClassTermRequest 
        : IRequest<ModClassTermView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindModClassTermRequestHandler 
        : IRequestHandler<FindModClassTermRequest, ModClassTermView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindModClassTermRequestHandler(
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
        public async Task<ModClassTermView> Handle(
            FindModClassTermRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModClassTerms
               .Where(e => e.Id == request.Id)
               .ProjectTo<ModClassTermView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
