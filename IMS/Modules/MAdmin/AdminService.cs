using IMS.Models;
using IMS.Modules.MUser;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Modules.MAdmin
{
    public class AdminService : CommonService, IAdminService
    {
        public AdminService() : base()
        {
        }
        public long Count(UserEntity userEntity, SearchAdminEntity searchAdminEntity)
        {
            if (searchAdminEntity == null) searchAdminEntity = new SearchAdminEntity();
            IQueryable<Admin> admins = IMSContext.Admins;
            admins = searchAdminEntity.ApplyTo(admins);
            return admins.Count();
        }
        public List<AdminEntity> Get(UserEntity userEntity, SearchAdminEntity searchAdminEntity)
        {
            if (searchAdminEntity == null) searchAdminEntity = new SearchAdminEntity();
            IQueryable<Admin> admins = IMSContext.Admins.Include(l => l.IdNavigation);
            admins = searchAdminEntity.ApplyTo(admins);
            admins = searchAdminEntity.SkipAndTake(admins);
            return admins.ToList().Select(a => new AdminEntity(a)).ToList();
        }
        public AdminEntity Get(UserEntity userEntity, Guid Id)
        {
            Admin admin = IMSContext.Admins.Where(a => a.Id == Id)
                .Include(l => l.IdNavigation).FirstOrDefault();
            if (admin == null)
            {
                throw new BadRequestException("Admin không tồn tại!");
            }
            return new AdminEntity(admin); 

        }
        public AdminEntity Create(UserEntity UserEntity, AdminEntity AdminEntity)
        {
            Admin Admin = AdminEntity.ToModel();
            User User = new User();
            User.Id = Admin.Id;
            User.Username = AdminEntity.Username;
            User.Password = "12345abcd";

            IMSContext.Users.Add(User);
            IMSContext.Admins.Add(Admin);
            IMSContext.SaveChanges();
            return Get(UserEntity, Admin.Id);
        }
        public AdminEntity Update(UserEntity UserEntity, Guid Id, AdminEntity AdminEntity)
        {
            Admin Admin = IMSContext.Admins.Where(a => a.Id == Id).FirstOrDefault();
            User User = IMSContext.Users.Where(u => u.Id == Id).FirstOrDefault();
            User.Username = AdminEntity.Username;
            AdminEntity.ToModel(Admin);
            IMSContext.SaveChanges();
            return Get(UserEntity, Admin.Id);
        }
        public bool Delete(UserEntity userEntity, Guid Id)
        {
            Admin admin = IMSContext.Admins.Where(a => a.Id == Id).FirstOrDefault();
            if (admin == null)
            {
                throw new BadRequestException("Admin không tồn tại!");
            }
            IMSContext.Remove(admin);
            IMSContext.SaveChanges();
            return true;
        }
    }
}
