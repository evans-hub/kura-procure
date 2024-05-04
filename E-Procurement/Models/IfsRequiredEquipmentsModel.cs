using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models
{
    public class IfsRequiredEquipmentsModel
    {
        public string Document_No { get; set; }
        public string Procurement_Document_Type_ID { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Minimum_Required_Qty { get; set; }
        public bool? Track_Certificate_Expiry { get; set; }
        public string Requirement_Type { get; set; }
        public bool? Special_Group_Requirement { get; set; }
        public bool? Specialized_Provider_Req { get; set; }        
        public bool Blocked { get; set; }
        public string Equipment_Type_Code { get; set; }
    }
}