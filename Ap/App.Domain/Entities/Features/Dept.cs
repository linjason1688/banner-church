using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class Dept : EntityBase
    {

        /// <summary>
        ///  Id
        /// </summary>
        public long Id { get; set; }
        ///// <summary>
        /////  以前欄位Id
        ///// </summary>
        //public long DeptId { get; set; }
        /// <summary>
        ///  舊的Id
        /// </summary>
        public long UpperDeptId { get; set; }
       // /// <summary>
       // ///  舊欄位對應部門id Portal.Id        
       // /// </summary>
       // public long PortalId { get; set; }

        /// <summary>
        ///  部門名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  部門主管職稱
        /// </summary>
        public string Title { get; set; }

       

        public string StatusCd { get; set; }

    }
}
