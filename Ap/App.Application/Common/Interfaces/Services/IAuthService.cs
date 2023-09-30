using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Dtos;
using App.Application.Common.Dtos.Services;

namespace App.Application.Common.Interfaces.Services
{
    public interface IAuthService
    {
        bool IsPrivilegeFree { get; }

        bool Authorized { get; }

        UserIdentity Identity { get; }

        Task<SignInResult> SignInAsync(
            SignIn data,
            CancellationToken cancellationToken = new CancellationToken()
        );

        /// <summary>
        /// 驗證 / refresh sso session
        /// </summary>
        Task ValidateSessionAsync(ValidateSessionRequest request);

        /// <summary>
        /// 取得 sso user profile
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        Task<string> GenerateJwtAsync(
            UserIdentity identity = null,
            CancellationToken cancellationToken = new CancellationToken()
        );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jwt"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<RetrieveProfileState> RetrievingProfileOfJwtAsync(
            string jwt,
            CancellationToken cancellationToken = new CancellationToken()
        );

        /// <summary>
        /// 檢查存取權限
        /// </summary>
        /// <param name="action"></param>
        /// <param name="controller"></param>
        /// <returns></returns>
        Task<bool> HasPrivilegeForAsync(string action, string controller);
    }
}
