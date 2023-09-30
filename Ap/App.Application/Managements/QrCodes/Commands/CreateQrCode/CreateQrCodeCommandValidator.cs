#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.QrCodes.Commands.CreateQrCode
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateQrCodeCommandValidator 
        : AbstractValidator<CreateQrCodeCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateQrCodeCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.QrCode, e => e.Name)
            //     );
        }
    }
}
