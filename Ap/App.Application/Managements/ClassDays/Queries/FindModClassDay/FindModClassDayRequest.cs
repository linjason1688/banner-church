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
using App.Application.Managements.ClassDays.ModClassDays.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.ClassDays.ModClassDays.Queries.FindModClassDay
{
    /// <summary>
    /// 取得  ModClassDay 單筆明細
    /// </summary>

    public class FindModClassDayRequest 
        : IRequest<ModClassDayView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindModClassDayRequestHandler 
        : IRequestHandler<FindModClassDayRequest, ModClassDayView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindModClassDayRequestHandler(
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
            FindModClassDayRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModClassDays
               .Where(e => e.Id == request.Id)
               .ProjectTo<ModClassDayView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
