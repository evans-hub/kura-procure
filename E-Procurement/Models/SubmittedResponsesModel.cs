using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models
{
    public class SubmittedResponsesModel
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Tender_Summary { get; set; }
        public string Primary_Targets { get; set; }
        public string Documents_Date { get; set; }
        public string External_Document_No { get; set; }
        public string Vendor_Representative_Name { get; set; }
        public string Vendor_Repr_Designation { get; set; }
        public string Vendor_Address { get; set; }
        public string Vendor_Address_2 { get; set; }
        public string City { get; set; }
        public string Phone_No { get; set; }
        public string Country_Region_Code { get; set; }
        public string Post_Code { get; set; }
        public string E_Mail { get; set; }
        public string Special_Group_Vendor { get; set; }
        public string Special_Group_Category { get; set; }
        public string Final_Evaluation_Score { get; set; }
        public string Document_Status { get; set; }
        public string Date_Submitted { get; set; }
        public string Created_Date { get; set; }
        public string DocumentNo { get; set; }
        public string RfiDocumentNo { get; set; }
        public List<string> ProcurementCategory { get; set; }
        public string RepFullName { get; set; }
        public string RepDesignation { get; set; }
        public string RfiDocApplicationNo { get; set; }
    }
}