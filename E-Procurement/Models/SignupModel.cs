using System.ComponentModel.DataAnnotations;

namespace E_Procurement.Models
{
    public class SignupModel
    {
        [Required(ErrorMessage = "Enter a Valid Supplier Name")]
        [Display(Name = "Name")]
        public string VendorName { get; set; }
        [Required(ErrorMessage = "Enter a Valid Contact Name")]
        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        [Required(ErrorMessage = "Enter a Valid Phone Number")]
        [Display(Name = "Phnenumber")]
        public string Phonenumber { get; set; }
        [Required(ErrorMessage = "Enter a Valid Tax Pin")]
        [Display(Name = "Tax Pin")]
        public string Taxpin { get; set; }
        [Required(ErrorMessage = "Enter a Valid Kra Pin")]
        [Display(Name = "Kra Pin")]
        public string KraPin { get; set; }
        [Required(ErrorMessage = "Enter a Valid Email Address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        public string Password1 { get; set; }
        public string Password2 { get; set; }
        public string IDNoorRegNo { get; set; }
    }
}