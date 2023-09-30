#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberClasses.ModMemberClasses.Queries.FetchAllModMemberClass
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModMemberClassRequestValidator 
        : AbstractValidator<FetchAllModMemberClassRequest>
    {
        public FetchAllModMemberClassRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
