using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Modules.MStudentLecturer
{
    [Route("api/StudentLectures")]
    public class StudentLecturerController : CommonController
    {
        public IStudentLecturerService StudentLecturerService;
        public StudentLecturerController(IStudentLecturerService studentLecturerService)
        {
            this.StudentLecturerService = studentLecturerService;
        }
        [Route("Count"), HttpGet]
        public long Count(SearchStudentLecturerEntity searchStudentLecturerEntity)
        {
            return StudentLecturerService.Count(UserEntity, searchStudentLecturerEntity);
        }
        [Route(""), HttpGet]
        public List<StudentLecturerEntity> Get(SearchStudentLecturerEntity searchStudentLecturerEntity)
        {
            return StudentLecturerService.Get(UserEntity, searchStudentLecturerEntity);
        }
        [Route("{StudentId}"), HttpGet]
        public StudentLecturerEntity Get(Guid StudentId)
        {
            return StudentLecturerService.Get(UserEntity, StudentId);
        }
        [Route(""), HttpPost]
        public StudentLecturerEntity Create([FromBody] StudentLecturerEntity studentLectureEntity)
        {
            return StudentLecturerService.Create(UserEntity, studentLectureEntity);
        }
        [Route("{StudentId}"), HttpPut]
        public StudentLecturerEntity Update(Guid StudentId, [FromBody] StudentLecturerEntity studentLecturerEntity)
        {
            return StudentLecturerService.Update(UserEntity, StudentId, studentLecturerEntity);
        }
        [Route("{StudentId}"), HttpDelete]
        public bool Delete(Guid StudentId)
        {
            return StudentLecturerService.Delete(UserEntity, StudentId);
        }
    }
}
