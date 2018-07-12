using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS.Models;
using IMS.Modules.MInternFollow;
using IMS.Modules.MInternshipCourse;
using IMS.Modules.MUser;
using Microsoft.AspNetCore.Mvc;
namespace IMS.Modules.MStudent
{
    [Route("api/Students")]
    public class StudentController : CommonController
    {
        public IStudentService studentService;
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }
        [Route("Count"), HttpGet]
        public long Count(SearchStudentEntity SearchStudentEntity)
        {
            return studentService.Count(UserEntity, SearchStudentEntity);
        }
        [Route(""), HttpGet]
        public List<StudentEntity> Get(SearchStudentEntity SearchStudentEntity)
        {
            return studentService.Get(UserEntity, SearchStudentEntity);
        }
        [Route("{StudentId}"), HttpGet]
        public StudentEntity Get(Guid StudentId)
        {
            return studentService.Get(UserEntity, StudentId);
        }

        [Route(""), HttpPost]
        public StudentEntity Create([FromBody]StudentEntity StudentEntity)
        {
            return studentService.Create(UserEntity, StudentEntity);
        }

        [Route("{StudentId}"), HttpPut]
        public StudentEntity Put(Guid StudentId, [FromBody]StudentEntity studentEntity)
        {
            return studentService.Update(UserEntity, StudentId, studentEntity);
        }
        [Route("{StudentId}"), HttpDelete]
        public bool Delete(Guid StudentId)
        {
            return studentService.Delete(UserEntity, StudentId);
        }
        [Route("{StudentId}/InternshipCourses"), HttpGet]
        public List<InternshipCourseEntity> GetInternshipCourses([FromRoute] Guid StudentId)
        {
            return studentService.GetInternshipCourses(UserEntity, StudentId);
        }
    }
}

