using System.Threading.Tasks;

namespace App.Infrastructure.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOneTimeSetup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task SetupAsync();
    }
}
