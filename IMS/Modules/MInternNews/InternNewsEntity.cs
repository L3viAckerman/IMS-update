using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using IMS.Models;
using IMS.Modules.MCompany;
using IMS.Modules.MInternFollow;

namespace IMS.Modules.MInternNews
{
    public class InternNewsEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid? CompanyId { get; set; }
        public DateTime ExpiredDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<InternFollowEntity> InternFollowEntities { get; set; }
        public InternNewsEntity()
        {

        }
        public InternNewsEntity(InternNews internNews)
        {
            this.Id = internNews.Id;
            this.Title = internNews.Title;
            this.Content = internNews.Content;
            //this.CompanyEntity = internNews.Company == null ? null : new CompanyEntity(internNews.Company);
            this.CompanyId = internNews.CompanyId;
            this.ExpiredDate = internNews.ExpiredDate;
            this.CreatedDate = internNews.CreatedDate;
            //this.UpdatedDate = internNews.UpdatedDate;
            this.InternFollowEntities = internNews.InternFollows == null ? null : internNews.InternFollows.Select(itf => new InternFollowEntity(itf)).ToList();
        }
        public InternNews ToModel(InternNews internNews = null)
        {
            if(internNews==null)
            {
                internNews = new InternNews();
                internNews.Id = Guid.NewGuid();
                internNews.CreatedDate = DateTime.Now;
                internNews.UpdatedDate = DateTime.Now;
            }
            internNews.ExpiredDate = this.ExpiredDate;
            internNews.CompanyId = this.CompanyId;
            internNews.Title = this.Title;
            internNews.Content = this.Content;
            return internNews;
        }

    }
}
