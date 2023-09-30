#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryResps.Commands.DeleteMinistryResp
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteMinistryRespCommandValidator 
        : AbstractValidator<DeleteMinistryRespCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteMinistryRespCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
