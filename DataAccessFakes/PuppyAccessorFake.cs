using DataAccessInterfaces;
using DataDomain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    public class PuppyAccessorFake : IPuppyAccessor
    {
        private List<Puppy> _puppies;
        public PuppyAccessorFake()
        {
            _puppies = new List<Puppy>();
            _puppies.Add(new Puppy() { PuppyID = "ALit1One", BreedID = "Aussiedoodle", LitterID="AussieLit1", MedicalRecordID="Luke1", Image = "fonzi.jpg", Gender = "Female", Adopted = false, Microchip = true, Price= 800.00m});
            _puppies.Add(new Puppy() { PuppyID = "CLit1One", BreedID = "Cockapoo", LitterID = "CockerLit1", MedicalRecordID = "Luke2", Image = "fonzi.jpg", Gender = "Male", Adopted = false, Microchip = true, Price = 900.00m });
        }

        public List<Puppy> SelectAllPuppies()
        {
            List<Puppy> puppies = new List<Puppy>();
            foreach (var puppy in _puppies)
            {
                puppies.Add(puppy);
            }
            return puppies;
        }

        public List<Puppy> SelectPuppiesByLitterID(string litterID)
        {
            List<Puppy> litterPuppies = new List<Puppy>();
            foreach (var puppy in _puppies)
            {
                if (puppy.LitterID == litterID)
                {
                    litterPuppies.Add(puppy);
                }
            }
            if (litterID.Length == 0)
            {
                throw new ArgumentException("Puppy record not found");
            }
            return litterPuppies;
        }

        public int UpdatePuppy(string puppyID, bool oldAdopted, bool newAdopted)
        {
            int count = 0;
            for (int i = 0; i < _puppies.Count(); i++)
            {
                if (_puppies[i].PuppyID == puppyID)
                {
                    _puppies[i].Adopted = newAdopted;
                    count++;
                }
            }
            if (count == 0)
            {
                throw new ArgumentException("Puppy record not found");
            }
            return count;
        }



    }
}
