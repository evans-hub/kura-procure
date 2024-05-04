namespace E_Procurement.Models
{
    public class LitigationModel
    {
        public string DisputeDescription { get; set; }
        public string CategoryofDispute { get; set; }
        public string Year { get; set; }
        public string TheotherDisputeparty { get; set; }
        public decimal? DisputeAmount { get; set; }
        public string Thirdparty { get; set; }
        public string AwardType { get; set; }
        public string DisputeAmounts { get; set; }
        public int Entry_No { get; set; }
    }
}