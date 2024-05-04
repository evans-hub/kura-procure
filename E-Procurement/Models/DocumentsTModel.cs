namespace E_Procurement.Models
{
    public class DocumentsTModel
    {
        public string Template_ID { get; set; }
        public string Procurement_Process { get; set; }
        public string Procurement_Document_Type { get; set; }
        //common fields
        public string Requirement_Type { get; set; }
        public string Description { get; set; }
        //ifp Documents
        public string Document_Type { get; set; }
        public string SpecialGroupRequirement { get; set; }
        public string SpecialisedRequirement { get; set; }
        public string Document_No { get; set; }
        public string Procurement_Document_Type_ID { get; set; }
        public string Tracks_Certificate_Expiry { get; set; }
        public bool HasExpiryDate { get; set; }
        public string category { get; set; }

    }
}