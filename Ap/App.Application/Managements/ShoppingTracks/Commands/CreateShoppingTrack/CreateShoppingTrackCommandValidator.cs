#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.ShoppingTracks.Commands.CreateShoppingTrack
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateShoppingTrackCommandValidator 
        : AbstractValidator<CreateShoppingTrackCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateShoppingTrackCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ShoppingTrack, e => e.Name)
            //     );
        }
    }
}
