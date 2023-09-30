using System.ComponentModel;

namespace App.Domain.Entities.Core
{
    /// <summary>
    /// AP 錯誤紀錄
    /// </summary>
    [Description("AP 錯誤紀錄")]
    public class ExceptionLog : EntityBase, ILogEntity
    {
        [Description("Id")]
        public long Id { get; set; }

        /// <summary>
        /// MachineName
        /// </summary>
        [Description("MachineName")]
        public string MachineName { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        [Description("Message")]
        public string Message { get; set; }

        /// <summary>
        /// Source
        /// </summary>
        [Description("Source")]
        public string Source { get; set; }

        /// <summary>
        /// StackTrace
        /// </summary>
        [Description("StackTrace")]
        public string StackTrace { get; set; }

        /// <summary>
        /// 額外資訊
        /// </summary>
        [Description("ExtraData")]
        public string ExtraData { get; set; }
    }
}
