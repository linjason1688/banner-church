#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysOrgUsers.Queries.QuerySysOrgUser
{
    /// <summary>
    /// 
    /// </summary>
    public class QuerySysOrgUserRequestValidator 
        : AbstractValidator<QuerySysOrgUserRequest>
    {
        public QuerySysOrgUserRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
