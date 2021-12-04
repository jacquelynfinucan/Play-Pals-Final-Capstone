using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class PetSqlDao : IPetDao
    {
        private readonly string connectionString;

        public PetSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public petModel AddPet(int userID, petModel pet)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("", conn);
                }
            }
            catch
            {

            }
            return null;
        }

        public petModel GetPetByPetId(int petId)
        {
            return null;
        }

        public List<petModel> GetListOfUserPets(int userID)
        {
            return null;
        }

    }
}
