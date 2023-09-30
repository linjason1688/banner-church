#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ShoppingTracks.Commands.DeleteShoppingTrack
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteShoppingTrackCommandValidator 
        : AbstractValidator<DeleteShoppingTrackCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteShoppingTrackCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
