using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models
{
    public class PurchaseCodeLinesModel
    {
        public string Standard_Purchase_Code { get; set; }
        public string Line_No { get; set; }
        public string Type { get; set; }
        public string No { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string Amount_Excl_VAT { get; set; }
        public string Unit_of_Measure_Code { get; set; }
        public string Item_Category { get; set; }
    }
}