


namespace App.Application.Managements.MinistryScheduleDetails.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class MinistryScheduleDetailBase
    {
        /// <summary>
        ///  排程明細id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///  MinistrySchedule.Id
        /// </summary>
        public long MinistryScheduleId { get; set; }

        /// <summary>
        ///  堂表名稱 例如：第一堂
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  描述  例如 09:00~10:00
        /// </summary>
        public string Description { get; set; }
        // [DataMember]

    }
}

