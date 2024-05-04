using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models.Contractor
{
    public class ContractorBanksModel
    {
        public string BankCode { get; set; }
        public string Vendor_No { get; set; }
        public string BankName { get; set; }
        public string BankAccountNo { get; set; }
        public string CurrencyCode { get; set; }
        public string Contact { get; set; }
        public string Phone_No { get; set; }
        public string Bank_Branch_No { get; set; }
        public string CountryCode { get; set; }
        public string City { get; set; }
        public string Post_Code { get; set; }
    }
}