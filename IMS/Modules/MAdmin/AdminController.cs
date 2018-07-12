using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace IMS.Modules.MAdmin
{
    [Route("api/Admins")]
    public class AdminController : CommonController
    {
        public IAdminService AdminService;
        public AdminController(IAdminService adminService)
        {
            this.AdminService = adminService;
        }
        [Route("Count"), HttpGet]
        public long Count(SearchAdminEntity searchAdminEntity)
        {
            return AdminService.Count(UserEntity, searchAdminEntity);
        }
        [Route(""), HttpGet]
        public List<AdminEntity> Get( SearchAdminEntity searchAdminEntity)
        {
            return AdminService.Get(UserEntity, searchAdminEntity);
        }
        [Route("{Id}"), HttpGet]
        public AdminEntity Get(Guid Id)
        {
            return AdminService.Get(UserEntity, Id);
        }
        [Route(""), HttpPost]
        public AdminEntity Create([FromBody] AdminEntity adminEntity)
        {
            return AdminService.Create(UserEntity, adminEntity);
        }
        [Route("{Id}"), HttpPut]
        public AdminEntity Update(Guid Id,[FromBody] AdminEntity adminEntity)
        {
            return AdminService.Update(UserEntity, Id, adminEntity);
        }
        [Route("{Id}"), HttpDelete]
        public bool Delete( Guid Id)
        {
            return AdminService.Delete(UserEntity, Id);
        }
    }
}
