#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAreaSupervisors.Queries.QueryVwAreaSupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwAreaSupervisorRequestValidator 
        : AbstractValidator<QueryVwAreaSupervisorRequest>
    {
        public QueryVwAreaSupervisorRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
