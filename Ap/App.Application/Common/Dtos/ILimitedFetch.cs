namespace App.Application.Common.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILimitedFetch
    {
        /// <summary>
        /// 筆數限制
        /// </summary>
        int? Limit { get; set; }
    }
}
