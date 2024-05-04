using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models.Contractor
{
    public class SharePointTModel
    {
        public string FileName { get; set; }
        public string TenderNumber { get; set; }
        public string FolderName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}