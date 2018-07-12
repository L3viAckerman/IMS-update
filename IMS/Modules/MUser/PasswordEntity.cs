using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MUser
{
    public class PasswordEntity
    {
        public string OldPassword { get; set; }
        public UserEntity UserEntity { get; set; }
    }
}
