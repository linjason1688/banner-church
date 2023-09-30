#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using App.Application.Common.Extensions;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.SysSettings.Commands.DeleteSysSetting
{
    /// <summary>
    /// 刪除  SysSetting
    /// </summary>

    public class DeleteSysSettingCommand : IRequest<Unit>
    {
    
        public int Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DeleteSysSettingCommandHandler : IRequestHandler<DeleteSysSettingCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;


        /// <summary>
        /// 
        /// </summary>
        public DeleteSysSettingCommandHandler(
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
        public async Task<Unit> Handle(
            DeleteSysSettingCommand command,
            CancellationToken cancellationToken
        )
        {
            await this.appDbContext.SysSettings.RemoveAsync(
                new SysSetting()
                {
                    //Id = command.Id
                }
            );

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
