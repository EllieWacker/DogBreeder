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
    public class LitterManager : ILitterManager
    {
        private ILitterAccessor _litterAccessor;

        public LitterManager()
        {
            _litterAccessor = new LitterAccessor();

        }

        public LitterManager(ILitterAccessor litterAccessor)
        {
            _litterAccessor = litterAccessor;

        }
        public Litter SelectLitterByLitterID(string litterID)
        {
            Litter litter = null;
            try
            {
                litter = _litterAccessor.SelectLitterByLitterID(litterID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Litter not found", ex);
            }
            return litter;
        }

        public List<Litter> GetAllLitters()
        {
            List<Litter> litters = new List<Litter>();
            try
            {
                litters = _litterAccessor.SelectAllLitters();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Litter list not found", ex);
            }
            return litters;
        }

    }
}
