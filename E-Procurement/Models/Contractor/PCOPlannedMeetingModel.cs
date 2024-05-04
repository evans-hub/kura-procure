using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models.Contractor
{
    public class PCOPlannedMeetingModel
    {
        public string Notice_No { get; set; }
        public string Meeting_Type { get; set; }
        public string Description { get; set; }
        public string Start_Date { get; set; }
        public string Start_Time { get; set; }
        public string End_Date { get; set; }
        public string Venue_Location { get; set; }
        public string End_Time { get; set; }
    }
}