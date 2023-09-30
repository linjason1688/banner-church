#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Privileges.Queries.FindPrivilege
{
    /// <summary>
    /// 
    /// </summary>
    public class FindPrivilegeRequestValidator
        : AbstractValidator<FindPrivilegeRequest>
    {
        public FindPrivilegeRequestValidator()
        {
            RuleFor(r => r.Id)
               .NotNull();
        }
    }
}
