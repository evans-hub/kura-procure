using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models.Contractor
{
    public class PCORequredDocumentsModel
    {
        public string Notice_No { get; set; }
        public string Document_Type { get; set; }
        public string Description { get; set; }
        public string Requirement_Type { get; set; }
        public string Guidelines_Instructions { get; set; }
        public string Due_Date { get; set; }
    }
}