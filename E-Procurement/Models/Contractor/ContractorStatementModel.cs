using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models.Contractor
{
    public class ContractorStatementModel
    {
        public int EntryNo { get; set; }
        public string Vendor_No { get; set; }
        public string Posting_Date { get; set; }
        public string Document_Type { get; set; }
        public string Document_No { get; set; }
        public string Description { get; set; }
        public string Vendor_Name { get; set; }
        public string Amount { get; set; }
        public string Remaining_Amount { get; set; }
        public string Amount_LCY { get; set; }
        public string Bal_Account_No { get; set; }
        public string Bal_Account_Type { get; set; }
        public string Transaction_No { get; set; }
        public string Debit_Amount_LCY { get; set; }
        public string Credit_Amount_LCY { get; set; }
        public string Document_Date { get; set; }
        public string External_Document_No { get; set; }
        public string Remaining_Amt_LCY { get; set; }
    }
}