using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public int PlayDateID { get; set; }
        public int FromUserID { get; set; }
        public string FromUsername { get; set; }
        public int FromPetID { get; set; }
        public string FromPetName { get; set; }
        public DateTime PostDate { get; set; }
        public string MessageText { get; set; }
    }
}
