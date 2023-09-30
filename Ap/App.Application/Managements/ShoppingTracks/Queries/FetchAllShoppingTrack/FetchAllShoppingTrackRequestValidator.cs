#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ShoppingTracks.Queries.FetchAllShoppingTrack
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllShoppingTrackRequestValidator 
        : AbstractValidator<FetchAllShoppingTrackRequest>
    {
        public FetchAllShoppingTrackRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
