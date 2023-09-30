#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwZoneSupervisors.Queries.QueryVwZoneSupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwZoneSupervisorRequestValidator 
        : AbstractValidator<QueryVwZoneSupervisorRequest>
    {
        public QueryVwZoneSupervisorRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
