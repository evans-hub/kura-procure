using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models
{
    public class TenderSecurityTypes
    {
        public string Security_Type { get; set; }
        public string IFS_DescriptionCode { get; set; }
        public string Description { get; set; }
        public string Nature_of_Security { get; set; }
        public string IFS_Code { get; set; }
        public string No_of_Filed_Securities { get; set; }
        public string Filed_Securities_Value_LCY { get; set; }
        public string No_of_Forfeited_Securities { get; set; }
        public string Forfeited_Securities_Value_LCY { get; set; }
        public string Released_Securities_Value_LCY { get; set; }
        public string BLocked { get; set; }
        public string Code { get; set; }
    }
}