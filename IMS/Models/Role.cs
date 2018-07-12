using System;
using System.Collections.Generic;

namespace IMS.Models
{
    public partial class Role
    {
        public Role()
        {
            RoleOperations = new HashSet<RoleOperation>();
            RoleUsers = new HashSet<RoleUser>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<RoleOperation> RoleOperations { get; set; }
        public ICollection<RoleUser> RoleUsers { get; set; }
    }
}
