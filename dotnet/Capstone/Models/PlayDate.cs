using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class PlayDate
    {
        public int PlayDateID {get;set;}
        public int HostUserID { get; set; }

        public int HostPetID { get; set; }

        public int GuestPetID { get; set; } = -1;

        //model to be created
        public dynamic Location { get; set; }

        public DateTime DateOfPlayDate { get; set; }


    }
}
