#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMemberMinisters.Commands.DeleteVwMemberMinister
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwMemberMinisterCommandValidator 
        : AbstractValidator<DeleteVwMemberMinisterCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwMemberMinisterCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
