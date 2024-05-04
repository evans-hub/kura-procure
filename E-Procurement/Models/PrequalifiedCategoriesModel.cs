using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models
{
    public class PrequalifiedCategoriesModel
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
        public string Submission_End_Date { get; set; }
        public string Submission_Start_Date { get; set; }
        public string Submission_End_Time { get; set; }
        public string Submission_Start_Time { get; set; }
        public string Application_Location { get; set; }
        public string Special_Group { get; set; }
    }
}