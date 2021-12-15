using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Park
    {
        public string Location_id { get; set; }
        public string Location_name { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Address { get; set; }

        public Park(string location_id,string location_name, double lat, double lng, string address)
        {
            Location_id = location_id;
            Location_name = location_name;
            Lat = lat;
            Lng = lng;
            Address = address;
        }

        public List<FrontEndPlayDate> playDates { get; set; }

        

    }
}
