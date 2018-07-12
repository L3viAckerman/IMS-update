using IMS.Modules.MUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MStudentLecturer
{
   public interface IStudentLecturerService : ITransientService
    {
        long Count(UserEntity userEntity, SearchStudentLecturerEntity searchStudentLecturerEntity);
        List<StudentLecturerEntity> Get(UserEntity userEntity, SearchStudentLecturerEntity searchStudentLecturerEntity);
        StudentLecturerEntity Get(UserEntity userEntity, Guid StudentId);
        StudentLecturerEntity Create(UserEntity userEntity, StudentLecturerEntity studentLectureEntity);
        StudentLecturerEntity Update(UserEntity userEntity, Guid StudentId, StudentLecturerEntity studentLecturerEntity);
        bool Delete(UserEntity userEntity, Guid StudentId);
    }
}

