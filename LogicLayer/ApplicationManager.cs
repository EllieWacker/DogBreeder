using DataAccessInterfaces;
using DataAccessLayer;
using DataDomain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class ApplicationManager : IApplicationManager
    {
        private IApplicationAccessor _applicationAccessor;

        public ApplicationManager()
        {
            _applicationAccessor = new ApplicationAccessor();

        }

        public ApplicationManager(IApplicationAccessor applicationAccessor)
        {
            _applicationAccessor = applicationAccessor;

        }
        public Application SelectApplicationByUserID(int userID)
        {
            Application application = null;
            try
            {
                application = _applicationAccessor.SelectApplicationByUserID(userID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Application not found", ex);
            }
            return application;
        }

        public int InsertApplication(int userID, string fullName, int age, bool renting, bool yard, string desiredBreed, string desiredGender, string preferredContact, string comment)
        {
            int result = 0;
            try
            {
                result = _applicationAccessor.InsertApplication(userID, fullName, age, renting, yard, desiredBreed, desiredGender, preferredContact, comment);
                if (result == 0)
                {
                    throw new ApplicationException("Insert Application Failed");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Insert failed." + ex.Message, ex);
            }


            return result;
        }
        public List<Application> GetAllApplications()
        {
            List<Application> applications = null;

            try
            {
                applications = _applicationAccessor.SelectAllApplications();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not available", ex);
            }

            return applications;
        }
    }
}
