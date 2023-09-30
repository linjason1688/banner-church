using System;

namespace App.Domain.Entities.Features
{
    //#CreateAPI
    public partial class Ministry: EntityBase
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 事工團分類id
        /// </summary>
        public long MinistryDefId { get; set; }

        /// <summary>
        /// 事工團編號
        /// </summary>
        public string MinistryNo { get; set; }


        /// <summary>
        /// 事工團名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否兒童事工團
        /// </summary>
        public string ChildMinistry { get; set; }

        /// <summary>
        /// 事工團狀態
        /// </summary>
        public string MinistryStatus { get; set; }

        /// <summary>
        /// 性質
        /// </summary>
        public string Nature { get; set; }


        /// <summary>
        /// id
        /// </summary>
        public string StatusCd { get; set; }


        public string Comment { get; set; }

        //public string IsActivated { get; set; }
    }
}
