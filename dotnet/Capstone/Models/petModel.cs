using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class petModel
    {
        //Data Validation

        public string Name { get; set; }
        public int Age { get; set; }

        public bool IsMale { get; set; }
        public bool IsSpayed { get; set; }
        public int Size { get; set; }
        public string Breed { get; set; }
        public List<int> Traits;
        public string Description { get; set; }
        public int PetId { get; set; }
        public string AnimalType { get; set; }


    }
}
