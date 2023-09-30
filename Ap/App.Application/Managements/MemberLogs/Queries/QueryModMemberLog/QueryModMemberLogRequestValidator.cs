#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberLogs.ModMemberLogs.Queries.QueryModMemberLog
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModMemberLogRequestValidator 
        : AbstractValidator<QueryModMemberLogRequest>
    {
        public QueryModMemberLogRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
