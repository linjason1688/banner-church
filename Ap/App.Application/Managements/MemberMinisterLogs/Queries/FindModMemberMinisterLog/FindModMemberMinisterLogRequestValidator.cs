#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberMinisterLogs.ModMemberMinisterLogs.Queries.FindModMemberMinisterLog
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModMemberMinisterLogRequestValidator 
        : AbstractValidator<FindModMemberMinisterLogRequest>
    {
        public FindModMemberMinisterLogRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
