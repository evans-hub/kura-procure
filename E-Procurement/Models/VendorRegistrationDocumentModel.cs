using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models
{
    public class VendorRegistrationDocumentModel
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Global_Requirement { get; set; }
        public string SpecialGroupRequirement { get; set; }
        public string Document_No { get; set; }
        public string Special_Group_Requirement { get; set; }
         public string Contractor_Works_Requirement { get; set; }
    }
}