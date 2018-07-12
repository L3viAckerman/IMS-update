using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MStudent
{
    public class SearchStudentEntity : FilterEntity
    {
        public string Vnumail { get;  set; }
        public string FullName { get;  set; }
        public string Code { get;  set; }
        public string Class { get;  set; }
        public string Department { get;  set; }
        public IQueryable<Student> ApplyTo(IQueryable<Student> students)
        {
            if(!string.IsNullOrEmpty(Vnumail))
            {
                students = students.Where(s => s.Vnumail.ToLower().Equals(Vnumail));
            }
            if (!string.IsNullOrEmpty(FullName))
            {
                students = students.Where(s => s.FullName.ToLower().Equals(FullName.ToLower()));
            }
            if (!string.IsNullOrEmpty(Code))
            {
                students = students.Where(s => s.Vnumail.Equals(Code));
            }
            if (!string.IsNullOrEmpty(Class))
            {
                students = students.Where(s => s.Vnumail.ToLower().Equals(Class));
            }
            if (!string.IsNullOrEmpty(Department))
            {
                students = students.Where(s => s.Vnumail.ToLower().Equals(Department));
            }
            return students;
        }
    }
}
