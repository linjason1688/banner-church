#region

using FluentValidation;

#endregion

namespace App.Application.Features.File.Commands.CreateUploadFile
{
    /// <summary>
    /// </summary>
    public class CreateUploadFileCommandValidator
        : AbstractValidator<CreateUploadFileCommand>
    {
        public CreateUploadFileCommandValidator()
        {
            this.RuleFor(r => r.File)
               .NotNull();

            this.RuleFor(r => r.Filename)
               .NotEmpty();

            this.RuleFor(r => r.Category)
               .NotEmpty();
        }
    }
}
