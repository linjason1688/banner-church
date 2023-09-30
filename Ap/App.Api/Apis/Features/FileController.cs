using System;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using App.Application.Common.Exceptions;
using App.Application.Features.File.Commands.CreateUploadFile;
using App.Application.Features.File.Commands.DownloadFile;
using App.Application.Features.File.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 檔案
    /// </summary>
    [Route("api/features/[controller]")]
    public class FileController : ApiControllerBase
    {
        /// <summary>
        /// 檔案上傳
        /// key: file
        /// </summary>
        /// <param name="category">分類</param>
        /// <param name="file">檔案</param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [Consumes("multipart/form-data")]
        [Route("upload/{category}")]
        [HttpPost]
        public async Task<ApiResponse<UploadFileView>> UploadFileAsync(
            [FromRoute] string category,
            [FromForm] IFormFile file
        )
        {
            if (null == file)
            {
                throw new MyBusinessException($"{nameof(file)} field should be provided");
            }

            var data = await this.Mediator.Send(
                new CreateUploadFileCommand
                {
                    File = file.OpenReadStream(),
                    Category = category,
                    Filename = file.FileName
                }
            );

            var res = new ApiResponse<UploadFileView>()
            {
                Data = data
            };

            return res;
        }


        /// <summary>
        /// 檔案下載
        /// </summary>
        /// <returns></returns>
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [Route("download/{fileKey:guid}")]
        [HttpGet]
        public async Task DownloadFileAsync([FromRoute] Guid fileKey)
        {
            this.Response.Headers.Clear();

            var data = await this.Mediator.Send(
                new DownloadFileCommand
                {
                    FileKey = fileKey,
                    OutputStream = this.Response.Body
                }
            );

            this.Response.ContentType = "application/octet-stream";
            this.Response.Headers.Append("Content-Disposition", $"attachment; filename=\"{data.Filename}\"");

            await this.Response.Body.FlushAsync();
        }
    }
}
