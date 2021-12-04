using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase 
    {
   
        private readonly IProfileDao profileDao;

        public ProfileController(IProfileDao _profileDao)
        {
            profileDao = _profileDao;
        }

        [HttpPost()]
        public IActionResult AddProfile(Profile profile)
        {
            profileDao.AddProfile(profile);
            return Ok();
        }

        [HttpPut()]
        public IActionResult UpdateProfile(Profile profile)
        {
            profileDao.UpdateProfile(profile);
            return Ok();
        }

        [HttpDelete("/{userID}")]
        public IActionResult DeleteProfile(int id)
        {
            profileDao.DeleteProfile(id);
            return NoContent();
        }

        [HttpGet("/{userID}")]
        public ActionResult<Profile> GetProfile(int userID)
        {
            Profile profile = profileDao.GetProfile(userID);
            return profile;
        }

        [HttpGet()]
        public ActionResult<List<Profile>> GetAllProfiles()
        {
            List<Profile> profiles = profileDao.GetAllProfiles();
            return profiles;
        }

    }
}
