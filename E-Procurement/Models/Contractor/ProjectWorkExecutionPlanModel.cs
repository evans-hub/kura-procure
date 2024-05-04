using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models.Contractor
{
    public class ProjectWorkExecutionPlanModel
    {
        public string Document_No { get; set; }
        public string Document_Date { get; set; }
        public string Commencement_Order_ID { get; set; }
        public string Project_ID { get; set; }
        public string Description { get; set; }
        public string Contractor_No { get; set; }
        public string Contractor_Name { get; set; }
        public string Project_Name { get; set; }
        public string Road_Code { get; set; }
        public string Road_Section_No { get; set; }
        public string Section_Name { get; set; }
        public string Project_Start_Date { get; set; }
        public string Region_ID { get; set; }
        public string Constituency_ID { get; set; }
        public string Directorate_ID { get; set; }
        public string Department_ID { get; set; }
        public string status { get; set; }
    }
}