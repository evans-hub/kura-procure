using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models.Contractor
{
    public class MeasurementSheetModel
    {

        public string Document_Type { get; set; }
        public string Documents_No { get; set; }
        public string Payment_Certificate_Type { get; set; }
        public string Document_Date { get; set; }
        public string BankCode { get; set; }
        public string Project_ID { get; set; }
        public string Description { get; set; }
        public string Works_Start_Chainage { get; set; }
        public string Works_End_Chainage { get; set; }
        public string Contractor_Name { get; set; }
        public string Status { get; set; }
        public string Created_DateTime { get; set; }
        public string Project_Name { get; set; }
        public string Project_Start_Date { get; set; }
        public string Project_Engineer_No { get; set; }
        public string Project_Manager { get; set; }
        public string Project_Engineer_Name { get; set; }
        public string Engineer_Representative_No { get; set; }
        public string Engineer_Representative_Name { get; set; }
        public string Region_ID { get; set; }
        public string Directorate_ID { get; set; }
        public string Department_ID { get; set; }
        public string Constituency_ID { get; set; }
        public string Funding_Agency_ID { get; set; }
        public string County_ID { get; set; }
        public string Road_Section_No { get; set; }
        public string Section_End_Chainage { get; set; }
        public string Total_Section_Length_KMs { get; set; }
        public string Contractor_No { get; set; }
        public string Portal_Status { get; set; }
        public string From_Date { get; set; }
        public string To_Date { get; set; }
        public string Contract_ID { get; set; }
    }
}