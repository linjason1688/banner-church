using System;
using System.Collections.Generic;
using App.Application.Managements.Organizations.Dtos;
using App.Application.Managements.Pastorals.Dtos;
using App.Domain.Entities;

namespace App.Application.Managements.Questionnaires.Dtos
{
    /// <summary>
    /// Questionnaire 
    /// </summary>
    public class QuestionnaireView : QuestionnaireBase, IEntityBase
    {
        /// <inheritdoc />
        public Guid? HandledId { get; set; }

        /// <inheritdoc />
        public DateTime DateCreate { get; set; }

        /// <inheritdoc />
        public string UserCreate { get; set; }

        /// <inheritdoc />
        public DateTime? DateUpdate { get; set; }

        /// <inheritdoc />
        public string UserUpdate { get; set; }

        public QuestionnaireView()
        {
            this.OrganizationViews = new List<OrganizationView>();
            this.PastoralViews = new List<PastoralView>();
        }
    }
}
