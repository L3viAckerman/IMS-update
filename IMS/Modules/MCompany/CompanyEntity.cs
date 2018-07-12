using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS.Modules.MCompany;

namespace IMS.Modules.MCompany
{
   public class CompanyEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        
        public CompanyEntity() { }
        // get db to entity 
        public CompanyEntity(Company Company)
        {
            this.Id = Company.Id;
            this.Name = Company.Name;
            this.Address = Company.Address;

        }
        // move from entity to model 
        public Company ToModel(Company Company = null)
        {
            if(Company == null)
            {
                Company = new Company();
                Company.Id = Guid.NewGuid();
            }
            Company.Address = this.Address;
            //Company.Id = this.Id;
            Company.Name = this.Name;
            return Company;
        }
    }
}
