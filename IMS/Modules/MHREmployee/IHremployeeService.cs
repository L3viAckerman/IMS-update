using IMS.Modules.MUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MHrEmployee
{
    public interface IHrEmployeeService : ITransientService
    {
        long Count(UserEntity UserEntity, SearchHrEmployeeEntity SearchHrEmployeeEntity);
        List<HrEmployeeEntity> Get(UserEntity UserEntity, SearchHrEmployeeEntity SearchHrEmployeeEntity);
        HrEmployeeEntity Get(UserEntity UserEntity,Guid Id);
        HrEmployeeEntity Create(UserEntity UserEntity, HrEmployeeEntity SearchHrEmployeeEntity);
        HrEmployeeEntity Update(UserEntity UserEntity,Guid Id, HrEmployeeEntity HrEmployeeEntity);
        bool Delete(UserEntity UserEntity, Guid Id);

    }
}
