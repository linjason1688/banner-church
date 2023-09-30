#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Teachers.ModTeachers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Teachers.ModTeachers.Commands.CreateModTeacher
{
    /// <summary>
    /// 建立 ModTeacher
    /// </summary>

    public class CreateModTeacherCommand :  ModTeacherBase, IRequest<ModTeacherView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModTeacherCommandHandler : IRequestHandler<CreateModTeacherCommand, ModTeacherView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModTeacherCommandHandler(
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
        public async Task<ModTeacherView> Handle(
            CreateModTeacherCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModTeacher>(command);

            await this.appDbContext.ModTeachers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModTeacherView>(entity);
        }
    }
}
