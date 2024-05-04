using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models.Contractor
{
    public class RoadLinkEnvironsModel
    {
        public string Entry_No { get; set; }
        public string Road_Environ_Category { get; set; }
        public string Description { get; set; }
        public string Road_Code { get; set; }
        public string Road_Section_No { get; set; }
        public string Connected_to_Road_Link { get; set; }
        public string Location_Details { get; set; }
        public string Road_Class_ID { get; set; }
        public string Constituency_ID { get; set; }
        public string Region_ID { get; set; }      
    }
}