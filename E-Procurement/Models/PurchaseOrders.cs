using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models
{
    public class PurchaseOrders
    {
        public string No { get; set; }
        public string Purchaseordertype { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }
        public string DocumentDate { get; set; }
        public string Amount_including_vat { get; set; }
        public string currency_code { get; set; }
        public string Amount { get; set; }
    }
}