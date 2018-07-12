using IMS.Modules.MStudent;
using IMS.Modules.MUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MLecturer
{
    public interface ILecturerService : ITransientService
    {
        
        long Count(UserEntity UserEntity, SearchLecturerEntity SearchLecturerEntity);
        List<LecturerEntity> Get(UserEntity UserEntity, SearchLecturerEntity SearchLecturerEntity);
        LecturerEntity Get(UserEntity UserEntity, Guid LecturerId);
        LecturerEntity Create(UserEntity UserEntity, LecturerEntity LecturerEntity);
        LecturerEntity Update(UserEntity UserEntity, Guid LecturerId, LecturerEntity LecturerEntity);
        bool Delete(UserEntity UserEntity, Guid LecturerId);
    }
}
