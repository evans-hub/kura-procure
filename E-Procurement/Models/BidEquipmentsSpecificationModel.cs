using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models
{
    public class BidEquipmentsSpecificationModel
    {
        public string Equipment_Type_Code { get; set; }
        public string No { get; set; }
        public string Entry_No { get; set; }
        public string Ownership_Type { get; set; }
        public string Equipment_Serial { get; set; }
        public string Equipment_Condition_Code { get; set; }
        public string Equipment_Usability_Code { get; set; }
        public decimal Qty_of_Equipment { get; set; }
        public string Description { get; set; }
        public string Years_of_Previous_Use { get; set; }
    }
}