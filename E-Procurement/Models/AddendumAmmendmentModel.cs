using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models
{
    public class AddendumAmmendmentModel
    {
        public string Addendum_Notice_No { get; set; }
        public int Line_No { get; set; }
        public string Amended_Section_of_Tender_Doc { get; set; }
        public string Amendment_Type { get; set; }
        public string Amendment_Description { get; set; }
    }
}