using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Dtos.Services;

namespace App.Application.Common.Interfaces
{
    public interface ISignInService
    {
        Task<SignInResult> SignInAsync(
            SignIn sign,
            CancellationToken cancellationToken
        );
    }
}
