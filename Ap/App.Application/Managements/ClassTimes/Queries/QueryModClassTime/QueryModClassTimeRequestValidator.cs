#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ClassTimes.ModClassTimes.Queries.QueryModClassTime
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModClassTimeRequestValidator 
        : AbstractValidator<QueryModClassTimeRequest>
    {
        public QueryModClassTimeRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
