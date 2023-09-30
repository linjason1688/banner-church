using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.Domain.Entities.Features;

namespace App.Application.Common.Interfaces.Services
{
    public interface IAppCacheService
    {
        /// <summary>
        /// </summary>
        /// <param name="forceReload"></param>
        /// <returns></returns>
        Task<string> GetItemAsync(bool forceReload = false);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<Privilege>> GetPrivilegesAsync(
            bool forceReload = false,
            CancellationToken cancellationToken = default
        );


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<RolePrivilegeMapping>> GetRolePrivilegeMappingAsync(
            bool forceReload = false,
            CancellationToken cancellationToken = default
        );
    }
}
