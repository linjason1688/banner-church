#region

using App.Application.Managements.Members.ModMembers.Queries.QueryModMember;
using FluentValidation;

#endregion

namespace App.Application.Managements.Members.Queries.QueryModMember
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModMemberRequestValidator 
        : AbstractValidator<QueryModMemberRequest>
    {
        public QueryModMemberRequestValidator()
        {
            this.RuleFor(r => r);
        }
    }
}
