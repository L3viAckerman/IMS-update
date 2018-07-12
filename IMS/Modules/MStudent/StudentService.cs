using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS.Models;
using Microsoft.EntityFrameworkCore;
using IMS.Modules;
using IMS.Modules.MUser;
using IMS.Modules.MInternFollow;
using IMS.Modules.MInternshipCourse;

namespace IMS.Modules.MStudent
{
    public class StudentService : CommonService, IStudentService

    {
        public StudentService() : base()
        {

        }
        public List<StudentEntity> Get(UserEntity UserEntity, SearchStudentEntity SearchStudentEntity)
        {
            if (SearchStudentEntity == null) SearchStudentEntity = new SearchStudentEntity();
            IQueryable<Student> Students = IMSContext.Students
                .Include(l => l.IdNavigation)
                .Include(s => s.InternshipCourses)
                .Include(s => s.LecturerFollows)
                .Include(s => s.InternFollows)
                .Include(s => s.StudentLecturers);
            Students = SearchStudentEntity.ApplyTo(Students);
            Students = SearchStudentEntity.SkipAndTake(Students);
            return Students.ToList().Select(u => new StudentEntity(u, u.LecturerFollows, u.InternFollows, u.InternshipCourses)).ToList();
        }
        public long Count(UserEntity UserEntity, SearchStudentEntity SearchStudentEntity)
        {
            if (SearchStudentEntity == null) SearchStudentEntity = new SearchStudentEntity();
            IQueryable<Student> Students = IMSContext.Students;
            Students = SearchStudentEntity.ApplyTo(Students);
            return Students.Count();
        }
        public StudentEntity Get(UserEntity UserEntity, Guid studentId)
        {
            Student student = IMSContext.Students.Where(s => s.Id == studentId)
                .Include(l => l.IdNavigation)
                .Include(s => s.LecturerFollows)
                .Include(s => s.InternshipCourses)
                .Include(s => s.InternFollows)
                .Include(s => s.StudentLecturers)
                .FirstOrDefault();
            if (student == null)
            {
                throw new BadRequestException("User not found");
            }
            return new StudentEntity(student, student.LecturerFollows, student.InternFollows, student.InternshipCourses);
        }
        public List<InternshipCourseEntity> GetInternshipCourses(UserEntity UserEntity, Guid StudentId)
        {
            List<InternshipCourse> InternshipCourse = IMSContext.InternshipCourses.Where(inc => inc.StudentId == StudentId).ToList();
            if (InternshipCourse == null)
                throw new BadRequestException("InternshipCourse không tồn tại");
            return InternshipCourse.Select(u => new InternshipCourseEntity(u)).ToList();
        }
        public StudentEntity Update(UserEntity UserEntity, Guid StudentId, StudentEntity StudentEntity)
        {

            Student student = IMSContext.Students.Where(s => s.Id == StudentId).FirstOrDefault();
            if (student == null)
            { 
                throw new BadRequestException("User not found");
            }
            StudentEntity.ToModel(student);
            IMSContext.SaveChanges();
            return new StudentEntity(student);
        }
        public StudentEntity Create(UserEntity UserEntity, StudentEntity StudentEntity)
        {
            Student student = StudentEntity.ToModel();
            User User = new User();
            User.Id = student.Id;
            User.Username = StudentEntity.Username;
            User.Password = "12345abcd";

            IMSContext.Users.Add(User);
            IMSContext.Students.Add(student);
            IMSContext.SaveChanges();
            // return new StudentEntity(IMSContext.Students.Where(s => s.Id == student.Id).FirstOrDefault());
            return Get(UserEntity, student.Id);
        }

        public bool Delete(UserEntity UserEntity, Guid studentId)
        {
            Student student = IMSContext.Students.Where(s => s.Id == studentId).FirstOrDefault();
            if (student == null) return false;
            IMSContext.Students.Remove(student);
            IMSContext.SaveChanges();
            return true;
        }
    }
}
