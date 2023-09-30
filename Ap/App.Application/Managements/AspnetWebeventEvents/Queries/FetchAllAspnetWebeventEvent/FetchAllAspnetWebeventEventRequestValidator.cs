#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetWebeventEvents.Queries.FetchAllAspnetWebeventEvent
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllAspnetWebeventEventRequestValidator 
        : AbstractValidator<FetchAllAspnetWebeventEventRequest>
    {
        public FetchAllAspnetWebeventEventRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
