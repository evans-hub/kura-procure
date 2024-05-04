namespace E_Procurement.Models
{
    public class IFPRequestsModel
    {
        public string Code { get; set; }
        public string PrequalificationNo { get; set; }
        public string Description { get; set; }
        public string Vendor_Representative_Name { get; set; }
        public string Vendor_Repr_Designation { get; set; }
        public string Vendor_Address { get; set; }
        public string Vendor_Address2 { get; set; }
        public string Tender_Summary { get; set; }
        public string Primary_Target_Vendor_Cluster { get; set; }
        public string Document_Date { get; set; }
        public string RFI_Documents_No { get; set; }
        public string Period_Start_Date { get; set; }
        public string Period_End_Date { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public bool Published { get; set; }
        public string Submission_Start_Date { get; set; }
        public string Submission_Start_Time { get; set; }
        public string Submission_End_Date { get; set; }
        public string Procurement_Type { get; set; }
        public string Tender_Box_Location_Code { get; set; }
        public string Created_Date_Time { get; set; }
        public string Document_Type { get; set; }
        public string External_Document_No { get; set; }
        public string Prequalified_End_Date { get; set; }
        public string Region { get; set; }
        public string constituency { get; set; }
        


        //RFI scoring Template

        public string templateType { get; set; }
        public string templateDescription { get; set; }
        public string procurementType { get; set; }
        public string bidscoringTemplate { get; set; }
        public string criteriaGroupId { get; set; }
        public string evaluationType { get; set; }
        public string totalweight { get; set; }





    }
}