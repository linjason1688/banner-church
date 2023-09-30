#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberMinisterLogs.ModMemberMinisterLogs.Queries.QueryModMemberMinisterLog
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModMemberMinisterLogRequestValidator 
        : AbstractValidator<QueryModMemberMinisterLogRequest>
    {
        public QueryModMemberMinisterLogRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
