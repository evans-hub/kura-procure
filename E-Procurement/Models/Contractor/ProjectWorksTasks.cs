using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models.Contractor
{
    public class ProjectWorksTasks
    {
        public string Job_Task_No { get; set; }
        public string Job_No { get; set; }
        public string Description { get; set; }
        public string Road_Section_No { get; set; }
        public string Start_Date { get; set; }
        public string End_Date { get; set; }
        public string Start_Point_Km{ get; set; }
        public string End_Point_Km { get; set; }
        public string Road_Condition { get; set; }
        public string Completed_Length { get; set; }
        public string Roads_Category { get; set; }
        public string Surface_Type { get; set; }

    }
}