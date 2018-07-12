using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS.Modules.MStudent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Modules.MLecturer
{
    [Route("api/Lecturers")]
    public class LecturerController : CommonController
    {
        public ILecturerService LecturerService;
        public LecturerController(ILecturerService LecturerService)
        {
            this.LecturerService = LecturerService;
        }

        [Route("Count"), HttpGet]
        public long Count(SearchLecturerEntity SearchLecturerEntity)
        {
            return LecturerService.Count(UserEntity, SearchLecturerEntity);
        }

        [Route(""), HttpGet]
        public List<LecturerEntity> Get(SearchLecturerEntity SearchLecturerEntity)
        {
            return LecturerService.Get(UserEntity, SearchLecturerEntity);
        }
        [Route("{LecturerId}"), HttpGet]
        public LecturerEntity Get(Guid LecturerId)
        {
            return LecturerService.Get(UserEntity, LecturerId);
        }
        [Route(""), HttpPost]
        public LecturerEntity Create([FromBody]LecturerEntity LecturerEntity)
        {
            return LecturerService.Create(UserEntity, LecturerEntity);
        }
        [Route("{LecturerId}"), HttpPut]
        public LecturerEntity Update(Guid LecturerId, [FromBody]LecturerEntity LecturerEntity)
        {
            return LecturerService.Update(UserEntity, LecturerId, LecturerEntity);
        }
        [Route("{LecturerId}"), HttpDelete]
        public bool Delete(Guid LecturerId)
        {
            return LecturerService.Delete(UserEntity, LecturerId);
        }
    }
}