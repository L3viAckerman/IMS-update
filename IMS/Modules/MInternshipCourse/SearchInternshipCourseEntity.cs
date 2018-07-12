using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MInternshipCourse
{
    public class SearchInternshipCourseEntity : FilterEntity
    {
        public Guid StudentId { get; set; }
        public string StudentName { get; set; }
        public string CompanyName { get; set; }
        public SearchInternshipCourseEntity(Guid Id)
        {
            this.StudentId = Id;
        }

        public SearchInternshipCourseEntity()
        {
        }

        public IQueryable<InternshipCourse> ApplyTo(IQueryable<InternshipCourse> InternshipCourses)
        {
            if (StudentId != Guid.Empty)
                InternshipCourses = InternshipCourses.Where(m => m.StudentId.Equals(StudentId));
            if (!string.IsNullOrEmpty(StudentName))
                InternshipCourses = InternshipCourses.Where(m => m.Student.FullName.ToLower().Contains(StudentName.ToLower()));
            if (!string.IsNullOrEmpty(CompanyName))
                InternshipCourses = InternshipCourses.Where(m => m.Company.Name.ToLower().Contains(CompanyName.ToLower()));
            return InternshipCourses;
        }
    }
}
