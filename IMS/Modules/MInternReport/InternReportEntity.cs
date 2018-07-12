using System;
using IMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS.Modules.MInternshipCourse;

namespace IMS.Modules.MInternReport
{
    public class InternReportEntity
    {
        public Guid Id { get; set; }
        public Guid? InternshipCourseId { get; set; }
        public string Content { get; set; }
        public double PartnerScore { get; set; }
        public double LecturerScore { get; set; }
        public DateTime Date { get; set; }
        public Guid CompanyId { get; set; }
        public string LecturerComment { get; set; }
        public string CompanyComment { get; set; }
        public long Cx { get; set; }

        public InternshipCourseEntity InternshipCourseEntity { get; set; }

        public InternReportEntity() { }
        public InternReportEntity (InternReport internReport)
        {
            this.Id = internReport.Id;
            this.InternshipCourseId = internReport.InternshipCourseId;
            this.Content = internReport.Content;
            this.PartnerScore = internReport.PartnerScore;
            this.LecturerScore = internReport.LecturerScore;
            this.Date = internReport.Date;
            this.LecturerComment = internReport.LecturerComment;
            this.CompanyComment = internReport.CompanyComment;
            this.Cx = internReport.Cx;
            this.InternshipCourseEntity = internReport.InternshipCourse == null ? null : new InternshipCourseEntity(internReport.InternshipCourse);
        }
        public InternReport ToModel(InternReport internReport = null)
        {
            if(internReport == null)
            {
                internReport = new InternReport();
                internReport.Id = Guid.NewGuid();
            }
            internReport.InternshipCourseId = this.InternshipCourseId;
            internReport.Content = this.Content;
            internReport.PartnerScore = this.PartnerScore;
            internReport.LecturerScore = this.LecturerScore;
            internReport.Date = DateTime.Now;
            internReport.LecturerComment = this.LecturerComment;
            internReport.CompanyComment = this.CompanyComment;
            internReport.Cx = this.Cx;
            return internReport;
        }
    }
}
