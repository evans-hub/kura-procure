using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Procurement.Models.Contractor
{
    public class RoadSectionsModel
    {
        public string Road_Section_No { get; set; }
        public string Road_Code { get; set; }
        public string Section_Name { get; set; }
        public string Road_Class_Id { get; set; }
        public string Road_Category { get; set; }
        public string CarriageAwayType { get; set; }
        public string Constituency { get; set; }
        public string County { get; set; }
        public string Region { get; set; }
        public string Start_Chainage { get; set; }
        public string End_Chainage { get; set; }
        public string Total_Road_Length { get; set; }
        public string Start_Point_Longitude { get; set; }
        public string Start_Point_Latitude { get; set; }
        public string End_Point_Longitude { get; set; }
        public string End_Point_Latitude { get; set; }
        public string Paved_Road_Lenght_Km { get; set; }
        public string Paved_Road_Length { get; set; }
        public string UnPaved_Road_Length { get; set; }
    }
}