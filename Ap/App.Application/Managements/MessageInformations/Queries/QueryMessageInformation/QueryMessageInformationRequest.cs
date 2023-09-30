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

#endregion

namespace App.Application.Managements.MessageInformations.Queries.QueryMessageInformation
{
    /// <summary>
    /// 分頁查詢 MessageInformation
    /// </summary>
    public class QueryMessageInformationRequest
        : PageableQuery, IRequest<Page<MessageInformationView>>
    {
        /// <summary>
        /// id
        /// </summary>
        public long? Id { get; set; }

        ///Organization.Id 旌旗id           //GetUserId from  User.OrganizationId
        /// </summary>
        public long? OrganizationId { get; set; }

        ///  <summary>
        ///MeetingPoint.Id 聚會點id       //GetUserId from  User.MeetingPointId
        /// </summary>
        public long? MeetingPointId { get; set; }

        ///  <summary>
        ///Pastoral.Id 牧養組織id         //GetUserId from  User.PastoralId
        /// </summary>
        public long? PastoralId { get; set; }

        ///  <summary>
        ///MinistryResp.Id 牧養身分
        /// </summary>                            //GetUserId from MinistryRespUser.MinistryRespId 
        public long? MinistryRespId { get; set; }


        ///  <summary>
        ///Ministry.Id 事工團                                      //GetUserId from MinistryMeetingUser join  MinistryMeeting   => MinistryMeeting.MinistryId=輸入的MinistryId
        /// </summary>
        public long? MinistryId { get; set; }

        ///  <summary>
        ///CourseNo 課程名稱 課程代碼          //GetUserId from UserCourse     
        /// </summary>
        public long? CourseId { get; set; }

        ///  <summary>
        ///性別 對應SystemConfigtype=GenderType顯示 namevalue存此欄位0：女姓1：男性     //GetUserId from  User.GenderType
        /// </summary>
        public string? GenderType { get; set; }

        ///  <summary>           //GetUserId from  User.Birthday 年分 like 選的前三位 碼  例如  0 =>1920   就是 birthday like '192%'
        ///性別 對應SystemConfigtype=BirthdayYearRange顯示 namevalue存此欄位0：1920   1：1930  2:1940  3:1950  4:1960  5:1970   6:1980  7:1990  8:2000   9:2010   10:2020
        /// </summary>
        public string? BirthdayYearRange { get; set; }

        /// <summary>
        ///  職業type=EduType顯示 namevalue存此欄位0：老師1：家管…    //GetUserId from  User.ProfessionType
        /// </summary>
        public string? ProfessionType { get; set; }

        /// <summary>
        /// 推播訊息描述
        /// </summary>
        public string? Title { get; set; }


        /// <summary>
        /// 推播訊息內容
        /// </summary>
        public string? Descriptions { get; set; }


        /// <summary>
        ///  職業type=MessageSendType namevalue存此欄位0：尚未推播    1：已推播
        /// </summary>
        public string? MessageSendType { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        public string StatusCd { get; set; }
    }

    /// <summary>
    ///  分頁查詢 MessageInformation
    /// </summary>
    public class QueryMessageInformationRequestHandler
        : IRequestHandler<QueryMessageInformationRequest, Page<MessageInformationView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryMessageInformationRequestHandler(
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
        public async Task<Page<MessageInformationView>> Handle(
            QueryMessageInformationRequest request,
            CancellationToken cancellationToken
        )
        {
            var result = await this.appDbContext
               .MessageInformations
               .WhereWhen(Convert.ToInt64(request.Id) != 0, c => c.Id == request.Id) //id
               .WhereWhenNotEmpty(request.StatusCd, c => c.StatusCd == request.StatusCd)
               .ProjectTo<MessageInformationView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

            var ids = result.Records.Select(c => c.Id);

            var details = await this.appDbContext.MessageInformationUsers
                                    .Where(c => ids.Contains(c.MessageInformationId))
                                    .ProjectTo<MessageInformationUserView>(this.mapper.ConfigurationProvider)
                                    .ToListAsync();
            foreach(var obj in result.Records)
            {
                obj.messageInformationUserViews = details.Where(c => c.MessageInformationId == obj.Id).ToList();
            }
            return result;
        }
    }
}
