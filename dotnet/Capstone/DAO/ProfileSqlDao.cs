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

        private Profile GetProfileFromReader(SqlDataReader reader)
        {
            Profile profile = new Profile()
            {
                UserId = Convert.ToInt32(reader["user_id"]),
                FirstName = Convert.ToString(reader["first_name"]),
                LastName = Convert.ToString(reader["last_name"]),
                Email = Convert.ToString(reader["email"]),
                Zip = Convert.ToInt32(reader["zip_code"])
            };
            return profile;
        }

        public Profile GetProfile(int userID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT user_id, first_name, last_name, email, zip_code " +
                        "FROM dbo.user_profile WHERE user_id = @userID", conn);
                    cmd.Parameters.AddWithValue("@userID", userID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        returnProfile = GetProfileFromReader(reader);
                    }
                }
            }
            catch(SqlException)
            {
                throw;
            }
            return returnProfile;
        }

        public List<Profile> GetAllProfiles()
        {
            List<Profile> profiles = new List<Profile>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT user_id, first_name, last_name, email, zip_code FROM dbo.user_profile", conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        returnProfile = GetProfileFromReader(reader);
                        profiles.Add(returnProfile);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return profiles;
        }

        public Profile AddProfile(Profile profile)
        {
            int newProfileId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.user_profile (first_name, last_name, email, zip_code, user_id) " +
                                                    "OUTPUT INSERTED.user_id " +
                                                    "VALUES (@firstName, @lastName, @email, @zipCode, @userId)", conn);
                    cmd.Parameters.AddWithValue("@firstName", profile.FirstName);
                    cmd.Parameters.AddWithValue("@lastName",profile.LastName);
                    cmd.Parameters.AddWithValue("@email", profile.Email);
                    cmd.Parameters.AddWithValue("@zipCode", profile.Zip);
                    cmd.Parameters.AddWithValue("@userId", profile.UserId);

                    newProfileId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch(SqlException)
            {
                throw;
            }
            return GetProfile(newProfileId);
        }

        public Profile UpdateProfile(Profile profile)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE dbo.user_profile SET first_name = @firstName, last_name = @lastName, email = @email, zip_code = @zipCode " +
                                                    "WHERE user_id = @userID", conn);
                    cmd.Parameters.AddWithValue("@userID", profile.UserId);
                    cmd.Parameters.AddWithValue("@firstName", profile.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", profile.LastName);
                    cmd.Parameters.AddWithValue("@email", profile.Email);
                    cmd.Parameters.AddWithValue("@zipCode", profile.Zip);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return GetProfile(profile.UserId);
        }

        /// <summary>
        /// May not need this method
        /// </summary>
        /// <param name="userID"></param>
        public void DeleteProfile(int userID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM dbo.user_profile WHERE user_id = @userID", conn);
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

    }
}
