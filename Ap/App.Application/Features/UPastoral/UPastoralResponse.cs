using App.Application.Common.Attributes;

namespace App.Application.Features.CreateMinistryDef
{
    //#CreateAPI
    /// <summary>
    /// 尋找帳號結果
    /// </summary>
    [SwaggerCustomId(Id = "AddPastoralResponse")]
    public class UPastoralResponse
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public string Name { get; set; }
    }
}
