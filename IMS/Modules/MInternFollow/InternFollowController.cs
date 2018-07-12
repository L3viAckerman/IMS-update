using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MInternFollow 
{
    [Route("api/InternFollows")]
    public class InternFollowController : CommonController
    {
        public IInternFollowService InternFollowService;
        public InternFollowController(IInternFollowService InternFollowService) 
        {
            this.InternFollowService = InternFollowService;
        }
        [Route("Count"), HttpGet]
        public long Count(SearchInternFollowEntity SearchInternReportEntity)
        {
            return InternFollowService.Count(UserEntity, SearchInternReportEntity);
        }
        [Route(""), HttpGet]
        public List<InternFollowEntity> Get(SearchInternFollowEntity SearchInternReportEntity)
        {
            return InternFollowService.Get(UserEntity, SearchInternReportEntity);
        }
        [Route("Student/{studentId}"), HttpGet]
        public List<InternFollowEntity> GetInternFollows([FromRoute]Guid studentId)
        {
            return InternFollowService.GetInternFollows(UserEntity, studentId);
        }
        //[HttpGet]
        //public List<InternFollowEntity> GetInternFollows()
        //{
        //    return InternFollowService.GetInternFollows(UserEntity);
        //}
        [HttpDelete("{internNewsId}")]
        public bool Delete([FromRoute] Guid internNewsId)
        {
            return InternFollowService.Delete(UserEntity, internNewsId);
        }

      

    }
}
