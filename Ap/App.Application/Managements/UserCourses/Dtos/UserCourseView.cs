using System;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.UserCourses.Dtos
{
    /// <summary>
    /// UserCourse 
    /// </summary>
    public class UserCourseView : UserCourseBase, IEntityBase
    {

        /// <summary>
        ///  課程名稱
        /// </summary>
        public string CourseName { get; set; }


        ///  <summary>
        ///Organization.Id
        /// </summary>
        public long? OrganizationId { get; set; }

        /// <summary>
        ///  組織名稱
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        ///  主任牧師名稱
        /// </summary>
        public string PastorName { get; set; }

        ///  <summary>
        ///代號/梯次
        /// </summary>
        public string ScheduleNo { get; set; }

        ///  <summary>
        ///附件類別對應type=ClassDay顯示 namevalue存此欄位1：一2：二….
        /// </summary>
        public string ClassDay { get; set; }

        ///  <summary>
        ///開始時間
        /// </summary>
        public string ClassTimeS { get; set; }
        ///  <summary>
        ///結束時間
        /// </summary>
        public string ClassTimeE { get; set; }
        ///  <summary>
        ///地點
        /// </summary>
        public string Place { get; set; }

        ///  <summary>
        ///課程類別CourseManagementType.Id
        /// </summary>
        public long? CourseManagementTypeId { get; set; }

        ///  <summary>
        ///課程代碼
        /// </summary>
        public string CourseManagementNo { get; set; }


        ///  <summary>
        ///課程作業繳交日期
        /// </summary>
        public DateTime? HomeworkDate { get; set; }

        ///  <summary>
        ///課程標題
        /// </summary>
        public string Title { get; set; }
        ///  <summary>
        ///課程內容描述
        /// </summary>
        public string Description { get; set; }
        ///  <summary>
        ///課程狀態對應type=CourseManagementStatus顯示 namevalue存此欄位0：關閉1：開啟
        /// </summary>
        public string CourseManagementStatus { get; set; }

        /// <summary>
        /// 課程類別編號
        /// </summary>
        public string CourseManagementTypeNo { get; set; }

        /// <summary>
        /// 課程類別名稱
        /// </summary>
        public string CourseManagementTypeName { get; set; }

        /// <summary>
        /// 開課狀態 : 0 - 未開，1 - 上課中，2 - 結束
        /// </summary>
        public string CourseStatus { get; set; }

        /// <summary>
        /// 開課班級與時段
        /// </summary>
        public string CourseClassSchedule { get; set; }

        ///  <summary>
        ///年度 屆別
        /// </summary>
        public string Year { get; set; }

        ///  <summary>
        ///名稱
        /// </summary>
        public string Name { get; set; }

        ///  <summary>
        ///梯次
        /// </summary>
        public string ClassNum { get; set; }

        /// <summary>
        /// 課程時間Id
        /// </summary>
        public long? CourseTimeScheduleId { get; set; }

        ///  <summary>
        ///季
        /// </summary>
        public string Season { get; set; }



        ///  <summary>
        ///開課日起
        /// </summary>
        public DateTime OpenDateS { get; set; }

        ///  <summary>
        ///開課日迄
        /// </summary>
        public DateTime OpenDateE { get; set; }

        ///  <summary>
        ///報名日期(線上)
        /// </summary>
        public DateTime? SignUpDateS { get; set; }
        ///  <summary>
        ///報名截止日(線上)
        /// </summary>
        public DateTime? SignUpDateE { get; set; }


        ///  <summary>
        ///報名日期(臨櫃)
        /// </summary>
        public DateTime? CounterSignUpDateS { get; set; }
        ///  <summary>
        ///報名截止日(臨櫃)
        /// </summary>
        public DateTime? CounterSignUpDateE { get; set; }


        /// <inheritdoc />
        public Guid? HandledId { get; set; }

        /// <inheritdoc />
        public DateTime DateCreate { get; set; }

        /// <inheritdoc />
        public string UserCreate { get; set; }

        /// <inheritdoc />
        public DateTime? DateUpdate { get; set; }

        /// <inheritdoc />
        public string UserUpdate { get; set; }

    }
}
