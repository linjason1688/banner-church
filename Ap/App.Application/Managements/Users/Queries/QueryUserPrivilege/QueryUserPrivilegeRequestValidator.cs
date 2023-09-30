#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Privileges.Queries.QueryPrivilege
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryUserPrivilegeRequestValidator 
        : AbstractValidator<QueryUserPrivilegeRequest>
    {
        public QueryUserPrivilegeRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
