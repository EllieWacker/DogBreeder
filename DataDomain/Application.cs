using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain
{
    public class Application
    {
        public int ApplicationID { get; set; }
        public int UserID { get; set; }
        public string? FullName { get; set; }
        public int Age { get; set; }
        public bool Renting { get; set; }
        public bool Yard { get; set; }
        public string? DesiredBreed { get; set; }
        public string? DesiredGender { get; set; }
        public string? PreferredContact { get; set; }
        public string? Comment { get; set; }
    }
}
