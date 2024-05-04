using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models.Contractor
{
    public class OrderToCommenceModel
    {
        public string Notice_No { get; set; }
        public string Document_Date { get; set; }
        public string Purchase_Contract_ID { get; set; }
        public string Project_ID { get; set; }
        public string Description { get; set; }
        public string Staff_Appointment_Voucher_No { get; set; }
        public string Contractor_No { get; set; }
        public string Contractor_Name { get; set; }
        public string Vendor_Address { get; set; }
        public string Vendor_Address_2 { get; set; }
        public string Vendor_Post_Code { get; set; }
        public string Vendor_City { get; set; }
        public string Primary_E_mail { get; set; }
        public string Contract_Start_Date { get; set; }
        public string Contract_End_Date { get; set; }
        public string IFS_Code { get; set; }
        public string Tender_Name { get; set; }
        public string Project_Name { get; set; }
        public string Contract_No { get; set; }
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
        public string ScheduleStartDate { get; set; }
        public string ScheduleEndDate { get; set; }
    }
}