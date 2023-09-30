#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.ShoppingTracks.Commands.UpdateShoppingTrack
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateShoppingTrackCommandValidator 
        : AbstractValidator<UpdateShoppingTrackCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateShoppingTrackCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ShoppingTrack, e => e.Name)
            //     );
        }
    }
}
