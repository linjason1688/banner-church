#region

using FluentValidation;

#endregion

namespace App.Application.Features.File.Commands.DownloadFile
{
    /// <summary>
    /// </summary>
    public class DownloadFileCommandValidator
        : AbstractValidator<DownloadFileCommand>
    {
        public DownloadFileCommandValidator()
        {
            this.RuleFor(r => r.FileKey)
               .NotNull();

            this.RuleFor(r => r.OutputStream)
               .NotNull();
        }
    }
}
