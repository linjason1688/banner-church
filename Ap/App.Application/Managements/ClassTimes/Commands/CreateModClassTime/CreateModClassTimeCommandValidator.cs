#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.ClassTimes.ModClassTimes.Commands.CreateModClassTime
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModClassTimeCommandValidator 
        : AbstractValidator<CreateModClassTimeCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModClassTimeCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModClassTime, e => e.Name)
            //     );
        }
    }
}
