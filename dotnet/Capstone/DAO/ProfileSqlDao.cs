using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Capstone.Models;

namespace Capstone.DAO
{
    public class ProfileSqlDao : IProfileDao
    {
        private readonly string connectionString;
        private Profile returnProfile = new Profile();

        public ProfileSqlDao (string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Profile GetProfile(int userID)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT profile FROM")
            }
        }

        public List<Profile> GetAllProfiles()
        {
            return profile;//remove later
        }

        public Profile AddProfile(Profile profile)
        {
            return profile;//remove later
        }

        public Profile UpdateProfile(int userID)
        {
            return profile;//remove later
        }

        public Profile DeleteProfile(int userID)
        {
            return profile;//remove later
        }
    }
}
