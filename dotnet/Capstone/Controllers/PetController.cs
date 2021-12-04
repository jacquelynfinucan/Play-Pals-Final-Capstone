using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;

namespace Capstone.Controllers
{
    [ApiController]
    public class PetController : Controller
    {
        private readonly IPetDao petDao;

        public PetController(IPetDao _petDao)
        {
            petDao = _petDao;
        }

        /*
        [HttpPost("/profile/{userID}/pets")]
        public IActionResult AddAPetToUser(int userID, petModel pet)
        {
            petModel newPet = petDao.AddPet(userID, pet);
            return Ok(newPet);
        }
       
        */

        [HttpGet("/pet/{petID}")]
        public ActionResult<petModel> GetAPet(int petID)
        {
            petModel pet = petDao.GetPetByPetId(petID);

            if (pet == null)
            {
                return NotFound("No pet for that given ID");
            }
            else
            {
                return Ok(pet);
            }
        }

        [HttpGet("/profiles/{userID}/pets")]
        public IActionResult GetUserPets(int userID)
        {
            List<petModel> pets = petDao.GetListOfUserPets(userID);
            if (pets == null)
            {
                return NotFound("This user does not have any registered pets.");
            }
            else
            {
                return Ok(pets);
            }
        }

        [HttpGet("/pets")]
        public IActionResult GetAllThePets()
        {
            List<petModel> pets = petDao.GetListOfAllPets();
            if(pets == null)
            {
                return NotFound("There are no pets listed as this time.");
            }
            else
            {
                return Ok(pets);
            }
        }

       [HttpPut("/pets/{petID}")]
       IActionResult UpdateAPet(int petID, petModel pet)
       {
            return null;
       }

       /*

      [HttpDelete("/pets/{petID}")]
      IActionResult DeleteAPet(int userID, petModel pet)
      {

      }
      */
    }
}

