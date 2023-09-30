namespace App.Application.Common.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class RetrieveProfileState
    {
        /// <summary>
        /// 是否重發 token
        /// </summary>
        public bool ReIssuedToken { get; set; }

        public string JwtToken { get; set; }
    }
}
