using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MLecturer
{
    public class SearchLecturerEntity : FilterEntity
    {
        // Định nghĩa các điều kiện search của lecturer 
        public string Vnumail { get; set; }
        public string FullName { get; set; }
        public IQueryable<Lecturer> ApplyTo(IQueryable<Lecturer> Lecturers)
        {
            if (!string.IsNullOrEmpty(Vnumail))
                Lecturers = Lecturers.Where(u => u.Vnumail.ToLower().Equals(Vnumail.ToLower()));
            if (!string.IsNullOrEmpty(FullName))
                Lecturers = Lecturers.Where(u => u.FullName.ToLower().Equals(FullName.ToLower()));
            return Lecturers;
        }
    }
}
