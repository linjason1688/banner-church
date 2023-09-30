#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetUsersinroles.Commands.DeleteAspnetUsersinrole
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteAspnetUsersinroleCommandValidator 
        : AbstractValidator<DeleteAspnetUsersinroleCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteAspnetUsersinroleCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
