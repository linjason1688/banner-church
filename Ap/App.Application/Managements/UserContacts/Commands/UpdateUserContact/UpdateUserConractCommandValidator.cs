#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserContacts.Commands.UpdateUserContact
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateUserContactCommandValidator 
        : AbstractValidator<UpdateUserContactCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateUserContactCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.UserContact, e => e.Name)
            //     );
        }
    }
}
