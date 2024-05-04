namespace E_Procurement.Models
{
    public class RfiPrequalifcTModel
    {
        public string Document_No { get; set; }
        public string Prequalification_Category_ID { get; set; }
        public string Description { get; set; }
        public string Period_Start_Date { get; set; }
        public string Period_End_Date { get; set; }
        public bool SpecialGroupReservations { get; set; }
        public string Submission_Start_Date { get; set; }
        public string Submission_Start_Time { get; set; }
        public string Submission_End_Date { get; set; }
        public string Submission_End_Time { get; set; }
        public string Applicable_Location { get; set; }
        public string Restricted_RC_Type { get; set; }
        public string Procurement_Type { get; set; }
    }
}