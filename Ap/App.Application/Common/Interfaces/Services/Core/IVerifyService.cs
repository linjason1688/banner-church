using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Dtos.Services;

namespace App.Application.Common.Interfaces.Services.Core
{
    public interface IVerifyService
    {
        public Task<Verification> CreateVerification(int codeLength = 4, CancellationToken cancellationToken = default);


        public void Verify(string code, string token);
    }
}
