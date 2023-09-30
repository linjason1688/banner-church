#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.LessionTimes.ModLessionTimes.Commands.CreateModLessionTime
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModLessionTimeCommandValidator 
        : AbstractValidator<CreateModLessionTimeCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModLessionTimeCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModLessionTime, e => e.Name)
            //     );
        }
    }
}
