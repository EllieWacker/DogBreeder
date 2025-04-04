﻿using DataAccessInterfaces;
using DataDomain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessFakes
{
    public class ApplicationAccessorFake : IApplicationAccessor
    {
        private List<DataDomain.Application> _applications;
        public ApplicationAccessorFake()
        {
            _applications = new List<DataDomain.Application>();
            _applications.Add(new DataDomain.Application() { ApplicationID = 1, UserID =1, FullName = "Clemmy", Age = 24, Renting = true, Yard = false, DesiredBreed = "aussie", DesiredGender = "Female", PreferredContact = "Phone", Comment="Great!"});
            _applications.Add(new DataDomain.Application() { ApplicationID = 1, UserID =1, FullName = "Mya",    Age = 24, Renting = true, Yard = false, DesiredBreed = "golden", DesiredGender = "Female", PreferredContact = "Email", Comment="Bad" });
        }
        public DataDomain.Application SelectApplicationByUserID(int userID)
        {
            foreach (var application in _applications)
            {
                if (application.UserID == userID)
                {
                    return application;
                }
            }
            throw new ArgumentException("Application record not found");
        }

        public int InsertApplication(int userID, string fullName, int age, bool renting, bool yard, string desiredBreed, string desiredGender, string preferredContact, string comment)
        {
            int result = 0;
            var _application = new DataDomain.Application()
            {
                UserID = userID,
                FullName = fullName,
                Age = age,
                Renting = renting,
                Yard = yard,
                DesiredBreed=desiredBreed,
                DesiredGender = desiredGender,
                PreferredContact = preferredContact,
                Comment = comment
            };

            _applications.Add(_application);
            result = _application.UserID;

            if (result == 0)
            {
                throw new ArgumentException("Unable to insert application");
            }
            return result;
        }

        public List<DataDomain.Application> SelectAllApplications()
        {

            if (_applications.Count == 0 )
            {
                throw new ArgumentException("Application record not found");
            }

            return _applications;
        }
    }
   }
