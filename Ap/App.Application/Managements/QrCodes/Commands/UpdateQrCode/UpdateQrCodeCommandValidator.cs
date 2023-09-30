#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.QrCodes.Commands.UpdateQrCode
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateQrCodeCommandValidator 
        : AbstractValidator<UpdateQrCodeCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateQrCodeCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.QrCode, e => e.Name)
            //     );
        }
    }
}
