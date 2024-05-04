using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models.Contractor
{
    public class WEPContractorEquipment
    {
        public string Document_Type { get; set; }
        public string Document_No { get; set; }
        public string Contractor_No { get; set; }
        public string Equipment_No { get; set; }
        public string Equipment_Type_Code { get; set; }
        public string Description { get; set; }
        public string Ownership_Type { get; set; }
        public string Equipment_Serial_No { get; set; }
        public string Equipment_Usability_Code { get; set; }
        public string Years_of_Previous_Use { get; set; }
        public string Equipment_Condition_Code { get; set; }
        public string Equipment_Availability { get; set; }
    }
}