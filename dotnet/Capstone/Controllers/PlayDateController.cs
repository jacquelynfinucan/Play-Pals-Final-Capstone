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
        [HttpGet("playdates/place/{locationId}")]
        public ActionResult<List<PlayDate>> GetAllPlayDatesForLocation(int locationId)
        {
            return Ok(playDateDao.GetAllPlayDatesForLocation(locationId));
        }



        [HttpGet("/playdates")]
        public ActionResult<List<PlayDate>> GetAllPlayDates()
        {
            List<PlayDate> playDates = playDateDao.GetAllPlayDates();
            
            return Ok(playDates);
        }

        [HttpGet("/playdates/user/{hostUserId}")]
        public ActionResult<List<FrontEndPlayDate>> GetAllPlayDatesForHost(int hostUserId)
        {
            var playDates = playDateDao.GetFrontEndPlayDatesForHost(hostUserId);

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
        [HttpPut("/playdates/{playDateId}/status/{statusId}")]
        public IActionResult UpdateAStatus(int statusId, int playDateId)
        {
            playDateDao.UpdateStatus(playDateId,statusId);
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

        [HttpGet("/threads/{userID}")]
        public IActionResult GetPlayDateThreadsForUser(int userID)
        {
            List<PlayDateThread> playDateThreadsForUser = playDateDao.GetPlayDateThreadsForUser(userID);

            return Ok(playDateThreadsForUser);
        }

        [HttpGet("/playdates/{playDateID}/threads")]
        public IActionResult GetPlayDateThreadForPlayDateID(int playDateID)
        {
            PlayDateThread playDateThread = playDateDao.GetPlayDateThreadForPlayDateID(playDateID);

            return Ok(playDateThread);
        }
    }
}
