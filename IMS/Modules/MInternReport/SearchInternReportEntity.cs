using System;
using IMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MInternReport
{
    public class SearchInternReportEntity : FilterEntity
    {
        public Guid? CourseId { get; set; }
        public Guid? LecturerId { get; set; }
        //public SearchInternReportEntity(Guid courseId)
        //{
        //    this.courseId = courseId;
        //}
        public IQueryable<InternReport> ApplyTo(IQueryable<InternReport> internReports)
        {
            if (CourseId.HasValue)
                internReports = internReports.Where(ir => ir.InternshipCourseId.HasValue && ir.InternshipCourseId.Value == CourseId.Value);
            if (LecturerId.HasValue)
                internReports = internReports.Where(ir => ir.InternshipCourse!= null &&
                ir.InternshipCourse.LecturerId.HasValue && ir.InternshipCourse.LecturerId.Value == LecturerId.Value);

            return internReports;
        }
    }
}
