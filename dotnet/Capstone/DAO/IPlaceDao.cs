using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IPlaceDao
    {

        public Location GetPlacesInZip(int zipCode);
        public Location GetPlacesNearLocation(double lat, double lng);
        public int AddPlaceIDtoPlayDate(string placeID, int playdateID);


    }
}
