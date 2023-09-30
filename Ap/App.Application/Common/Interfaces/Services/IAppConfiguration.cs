using App.Application.Common.Configs;

namespace App.Application.Common.Interfaces.Services
{
    /// <summary>
    /// </summary>
    public interface IAppConfiguration
    {
        /// <summary>
        /// </summary>
        public AppConfig AppConfig { get; }

        /// <summary>
        /// </summary>
        public SqlConfig SqlConfig { get; }

        /// <summary>
        /// </summary>
        public DevConfig DevConfig { get; }

        /// <summary>
        /// </summary>
        public ScheduleJobsConfig ScheduleJobsConfig { get; }
    }
}
