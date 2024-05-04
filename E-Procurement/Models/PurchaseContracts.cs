using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models
{
    public class PurchaseContracts
    {
        public string No { get; set; }
        public string Purchaseordertype { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }
        public string DocumentDate { get; set; }
        public string Amount_including_vat { get; set; }
        public string currency_code { get; set; }
        public string Amount { get; set; }
        public string Contract_Description { get; set; }
        public string Contract_Start_Date { get; set; }
        public string Contract_End_Date { get; set; }
        public string Awarded_Tender_Sum { get; set; }
        public string Location_Code { get; set; }
        public string Tender_Id { get; set; }
        public string Conttract_type { get; set; }
    }
}