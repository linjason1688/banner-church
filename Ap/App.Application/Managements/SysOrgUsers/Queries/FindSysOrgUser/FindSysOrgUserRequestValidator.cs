#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysOrgUsers.Queries.FindSysOrgUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FindSysOrgUserRequestValidator 
        : AbstractValidator<FindSysOrgUserRequest>
    {
        public FindSysOrgUserRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
