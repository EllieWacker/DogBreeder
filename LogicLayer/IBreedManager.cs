﻿using DataDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface IBreedManager
    {
        public Breed SelectBreedByBreedID(string breedID);
    }
}
