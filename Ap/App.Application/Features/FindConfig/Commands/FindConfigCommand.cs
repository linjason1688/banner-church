using App.Application.Features.FindConfig.Dtos;
using App.Domain.Entities.Features;
using MediatR;

namespace App.Application.Features.FindConfig.Commands
{
    /// <summary>
    /// 尋找帳號請求
    /// </summary>
    public class FindConfigCommand : IRequest<FindConfigResponse>
    {

        /// <summary>
        /// Key系統自動產生
        /// </summary>
        public string Id{ get; set; }

        /// <summary>
        /// 對應使用元件資訊
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 對應數值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 顯示資訊
        /// </summary>
        public string Name { get; set; }


    }
}
