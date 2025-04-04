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
    public class LitterAccessorFake : ILitterAccessor
    {
        private List<Litter> _litters;
        public LitterAccessorFake()
        {
            _litters = new List<Litter>();
            _litters.Add(new Litter() { LitterID = "AussieLit5", FatherDogID="Harold", MotherDogID="Clemmy", Image = "lit5.jpg", DateOfBirth= new DateTime(2004, 12, 5), GoHomeDate = new DateTime(2005,2, 5) });
            _litters.Add(new Litter() { LitterID = "AussieLit6", FatherDogID = "Harold", MotherDogID = "Mya", Image = "lit6.jpg", DateOfBirth = new DateTime(2004, 12, 5), GoHomeDate = new DateTime(2005, 2, 5) });
        }

        public List<Litter> SelectAllLitters()
        {
            List<Litter> litters = new List<Litter>();
            foreach (var litter in _litters)
            {
                litters.Add(litter);
            }
            return litters;
        }

        public Litter SelectLitterByLitterID(string litterID)
        {
            foreach (var litter in _litters)
            {
                if (litter.LitterID == litterID)
                {
                    return litter;
                }
            }
            throw new ArgumentException("Litter record not found");
        }


    }
}
