#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Teachers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Teachers.Commands.CreateTeacher
{
    /// <summary>
    /// 建立 Teacher
    /// </summary>

    public class CreateTeacherCommand :  TeacherBase, IRequest<TeacherView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, TeacherView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateTeacherCommandHandler(
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
        public async Task<TeacherView> Handle(
            CreateTeacherCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<Teacher>(command);

            await this.appDbContext.Teachers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<TeacherView>(entity);
        }
    }
}
