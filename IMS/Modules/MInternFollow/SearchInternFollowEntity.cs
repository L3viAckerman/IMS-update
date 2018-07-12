using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MInternFollow
{
    public class SearchInternFollowEntity : FilterEntity
    {
        public int Status { get; set; }
        public string InternNewsName { get; set; }
        public string StudentName { get; set; }
        public IQueryable<InternFollow> ApplyTo(IQueryable<InternFollow> internFollows)
        {
            if (!string.IsNullOrEmpty(InternNewsName))
                internFollows = internFollows.Where(s => s.InternNews.Title.ToLower().Equals(this.InternNewsName.ToLower()));
            if (!string.IsNullOrEmpty(StudentName))
                internFollows = internFollows.Where(s => s.Student.FullName.ToLower().Equals(this.StudentName.ToLower()));
            return internFollows;
        }
    }
}
