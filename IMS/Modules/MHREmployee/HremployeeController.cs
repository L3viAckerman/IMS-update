using System;
using IMS.Modules.MHrEmployee;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Modules.MHrEmployee
{
    [Route("api/HrEmployees")]
    public class HrEmployeeController : CommonController
    {
        public IHrEmployeeService HrEmployeeService;
        public HrEmployeeController (IHrEmployeeService HrEmployeeService)
        {
             this.HrEmployeeService = HrEmployeeService;
        }
        [Route("Count"), HttpGet]
        public long Count(SearchHrEmployeeEntity SearchHrEmployeeEntity)
        {
            return HrEmployeeService.Count(UserEntity, SearchHrEmployeeEntity);
        }
        [Route(""), HttpGet]
        public List<HrEmployeeEntity> Get(SearchHrEmployeeEntity SearchHrEmployeeEntity)
        {
            return HrEmployeeService.Get(UserEntity, SearchHrEmployeeEntity);
        }
        [Route("{Id}"), HttpGet]
        public HrEmployeeEntity Get(Guid Id)
        {
            return HrEmployeeService.Get(UserEntity,Id);
        }
        [Route(""), HttpPost]
        public HrEmployeeEntity Create([FromBody] HrEmployeeEntity HrEmployeeEntity)
        {
            return HrEmployeeService.Create(UserEntity, HrEmployeeEntity);
        }
        [Route("{Id}"), HttpPut]
        public HrEmployeeEntity Update(Guid Id, [FromBody] HrEmployeeEntity HrEmployeeEntity)
        {
            return HrEmployeeService.Update(UserEntity, Id, HrEmployeeEntity);
        }
        [Route("{Id}"), HttpDelete]
        public bool Delete(Guid Id)
        {
            return HrEmployeeService.Delete(UserEntity, Id);
        }

    }

 }
