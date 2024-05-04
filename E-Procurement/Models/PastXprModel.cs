namespace E_Procurement.Models
{
    public class PastXprModel
    {
        public string ClientName { get; set; }
        public string Address { get; set; }
        public string ProjectName { get; set; }
        public string ProjectScope { get; set; }
        public string ProjectStartDate { get; set; }
        public string ProjectEndDate { get; set; }
        public decimal? ProjectValue { get; set; }
        public string Country { get; set; }
        public string Contract_Ref { get; set; }
        public string Delivery_Location { get; set; }
        public string Assignment_Name { get; set; }
        public string Contact_Person { get; set; }
        public int Entry_No { get; set; }
    }
}