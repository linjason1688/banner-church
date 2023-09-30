#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysOrgUsers.Queries.FetchAllSysOrgUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllSysOrgUserRequestValidator 
        : AbstractValidator<FetchAllSysOrgUserRequest>
    {
        public FetchAllSysOrgUserRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
