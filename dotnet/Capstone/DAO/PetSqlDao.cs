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

            petModel pet = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from pet_profile where pet_id = @petId", conn);
                    cmd.Parameters.AddWithValue("@petId", petId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        pet = GetPetModelFromReader(reader);
                    }
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return pet;
        }

        public List<petModel> GetListOfUserPets(int userID)
        {
            List<petModel> pets = new List<petModel>();

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"select * from users_pets join pet_profile on users_pets.pet_id = pet_profile.pet_id
                                                     where user_id = @userID", conn);
                    cmd.Parameters.AddWithValue("@userId", userID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        petModel pet = GetPetModelFromReader(reader);
                        pets.Add(pet);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return pets;
        }

        public List<petModel> GetListOfAllPets()
        {
            List<petModel> pets = new List<petModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from pet_profile", conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        petModel pet = GetPetModelFromReader(reader);
                        pets.Add(pet);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return pets;
        }

        public petModel UpdatePetInfo(int petID)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
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

        private petModel GetPetModelFromReader(SqlDataReader reader)
        {
            petModel pet = new petModel();
            pet.Age = Convert.ToInt32(reader["age"]);
            pet.Name = Convert.ToString(reader["pet_name"]);
            pet.Size = Convert.ToInt32(reader["size"]);
            pet.Breed = Convert.ToString(reader["breed"]);
            pet.Description = Convert.ToString(reader["description"]);
            pet.IsMale = Convert.ToBoolean(reader["is_Male"]);
            pet.IsSpayed = Convert.ToBoolean(reader["is_Spayed_neutered"]);

            return pet;
        }

    }
}

//public string Name { get; set; }
//public int Age { get; set; }
//public bool IsMale { get; set; }
//public bool IsSpayed { get; set; }
//public int Size { get; set; }
//public string Breed { get; set; }
//public List<int> Traits;
//public string Description { get; set; }
