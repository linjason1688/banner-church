#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Privileges.Queries.QueryPrivilege
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryPrivilegeRequestValidator 
        : AbstractValidator<QueryPrivilegeRequest>
    {
        public QueryPrivilegeRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
