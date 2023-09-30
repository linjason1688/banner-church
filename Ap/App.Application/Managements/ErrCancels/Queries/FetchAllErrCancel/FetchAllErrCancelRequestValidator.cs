#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ErrCancels.Queries.FetchAllErrCancel
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllErrCancelRequestValidator 
        : AbstractValidator<FetchAllErrCancelRequest>
    {
        public FetchAllErrCancelRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
