#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwCheckInMemberClasses.Queries.FindVwCheckInMemberClass
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwCheckInMemberClassRequestValidator 
        : AbstractValidator<FindVwCheckInMemberClassRequest>
    {
        public FindVwCheckInMemberClassRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
