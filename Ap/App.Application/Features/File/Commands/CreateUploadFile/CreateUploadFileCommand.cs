#region

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Features.File.Dtos;
using App.Application.Services;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

#endregion

namespace App.Application.Features.File.Commands.CreateUploadFile
{
    /// <summary>
    /// 建立 UploadFile
    /// </summary>
    public class CreateUploadFileCommand : IRequest<UploadFileView>
    {
        public Stream File { get; set; }

        /// <summary>
        /// 儲存檔案分類(folder name)
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 檔名
        /// </summary>
        [JsonIgnore]
        public string Filename { get; set; }
    }

    /// <summary>
    /// </summary>
    public class CreateUploadFileCommandHandler : IRequestHandler<CreateUploadFileCommand, UploadFileView>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IFileMangeService fileMangeService;
        private readonly IMapper mapper;

        /// <summary>
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="appDbContext"></param>
        /// <param name="fileMangeService"></param>
        public CreateUploadFileCommandHandler(
            IMapper mapper,
            IAppDbContext appDbContext,
            IFileMangeService fileMangeService
        )
        {
            this.mapper = mapper;
            this.appDbContext = appDbContext;
            this.fileMangeService = fileMangeService;
        }

        /// <summary>
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<UploadFileView> Handle(
            CreateUploadFileCommand command,
            CancellationToken cancellationToken
        )
        {
            var fi = await this.fileMangeService.SaveFileAsync(
                command.File,
                command.Category,
                command.Filename
            );

            var entity = new UploadFile
            {
                FileKey = fi.FileKey,
                OwnerEntity = null,
                Filename = fi.OriginalFilename,
                FileExtension = fi.FileExtension,
                RelativeFilepath = fi.RelativeFilepath,
                Bound = false,
                FileSize = command.File.Length
            };

            await this.appDbContext.UploadFiles.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<UploadFileView>(entity);
        }
    }
}
