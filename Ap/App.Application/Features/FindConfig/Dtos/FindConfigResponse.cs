using App.Domain.Entities.Features;

namespace App.Application.Features.FindConfig.Dtos
{
    /// <summary>
    /// 尋找帳號結果
    /// </summary>
    public class FindConfigResponse
    {
        /// <summary>
        /// 對應使用元件資訊
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 顯示資訊
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 對應數值
        /// </summary>
        public string Value { get; set; }


    }
}
