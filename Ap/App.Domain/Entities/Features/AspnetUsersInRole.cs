using System;

namespace App.Domain.Entities.Features
{
    public partial class AspnetUsersInRole
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
