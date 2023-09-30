#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ShoppingTracks.Queries.FindShoppingTrack
{
    /// <summary>
    /// 
    /// </summary>
    public class FindShoppingTrackRequestValidator 
        : AbstractValidator<FindShoppingTrackRequest>
    {
        public FindShoppingTrackRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
