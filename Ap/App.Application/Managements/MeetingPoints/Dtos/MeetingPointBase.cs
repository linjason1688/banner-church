


using System;

namespace App.Application.Managements.MeetingPoints.Dtos
{
    //#CreateAPI
    /// <summary>
    /// 
    /// </summary>
    public class MeetingPointBase
    {

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

      

        /// <summary>
        /// 聚會點名稱
        /// </summary>
        public string Name { get; set; }

      

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

