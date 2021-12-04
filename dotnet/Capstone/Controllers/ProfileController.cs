using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfileController : Controller //controller vs controllerbase
    {
        private readonly IProfileDao profilesDao;

        [HttpPost("/")]
        IActionResult AddProfile(Profile profile)
        {
            return null;
        }

        [HttpPut("/{userID}")]
        IActionResult UpdateProfile(int userID, Profile profile)
        {
            return null;
        }

        [HttpDelete("/{userID}")]
        IActionResult DeleteProfile(int id)
        {
            return null;
        }

        [HttpGet("/{userID}")]
        IActionResult GetProfile(int userID)
        {
            return null;
        }

        [HttpGet("/")]
        IActionResult GetAllProfiles()
        {
            return null;
        }

    }
}
