using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS.Modules.MUser;

namespace IMS.Modules.MAdmin
{
    public interface IAdminService : ITransientService
    {
        long Count(UserEntity userEntity, SearchAdminEntity searchAdminEntity);
        List<AdminEntity> Get(UserEntity userEntity, SearchAdminEntity searchAdminEntity);
        AdminEntity Get(UserEntity userEntity, Guid Id);
        AdminEntity Create(UserEntity userEntity, AdminEntity adminEntity);
        AdminEntity Update(UserEntity userEntity, Guid Id, AdminEntity adminEntity);
        bool Delete(UserEntity userEntity, Guid Id);

    }
}
