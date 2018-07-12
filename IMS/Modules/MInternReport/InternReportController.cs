using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Modules.MInternReport
{
    [Route("api/Reports")]
    public class InternReportController : CommonController
    {
        public IInternReportService InternReportService;
        public InternReportController(IInternReportService InternReportService)
        {
            this.InternReportService = InternReportService;
        }
        [Route("Count"), HttpGet]
        public long Count(SearchInternReportEntity SearchInternReportEntity)
        {
            return InternReportService.Count(SearchInternReportEntity);
        }
        [Route("{ReportId}"), HttpGet]
        public InternReportEntity Get(Guid ReportId)
        {
            return InternReportService.Get(UserEntity, ReportId);
        }
        [Route(""), HttpGet]
        public List<InternReportEntity> Get(SearchInternReportEntity SearchInternReportEntity)
        {
            return InternReportService.Get(UserEntity, SearchInternReportEntity);
        }
        [Route(""), HttpPost]
        public InternReportEntity Create([FromBody]InternReportEntity InternReportEntity)
        {
            return InternReportService.Create(UserEntity, InternReportEntity);
        }
        [Route("{ReportId}"), HttpPut]
        public InternReportEntity Update()
        {
            return null;
        }
        [Route("{ReportId}"), HttpDelete]
        public bool Delete(Guid ReportId)
        {
            return InternReportService.Delete(UserEntity, ReportId);
        }

        [Route("Lecturer/{LectureId}"), HttpGet]
        public List<InternReportEntity> ReadReports(Guid LectureId)
        {
            return InternReportService.ReadReports(UserEntity, LectureId);
        }
    }
}
