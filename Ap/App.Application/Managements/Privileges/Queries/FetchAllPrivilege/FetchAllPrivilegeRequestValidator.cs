#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Privileges.Queries.FetchAllPrivilege
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllPrivilegeRequestValidator 
        : AbstractValidator<FetchAllPrivilegeRequest>
    {
        public FetchAllPrivilegeRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
