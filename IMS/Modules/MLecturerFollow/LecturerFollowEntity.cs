using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS.Modules.MUser;
using System.ComponentModel.DataAnnotations;
using IMS.Modules.MLecturer;
using IMS.Modules.MStudent;

namespace IMS.Modules.MLecturerFollow
{
    public class LecturerFollowEntity
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid LecturerId { get; set; }
        public int Status { get; set; }
        //[DataType(DataType.Date)]
        public string Start { get; set; }
        //[DataType(DataType.Date)]
        public string End { get; set; }

        public LecturerEntity LecturerEntity { get; set; }
        public StudentEntity StudentEntity { get; set; }

        public LecturerFollowEntity() { }

        public LecturerFollowEntity(LecturerFollow LecturerFollow)
        {
            this.Id = LecturerFollow.Id;
            this.StudentId = LecturerFollow.StudentId;
            this.LecturerId = LecturerFollow.LecturerId;
            this.Status = LecturerFollow.Status;
            this.LecturerEntity = LecturerFollow.Lecturer == null ? null : new LecturerEntity(LecturerFollow.Lecturer);
            this.StudentEntity = LecturerFollow.Student == null ? null : new StudentEntity(LecturerFollow.Student);
            //this.Start = LecturerFollow.Start;
            //this.End = LecturerFollow.End;
        }

        public LecturerFollow ToModel(LecturerFollow LecturerFollow = null)
        {
            if (LecturerFollow == null)
            {
                LecturerFollow = new LecturerFollow();
                LecturerFollow.Id = Guid.NewGuid();
            }
            LecturerFollow.StudentId = this.StudentId;
            LecturerFollow.LecturerId = this.LecturerId;
            LecturerFollow.Status = this.Status;
            //LecturerFollow.Start = this.Start;
            //LecturerFollow.End = this.End;

            return LecturerFollow;
        }
    }
}
