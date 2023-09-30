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
using App.Application.Managements.UserContacts.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.UserContacts.Queries.QueryUserContact
{
    /// <summary>
    /// 分頁查詢 UserContact
    /// </summary>

    public class QueryUserContactRequest 
        : PageableQuery, IRequest<Page<UserContactView>>
    {

        /// <summary>
        ///  Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        ///  建立 User.Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        ///  姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///  關係類別 對應SystemConfig        type=RelativeType       顯示 name       value存此欄位0：配偶1：父母2：子女
        /// </summary>
        public string RelativeType { get; set; }

        /// <summary>
        ///  電話
        /// </summary>
        public string Phone { get; set; }
    }

    /// <summary>
    ///  分頁查詢 UserContact
    /// </summary>
    public class QueryUserContactRequestHandler 
        : IRequestHandler<QueryUserContactRequest, Page<UserContactView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryUserContactRequestHandler(
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
        public async Task<Page<UserContactView>> Handle(
            QueryUserContactRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .UserContacts
              .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)//id//緊急聯絡人
              .WhereWhen(Convert.ToInt64(request.UserId) > 0, c => c.UserId == request.UserId)//User.Id
                //.WhereWhenNotEmpty(request.UserId.ToString(), c => c.UserId.ToString() == request.UserId)//User.Id
                .WhereWhenNotEmpty(request.Name?.ToString(), c => c.Name == request.Name)//姓名
                .WhereWhenNotEmpty(request.RelativeType.ToString(), c => c.Relative.ToString() == request.RelativeType.ToString())//關係
                .WhereWhenNotEmpty(request.Phone?.ToString(), c => c.Phone == request.Phone)//電話

               .ProjectTo<UserContactView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
