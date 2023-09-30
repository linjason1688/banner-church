#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberClassDayTerms.ModMemberClassDayTerms.Queries.FetchAllModMemberClassDayTerm
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModMemberClassDayTermRequestValidator 
        : AbstractValidator<FetchAllModMemberClassDayTermRequest>
    {
        public FetchAllModMemberClassDayTermRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
