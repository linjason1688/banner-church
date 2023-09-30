#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Constants;
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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.QrCodes.Queries.QueryQrCode
{
    /// <summary>
    /// 分頁查詢 QrCode
    /// </summary>

    public class QueryQrCodeRequest 
        : PageableQuery, IRequest<Page<QrCodeView>>
    {

        ///  <summary>
        ///QrCodeId
        /// </summary>
        public long Id { get; set; }
        ///  <summary>
        ///  報到類別對應 systemconfig.Type=RefferenceType 0:兒童個人報到專用 1:小組報到 2:主日報到 3:領袖之夜報到 4:課程報到 5:事工團報到 6:問卷填寫
        /// </summary>
        public int? ReferenceType { get; set; }
        ///  <summary>
        ///對應報到類別主擋Id  
        /// </summary>
        public long? ReferenceId { get; set; }
        ///  <summary>
        ///報到使用者Id
        /// </summary>
        public long? UserId { get; set; }
        ///  <summary>
        ///Id+RefferenceType+UserId 產生唯一值
        /// </summary>
        public string GenerateCode { get; set; }
        ///  <summary>
        ///付款方式 對應SystemConfig內Type=RegisterStatus 0:尚未報到 1:已報到
        /// </summary>
        public int? RegisterStatus { get; set; }
        ///  <summary>
        ///報到時間
        /// </summary>
        public DateTime? RegisterTime { get; set; }
    }

    /// <summary>
    ///  分頁查詢 QrCode
    /// </summary>
    public class QueryQrCodeRequestHandler 
        : IRequestHandler<QueryQrCodeRequest, Page<QrCodeView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryQrCodeRequestHandler(
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
        public async Task<Page<QrCodeView>> Handle(
            QueryQrCodeRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
                .QrCodes
                    .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)//QrCodeId
                    .WhereWhen(request.ReferenceType.HasValue, c => c.ReferenceType == request.ReferenceType)//報到類別對應 systemconfig.Type=RefferenceType 0:兒童個人報到專用 1:小組報到 2:主日報到 3:領袖之夜報到 4:課程報到 5:事工團報到 6:問卷填寫        
                    .WhereWhen(request.ReferenceId.HasValue, c => c.ReferenceId == request.ReferenceId)//對應報到類別主擋Id
                    .WhereWhen(Convert.ToInt64(request.UserId) > 0, c => c.UserId == request.UserId)//報到使用者Id
                    .WhereWhenNotEmpty(request.GenerateCode, c => c.GenerateCode == request.GenerateCode)//Id+RefferenceType+UserId 產生唯一值
                    .WhereWhen(request.RegisterStatus.HasValue, c => c.RegisterStatus == request.RegisterStatus)//付款方式 對應SystemConfig內Type=RegisterStatus 0:尚未報到 1:已報到
                    .WhereWhen(request.RegisterTime.HasValue, c => c.RegisterTime == request.RegisterTime)//報到時間

                    .ProjectTo<QrCodeView>(this.mapper.ConfigurationProvider)
                    .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
                    .ToPageAsync(request);




        }
      
        

    }
}
