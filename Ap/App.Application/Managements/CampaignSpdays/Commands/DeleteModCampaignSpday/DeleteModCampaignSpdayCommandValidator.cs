#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CampaignSpdays.ModCampaignSpdays.Commands.DeleteModCampaignSpday
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModCampaignSpdayCommandValidator 
        : AbstractValidator<DeleteModCampaignSpdayCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModCampaignSpdayCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
