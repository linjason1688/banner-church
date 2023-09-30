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
using App.Application.Managements.MinisterGroups.ModMinisterGroups.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.MinisterGroups.ModMinisterGroups.Queries.FindModMinisterGroup
{
    /// <summary>
    /// 取得  ModMinisterGroup 單筆明細
    /// </summary>

    public class FindModMinisterGroupRequest 
        : IRequest<ModMinisterGroupView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindModMinisterGroupRequestHandler 
        : IRequestHandler<FindModMinisterGroupRequest, ModMinisterGroupView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindModMinisterGroupRequestHandler(
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
        public async Task<ModMinisterGroupView> Handle(
            FindModMinisterGroupRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModMinisterGroups
               .Where(e => e.Id == request.Id)
               .ProjectTo<ModMinisterGroupView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
