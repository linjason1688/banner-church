#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Members.ModMembers.Queries.FindModMember
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModMemberRequestValidator 
        : AbstractValidator<FindModMemberRequest>
    {
        public FindModMemberRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
