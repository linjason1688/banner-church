#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberClasses.ModMemberClasses.Queries.FindModMemberClass
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModMemberClassRequestValidator 
        : AbstractValidator<FindModMemberClassRequest>
    {
        public FindModMemberClassRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
