using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MHrEmployee
{
    public class SearchHrEmployeeEntity : FilterEntity
    {
        public Guid Id { get; set; }
        public IQueryable<HrEmployee> ApplyTo(IQueryable<HrEmployee> HrEmployees)
        {
            if (Id != Guid.Empty)
                HrEmployees = HrEmployees.Where(h => h.Id.Equals(Id));
            return HrEmployees;
        }
    }
}
