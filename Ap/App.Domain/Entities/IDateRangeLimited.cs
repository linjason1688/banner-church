using System;
using System.ComponentModel;

namespace App.Domain.Entities
{
    public interface IDateRangeLimited
    {
        /// <summary>
        /// 啟用日期
        /// </summary>
        [Description("啟用日期")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 啟用迄日
        /// </summary>
        [Description("啟用迄日")]
        public DateTime? StopDate { get; set; }
    }
}
