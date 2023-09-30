#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberClassTimes.ModMemberClassTimes.Queries.FindModMemberClassTime
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModMemberClassTimeRequestValidator 
        : AbstractValidator<FindModMemberClassTimeRequest>
    {
        public FindModMemberClassTimeRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
