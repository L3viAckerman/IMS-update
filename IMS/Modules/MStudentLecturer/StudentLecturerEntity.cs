using IMS.Models;
using IMS.Modules.MUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MStudentLecturer
{
    public class StudentLecturerEntity
    {
        public Guid StudentId { get; set; }
        public Guid LecturerId { get; set; }
        public UserEntity userEntity { get; set; }
        public StudentLecturerEntity() { }
        public StudentLecturerEntity(StudentLecturer studentLecturer)
        {
            this.StudentId = studentLecturer.StudentId;
            this.LecturerId = studentLecturer.LecturerId;  
        }
        public StudentLecturer ToModel(StudentLecturer studentLecturer = null)
        {
            if(studentLecturer == null)
            {
                studentLecturer = new StudentLecturer();
            }
            studentLecturer.StudentId = this.StudentId;
            studentLecturer.LecturerId = this.LecturerId;
            return studentLecturer;
        }
    }
}
