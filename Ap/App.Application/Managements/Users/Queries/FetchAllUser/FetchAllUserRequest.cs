#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Users.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.Users.Queries.FetchAllUser
{
    /// <summary>
    /// 查詢  User 所有資料
    /// </summary>

    public class FetchAllUserRequest
        : IRequest<List<UserView>>, ILimitedFetch
    {
        /// <inheritdoc />

        public int? Limit { get; set; }

        public string? IdNumber { get; set; } //帳號及身分證
        public string? CellPhone { get; set; }//手機
        public string? Email1 { get; set; }//Email1
        public string? Email2 { get; set; }//Email2
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllUserHandler
        : IRequestHandler<FetchAllUserRequest, List<UserView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllUserHandler(
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
        public async Task<List<UserView>> Handle(
            FetchAllUserRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .Users
               .WhereWhenNotEmpty(request.IdNumber, c => c.IdNumber == request.IdNumber)
               .WhereWhenNotEmpty(request.Email1, c => c.Email1 == request.Email1 || c.Email2 == request.Email1)
               .WhereWhenNotEmpty(request.Email2, c => c.Email1 == request.Email2 || c.Email2 == request.Email2)
               .WhereWhenNotEmpty(request.CellPhone, c => c.CellPhone == request.CellPhone ||
                                      c.CellPhone1 == request.CellPhone ||
                                      c.CellPhone2 == request.CellPhone)
               .ApplyLimitConstraint(request)
               .ProjectTo<UserView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
