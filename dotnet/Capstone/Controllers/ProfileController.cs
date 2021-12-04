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

        [HttpPost("/")]
        IActionResult AddProfile(Profile profile)
        {
            profileDao.AddProfile(profile);
            return Ok();
        }

        [HttpPut("/")]
        IActionResult UpdateProfile(Profile profile)
        {
            profileDao.UpdateProfile(profile);
            return Ok();
        }

        [HttpDelete("/{userID}")]
        IActionResult DeleteProfile(int id)
        {
            profileDao.DeleteProfile(id);
            return NoContent();
        }

        [HttpGet("/{userID}")]
        ActionResult<Profile> GetProfile(int userID)
        {
            Profile profile = profileDao.GetProfile(userID);
            return profile;
        }

        [HttpGet("/")]
        ActionResult<List<Profile>> GetAllProfiles()
        {
            List<Profile> profiles = profileDao.GetAllProfiles();
            return profiles;
        }

    }
}
