using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IProfileDao //don't forget to add dependency injection in startup.cs
    {
        Profile GetProfile(int userID);
        List<Profile> GetAllProfiles();
        Profile AddProfile(Profile profile);
    }
}
