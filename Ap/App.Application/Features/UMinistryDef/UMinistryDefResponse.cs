using App.Application.Common.Attributes;

namespace App.Application.Features.UMinistryDef
{
    //#CreateAPI
    /// <summary>
    /// 尋找帳號結果
    /// </summary>
    [SwaggerCustomId(Id = "AddMinistryDefResponse")]
    public class UMinistryDefResponse
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public string Name { get; set; }
    }
}
