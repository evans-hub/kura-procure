using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models.Contractor
{
    public class RoadsInventoryModel
    {
        public string Road_Code { get; set; }
        public string Link_Name { get; set; }
        public string Road_Category { get; set; }
        public string Carriageway_Type { get; set; }
        public string Primary_County_ID { get; set; }
        public string Start_Chainage_KM { get; set; }
        public string End_Chainage_KM { get; set; }
        public string Gazetted_Road_Length_KMs { get; set; }
        public string No_of_Road_Sections { get; set; }
        public string General_Road_Surface_Condition { get; set; }
        public string Start_Point_Longitude { get; set; }
        public string Start_Point_Latitude { get; set; }
        public string End_Point_Longitude { get; set; }
        public string End_Point_Latitude { get; set; }
        public string Paved_Road_Length_Km { get; set; }
        public string Paved_Road_Length { get; set; }
        public string Unpaved_Road_Length { get; set; }
        public string Original_Road_Agency { get; set; }
        public string Road_Class_ID { get; set; }
    }
}