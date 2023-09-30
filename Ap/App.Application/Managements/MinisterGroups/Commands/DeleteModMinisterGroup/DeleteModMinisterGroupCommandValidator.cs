#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinisterGroups.ModMinisterGroups.Commands.DeleteModMinisterGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModMinisterGroupCommandValidator 
        : AbstractValidator<DeleteModMinisterGroupCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModMinisterGroupCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
