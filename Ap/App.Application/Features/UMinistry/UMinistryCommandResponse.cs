using App.Application.Common.Attributes;

namespace App.Application.Features.UMinistry
{
    /// <summary>
    /// 尋找帳號結果
    /// </summary>
    [SwaggerCustomId(Id = "AddMinistryCommandResponse")]
    public class UMinistryCommandResponse
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public string Name { get; set; }
    }
}
