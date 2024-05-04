using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models
{
    public class SubmittedPrequalificationCategoriesModel
    {
        public string Evaluation_Score { get; set; }
        public string Evaluation_Decision { get; set; }
        public string Prequalification_End_Date { get; set; }
        public string Prequalification_Start_Date { get; set; }
        public string Restricted_RC_ID { get; set; }
        public string Restricted_Responsbility_Cente { get; set; }
        public string Global_RC_Prequalification { get; set; }
        public string Unique_Category_Requirements { get; set; }
        public string Special_Group_Reservation { get; set; }
        public string Vendor_No { get; set; }
        public string RFI_Document_No { get; set; }
        public string Category_Description { get; set; }
        public string Procurement_Category { get; set; }
        public string Document_No { get; set; }
        public string Document_Type { get; set; }
    }
}