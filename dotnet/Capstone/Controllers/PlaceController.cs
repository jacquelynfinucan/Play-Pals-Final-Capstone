using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;

namespace Capstone.Controllers
{
    [ApiController]
    public class PlaceController
    {
        private readonly IPlaceDao PlaceDao;

        public PlaceController(IPlaceDao _placeDao)
        {
            PlaceDao = _placeDao;
        }


        private static RestClient client = new RestClient();

        [HttpGet("/parks/{zipCode}")]
        public Location GetPlacesInZip(int zipCode)
        {
            return PlaceDao.GetPlacesInZip(zipCode);
        }
        [HttpGet("/parks/{lat}/{lng}")]
        public Location GetNearbyLocations(double lat, double lng)
        {
            return PlaceDao.GetPlacesNearLocation(lat, lng);
        }

        [HttpPut("/playdates/{playdateid}/place/{placeid}")]
        public int AddPlaceId(string placeid, int playdateid)
        {
            return PlaceDao.AddPlaceIDtoPlayDate(placeid, playdateid);
        }

        [HttpGet("parks/users/{userID}")]

        public List<Park> GetAllDateLocationsForUser(int userID)
        {
            return PlaceDao.GetFullParkDateInfoFromUserID(userID);
        }



    }
}


