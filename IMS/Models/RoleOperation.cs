using System;
using System.Collections.Generic;

namespace IMS.Models
{
    public partial class RoleOperation
    {
        public Guid RoleId { get; set; }
        public Guid OperationId { get; set; }

        public Operation Operation { get; set; }
        public Role Role { get; set; }
    }
}
