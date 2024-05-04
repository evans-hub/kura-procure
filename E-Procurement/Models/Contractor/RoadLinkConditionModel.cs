using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models.Contractor
{
    public class RoadLinkConditionModel
    {
        public string Enrty_No { get; set; }
        public string Posting_Date { get; set; }
        public string Document_No { get; set; }
        public string Road_Code { get; set; }
        public string Road_Section_No { get; set; }
        public string Pavement_Surface_Type { get; set; }
        public string Pavement_Category { get; set; }
        public string Start_Chainage { get; set; }
        public string End_Chainage { get; set; }
        public string Road_Length_Kms { get; set; }
        public string Road_Class_ID { get; set; }
        public string Constituency_ID { get; set; }
        public string County_ID { get; set; }
        public string Region_ID { get; set; }
    }
}