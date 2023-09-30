#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Ministers.ModMinisters.Queries.QueryModMinister
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModMinisterRequestValidator 
        : AbstractValidator<QueryModMinisterRequest>
    {
        public QueryModMinisterRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
