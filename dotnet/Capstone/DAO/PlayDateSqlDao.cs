using System;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public class PlayDateSqlDao : IPlayDateDao
    {
        private readonly string connectionString;

        public PlayDateSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public PlayDate GetAPlayDate(int playDateId)
        {
            PlayDate returnPlayDate = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT host_user_id, host_pet_id, guest_pet_id, date_time, location_id " + //location is TBD**
                        "FROM play_dates WHERE play_date_id = @playDateId", conn); //might have to join to get location-TBD**
                    cmd.Parameters.AddWithValue("@playDateId", playDateId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        returnPlayDate = GetPlayDateFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnPlayDate;
        }

        public List<PlayDate> GetAllPlayDates()
        {
            List<PlayDate> allPlayDates = new List<PlayDate>();
            PlayDate currentPlayDate;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT host_user_id, host_pet_id, guest_pet_id, date_time, location_id" + //location is TBD**
                        "FROM play_dates", conn); //might have to join to get location-TBD**
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        currentPlayDate = GetPlayDateFromReader(reader);
                        allPlayDates.Add(currentPlayDate);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return allPlayDates;
        }
        public List<PlayDate> GetAllPlayDatesForHost(int hostUserId)
        {
            List<PlayDate> allPlayDates = new List<PlayDate>();
            PlayDate currentPlayDate;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT host_user_id, host_pet_id, guest_pet_id, date_time, location_id " + //location is TBD**
                        "FROM play_dates WHERE host_user_id = @hostUserId", conn); //might have to join to get location-TBD**
                    cmd.Parameters.AddWithValue("@hostUserId", hostUserId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        currentPlayDate = GetPlayDateFromReader(reader);
                        allPlayDates.Add(currentPlayDate);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return allPlayDates;
        }
        public List<FrontEndPlayDate> GetFrontEndPlayDatesForHost(int hostUserId)
        {
            var allPlayDates = new List<FrontEndPlayDate>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT user_profile.first_name as hostName, GuestPet.pet_name as guestPet, HostPet.pet_name as hostPet,date_time
FROM play_dates 
JOIN pet_profile as GuestPet ON GuestPet.pet_id = play_dates.guest_pet_id
JOIN pet_profile as HostPet ON HostPet.pet_id = play_dates.host_pet_id
JOIN user_profile ON play_dates.host_user_id = user_profile.user_id
WHERE host_user_id = @host_user_id", conn);
                    cmd.Parameters.AddWithValue("@host_User_Id", hostUserId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        allPlayDates.Add(GetFrontEndPlayDateFromReader(reader));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return allPlayDates;
        }

        public int AddAPlayDate(PlayDate newPlayDate)
        {
            int newPlayDateId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO play_dates (host_user_id, host_pet_id, guest_pet_id, date_time, location)" + //location is TBD**
                        "OUTPUT inserted.play_date_id" +
                        "VALUES (@hostUserId, @hostPetId, @guestPetId, @location, @dateTime)", conn);
                    cmd.Parameters.AddWithValue("@hostUserId", newPlayDate.HostUserID);
                    cmd.Parameters.AddWithValue("@hostPetId", newPlayDate.HostPetID);
                    cmd.Parameters.AddWithValue("@guestPetId", newPlayDate.GuestPetID);
                    cmd.Parameters.AddWithValue("@location", newPlayDate.Location); //tbd-might not be in this table-have to join?-TBD**
                    cmd.Parameters.AddWithValue("@dateTime", newPlayDate.DateOfPlayDate);
                    newPlayDateId = (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return newPlayDateId;
        }

        public bool UpdateAPlayDate(PlayDate updatedPlayDate)
        {
            bool isUpdateSuccessful = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE play_dates SET host_pet_id = @hostPetId," +
                        "guest_pet_id = @guestPetId, date_time = @dateTime, location = @location)", conn); //location is TBD**
                    cmd.Parameters.AddWithValue("@hostPetId", updatedPlayDate.HostPetID);
                    cmd.Parameters.AddWithValue("@guestPetId", updatedPlayDate.GuestPetID);
                    cmd.Parameters.AddWithValue("@location", updatedPlayDate.Location); //tbd-might not be in this table-have to join?-TBD**
                    cmd.Parameters.AddWithValue("@dateTime", updatedPlayDate.DateOfPlayDate);
                    cmd.ExecuteNonQuery();
                    isUpdateSuccessful = true;
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return isUpdateSuccessful;
        }

        public bool DeleteAPlayDate(int playDateId)
        {
            bool isDeleteSuccessful = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM play_dates WHERE play_date_id = @playDateId", conn);
                    cmd.Parameters.AddWithValue("@playDateId", playDateId);
                    cmd.ExecuteNonQuery();
                    isDeleteSuccessful = true;
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return isDeleteSuccessful;
        }


        private PlayDate GetPlayDateFromReader(SqlDataReader reader)
        {
            PlayDate p = new PlayDate()
            {
                HostUserID = Convert.ToInt32(reader["host_user_id"]),
                HostPetID = Convert.ToInt32(reader["host_pet_id"]),
                GuestPetID = Convert.ToInt32(reader["guest_pet_id"]),
                //Location = Convert.ToInt32(reader["location_id"]), //convert to dynamic??-TBD
                DateOfPlayDate = Convert.ToDateTime(reader["date_time"]),
            };

            return p;
        }

        private FrontEndPlayDate GetFrontEndPlayDateFromReader(SqlDataReader reader)
        {
            var p = new FrontEndPlayDate();
            p.HostPet = (String)reader["hostPet"];
            p.GuestPet = (String)reader["guestPet"];
            p.HostName = (String)reader["hostName"];
            p.DateOfPlayDate = (DateTime)reader["date_time"];
            return p;
        }
    }
}
