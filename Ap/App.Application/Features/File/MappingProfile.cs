using App.Application.Features.File.Commands.CreateUploadFile;
using App.Application.Features.File.Dtos;
using App.Domain.Entities.Features;
using AutoMapper;

namespace App.Application.Features.File
{
    /// <summary>
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public MappingProfile()
        {
            this.CreateMap<UploadFile, UploadFileView>();
            this.CreateMap<CreateUploadFileCommand, UploadFile>();
        }
    }
}
