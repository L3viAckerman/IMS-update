using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MLecturerFollow
{
    public class SearchLecturerFollowEntity : FilterEntity
    {
        public string Studentname { get; set; }
        public string MSSV { get; set; }
        public int? Status { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public IQueryable<LecturerFollow> ApplyTo(IQueryable<LecturerFollow> LecturerFollows)
        {
            if (!string.IsNullOrEmpty(Studentname))
                LecturerFollows = LecturerFollows.Where(u => u.Student.FullName.ToLower().Equals(Studentname.ToLower()));
            if (!string.IsNullOrEmpty(MSSV))
                LecturerFollows = LecturerFollows.Where(u => u.Student.Code.ToLower().Equals(MSSV.ToLower()));
            if(Status != null)
                LecturerFollows = LecturerFollows.Where(u => u.Status == Status);
            //if(Start != null)
            //    LecturerFollows = LecturerFollows.Where(u => u.Start >= Start);
            //if (End != null)
            //    LecturerFollows = LecturerFollows.Where(u => u.End <= End);


            return LecturerFollows;
        }
    }
}
