using System;

namespace App.Application.Managements.UserQuestionnaires.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class UserQuestionnaireBase
    {
        ///  <summary>
        ///會員填寫問卷.id
        /// </summary>
        public long Id { get; set; }

        ///  <summary>
        ///問卷.id
        /// </summary>
        public long QuestionnaireId { get; set; }

        ///  <summary>
        ///User.id
        /// </summary>
        public long UserId { get; set; }

        ///  <summary>
        ///問卷產生預設0
        ///問卷類型
        ///type=QuestionnaireWriteType
        ///顯示 name
        ///value存此欄位
        ///0：未填寫
        ///1：已填寫
        /// </summary>        
        public string QuestionnaireWriteType { get; set; }

        ///  <summary>
        ///居住區域
        ///type=QuestionnaireGoArea
        ///顯示 name
        ///value存此欄位
        ///0：台中
        ///1：台北
        ///2：高雄
        /// </summary>
        public string QuestionnaireGoArea { get; set; }

        ///  <summary>
        ///滿意度
        ///type=Satisfaction
        ///顯示 name
        ///value存此欄位
        ///1：1
        ///2：2
        ///3：3
        ///4：4
        ///5：5
        /// </summary>
        public string Satisfaction { get; set; }

        ///  <summary>
        ///評價
        ///type=Satisfaction
        ///顯示 name
        ///value存此欄位
        ///1：1
        ///2：2
        ///3：3
        ///4：4
        ///5：5
        /// </summary>
        public string Evaluation { get; set; }

        ///  <summary>
        ///填寫問卷日期
        /// </summary>
        public DateTime? WriteQuestionnaireDate { get; set; }

        /// <summary>
        /// 說明
        /// </summary>
        public string Comment { get; set; }
    }
}
