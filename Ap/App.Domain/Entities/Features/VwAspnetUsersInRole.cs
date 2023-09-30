using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class VwAspnetUsersInRole
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
