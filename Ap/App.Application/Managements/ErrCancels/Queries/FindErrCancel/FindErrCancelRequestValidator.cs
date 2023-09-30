#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ErrCancels.Queries.FindErrCancel
{
    /// <summary>
    /// 
    /// </summary>
    public class FindErrCancelRequestValidator 
        : AbstractValidator<FindErrCancelRequest>
    {
        public FindErrCancelRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
