#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Members.ModMembers.Queries.FetchAllModMember
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModMemberRequestValidator 
        : AbstractValidator<FetchAllModMemberRequest>
    {
        public FetchAllModMemberRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
