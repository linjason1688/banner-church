#region

using FluentValidation;

#endregion

namespace App.Application.Features.File.Commands.DeleteUploadFile
{
    /// <summary>
    /// </summary>
    public class DeleteUploadFileCommandValidator
        : AbstractValidator<DeleteUploadFileCommand>
    {
        public DeleteUploadFileCommandValidator()
        {
            this.RuleFor(r => r);
        }
    }
}
