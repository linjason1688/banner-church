using System.ComponentModel;

namespace App.Domain.Constants
{
    /// <summary>
    /// 性別
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// 女
        /// </summary>
        [Description("Female")]
        Female,

        /// <summary>
        /// 男
        /// </summary>
        [Description("Male")]
        Male,

        /// <summary>
        /// 中性
        /// </summary>
        [Description("Neutral")]
        Neutral
    }
}
