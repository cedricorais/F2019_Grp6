using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CemeteryManagementSystem.Models
{
    public class TestModel
    {
        public string StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public TestModel()
        {
            StudentID = "";
            LastName = "";
            FirstName = "";
            MiddleName = "";
        }

        public TestModel(string studId, string lName, string fName, string mName)
        {
            StudentID = studId;
            LastName = lName;
            FirstName = fName;
            MiddleName = mName;
        }
    }
}