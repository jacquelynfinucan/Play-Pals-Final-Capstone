using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;


namespace Capstone.Controllers
{
    [ApiController]
    public class PlaceController
    {
        private static string API_URL = "https://opentdb.com/api.php?amount=5&difficulty=medium&type=multiple";
        private static RestClient client = new RestClient();

        [HttpGet("/parks/{zipCode}")]
        public Location GetPlacesInZip(int zipCode)
        {
            var url = $"https://maps.googleapis.com/maps/api/place/textsearch/json?query=park+in+{zipCode}&key=AIzaSyBCEUQy7Ko99B-a-IVKJbxWkKkiqBtkjik";
            var request = new RestRequest(url);
            var response = client.Get<Location>(request);
            return response.Data;
        }





    }
}


