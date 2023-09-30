#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Ministries.Commands.CreateMinistry
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateMinistryCommandValidator 
        : AbstractValidator<CreateMinistryCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateMinistryCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.Ministry, e => e.Name)
            //     );
        }
    }
}
