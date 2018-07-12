using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS.Models;
using IMS.Modules.MLecturer;
using IMS.Modules.MUser;
using IMS.Modules.MInternFollow;
using IMS.Modules.MInternshipCourse;

namespace IMS.Modules.MStudent
{
    public interface IStudentService : ITransientService
    {
        long Count(UserEntity UserEntity, SearchStudentEntity SearchStudentEntity);
        List<StudentEntity> Get(UserEntity UserEntity, SearchStudentEntity SearchStudentEntity);
        List<InternshipCourseEntity> GetInternshipCourses(UserEntity UserEntity, Guid StudentId);
        StudentEntity Get(UserEntity UserEntity, Guid studentId);
        StudentEntity Update(UserEntity UserEntity, Guid StudentId, StudentEntity StudentEntity);
        StudentEntity Create(UserEntity UserEntity, StudentEntity StudentEntity);
        bool Delete(UserEntity UserEntity, Guid StudentId);
    }
}
