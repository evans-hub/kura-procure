using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models
{
    public class SubmittedTenderResponse
    {
        public string InvitationNo { get; set; }
        public string vendorNo { get; set; }
        public string VendorName { get; set; }
        public string ResponseNo { get; set; }
        public string ResponsibilityCentre { get; set; }
        public string TenderName { get; set; }
        public string status { get; set; }
        public string invitationNoticeType { get; set; }
        public string tenderDescription { get; set; }
        public string itemDescription { get; set; }
        public string itemLocation { get; set; }
        public decimal itemQuantity { get; set; }
        public decimal directunitcost { get; set; }
        public string endDate { get; set; }
        public string DocumentStatus { get; set; }
        public string BidRepName { get; set; }
        public string bidderRepDesignation { get; set; }
        public string bidderRepAddress{ get; set; }
        public string BidderWittnesName { get; set; }
        public string VAT_Registration_No { get; set; }
        public string Bidder_Witness_Designation { get; set; }
        public string Bid_Charge_LCY { get; set; }
        public string Bidder_witness_Address { get; set; }
        public string Bid_Charge_Code { get; set; }
        public string Payment_Reference_No { get; set; }
        public string BiddeType { get; set; }
        public string jointPartnerVenture { get; set; }
        public string TenderDocumentSources { get; set; }
        



    }
}