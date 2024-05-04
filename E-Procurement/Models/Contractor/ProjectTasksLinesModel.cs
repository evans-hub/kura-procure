using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models.Contractor
{
    public class ProjectTasksLinesModel
    {
        public string Job_No { get; set; }
        public string Job_Task_No { get; set; }
        public string Description { get; set; }
        public string Department_Code { get; set; }
        public string Directorate_Code { get; set; }
        public string Division { get; set; }
        public string Commitments { get; set; }
        public string BankCode { get; set; }
        public string Start_Point_Km { get; set; }
        public string End_Point_Km { get; set; }
        public string Start_Date { get; set; }
        public string End_Date { get; set; }
        public string Vendor_No { get; set; }
        public string Funding_Source { get; set; }
        public string Procurement_Method { get; set; }
        public string Surface_Types { get; set; }
        public string Road_Condition { get; set; }
        public string Completed_Length_Km { get; set; }
        public string Roads_Category { get; set; }
        public string Fund_Type { get; set; }
        public string Execution_Method { get; set; }
        public string Region { get; set; }
        public string Constituency { get; set; }
        public string RoadSection { get; set; }
    }
}