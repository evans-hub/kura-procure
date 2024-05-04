using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace E_Procurement.Models
{
    public class SupplierLogin
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please this is Required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please this is Required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please this is Required.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = " Please this is Required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        public System.DateTime CreatedDate { get; set; }

        public Nullable<System.DateTime> LastLoginDate { get; set; }

        public bool RememberMe { get; set; }
    }

}