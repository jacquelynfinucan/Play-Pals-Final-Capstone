using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfileController : Controller //controller vs controllerbase
    {
   
        private readonly IProfileDao profileDao;

        [HttpPost("/")]
        public IActionResult AddProfile(Profile profile)
        {
            return null;
        }

        [HttpPut("/{userID}")]
        public IActionResult UpdateProfile(int userID, Profile profile)
        {
            return null;
        }

        [HttpDelete("/{userID}")]
       public IActionResult DeleteProfile(int id)
        {
            return null;
        }

        [HttpGet("/{userID}")]
       public ActionResult<Profile> GetProfile(int userID)
        {
            Profile profile = profileDao.GetProfile(userID);
            return profile;
        }

        [HttpGet("/")]
       public ActionResult<List<Profile>> GetAllProfiles()
        {
            List<Profile> profiles = profileDao.GetAllProfiles();
            return profiles;
        }

    }
}
