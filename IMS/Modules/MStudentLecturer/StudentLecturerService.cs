using IMS.Models;
using IMS.Modules.MUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Modules.MStudentLecturer
{
    public class StudentLecturerService : CommonService, IStudentLecturerService
    {
        public StudentLecturerService() : base()
        {
        }
        public long Count(UserEntity userEntity, SearchStudentLecturerEntity searchStudentLecturerEntity)
        {
            if (searchStudentLecturerEntity == null) searchStudentLecturerEntity = new SearchStudentLecturerEntity();
            IQueryable<StudentLecturer> studentLecturers = IMSContext.StudentLecturers;
            studentLecturers = searchStudentLecturerEntity.ApplyTo(studentLecturers);
            return studentLecturers.Count();
        }
        public List<StudentLecturerEntity> Get(UserEntity userEntity, SearchStudentLecturerEntity searchStudentLecturerEntity)
        { 
            if (searchStudentLecturerEntity == null) searchStudentLecturerEntity = new SearchStudentLecturerEntity();
            IQueryable<StudentLecturer> studentLecturers = IMSContext.StudentLecturers;
            studentLecturers = searchStudentLecturerEntity.ApplyTo(studentLecturers);
            studentLecturers = searchStudentLecturerEntity.SkipAndTake(studentLecturers);
            return studentLecturers.ToList().Select(sl => new StudentLecturerEntity(sl)).ToList();
        }
        public StudentLecturerEntity Get(UserEntity userEntity, Guid StudentId)
        {
            StudentLecturer studentLecturer = IMSContext.StudentLecturers.Where(sl => sl.StudentId == StudentId).FirstOrDefault();
            if (studentLecturer == null)
                throw new BadRequestException("StudentLecturer không tồn tại! ");
            return new StudentLecturerEntity(studentLecturer);
        }
        public StudentLecturerEntity Create(UserEntity userEntity, StudentLecturerEntity studentLecturerEntity)
        {
            StudentLecturer studentLecturer = studentLecturerEntity.ToModel();
            IMSContext.StudentLecturers.Add(studentLecturer);
            IMSContext.SaveChanges();
            return studentLecturerEntity;
        }
        public StudentLecturerEntity Update(UserEntity userEntity, Guid StudentId, StudentLecturerEntity studentLectureEntity)
        {
            StudentLecturer studentLecturer = IMSContext.StudentLecturers.Where(sl => sl.StudentId == StudentId).FirstOrDefault();
            studentLectureEntity.ToModel(studentLecturer);
            IMSContext.SaveChanges();
            return null;
        }
        public bool Delete(UserEntity userEntity, Guid StudentId)
        {
            StudentLecturer studentLecturer = IMSContext.StudentLecturers.Where(sl => sl.StudentId == StudentId).FirstOrDefault();
            if (studentLecturer == null)
                throw new BadRequestException("StudentLecturer không tồn tại!");
            IMSContext.Remove(studentLecturer);
            IMSContext.SaveChanges();
            return true;
        }
    }
}
