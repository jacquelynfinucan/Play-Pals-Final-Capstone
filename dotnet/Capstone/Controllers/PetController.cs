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


        [HttpPost("profiles/{userID}/pets")]
        public IActionResult AddAPetToUser(int userID, petModel pet)
        {
            int newPetID = petDao.AddPet(userID, pet);
            if(newPetID != -1)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
      
        }

        [HttpGet("/pets/{petID}")]
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
            if (pets == null)
            {
                return NotFound("There are no pets listed as this time.");
            }
            else
            {
                return Ok(pets);
            }
        }

        [HttpPut("/pets/{petID}")]
        public IActionResult UpdateAPet(int petID, petModel pet)
        {
            if (petDao.UpdatePetInfo(petID, pet))
            {
                return Ok(true);
            }
            else
            {
                return NotFound("Pet info could not be updated");
            }
        }

        [HttpDelete("/pets/{petID}")]
        public ActionResult<bool> DeleteAPet(int petID)
        {
            //petModel deletedPet = petDao.GetPetByPetId(petID);

            //if (deletedPet == null)
            //{
            //    return NotFound("Pet does not exist");
            //}

            bool result = petDao.DeleteUserPet(petID);

            if (!result)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}

