using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models.Contractor
{
    public class ContractorDirectorsModel
    {
        public string Fullname { get; set; }
        public int Entry_No { get; set; }
        public string Nationality { get; set; }
        public decimal? OwnershipPercentage { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string IdNumber { get; set; }
        public string CitizenshipType { get; set; }
        public string PostCode { get; set; }
    }
}