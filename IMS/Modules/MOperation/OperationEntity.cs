using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS.Modules.MUser;
namespace IMS.Modules.MOperation
{
    public class OperationEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Method { get; set; }
        public List<string> Role { get; set; }
        public OperationEntity() { }

        public OperationEntity(Operation Operation )
        {
            this.Id = Operation.Id;
            this.Name = Operation.Name;
            this.Link = Operation.Link;
            this.Method = Operation.Method;
            this.Role = Operation.Role.ToString().Replace(" ","").Split(",").ToList() ;
        }

        public Operation ToModel(Operation Operation = null)
        {
            if (Operation == null)
            {
                Operation = new Operation();
                Operation.Id = Guid.NewGuid();
            }
            Operation.Name = this.Name;
            Operation.Link = this.Link;
            Operation.Method = this.Method;
            string role = string.Join(",", this.Role);
            Operation.Role = (ROLES)Enum.Parse(typeof(ROLES), role);
            
            return Operation;
        }
    }
}
