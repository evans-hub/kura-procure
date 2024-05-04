using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models
{
    public class RoadsWorksProgrammeModel
    {
        public string Code { get; set; }
        public string Work_Program_Type { get; set; }
        public string Description { get; set; }
        public string Consolidated_Road_W_Program_ID { get; set; }
        public string Region_ID { get; set; }
        public string Document_Date { get; set; }
        public string Corporate_Strategic_Plan_ID { get; set; }
        public string Financial_Budget_ID { get; set; }
        public string Financial_Year_Code { get; set; }
        public string Start_Date { get; set; }
        public string End_Date { get; set; }
        public string Total_Workplanned_Length_Km { get; set; }
        public string Total_Budget_Works { get; set; }
        public string Total_Actual_Costs { get; set; }
        public string Approval_Status { get; set; }
        public string Posted { get; set; }
        public string Created_By { get; set; }
        public string Created_Time { get; set; }
        public string Created_Date { get; set; }
    }
}