namespace App.Application.Common.Dtos.Services
{
    /// <summary>
    /// </summary>
    public class AccountVerification
    {
        /// <summary>
        /// 請於登入時一併帶上
        /// </summary>
        public string Token { get; set; }
        
#if DEBUG
        public string Code { get; set; }
#endif
    }
}
