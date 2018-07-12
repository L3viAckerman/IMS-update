using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using IMS.Models;
using IMS.Modules.MInternFollow;
using IMS.Modules.MInternshipCourse;
using IMS.Modules.MLecturerFollow;
using IMS.Modules.MStudentLecturer;
using IMS.Modules.MUser;

namespace IMS.Modules.MStudent
{
    public class StudentEntity
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string Username { get; set; } 
        public string Code { get; set; }
        public string Class { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }
        public string Birthday { get; set; }
        public string Gpa { get; set; }
        public string Vnumail { get; set; }
        public string GraduationYear { get; set; }
        public string Avatar { get; set; }
        public string PersonalMail { get; set; }
        public string Skype { get; set; }
        public string Facebook { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public string Node { get; set; }
        public string LanguageSkill { get; set; }
        public string Certificate { get; set; }
        public string Experience { get; set; }
        public string Goal { get; set; }
        public string Note { get; set; }
        public UserEntity UserEntity { get; set; }
        public List<InternFollowEntity> InternFollowEntities { get; set; }
        public List<InternshipCourseEntity> InternshipCourseEntities { get; set; }
        public List<LecturerFollowEntity> LecturerFollowEntities { get; set; }
        public List<StudentLecturerEntity> StudentLecturerEntities { get; set; }
        //public long Cx { get; set; }
        public StudentEntity()
        {

        }
        public StudentEntity(Student student, params object[] args)
        {
            this.Id = student.Id;
            this.Username = student.IdNavigation.Username;
            this.UserId = student.Id;
            this.Code = student.Code;
            this.Class = student.Class;
            this.Department = student.Department;
            this.Address = student.Address;
            this.FullName = student.FullName;
            this.Birthday = student.Birthday;
            this.Vnumail = student.Vnumail;
            this.Gpa = student.Gpa;
            this.GraduationYear = student.GraduationYear;
            this.Avatar = student.Avatar;
            this.PersonalMail = student.PersonalMail;
            this.Skype = student.Skype;
            this.Facebook = student.Facebook;
            this.Position = student.Position;
            this.Phone = student.Phone;
            this.LanguageSkill = student.LanguageSkill;
            this.Certificate = student.Certificate;
            this.Experience = student.Experience;
            this.Goal = student.Goal;
            this.Note = student.Note;
            foreach (var arg in args)
            {
                if (arg is ICollection<InternFollow>)
                    this.InternFollowEntities = (arg as ICollection<InternFollow>).Select(itf => new InternFollowEntity(itf)).ToList();
                if (arg is ICollection<InternshipCourse>)
                    this.InternshipCourseEntities = (arg as ICollection<InternshipCourse>).Select(ic => new InternshipCourseEntity(ic)).ToList();
                if (arg is ICollection<StudentLecturer>)
                    this.StudentLecturerEntities = (arg as ICollection<StudentLecturer>).Select(sl => new StudentLecturerEntity(sl)).ToList();
                if (arg is ICollection<LecturerFollow>)
                    this.LecturerFollowEntities = (arg as ICollection<LecturerFollow>).Select(lf => new LecturerFollowEntity(lf)).ToList();
            }
            //this.Cx = student.Cx;
        }
        public Student ToModel(Student student = null)
        {
            if (student == null)
            {
                student = new Student();
                student.Id = Guid.NewGuid();
            }

            student.Code = this.Code;
            student.Class = this.Class;
            student.Department = this.Department;
            student.Address = this.Address;
            student.FullName = this.FullName;
            student.Birthday = this.Birthday;
            student.Vnumail = this.Vnumail;
            student.Gpa = this.Gpa;
            student.GraduationYear = this.GraduationYear;
            student.Avatar = this.Avatar;
            student.PersonalMail = this.PersonalMail;
            student.Skype = this.Skype;
            student.Facebook = this.Facebook;
            student.Phone = this.Phone;
            student.Position = this.Position;
            student.LanguageSkill = this.LanguageSkill;
            student.Certificate = this.Certificate;
            student.Experience = this.Experience;
            student.Goal = this.Goal;
            student.Note = this.Note;
            //student.Cx = this.Cx;
            return student;
        }

    }
}
