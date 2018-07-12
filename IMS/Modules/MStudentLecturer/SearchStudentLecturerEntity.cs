using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MStudentLecturer
{
    public class SearchStudentLecturerEntity : FilterEntity
    {
        public Guid StudentId { get; set; }
        public Guid LecturerId { get; set; }
        public IQueryable<StudentLecturer> ApplyTo(IQueryable<StudentLecturer> studentLecturers)
        {
            if(StudentId != Guid.Empty)
            {
                studentLecturers = studentLecturers.Where(sl => sl.StudentId.Equals(StudentId));
            }
            return studentLecturers;
        }
    }
}
