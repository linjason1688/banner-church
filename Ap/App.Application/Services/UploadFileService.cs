using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Domain.Entities;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Yozian.DependencyInjectionPlus.Attributes;

namespace App.Application.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUploadFileService
    {
        /// <summary>
        /// 將檔案標記 (已/未) 綁定
        /// </summary>
        /// <param name="fileKey"></param>
        /// <param name="bound"></param>
        /// <param name="cancellationToken"></param>
        Task MarkFileBoundAsync<T>(Guid? fileKey, bool bound = true, CancellationToken cancellationToken = default)
            where T : EntityBase;

        /// <summary>
        /// 刪除檔案
        /// </summary>
        /// <param name="fileKey"></param>
        /// <param name="cancellationToken"></param>
        Task RemoveFileAsync(Guid? fileKey, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// 
    /// </summary>
    [ScopedService(typeof(IUploadFileService))]
    public class UploadFileService
        : IUploadFileService
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;
        private readonly IAppDbContext appDbContext;
        private readonly IFileMangeService fileMangeService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        /// <param name="appDbContext"></param>
        /// <param name="fileMangeService"></param>
        public UploadFileService(
            IMapper mapper,
            ILogger<UploadFileService> logger,
            IAppDbContext appDbContext,
            IFileMangeService fileMangeService
        )
        {
            this.mapper = mapper;
            this.logger = logger;
            this.appDbContext = appDbContext;
            this.fileMangeService = fileMangeService;
        }


        /// <summary>
        /// 將檔案標記 (已/未) 綁定
        /// </summary>
        /// <param name="fileKey"></param>
        /// <param name="bound"></param>
        /// <param name="cancellationToken"></param>
        public async Task MarkFileBoundAsync<T>(
            Guid? fileKey,
            bool bound = true,
            CancellationToken cancellationToken = default
        )
            where T : EntityBase
        {
            if (!fileKey.HasValue)
            {
                return;
            }

            var file = await this.appDbContext.UploadFiles
               .FindOneAsync(
                    e => e.FileKey == fileKey,
                    cancellationToken
                );

            file.Bound = bound;
            file.OwnerEntity = typeof(T).Name;

            await this.appDbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// 刪除檔案
        /// </summary>
        /// <param name="fileKey"></param>
        /// <param name="cancellationToken"></param>
        public async Task RemoveFileAsync(Guid? fileKey, CancellationToken cancellationToken = default)
        {
            if (!fileKey.HasValue)
            {
                return;
            }

            var file = await this.appDbContext.UploadFiles
               .FindOneAsync(
                    e => e.FileKey == fileKey,
                    cancellationToken
                );

            var path = this.fileMangeService.GetFilepath(file.RelativeFilepath);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
