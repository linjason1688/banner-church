#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.UserContacts.Commands.CreateUserContact
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateUserContactCommandValidator 
        : AbstractValidator<CreateUserContactCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateUserContactCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.UserContact, e => e.Name)
            //     );
        }
    }
}
