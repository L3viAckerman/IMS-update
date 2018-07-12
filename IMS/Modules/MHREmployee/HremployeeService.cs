using IMS.Modules.MUser;
using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IMS.Modules.MHrEmployee
{
    public class HrEmployeeService : CommonService, IHrEmployeeService
    {
        public HrEmployeeService() : base()
        {
        }
        public long Count(UserEntity UserEntity, SearchHrEmployeeEntity SearchHrEmployeeEntity)
        {
            if (SearchHrEmployeeEntity == null) SearchHrEmployeeEntity = new SearchHrEmployeeEntity();
            IQueryable<HrEmployee> HrEmployees = IMSContext.HrEmployees;
            HrEmployees = SearchHrEmployeeEntity.ApplyTo(HrEmployees);
            return HrEmployees.Count();
        }
        public List<HrEmployeeEntity> Get(UserEntity UserEntity, SearchHrEmployeeEntity SearchHrEmployeeEntity)
        {
            if (SearchHrEmployeeEntity == null) SearchHrEmployeeEntity = new SearchHrEmployeeEntity();
            IQueryable<HrEmployee> HrEmployees = IMSContext.HrEmployees.Include(l => l.IdNavigation);
            HrEmployees = SearchHrEmployeeEntity.ApplyTo(HrEmployees);
            HrEmployees = SearchHrEmployeeEntity.SkipAndTake(HrEmployees);
            return HrEmployees.ToList().Select(h => new HrEmployeeEntity(h)).ToList();
        }
        public HrEmployeeEntity Get(UserEntity UserEntity, Guid Id)
        {
            HrEmployee HrEmployee = IMSContext.HrEmployees.Where(h => h.Id == Id)
                .Include(l => l.IdNavigation).FirstOrDefault();
            if (HrEmployee == null)
            {
                throw new BadRequestException("Hremplopyee không tồn tại!");
            }
            return new HrEmployeeEntity(HrEmployee);
        }
        public HrEmployeeEntity Create(UserEntity UserEntity, HrEmployeeEntity HrEmployeeEntity)
        {
            HrEmployee HrEmployee = HrEmployeeEntity.ToModel();
            User user = new User();
            user.Id = HrEmployee.Id;
            user.Username = HrEmployeeEntity.Username;
            user.Password = "12345abcd";

            IMSContext.Users.Add(user);
            IMSContext.HrEmployees.Add(HrEmployee);
            IMSContext.SaveChanges();
            return Get(UserEntity, HrEmployee.Id);
        }
        public HrEmployeeEntity Update(UserEntity UserEntity, Guid Id, HrEmployeeEntity HrEmployeeEntity)
        {
            HrEmployee HrEmployee = IMSContext.HrEmployees.Where(h => h.Id == Id).FirstOrDefault();
            HrEmployeeEntity.ToModel(HrEmployee);
            IMSContext.SaveChanges();
            return HrEmployeeEntity;
        }
        public bool Delete(UserEntity UserEntity, Guid Id)
        {
            HrEmployee HrEmployee = IMSContext.HrEmployees.Where(h => h.Id == Id).FirstOrDefault();
            if (HrEmployee == null)
            {
                throw new BadRequestException("HrEmployee không tồn tại");
            }
            IMSContext.HrEmployees.Remove(HrEmployee);
            IMSContext.SaveChanges();
            return true;


        }
    }

}

