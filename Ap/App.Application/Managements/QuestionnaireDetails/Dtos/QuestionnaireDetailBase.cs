


using System;
using System.Collections.Generic;

namespace App.Application.Managements.QuestionnaireDetails.Dtos
{
    /// <summary>
    /// 問卷明細
    /// </summary>
    public class QuestionnaireDetailBase
    {


        ///  <summary>
        ///問卷明細Id
        /// </summary>
        public long Id { get; set; }
        ///  <summary>
        ///問卷Id
        /// </summary>
        public long QuestionnaireId { get; set; }
        ///  <summary>
        ///上層問卷DetailId
        /// </summary>
        public long UpperQuestionnaireDetailId { get; set; }
        ///  <summary>
        ///問卷內容類型type=QuestionnaireDetailType namevalue存此欄位0：區段標題1：題目2：選項
        /// </summary>
        public string QuestionnaireDetailType { get; set; }
        ///  <summary>
        ///QuestionnaireType=1才可選問卷內容類型type=ComponentType顯示 namevalue存此欄位0：選擇(單選)1：選擇(多選)2：是非3：簡答
        /// </summary>
        public string ComponentType { get; set; }
        ///  <summary>
        ///顯示排序
        /// </summary>
        public int Sequence { get; set; }
        ///  <summary>
        ///元件描述假設QuestionnaireType=0此顯示區段標題假設QuestionnaireType=1此顯示該UpperQuestionnaireId.區段之Sequence題目名稱假設QuestionnaireType=2此顯示該UpperQuestionnaireId.區段之ComponentType選項之內容說明
        /// </summary>
        public string Name { get; set; }

        ///  <summary>
        ///描述
        /// </summary>
        public string Description { get; set; }

       

        public List<QuestionnaireDetailView> QuestionnaireDetailViews { get; set; }

    }
}

