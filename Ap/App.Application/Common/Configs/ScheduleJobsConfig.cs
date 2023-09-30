namespace App.Application.Common.Configs
{
    /// <summary>
    /// 
    /// </summary>
    public class ScheduleJobsConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public ScheduleCoreJobConfig Core { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ScheduleFeatureJobConfig Features { get; set; }
    }



    /// <summary>
    /// 
    /// </summary>
    public class JobConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CronExpression { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ap 啟動時執行一次 (可供測試使用)
        /// </summary>
        public bool StartAtStartup { get; set; }
    }


}
