using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS.Modules.MUser;

namespace IMS.Modules.MAdmin
{
    public class AdminEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Organization { get; set; }
        public string Vnumail { get; set; }
        public string Gmail { get; set; }
        public string Phone { get; set; }
        public long Cx { get; set; }
        public AdminEntity() { }
        public AdminEntity(Admin admin)
        {
            this.Id = admin.Id;
            this.Username = admin.IdNavigation.Username;
            this.Fullname = admin.Fullname;
            this.Organization = admin.Organization;
            this.Vnumail = admin.Vnumail;
            this.Phone = admin.Phone;
            this.Gmail = admin.Gmail;
            this.Cx = admin.Cx;
        }

        public Admin ToModel(Admin admin = null)
        {
            if(admin == null)
            {
                admin = new Admin();
                admin.Id = this.Id;
            }
            admin.Fullname = this.Fullname;
            admin.Organization = this.Organization;
            admin.Vnumail = this.Vnumail;
            admin.Phone = this.Phone;
            admin.Gmail = this.Gmail;
            //admin.Cx = this.Cx;
            return admin;
        }
    }
}
