using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models
{
    public class BidResponsePersonnel
    {
        public string StaffName { get; set; }
        public string No { get; set; }
        public string Entry_No { get; set; }
        public string StaffCategory { get; set; }
        public string EmploymentType { get; set; }
        public string EmailAddress { get; set; }
        public string Profession { get; set; }
        public string ProjectRoleCode { get; set; }
        public string RequiredProfession { get; set; }
        HttpPostedFile browsedFile { get; set; }



    }
}