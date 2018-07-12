using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MAdmin
{
    public class SearchAdminEntity : FilterEntity
    {
        public string Vnumail { get; set; }
        public IQueryable<Admin> ApplyTo(IQueryable<Admin> admins)
        {
            if(!string.IsNullOrEmpty(Vnumail))
            {
                admins = admins.Where(a => a.Vnumail.ToLower().Equals(Vnumail.ToLower()));
            }
            return admins;
        }
    }
}
