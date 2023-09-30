#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Pastorals.Queries.QueryPastoral
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryPastoralRequestValidator 
        : AbstractValidator<QueryPastoralRequest>
    {
        public QueryPastoralRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
