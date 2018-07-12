using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS.Models;
namespace IMS.Modules.MInternNews
{
    public class SearchInternNewsEntity : FilterEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Company Company { get; set; }
        public Guid? CompanyId { get; set; }
        public SearchInternNewsEntity()
        {

        }
        public IQueryable<InternNews> ApplyTo(IQueryable<InternNews> internNews)
        {
            if(Company!=null)
            {
                internNews = internNews.Where(news => news.Company.Name.Equals(Company.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(Content))
            {
                internNews = internNews.Where(news => news.Content.ToLower().Contains(Content.ToLower()));
            }
            if (!string.IsNullOrEmpty(Title))
            {
                internNews = internNews.Where(news => news.Title.ToLower().Equals(Title.ToLower()));
            }
            if (CompanyId.HasValue)
            {
                internNews = internNews.Where(news => news.CompanyId == CompanyId.Value);
            }
            return internNews;
        }
        
    }
}
