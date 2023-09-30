#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserPastoralCares.Commands.DeleteUserPastoralCare
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteUserPastoralCareCommandValidator 
        : AbstractValidator<DeleteUserPastoralCareCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteUserPastoralCareCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
