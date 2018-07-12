using System.Security.Claims;
using IMS.Modules.MUser;

namespace IMS
{
    public class MyPrincipal : ClaimsPrincipal
    {
        public MyPrincipal(UserEntity UserEntity)
        {
            this.UserEntity = UserEntity;
        }

        public UserEntity UserEntity { get; set; }
      
    }
}
