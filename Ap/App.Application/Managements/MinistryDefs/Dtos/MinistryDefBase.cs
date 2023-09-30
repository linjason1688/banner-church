


using System;

namespace App.Application.Managements.MinistryDefs.Dtos
{
    //#CreateAPI
    /// <summary>
    /// 
    /// </summary>
    public class MinistryDefBase
    {

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 事工團分類代碼
        /// </summary>
        public string MinistryDefNo { get; set; }

        /// <summary>
        /// 事工團分類名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 事工團類別狀態
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
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }

        public int IsActivated { get; set; }

    }
}

