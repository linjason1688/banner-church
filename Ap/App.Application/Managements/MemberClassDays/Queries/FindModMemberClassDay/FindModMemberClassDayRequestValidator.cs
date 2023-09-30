#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberClassDays.ModMemberClassDays.Queries.FindModMemberClassDay
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModMemberClassDayRequestValidator 
        : AbstractValidator<FindModMemberClassDayRequest>
    {
        public FindModMemberClassDayRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
