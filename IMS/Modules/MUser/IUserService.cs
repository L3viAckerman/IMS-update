using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MUser
{
    public interface IUserService : ITransientService
    {
        long Count(SearchUserEntity SearchUserEntity);
        List<UserEntity> Get(SearchUserEntity SearchUserEntity);
        UserEntity Get(Guid UserId);
        bool ChangePassword(Guid UserId, PasswordEntity passwordEntity);
        UserEntity Create(UserEntity UserEntity);
        UserEntity Update(Guid UserId, UserEntity UserEntity);
        bool Delete(Guid UserId);
        string Login(UserEntity UserEntity);
    }
}
