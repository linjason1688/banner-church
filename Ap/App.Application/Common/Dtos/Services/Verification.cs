namespace App.Application.Common.Dtos.Services
{
    /// <summary>
    /// </summary>
    public class Verification
    {
        /// <summary>
        /// Base 64
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// 請於登入時一併帶上
        /// </summary>
        public string Token { get; set; }
        
#if DEBUG
        public int Code { get; set; }
#endif
    }
}
