using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models.Contractor
{
    public class ProjectWorkTasksModel
    {
        public string Document_Type { get; set; }
        public string Description { get; set; }
        public string Document_No { get; set; }
        public string Job_No { get; set; }
        public string Job_Task_No { get; set; }
        public string Scheduled_Start_Date { get; set; }
        public string Scheduled_End_Date { get; set; }
        public string Budget { get; set; }
        public string Job_Task { get; set; }
    }
}