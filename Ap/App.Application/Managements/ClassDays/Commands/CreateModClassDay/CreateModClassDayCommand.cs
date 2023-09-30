#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.ClassDays.ModClassDays.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.ClassDays.ModClassDays.Commands.CreateModClassDay
{
    /// <summary>
    /// 建立 ModClassDay
    /// </summary>

    public class CreateModClassDayCommand :  ModClassDayBase, IRequest<ModClassDayView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModClassDayCommandHandler : IRequestHandler<CreateModClassDayCommand, ModClassDayView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModClassDayCommandHandler(
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
        public async Task<ModClassDayView> Handle(
            CreateModClassDayCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModClassDay>(command);

            await this.appDbContext.ModClassDays.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModClassDayView>(entity);
        }
    }
}
