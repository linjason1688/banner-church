#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberLogs.ModMemberLogs.Queries.FindModMemberLog
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModMemberLogRequestValidator 
        : AbstractValidator<FindModMemberLogRequest>
    {
        public FindModMemberLogRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
