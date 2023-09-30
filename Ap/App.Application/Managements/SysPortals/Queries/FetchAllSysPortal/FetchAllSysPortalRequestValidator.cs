#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysPortals.Queries.FetchAllSysPortal
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllSysPortalRequestValidator 
        : AbstractValidator<FetchAllSysPortalRequest>
    {
        public FetchAllSysPortalRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
