using DataDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface IPuppyManager
    {
        public List<Puppy> SelectPuppiesByLitterID(string litterID);
        public int UpdatePuppy(string puppyID, bool oldApprovedPuppy, bool newApprovedPuppy);
        public List<Puppy> GetAllPuppies();
    }
}
