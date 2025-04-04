using DataDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    public interface IPuppyAccessor
    {
        List<Puppy> SelectPuppiesByLitterID(string litterID);
        int UpdatePuppy(string puppyID, bool oldAdopted, bool newAdopted);
        List<Puppy> SelectAllPuppies();
    }
}
