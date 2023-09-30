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
using App.Application.Managements.QrCodes.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.QrCodes.Queries.FindQrCode
{
    /// <summary>
    /// 取得  QrCode 單筆明細
    /// </summary>

    public class FindQrCodeRequest 
        : IRequest<QrCodeView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindQrCodeRequestHandler 
        : IRequestHandler<FindQrCodeRequest, QrCodeView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindQrCodeRequestHandler(
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
        public async Task<QrCodeView> Handle(
            FindQrCodeRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .QrCodes
               .Where(e => e.Id == request.Id)
               .ProjectTo<QrCodeView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
