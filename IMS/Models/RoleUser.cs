using System;
using System.Collections.Generic;

namespace IMS.Models
{
    public partial class RoleUser
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public Role Role { get; set; }
        public User User { get; set; }
    }
}
