


using System;
using System.Collections.Generic;
using App.Application.Managements.CourseAppendixs.Dtos;
using App.Application.Managements.CourseManagementFilters.Dtos;

namespace App.Application.Managements.Courses.Dtos
{
    /// <summary>
    /// 課程主檔
    /// </summary>
    public class CourseBase
    {

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }


        ///  <summary>
        ///課程類別CourseManagement.Id
        /// </summary>
        public long CourseManagementId { get; set; }
        ///  <summary>
        ///Organization.Id
        /// </summary>
        public long? OrganizationId { get; set; }


        ///  <summary>
        ///Questionnaire.Id 問卷Id
        /// </summary>
        public long QuestionnaireId { get; set; }


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

        ///  <summary>
        ///季
        /// </summary>
        public string Season { get; set; }

        ///  <summary>
        ///開課日
        /// </summary>
        public DateTime OpenDateS { get; set; }
        ///  <summary>
        ///開課日
        /// </summary>
        public DateTime OpenDateE { get; set; }

        ///  <summary>
        ///開課日
        /// </summary>
        public DateTime OpenDate { get; set; }


   
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

        ///  <summary>
        ///優惠報名截止日
        /// </summary>
        public DateTime? DiscountSignUpDate { get; set; }
        ///  <summary>
        ///報名方式對應type=CourseSignUpType顯示 namevalue存此欄位0：一般臨櫃1：網路報名
        /// </summary>
        public string CourseSignUpType { get; set; }
        ///  <summary>
        ///最少志願數
        /// </summary>
        public int WishCount { get; set; }
        ///  <summary>
        ///是否需要推薦對應type=IsYN顯示 namevalue存此欄位0：N1：Y
        /// </summary>
        public string NeedRecommend { get; set; }
        ///  <summary>
        ///新朋友可報名對應type=IsYN顯示 namevalue存此欄位0：N1：Y
        /// </summary>
        public string AcceptNewMember { get; set; }
        ///  <summary>
        ///課程說明/資格
        /// </summary>
        public string Description { get; set; }
        ///  <summary>
        ///上課堂數
        /// </summary>
        public int ClassCount { get; set; }
        ///  <summary>
        ///報名名額
        /// </summary>
        public int Quota { get; set; }



        ///  <summary>
        ///結業狀態對應type=GraduationType顯示 namevalue存此欄位0：未結業1：已結業 2:-
        /// </summary>
        public string GraduationType { get; set; }



        ///  <summary>
        ///前台特殊需求
        /// </summary>
        public string SpecialRequirement { get; set; }



        ///  <summary>
        ///對象資格說明
        /// </summary>
        public string BasicQualification { get; set; }


        ///  <summary>
        ///結業資格說明
        /// </summary>
        public string GraduationQualification { get; set; }

        ///  <summary>
        ///課程內容
        /// </summary>
        public string CourseContext { get; set; }



        ///  <summary>
        ///注意事項
        /// </summary>
        public string CourseNoticeDesc { get; set; }



        ///  <summary>
        ///退費原則
        /// </summary>
        public string CourseRefundDesc { get; set; }


        ///  <summary>
        ///作業繳交日期
        /// </summary>
        public DateTime HomeworkDate { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        public string StatusCd { get; set; }


        ///  <summary>
        ///課程過濾主檔Id CourseManagementFilter.Id
        /// </summary>
        public long CourseManagementFilterId { get; set; }


        /// <summary>
        /// 課程圖片上傳
        /// </summary>
        public List<CourseAppendixBase> CourseAppendices { get; set; }
        
        /// <summary>
        /// 課程過濾主檔
        /// </summary>
        public CourseManagementFilterBase CourseManagementFilter { get; set; }
    }
}

