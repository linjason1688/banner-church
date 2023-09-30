#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysPortals.Queries.QuerySysPortal
{
    /// <summary>
    /// 
    /// </summary>
    public class QuerySysPortalRequestValidator 
        : AbstractValidator<QuerySysPortalRequest>
    {
        public QuerySysPortalRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
