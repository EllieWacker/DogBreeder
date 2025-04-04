using DataDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    public interface IApplicationAccessor
    {
        Application SelectApplicationByUserID(int userID);
        int InsertApplication(int userID, string fullName, int age, bool renting, bool yard, string desiredBreed, string desiredGender, string preferredContact, string comment);

        List<Application> SelectAllApplications();
    }
}
