using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain
{
    public class Puppy
    {
        public string? PuppyID { get; set; }
        public string? BreedID { get; set; }
        public string? LitterID { get; set; }
        public string? MedicalRecordID { get; set; }
        public string? Image {  get; set; }
        public string? Gender { get; set; }
        public bool Adopted { get; set; }
        public bool Microchip { get; set; }
        public decimal? Price { get; set; }
    }
}
