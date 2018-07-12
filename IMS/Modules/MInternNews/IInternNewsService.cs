using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS.Modules.MInternFollow;
using IMS.Modules.MInternNews;
using IMS.Modules.MUser;

namespace IMS.Modules.MInternshipNews
{
    public interface IInternNewsService : ITransientService
    {
        long Count(SearchInternNewsEntity searchInternNewsEntity);
        List<InternNewsEntity> Get(SearchInternNewsEntity searchInternNewsEntity);
        InternNewsEntity Get(UserEntity UserEntity, Guid InternNewsId);
        InternNewsEntity Create(InternNewsEntity internNewsEntity);
        InternNewsEntity Update(Guid internId, InternNewsEntity internNewsEntity);
        bool Delete(Guid internNewsId);
        InternFollowEntity ChangeStatusFollow(UserEntity UserEntity, Guid InternNewsId);
    }

}
