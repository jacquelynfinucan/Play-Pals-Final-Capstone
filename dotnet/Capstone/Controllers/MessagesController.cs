using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [ApiController]
    public class MessagesController : Controller
    {
        private readonly IMessageDao messageDao;

        public MessagesController(IMessageDao _messageDao)
        {
            messageDao = _messageDao;
        }

        [HttpPost("/messages")]
        public IActionResult AddMessage(Message message)
        {
            Message addedMessage = messageDao.AddMessage(message);

            if (addedMessage != null)
            {
                return Created(message.MessageID.ToString(), null);
            }
            else
            {
                return BadRequest(new { message = "An error occurred and message was not created." });
            }
        }

        [HttpPut("/messages/{messageID}")]
        public IActionResult UpdateMessage(int messageID, Message message)
        {
            Message updatedMessage = messageDao.UpdateMessage(messageID, message);

            if (updatedMessage != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new { message = "An error occurred and message was not updated." });
            }
        }

        [HttpGet("/messages/{messageID}")]
        public IActionResult GetMessage(int messageID)
        {
            Message message = messageDao.GetMessage(messageID);

            if (message != null)
            {
                return Ok(message);
            }
            else
            {
                return BadRequest(new { message = "An error occurred no message found for the ID." });
            }
        }

        [HttpDelete("/messages/{messageID}")]
        public IActionResult DeleteMessage(int messageID)
        {
            messageDao.DeleteMessage(messageID);
            return NoContent();
        }

        [HttpGet("/playdates/{playDateID}/messages")]
        public IActionResult GetMessagesForPlayDate(int playDateID)
        {
            List<Message> messagesForPlayDate = messageDao.GetMessagesForPlayDate(playDateID);

            return Ok(messagesForPlayDate);
        }
    }
}
