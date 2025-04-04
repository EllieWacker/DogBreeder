using DataAccessInterfaces;
using DataAccessLayer;
using DataDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class PuppyManager : IPuppyManager
    {
        private IPuppyAccessor _puppyAccessor;

        public PuppyManager()
        {
            _puppyAccessor = new PuppyAccessor();

        }

        public PuppyManager(IPuppyAccessor puppyAccessor)
        {
            _puppyAccessor = puppyAccessor;

        }
        public List<Puppy> SelectPuppiesByLitterID(string litterID)
        {
            List<Puppy> puppies = new List<Puppy>();
            try
            {
                puppies = _puppyAccessor.SelectPuppiesByLitterID(litterID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Puppy list not found", ex);
            }
            return puppies;
        }

        public int UpdatePuppy(string puppyID, bool oldApprovedPuppy, bool newApprovedPuppy)
        {
            int result = 0;
            try
            {
                result = _puppyAccessor.UpdatePuppy(puppyID, oldApprovedPuppy, newApprovedPuppy);
                if (result == 0)
                {
                    throw new ApplicationException("Puppy not updated");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update failed", ex);
            }

            return result;
        }

        public List<Puppy> GetAllPuppies()
        {
            List<Puppy> puppies = new List<Puppy>();
            try
            {
                puppies = _puppyAccessor.SelectAllPuppies();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Puppy list not found", ex);
            }
            return puppies;
        }

    }
}
