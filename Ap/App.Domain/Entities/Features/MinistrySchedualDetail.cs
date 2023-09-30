using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace App.Domain.Entities.Features
{
    //#CreateAPI
    public partial class MinistryScheduleDetail: EntityBase
    {
       

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 事工團排程代碼
        /// </summary>
        public long MinistryScheduleId { get; set; }

        /// <summary>
        /// 堂表名稱 例如：第一堂
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述  例如 09:00~10:00
        /// </summary>
        public string Description { get; set; }

        public string StatusCd { get; set; }

        #region FKS




        #endregion
    }
}
