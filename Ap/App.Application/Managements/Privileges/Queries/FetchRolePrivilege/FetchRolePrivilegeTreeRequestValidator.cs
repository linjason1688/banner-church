#region

using FluentValidation;

#endregion

namespace App.Application.Managements.Privileges.Queries.FetchRolePrivilege
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchRolePrivilegeRequestValidator
        : AbstractValidator<FetchRolePrivilegeRequest>
    {
        public FetchRolePrivilegeRequestValidator()
        {
            this.RuleFor(r => r.RoleId)
               .NotNull();
        }
    }
}
