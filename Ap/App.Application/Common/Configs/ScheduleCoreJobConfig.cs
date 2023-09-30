namespace App.Application.Common.Configs
{
    /// <summary>
    /// 
    /// </summary>
    public class ScheduleCoreJobConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public JobConfig HeartBeatingJob { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public HouseKeepingConfig LogFileHousekeepingJob { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public HouseKeepingConfig ApiLogHousekeepingJob { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public JobConfig ApiAuditLogJob { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public JobConfig ExceptionLogJob { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class HouseKeepingConfig : JobConfig
    {
        /// <summary>
        /// 保留天數
        /// </summary>
        public int? KeepDays { get; set; }
    }
}
