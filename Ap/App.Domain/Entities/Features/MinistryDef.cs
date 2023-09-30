using System;

namespace App.Domain.Entities.Features
{
    //#CreateAPI
    public partial class MinistryDef: EntityBase
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }



        /// <summary>
        /// 事工團編號
        /// </summary>
        public string MinistryDefNo { get; set; }


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
        public string MinistryDefStatus { get; set; }





        /// <summary>
        /// 事工團類別  MinistryDefType 0一般事工團   1小組  
        /// </summary>
        public string MinistryDefType { get; set; }

        /// <summary>
        /// id
        /// </summary>
        public string StatusCd { get; set; }


        public string Comment { get; set; }

    }
}
