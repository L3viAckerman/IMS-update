using IMS.Models;
using IMS.Modules.MCompany;
using IMS.Modules.MInternReport;
using IMS.Modules.MStudent;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MInternshipCourse
{
    public class InternshipCourseEntity
    {
        public Guid Id { get; set; }
        public Guid? StudentId { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? LecturerId { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string File { get; set; }
        public string LecturerComment { get; set; }
        public string CompanyComment { get; set; } 
        public CompanyEntity CompanyEntity { get; set; }
        public StudentEntity StudentEntity { get; set; }
        public int? FinalScore { get; set; }
        public List<InternReportEntity> InternReportEntities { get; set; }
        public InternshipCourseEntity() { }
        public InternshipCourseEntity(InternshipCourse internshipCourse, params object[] args)
        {
            this.Id = internshipCourse.Id;
            this.StudentId = internshipCourse.StudentId;
            this.CompanyId = internshipCourse.CompanyId;
            this.LecturerId = internshipCourse.LecturerId;
            //this.Start = internshipCourse.Start;
            //this.End = internshipCourse.End;
            this.File = internshipCourse.File;
            this.LecturerComment = internshipCourse.LecturerComment;
            this.CompanyComment = internshipCourse.CompanyComment;
            this.FinalScore = internshipCourse.FinalScore;
            foreach (var arg in args)
            {
                if (arg is ICollection<InternReport>)
                    this.InternReportEntities = (arg as ICollection<InternReport>).Select(ir => new InternReportEntity(ir)).ToList();
                if (arg is Company)
                    this.CompanyEntity = internshipCourse.Company == null ? null : new CompanyEntity(arg as Company);
                if (arg is Student)
                    this.StudentEntity = internshipCourse.Student == null ? null : new StudentEntity(arg as Student);
            }
        }
        public InternshipCourse ToModel(InternshipCourse internshipCourse = null)
        {
            if(internshipCourse == null)
            {
                internshipCourse = new InternshipCourse();
                internshipCourse.Id = Guid.NewGuid();
                //internshipCourse.Start = (DateTime)new SqlDateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                //                    DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            }
            internshipCourse.StudentId = this.StudentId;
            internshipCourse.CompanyId = this.CompanyId;
            internshipCourse.LecturerId = this.LecturerId;
            internshipCourse.FinalScore = this.FinalScore;
            //internshipCourse.End = this.End;
            internshipCourse.File = this.File;
            internshipCourse.LecturerComment = this.LecturerComment;
            internshipCourse.CompanyComment = this.CompanyComment;
            return internshipCourse;
        }
    }
}
