using System;

namespace App.Domain.Entities.Features
{
    public partial class ModMeeting
    {
        public int GroupId { get; set; }
        public DateTime Date { get; set; }
        public string GroupName { get; set; }
        public int GroupTypeId { get; set; }
        public int OrgId { get; set; }
        public int DepId { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public string MeetingTime { get; set; }
        public int NoneGroupAttend { get; set; }
        public int NewCommerAttend { get; set; }
        public int ChildAttend { get; set; }
        public int WorshipNoneGroupAttend { get; set; }
        public string AttendComment { get; set; }
        public string AreaComment { get; set; }
        public string ZoneComment { get; set; }
        public string GroupComment { get; set; }
        public string WorshipComment { get; set; }
        public int ExpNo { get; set; }
        public int? WeekOfExp { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}
