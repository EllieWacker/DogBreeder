﻿using DataAccessInterfaces;
using DataAccessLayer;
using DataDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class FatherDogManager : IFatherDogManager
    {
        private IFatherDogAccessor _fatherDogAccessor;

        public FatherDogManager()
        {
            _fatherDogAccessor = new FatherDogAccessor();

        }

        public FatherDogManager(IFatherDogAccessor fatherDogAccessor)
        {
            _fatherDogAccessor = fatherDogAccessor;

        }
        public FatherDog SelectFatherDogByFatherDogID(string fatherDogID)
        {
            FatherDog fatherDog = null;
            try
            {
                fatherDog = _fatherDogAccessor.SelectFatherDogByFatherDogID(fatherDogID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("FatherDog not found", ex);
            }
            return fatherDog;
        }
    }
}
