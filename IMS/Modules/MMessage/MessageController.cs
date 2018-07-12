using System;
using IMS.Modules.MUser;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Modules.MMessage
{
    [Route("api/Messages")]
    public class MessageController : CommonController
    {
        public IMessageService MessageService;
        public MessageController(IMessageService MessageService)
        {
            this.MessageService = MessageService;
        }

        [Route("Count"), HttpGet]
        public long Count(SearchMessageEntity SearchMessageEntity)
        {
            return MessageService.Count(UserEntity, SearchMessageEntity);
        }

        [Route(""), HttpGet]
        public List<MessageEntity> Get()
        {
            return MessageService.Get(UserEntity);
        }
        [Route("{MessageId}"), HttpGet]
        public MessageEntity Get(Guid MessageId)
        {
            return MessageService.Get(UserEntity, MessageId);
        }
        [Route(""), HttpPost]
        public MessageEntity Create([FromBody]MessageEntity MessageEntity)
        {
            return MessageService.Create(UserEntity, MessageEntity);
        }
        [Route("{MessageId}"), HttpPut]
        public MessageEntity Update()
        {
            return null;
        }
        [Route("{MessageId}"), HttpDelete]
        public bool Delete(Guid MessageId)
        {
            return MessageService.Delete(UserEntity, MessageId);
        }
    }
}
