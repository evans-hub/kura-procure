using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models
{
    public class ResetPasswordModel
    {
        public string emailaddress { get; set; }
        public string oldpassword { get; set; }
        public string newpassword { get; set; }
        public string confirmpassword { get; set; }
    }
}