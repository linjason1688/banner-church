#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ShoppingTracks.Queries.QueryShoppingTrack
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryShoppingTrackRequestValidator 
        : AbstractValidator<QueryShoppingTrackRequest>
    {
        public QueryShoppingTrackRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
