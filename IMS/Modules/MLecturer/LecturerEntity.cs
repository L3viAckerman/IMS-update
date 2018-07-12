using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS.Modules.MUser;
namespace IMS.Modules.MLecturer
{
    public class LecturerEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Vnumail { get; set; }
        public string Gmail { get; set; }
        public string Note { get; set; }
        public string Phone { get; set; }
        public string Fullname { get; set; }
        public LecturerEntity() { }
        // Tạo một entity từ một bản ghi trong db 
        public LecturerEntity(Lecturer Lecturer)
        {
            this.Id = Lecturer.Id;
            this.Username = Lecturer.IdNavigation.Username;
            this.Vnumail = Lecturer.Vnumail;
            this.Gmail = Lecturer.Gmail;
            this.Note = Lecturer.Note;
            this.Phone = Lecturer.Phone;
            this.Fullname = Lecturer.FullName;
        }
        // Chuyển từ thực thể về db
        public Lecturer ToModel(Lecturer Lecturer = null)
        {
            if (Lecturer == null)
            {
                Lecturer = new Lecturer();
                Lecturer.Id = Guid.NewGuid();
            }
            Lecturer.FullName = this.Fullname;
            Lecturer.Vnumail = this.Vnumail;
            Lecturer.Gmail = this.Gmail;
            Lecturer.Note = this.Note;
            Lecturer.Phone = this.Phone;
            return Lecturer;
        }
    }
}
