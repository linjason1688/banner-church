#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ErrCancels.Commands.DeleteErrCancel
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteErrCancelCommandValidator 
        : AbstractValidator<DeleteErrCancelCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteErrCancelCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
