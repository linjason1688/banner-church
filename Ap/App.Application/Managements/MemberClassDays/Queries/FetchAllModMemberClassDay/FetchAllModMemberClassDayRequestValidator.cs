#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberClassDays.ModMemberClassDays.Queries.FetchAllModMemberClassDay
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModMemberClassDayRequestValidator 
        : AbstractValidator<FetchAllModMemberClassDayRequest>
    {
        public FetchAllModMemberClassDayRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
