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

                    while (reader.Read())
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
        public List<FrontEndPlayDate> GetFrontEndPlayDatesForUserAndLocation(int hostUserId, string locationID)
        {
            var allPlayDates = new List<FrontEndPlayDate>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT location_id, play_date_id, user_profile.first_name as hostName, GuestPet.pet_name as guestPet, HostPet.pet_name as hostPet,date_time,GuestProfile.first_name as GuestName
                                                      FROM play_dates 
                                                      JOIN pet_profile as GuestPet ON GuestPet.pet_id = play_dates.guest_pet_id
                                                      JOIN pet_profile as HostPet ON HostPet.pet_id = play_dates.host_pet_id
                                                      JOIN user_profile ON play_dates.host_user_id = user_profile.user_id
                                                      JOIN users_pets on play_dates.guest_pet_id = users_pets.pet_id
                                                      JOIN user_profile as GuestProfile ON users_pets.user_id = GuestProfile.user_id
                                                      WHERE host_user_id = @host_User_Id AND location_id = @locationID
                                                      ", conn);
                    cmd.Parameters.AddWithValue("@host_User_Id", hostUserId);
                    cmd.Parameters.AddWithValue("@locationID", hostUserId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
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

        public void UpdateStatus(int playDateID,int newStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"UPDATE play_dates
                                                      SET status_id = @statusID
                                                      WHERE play_date_id = @playDateId", conn);
                    cmd.Parameters.AddWithValue("@statusID", newStatus);
                    cmd.Parameters.AddWithValue("@playDateID", playDateID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected != 1)
                    {
                        throw new Exception();
                    }
                }
            }
            catch (SqlException)
            {

                throw;
            }

        }
        public int AddAPlayDate(PlayDate newPlayDate)
        {
            int newPlayDateId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO play_dates (title, host_user_id, host_pet_id, guest_pet_id, date_time, address, status_id, location_id)" + //location is TBD**
                        "OUTPUT inserted.play_date_id " +
                        "VALUES (@title, @hostUserId, @hostPetId, @guestPetId, @dateTime, @address, 1, @locationID)", conn);
                    cmd.Parameters.AddWithValue("@title", newPlayDate.Title);
                    cmd.Parameters.AddWithValue("@hostUserId", newPlayDate.HostUserID);
                    cmd.Parameters.AddWithValue("@hostPetId", newPlayDate.HostPetID);
                    cmd.Parameters.AddWithValue("@guestPetId", newPlayDate.GuestPetID);
                    // cmd.Parameters.AddWithValue("@location", newPlayDate.location_id); //tbd-might not be in this table-have to join?-TBD**
                    cmd.Parameters.AddWithValue("@dateTime", newPlayDate.DateOfPlayDate);
                    cmd.Parameters.AddWithValue("@address", newPlayDate.Address);
                    if (newPlayDate.location_id == null)
                    {
                        cmd.Parameters.AddWithValue("@locationID", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@locationID", newPlayDate.location_id);
                    }
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

                    SqlCommand cmd = new SqlCommand(@"UPDATE dbo.play_dates SET title = @title, host_user_id = @hostUserID, address = @address, 
                        host_pet_id = @hostPetID, guest_pet_id = @guestPetID, date_time = @dateTime, location_id = @locationID 
                        WHERE play_date_id = @playDateID;", conn);
                    cmd.Parameters.AddWithValue("@title", updatedPlayDate.Title);
                    cmd.Parameters.AddWithValue("@hostUserID", updatedPlayDate.HostUserID);
                    cmd.Parameters.AddWithValue("@address", updatedPlayDate.Address);
                    cmd.Parameters.AddWithValue("@hostPetID", updatedPlayDate.HostPetID);
                    cmd.Parameters.AddWithValue("@guestPetID", updatedPlayDate.GuestPetID);
                    cmd.Parameters.AddWithValue("@dateTime", updatedPlayDate.DateOfPlayDate);
                    if (updatedPlayDate.location_id == null)
                    {
                        cmd.Parameters.AddWithValue("@locationID", DBNull.Value);
                    }
                    else {
                        cmd.Parameters.AddWithValue("@locationID", updatedPlayDate.location_id);
                    }
                    cmd.Parameters.AddWithValue("@playDateID", updatedPlayDate.PlayDateID);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 1)
                    {
                        isUpdateSuccessful = true;
                    }
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
            PlayDate playDate = new PlayDate();

            playDate.PlayDateID = Convert.ToInt32(reader["play_date_id"]);
            playDate.Title = Convert.ToString(reader["title"]);
            playDate.HostUserID = Convert.ToInt32(reader["host_user_id"]);
            playDate.HostUsername = Convert.ToString(reader["host_username"]);
            playDate.HostPetID = Convert.ToInt32(reader["host_pet_id"]);
            playDate.HostPetName = Convert.ToString(reader["host_pet_name"]);
            playDate.GuestPetID = Convert.ToInt32(reader["guest_pet_id"]);
            playDate.GuestUsername = Convert.ToString(reader["guest_username"]);
            playDate.GuestPetName = Convert.ToString(reader["guest_pet_name"]);
            playDate.DateOfPlayDate = Convert.ToDateTime(reader["date_time"]);
            playDate.Address = Convert.ToString(reader["address"]);
            playDate.StatusID = Convert.ToInt32(reader["status_id"]);

            return playDate;
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

        public List<PlayDateThread> GetPlayDateThreadsForUser(int userID)
        {
            List<PlayDateThread> playDateThreadsForUser = new List<PlayDateThread>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT PD.play_date_id, title, host_user_id, HU.username AS host_username, host_pet_id, " +
                        "HP.pet_name AS host_pet_name, guest_pet_id, GU.username AS guest_username, " +
                        "GP.pet_name AS guest_pet_name, date_time, MAX(PDM.post_date) AS latest_message_date " +
                        "FROM dbo.play_dates AS PD " +
                        "INNER JOIN dbo.users AS HU ON HU.user_id = PD.host_user_id " +
                        "INNER JOIN dbo.pet_profile AS HP ON HP.pet_id = PD.host_pet_id " +
                        "INNER JOIN dbo.pet_profile AS GP ON GP.pet_id = PD.guest_pet_id " +
                        "INNER JOIN dbo.users_pets AS GUP ON GUP.pet_id = GP.pet_id " +
                        "INNER JOIN dbo.users AS GU ON GU.user_id = GUP.user_id " +
                        "LEFT OUTER JOIN dbo.play_date_messages AS PDM on PDM.play_date_id = PD.play_date_id " +
                        "WHERE PD.host_user_id = @userID OR GU.user_id = @userID " +
                        "GROUP BY PD.play_date_id, title, host_user_id, HU.username, host_pet_id, " +
                        "HP.pet_name, guest_pet_id, GU.username, GP.pet_name, date_time " +
                        "ORDER BY latest_message_date DESC;", conn);
                    cmd.Parameters.AddWithValue("@userID", userID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        PlayDateThread playDateThread = GetPlayDateThreadsFromReader(reader);
                        playDateThreadsForUser.Add(playDateThread);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return playDateThreadsForUser;
        }

        public List<PlayDate> GetAllPlayDatesForLocation(int LocationID)
        {
            List<PlayDate> allPlayDates = new List<PlayDate>();
            PlayDate currentPlayDate;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT host_user_id, host_pet_id, guest_pet_id, date_time, location_id
                                                      FROM play_dates 
                                                      WHERE location_id = @LocationID", conn); 
                    cmd.Parameters.AddWithValue("@LocationID", LocationID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
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


        private PlayDateThread GetPlayDateThreadsFromReader(SqlDataReader reader)
        {
            PlayDateThread playDateThread = new PlayDateThread();

            playDateThread.PlayDateID = Convert.ToInt32(reader["play_date_id"]);
            playDateThread.Title = Convert.ToString(reader["title"]);
            playDateThread.HostUserID = Convert.ToInt32(reader["host_user_id"]);
            playDateThread.HostUsername = Convert.ToString(reader["host_username"]);
            playDateThread.HostPetID = Convert.ToInt32(reader["host_pet_id"]);
            playDateThread.HostPetName = Convert.ToString(reader["host_pet_name"]);
            playDateThread.GuestPetID = Convert.ToInt32(reader["guest_pet_id"]);
            playDateThread.GuestUsername = Convert.ToString(reader["guest_username"]);
            playDateThread.GuestPetName = Convert.ToString(reader["guest_pet_name"]);
            playDateThread.DateOfPlayDate = Convert.ToDateTime(reader["date_time"]);

            if (reader["latest_message_date"] == DBNull.Value)
            {
                playDateThread.LatestMessageDate = null;
            }
            else
            {
                playDateThread.LatestMessageDate = Convert.ToDateTime(reader["latest_message_date"]);
            }
            
            return playDateThread;
        }

        public PlayDateThread GetPlayDateThreadForPlayDateID(int playDateID)
        {
            PlayDateThread playDateThread = new PlayDateThread();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT PD.play_date_id, title, host_user_id, HU.username AS host_username, host_pet_id, " +
                        "HP.pet_name AS host_pet_name, guest_pet_id, GU.username AS guest_username, " +
                        "GP.pet_name AS guest_pet_name, date_time, MAX(PDM.post_date) AS latest_message_date " +
                        "FROM dbo.play_dates AS PD " +
                        "INNER JOIN dbo.users AS HU ON HU.user_id = PD.host_user_id " +
                        "INNER JOIN dbo.pet_profile AS HP ON HP.pet_id = PD.host_pet_id " +
                        "INNER JOIN dbo.pet_profile AS GP ON GP.pet_id = PD.guest_pet_id " +
                        "INNER JOIN dbo.users_pets AS GUP ON GUP.pet_id = GP.pet_id " +
                        "INNER JOIN dbo.users AS GU ON GU.user_id = GUP.user_id " +
                        "LEFT OUTER JOIN dbo.play_date_messages AS PDM on PDM.play_date_id = PD.play_date_id " +
                        "WHERE PD.play_date_id = @playDateID " +
                        "GROUP BY PD.play_date_id, title, host_user_id, HU.username, host_pet_id, " +
                        "HP.pet_name, guest_pet_id, GU.username, GP.pet_name, date_time " +
                        "ORDER BY latest_message_date DESC;", conn);
                    cmd.Parameters.AddWithValue("@playDateID", playDateID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        playDateThread = GetPlayDateThreadsFromReader(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return playDateThread;
        }

        public List<PlayDate> GetPlayDatesForUserByStatus(int userID, int statusID)
        {
            List<PlayDate> playDatesForUserByStatus = new List<PlayDate>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT PD.play_date_id, title, host_user_id, HU.username AS host_username, host_pet_id,
                        HP.pet_name AS host_pet_name, guest_pet_id, GU.username AS guest_username,
                        GP.pet_name AS guest_pet_name, date_time, address, status_id
                        FROM dbo.play_dates AS PD
                        INNER JOIN dbo.users AS HU ON HU.user_id = PD.host_user_id
                        INNER JOIN dbo.pet_profile AS HP ON HP.pet_id = PD.host_pet_id
                        INNER JOIN dbo.pet_profile AS GP ON GP.pet_id = PD.guest_pet_id
                        INNER JOIN dbo.users_pets AS GUP ON GUP.pet_id = GP.pet_id
                        INNER JOIN dbo.users AS GU ON GU.user_id = GUP.user_id
                        WHERE(PD.host_user_id = @userID OR GU.user_id = @userID) AND status_id = @statusID", conn);
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@statusID", statusID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        PlayDate playDate = GetPlayDateFromReader(reader);
                        playDatesForUserByStatus.Add(playDate);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return playDatesForUserByStatus;
        }
    }
}
