using IMS.Models;
using IMS.Modules.MUser;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MInternReport
{
    public class InternReportService: CommonService, IInternReportService
    {
        public long Count(SearchInternReportEntity SearchInternReportEntity)
        {
            if (SearchInternReportEntity == null) SearchInternReportEntity = new SearchInternReportEntity();
            IQueryable<InternReport> internReports = IMSContext.InternReports;
            internReports = SearchInternReportEntity.ApplyTo(internReports);
            return internReports.Count();
        }
        public List<InternReportEntity> Get(UserEntity UserEntity, SearchInternReportEntity SearchInternReportEntity )
        {
            if (SearchInternReportEntity == null) SearchInternReportEntity = new SearchInternReportEntity();
            IQueryable<InternReport> InternReports = IMSContext.InternReports;
            InternReports = SearchInternReportEntity.ApplyTo(InternReports);
            InternReports = SearchInternReportEntity.SkipAndTake(InternReports);
            return InternReports.Select(u => new InternReportEntity(u)).ToList();
        }
        public InternReportEntity Get(UserEntity UserEntity, Guid Id)
        {
            InternReport internReport = IMSContext.InternReports.Where(ir => ir.Id == Id).FirstOrDefault();
            if (internReport == null)
                throw new BadRequestException("Report not found!");
            return new InternReportEntity(internReport);
        }
        public InternReportEntity Create(UserEntity UserEntity, InternReportEntity InternReportEntity)
        {
            InternReport internReport = InternReportEntity.ToModel();
            IMSContext.InternReports.Add(internReport);
            IMSContext.SaveChanges();
            return InternReportEntity;
        }
        public InternReportEntity Update(Guid Id, InternReportEntity InternReportEntity)
        {
            return null;
        }
        public bool Delete(UserEntity UserEntity, Guid Id)
        {
            InternReport internReport = IMSContext.InternReports.Where(m => m.Id == Id).FirstOrDefault();
            if (internReport == null)
                throw new BadRequestException("Report not found.");
            IMSContext.InternReports.Remove(internReport);
            IMSContext.SaveChanges();
            return true;
        }

        public List<InternReportEntity> ReadReports(UserEntity userEntity, Guid LectureId)
        {
            throw new NotImplementedException();
        }
    }
}
