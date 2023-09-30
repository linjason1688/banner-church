#region

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services.Core;
using App.Application.Managements.Users.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Yozian.Extension.Pagination;
using Yozian.Extension;
using App.Application.Managements.Pastorals.Dtos;
using System.Collections.Generic;
using App.Application.Managements.CoursePrices.Dtos;
using App.Application.Managements.Organizations.Dtos;
using App.Domain.Entities.Features;
using System.Security.Cryptography;

#endregion

namespace App.Application.Managements.Users.Queries.QueryUser
{
    /// <summary>
    /// 分頁查詢 User
    /// </summary>

    public class QueryUserRequest
        : PageableQuery, IRequest<Page<UserView>>
    {
        ///  <summary>
        ///使用者主檔
        /// </summary>
        public long Id { get; set; }
        ///  <summary>
        ///aspnet_Membership.UserId
        /// </summary>
        public string UserId { get; set; }
        ///  <summary>
        ///所屬牧區id =>對應牧區身分類別
        /// </summary>
        public long? PastoralId { get; set; }
        ///  <summary>
        ///手機類型 對應SystemConfigtype=PhoneType顯示 namevalue存此欄位0：家長手機1：小孩手機
        /// </summary>
        public string PhoneType { get; set; }
        ///  <summary>
        ///姓
        /// </summary>
        public string FirstName { get; set; }
        ///  <summary>
        ///名
        /// </summary>
        public string LastName { get; set; }
        ///  <summary>
        ///性別 對應SystemConfigtype=GenderType顯示 namevalue存此欄位0：女姓1：男性
        /// </summary>
        public string GenderType { get; set; }
        ///  <summary>
        ///居住國家
        /// </summary>
        public string LiveCountry { get; set; }
        ///  <summary>
        ///生日
        /// </summary>
        public DateTime? Birthday { get; set; }
        ///  <summary>
        ///身分證字號
        /// </summary>
        public string IdNumber { get; set; }
        ///  <summary>
        ///手機門號
        /// </summary>
        public string CellPhone { get; set; }
        ///  <summary>
        ///城市
        /// </summary>
        public string LiveCity { get; set; }
        ///  <summary>
        ///郵遞區號
        /// </summary>
        public string LiveZipCode { get; set; }
        ///  <summary>
        ///地區
        /// </summary>
        public string LiveZipArea { get; set; }
        ///  <summary>
        ///詳細地址
        /// </summary>
        public string LiveAddress { get; set; }
        ///  <summary>
        ///地址2
        /// </summary>
        public string LiveAddress2 { get; set; }
        ///  <summary>
        ///教會類別 對SystemConfigtype=ChurchType顯示 namevalue存此欄位0：其他1：旌旗教會
        /// </summary>

        public string ChurchType { get; set; }
        ///  <summary>
        ///過去在哪個教會名稱
        /// </summary>
        public string AnotherChurchName { get; set; }
        ///  <summary>
        ///電話(市話)
        /// </summary>
        public string Phone { get; set; }
        ///  <summary>
        ///電話(手機)
        /// </summary>
        public string CellPhone1 { get; set; }
        ///  <summary>
        ///電話(手機2)
        /// </summary>
        public string CellPhone2 { get; set; }
        ///  <summary>
        ///Email(主要)
        /// </summary>
        public string Email1 { get; set; }
        ///  <summary>
        ///Email(次要)
        /// </summary>
        public string Email2 { get; set; }
        ///  <summary>
        ///APP 對應SystemConfigtype=AppIDType顯示 namevalue存此欄位0：無1：LINE2：Instagram3：WeChat4：其他5：無
        /// </summary>
        public string AppIDType { get; set; }
        ///  <summary>
        ///LINEId
        /// </summary>
        public string LineId { get; set; }
        ///  <summary>
        ///InstagramId
        /// </summary>
        public string InstagramId { get; set; }
        ///  <summary>
        ///WeChatId
        /// </summary>
        public string WeChatId { get; set; }
        ///  <summary>
        ///其他APPId
        /// </summary>
        public string OtherSocialId { get; set; }
        ///  <summary>
        ///是否在旌旗小組對應SystemConfigtype=IsYN顯示 namevalue存此欄位0：N1：Y
        /// </summary>
        public string IsChurchGroup { get; set; }
        ///  <summary>
        ///
        /// </summary>
        public string ChurchGroupNo { get; set; }
        ///  <summary>
        ///是否願意加入旌旗小組對應SystemConfigtype=IsYN顯示 namevalue存此欄位0：N1：Y
        /// </summary>
        public string IsJoinChurchGroup { get; set; }
        ///  <summary>
        ///志願序1 實體 星期對應SystemConfigtype=JoinDate顯示 namevalue存此欄位1：星期一2：星期二3：星期三4：星期四5：星期五6：星期六7：星期日
        /// </summary>
        public string JoinInPersonDate1 { get; set; }
        ///  <summary>
        ///志願序1 實體 時間type=JoinTime顯示 namevalue存此欄位1：上午2：下午
        /// </summary>
        public string JoinInPersonTime1 { get; set; }
        ///  <summary>
        ///志願序1 實體 時間type=JoinLocation顯示 namevalue存此欄位1：堂點
        /// </summary>
        public string JoinInPersonLocation1 { get; set; }
        ///  <summary>
        ///志願序2 實體 星期對應SystemConfigtype=JoinDate顯示 namevalue存此欄位1：星期一2：星期二3：星期三4：星期四5：星期五6：星期六7：星期日
        /// </summary>
        public string JoinInPersonDate2 { get; set; }
        ///  <summary>
        ///志願序2 實體 時間type=JoinTime顯示 namevalue存此欄位1：上午2：下午
        /// </summary>
        public string JoinInPersonTime2 { get; set; }
        ///  <summary>
        ///志願序2 實體 時間type=JoinLocation顯示 namevalue存此欄位1：堂點
        /// </summary>
        public string JoinInPersonLocation2 { get; set; }
        ///  <summary>
        ///志願序3 實體 星期對應SystemConfigtype=JoinDate顯示 namevalue存此欄位1：星期一2：星期二3：星期三4：星期四5：星期五6：星期六7：星期日
        /// </summary>
        public string JoinInPersonDate3 { get; set; }
        ///  <summary>
        ///志願序3實體 時間type=JoinTime顯示 namevalue存此欄位1：上午2：下午
        /// </summary>
        public string JoinInPersonTime3 { get; set; }
        ///  <summary>
        ///志願序3 實體 時間type=JoinLocation顯示 namevalue存此欄位1：堂點
        /// </summary>
        public string JoinInPersonLocation3 { get; set; }
        ///  <summary>
        ///志願序1 線上 星期對應SystemConfigtype=JoinDate顯示 namevalue存此欄位1：星期一2：星期二3：星期三4：星期四5：星期五6：星期六7：星期日
        /// </summary>
        public string JoinOnlineDate1 { get; set; }
        ///  <summary>
        ///志願序1 線上 時間type=JoinTime顯示 namevalue存此欄位1：上午2：下午
        /// </summary>
        public string JoinOnlineTime1 { get; set; }
        ///  <summary>
        ///志願序2 線上 星期對應SystemConfigtype=JoinDate顯示 namevalue存此欄位1：星期一2：星期二3：星期三4：星期四5：星期五6：星期六7：星期日
        /// </summary>
        public string JoinOnlineDate2 { get; set; }
        ///  <summary>
        ///志願序2 線上 時間type=JoinTime顯示 namevalue存此欄位1：上午2：下午
        /// </summary>
        public string JoinOnlineTime2 { get; set; }
        ///  <summary>
        ///志願序3 線上 星期對應SystemConfigtype=JoinDate顯示 namevalue存此欄位1：星期一2：星期二3：星期三4：星期四5：星期五6：星期六7：星期日
        /// </summary>
        public string JoinOnlineDate3 { get; set; }
        ///  <summary>
        ///志願序3 線上 時間type=JoinTime顯示 namevalue存此欄位1：上午2：下午
        /// </summary>
        public string JoinOnlineTime3 { get; set; }
        ///  <summary>
        ///會員類別type=MemberType顯示 namevalue存此欄位0：一般會員1：會友 2：講師
        /// </summary>
        public string MemberType { get; set; }
        ///  <summary>
        ///教育程度type=EduType顯示 namevalue存此欄位0：小學1：國中…..
        /// </summary>
        public string EduType { get; set; }
        ///  <summary>
        ///職業type=EduType顯示 namevalue存此欄位0：老師1：家管…..
        /// </summary>
        public string ProfessionType { get; set; }
        ///  <summary>
        ///是否結婚對應SystemConfigtype=IsMarried顯示 namevalue存此欄位0：未婚1：已婚
        /// </summary>
        public string IsMarried { get; set; }

        ///  <summary>
        ///家長Id
        /// </summary>
        public string ParentUserId { get; set; }
        ///  <summary>
        ///國家代碼
        /// </summary>
        public string CountryCode { get; set; }
        ///  <summary>
        ///是否舊會員 Y是N否
        /// </summary>
        public string IsOldMember { get; set; }
        ///  <summary>
        ///密碼
        /// </summary>
        public string Password { get; set; }
        ///  <summary>
        ///令牌
        /// </summary>
        public string Passwordsalt { get; set; }



        /// <summary>
        ///  成人或是兒童(true - adult; false - children ( <= 12 歲)）
        /// </summary>
        public bool? IsAdult { get; set; }


        /// <summary>
        ///中低收入戶 IsYN 0:否 1:是
        /// </summary>
        public string LowIncome { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 帳號
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 帳號
        /// </summary>
        public string UserNo { get; set; }

        /// <summary>
        /// 聚會點Id
        /// </summary>
        public long MeetingPointId { get; set; }

        /// <summary>
        ///備註欄位
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 受洗 對應SystemConfig type=BaptizedType顯示 namevalue存此欄位0：未受洗1：已受洗2：其它
        /// </summary>
        public string BaptizedType { get; set; }


        ///  <summary>
        ///Organization.Id
        /// </summary>
        public long? OrganizationId { get; set; }
    }

    /// <summary>
    ///  分頁查詢 User
    /// </summary>
    public class QueryUserRequestHandler
        : IRequestHandler<QueryUserRequest, Page<UserView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;
        private readonly IDateTime dateTime;

        /// <summary>
        /// 
        /// </summary>
        public QueryUserRequestHandler(
            IMapper mapper,
            IAppDbContext appDbContext,
            IDateTime dateTime
        )
        {
            this.mapper = mapper;

            this.appDbContext = appDbContext;
            this.dateTime = dateTime;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Page<UserView>> Handle(
            QueryUserRequest request,
            CancellationToken cancellationToken
        )
        {

          


            //先抓角色檔的Id
            var Rst = this.appDbContext.Roles
                 .WhereWhen(1 == 1, c => c.Name.Contains("講師"));

            //抓User權限檔 是講師的角色
            var RUMst = this.appDbContext.RoleUserMappings.WhereWhen(1 == 1, c => Rst.Select(c => c.Id).Contains(c.RoleId));

          

            var OrgUserLst = this.appDbContext.OrganizationUsers
                .WhereWhen(Convert.ToInt64(request.OrganizationId) > 0, c => c.OrganizationId == request.OrganizationId);

            var lst = this.appDbContext
               .Users
               .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)
               .WhereWhen(Convert.ToInt64(request.MeetingPointId) > 0, c => c.MeetingPointId == request.MeetingPointId)

               //.WhereWhenNotEmpty(request.Id.ToString(), c => c.Id == request.Id)//使用者主檔
               //.WhereWhenNotEmpty(request.UserId.ToString(), c => c.UserId == request.UserId)//aspnet_Membership.UserId
               .WhereWhen(Convert.ToInt64(request.PastoralId) > 0, c => c.PastoralId == request.PastoralId)//所屬牧區id =>對應牧區身分類別
               .WhereWhenNotEmpty(request.PhoneType?.ToString(), c => c.PhoneType == request.PhoneType)//手機類型 對應SystemConfigtype=PhoneType顯示 namevalue存此欄位0：家長手機1：小孩手機
               .WhereWhenNotEmpty(request.FirstName?.ToString(), c => c.FirstName == request.FirstName)//姓
               .WhereWhenNotEmpty(request.LastName?.ToString(), c => c.LastName == request.LastName)//名
               .WhereWhenNotEmpty(request.GenderType?.ToString(), c => c.GenderType == request.GenderType)//性別 對應SystemConfigtype=GenderType顯示 namevalue存此欄位0：女姓1：男性
               .WhereWhenNotEmpty(request.LiveCountry?.ToString(), c => c.LiveCountry == request.LiveCountry)//居住國家
               .WhereWhen(request.Birthday != null, c => c.Birthday == request.Birthday)//生日
               .WhereWhenNotEmpty(request.IdNumber?.ToString(), c => c.IdNumber == request.IdNumber)//身分證字號
               .WhereWhenNotEmpty(request.CellPhone?.ToString(), c => c.CellPhone == request.CellPhone)//手機門號
               .WhereWhenNotEmpty(request.LiveCity?.ToString(), c => c.LiveCity == request.LiveCity)//城市
               .WhereWhenNotEmpty(request.LiveZipCode?.ToString(), c => c.LiveZipCode == request.LiveZipCode)//郵遞區號
               .WhereWhenNotEmpty(request.LiveZipArea?.ToString(), c => c.LiveZipArea == request.LiveZipArea)//地區
               .WhereWhenNotEmpty(request.LiveAddress?.ToString(), c => c.LiveAddress == request.LiveAddress)//詳細地址
               .WhereWhenNotEmpty(request.LiveAddress2?.ToString(), c => c.LiveAddress2 == request.LiveAddress2)//地址2
               .WhereWhenNotEmpty(request.ChurchType?.ToString(), c => c.ChurchType == request.ChurchType)//教會類別 對SystemConfigtype=ChurchType顯示 namevalue存此欄位0：其他1：旌旗教會
               .WhereWhenNotEmpty(request.ChurchType?.ToString(), c => c.ChurchType == request.ChurchType)//
               .WhereWhenNotEmpty(request.AnotherChurchName?.ToString(), c => c.AnotherChurchName == request.AnotherChurchName)//過去在哪個教會名稱
               .WhereWhenNotEmpty(request.Phone?.ToString(), c => c.Phone == request.Phone)//電話(市話)
               .WhereWhenNotEmpty(request.CellPhone1?.ToString(), c => c.CellPhone1 == request.CellPhone1)//電話(手機)
               .WhereWhenNotEmpty(request.CellPhone2?.ToString(), c => c.CellPhone2 == request.CellPhone2)//電話(手機2)
               .WhereWhenNotEmpty(request.Email1?.ToString(), c => c.Email1 == request.Email1)//Email(主要)
               .WhereWhenNotEmpty(request.Email2?.ToString(), c => c.Email2 == request.Email2)//Email(次要)
                                                                                              //.WhereWhenNotEmpty(request.AppIDType?.ToString(), c => c.AppIDType == request.AppIDType)//APP 對應SystemConfigtype=AppIDType顯示 namevalue存此欄位0：無1：LINE2：Instagram3：WeChat4：其他5：無
               .WhereWhenNotEmpty(request.LineId?.ToString(), c => c.LineId == request.LineId)//LINEId
               .WhereWhenNotEmpty(request.InstagramId?.ToString(), c => c.InstagramId == request.InstagramId)//InstagramId
               .WhereWhenNotEmpty(request.WeChatId?.ToString(), c => c.WeChatId == request.WeChatId)//WeChatId
               .WhereWhenNotEmpty(request.OtherSocialId?.ToString(), c => c.OtherSocialId == request.OtherSocialId)//其他APPId
                                                                                                                   //.WhereWhenNotEmpty(request.AnotherAppName?.ToString(), c => c.AnotherAppName == request.AnotherAppName)//其他社群使用APP名稱
               .WhereWhenNotEmpty(request.IsChurchGroup?.ToString(), c => c.IsChurchGroup == request.IsChurchGroup)//是否在旌旗小組對應SystemConfigtype=IsYN顯示 namevalue存此欄位0：N1：Y
               .WhereWhenNotEmpty(request.ChurchGroupNo?.ToString(), c => c.ChurchGroupNo == request.ChurchGroupNo)//
               .WhereWhenNotEmpty(request.IsJoinChurchGroup?.ToString(), c => c.IsJoinChurchGroup == request.IsJoinChurchGroup)//是否願意加入旌旗小組對應SystemConfigtype=IsYN顯示 namevalue存此欄位0：N1：Y
               .WhereWhenNotEmpty(request.JoinInPersonDate1?.ToString(), c => c.JoinInPersonDate1 == request.JoinInPersonDate1)//志願序1 實體 星期對應SystemConfigtype=JoinDate顯示 namevalue存此欄位1：星期一2：星期二3：星期三4：星期四5：星期五6：星期六7：星期日
               .WhereWhenNotEmpty(request.JoinInPersonTime1?.ToString(), c => c.JoinInPersonTime1 == request.JoinInPersonTime1)//志願序1 實體 時間type=JoinTime顯示 namevalue存此欄位1：上午2：下午
               .WhereWhenNotEmpty(request.JoinInPersonLocation1?.ToString(), c => c.JoinInPersonLocation1 == request.JoinInPersonLocation1)//志願序1 實體 時間type=JoinLocation顯示 namevalue存此欄位1：堂點
               .WhereWhenNotEmpty(request.JoinInPersonDate2?.ToString(), c => c.JoinInPersonDate2 == request.JoinInPersonDate2)//志願序2 實體 星期對應SystemConfigtype=JoinDate顯示 namevalue存此欄位1：星期一2：星期二3：星期三4：星期四5：星期五6：星期六7：星期日
               .WhereWhenNotEmpty(request.JoinInPersonTime2?.ToString(), c => c.JoinInPersonTime2 == request.JoinInPersonTime2)//志願序2 實體 時間type=JoinTime顯示 namevalue存此欄位1：上午2：下午
               .WhereWhenNotEmpty(request.JoinInPersonLocation2?.ToString(), c => c.JoinInPersonLocation2 == request.JoinInPersonLocation2)//志願序2 實體 時間type=JoinLocation顯示 namevalue存此欄位1：堂點
               .WhereWhenNotEmpty(request.JoinInPersonDate3?.ToString(), c => c.JoinInPersonDate3 == request.JoinInPersonDate3)//志願序3 實體 星期對應SystemConfigtype=JoinDate顯示 namevalue存此欄位1：星期一2：星期二3：星期三4：星期四5：星期五6：星期六7：星期日
               .WhereWhenNotEmpty(request.JoinInPersonTime3?.ToString(), c => c.JoinInPersonTime3 == request.JoinInPersonTime3)//志願序3實體 時間type=JoinTime顯示 namevalue存此欄位1：上午2：下午
               .WhereWhenNotEmpty(request.JoinInPersonLocation3?.ToString(), c => c.JoinInPersonLocation3 == request.JoinInPersonLocation3)//志願序3 實體 時間type=JoinLocation顯示 namevalue存此欄位1：堂點
               .WhereWhenNotEmpty(request.JoinOnlineDate1?.ToString(), c => c.JoinOnlineDate1 == request.JoinOnlineDate1)//志願序1 線上 星期對應SystemConfigtype=JoinDate顯示 namevalue存此欄位1：星期一2：星期二3：星期三4：星期四5：星期五6：星期六7：星期日
               .WhereWhenNotEmpty(request.JoinOnlineTime1?.ToString(), c => c.JoinOnlineTime1 == request.JoinOnlineTime1)//志願序1 線上 時間type=JoinTime顯示 namevalue存此欄位1：上午2：下午
               .WhereWhenNotEmpty(request.JoinOnlineDate2?.ToString(), c => c.JoinOnlineDate2 == request.JoinOnlineDate2)//志願序2 線上 星期對應SystemConfigtype=JoinDate顯示 namevalue存此欄位1：星期一2：星期二3：星期三4：星期四5：星期五6：星期六7：星期日
               .WhereWhenNotEmpty(request.JoinOnlineTime2?.ToString(), c => c.JoinOnlineTime2 == request.JoinOnlineTime2)//志願序2 線上 時間type=JoinTime顯示 namevalue存此欄位1：上午2：下午
               .WhereWhenNotEmpty(request.JoinOnlineDate3?.ToString(), c => c.JoinOnlineDate3 == request.JoinOnlineDate3)//志願序3 線上 星期對應SystemConfigtype=JoinDate顯示 namevalue存此欄位1：星期一2：星期二3：星期三4：星期四5：星期五6：星期六7：星期日
               .WhereWhenNotEmpty(request.JoinOnlineTime3?.ToString(), c => c.JoinOnlineTime3 == request.JoinOnlineTime3)//志願序3 線上 時間type=JoinTime顯示 namevalue存此欄位1：上午2：下午
                                                                                                                         //.WhereWhenNotEmpty(request.MemberType?.ToString(), c => c.MemberType == request.MemberType)//會員類別type=MemberType顯示 namevalue存此欄位0：一般會員1：會友 2:講師

               //.WhereWhenNotEmpty(request.MemberType?.ToString(), c => c.MemberType == request.MemberType)

               //.WhereWhen(1 == 1, c => RUMst.Select(c => c.UserId).Contains(c.Id))//必須有講師角色的權限的User
                                                                                  //
               .WhereWhenNotEmpty(request.EduType?.ToString(), c => c.EduType == request.EduType)//教育程度type=EduType顯示 namevalue存此欄位0：小學1：國中…..
               .WhereWhenNotEmpty(request.ProfessionType?.ToString(), c => c.ProfessionType == request.ProfessionType)//職業type=EduType顯示 namevalue存此欄位0：老師1：家管…..
               .WhereWhenNotEmpty(request.IsMarried?.ToString(), c => c.IsMarried == request.IsMarried)//是否結婚對應SystemConfigtype=IsMarried顯示 namevalue存此欄位0：未婚1：已婚
                                                                                                       //.WhereWhenNotEmpty(request.IsActivated?.ToString(), c => c.IsActivated == request.IsActivated)//是否啟用對應SystemConfigtype=IsYN顯示 namevalue存此欄位0：N1：Y
               .WhereWhenNotEmpty(request.ParentUserId?.ToString(), c => c.ParentUserId.ToString() == request.ParentUserId)//家長Id
               .WhereWhenNotEmpty(request.CountryCode?.ToString(), c => c.CountryCode == request.CountryCode)//國家代碼
               .WhereWhenNotEmpty(request.IsOldMember?.ToString(), c => c.IsOldMember == request.IsOldMember)//是否舊會員 Y是N否
               .WhereWhenNotEmpty(request.LowIncome?.ToString(), c => c.LowIncome == request.LowIncome)//是否中低收入戶
               .WhereWhenNotEmpty(request.Name, c => c.FirstName!.Contains(request.Name) || c.LastName!.Contains(request.Name))
               .WhereWhenNotEmpty(request.Username, c => c.Name == request.Username)
               .WhereWhenNotEmpty(request.UserNo, c => c.UserNo == request.UserNo)
               .WhereWhenNotEmpty(request.BaptizedType?.ToString(), c => c.BaptizedType == request.BaptizedType)//BaptizedType //是否受洗 0否 1是

               //過濾堂點資訊
               .WhereWhen(Convert.ToInt64(request.OrganizationId) > 0, c => OrgUserLst.Select(c => c.UserId).Contains(c.Id))    
               
            ;
            if (!string.IsNullOrEmpty(request.MemberType))
            {
                if (request.MemberType.ToString() == "2")
                {
                    lst = lst.WhereWhen(1 == 1, c => RUMst.Select(c => c.UserId).Contains(c.Id));//必須有講師角色的權限的User
                }
            }

          


            if (request.IsAdult.HasValue)
            {
                // lst = (await lst.ToListAsync())
                //         .Where(c => c.Birthday <= DateTime.Now)  //过滤非法生日
                //         .Where(c => request.IsAdult.Value ?
                //                     (new DateTime((DateTime.Now - c.Birthday).Ticks).Year - 1) > 12 :
                //                     (new DateTime((DateTime.Now - c.Birthday).Ticks).Year - 1) <= 12)
                //         .AsQueryable();


                //使用DateDiffYear, 會轉成Sql DateDiff(Year, date1, date2)
                //只計算 年份，不是太精準。
                //lst = lst.Where(c => request.IsAdult.Value ?
                //                    EF.Functions.DateDiffYear(c.Birthday, DateTime.Now) > 12 :
                //                    EF.Functions.DateDiffYear(c.Birthday, DateTime.Now) <= 12);

                var adultBrithThresholdDate = this.dateTime.Now.AddYears(-12);

                lst = lst
                   .Where(c => c.Birthday <= this.dateTime.Now)
                   .WhereWhen(

                        // 大人
                        request.IsAdult.Value,
                        e => EF.Functions.DateDiffDay(e.Birthday, adultBrithThresholdDate) > 0
                    )
                   .WhereWhen(

                        // 小孩
                        !request.IsAdult.Value,
                        e => EF.Functions.DateDiffDay(e.Birthday, adultBrithThresholdDate) <= 0
                    );

            }

            var result = await lst.ProjectTo<UserView>(this.mapper.ConfigurationProvider)
                            .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
                            .ToPageAsync(request);

            //Flat org & pastoral
            // ToDo
            //for lst 將 objPastoral 跟  objOrg 包進去 UserView內
            var ids = result.Records.Select(c => c.Id).ToList();
            var pastIds = result.Records.Select(c => c.PastoralId).ToList();
            var orgLst = await (from x in this.appDbContext.OrganizationUsers.Where(c => ids.Contains(c.UserId))
                                from y in this.appDbContext.Organizations
                                where x.OrganizationId == y.Id
                                select new
                                {
                                    UserId = x.UserId,
                                    OrgView = this.mapper.Map<OrganizationView>(y)
                                }).ToListAsync(cancellationToken);
            var pastLst = await this.appDbContext.Pastorals.Where(c => pastIds.Contains(c.Id))
                                    .ProjectTo<PastoralView>(this.mapper.ConfigurationProvider)
                                    .ToListAsync(cancellationToken);
            foreach (var obj in result.Records)
            {
                //抓User權限檔 
                var RUMst2 = this.appDbContext.RoleUserMappings.WhereWhen(1==1, c => c.UserId == obj.Id).SingleOrDefault();
                //放入權限Id資訊
                if (RUMst2 != null)
                {
                    obj.RoleId = RUMst2.RoleId;
                }
                var org = orgLst.FirstOrDefault(c => c.UserId == obj.Id);
                if (org != null)
                {
                    await this.OrganizationFlatBuilder(org.OrgView, obj.OrganizationTree, "UP","1");
                }
                var past = pastLst.FirstOrDefault(c => c.Id == obj.PastoralId);
                if (past != null)
                {
                    await this.PastoralFlatBuilder(past, obj.PastoralTree, "UP", "1");
                }
            }

            return result;
        }

        private async Task OrganizationFlatBuilder(OrganizationView obj, List<OrganizationView> result, string mode,string AddDefault)
        {
            if (mode.ToUpper() == "UP")
            {
                
                var parent = await this.appDbContext.Organizations
                                    .Where(c => c.Id == obj.UpperOrganizationId)
                                    .ProjectTo<OrganizationView>(this.mapper.ConfigurationProvider)
                                    .FirstOrDefaultAsync();
                if (AddDefault == "1") //預設第一次進來要把原本的第一筆資料先寫入
                {
                    result.Add(obj);
                }
                if (parent != null)
                {
                    result.Add(parent);
                    await OrganizationFlatBuilder(parent, result, mode,"0");
                }
            }
            else
            {
                if (obj == null) return;
                result.Add(obj);
                var lst = await this.appDbContext.Organizations
                                    .Where(c => c.UpperOrganizationId == obj.Id)
                                    .ProjectTo<OrganizationView>(this.mapper.ConfigurationProvider)
                                    .ToListAsync();
                foreach (var past in lst)
                {
                    await this.OrganizationFlatBuilder(past, result, mode, "0");
                }
            }
        }
        private async Task PastoralFlatBuilder(PastoralView obj, List<PastoralView> result, string mode, string AddDefault)
        {
            if (mode.ToUpper() == "UP")
            {
                if (AddDefault == "1") //預設第一次進來要把原本的第一筆資料先寫入
                {
                    result.Add(obj);
                }

                var parent = await this.appDbContext.Pastorals
                                    .Where(c => c.Id == obj.UpperPastoralId)
                                    .ProjectTo<PastoralView>(this.mapper.ConfigurationProvider)
                                    .FirstOrDefaultAsync();
                if (parent != null)
                {
                    result.Add(parent);
                    await PastoralFlatBuilder(parent, result, mode, "0");
                }
            }
            else
            {
                if (obj == null) return;
                result.Add(obj);
                var lst = await this.appDbContext.Pastorals
                                    .Where(c => c.UpperPastoralId == obj.Id)
                                    .ProjectTo<PastoralView>(this.mapper.ConfigurationProvider)
                                    .ToListAsync();
                foreach (var past in lst)
                {
                    await this.PastoralFlatBuilder(past, result, mode, "0");
                }
            }
        }
    }
}
