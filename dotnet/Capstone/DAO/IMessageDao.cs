using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IMessageDao
    {
        public List<Message> GetMessagesForPlayDate(int playDateID);

        public Message GetMessage(int messageID);

        public Message AddMessage(Message message);

        public Message UpdateMessage(int messageID, Message message);

        public void DeleteMessage(int messageID);
    }
}
