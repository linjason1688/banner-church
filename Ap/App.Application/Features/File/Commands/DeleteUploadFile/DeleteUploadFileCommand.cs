#region

using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Features.File.Commands.DeleteUploadFile
{
    /// <summary>
    /// 刪除  UploadFile
    /// </summary>
    public class DeleteUploadFileCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }

    /// <summary>
    /// </summary>
    public class DeleteUploadFileCommandHandler : IRequestHandler<DeleteUploadFileCommand, Unit>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IAuthService authService;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        /// <summary>
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="appDbContext"></param>
        /// <param name="authService"></param>
        public DeleteUploadFileCommandHandler(
            ILogger<DeleteUploadFileCommandHandler> logger,
            IMapper mapper,
            IAppDbContext appDbContext,
            IAuthService authService
        )
        {
            this.logger = logger;
            this.mapper = mapper;
            this.appDbContext = appDbContext;
            this.authService = authService;
        }

        /// <summary>
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(
            DeleteUploadFileCommand command,
            CancellationToken cancellationToken
        )
        {
            this.appDbContext.UploadFiles.Remove(
                new UploadFile()
                {
                    Id = command.Id
                }
            );

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
