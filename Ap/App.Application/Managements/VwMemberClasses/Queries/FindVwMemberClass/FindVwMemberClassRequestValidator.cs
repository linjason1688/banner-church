#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMemberClasses.Queries.FindVwMemberClass
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwMemberClassRequestValidator 
        : AbstractValidator<FindVwMemberClassRequest>
    {
        public FindVwMemberClassRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
