using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Dtos.Services;
using App.Application.Common.Interfaces.Services;
using App.Application.Services;
using App.Utility;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Yozian.DependencyInjectionPlus.Attributes;
using Yozian.Extension;

namespace App.Infrastructure.Services.Impl
{
    /// <summary>
    /// </summary>
    [ScopedService(typeof(IFileMangeService))]
    public class FileMangeService
        : IFileMangeService
    {
        /// <summary>
        /// i.e. /abs/path  or   c:\abs\path
        /// </summary>
        private static readonly Regex absPathRegex = new Regex(@"^(\/|[a-z]:\\).+");

        private readonly IAppConfiguration appConfiguration;

        private readonly ILogger logger;

        public FileMangeService(
            IMapper mapper,
            ILogger<FileMangeService> logger,
            IAppConfiguration appConfiguration
        )
        {
            this.logger = logger;
            this.appConfiguration = appConfiguration;
        }


        /// <summary>
        /// 一律儲存在 app runtime root folder 底下
        /// </summary>
        /// <param name="file"></param>
        /// <param name="category"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public async Task<FileStoreInfo> SaveFileAsync(Stream file, string category, string filename)
        {
            var uploadRootPath = this.GetRootPath();
            var folder = Path.Join(uploadRootPath, category);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            var fileKey = Guid.NewGuid();

            var saveFilename = $"{fileKey}-{filename}";

            var relativeFilepath = Path.Join(category, saveFilename);

            var path = Path.Join(folder, saveFilename);

            await using var fs = File.Create(path);

            file.Seek(0, SeekOrigin.Begin);
            await file.CopyToAsync(fs);

            await fs.FlushAsync();

            var length = fs.Length;

            fs.Close();

            return new FileStoreInfo()
            {
                FileKey = fileKey,
                RelativeFilepath = relativeFilepath,
                OriginalFilename = filename,
                FileExtension = Path.GetExtension(filename),
                FileSize = length
            };
        }

        public string GetFilepath(string relativeFilepath)
        {
            return Path.Join(
                this.GetRootPath(),
                relativeFilepath
            );
        }

        public async Task DownloadFileAsync(
            string relativeFilepath,
            Stream outputStream,
            CancellationToken cancellationToken = default
        )
        {
            var filepath = this.GetFilepath(relativeFilepath);

            await using var fs = new FileStream(filepath, FileMode.Open);

            await fs.CopyToAsync(outputStream, cancellationToken);

            fs.Close();
        }

        private string GetRootPath()
        {
            var config = this.appConfiguration.AppConfig;

            var uploadRootPath = this.CorrectPath(config.UploadFolderPath);

            if (absPathRegex.IsMatch(uploadRootPath))
            {
                return uploadRootPath;
            }

            // 非絕對路徑，就儲存在 app root folder
            return Path.Join(
                AppRuntimeVariables.AppRootPath,
                uploadRootPath
            );
        }


        private string CorrectPath(string path)
        {
            Path.GetInvalidPathChars()
               .ForEach(
                    ic =>
                    {
                        path = path.Replace(ic.ToString(), Path.PathSeparator.ToString());
                    }
                );

            return path;
        }
    }
}
