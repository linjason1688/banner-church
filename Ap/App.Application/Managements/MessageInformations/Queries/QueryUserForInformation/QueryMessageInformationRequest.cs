#region

using System;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.MessageInformations.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Yozian.Extension.Pagination;
using Yozian.Extension;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using App.Application.Managements.MessageInformationUsers.Dtos;
using System.Collections.Generic;
using App.Application.Managements.MessageInformations.Queries.FetchAllMessageInformation;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Internal;
using App.Application.Managements.Users.Dtos;

#endregion

namespace App.Application.Managements.MessageInformations.Queries.QueryUserForInformation
{
    /// <summary>
    /// 分頁查詢 MessageInformation
    /// </summary>
    public class QueryUserForInformationRequest
        : IRequest<List<UserView>>, ILimitedFetch
    {
        public int? Limit { get; set; }

        ///  <summary>
        ///Organization.Id 旌旗id
        /// </summary>
        public long OrganizationId { get; set; }

        ///  <summary>
        ///MeetingPoint.Id 聚會點id
        /// </summary>
        public long MeetingPointId { get; set; }

        ///  <summary>
        ///Pastoral.Id 牧養組織id
        /// </summary>
        public long PastoralId { get; set; }

        ///  <summary>
        ///MinistryResp.Id 牧養身分
        /// </summary>
        public long MinistryRespId { get; set; }


        ///  <summary>
        ///Ministry.Id 事工團
        /// </summary>
        public long MinistryId { get; set; }

        ///  <summary>
        ///CourseId 課程名稱 課程代碼
        /// </summary>
        public long CourseId { get; set; }

        ///  <summary>
        ///性別 對應SystemConfigtype=GenderType顯示 namevalue存此欄位0：女姓1：男性
        /// </summary>
        public string GenderType { get; set; }

        ///  <summary>
        ///性別 對應SystemConfigtype=BirthdayYearRange顯示 namevalue存此欄位0：1920   1：1930  2:1940  3:1950  4:1960  5:1970   6:1980  7:1990  8:2000   9:2010   10:2020
        /// </summary>
        public string BirthdayYearRange { get; set; }

        /// <summary>
        ///  職業type=EduType顯示 namevalue存此欄位0：老師1：家管…
        /// </summary>
        public string ProfessionType { get; set; }
    }

    /// <summary>
    ///  分頁查詢 MessageInformation
    /// </summary>
    public class QueryUserForInformationRequestHandler
        : IRequestHandler<QueryUserForInformationRequest, List<UserView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryUserForInformationRequestHandler(
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
            QueryUserForInformationRequest request,
            CancellationToken cancellationToken
        )
        {
            var year = await this.appDbContext
                             .SystemConfigs
                             .Where(c => c.Type == "BirthdayYearRange" && c.Name == request.BirthdayYearRange)
                             .FirstOrDefaultAsync();
            var date = string.IsNullOrEmpty(year?.Value) ? DateTime.MinValue : new DateTime(int.Parse(year?.Value), 1, 1);

            var main = this.appDbContext
                            .Users
                            .WhereWhen(request.MeetingPointId > 0, c => c.MeetingPointId == request.MeetingPointId)
                            .WhereWhen(request.PastoralId > 0, c => c.PastoralId == request.PastoralId)
                            .WhereWhen(string.IsNullOrEmpty(request.GenderType) == false, c => c.GenderType == request.GenderType)
                            .WhereWhen(string.IsNullOrEmpty(request.ProfessionType) == false, c => c.ProfessionType == request.ProfessionType)
                            .WhereWhen(string.IsNullOrEmpty(request.BirthdayYearRange) == false, c => c.Birthday > date);

            if (request.OrganizationId > 0)
            {
                var ids = await this.appDbContext
                                    .OrganizationUsers
                                    .Where(c => c.OrganizationId == request.OrganizationId)
                                    .Select(c => c.UserId)
                                    .ToListAsync();
                main = main.WhereWhen(ids.Count > 0, c => ids.Contains(c.Id));
            }
            if (request.MinistryRespId > 0)
            {
                var ids = await this.appDbContext
                                    .MinistryRespUsers
                                    .Where(c => c.MinistryRespId == request.MinistryRespId)
                                    .Select(c => c.UserId)
                                    .ToListAsync();
                main = main.WhereWhen(ids.Count > 0, c => ids.Contains(c.Id));
            }
            if (request.MinistryId > 0)
            {
                var ids = await (from x in this.appDbContext.MinistryMeetingUsers
                                 from y in this.appDbContext.MinistryMeetings.Where(c => c.MinistryId == request.MinistryId)
                                 where x.MinistryMeetingId == y.Id
                                 select x.UserId).ToListAsync();
                main = main.WhereWhen(ids.Count > 0, c => ids.Contains(c.Id));
            }
            if (request.CourseId > 0)
            {

                var ids = await this.appDbContext
                                    .UserCourses
                                    .Where(c => c.CourseId == request.CourseId)
                                    .Select(c => c.UserId)
                                    .ToListAsync();
                main = main.WhereWhen(ids.Count > 0, c => ids.Contains(c.Id));
            }

            var result = await main.ProjectTo<UserView>(this.mapper.ConfigurationProvider)
                             .ToListAsync();

            return result;
        }
    }
}
