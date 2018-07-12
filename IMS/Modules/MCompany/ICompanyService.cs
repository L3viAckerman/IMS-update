using IMS.Modules.MUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MCompany
{
    public interface ICompanyService : ITransientService
    {
        long Count(SearchCompanyEntity SearchCompanyEntity);
        List<CompanyEntity> Get(SearchCompanyEntity SearchCompanyEntity);
        CompanyEntity Get(Guid Id);
        CompanyEntity Create(UserEntity UserEntity, CompanyEntity CompanyEntity);
        CompanyEntity Update(Guid Id, CompanyEntity CompanyEntity);
        bool Delete(Guid Id);

    }
}
