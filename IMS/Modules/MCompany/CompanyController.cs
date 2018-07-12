using System;
using IMS.Modules.MUser;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Modules.MCompany
{
    [Route("api/Companies")]
    public class CompanyController : CommonController
    {
        public ICompanyService CompanyService;
        public CompanyController (ICompanyService CompanyService)
        {
            this.CompanyService = CompanyService;
        }
        [Route("Count"), HttpGet]
        public long Count(SearchCompanyEntity SearchCompanyEntity)
        {
            return CompanyService.Count(SearchCompanyEntity);
        }
        [Route(""), HttpGet]
        public List<CompanyEntity> Get(SearchCompanyEntity SearchCompanyEntity)
        {
            return CompanyService.Get(SearchCompanyEntity);
        }
        [Route("{Id}"), HttpGet]
        public CompanyEntity Get(Guid Id)
        {
            return CompanyService.Get(Id);
        }
        [Route(""), HttpPost]
        public CompanyEntity Create([FromBody]CompanyEntity CompanyEntity)
        {
            return CompanyService.Create(UserEntity, CompanyEntity);
        }
        [Route("{Id}"), HttpPut]
        public CompanyEntity Update(Guid Id, [FromBody]CompanyEntity CompanyEntity)
        {
            return CompanyService.Update(Id, CompanyEntity);
        }
        [Route("{Id}"), HttpDelete]
        public bool Delete(Guid Id)
        {
            return CompanyService.Delete(Id);
        }
    }
}
