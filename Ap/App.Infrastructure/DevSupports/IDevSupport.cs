#region

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

#endregion

namespace App.Infrastructure.DevSupports
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDevSupport
    {
        /// <summary>
        /// 
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Process(Dictionary<string, object> options, CancellationToken cancellationToken = default);
    }
}
