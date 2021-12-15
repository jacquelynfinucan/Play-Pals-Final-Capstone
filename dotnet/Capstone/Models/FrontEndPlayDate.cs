using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class FrontEndPlayDate
    {   
        public int play_date_id { get; set; }
        public string HostName { get; set; }
        public string GuestName { get; set; }
        public string GuestPet { get; set; }
        public string HostPet { get; set; }
        public DateTime DateOfPlayDate { get; set; }

        

    }
}
