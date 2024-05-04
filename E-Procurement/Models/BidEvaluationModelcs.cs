using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models
{
    public class BidEvaluationModelcs
    {
        public int preliminary_evaluation { get; set; }
        public int technical_evaluation { get; set; }
        public int financial_evaluation { get; set; }
    }
}