using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MOperation
{
    public class SearchOperationEntity : FilterEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Method { get; set; }
        public string Role { get; set; }
        public IQueryable<Operation> ApplyTo(IQueryable<Operation> Operations)
        {
            if (!string.IsNullOrEmpty(Name))
                Operations = Operations.Where(u => u.Name.ToLower().Equals(Name.ToLower()));
            return Operations;
        }
    }
}
