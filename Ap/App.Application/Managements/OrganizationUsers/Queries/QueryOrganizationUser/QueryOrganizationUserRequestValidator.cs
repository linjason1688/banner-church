#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.OrganizationUsers.Queries.QueryOrganizationUser
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryOrganizationUserRequestValidator 
        : AbstractValidator<QueryOrganizationUserRequest>
    {
        public QueryOrganizationUserRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
