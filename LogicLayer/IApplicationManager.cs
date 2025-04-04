using DataDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface IApplicationManager
    {
        public Application SelectApplicationByUserID(int userID);
        public int InsertApplication(int userID, string fullName, int age, bool renting, bool yard, string desiredBreed, string desiredGender, string preferredContact, string comment);
        public List<Application> GetAllApplications();

    }
}
