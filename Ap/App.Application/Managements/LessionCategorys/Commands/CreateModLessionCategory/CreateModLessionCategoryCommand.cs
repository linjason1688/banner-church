#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.LessionCategorys.ModLessionCategorys.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.LessionCategorys.ModLessionCategorys.Commands.CreateModLessionCategory
{
    /// <summary>
    /// 建立 ModLessionCategory
    /// </summary>

    public class CreateModLessionCategoryCommand :  ModLessionCategoryBase, IRequest<ModLessionCategoryView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModLessionCategoryCommandHandler : IRequestHandler<CreateModLessionCategoryCommand, ModLessionCategoryView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModLessionCategoryCommandHandler(
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
        public async Task<ModLessionCategoryView> Handle(
            CreateModLessionCategoryCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModLessionCategory>(command);

            await this.appDbContext.ModLessionCategories.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModLessionCategoryView>(entity);
        }
    }
}
