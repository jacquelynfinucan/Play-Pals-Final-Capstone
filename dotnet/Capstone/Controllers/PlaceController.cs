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





    }
}


