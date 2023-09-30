


using System;
using App.Domain.Entities;

namespace App.Application.Managements.Ministers.ModMinisters.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class ModMinisterBase: EntityBase
    {

        public long Id { get; set; }

        public string MinistryNo { get; set; }
        public string Name { get; set; }
        public string MinistryDefStatus { get; set; }
        public string StatusCd { get; set; }


        public string Comment { get; set; }
     

        public int IsActivated { get; set; }

    }
}

