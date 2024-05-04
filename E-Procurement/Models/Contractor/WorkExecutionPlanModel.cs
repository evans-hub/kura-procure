using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models.Contractor
{
    public class WorkExecutionPlanModel
    {
        public string Document_No { get; set; }
        public string Document_Date { get; set; }
        public string Commencement_Order_ID { get; set; }
        public string Project_ID { get; set; }
        public string Purchase_Contract_ID { get; set; }
        public string Description { get; set; }
        public string Contractor_No { get; set; }
        public string Contractor_Name { get; set; }
        public string Project_Name { get; set; }
        public string Road_Code { get; set; }
        public string Road_Section_No { get; set; }
        public string Section_Name { get; set; }
        public string Project_Start_Date { get; set; }
        public string Project_End_Date { get; set; }
        public string Constituency_ID { get; set; }
        public string Region_ID { get; set; }
        public string Directorate_ID { get; set; }
        public string Department_ID { get; set; }
        public string Status { get; set; }
        public string Created_By { get; set; }
        public string Created_DateTime { get; set; }
    }
}