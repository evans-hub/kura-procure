using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models.Contractor
{
    public class ContractsModel
    {
        public string Document_Type { get; set; }
        public string Buy_from_Vendor_No { get; set; }
        public string No { get; set; }
        public string Pay_to_Name { get; set; }
        public string Pay_to_Vendor_No { get; set; }
        public string Pay_to_Name_2 { get; set; }
        public string Pay_to_Address { get; set; }
        public string Pay_to_Address_2 { get; set; }
        public string Pay_to_Contact { get; set; }
        public string Your_Reference { get; set; }
        public string Order_Date { get; set; }
        public string Posting_Date { get; set; }
        public string Location_Code { get; set; }
        public string Region_Code { get; set; }
        public string Amount { get; set; }
        public string Amount_Including_Vat { get; set; }
        public string Constituency { get; set; }
        public string Road_Code { get; set; }
        public string Link_Name { get; set; }
        public string Works_Length { get; set; }
        public string Requisition_Product_Group { get; set; }
        public string Invatition_for_supply { get; set; }
        public string Tender_Description { get; set; }
        public string Contract_End_Date { get; set; }
        public string Contract_Start_Date { get; set; }
        public string Contract_Description { get; set; }
        public string Contract_Value { get; set; }

    }
}