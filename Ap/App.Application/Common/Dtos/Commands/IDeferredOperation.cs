using Newtonsoft.Json;

namespace App.Application.Common.Dtos.Commands
{
    /// <summary>
    /// </summary>
    public interface IDeferredOperation
    {
        /// <summary>
        /// 由外層 caller 控制 save 的時機
        /// 供其它 command called 時使用
        /// </summary>
        [JsonIgnore]
        bool DeferredSave { get; set; }
    }
}
