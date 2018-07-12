using IMS.Modules.MUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MMessage
{
    public interface IMessageService : ITransientService
    {
        long Count(UserEntity UserEntity, SearchMessageEntity SearchMessageEntity);
        List<MessageEntity> Get(UserEntity UserEntity);
        MessageEntity Get(UserEntity UserEntity, Guid MessageId);
        MessageEntity Create(UserEntity UserEntity, MessageEntity MessageEntity);
        MessageEntity Update(MessageEntity MessageEntity, Guid MessageId);
        bool Delete(UserEntity UserEntity, Guid MessageId);
    }
}
