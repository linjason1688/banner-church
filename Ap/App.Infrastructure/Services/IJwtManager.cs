using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Dtos;

namespace App.Infrastructure.Services
{
    /// <summary>
    /// </summary>
    public interface IJwtManager<T>
        where T : JwtPayload
    {
        Task<string> EncodeAsync(
            T payload,
            CancellationToken cancellationToken = new CancellationToken()
        );

        Task<T> DecodeAsync(
            string token,
            bool verify = true,
            CancellationToken cancellationToken = new CancellationToken()
        );
    }
}
