using IMS.Models;
using IMS.Modules.MUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MMessage
{
    public class MessageService: CommonService, IMessageService
    {
        public long Count(UserEntity UserEntity, SearchMessageEntity SearchMessageEntity)
        {
            if (SearchMessageEntity == null) SearchMessageEntity = new SearchMessageEntity(UserEntity.Id);
            IQueryable<Message> Messages = IMSContext.Messages;
            Messages = SearchMessageEntity.ApplyTo(Messages);
            return Messages.Count();
            
        }
        public List<MessageEntity> Get(UserEntity UserEntity)
        {
            IQueryable<Message> Messages = IMSContext.Messages.Where(m => (m.Sender == UserEntity.Id || m.Receiver == UserEntity.Id));
            return Messages.ToList().Select(m => new MessageEntity(m)).ToList();
        }
        public MessageEntity Get(UserEntity UserEntity, Guid MessageId)
        {
            Message Message = IMSContext.Messages.Where(m => m.Id == MessageId).FirstOrDefault();
            if (Message == null)
                throw new BadRequestException("Message not found.");
            return new MessageEntity(Message);
        }
        public MessageEntity Create(UserEntity UserEntity, MessageEntity MessageEntity)
        {
            Message Message = MessageEntity.ToModel();
            IMSContext.Messages.Add(Message);
            IMSContext.SaveChanges();
            return MessageEntity;
        }
        public MessageEntity Update(MessageEntity MessageEntity, Guid MessageId)
        {
            return null;
        }
        public bool Delete(UserEntity UserEntity, Guid MessageId)
        {
            Message Message = IMSContext.Messages.Where(m => m.Id == MessageId).FirstOrDefault();
            if (Message == null)
                throw new BadRequestException("Message not found.");
            IMSContext.Messages.Remove(Message);
            IMSContext.SaveChanges();
            return true;
        }
    }
}
