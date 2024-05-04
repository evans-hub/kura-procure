using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models
{
    public class ProfileMultipleModels
    {
        public VendorModel VendorModel { get; set; }
        public IEnumerable<VendorModel> VendorModels { get; set; }
    }
}