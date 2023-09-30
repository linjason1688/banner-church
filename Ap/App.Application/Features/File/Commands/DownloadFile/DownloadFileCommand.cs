#region

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Features.File.Dtos;
using App.Application.Services;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Features.File.Commands.DownloadFile
{
    /// <summary>
    /// </summary>
    public class DownloadFileCommand : IRequest<DownloadFileInfo>
    {
        public Guid FileKey { get; set; }

        public Stream OutputStream { get; set; }
    }

    /// <summary>
    /// </summary>
    public class DownloadUploadFileCommandHandler
        : IRequestHandler<DownloadFileCommand, DownloadFileInfo>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IAuthService authService;
        private readonly IFileMangeService fileMangeService;
        private readonly ILogger logger;
        private readonly IMapper mapper;


        /// <summary>
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="appDbContext"></param>
        /// <param name="authService"></param>
        /// <param name="fileMangeService"></param>
        public DownloadUploadFileCommandHandler(
            ILogger<DownloadUploadFileCommandHandler> logger,
            IMapper mapper,
            IAppDbContext appDbContext,
            IAuthService authService,
            IFileMangeService fileMangeService
        )
        {
            this.logger = logger;
            this.mapper = mapper;
            this.appDbContext = appDbContext;
            this.authService = authService;
            this.fileMangeService = fileMangeService;
        }

        /// <summary>
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DownloadFileInfo> Handle(
            DownloadFileCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.UploadFiles
               .FindOneAsync(e => e.FileKey == command.FileKey, cancellationToken);

            await this.fileMangeService.DownloadFileAsync(
                entity.RelativeFilepath,
                command.OutputStream,
                cancellationToken
            );

            return new DownloadFileInfo()
            {
                Filename = entity.Filename
            };
        }
    }
}
