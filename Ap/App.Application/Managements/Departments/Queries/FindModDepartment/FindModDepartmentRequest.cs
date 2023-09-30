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
using App.Application.Managements.Departments.ModDepartments.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.Departments.ModDepartments.Queries.FindModDepartment
{
    /// <summary>
    /// 取得  ModDepartment 單筆明細
    /// </summary>

    public class FindModDepartmentRequest 
        : IRequest<ModDepartmentView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindModDepartmentRequestHandler 
        : IRequestHandler<FindModDepartmentRequest, ModDepartmentView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindModDepartmentRequestHandler(
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
        public async Task<ModDepartmentView> Handle(
            FindModDepartmentRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModDepartments
               .Where(e => e.Id == request.Id)
               .ProjectTo<ModDepartmentView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
