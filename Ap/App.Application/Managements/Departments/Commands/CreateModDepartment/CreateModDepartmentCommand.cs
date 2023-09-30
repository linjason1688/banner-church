#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Departments.ModDepartments.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Departments.ModDepartments.Commands.CreateModDepartment
{
    /// <summary>
    /// 建立 ModDepartment
    /// </summary>

    public class CreateModDepartmentCommand :  ModDepartmentBase, IRequest<ModDepartmentView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModDepartmentCommandHandler : IRequestHandler<CreateModDepartmentCommand, ModDepartmentView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModDepartmentCommandHandler(
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
            CreateModDepartmentCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModDepartment>(command);

            await this.appDbContext.ModDepartments.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModDepartmentView>(entity);
        }
    }
}
