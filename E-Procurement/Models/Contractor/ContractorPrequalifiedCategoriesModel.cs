using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models.Contractor
{
    public class ContractorPrequalifiedCategoriesModel
    {
        public string Entry_No { get; set; }
        public string IFP_No { get; set; }
        public string Vendor_No { get; set; }
        public string Procurement_Type { get; set; }
        public string Procurement_Category_Code { get; set; }
        public string Description { get; set; }
        public string Start_Date { get; set; }
        public string End_Date { get; set; }
        public string Block { get; set; }
        public string Date_Block { get; set; }
        public string Document_Type { get; set; }
        public string Document_No { get; set; }
        public string Posting_Date { get; set; }
    }
}