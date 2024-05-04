using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models
{
    public class BidResponseInsertDataTModel
    {
        //bid witnessess model
        public string BidRespNumber { get; set; }
        public string BidderRepName { get; set; }
        public string BidderRepDesignation { get; set; }
        public string BidderRepAddress { get; set; }
        public string BidderWitnessName { get; set; }
        public string BidderWitnessDesignation { get; set; }
        public string BidderWitnessAddress { get; set; }
        public string PaymentReference { get; set; }
        public int BidderType { get; set; }
        public string TenderDocumentsSource { get; set; }
        public string JointVenture { get; set; }
        //bid preference model
        public string BidPrefAgpoCertNo { get; set; }
        public string BidPrefRespNo { get; set; }
        public string BidPrefRegisteredGrpe { get; set; }
        public string BidPrefProductServiceCat { get; set; }
        public string BidPrefAgpoCertEffDte { get; set; }
        public string BidPrefAgpoCertExpDte { get; set; }
    }
}