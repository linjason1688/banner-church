#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Pastorals.Queries.FindPastoral
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryPastoralTreeRequestValidator 
        : AbstractValidator<QueryPastoralTreeRequest>
    {
        public QueryPastoralTreeRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
