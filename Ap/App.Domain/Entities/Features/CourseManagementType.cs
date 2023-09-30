using System;

namespace App.Domain.Entities.Features
{
    //#CreateAPI
    public partial class CourseManagementType: EntityBase
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }



        /// <summary>
        /// 課程類別編號
        /// </summary>
        public string CourseManagementTypeNo { get; set; }

        /// <summary>
        /// 課程類別名稱
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 備註
        /// </summary>
        public string Remark { get; set; }
        public string StatusCd { get; set; }

    }

}
