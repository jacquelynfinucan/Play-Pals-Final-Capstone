using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Capstone.Models
{
    public class Location
    {
        public List<Place> results { get; set; }
    }
    public class Place
    { 
        public string place_id { get; set; }
        public string name { get; set; }
        public string formatted_address { get; set; }
        [JsonPropertyName("geometry")]
        public List<Geometry> geometry { get; set; }
    }
    public class Geometry
    {
        public Coordinates location { get; set; }
    }
    
    public class Coordinates
    {
        public double lat { get; set; }
        public double lng { get; set; }

    }
}
