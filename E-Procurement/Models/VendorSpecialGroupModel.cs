using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models
{
    public class VendorSpecialGroupModel
    {
        public string BankCode { get; set; }
        public string Certifcate_No { get; set; }
        public string Vendor_No { get; set; }
        public string Vendor_Category_Code { get; set; }
        public string Certifying_Agency_Code { get; set; }
        public string Products_Service_Category { get; set; }
        public string Certificate_Expiry_Date { get; set; }
        public string Certificate_Effective_Date { get; set; }
        public string End_Date { get; set; }
        public string Registered_Specia_Group { get; set; }
    }
}