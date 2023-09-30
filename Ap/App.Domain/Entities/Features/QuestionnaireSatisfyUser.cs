using System;
using System.Xml.Linq;

namespace App.Domain.Entities.Features
{
    public class QuestionnaireSatisfyUser : EntityBase, ILogEntity
    {
        ///  <summary>
        ///會員出席聚會狀態.id
        /// </summary>
        public long Id { get; set; }
        ///  <summary>
        ///Questionnaire.id 問卷Id
        /// </summary>
        public long QuestionnaireId { get; set; }
        ///  <summary>
        ///User.Id
        /// </summary>
        public long UserId { get; set; }
        ///  <summary>
        ///問卷產生預設0        問卷類型        type = QuestionnaireWriteType顯示 namevalue存此欄位0：未填寫1：已填寫
        /// </summary>
        public string QuestionnaireWriteType { get; set; }
        ///  <summary>
        ///居住區域        type=QuestionnaireGoArea        顯示 name        value存此欄位0：台中1：台北2：高雄
        /// </summary>
        public string QuestionnaireGoArea { get; set; }
        ///  <summary>
        ///滿意度        type=Satisfaction        顯示 name       value存此欄位1：1 2：2 3：3 4：4 5：5
        /// </summary>
        public string Satisfaction { get; set; }
        ///  <summary>
        ///評價        type=Evaluation        顯示 name       value存此欄位1：1 2：2 3：3 4：4 5：5
        /// </summary>
        public string Evaluation { get; set; }
        ///  <summary>
        ///問卷日期
        /// </summary>
        public string WriteQuestionnaireDate { get; set; }



        public DateTime? AttendanceDate { get; set; }

        public string Memo { get; set; }
        public string StatusCd { get; set; }

        public virtual User User { get; set; }
    }
}
