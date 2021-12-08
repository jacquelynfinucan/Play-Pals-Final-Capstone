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

        public int AddPet(int userId, petModel pet)
        {
            int newPetId = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"insert into pet_profile(pet_name, breed, age, size, is_male, is_spayed_neutered, description, animal_type)
                                                    output inserted.pet_id values(@petName, @breed, @age, @size, @isMale, @isSpayedNeutered, @description, @animalType)", conn);
                    cmd.Parameters.AddWithValue("@petName", pet.Name);
                    cmd.Parameters.AddWithValue("@breed", pet.Breed);
                    cmd.Parameters.AddWithValue("@age", pet.Age);
                    cmd.Parameters.AddWithValue("@size", pet.Size);
                    cmd.Parameters.AddWithValue("@isMale", pet.IsMale);
                    cmd.Parameters.AddWithValue("@isSpayedNeutered", pet.IsSpayed);
                    cmd.Parameters.AddWithValue("@description", pet.Description);
                    cmd.Parameters.AddWithValue("@animalType", pet.AnimalType);

                    newPetId = (int)cmd.ExecuteScalar();
                    if (newPetId == 0)
                    {
                        throw new Exception();
                    }
                    cmd = new SqlCommand(@"insert into users_pets(user_id, pet_id)
                                         values (@userId, @newId)", conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@newId", newPetId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if(rowsAffected != 1)
                    {
                        throw new Exception();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return newPetId;
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
            catch (SqlException ex)
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
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"select * from pet_profile join users_pets on users_pets.pet_id = pet_profile.pet_id
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

        public bool UpdatePetInfo(int petID, petModel pet)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"update pet_profile 
                                                    set 
                                                    pet_name = @petName,
                                                    breed = @breed,
                                                    age = @age,
                                                    size = @size,
                                                    is_male = @isMale,
                                                    is_spayed_neutered = @isSpayedNeutered,
                                                    description = @description
                                                    where pet_id = @petID", conn);
                    cmd.Parameters.AddWithValue("@petName", pet.Name);
                    cmd.Parameters.AddWithValue("@breed", pet.Breed);
                    cmd.Parameters.AddWithValue("@age", pet.Age);
                    cmd.Parameters.AddWithValue("@size", pet.Size);
                    cmd.Parameters.AddWithValue("@isMale", pet.IsMale);
                    cmd.Parameters.AddWithValue("@isSpayedNeutered", pet.IsSpayed);
                    cmd.Parameters.AddWithValue("@description", pet.Description);
                    cmd.Parameters.AddWithValue("@petID", petID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeleteUserPet(int petID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"delete from users_pets
                                                    where pet_id = @petID
                                                    delete from pet_profile
                                                    where pet_id = @petID", conn);
                    cmd.Parameters.AddWithValue("@petID", petID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected != 2)
                    {
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
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
            pet.PetId = Convert.ToInt32(reader["pet_id"]);

            return pet;
        }
    }
}

