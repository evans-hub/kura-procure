namespace E_Procurement.Models
{
    public class IfsDocumentTModel
    {
        public string Document_No { get; set; }
        public string Procurement_Document_Type_ID { get; set; }
        public string Description { get; set; }
        public string Track_Certificate_Expiry { get; set; }
        public string Requirement_Type { get; set; }
        public string Special_Group_Requirement { get; set; }
        public string Specialized_Provider_Req { get; set; }
        public string instructions { get; set; }

        //contractor
        public string prnNo { get; set; }
        public string procDocType { get; set; }
        public string ifsNo { get; set; }
        public string processArea { get; set; }
        public string filelink { get; set; }
    }
}