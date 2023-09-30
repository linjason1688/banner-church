using System;

namespace App.Domain.Entities.Features
{
    public partial class ModActivityWork
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public string MinisterRequired { get; set; }
        public int MaleWanted { get; set; }
        public int FemaleWanted { get; set; }
        public bool IsTeam { get; set; }
        public bool IsNeedRecruit { get; set; }
        public int? TargetMinisterId { get; set; }
        public string TargetRole { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}
