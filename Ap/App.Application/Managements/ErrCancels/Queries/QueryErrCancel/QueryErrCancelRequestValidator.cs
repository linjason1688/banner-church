#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ErrCancels.Queries.QueryErrCancel
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryErrCancelRequestValidator 
        : AbstractValidator<QueryErrCancelRequest>
    {
        public QueryErrCancelRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
