using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Features.FindMinistryRecord
{
    public class MinistryRecordView : EntityBase
    {

        /// <summary>
        /// 事工團分類
        /// </summary>
        public string MinistryDefName { get; set; }


        /// <summary>
        /// 事工團名稱
        /// </summary>
        public string MinistryName { get; set; }

        /// <summary>
        /// 事工團職分名稱
        /// </summary>
        public string MinistryRespName { get; set; }

        /// <summary>
        /// 出席狀態
        /// </summary>
        public int MeetAttendanceType { get; set; }

        /// <summary>
        /// 事工團異動記錄
        /// </summary>
        public int MinistryRespUserStatus { get; set; }

        /// <summary>
        /// 出席日期
        /// </summary>
        public DateTime MeetingDay { get; set; }


    }
}
