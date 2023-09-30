#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Newses.ModNewses.Commands.CreateModNews
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModNewsCommandValidator 
        : AbstractValidator<CreateModNewsCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModNewsCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModNews, e => e.Name)
            //     );
        }
    }
}
