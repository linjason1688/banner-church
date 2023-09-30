using System.IO;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Dtos.Services;

namespace App.Application.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFileMangeService
    {
        /// <summary>
        /// 一律儲存在 app runtime root folder 底下
        /// </summary>
        /// <param name="file"></param>
        /// <param name="category"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        Task<FileStoreInfo> SaveFileAsync(Stream file, string category, string filename);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="relativeFilepath"></param>
        /// <returns></returns>
        string GetFilepath(string relativeFilepath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="relativeFilepath"></param>
        /// <param name="outputStream"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task DownloadFileAsync(
            string relativeFilepath,
            Stream outputStream,
            CancellationToken cancellationToken = default
        );
    }
}
