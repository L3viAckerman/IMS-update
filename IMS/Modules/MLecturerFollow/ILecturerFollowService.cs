using IMS.Modules.MUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MLecturerFollow
{
    public interface ILecturerFollowService : ITransientService
    {
        long Count(UserEntity UserEntity, SearchLecturerFollowEntity SearchLecturerFollowEntity);
        List<LecturerFollowEntity> Get(UserEntity UserEntity, SearchLecturerFollowEntity SearchLecturerFollowEntity);
        LecturerFollowEntity Get(UserEntity UserEntity, Guid LecturerFollowId);
        LecturerFollowEntity Create(UserEntity UserEntity, LecturerFollowEntity LecturerFollowEntity);
        LecturerFollowEntity Update(UserEntity UserEntity, Guid LecturerFollowId, LecturerFollowEntity LecturerFollowEntity);
        bool Delete(UserEntity UserEntity, Guid LecturerFollowId);
    }
}
