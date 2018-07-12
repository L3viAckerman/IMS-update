using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MInternshipCourse
{
    [Route("api/InternshipCourses")]
    public class InternshipCourseController : CommonController
    {
        IInternshipCourseService internshipCourseService;
        public InternshipCourseController(IInternshipCourseService internshipCourseService): base()
        {
            this.internshipCourseService = internshipCourseService;
        }
        [Route(""), HttpGet]
        public List<InternshipCourseEntity> Get(SearchInternshipCourseEntity SearchInternshipCourseEntity)
        {
            return internshipCourseService.Get(UserEntity, SearchInternshipCourseEntity);
        }
        [Route("Count"), HttpGet]
        public long Count(SearchInternshipCourseEntity SearchInternshipCourseEntity)
        {
            return internshipCourseService.Count(SearchInternshipCourseEntity);
        }
        [Route(""), HttpPost]
        public InternshipCourseEntity Create([FromBody]InternshipCourseEntity internshipCourseEntity)
        {
            return internshipCourseService.Create(UserEntity, internshipCourseEntity);
        }
        [Route("{internshipCourseId}"), HttpPut]
        public InternshipCourseEntity Update([FromRoute]Guid internshipCourseId,[FromBody]InternshipCourseEntity internshipCourseEntity)
        {
            return internshipCourseService.Update(UserEntity, internshipCourseId, internshipCourseEntity);
        }
        [Route("{internshipCourseId}"), HttpDelete]
        public bool Delete([FromRoute] Guid internshipCourseId)
        {
            return internshipCourseService.Delete(UserEntity, internshipCourseId);
        }

    }
}
