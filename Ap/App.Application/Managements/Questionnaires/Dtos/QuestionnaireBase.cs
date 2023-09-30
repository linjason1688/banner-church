using System;
using System.Collections.Generic;
using App.Application.Managements.Organizations.Dtos;
using App.Application.Managements.Pastorals.Dtos;
using App.Application.Managements.QuestionnaireDetails.Dtos;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Questionnaires.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class QuestionnaireBase
    {
        ///  <summary>
        ///問卷Id
        /// </summary>
        public long Id { get; set; }

        ///  <summary>
        ///問卷堂點類別        type=QuestionnaireJoinLocation       顯示 name     value存此欄位0：堂點
        /// </summary>
        public string QuestionnaireJoinLocation { get; set; }

        ///  <summary>
        ///問卷類型type=QuestionnaireType顯示 namevalue存此欄位0：課程問卷 1:服事徵召 2:一般問卷
        /// </summary>       
        public string QuestionnaireType { get; set; }

        ///  <summary>
        ///問卷名稱
        /// </summary>
        public string Name { get; set; }


        ///  <summary>
        ///問卷說明
        /// </summary>
        public string Description { get; set; }


        ///  <summary>
        ///指定堂點
        /// </summary>
        public long OrganizationId { get; set; }

        ///  <summary>
        ///指定牧區
        /// </summary>
        public long PastoralId { get; set; }



        ///  <summary>
        ///指定課程分類
        /// </summary>
        public long CourseManagementTypeId { get; set; }
        ///  <summary>
        ///指定課程名稱
        /// </summary>
        public string CourseManagementName { get; set; }
        ///  <summary>
        ///指定年度
        /// </summary>
        public string CourseYear { get; set; }
        ///  <summary>
        ///指定季
        /// </summary>
        public string CourseSeason { get; set; }
        ///  <summary>
        ///指定梯次
        /// </summary>
        public string CourseClassNum { get; set; }
        ///  <summary>
        ///指定課程代碼
        /// </summary>
        public string CourseManagementNo { get; set; }

        ///  <summary>
        ///作業繳交日期
        /// </summary>
        public DateTime CourseHomeworkDate { get; set; }

        /// <summary>
        ///  Organization List When Query OrganizationId Condition 
        /// </summary>
        public List<OrganizationView> OrganizationViews { get; set; }

        /// <summary>
        /// Pastoral List When Query PastoralId Condition
        /// </summary>
        public List<PastoralView> PastoralViews { get; set; }

        /// <summary>
        ///  QuestionnaireDetail List
        /// </summary>
        public List<QuestionnaireDetailView> QuestionnaireDetailsViews { get; set; }


        public QuestionnaireBase()
        {
            this.OrganizationViews = new List<OrganizationView>();
            this.PastoralViews = new List<PastoralView>();
            this.QuestionnaireDetailsViews = new List<QuestionnaireDetailView>();
        }
    }
}
