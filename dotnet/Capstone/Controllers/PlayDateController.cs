using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayDateController : ControllerBase
    {

        private readonly IUserDao userDao;

 
        /*
        [HttpPost("/profile/{userID}/pets")]
        IActionResult AddAPetToUser(int userID,petModel pet)
        {

        }
        [HttpGet("/pet/{petID}")]
        IActionResult GetAPet(int petID)
        {
        }
        [HttpGet("/profile/{userID}/pets")]
        IActionResult GetUserPets(int userID)
        {

        }

        [HttpGet("/pets")]
        IActionResult GetAllThePets()
        {

        }



        [HttpPut("/pets/{petID}")]
        IActionResult UpdateAPet(int petID,petModel pet)
        {

        }
        [HttpDelete("/pets/{petID}")]
        IActionResult DeleteAPet(int userID, petModel pet)
        {

        }
        [HttpPost("/profiles")]
        IActionResult MakeAUserProfile(UserProfile profile)
        {

        } 
        [HttpPut("/profiles")]
        IActionResult UpdateUserProfile(int userID,UserProfile profile)
        {

        }
        [HttpGet("/profiles/{userID}")]
        IActionResult GetAUser(int userID)
        {

        }
        [HttpGet("/profiles")]
        IActionResult GetAllUsers()
        {

        }
        [HttpDelete("/profiles/{id}")]
        IActionResult DeleteUserProfile(int id)
        {

        }
        [HttpPost("/playdates")]
        IActionResult AddAPlayDate(PlayDate playDate)
        {

        }
        [HttpGet("/playdates")]
        IActionResult GetAllPlayDates()
        {

        }*/
    }
}
