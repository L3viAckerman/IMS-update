using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules.MMessage
{
    public class SearchMessageEntity : FilterEntity
    {
        public Guid UserId { get; set; }
        public SearchMessageEntity(Guid Id)
        {
            this.UserId = Id;
        }
        public IQueryable<Message> ApplyTo (IQueryable<Message> Messages)
        {
            if (UserId != Guid.Empty)
                Messages = Messages.Where(m => m.Sender.Equals(UserId) || m.Receiver.Equals(UserId));
            return Messages;
        }
    }
}
