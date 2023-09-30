#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.RoleUserMappings.Queries.QueryRoleUserMapping
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryRoleUserMappingRequestValidator 
        : AbstractValidator<QueryRoleUserMappingRequest>
    {
        public QueryRoleUserMappingRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
