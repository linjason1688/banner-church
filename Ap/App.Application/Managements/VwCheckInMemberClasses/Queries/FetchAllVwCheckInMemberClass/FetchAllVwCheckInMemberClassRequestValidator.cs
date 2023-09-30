#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwCheckInMemberClasses.Queries.FetchAllVwCheckInMemberClass
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwCheckInMemberClassRequestValidator 
        : AbstractValidator<FetchAllVwCheckInMemberClassRequest>
    {
        public FetchAllVwCheckInMemberClassRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
