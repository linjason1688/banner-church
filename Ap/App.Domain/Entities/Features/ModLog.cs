using System;

namespace App.Domain.Entities.Features
{
    public partial class ModLog
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Content { get; set; }
        public int TypeId { get; set; }
        public DateTime Date { get; set; }
    }
}
