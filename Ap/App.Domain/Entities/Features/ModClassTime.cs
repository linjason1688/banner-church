using System;

namespace App.Domain.Entities.Features
{
    public partial class ModClassTime
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int LessionTimeId { get; set; }
        public string ClassCode { get; set; }
        public int DayofWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string TeacherName { get; set; }
        public string Place { get; set; }
        public int Capacity { get; set; }
        public DateTime? SignUpDueDate { get; set; }
        public DateTime? DiscountDueDate { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}
