using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayDateController : ControllerBase
    {
        private readonly IPlayDateDao playDateDao;

        public PlayDateController(IPlayDateDao _playDateDao)
        {
            playDateDao = _playDateDao;
        }

        [HttpGet("/playdates")]
        public ActionResult<List<PlayDate>> GetAllPlayDates()
        {
            List<PlayDate> playDates = playDateDao.GetAllPlayDates();

            return Ok(playDates);
        }

        [HttpGet("/playdates/{hostUserId}")]
        public ActionResult<List<PlayDate>> GetAllPlayDatesForHost(int hostUserId)
        {
            List<PlayDate> playDates = playDateDao.GetAllPlayDatesForHost(hostUserId);

            return Ok(playDates);
        }

        [HttpGet("/playdates/{playDateId}")]
        public ActionResult<PlayDate> GetAPlayDate(int playDateId)
        {
            PlayDate playDate = playDateDao.GetAPlayDate(playDateId);
            return Ok(playDate);
        }

        [HttpPost("/playdates")]
        public IActionResult AddAPlayDate(PlayDate newPlayDate)
        {
            int newPlayDateId = playDateDao.AddAPlayDate(newPlayDate);
            return Ok();
        }
     
        [HttpPut("/playdates/{playDateId}")]
        public IActionResult UpdateAPlayDate(int playDateId, PlayDate updatedPlayDate)
        {
            bool isSuccessful = playDateDao.UpdateAPlayDate(updatedPlayDate);
            return Ok();
        }

        [HttpDelete("/playdates/{playDateId}")]
        public IActionResult DeleteAPlayDate(int playDateId)
        {
            bool isSuccessful = playDateDao.DeleteAPlayDate(playDateId);
            return Ok();
        }
    }
}
