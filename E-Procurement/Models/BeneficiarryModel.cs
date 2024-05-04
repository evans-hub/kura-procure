using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models
{
    public class BeneficiarryModel
    {
        public string Name { get; set; }
        public int Entry_No { get; set; }
        public string idType  { get; set; }
        public string idpassportNumber { get; set; }
        public int Phonenumber { get; set; }
        public string BeneficiaryType { get; set; }
        public string Email { get; set; }
        public decimal AllocatedShares { get; set; }
       
    }
}