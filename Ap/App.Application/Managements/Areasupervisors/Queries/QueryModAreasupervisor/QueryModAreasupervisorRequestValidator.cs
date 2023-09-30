#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Areasupervisors.ModAreasupervisors.Queries.QueryModAreasupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModAreasupervisorRequestValidator 
        : AbstractValidator<QueryModAreasupervisorRequest>
    {
        public QueryModAreasupervisorRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
