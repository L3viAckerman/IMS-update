using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Modules.MLecturerFollow
{
    [Route("api/LecturerFollows")]
    public class LecturerFollowController : CommonController
    {
        public ILecturerFollowService LecturerFollowService;
        public LecturerFollowController(ILecturerFollowService LecturerFollowService)
        {
            this.LecturerFollowService = LecturerFollowService;
        }

        [Route("Count"), HttpGet]
        public long Count(SearchLecturerFollowEntity SearchLecturerFollowEntity)
        {
            return LecturerFollowService.Count(UserEntity, SearchLecturerFollowEntity);
        }

        [Route(""), HttpGet]
        public List<LecturerFollowEntity> Get(SearchLecturerFollowEntity SearchLecturerFollowEntity)
        {
            return LecturerFollowService.Get(UserEntity, SearchLecturerFollowEntity);
        }
        [Route("{LecturerId}"), HttpGet]
        public LecturerFollowEntity Get(Guid LecturerId)
        {
            return LecturerFollowService.Get(UserEntity, LecturerId);
        }
        [Route(""), HttpPost]
        public LecturerFollowEntity Create([FromBody]LecturerFollowEntity LecturerFollowEntity)
        {
            return LecturerFollowService.Create(UserEntity, LecturerFollowEntity);
        }
        [Route("{LecturerId}"), HttpPut]
        public LecturerFollowEntity Update(Guid LecturerId, [FromBody]LecturerFollowEntity LecturerFollowEntity)
        {
            return LecturerFollowService.Update(UserEntity, LecturerId, LecturerFollowEntity);
        }
        [Route("{LecturerId}"), HttpDelete]
        public bool Delete(Guid LecturerId)
        {
            return LecturerFollowService.Delete(UserEntity, LecturerId);
        }
    }
}