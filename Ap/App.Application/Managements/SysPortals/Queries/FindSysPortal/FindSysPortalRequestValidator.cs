#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysPortals.Queries.FindSysPortal
{
    /// <summary>
    /// 
    /// </summary>
    public class FindSysPortalRequestValidator 
        : AbstractValidator<FindSysPortalRequest>
    {
        public FindSysPortalRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
