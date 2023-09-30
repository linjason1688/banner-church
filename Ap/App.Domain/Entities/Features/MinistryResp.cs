using System;
using System.Xml.Linq;

namespace App.Domain.Entities.Features
{
    //#CreateAPI
    public partial class MinistryResp: EntityBase
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 事工團.Id
        /// </summary>
        public long MinistryId { get; set; }
       
        /// <summary>
        /// 順序
        /// </summary>
        public int Seq { get; set; }

        /// <summary>
        /// 事工團職份名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否管理職是否管理職        對應type=IsYN        顯示 name        value存此欄位 0：N 1：Y
        /// </summary>
        public string ManageType { get; set; }

        /// <summary>
        /// id
        /// </summary>
        public string StatusCd { get; set; }


        public string Comment { get; set; }

        //public string IsActivated { get; set; }
    }
}
