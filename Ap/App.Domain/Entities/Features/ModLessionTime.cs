using System;

namespace App.Domain.Entities.Features
{
    public partial class ModLessionTime
    {
        public int Id { get; set; }
        public int LessionId { get; set; }
        public string ClassCode { get; set; }
        public int DayofWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string TeacherName { get; set; }
        public string Place { get; set; }
        public string StatusCd { get; set; }
    }
}
