using IMS.Models;
using IMS.Modules.MInternNews;
using IMS.Modules.MStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MInternFollow
{
    public class InternFollowEntity
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid InternNewsId { get; set; }
        public int Status { get; set; }
        public InternNewsEntity InternNewsEntity { get; set; }
        public StudentEntity StudentEntity { get; set; }
        public InternFollowEntity()
        {

        }
        public InternFollowEntity(InternFollow InternFollow, params object[] args)
        {
            this.Id = InternFollow.Id;
            this.StudentId = InternFollow.StudentId;
            this.InternNewsId = InternFollow.InternNewsId;
            this.Status = InternFollow.Status;
            this.StudentEntity = InternFollow.Student == null ? null : new StudentEntity(InternFollow.Student);
            //this.InternNewsEntity = InternFollow.InternNews == null ? null : new InternNewsEntity(InternFollow.InternNews);
            foreach (var arg in args)
            {
                if (arg is InternNews)
                    this.InternNewsEntity = new InternNewsEntity(arg as InternNews);
            }

        }
        public InternFollow ToModel(InternFollow InternFollow = null)
        {
            if(InternFollow == null)
            {
                InternFollow = new InternFollow();
                InternFollow.Id = Guid.NewGuid();
            }
            InternFollow.StudentId = this.StudentId;
            InternFollow.InternNewsId = this.InternNewsId;
            InternFollow.Status = this.Status;
            return InternFollow;
        }
    }
}
