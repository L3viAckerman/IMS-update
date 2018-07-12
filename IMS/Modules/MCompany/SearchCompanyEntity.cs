using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MCompany
{
    public class SearchCompanyEntity : FilterEntity
    {
        public string Name { get; set; }
        public IQueryable<Company> ApplyTo(IQueryable<Company> Companies)
        {
            if (!string.IsNullOrEmpty(Name))
                Companies = Companies.Where(c => c.Name.ToLower().Equals(Name.ToLower()));
            return Companies;
        }
    }
}
