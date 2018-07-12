using IMS.Modules.MInternNews;
using IMS.Modules.MUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MInternFollow
{
    public interface IInternFollowService : ITransientService
    {
        long Count(UserEntity UserEntity, SearchInternFollowEntity SearchInternReportEntity);
        // get all InternFollow
        List<InternFollowEntity> Get(UserEntity UserEntity, SearchInternFollowEntity SearchInternReportEntity); 
        // get all InternFollow of a Student
        List<InternFollowEntity> GetInternFollows(UserEntity UserEntity, Guid studentId);
        // get all InternFollow of current User
        List<InternFollowEntity> GetInternFollows(UserEntity userEntity);
        bool Delete(UserEntity userEntity, Guid internFollowId);
    }
}
