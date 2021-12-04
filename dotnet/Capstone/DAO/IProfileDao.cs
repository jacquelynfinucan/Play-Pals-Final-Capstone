using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IProfileDao
    {
        Profile GetProfile(int userID);
        List<Profile> GetAllProfiles();
        Profile AddProfile(Profile profile);
        Profile UpdateProfile(Profile profile);
        void DeleteProfile(int userID);
    }
}
