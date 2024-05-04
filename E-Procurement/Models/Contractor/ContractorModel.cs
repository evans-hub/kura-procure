using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Procurement.Models.Contractor
{
    public class ContractorModel
    {
        public List<SelectListItem> VendorItems { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Phone_No { get; set; }
        public string Taxpin { get; set; }
        public string PIN_Number { get; set; }
        public string E_mail { get; set; }
        public string Password1 { get; set; }
        public string Password2 { get; set; }
        public string Vendor_No { get; set; }
        public string Owner_Type { get; set; }
        public string Vendor_Type { get; set; }
        public string Tax_Compliance { get; set; }
        public string RegistrationNo { get; set; }
        public string Primary_Contact_No { get; set; }
        public string Telephone_No { get; set; }
        public string No { get; set; }
        public string Supplier_Category { get; set; }
        public string Currency { get; set; }
        public string Balance { get; set; }
        public string BusinessType { get; set; }
        public int VendorType { get; set; }
        public int OwnerType { get; set; }
        public string CertofIncorporation { get; set; }
        public string DateofIncorporation { get; set; }
        public string OpsDate { get; set; }
        public string LanguageCode { get; set; }
        public string IndustryGroup { get; set; }
        public string Vision { get; set; }
        public string Mision { get; set; }
        public string PoBox { get; set; }
        public string PhysicalLocation { get; set; }
        public string PostaCode { get; set; }
        public string PostaCity { get; set; }
        public string CountryofOrigin { get; set; }
        public string WebUrl { get; set; }
        public string Fax { get; set; }
        public string HouseNo { get; set; }
        public string TelephoneNo { get; set; }
        public string FloorNo { get; set; }
        public string PlotNo { get; set; }
        public string StreetorRoad { get; set; }
        public string CompanySize { get; set; }
        public decimal NominalCap { get; set; }
        public int DealerType { get; set; }
        public decimal MaxBizValue { get; set; }
        public string MobileNo { get; set; }
        public string NatureofBz { get; set; }
        public string OrganizationalLevelCode { get; set; }
        public string VAT_Registration_No { get; set; }
        public string Supplier_Type { get; set; }
        public string Dealer_Type { get; set; }
        public string Address_2 { get; set; }
        public string Physical_location { get; set; }
        public string Signatory_Designation { get; set; }
        public string Issued_Capital { get; set; }
    }
}