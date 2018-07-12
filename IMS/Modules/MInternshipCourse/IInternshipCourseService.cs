using IMS.Modules.MUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MInternshipCourse
{
    public interface IInternshipCourseService : ITransientService
    {
        long Count(SearchInternshipCourseEntity SearchInternshipCourseEntity);
        List<InternshipCourseEntity> Get(UserEntity UserEntity, SearchInternshipCourseEntity SearchInternshipCourseEntity);
        List<InternshipCourseEntity> Get(UserEntity UserEntity);
        InternshipCourseEntity Create(UserEntity UserEntity, InternshipCourseEntity internshipCourseEntity);
        InternshipCourseEntity Update(UserEntity UserEntity, Guid internshipCourseId, InternshipCourseEntity internshipCourseEntity);
        bool Delete(UserEntity UserEntity, Guid internshipCourseId);
    }
}
