#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.QrCodes.Commands.DeleteQrCode
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteQrCodeCommandValidator 
        : AbstractValidator<DeleteQrCodeCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteQrCodeCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
