using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models
{
    public class RegistrationDocumentsModel
    {
        public string Template_ID { get; set; }
        public string Procurement_Process { get; set; }
        public string Procurement_Document_Type { get; set; }
        //common fields
        public string Requirement_Type { get; set; }
        public string Description { get; set; }
        //ifp Documents
        public string Document_Type { get; set; }
        public string SpecialGroupRequirement { get; set; }
        public string SpecialisedRequirement { get; set; }
        public string Document_No { get; set; }
        public string Procurement_Document_Type_ID { get; set; }
        public string Tracks_Certificate_Expiry { get; set; }

        public string Date_Filed{ get; set; }
        public string Certificate_No { get; set; }
        public string Issue_Date { get; set; }
        public string Expiry_Date { get; set; }
        public string File_Name { get; set; }
        public string File_Type { get; set; }
        public string File_Extension { get; set; }

        public string instructions { get; set; }

        public int entryNo { get; set; }
    }
}