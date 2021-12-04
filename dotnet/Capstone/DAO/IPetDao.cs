using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IPetDao
    {
        public petModel AddPet(int userID, petModel pet);
        public petModel GetPetByPetId(int petId);
        public List<petModel> GetListOfUserPets(int userID);
        public List<petModel> GetListOfAllPets();
        public petModel UpdatePetInfo(int petID);
    }
}
