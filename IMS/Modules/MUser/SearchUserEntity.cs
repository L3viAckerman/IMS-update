using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MUser
{
    public class SearchUserEntity : FilterEntity
    {
        public string Username { get; set; }
        public IQueryable<User> ApplyTo(IQueryable<User> Users)
        {
            if (!string.IsNullOrEmpty(Username))
                Users = Users.Where(u => u.Username.ToLower().Equals(Username.ToLower()));
            return Users;
        }
    }
}
