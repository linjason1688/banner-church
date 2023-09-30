using App.Application.Common.Dtos;

namespace App.Infrastructure.Dtos.Services
{
    /// <summary>
    /// </summary>
    public sealed class IdentityJwtPayload : JwtPayload
    {
        public UserIdentity User { get; set; }
    }
}
