using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using RestSharp;
using System.Data.SqlClient;


namespace Capstone.DAO
{
    public class PlaceDao : IPlaceDao
    {

        private static RestClient client = new RestClient();
        private readonly string connectionString;
        public PlaceDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public int AddPlaceIDtoPlayDate(string placeID, int playdateID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    var cmdString = @"UPDATE play_dates
                                      SET location_id = @PlaceID
                                      WHERE play_date_id=@playdateID";
                    SqlCommand cmd = new SqlCommand(cmdString, conn);
                    cmd.Parameters.AddWithValue("@PlaceID", placeID);
                    cmd.Parameters.AddWithValue("@playdateID", playdateID);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public Location GetPlacesInZip(int zipCode)
        {
            var url = $"https://maps.googleapis.com/maps/api/place/textsearch/json?query=park+near+{zipCode}&key=AIzaSyBCEUQy7Ko99B-a-IVKJbxWkKkiqBtkjik";
            var request = new RestRequest(url);
            var response = client.Get<Location>(request);
            addPlacesToDatabase(response.Data);


            return response.Data;
        }

        public Location GetPlacesNearLocation(double lat, double lng)
        {
            var url = $"https://maps.googleapis.com/maps/api/place/textsearch/json?location={lat}%2C{lng}&radius=10000&type=park&key=AIzaSyBCEUQy7Ko99B-a-IVKJbxWkKkiqBtkjik";
            var request = new RestRequest(url);
            var response = client.Get<Location>(request);
            addPlacesToDatabase(response.Data);
            return response.Data;
        }

        public List<Park> GetFullParkDateInfoFromUserID(int UserID)
        {
            var listParks = GetParksWithUserPlaydates(UserID);

            foreach(Park park in listParks)
            {
                park.playDates = GetFrontEndPlayDatesForUserAndLocation(UserID, park.Location_id);
            }
            return listParks;
        }



        public List<Park> GetParksWithUserPlaydates(int UserID)
        {
            var parkList = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    var cmdString = @"SELECT location_id, location_name, latitude, longitude, formatted_address FROM location
                                      WHERE location_id in
                                       
                                      (SELECT DISTINCT location.location_id
                                       FROM play_dates
                                       JOIN location on location.location_id = play_dates.location_id
                                       JOIN users_pets on play_dates.guest_pet_id = pet_id
                                       WHERE user_id = @UserID
                                       UNION
                                       SELECT DISTINCT location.location_id
                                       FROM play_dates
                                       JOIN location on location.location_id = play_dates.location_id
                                       JOIN users_pets on play_dates.guest_pet_id = pet_id
                                       WHERE host_user_id = @UserID
                                       )";
                    SqlCommand cmd = new SqlCommand(cmdString, conn);
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    var reader = cmd.ExecuteReader();
                 
                        while (reader.Read())
                        {
                        parkList.Add(new Park(reader.GetString(0),reader.GetString(1),reader.GetDouble(2),reader.GetDouble(3),reader.GetString(4)));
                        }
                    return parkList;
                }
            }
            catch (SqlException)
            {
                throw;
            }
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
                                                      WHERE (host_user_id = @host_User_Id OR GuestProfile.user_id = @host_User_Id) AND location_id = @locationID
                                                      ", conn);
                    cmd.Parameters.AddWithValue("@host_User_Id", hostUserId);
                    cmd.Parameters.AddWithValue("@locationID", locationID);
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

        private FrontEndPlayDate GetFrontEndPlayDateFromReader(SqlDataReader reader)
        {
            var p = new FrontEndPlayDate();
            p.play_date_id = (int)reader["play_date_id"];
            p.HostPet = (String)reader["hostPet"];
            p.GuestPet = (String)reader["guestPet"];
            p.HostName = (String)reader["hostName"];
            p.GuestName = (String)reader["GuestName"];
            p.DateOfPlayDate = (DateTime)reader["date_time"];
            return p;
        }


        public int addPlacesToDatabase(Location location)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    var cmdString = @"INSERT INTO location
                                      SELECT * FROM(
                                      VALUES";
                    for (int i = 0; i < location.results.Count; i++)
                    {
                        if (i != 0) { cmdString += ", "; }
                        //edit below for additional database entries
                        cmdString += $@"(
                                         '{location.results[i].place_id}',
                                         '{location.results[i].name.Replace("'","''")}',
                                         '{location.results[i].geometry[0].location.lat}',
                                         '{location.results[i].geometry[0].location.lng}',
                                         '{location.results[i].formatted_address}'
                                         )";
                    }
                    cmdString += @") as t(location_id,location_name,latitude,longitude,formatted_address)
                                      WHERE NOT EXISTS (
                                      SELECT * FROM location
                                      WHERE t.location_id = location_id)";
                    SqlCommand cmd = new SqlCommand(cmdString,conn);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}

