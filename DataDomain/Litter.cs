using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain
{
    public class Litter
    {
        public string? LitterID { get; set; }
        public string? FatherDogID { get; set; }
        public string? MotherDogID { get; set; }
        public string? Image { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime GoHomeDate { get; set; }
        public int NumberPuppies { get; set; }
    }
}
