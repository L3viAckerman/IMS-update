using IMS.Models;
using IMS.Modules.MUser;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Modules.MLecturerFollow
{
    public class LecturerFollowService : CommonService, ILecturerFollowService
    {
        public LecturerFollowService():base()
        {
        }
        public long Count(UserEntity UserEntity, SearchLecturerFollowEntity SearchLecturerFollowEntity)
        {
            if (SearchLecturerFollowEntity == null) SearchLecturerFollowEntity = new SearchLecturerFollowEntity();
            IQueryable<LecturerFollow> Lecturers = IMSContext.LecturerFollows;
            Lecturers = SearchLecturerFollowEntity.ApplyTo(Lecturers);
            return Lecturers.Count();
        }
        public List<LecturerFollowEntity> Get(UserEntity UserEntity, SearchLecturerFollowEntity SearchLecturerFollowEntity)
        {
            if (SearchLecturerFollowEntity == null) SearchLecturerFollowEntity = new SearchLecturerFollowEntity();
            IQueryable<LecturerFollow> Lecturers = IMSContext.LecturerFollows
                .Include(s => s.Student)
                .Include(s => s.Lecturer);
            Lecturers = SearchLecturerFollowEntity.ApplyTo(Lecturers);
            Lecturers = SearchLecturerFollowEntity.SkipAndTake(Lecturers);
            return Lecturers.ToList().Select(u => new LecturerFollowEntity(u)).ToList();
        }
        public LecturerFollowEntity Get(UserEntity UserEntity, Guid LecturerId)
        {
            LecturerFollow LecturerFollow = IMSContext.LecturerFollows.Where(u => u.Id == LecturerId).FirstOrDefault();
            if (LecturerFollow == null)
                throw new BadRequestException("LecturerFollow không tồn tại");
            return new LecturerFollowEntity(LecturerFollow);
        }

        public LecturerFollowEntity Create(UserEntity UserEntity, LecturerFollowEntity LecturerFollowEntity)
        {
            LecturerFollow LecturerFollow = LecturerFollowEntity.ToModel();
            IMSContext.LecturerFollows.Add(LecturerFollow);
            IMSContext.SaveChanges();
            return LecturerFollowEntity;
        }
        public LecturerFollowEntity Update(UserEntity UserEntity, Guid LecturerId, LecturerFollowEntity LecturerFollowEntity)
        {
            LecturerFollow LecturerFollow = IMSContext.LecturerFollows.Where(l => l.Id == LecturerId).FirstOrDefault();
            LecturerFollowEntity.ToModel(LecturerFollow);
            IMSContext.SaveChanges();
            return null;
        }
        public bool Delete(UserEntity UserEntity, Guid LecturerId)
        {
            LecturerFollow LecturerFollow = IMSContext.LecturerFollows.Where(u => u.Id == LecturerId).FirstOrDefault();
            if (LecturerFollow == null)
                throw new BadRequestException("LecturerFollow không tồn tại.");
            IMSContext.LecturerFollows.Remove(LecturerFollow);
            IMSContext.SaveChanges();
            return true;
        }
      
    }
}
