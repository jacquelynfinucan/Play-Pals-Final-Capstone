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
        public Location GetPlacesInZip(int zipCode)
        {
            var url = $"https://maps.googleapis.com/maps/api/place/textsearch/json?query=park+near+{zipCode}&key=AIzaSyBCEUQy7Ko99B-a-IVKJbxWkKkiqBtkjik";
            var request = new RestRequest(url);
            var response = client.Get<Location>(request);
            addPlacesToDatabase(response.Data);


            return response.Data;
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
                                         '{location.results[i].geometry[0].location.lng}'
                                         )";
                    }
                    cmdString += @") as t(location_id,location_name,latitude,longitude)
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

