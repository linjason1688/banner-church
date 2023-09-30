#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberClassTimes.ModMemberClassTimes.Queries.FetchAllModMemberClassTime
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModMemberClassTimeRequestValidator 
        : AbstractValidator<FetchAllModMemberClassTimeRequest>
    {
        public FetchAllModMemberClassTimeRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
