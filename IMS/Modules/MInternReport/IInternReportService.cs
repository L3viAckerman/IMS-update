using System;
using IMS.Modules.MUser;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MInternReport
{
    public interface IInternReportService : ITransientService
    {
        long Count(SearchInternReportEntity SearchInternReportEntity);
        List<InternReportEntity> Get(UserEntity UserEntity, SearchInternReportEntity SearchInternReportEntity);
        InternReportEntity Get(UserEntity UserEntity, Guid Id);
        InternReportEntity Create(UserEntity UserEntity, InternReportEntity InternReportEntity);
        InternReportEntity Update(Guid Id, InternReportEntity InternReportEntity);
        bool Delete(UserEntity UserEntity, Guid Id);
        List<InternReportEntity> ReadReports(UserEntity userEntity, Guid LectureId);
    }
}
