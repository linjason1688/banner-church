#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Newses.ModNewses.Commands.UpdateModNews
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModNewsCommandValidator 
        : AbstractValidator<UpdateModNewsCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModNewsCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModNews, e => e.Name)
            //     );
        }
    }
}
