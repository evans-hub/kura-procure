using System.Collections.Generic;
using System.Web.Mvc;

namespace E_Procurement.Models
{
    public class LanguageModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<SelectListItem> languages { get; set; }

    }

}