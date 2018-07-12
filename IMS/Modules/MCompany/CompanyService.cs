using IMS.Modules.MUser;
using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Modules.MCompany
{
    public class CompanyService : CommonService, ICompanyService
    {
       public CompanyService():base()
       {
       }
        public long Count(SearchCompanyEntity SearchCompanyEntity)
        {
            if (SearchCompanyEntity == null) SearchCompanyEntity = new SearchCompanyEntity();
            IQueryable<Company> Companies = IMSContext.Companies;
            Companies = SearchCompanyEntity.ApplyTo(Companies);
            return Companies.Count();
        }
        public List<CompanyEntity> Get(SearchCompanyEntity SearchCompanyEntity)
        {
            if (SearchCompanyEntity == null) SearchCompanyEntity = new SearchCompanyEntity();
            IQueryable<Company> Companies = IMSContext.Companies;
            Companies = SearchCompanyEntity.ApplyTo(Companies);
            Companies = SearchCompanyEntity.SkipAndTake(Companies);
            return Companies.ToList().Select(c => new CompanyEntity(c)).ToList();
        }
        public CompanyEntity Get(Guid Id)
        {
            Company Company = IMSContext.Companies.Where(c => c.Id == Id).FirstOrDefault();
            if (Company == null)
            {
                throw new BadRequestException("Company không tồn tại");
            }
            return new CompanyEntity(Company);
        }
        public CompanyEntity Create(UserEntity UserEntity, CompanyEntity CompanyEntity)
        {
            Company Company = CompanyEntity.ToModel();
            IMSContext.Companies.Add(Company);
            IMSContext.SaveChanges();
            return CompanyEntity;
        }
        public CompanyEntity Update(Guid Id, CompanyEntity CompanyEntity)
        {
            Company Company = IMSContext.Companies.Where(c => c.Id == Id).FirstOrDefault();
            CompanyEntity.ToModel(Company);
            IMSContext.SaveChanges();
            return Get(Id);
        }
        public bool Delete(Guid CompanyId)
        {
            Company Company = IMSContext.Companies.Where(c => c.Id == CompanyId).FirstOrDefault();
            if (Company == null)
            {
                throw new BadRequestException("Company không tồn tại");
            }
            IMSContext.Companies.Remove(Company);
            IMSContext.SaveChanges();
            return true;
        }

    }
}
