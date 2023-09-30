#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.RolePrivilegeMappings.Queries.QueryRolePrivilegeMapping
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryRolePrivilegeMappingRequestValidator 
        : AbstractValidator<QueryRolePrivilegeMappingRequest>
    {
        public QueryRolePrivilegeMappingRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
