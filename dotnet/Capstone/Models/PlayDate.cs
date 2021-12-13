using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class PlayDate
    {
        public string title { get; set; } //required

        public int PlayDateID { get;set; } //required
        public int HostUserID { get; set; } //required
        public int HostPetID { get; set; } //required
        public int GuestPetID { get; set; } = -1;  //required

        public string Address { get; set; } //required
        public DateTime DateOfPlayDate { get; set; } //required
        public int StatusID { get; set; } //required
        public string HostUsername { get; set; }
        public string HostPetName { get; set; }
        public string GuestUsername { get; set; }
        public string GuestPetName { get; set; }
        //model to be created
        public string location_id { get; set; } 
    }

    public class PlayDateThread
    {
        public int PlayDateID { get; set; }
        public string Title { get; set; }
        public int HostUserID { get; set; }
        public string HostUsername { get; set; }
        public int HostPetID { get; set; }
        public string HostPetName { get; set; }
        public int GuestPetID { get; set; } = -1;
        public string GuestUsername { get; set; }
        public string GuestPetName { get; set; }
        //model to be created
        public string location_id { get; set; }
        public DateTime DateOfPlayDate { get; set; }
        public DateTime? LatestMessageDate { get; set; }
    }
}
