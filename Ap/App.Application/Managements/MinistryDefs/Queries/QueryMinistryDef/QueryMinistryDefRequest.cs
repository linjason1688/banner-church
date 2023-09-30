using System;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.MinistryDefs.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Yozian.Extension;
using Yozian.Extension.Pagination;

namespace App.Application.Managements.MinistryDefs.Queries.QueryMinistryDef
{
    /// <summary>
    /// 分頁查詢 MinistryDef
    /// </summary>
    public class QueryMinistryDefRequest
        : PageableQuery, IRequest<Page<MinistryDefView>>
    {
        /// <summary>
        /// id
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// 事工團分類代碼
        /// </summary>
        public string MinistryDefNo { get; set; }

        /// <summary>
        /// 事工團分類名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 事工團類別狀態
        /// </summary>
        public string MinistryDefStatus { get; set; }

        /// <summary>
        /// 事工團類別  MinistryDefType 0一般事工團   1小組  
        /// </summary>
        public string MinistryDefType { get; set; }

    }

    /// <summary>
    ///  分頁查詢 MinistryDef
    /// </summary>
    public class QueryMinistryDefRequestHandler
        : IRequestHandler<QueryMinistryDefRequest, Page<MinistryDefView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryMinistryDefRequestHandler(
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
        public async Task<Page<MinistryDefView>> Handle(
            QueryMinistryDefRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .MinistryDefs
               .WhereWhen(Convert.ToInt64(request.Id) != 0, c => c.Id == request.Id) //事工團分類.id
               .WhereWhenNotEmpty(
                    request.MinistryDefNo,
                    c => c.MinistryDefNo == request.MinistryDefNo
                )                                                            //事工團分類代碼
               .WhereWhenNotEmpty(request.Name, c => c.Name == request.Name) //事工團分類名稱
               .WhereWhenNotEmpty(
                    request.MinistryDefStatus,
                    c => c.MinistryDefStatus.ToString() == request.MinistryDefStatus
                ) //事工團類別類型type=MinistryDefStatus顯示 namevalue存此欄位0：停用1：啟用

                 .WhereWhenNotEmpty(
                    request.MinistryDefType,
                    c => c.MinistryDefType.ToString() == request.MinistryDefType
                ) //事工團類別類型type=MinistryDefType namevalue存此欄位0：一般事工團 1：小組
               .ProjectTo<MinistryDefView>(this.mapper.ConfigurationProvider)
               // .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);
        }
    }
}
