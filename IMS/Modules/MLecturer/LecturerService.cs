using IMS.Models;
using IMS.Modules.MStudent;
using IMS.Modules.MUser;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Modules.MLecturer
{
    public class LecturerService : CommonService, ILecturerService
    {
        public LecturerService():base(){}
        // Đếm số lượng Lecturer
        public long Count(UserEntity UserEntity, SearchLecturerEntity SearchLecturerEntity)
        {
            if (SearchLecturerEntity == null) SearchLecturerEntity = new SearchLecturerEntity();
            IQueryable<Lecturer> Lecturers = IMSContext.Lecturers;
            Lecturers = SearchLecturerEntity.ApplyTo(Lecturers);
            return Lecturers.Count();
        }
        // Lấy các Lecturer theo điều kiện search 
        public List<LecturerEntity> Get(UserEntity UserEntity, SearchLecturerEntity SearchLecturerEntity)
        {
            if (SearchLecturerEntity == null) SearchLecturerEntity = new SearchLecturerEntity();
            IQueryable<Lecturer> Lecturers = IMSContext.Lecturers.Include(l => l.IdNavigation);
            Lecturers = SearchLecturerEntity.ApplyTo(Lecturers);
            Lecturers = SearchLecturerEntity.SkipAndTake(Lecturers);
            return Lecturers.ToList().Select(u => new LecturerEntity(u)).ToList();
        }
        // Lấy Lecturer theo id 
        public LecturerEntity Get(UserEntity UserEntity, Guid LecturerId)
        {
            Lecturer Lecturer = IMSContext.Lecturers.Where(u => u.Id == LecturerId)
                .Include(l => l.IdNavigation).FirstOrDefault();
            if (Lecturer == null)
                throw new BadRequestException("Lecturer không tồn tại");
            return new LecturerEntity(Lecturer);
        }
        // Tạo mới Lecturer
        public LecturerEntity Create(UserEntity UserEntity, LecturerEntity LecturerEntity)
        {
            Lecturer Lecturer = LecturerEntity.ToModel();
            User User = new User();
            User.Id = Lecturer.Id;
            User.Username = LecturerEntity.Username;
            User.Password = "12345abcd";
           
            IMSContext.Users.Add(User);
            IMSContext.Lecturers.Add(Lecturer);
            IMSContext.SaveChanges();
            return Get(UserEntity, Lecturer.Id);
        }
        // Cập nhật Lecturer theo id
        public LecturerEntity Update(UserEntity UserEntity, Guid LecturerId, LecturerEntity LecturerEntity)
        {
            Lecturer Lecturer = IMSContext.Lecturers.Where(l => l.Id == LecturerId).FirstOrDefault();
            LecturerEntity.ToModel(Lecturer);
            IMSContext.SaveChanges();
            return LecturerEntity;
        }
        // Xóa Lecturer theo id
        public bool Delete(UserEntity UserEntity, Guid LecturerId)
        {
            Lecturer Lecturer = IMSContext.Lecturers.Where(l => l.Id == LecturerId).FirstOrDefault();
            if (Lecturer == null)
                throw new BadRequestException("Lecturer không tồn tại.");
            IMSContext.Lecturers.Remove(Lecturer);
            IMSContext.SaveChanges();
            return true;
        }
      
    }
}
