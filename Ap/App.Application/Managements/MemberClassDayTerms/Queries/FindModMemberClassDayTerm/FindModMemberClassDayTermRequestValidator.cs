#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberClassDayTerms.ModMemberClassDayTerms.Queries.FindModMemberClassDayTerm
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModMemberClassDayTermRequestValidator 
        : AbstractValidator<FindModMemberClassDayTermRequest>
    {
        public FindModMemberClassDayTermRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
