using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class SysSetting
    {
        public string SettingName { get; set; }
        public string Value { get; set; }
        public bool IsSensitive { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}
