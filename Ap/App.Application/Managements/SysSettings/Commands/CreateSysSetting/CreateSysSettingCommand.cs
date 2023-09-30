#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.SysSettings.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.SysSettings.Commands.CreateSysSetting
{
    /// <summary>
    /// 建立 SysSetting
    /// </summary>

    public class CreateSysSettingCommand :  SysSettingBase, IRequest<SysSettingView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateSysSettingCommandHandler : IRequestHandler<CreateSysSettingCommand, SysSettingView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateSysSettingCommandHandler(
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
        public async Task<SysSettingView> Handle(
            CreateSysSettingCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<SysSetting>(command);

            await this.appDbContext.SysSettings.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<SysSettingView>(entity);
        }
    }
}
