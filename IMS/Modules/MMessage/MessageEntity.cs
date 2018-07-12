using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MMessage
{
    public class MessageEntity
    {
        public Guid Id { get; set; }
        public Guid Sender { get; set; }
        public Guid Receiver { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public long Cx { get; set; }
        
        public MessageEntity() { }
        public MessageEntity (Message Message)
        {
            this.Id = Message.Id;
            this.Sender = Message.Sender;
            this.Receiver = Message.Receiver;
            this.Title = Message.Title;
            this.Content = Message.Content;
            this.Status = Message.Status;
            this.Date = Message.Date;
            this.Cx = Message.Cx;
        }

        public Message ToModel(Message Message = null)
        {
            if (Message == null)
            {
                Message = new Message();
                Message.Id = Guid.NewGuid();
            }
            Message.Sender = this.Sender;
            Message.Receiver = this.Receiver;
            Message.Title = this.Title;
            Message.Content = this.Content;
            Message.Status = 0;
            Message.Date = DateTime.Now;
            Message.Cx = this.Cx;
            return Message;
        }
    }
}
