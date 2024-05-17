using E_Procurement.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.SharePoint.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.HtmlControls;

namespace E_Procurement.Controllers
{
    public class

        HomeController : Controller
    {
        public ClientContext SPClientContext { get; set; }

        public Web SPWeb { get; set; }

        public string SPErrorMsg { get; set; }

        public ActionResult Index()
        {

            List<TenderModel> list = new List<TenderModel>();
            try
            {

                var nav = new NavConnection().queries();
                var today = DateTime.Today;
                var result = nav.fnGetInviteTender("");
                String[] info = result.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        string[] arr = info[i].Split('*');
                        if (arr[12] != "" && arr[14] == "Open Tender" && DateTime.Parse(arr[12]) >= today)
                        {
                            TenderModel tender = new TenderModel();
                            tender.Code = arr[0];
                            tender.Procurement_Method = arr[14];
                            tender.Solicitation_Type = arr[1];
                            tender.External_Document_No = arr[2];
                            tender.Procurement_Type = arr[3];
                            tender.Procurement_Category_ID = arr[4];
                            tender.Project_ID = arr[5];
                            tender.Tender_Name = arr[6];
                            tender.Tender_Summary = arr[7];
                            tender.Description = arr[8];
                            if (arr[9] != "")
                            {
                                tender.Document_Date = DateTime.Parse(arr[9]);

                            }
                            if (arr[13] != "")
                            {
                                tender.Submission_Start_Date = DateTime.Parse(arr[13]);

                            }
                            tender.Status = arr[10];
                            tender.Name = arr[11];
                            tender.Submission_End_Date = DateTime.Parse(arr[12]);
                            tender.Published = true;
                            list.Add(tender);

                        }

                    }

                }

            }
            catch (Exception ex)
            {

                // throw ex;
            }
            return View(list);
        }

        public ActionResult Guarantee()
        {
            return View();
        }
        public ActionResult InvitationforPrequalifications()
        {

            List<IFPRequestsModel> list = new List<IFPRequestsModel>();
            try
            {

                var nav = new NavConnection().queries();
                var today = DateTime.Today;
                var result = nav.fnGetInvitationForPrequalification();
                String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        string[] arr = info[i].Split('*');
                        if (arr[0] != "" && DateTime.Parse(arr[0]) >= today && arr[12] == "Invitation For Prequalification" && arr[10] == "Released")
                        {
                            IFPRequestsModel tender = new IFPRequestsModel();
                            tender.Code = arr[1];
                            tender.Status = arr[11];
                            tender.Tender_Summary = arr[3];
                            tender.External_Document_No = arr[4];
                            tender.Procurement_Type = arr[5];
                            tender.Description = arr[2];
                            tender.Submission_Start_Date = Convert.ToString(arr[7]);
                            tender.Submission_Start_Time = arr[8];
                            tender.Document_Date = Convert.ToString(arr[9]);
                            tender.Status = arr[10];
                            tender.Name = arr[6];
                            tender.Published = true;
                            list.Add(tender);

                        }
                    }

                }




            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View(list);
        }
        private static List<TenderModel> GetActiveTenderDetail()
        {
            List<TenderModel> list = new List<TenderModel>();
            try
            {
                var nav = new NavConnection().queries();
                var today = DateTime.Today;
                var result = nav.fnGetInviteTender("");
                String[] info = result.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        string[] arr = info[i].Split('*');

                        if (arr[12] != "" && arr[14] == "Open Tender" && DateTime.Parse(arr[12]) >= today)
                        {
                            TenderModel tender = new TenderModel();
                            tender.Code = arr[0];
                            tender.Procurement_Method = arr[14];
                            tender.Solicitation_Type = arr[1];
                            tender.External_Document_No = arr[2];
                            tender.Procurement_Type = arr[3];
                            tender.Procurement_Category_ID = arr[4];
                            tender.Project_ID = arr[5];
                            tender.Tender_Name = arr[6];
                            tender.Tender_Summary = arr[7];
                            tender.Description = arr[8];
                            if (arr[9] != "")
                            {
                                tender.Document_Date = DateTime.Parse(arr[9]);

                            }
                            if (arr[13] != "")
                            {
                                tender.Submission_Start_Date = DateTime.Parse(arr[13]);

                            }
                            tender.Status = arr[10];
                            tender.Name = arr[11];
                            tender.Submission_End_Date = DateTime.Parse(arr[12]);
                            tender.Published = true;
                            list.Add(tender);

                        }
                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }
            return list;
        }

        public List<TenderModel> GetActiveTenderDetailFilter()
        {
            List<TenderModel> list = new List<TenderModel>();
            string no = ViewBag.TenderNumber != null ? ViewBag.TenderNumber.ToString() : string.Empty;
            string name = ViewBag.TenderName != null ? ViewBag.TenderName.ToString() : string.Empty;
            try
            {
                var nav = new NavConnection().queries();
                var today = DateTime.Today;
               

                //var result = nav.fnGetInviteTendersearch(no ,name );
                var result = nav.fnGetInviteTender("");
                String[] info = result.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        string[] arr = info[i].Split('*');

                        //if (arr[12] != "" && arr[14] == "Open Tender" && DateTime.Parse(arr[12]) >= today)
                        //{
                            TenderModel tender = new TenderModel();
                            tender.Code = arr[0];
                            tender.Procurement_Method = arr[14];
                            tender.Solicitation_Type = arr[1];
                            tender.External_Document_No = arr[2];
                            tender.Procurement_Type = arr[3];
                            tender.Procurement_Category_ID = arr[4];
                            tender.Project_ID = arr[5];
                            tender.Tender_Name = arr[6];
                            tender.Tender_Summary = arr[7];
                            tender.Description = arr[8];
                            //if (arr[9] != "")
                            //{
                            //    tender.Document_Date = DateTime.Parse(arr[9]);

                            //}
                            //if (arr[13] != "")
                            //{
                            //    tender.Submission_Start_Date = DateTime.Parse(arr[13]);

                            //}
                            tender.Status = arr[10];
                            tender.Name = arr[11];
                            //tender.Submission_End_Date = DateTime.Parse(arr[12]);
                            tender.Published = true;
                            list.Add(tender);

                        //}
                    }


                }

                list = list.Where(item => item.Code == no).ToList();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            return list;
        }
        [HttpGet]
        public ActionResult ViewActiveTender(string tendernumber)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<ViewActiveTenderModel> list = new List<ViewActiveTenderModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var today = DateTime.Today;
                    var result = nav.fnGetInviteTender("");
                    String[] info = result.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            string[] arr = info[i].Split('*');

                            if (arr[12] != "" && arr[14] == "Open Tender" && arr[0] == tendernumber && DateTime.Parse(arr[12]) >= today)
                            {
                                ViewActiveTenderModel tender = new ViewActiveTenderModel();
                                tender.Code = arr[0];
                                tender.Procurement_Method = arr[14];
                                tender.Solicitation_Type = arr[1];
                                tender.External_Document_No = arr[2];
                                tender.Procurement_Type = arr[3];
                                tender.Procurement_Category_ID = arr[4];
                                tender.Project_ID = arr[5];
                                tender.Tender_Name = arr[6];
                                tender.Tender_Summary = arr[7];
                                tender.Description = arr[8];
                                tender.Document_Date = arr[9];
                                tender.Status = arr[10];
                                tender.Target_Bidder_Group = arr[15];
                                tender.Name = arr[11];

                                if (arr[13] != "")
                                {
                                    tender.Submission_Start_Date = DateTime.Parse(arr[13]);

                                }
                                tender.Submission_End_Date = DateTime.Parse(arr[12]);
                                tender.Published = true;
                                list.Add(tender);
                            }

                        }
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                return View(list);
            }
        }

        public ActionResult ViewEprequalifications(string tendernumber)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                dynamic model = new ExpandoObject();
                model.SingleTenders = GetSingleTenderDetails(tendernumber);
                model.ViewTenderAddendums = GetSingleTenderAddendum(tendernumber);
                model.TenderDocument = GetRequiredTenderDocuments(tendernumber);
                model.UploadedDocument = PopulateTenderDocumentsfromSpTable(tendernumber);
                return View(model);
            }
        }
        public ActionResult NavigationMenu()
        {
            return View();
        }

        public ActionResult NavigationFooter()
        {
            return View();
        }
        [HandleError]
        public ActionResult ActiveRFQs()
        {
            if (Session["vendorNo"] == null)
            {
                RedirectToAction("Login", "Home");
            }

            List<ActiveRfqModel> list = new List<ActiveRfqModel>();
            try
            {
                var nav = new NavConnection().queries();
                string vendorNo = Session["vendorNo"].ToString();
                var today = DateTime.Today;
                var result = nav.fnGetInvitationForRFQ(vendorNo);
                String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        string[] arr = info[i].Split('*');

                        if (arr[0] != "" && DateTime.Parse(arr[0]) >= today && arr[12] == "RFQ")
                        {
                            ActiveRfqModel tender = new ActiveRfqModel();
                            tender.Code = arr[6];
                            tender.Procurement_Method = arr[12];
                            tender.Solicitation_Type = arr[1];
                            tender.External_Document_No = arr[2];
                            tender.Procurement_Type = arr[11];
                            tender.Procurement_Category_ID = arr[3];
                            tender.Project_ID = arr[4];
                            tender.Tender_Name = arr[5];
                            tender.Tender_Summary = arr[7];
                            tender.Description = arr[8];
                            if (arr[13] != "")
                            {
                                tender.Document_Date = DateTime.Parse(arr[13]);

                            }
                            if (arr[10] != "")
                            {
                                tender.Submission_Start_Date = DateTime.Parse(arr[10]);

                            }
                            tender.Status = arr[9];
                            tender.Name = arr[5];
                            tender.Submission_End_Date = DateTime.Parse(arr[0]);
                            tender.Published = true;
                            list.Add(tender);
                        }

                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View(list);
        }
        [HandleError]
        public ActionResult AppliedQuotations()
        {
            if (Session["vendorNo"] == null)
            {
                RedirectToAction("Login", "Home");
            }

            List<ActiveRfqModel> list = new List<ActiveRfqModel>();
            try
            {
                var nav = new NavConnection().queries();
                string vendorNo = Session["vendorNo"].ToString();
                var today = DateTime.Today;
                var result = nav.fnGetInvitationForRFQ(vendorNo);

                String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        string[] arr = info[i].Split('*');

                        if (arr[0] != "" && DateTime.Parse(arr[0]) >= today && arr[12] == "RFQ" && arr[14] == "Published")
                        {
                            ActiveRfqModel tender = new ActiveRfqModel();
                            tender.Code = arr[6];
                            tender.Procurement_Method = arr[12];
                            tender.Solicitation_Type = arr[1];
                            tender.External_Document_No = arr[2];
                            tender.Procurement_Type = arr[11];
                            tender.Procurement_Category_ID = arr[3];
                            tender.Project_ID = arr[4];
                            tender.Tender_Name = arr[5];
                            tender.Tender_Summary = arr[7];
                            tender.Description = arr[8];
                            if (arr[13] != "")
                            {
                                tender.Document_Date = DateTime.Parse(arr[13]);

                            }
                            if (arr[10] != "")
                            {
                                tender.Submission_Start_Date = DateTime.Parse(arr[10]);


                            }
                            tender.Status = arr[9];
                            tender.Name = arr[5];
                            tender.Submission_End_Date = DateTime.Parse(arr[0]);
                            tender.Published = true;
                            list.Add(tender);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View(list);
        }
        public ActionResult ViewSingleTender(string tendernumber)
        {
            dynamic model = new ExpandoObject();
            model.SingleTenders = GetSingleTenderDetails(tendernumber);
            model.ViewTenderAddendums = GetSingleTenderAddendum(tendernumber);
            model.TenderPurchaseLines = GetTenderPurchaseLines(tendernumber);
            model.TenderSecurity = GetBidSecurity(tendernumber);
            model.TenderEvaluationSummery = GetTenderEvaluationSummery(tendernumber);
            model.TenderDocument = GetRequiredTenderDocuments(tendernumber);
            model.TenderskeystaffDetails = GetKeyStaffTenderPersonnel(tendernumber);
            model.RequredDocuemnts = GetIFSRequiredEquipments(tendernumber);
            model.TenderEvaluationCreteria = GetTenderEvaluationCreteria(tendernumber);
            //  model.UploadedDocument = PopulateTenderDocumentsfromSpTable(tendernumber);
            return View(model);


        }
        public ActionResult DocumentsSourcesList()
        {

            List<DropdownListsModel> documentssources = new List<DropdownListsModel>();
            try
            {
                var nav = new NavConnection().queries();
                var result = nav.fnGetTenderSourceDocument();
                String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        DropdownListsModel document = new DropdownListsModel();

                        String[] arr = info[i].Split('*');
                        document.Code = arr[0];
                        document.Description = arr[1];
                        documentssources.Add(document);
                    }

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View(documentssources);
        }
        public ActionResult YearCodesList()
        {
            List<DropdownListsModel> yearcodes = new List<DropdownListsModel>();
            try
            {
                var nav = new NavConnection().queries();
                var result = nav.fnGetCalendarYearCodeList();
                String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        DropdownListsModel year = new DropdownListsModel();
                        year.Code = arr[0];
                        year.Description = arr[1];
                        yearcodes.Add(year);
                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return View(yearcodes);
        }
        public ActionResult EquipmentCategoriesLists()
        {
            List<EquipmentCategories> equipmentcategories = new List<EquipmentCategories>();
            try
            {
                var nav = new NavConnection().queries();
                var result = nav.fnGetWorkEquipmentCategories();
                String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');

                        EquipmentCategories equptype = new EquipmentCategories();
                        equptype.Code = arr[0];
                        equptype.Description = arr[1];
                        equipmentcategories.Add(equptype);
                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return View(equipmentcategories);
        }

        public ActionResult purchasecontractId()
        {
            List<PurchaseContracts> purchasecontractz = new List<PurchaseContracts>();
            try
            {
                var nav = new NavConnection().queries();
                var vendorNo = Convert.ToString(Session["vendorNo"]);
                var result = nav.fnGetPurchaseHeader("Blanket Order", "");
                String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        PurchaseContracts purchaseContractIds = new PurchaseContracts();
                        purchaseContractIds.No = arr[0];
                        purchaseContractIds.Description = arr[2];
                        purchasecontractz.Add(purchaseContractIds);

                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return View(purchasecontractz);
        }


        public ActionResult Projects()
        {
            List<jobs> jobz = new List<jobs>();
            try
            {
                var nav = new NavConnection().queries();
                var vendorNo = Convert.ToString(Session["vendorNo"]);
                var result = nav.fnGetJobs();
                String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        jobs purchaseContractIds = new jobs();
                        purchaseContractIds.projectNo = arr[0];
                        purchaseContractIds.Description = arr[1];
                        jobz.Add(purchaseContractIds);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(jobz);
        }
        public ActionResult FormOfSecurity()
        {
            List<FormOfSec> Forms = new List<FormOfSec>();
            try
            {
                var nav = new NavConnection().queries();
                var vendorNo = Convert.ToString(Session["vendorNo"]);
                var result = nav.fnGetTenderSecurityTypes("Performance/Contract Security");
                String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        FormOfSec purchaseContractIds = new FormOfSec();
                        purchaseContractIds.Code = arr[0];
                        purchaseContractIds.Description = arr[1];
                        Forms.Add(purchaseContractIds);

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(Forms);
        }

        public ActionResult ProjectRole()
        {
            List<ProjectRole> projectRole = new List<ProjectRole>();
            try
            {
                var nav = new NavConnection().queries();
                var result = nav.fnGetProjectRoleCodes();
                String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        ProjectRole equptype = new ProjectRole();
                        equptype.projectroleCode = arr[0];
                        equptype.description = arr[1];
                        projectRole.Add(equptype);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(projectRole);
        }

        public ActionResult ViewRFISpecificRequirement(string CategoryID)
        {
            List<FRISpecificRequirementModel> requirements = new List<FRISpecificRequirementModel>();
            try
            {
                var nav = new NavConnection().queries();
                var result = nav.fnGetRFICategoryRequirements(CategoryID);
                String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        FRISpecificRequirementModel category1 = new FRISpecificRequirementModel();
                        category1.Category_ID = arr[0];
                        category1.Description = arr[1];
                        category1.Requirement_Type = arr[2];
                        requirements.Add(category1);

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(requirements);
        }

        public ActionResult PrequalifiedresponsibilityCenters(string documentNo, string category)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                //   var nav = NavConnection.ReturnNav();
                var vendorNo = Convert.ToString(Session["vendorNo"]);
                dynamic model = new ExpandoObject();
                model.responsibility = responsibilitycenterdetails(documentNo, category, vendorNo);
                model.category = viewcatefories(documentNo, vendorNo);
                ViewBag.documentNo = documentNo;
                ViewBag.category = category;
                //var Categories = nav.IFPResponcRC.Where(x =>x.Document_No== documentNo && x.Procurement_Category== category && x.Vendor_No== vendorNo && x.Document_Type== "IFP Response").ToList();
                // foreach (var categorylist in Categories)
                // {
                //     RFIResponceResponsibilityCenter rc = new RFIResponceResponsibilityCenter();
                //     rc.DocumentNo = categorylist.Document_No;
                //     rc.Category_ID = categorylist.Procurement_Category;
                //     rc.ResponsibilityCenterCode = categorylist.Responsibility_Center_Code;
                //     rc.constituencyCode = categorylist.Constituency_Code;
                //     rc.Description = categorylist.Description;
                //     requirements.Add(rc);
                // }


                return View(model);
            }
            //catch (Exception e)
            //{

            //    throw;
            //}

        }

        private static List<RFIResponceResponsibilityCenter> responsibilitycenterdetails(string documentNo, string category, string vendorNo)
        {
            List<RFIResponceResponsibilityCenter> list = new List<RFIResponceResponsibilityCenter>();
            try
            {
                var nav = new NavConnection().queries();
                //string vendorNo = Session["vendorNo"].ToString();
                var request = nav.fnGetIFPResponseLineRC(documentNo, category, vendorNo, "IFP Response");
                String[] info = request.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        RFIResponceResponsibilityCenter response = new RFIResponceResponsibilityCenter();
                        response.DocumentNo = arr[0];
                        response.Category_ID = arr[1];
                        response.ResponsibilityCenterCode = arr[2];
                        response.constituencyCode = arr[3];
                        response.Description = arr[4];

                        list.Add(response);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<CategoryResponce> viewcatefories(string documentNo, string vendorNo)
        {
            List<CategoryResponce> requirements = new List<CategoryResponce>();
            try
            {
                var nav = new NavConnection().queries();
                //var vendorNo = Convert.ToString(Session["vendorNo"]);
                var result = nav.fnGetIfpResponseLine(documentNo, "", vendorNo, "");
                String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        CategoryResponce category1 = new CategoryResponce();
                        category1.categoryId = arr[2];
                        category1.categoryDescription = arr[0];
                        category1.documentNo = arr[1];

                        requirements.Add(category1);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return requirements;
        }
        public ActionResult ViewSelectedCategories(string prequalificationNo, string InvitationNumber)
        {
            List<CategoryResponce> requirements = new List<CategoryResponce>();
            try
            {
                var nav = new NavConnection().queries();
                var vendorNo = Convert.ToString(Session["vendorNo"]);
                // string inviteNo = Request.QueryString["InvitationNumber"];
                ViewBag.invitationNo = InvitationNumber;
                ViewBag.prequalificationNo = prequalificationNo;
                var result = nav.fnGetIfpResponseLine(prequalificationNo, "", vendorNo, "");
                String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        CategoryResponce category1 = new CategoryResponce();
                        category1.categoryId = arr[2];
                        category1.categoryDescription = arr[0];
                        category1.documentNo = arr[1];
                        category1.region = arr[0];
                        category1.constituency = arr[3];
                        category1.rfiNumber = arr[4];
                        requirements.Add(category1);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(requirements);
        }

        public ActionResult viewselectedCategoriesRegistration(string prequalificationNo, string InvitationNumber)
        {
            List<CategoryResponce> requirements = new List<CategoryResponce>();
            try
            {
                var nav = new NavConnection().queries();
                var vendorNo = Convert.ToString(Session["vendorNo"]);
                // string inviteNo = Request.QueryString["InvitationNumber"];
                ViewBag.invitationNo = InvitationNumber;
                ViewBag.prequalificationNo = prequalificationNo;
                var result = nav.fnGetIfpResponseLine(prequalificationNo, "", vendorNo, "");
                String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        CategoryResponce category1 = new CategoryResponce();
                        category1.categoryId = arr[2];
                        category1.categoryDescription = arr[0];
                        category1.documentNo = arr[1];
                        category1.region = arr[0];
                        category1.constituency = arr[3];
                        category1.rfiNumber = arr[4];
                        requirements.Add(category1);
                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return View(requirements);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prequalificationNo"></param>
        /// <param name="InvitationNumber"></param>
        /// <returns></returns>
        public ActionResult ViewSelectedRegistrationCategories(string prequalificationNo, string InvitationNumber)
        {
            List<CategoryResponce> requirements = new List<CategoryResponce>();
            try
            {
                var nav = new NavConnection().queries();
                var vendorNo = Convert.ToString(Session["vendorNo"]);
                // string inviteNo = Request.QueryString["InvitationNumber"];
                ViewBag.invitationNo = InvitationNumber;
                ViewBag.prequalificationNo = prequalificationNo;
                var result = nav.fnGetIfpResponseLine(prequalificationNo, "", vendorNo, "");
                String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        CategoryResponce category1 = new CategoryResponce();
                        category1.categoryId = arr[2];
                        category1.categoryDescription = arr[0];
                        category1.documentNo = arr[1];
                        category1.region = arr[0];
                        category1.constituency = arr[3];
                        category1.rfiNumber = arr[4];
                        requirements.Add(category1);
                    }
                }


            }
            catch (Exception e)
            {


                throw;
            }
            return View(requirements);
        }
        public ActionResult PrequalificationAttachedDocuments(string InvitationNumber, string prequalificationNo)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                ViewBag.prequalificationNo = prequalificationNo;
                ViewBag.invitationNo = InvitationNumber;
                if (InvitationNumber == null)
                {
                    InvitationNumber = ViewBag.invitationNo;
                }
                model.Response = ResponseDetails(InvitationNumber, vendorNo);
                model.RequiredDocuments = RequiredDocumentsDetails(InvitationNumber, vendorNo);
                model.SpecificRequiredDocuments = SpecificRequiredDocuments(InvitationNumber, vendorNo);
                model.PrequalificationUploadedDocuments = PrequalificationUploaded(prequalificationNo, vendorNo);
               // model.UploadedDocument = AttachedPrequalificationDocuments(prequalificationNo);
                //model.PrequalificationUploadedDocuments = AttachedPrequalificationDocuments(prequalificationNo);

                return View(model);
            }
        }
        public ActionResult RegistrationAttachDocuments(string InvitationNumber, string prequalificationNo)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                ViewBag.prequalificationNo = prequalificationNo;
                ViewBag.invitationNo = InvitationNumber;
                model.Response = ResponseDetails(InvitationNumber, vendorNo);
                model.RequiredDocuments = RegistrationRequiredDocumentsDetails(InvitationNumber, vendorNo);
                model.SpecificRequiredDocuments = RegistrationSpecificRequiredDocuments(InvitationNumber, vendorNo);
                model.PrequalificationUploadedDocuments = PrequalificationUploaded(prequalificationNo, vendorNo);

                return View(model);
            }
        }

        public ActionResult supplierDocuments()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.UploadedDocuments = AlreadyRegisteredDocumentsDetails(vendorNo);
                model.RequiredDocuments = RegistrationRequiredDocumentsDetails(vendorNo);

                return View(model);
            }
        }

        public ActionResult TenderRFQAttachDocument(string tenderNo, string Response)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                ViewBag.prequalificationNo = tenderNo;
                ViewBag.invitationNo = Response;
                model.RequiredDocuments = GetRequiredTenderDocuments(tenderNo);
                model.RequredDocuemnts = GetIFSRequiredEquipments(tenderNo);
                //  model.Response = RegistrationResponseDetails(tenderNo, vendorNo);
                model.BidDetails = GetBidResponseDetails(tenderNo, vendorNo);
                ViewBag.TenderNo = Response;
                model.AttachedBiddDocuments = GetBidAttachedDocumentsDetails(Response, vendorNo);


                return View(model);
            }
        }
        public ActionResult TenderAttachDocument(string tenderNo, string Response)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                ViewBag.prequalificationNo = tenderNo;
                ViewBag.invitationNo = Response;
                model.RequiredDocuments = GetRequiredTenderDocuments(tenderNo);
                model.RequredDocuemnts = GetIFSRequiredEquipments(tenderNo);
                // model.Response = RegistrationResponseDetails(tenderNo, vendorNo);
                model.BidDetails = GetBidResponseDetails(tenderNo, vendorNo);
                ViewBag.TenderNo = Response;
                model.AttachedBiddDocuments = GetBidAttachedDocumentsDetails(Response, vendorNo);
                return View(model);
            }
        }

        public ActionResult PerfGuaranteeDocAttach(string Response)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                Response = Convert.ToString(Session["Response"]);
                model.RequiredDocuments = GetRequiredContractDocs(Response);
                model.AttachedBiddDocuments = GetBidAttachedDocumentsDetails(Response, vendorNo);
                model.UploadedDocument = PopulatePerformanceDocumentsfromSpTable(Response);
                return View(model);
            }
        }
        public ActionResult RgistrationAttachedDocuments(string InvitationNumber, string prequalificationNo)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                ViewBag.prequalificationNo = prequalificationNo;
                ViewBag.invitationNo = InvitationNumber;
                model.Response = ResponseDetails(InvitationNumber, vendorNo);
                model.RequiredDocuments = RegistrationRequiredDocumentsDetails(InvitationNumber);
                model.SpecificRequiredDocuments = SpecificRequiredDocuments(InvitationNumber, vendorNo);
                model.PrequalificationUploadedDocuments = PrequalificationUploaded(prequalificationNo, vendorNo);

                return View(model);
            }
        }

        public ActionResult PastExperienceCountries()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<CountriesModel> list = new List<CountriesModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var result = nav.fnGetCountries();
                    String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            CountriesModel country = new CountriesModel();
                            country.Code = arr[0];
                            country.Name = arr[1];
                            list.Add(country);
                        }
                    }
                }
                catch (Exception e)
                {

                    throw;
                }

                return View(list);
            }

        }

        public ActionResult EditBalanceSheetYearCodeList()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<DropdownListsModel> yearcodes = new List<DropdownListsModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var result = nav.fnGetCalendarYearCodeList();
                    String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            DropdownListsModel year = new DropdownListsModel();
                            year.Code = arr[0];
                            year.Description = arr[1];
                            yearcodes.Add(year);
                        }
                    }
                }
                catch (Exception e)
                {

                    throw;
                }
                return View(yearcodes);
            }
        }
        public ActionResult EditIncomeYearCodeList()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<DropdownListsModel> yearcodes = new List<DropdownListsModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var result = nav.fnGetCalendarYearCodeList();
                    String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {

                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            DropdownListsModel year = new DropdownListsModel();
                            year.Code = arr[0];
                            year.Description = arr[1];
                            yearcodes.Add(year);
                        }
                    }

                }
                catch (Exception e)
                {

                    throw;
                }
                return View(yearcodes);
            }
        }
        public ActionResult IncomeYearCodes()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<DropdownListsModel> yearcodes = new List<DropdownListsModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var result = nav.fnGetCalendarYearCodeList();
                    String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            DropdownListsModel year = new DropdownListsModel();
                            year.Code = arr[0];
                            year.Description = arr[1];
                            yearcodes.Add(year);
                        }
                    }

                }
                catch (Exception e)
                {

                    throw;
                }
                return View(yearcodes);
            }
        }
        public ActionResult IncomeYearCodesList()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<DropdownListsModel> yearcodes = new List<DropdownListsModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var result = nav.fnGetCalendarYearCodeList();
                    String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            DropdownListsModel year = new DropdownListsModel();
                            year.Code = arr[0];
                            year.Description = arr[1];
                            yearcodes.Add(year);
                        }
                    }


                }
                catch (Exception e)
                {

                    throw;
                }
                return View(yearcodes);
            }
        }
        public ActionResult MyTransactions()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.BidDetails = GetBidResponseDetails(vendorNo);
                model.PurchaseOders = GetPurchaseOrders(vendorNo);
                model.PurchaseContracts = GetPurchaseContracts(vendorNo);
                return View(model);
            }

        }
        private static List<PurchaseContracts> GetPurchaseContracts(string vendorNo)
        {
            List<PurchaseContracts> list = new List<PurchaseContracts>();
            try
            {
                var nav = new NavConnection().queries();
                var result = nav.fnGetPurchaseHeader("Blanket Order", vendorNo);
                String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[17] == "Blanket Order")
                        {
                            PurchaseContracts contract = new PurchaseContracts();
                            contract.No = arr[0];
                            contract.DocumentDate = Convert.ToString(arr[2]);
                            contract.Purchaseordertype = arr[3];
                            contract.Region = arr[4];
                            contract.Description = arr[5];
                            contract.Amount_including_vat = Convert.ToString(arr[6]);
                            contract.Amount = Convert.ToString(arr[16]);
                            contract.Contract_Description = arr[7];
                            contract.currency_code = arr[8];
                            contract.Contract_Start_Date = Convert.ToString(arr[9]);
                            contract.Contract_End_Date = Convert.ToString(arr[10]);
                            contract.Awarded_Tender_Sum = Convert.ToString(arr[11]);
                            contract.Location_Code = arr[12];
                            contract.Tender_Id = arr[13];
                            contract.Conttract_type = arr[14];
                            contract.currency_code = arr[15];
                            list.Add(contract);
                        }

                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return list;

        }
        private static List<BidResponseDetailsModel> GetBidResponseDetails(string vendorNo)
        {

            List<BidResponseDetailsModel> list = new List<BidResponseDetailsModel>();
            try
            {
                var nav = new NavConnection().queries();
                var result = nav.fnGetPurchaseHeader("Quote", vendorNo);
                String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[17] == "Quote")
                        {
                            BidResponseDetailsModel bid = new BidResponseDetailsModel();
                            bid.No = arr[0];
                            bid.Document_Date = Convert.ToString(arr[2]);
                            bid.Bidder_type = arr[18];
                            bid.Invitation_For_Supply_No = arr[13];
                            bid.Tender_Description = arr[20];
                            bid.Tender_Name = arr[19];
                            bid.Location_Code = arr[12];
                            bid.Currency_Code = arr[15];
                            bid.Amount = Convert.ToString(arr[16]);
                            bid.Amount_Including_VAT = Convert.ToString(arr[6]);
                            bid.Document_Status = arr[21];
                            list.Add(bid);
                        }

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;

        }
        private static List<PurchaseOrders> GetPurchaseOrders(string vendorNo)
        {

            List<PurchaseOrders> list = new List<PurchaseOrders>();
            try
            {
                var nav = new NavConnection().queries();
                var result = nav.fnGetPurchaseHeader("Order", vendorNo);
                String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');

                        if (arr[17] == "Order")
                        {
                            PurchaseOrders order = new PurchaseOrders();
                            order.No = arr[0];
                            order.DocumentDate = Convert.ToString(arr[2]);
                            order.Purchaseordertype = arr[22];
                            order.Region = arr[4];
                            order.Description = arr[5];
                            order.Amount_including_vat = Convert.ToString(arr[6]);
                            order.Amount = Convert.ToString(arr[16]);
                            order.currency_code = arr[15];
                            list.Add(order);
                        }

                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        public JsonResult SubmitTenderResponse(string tendernumber)
        {
            try
            {

                var nav = new NavConnection().ObjNav();
                var vendorNo = Session["vendorNo"].ToString();
                var nav1 = new NavConnection().ObjNav();

                var status = nav.fnSubmitTenderResponse(vendorNo, tendernumber);

                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        Session["BideResponseNumber"] = nav.fngetBidResponseNumber(tendernumber, vendorNo);
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    case "found":
                        Session["BideResponseNumber"] = nav.fngetBidResponseNumber(tendernumber, vendorNo);
                        return Json("found*" + res[1], JsonRequestBehavior.AllowGet);
                    case "profileincomplete":
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult SubmitRfiResponse(RfiResponseTModel rfimodel)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();

                if (rfimodel.constituency == null)
                {
                    rfimodel.constituency = "";
                }
                if (rfimodel.registrationPeriod == null)
                {
                    rfimodel.registrationPeriod = "";
                }



                var nav = new NavConnection().ObjNav();


                var status = nav.fnPrequalificationResponseDetails(vendorNo, rfimodel.RfiDocumentNo, rfimodel.RepFullName, rfimodel.RepDesignation, rfimodel.RfiDocApplicationNo, rfimodel.Region, rfimodel.constituency, rfimodel.registrationPeriod);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult InsertResponseLines(RfiResponseTModel postData)
        {
            try
            {
                var vendorNo = Convert.ToString(Session["vendorNo"]);
                int i = 0;


                string results_0 = (dynamic)null;
                string results_1 = (dynamic)null;
                if (postData.constituency == null)
                {
                    postData.constituency = "";
                }

                List<string> AllSelectedCategoriesLists = postData.ProcurementCategory.ToList();
                //Loop and insert records.
                foreach (var iteminlist in AllSelectedCategoriesLists)
                {
                    var selectedcategory = iteminlist;
                    var nav = new NavConnection().ObjNav();
                    var status = nav.fnInsertRFIResponseLines(postData.DocumentNo, selectedcategory, postData.RfiDocumentNo, vendorNo, postData.Region, postData.constituency, 1);
                    var res = status.Split('*');
                    results_0 = res[0];
                    results_1 = res[1];
                }
                switch (results_0)
                {
                    case "success":
                        return Json("success*" + results_1, JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + results_1, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult InsertIFRResponseLines(RfiResponseTModel postData)
        {
            try
            {
                var vendorNo = Convert.ToString(Session["vendorNo"]);
                int i = 0;


                string results_0 = (dynamic)null;
                string results_1 = (dynamic)null;
                if (postData.constituency == null)
                {
                    postData.constituency = "";
                }

                List<string> AllSelectedCategoriesLists = postData.ProcurementCategory.ToList();
                //Loop and insert records.
                foreach (var iteminlist in AllSelectedCategoriesLists)
                {
                    var selectedcategory = iteminlist;
                    var nav = new NavConnection().ObjNav();
                    var status = nav.FnInsertIFRResponseLines(postData.DocumentNo, selectedcategory, postData.RfiDocumentNo, vendorNo, postData.Region, postData.constituency, 1);
                    var res = status.Split('*');
                    results_0 = res[0];
                    results_1 = res[1];
                }
                switch (results_0)
                {
                    case "success":
                        return Json("success*" + results_1, JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + results_1, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult submitResponibilityCenters(RFIResponceResponsibilityCenter responsibilitycenter)
        {
            try
            {
                var vendorNo = Convert.ToString(Session["vendorNo"].ToString());
                var nav = new NavConnection().ObjNav();

                if (responsibilitycenter.constituencyCode == null)
                {
                    responsibilitycenter.constituencyCode = "";
                }

                //string DocNo = HttpContext.Request.QueryString["documentNo"];
                // string categoryId = HttpContext.Request.QueryString["category"];


                var status = nav.fnInsertRFIResponseResponsibilityCenter(responsibilitycenter.DocumentNo, responsibilitycenter.Category_ID, vendorNo, responsibilitycenter.ResponsibilityCenterCode, responsibilitycenter.constituencyCode);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult ApplyforPreQualifc(PrequalifiedCategories postData)
        {
            var results = (dynamic)null;
            try
            {
                List<string> AllSelectedCategoriesLists = postData.AllSelectedCategories.ToList();

                foreach (var iteminlist in AllSelectedCategoriesLists)
                {

                    var selectedcategory = iteminlist;
                    var vendorNo = Session["vendorNo"].ToString();
                    var nav = new NavConnection().ObjNav();
                    var status = nav.FnApplyPreQualification(vendorNo, selectedcategory);
                    string[] info = status.Split('*');
                    results = info[0];
                    switch (info[0])
                    {
                        case "success":
                            return Json("success*" + info[1], JsonRequestBehavior.AllowGet);

                        default:
                            return Json("danger*" + info[1], JsonRequestBehavior.AllowGet);
                    }
                }

            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
            return results;
        }
        public ActionResult ViewPurchaseContract(string tendernumber)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.SingleTenders = GetSingleTenderDetails(tendernumber);
                model.TenderAddendums = GetSingleTenderAddendum(tendernumber);
                model.TenderPurchaseLines = GetTenderPurchaseLines(tendernumber);
                model.TenderSecurity = GetBidSecurity(tendernumber);
                model.TenderDocument = GetRequiredTenderDocuments(tendernumber);
                model.TenderskeystaffDetails = GetKeyStaffTenderPersonnel(tendernumber);
                model.RequredDocuemnts = GetIFSRequiredEquipments(tendernumber);
                model.TenderEvaluationCreteria = GetTenderEvaluationCreteria(tendernumber);
                return View(model);
            }

        }
        public ActionResult ViewPurchaseOrders(string tendernumber)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.SingleTenders = GetSingleTenderDetails(tendernumber);
                model.TenderAddendums = GetSingleTenderAddendum(tendernumber);
                model.TenderPurchaseLines = GetTenderPurchaseLines(tendernumber);
                model.TenderSecurity = GetBidSecurity(tendernumber);
                model.TenderDocument = GetRequiredTenderDocuments(tendernumber);
                model.TenderskeystaffDetails = GetKeyStaffTenderPersonnel(tendernumber);
                model.RequredDocuemnts = GetIFSRequiredEquipments(tendernumber);
                model.TenderEvaluationCreteria = GetTenderEvaluationCreteria(tendernumber);
                return View(model);
            }

        }
        public ActionResult ViewExpressionInterest(string tendernumber)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.SingleTenders = GetSingleTenderDetails(tendernumber);
                model.TenderAddendums = GetSingleTenderAddendum(tendernumber);
                model.TenderPurchaseLines = GetTenderPurchaseLines(tendernumber);
                model.TenderSecurity = GetBidSecurity(tendernumber);
                model.TenderDocument = GetRequiredTenderDocuments(tendernumber);
                model.TenderskeystaffDetails = GetKeyStaffTenderPersonnel(tendernumber);
                model.RequredDocuemnts = GetIFSRequiredEquipments(tendernumber);
                model.TenderEvaluationCreteria = GetTenderEvaluationCreteria(tendernumber);
                return View(model);
            }

        }
        public ActionResult ViewAwadedContracts(string tendernumber)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.SingleTenders = GetSingleTenderDetails(tendernumber);
                model.TenderAddendums = GetSingleTenderAddendum(tendernumber);
                model.TenderPurchaseLines = GetTenderPurchaseLines(tendernumber);
                model.TenderSecurity = GetBidSecurity(tendernumber);
                model.TenderDocument = GetRequiredTenderDocuments(tendernumber);
                model.TenderskeystaffDetails = GetKeyStaffTenderPersonnel(tendernumber);
                model.RequredDocuemnts = GetIFSRequiredEquipments(tendernumber);
                model.TenderEvaluationCreteria = GetTenderEvaluationCreteria(tendernumber);
                return View(model);
            }

        }
        public ActionResult TenderResponseForm(string tendernumber)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.SingleTenders = GetSingleTenderDetails(tendernumber);
                model.TenderAddendums = GetSingleTenderAddendum(tendernumber);
                model.TenderPurchaseLines = GetTenderPurchaseLines(tendernumber);
                model.TenderSecurity = GetBidSecurity(tendernumber);
                model.TenderDocument = GetRequiredTenderDocuments(tendernumber);
                model.TenderskeystaffDetails = GetKeyStaffTenderPersonnel(tendernumber);
                model.RequredDocuemnts = GetIFSRequiredEquipments(tendernumber);
                model.RequredDocuemnts = GetIFSRequiredEquipments(tendernumber);
                model.TenderEvaluationCreteria = GetTenderEvaluationCreteria(tendernumber);
                model.TenderEvaluationSummery = GetTenderEvaluationSummery(tendernumber);
                // model.UploadedDocument = PopulateTenderDocumentsfromSpTable(tendernumber);
                return View(model);
            }

        }

        [HandleError]
        public ActionResult RFQResponseForm(string tendernumber)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.SingleTenders = GetSingleRFQDetails(tendernumber);
                model.TenderPurchaseLines = GetTenderPurchaseLines(tendernumber);
                model.TenderAddendums = GetSingleTenderAddendum(tendernumber);
                model.TenderSecurity = GetBidSecurity(tendernumber);
                model.TenderDocument = GetRequiredTenderDocuments(tendernumber);
                model.RequiredDocuments = GetRequiredTenderDocuments(tendernumber);
                model.RequredDocuemnts = GetIFSRequiredEquipments(tendernumber);
                model.AttachedBiddDocuments = GetBidAttachedDocumentsDetails(tendernumber, vendorNo);
                //model.UploadedDocument = PopulateTenderDocumentsfromSpTable(tendernumber);
                return View(model);
            }

        }
        public JsonResult TenderFinancialResponse(List<Financials> finance)
        {

            var results = (dynamic)null;
            try
            {
                if (finance == null)
                {
                    finance = new List<Financials>();
                }
                foreach (Financials financedetail in finance)
                {

                    string BillNumber = financedetail.billNo;
                    decimal ResponseQuantity = 0;
                    if (financedetail.quantity > 0)
                    {
                        ResponseQuantity = financedetail.quantity;
                    }
                    decimal ResponsePrice = 0;
                    if (financedetail.price > 0)
                    {
                        ResponsePrice = financedetail.price;
                    }

                    var vendorNo = Session["vendorNo"].ToString();
                    var nav = new NavConnection().ObjNav();
                    var status = nav.fnInsertPurchaseLinesResponseDetails(vendorNo, financedetail.documentNo, financedetail.billNo, financedetail.quantity, financedetail.price);
                    var res = status.Split('*');
                    results = res[0];
                }

            }
            catch (Exception ex)
            {
                results = ex.Message;
            }
            return Json(results, JsonRequestBehavior.AllowGet);
        }


        public JsonResult FnUploadBidResponseDocumentsTender(List<prequalifiedDocuments> finance)
        {
            var results = (dynamic)null;
            try
            {
                if (finance == null)
                {
                    finance = new List<prequalifiedDocuments>();
                }
                foreach (prequalifiedDocuments financedetail in finance)
                {

                    
                    var vendorNo = Convert.ToString(Session["vendorNo"]);
                    var nav = new NavConnection().ObjNav();
                    string storedFilename = "";

                    int errCounter = 0, succCounter = 0;
                    DateTime startdate, enddate;
                    CultureInfo usCulture = new CultureInfo("es-ES");
                    
                    DateTime dtofIssue = DateTime.Now;
                    DateTime expiryDate = DateTime.Now;
                    if (financedetail.issueDate == null && financedetail.expirydate == null)
                    {
                        dtofIssue = DateTime.Parse(financedetail.issueDate, usCulture.DateTimeFormat);
                        expiryDate = DateTime.Parse(financedetail.expirydate, usCulture.DateTimeFormat);
                    }


                    if (financedetail.browsedDoc == null)
                    {
                        errCounter++;
                        return Json("danger*browsedfilenull", JsonRequestBehavior.AllowGet);
                    }

                    if (vendorNo.Contains(":"))
                        vendorNo = vendorNo.Replace(":", "[58]");
                    vendorNo = vendorNo.Replace("/", "[47]");

                    if (financedetail.procurementDocumentType.Contains("/"))
                        financedetail.procurementDocumentType = financedetail.procurementDocumentType.Replace("/", "_");
                    string desc = financedetail.description;
                    if (string.IsNullOrEmpty(desc)) {
                        desc = "";
                    }


                    FileInfo fi = new FileInfo(financedetail.browsedDoc);

                    //string fileName0 = Path.GetFileName(financedetail.browsedDoc.FileName);
                    //string ext0 = _getFileextension(financedetail.browsedDoc);
                    string fileName0 = fi.Name;
                    string ext0 = fi.Extension;
                    string savedF0 = vendorNo + "_" + fileName0 + ext0;
                    
                    //bool up2Sharepoint = _UploadSupplierTenderDocumentToSharepoint(financedetail.applicationNO, financedetail.browsedDoc, financedetail.procurementDocumentType);
                    //if (up2Sharepoint == true)
                    //{

                        string filename = vendorNo + "_" + fileName0;
                        string sUrl = ConfigurationManager.AppSettings["FilesLocation"];
                        string defaultlibraryname = "Procurement%20Documents/";
                        string customlibraryname = "Tender Bid Reponses";
                        string sharepointLibrary = defaultlibraryname + customlibraryname;
                        financedetail.applicationNO = financedetail.applicationNO.Replace('/', '_');
                        financedetail.applicationNO = financedetail.applicationNO.Replace(':', '_');
                        //Sharepoint File Link
                        
                        string sharepointlink = sUrl + sharepointLibrary + "/" + financedetail.applicationNO + "/" + filename;
                    
                        if (financedetail.certificateNo == null)
                        {
                            financedetail.certificateNo = "";
                        }

                        // string fsavestatus = nav.FnInsertBidReponseDocuments(vendorNo, typauploadselect, filedescription, certificatenumber, dtofIssue, expiryDate, filename, BidResponseNumber);

                        string fsavestatus = nav.fnInsertBidReponseDocuments(vendorNo, financedetail.procurementDocumentType, desc, financedetail.certificateNo, dtofIssue, expiryDate, filename, financedetail.applicationNO, sharepointlink);
                        var splitanswer = fsavestatus.Split('*');
                        results = splitanswer[0];
                        //switch (splitanswer[0])
                        //{
                        //    case "success":
                        //        return Json("success*" + succCounter, JsonRequestBehavior.AllowGet);
                        //    default:
                        //        return Json("danger*" + succCounter, JsonRequestBehavior.AllowGet);
                        //}
                    //}
                    //else
                    //{
                    //    return Json("sharepointError*", JsonRequestBehavior.AllowGet);
                    //}
                }
            }
            catch (Exception ex)
            {
                results = ex.Message;
            }
            return Json(results, JsonRequestBehavior.AllowGet);
        }
        public JsonResult RFQFinancialResponse(List<Financials> finance)
        {

            var results = (dynamic)null;
            try
            {
                if (finance == null)
                {
                    finance = new List<Financials>();
                }
                foreach (Financials financedetail in finance)
                {

                    string BillNumber = financedetail.billNo;
                    decimal ResponsePrice = 0;
                    if (financedetail.price > 0)
                    {
                        ResponsePrice = financedetail.price;
                    }
                    var vendorNo = Session["vendorNo"].ToString();
                    var nav = new NavConnection().ObjNav();
                    var status = nav.fnInsertPurchaseLinesResponseRFQDetails(vendorNo, financedetail.documentNo, financedetail.billNo, financedetail.price);
                    var res = status.Split('*');
                    results = res[0];
                }

            }
            catch (Exception ex)
            {
                results = ex.Message;
            }
            return Json(results, JsonRequestBehavior.AllowGet);
        }
        private static List<TenderEvalCriteriaModel> GetTenderEvaluationCreteria(string tendernumber)
        {

            List<TenderEvalCriteriaModel> list = new List<TenderEvalCriteriaModel>();
            try
            {
                var nav = new NavConnection().queries();
                var today = DateTime.Today;

                var BidTemplateID = "";
                var result = nav.fnGetInviteTender("");
                String[] info = result.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        //  && DateTime.Parse(arr[12]) >= today
                        if (arr[14] == "Open Tender" && arr[0] == tendernumber)
                        {
                            BidTemplateID = arr[16];
                            if (BidTemplateID != null)
                            {
                                var query = nav.fnGetBidScoringTemplate(BidTemplateID);
                                String[] info1 = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                                if (info1 != null)
                                {
                                    for (int j = 0; j < info1.Length; j++)
                                    {
                                        String[] arr1 = info1[j].Split('*');
                                        TenderEvalCriteriaModel template = new TenderEvalCriteriaModel();
                                        template.Code = arr1[0];
                                        template.Template_type = arr1[1];
                                        template.Document_No = arr1[2];
                                        template.Description = arr1[3];
                                        template.Default_Procurement_Type = arr1[5];
                                        template.Total_Preliminary_Checks_Score = Convert.ToString(arr1[6]);
                                        template.Total_Technical_Evaluation = Convert.ToString(arr1[7]);
                                        template.Total_Financial_Evaluation = Convert.ToString(arr1[8]);
                                        template.Total_Assigned_Score_Weight = Convert.ToString(arr1[14]);
                                        template.Default_YES_Bid_Rating_Score = Convert.ToString(arr1[4]);
                                        template.NO_Bid_Rating_Response_Value = arr1[15];
                                        template.V1_POOR_Option_Text_Bid_Score = Convert.ToString(arr1[9]);
                                        template.V3_GOOD_Option_Text_Bid_Score = Convert.ToString(arr1[11]);
                                        template.V2_FAIR_Option_Text_Bid_Score = Convert.ToString(arr1[10]);
                                        template.V4_VERY_GOOD_Text_Bid_Score = Convert.ToString(arr1[12]);
                                        template.V5_EXCELLENT_Text_Bid_Score = Convert.ToString(arr1[13]);
                                        list.Add(template);
                                    }
                                }

                            }

                        }
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<TenderEvalCriteriaModel> GetTenderEvaluationSummery(string tendernumber)
        {

            List<TenderEvalCriteriaModel> list = new List<TenderEvalCriteriaModel>();
            try
            {
                var nav = new NavConnection().queries();
                var today = DateTime.Today;
                var result = nav.fnGetInviteTender("");
                var BidTemplateID = "";
                String[] info = result.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');

                        if (arr[12] != "" && arr[14] == "Open Tender" && arr[0] == tendernumber && DateTime.Parse(arr[12]) >= today)
                        {
                            BidTemplateID = arr[16];
                            if (BidTemplateID != null)
                            {
                                var request = nav.fnGetBidScoreRequirements(BidTemplateID);
                                String[] requestInfo = request.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                                if (requestInfo != null)
                                {
                                    for (int j = 0; j < requestInfo.Length; j++)
                                    {
                                        String[] arr1 = requestInfo[j].Split('*');
                                        Debug.WriteLine("Bid score  requirements: ", arr1);
                                        TenderEvalCriteriaModel template = new TenderEvalCriteriaModel();
                                        template.Code = arr1[0];
                                        template.EvaluationType = arr1[1];
                                        template.EvaluationRequirement = arr1[2];
                                        template.requirementType = arr1[3];
                                        template.contractRefClause = arr1[4];

                                        list.Add(template);
                                    }
                                }
                            }
                        }


                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<IfsRequiredEquipmentsModel> GetIFSRequiredEquipments(string tendernumber)
        {
            List<IfsRequiredEquipmentsModel> list = new List<IfsRequiredEquipmentsModel>();
            try
            {
                var nav = new NavConnection().queries();
                var request = nav.fnGetIFSRequiredEquipment(tendernumber);
                String[] info = request.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        IfsRequiredEquipmentsModel document = new IfsRequiredEquipmentsModel();
                        document.Document_No = arr[0];
                        document.Equipment_Type_Code = arr[1];
                        document.Procurement_Document_Type_ID = Convert.ToString(arr[1]);
                        document.Description = arr[2];
                        document.Category = arr[3];
                        document.Minimum_Required_Qty = Convert.ToString(arr[4]);
                        list.Add(document);
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return list;
        }
        private static List<TenderKeyStaffModel> GetBidKeyStaff(string tendernumber)
        {
            List<TenderKeyStaffModel> list = new List<TenderKeyStaffModel>();
            try
            {

                var nav = new NavConnection().queries();
                var query = nav.fnGetBidStaff(tendernumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        TenderKeyStaffModel staff = new TenderKeyStaffModel();
                        staff.IFS_Code = tendernumber;
                        staff.Staff_Role_Code = Convert.ToString(arr[0]);
                        staff.Title_Designation_Description = arr[1];
                        staff.Min_No_of_Recomm_Staff = Convert.ToString(arr[2]);
                        staff.Requirement_Type = arr[3];
                        staff.Staff_Category = arr[4];
                        list.Add(staff);

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<TenderKeyStaffModel> GetKeyStaffTenderPersonnel(string tendernumber)
        {
            List<TenderKeyStaffModel> list = new List<TenderKeyStaffModel>();
            try
            {

                var nav = new NavConnection().queries();
                var query = nav.fnGetIFSKeyStaff(tendernumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        TenderKeyStaffModel staff = new TenderKeyStaffModel();
                        staff.IFS_Code = tendernumber;
                        staff.Staff_Role_Code = Convert.ToString(arr[0]);
                        staff.Title_Designation_Description = arr[1];
                        staff.Min_No_of_Recomm_Staff = Convert.ToString(arr[2]);
                        staff.Requirement_Type = arr[3];
                        staff.Staff_Category = arr[4];
                        list.Add(staff);

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<IfsDocumentTModel> GetRequiredTenderDocuments(string tendernumber)
        {
            List<IfsDocumentTModel> list = new List<IfsDocumentTModel>();
            try
            {
                var nav = new NavConnection().queries();
                var result = nav.fnGetIfsRequiredDocs(tendernumber);
                String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        IfsDocumentTModel document = new IfsDocumentTModel();
                        document.Document_No = arr[0];
                        document.Procurement_Document_Type_ID = Convert.ToString(arr[1]);
                        document.Description = arr[2];
                        document.Track_Certificate_Expiry = Convert.ToString(arr[3]);
                        document.instructions = arr[4];
                        if (document.Track_Certificate_Expiry == "True")
                        {

                            document.Track_Certificate_Expiry = "Yes";
                        }
                        else
                        {
                            document.Track_Certificate_Expiry = "No";
                        }
                        document.Requirement_Type = arr[5];
                        document.Special_Group_Requirement = Convert.ToString(arr[6]);
                        document.Specialized_Provider_Req = Convert.ToString(arr[7]);
                        list.Add(document);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }


        private static List<IfsDocumentTModel> GetRequiredContractDocs(string tendernumber)
        {
            List<IfsDocumentTModel> list = new List<IfsDocumentTModel>();
            try
            {

                var nav = new NavConnection().queries();
                var result = nav.fnGetContractRequirements(tendernumber);
                String[] info = result.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        IfsDocumentTModel document = new IfsDocumentTModel();
                        document.Document_No = arr[0];
                        document.Procurement_Document_Type_ID = Convert.ToString(arr[1]);
                        document.Description = arr[2];
                        document.Track_Certificate_Expiry = Convert.ToString(arr[3]);
                        document.prnNo = arr[4];
                        document.ifsNo = arr[5];
                        document.processArea = arr[6];
                        document.instructions = arr[7];
                        if (document.Track_Certificate_Expiry == "True")
                        {

                            document.Track_Certificate_Expiry = "Yes";
                        }
                        else
                        {
                            document.Track_Certificate_Expiry = "No";
                        }
                        document.Requirement_Type = arr[8];

                        list.Add(document);

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<PurchaseCodeLinesModel> GetTenderPurchaseLines(string tendernumber)
        {
            List<PurchaseCodeLinesModel> list = new List<PurchaseCodeLinesModel>();
            try
            {

                var nav = new NavConnection().queries();
                var query = nav.fnGetStandardPurchaseLine(tendernumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        PurchaseCodeLinesModel items = new PurchaseCodeLinesModel();
                        items.Standard_Purchase_Code = arr[0];
                        items.Line_No = Convert.ToString(arr[1]);
                        items.Type = arr[2];
                        items.No = arr[3];
                        items.Description = arr[4];
                        items.Quantity = Convert.ToString(arr[5]);
                        items.Amount_Excl_VAT = Convert.ToString(arr[6]);
                        items.Unit_of_Measure_Code = arr[8];
                        items.Item_Category = arr[7];
                        list.Add(items);
                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<BidSecurityModel> GetBidSecurity(string tendernumber)
        {
            List<BidSecurityModel> list = new List<BidSecurityModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetIFSSecurity(tendernumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BidSecurityModel security = new BidSecurityModel();
                        security.IFS_Code = tendernumber;
                        security.Form_of_Security = Convert.ToString(arr[0]);
                        security.Security_Type = arr[1];
                        security.Required_at_Bid_Submission = Convert.ToString(arr[2]);
                        security.Description = arr[3];
                        security.Security_Amount_LCY = Convert.ToString(arr[4]);
                        security.Bid_Security_Validity_Expiry = Convert.ToString(arr[5]);
                        security.Nature_of_Security = arr[6];
                        list.Add(security);

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<SingleTenderModel> GetSingleTenderDetails(string tendernumber)
        {
            List<SingleTenderModel> list = new List<SingleTenderModel>();
            try
            {
                var nav = new NavConnection().queries();
                var today = DateTime.Today;
                var query = nav.fnGetInviteTender(tendernumber);
                String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        Debug.WriteLine(info[i]);
                        String[] arr = info[i].Split('*');

                        if (arr[12] != "" && arr[14] == "Open Tender" && arr[0] == tendernumber && arr[17] == "Published" && DateTime.Parse(arr[12]) >= today)
                        {

                            SingleTenderModel tender = new SingleTenderModel();
                            tender.Code = arr[0];
                            tender.Procurement_Method = arr[14];
                            tender.Solicitation_Type = arr[1];
                            tender.External_Document_No = arr[2];
                            tender.Invitation_Notice_Type = arr[18];
                            tender.Procurement_Type = arr[3];
                            tender.Procurement_Category_ID = arr[4];
                            tender.Project_ID = arr[5];
                            tender.Tender_Name = arr[6];
                            tender.Responsibility_Center = arr[19];
                            tender.Tender_Summary = arr[7];
                            tender.Description = arr[8];
                            tender.Document_Status = arr[17];
                            tender.Target_Bidder_Group = arr[15];
                            tender.Tender_Validity_Duration = arr[20];
                            tender.Tender_Validity_Expiry_Date = Convert.ToString(arr[21]);
                            tender.Bid_Selection_Method = arr[22];
                            tender.Location_Code = arr[23];
                            tender.Requisition_Product_Group = arr[24];
                            tender.Language_Code = arr[25];
                            tender.Mandatory_Special_Group_Reserv = arr[26];
                            if (arr[9] != "")
                            {
                                tender.Document_Date = DateTime.Parse(arr[9]);


                            }

                            if (arr[13] != "")
                            {
                                tender.Submission_Start_Date = DateTime.Parse(arr[13]);

                            }
                            if (arr[30] != "")
                            {
                                tender.Date_Created = DateTime.Parse(arr[30]);

                            }
                            if (arr[31] != "")
                            {
                                tender.Mandatory_Pre_bid_Visit_Date = DateTime.Parse(arr[31]);

                            }
                            tender.Status = arr[10];
                            tender.Name = arr[11];
                            tender.Location_Name = arr[27];
                            tender.Lot_No = arr[28];
                            tender.Submission_End_Date = DateTime.Parse(arr[12]);
                            tender.Submission_EndTime = Convert.ToString(arr[29]);
                            tender.Prebid_Meeting_Address = arr[33];
                            tender.Phone_No = arr[34];
                            tender.Bid_Opening_Time = arr[35];
                            tender.Procuring_Entity_Name_Contact = arr[36];
                            tender.Primary_Tender_Submission = arr[38];
                            tender.Performance_Security_Required = Convert.ToString(arr[37]);
                            if (tender.Performance_Security_Required == "True")
                            {

                                tender.Performance_Security_Required = "Yes";
                            }
                            else
                            {
                                tender.Performance_Security_Required = "No";
                            }
                            tender.Bid_Tender_Security_Required = Convert.ToString(arr[37]);
                            if (tender.Bid_Tender_Security_Required == "True")
                            {

                                tender.Bid_Tender_Security_Required = "Yes";
                            }
                            else
                            {
                                tender.Bid_Tender_Security_Required = "No";
                            }
                            tender.Bid_Scoring_Template = arr[16];
                            tender.Bid_Security = Convert.ToString(arr[59]);
                            tender.Performance_Security = Convert.ToString(arr[60]);
                            tender.Bid_Security_Amount_LCY = Convert.ToDecimal(arr[61]);
                            tender.Advance_Payment_Security_Req = Convert.ToString(arr[63]);
                            tender.Bid_Security_Validity_Duration = arr[64];
                            tender.Advance_Amount_Limit = Convert.ToDecimal(arr[62]);
                            tender.Insurance_Cover_Required = Convert.ToString(arr[65]);
                            if (tender.Insurance_Cover_Required == "True")
                            {

                                tender.Insurance_Cover_Required = "Yes";
                            }
                            else
                            {
                                tender.Insurance_Cover_Required = "No";
                            }
                            tender.Appointer_of_Bid_Arbitrator = arr[39];
                            tender.Published = Convert.ToString(true);
                            tender.Bid_Envelop_Type = arr[40];
                            if (arr[41] != "")
                            {
                                tender.Bid_Security_Expiry_Date = DateTime.Parse(arr[41]);

                            }
                            if (arr[42] != "")
                            {
                                tender.Bid_Opening_Date = DateTime.Parse(arr[42]).ToString("YYYY/mm/dd");

                            }
                            tender.Sealed_Bids = Convert.ToString(arr[43]);
                            if (tender.Sealed_Bids == "True")
                            {

                                tender.Sealed_Bids = "Yes";
                            }
                            else
                            {
                                tender.Sealed_Bids = "No";
                            }
                            tender.Address = arr[44];
                            tender.Post_Code = arr[45];
                            tender.City = arr[46];
                            tender.Country_Region_Code = arr[47];
                            tender.Tender_Box_Location_Code = arr[48];
                            tender.Bid_Opening_Venue = arr[49];
                            tender.Address_2 = arr[53];
                            tender.Advance_Payment_Security = Convert.ToDecimal(arr[54]);
                            tender.Bid_Charge_Code = arr[55];
                            tender.Bid_Charge_Bank_Code = arr[51];
                            tender.Bid_Charge_LCY = Convert.ToDecimal(arr[56]);
                            tender.Bank_Name = arr[57];
                            tender.Bank_Account_Name = arr[50];
                            if (arr[29] != "")
                            {
                                tender.Submission_EndTime = DateTime.Parse(arr[29]).ToString();

                            }
                            tender.Bid_Charge_Bank_Branch = arr[52];
                            tender.Bid_Charge_Bank_A_C_No = arr[58];
                            list.Add(tender);

                        }
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<SingleTenderModel> GetSingleRFQDetails(string tendernumber)
        {
            List<SingleTenderModel> list = new List<SingleTenderModel>();
            try
            {
                var nav = new NavConnection().queries();
                var today = DateTime.Today;
                var result = nav.fnGetInviteTender("");
                String[] info = result.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');

                        if (arr[12] != "" && arr[14] == "RFQ" && arr[0] == tendernumber && DateTime.Parse(arr[12]) >= today)
                        {

                            SingleTenderModel tender = new SingleTenderModel();
                            tender.Code = arr[0];
                            tender.Procurement_Method = arr[14];
                            tender.Solicitation_Type = arr[1];
                            tender.External_Document_No = arr[2];
                            tender.Invitation_Notice_Type = arr[18];
                            tender.Procurement_Type = arr[3];
                            tender.Procurement_Category_ID = arr[4];
                            tender.Project_ID = arr[5];
                            tender.Tender_Name = arr[6];
                            tender.Responsibility_Center = arr[19];
                            tender.Tender_Summary = arr[7];
                            tender.Description = arr[8];
                            tender.Document_Status = arr[17];
                            tender.Target_Bidder_Group = arr[15];
                            tender.Tender_Validity_Duration = arr[20];
                            tender.Tender_Validity_Expiry_Date = Convert.ToString(arr[21]);
                            tender.Bid_Selection_Method = arr[22];
                            tender.Location_Code = arr[23];
                            tender.Requisition_Product_Group = arr[24];
                            tender.Language_Code = arr[25];
                            tender.Mandatory_Special_Group_Reserv = arr[26];
                            if (arr[9] != "")
                            {
                                tender.Document_Date = DateTime.Parse(arr[9]);

                            }
                            tender.Status = arr[10];
                            tender.Name = arr[11];
                            tender.Location_Name = arr[27];
                            tender.Lot_No = arr[28];
                            if (arr[12] != "")
                            {
                                tender.Submission_End_Date = DateTime.Parse(arr[12]);

                            }
                            tender.Submission_EndTime = Convert.ToString(arr[29]);
                            if (arr[13] != "")
                            {
                                tender.Submission_Start_Date = DateTime.Parse(arr[13]);


                            }
                            if (arr[30] != "")
                            {
                                tender.Date_Created = DateTime.Parse(arr[30]);

                            }
                            if (arr[31] != "")
                            {
                                tender.Mandatory_Pre_bid_Visit_Date = DateTime.Parse(arr[31]);

                            }
                            tender.Prebid_Meeting_Address = arr[33];
                            tender.Phone_No = arr[34];
                            tender.Bid_Opening_Time = arr[35];
                            tender.Procuring_Entity_Name_Contact = arr[36];
                            tender.Primary_Tender_Submission = arr[38];
                            tender.Performance_Security_Required = Convert.ToString(arr[37]);
                            if (tender.Performance_Security_Required == "True")
                            {

                                tender.Performance_Security_Required = "Yes";
                            }
                            else
                            {
                                tender.Performance_Security_Required = "No";
                            }
                            tender.Bid_Tender_Security_Required = Convert.ToString(arr[37]);
                            if (tender.Bid_Tender_Security_Required == "True")
                            {

                                tender.Bid_Tender_Security_Required = "Yes";
                            }
                            else
                            {
                                tender.Bid_Tender_Security_Required = "No";
                            }
                            tender.Bid_Scoring_Template = arr[16];
                            tender.Bid_Security = Convert.ToString(arr[59]);
                            tender.Performance_Security = Convert.ToString(arr[60]);
                            tender.Bid_Security_Amount_LCY = Convert.ToDecimal(arr[61]);
                            tender.Advance_Payment_Security_Req = Convert.ToString(arr[63]);
                            tender.Bid_Security_Validity_Duration = arr[64];
                            tender.Advance_Amount_Limit = Convert.ToDecimal(arr[62]);
                            tender.Insurance_Cover_Required = Convert.ToString(arr[65]);
                            if (tender.Insurance_Cover_Required == "True")
                            {

                                tender.Insurance_Cover_Required = "Yes";
                            }
                            else
                            {
                                tender.Insurance_Cover_Required = "No";
                            }
                            tender.Appointer_of_Bid_Arbitrator = arr[39];
                            tender.Published = Convert.ToString(true);
                            tender.Bid_Envelop_Type = arr[40];
                            if (arr[41] != "")
                            {
                                tender.Bid_Security_Expiry_Date = DateTime.Parse(arr[41]);

                            }
                            tender.Bid_Opening_Date = Convert.ToString(arr[42]);
                            tender.Sealed_Bids = Convert.ToString(arr[43]);
                            if (tender.Sealed_Bids == "True")
                            {

                                tender.Sealed_Bids = "Yes";
                            }
                            else
                            {
                                tender.Sealed_Bids = "No";
                            }
                            tender.Address = arr[44];
                            tender.Post_Code = arr[45];
                            tender.City = arr[46];
                            tender.Country_Region_Code = arr[47];
                            tender.Tender_Box_Location_Code = arr[48];
                            tender.Bid_Opening_Venue = arr[49];
                            tender.Address_2 = arr[53];
                            tender.Advance_Payment_Security = Convert.ToDecimal(arr[54]);
                            tender.Bid_Charge_Code = arr[55];
                            tender.Bid_Charge_Bank_Code = arr[51];
                            tender.Bid_Charge_LCY = Convert.ToDecimal(arr[56]);
                            tender.Bank_Name = arr[57];
                            tender.Bank_Account_Name = arr[50];
                            tender.Submission_EndTime = Convert.ToString(arr[29]);
                            tender.Bid_Charge_Bank_Branch = arr[52];
                            tender.Bid_Charge_Bank_A_C_No = arr[58];
                            list.Add(tender);

                        }
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<SingleTenderAddendumModel> GetSingleTenderAddendum(string tendernumber)
        {
            List<SingleTenderAddendumModel> list = new List<SingleTenderAddendumModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetTenderAddedNotice(tendernumber);
                String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        SingleTenderAddendumModel addendum = new SingleTenderAddendumModel();
                        addendum.Addendum_Notice_No = arr[0];
                        addendum.Invitation_Notice_No = tendernumber;
                        addendum.Document_Date = Convert.ToString(arr[2]);
                        addendum.Addendum_Instructions = arr[3];
                        addendum.Primary_Addendum_Type_ID = arr[4];
                        addendum.Addendum_Type_Description = arr[5];
                        addendum.Tender_No = arr[18];
                        addendum.Tender_Description = arr[7];
                        addendum.Responsibility_Center = arr[8];
                        addendum.Description = arr[6];
                        addendum.New_Submission_Start_Date = Convert.ToString(arr[9]);
                        addendum.Status = arr[10];
                        addendum.Original_Submission_Start_Date = Convert.ToString(arr[11]);
                        addendum.New_Submission_End_Time = arr[19];
                        addendum.Original_Submission_End_Date = Convert.ToString(arr[21]);
                        addendum.Original_Bid_Opening_Date = Convert.ToString(arr[17]);
                        addendum.New_Bid_Opening_Date = Convert.ToString(arr[13]);
                        addendum.Original_Bid_Opening_Time = arr[20];
                        addendum.Original_Prebid_Meeting_Date = Convert.ToString(arr[15]);
                        addendum.New_Prebid_Meeting_Date = Convert.ToString(arr[16]);
                        list.Add(addendum);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<SingleTenderAddendumModel> GetSinglePrequalificatinAddendum(string tendernumber)
        {
            List<SingleTenderAddendumModel> list = new List<SingleTenderAddendumModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetTenderAddedNotice(tendernumber);
                String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        SingleTenderAddendumModel addendum = new SingleTenderAddendumModel();
                        addendum.Addendum_Notice_No = arr[0];
                        addendum.Invitation_Notice_No = tendernumber;
                        addendum.Document_Date = Convert.ToString(arr[2]);
                        addendum.Addendum_Instructions = arr[3];
                        addendum.Primary_Addendum_Type_ID = arr[4];
                        addendum.Addendum_Type_Description = arr[5];
                        addendum.Tender_No = arr[18];
                        addendum.Tender_Description = arr[7];
                        addendum.Responsibility_Center = arr[8];
                        addendum.Description = arr[6];
                        addendum.New_Submission_Start_Date = Convert.ToString(arr[9]);
                        addendum.Status = arr[10];
                        addendum.Original_Submission_Start_Date = Convert.ToString(arr[11]);
                        addendum.New_Submission_End_Time = arr[19];
                        addendum.Original_Submission_End_Date = Convert.ToString(arr[21]);
                        addendum.Original_Bid_Opening_Date = Convert.ToString(arr[17]);
                        addendum.New_Bid_Opening_Date = Convert.ToString(arr[13]);
                        addendum.Original_Bid_Opening_Time = arr[20];
                        addendum.Original_Prebid_Meeting_Date = Convert.ToString(arr[15]);
                        addendum.New_Prebid_Meeting_Date = Convert.ToString(arr[16]);
                        list.Add(addendum);
                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        public ActionResult MyStatement()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.Vendors = GetVendors(vendorNo);
                model.Statement = GetVendorsStatement(vendorNo);
                return View(model);
            }

        }
        public ActionResult MyAccount()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.Vendors = GetVendors(vendorNo);
                model.BanksDetails = GetBanks(vendorNo);
                model.StakeholdersDetails = GetStakeholders(vendorNo);
                // model.Beneficiaries = GetStakeholders(vendorNo);
                model.PrequalifcationHistory = GetPrequalificationHistory(vendorNo);
                model.PastExperience = GetVendorPastExeprience(vendorNo);
                model.litigationhistory = GetVendorLitigationHistoryDetails(vendorNo);
                model.balancesheet = GetVendorBalanaceDetails(vendorNo);
                model.incomestatement = GetVendorIncomeStatementDetails(vendorNo);
                return View(model);
            }
        }
        public ActionResult eBidding()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                List<TenderModel> list = new List<TenderModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var today = DateTime.Today;
                    var result = nav.fnGetInviteTender("");
                    String[] info = result.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');

                            if (arr[12] != "" && arr[14] == "Open Tender" && DateTime.Parse(arr[12]) >= today)
                            {
                                TenderModel tender = new TenderModel();
                                tender.Code = arr[0];
                                tender.Procurement_Method = arr[14];
                                tender.Solicitation_Type = arr[1];
                                tender.External_Document_No = arr[2];
                                tender.Procurement_Type = arr[3];
                                tender.Procurement_Category_ID = arr[4];
                                tender.Project_ID = arr[5];
                                tender.Tender_Name = arr[6];
                                tender.Tender_Summary = arr[7];
                                tender.Description = arr[8];
                                if (arr[9] != "")
                                {
                                    tender.Document_Date = DateTime.Parse(arr[9]);
                                }
                                tender.Status = arr[10];
                                tender.Name = arr[11];
                                if (arr[12] != "")
                                {
                                    tender.Submission_End_Date = DateTime.Parse(arr[12]);

                                }
                                if (arr[13] != "")
                                {
                                    tender.Submission_Start_Date = DateTime.Parse(arr[13]);

                                }
                                tender.Published = true;
                                list.Add(tender);

                            }
                        }

                    }

                }
                catch (Exception e)
                {

                    throw;
                }
                return View(list);

            }
        }
        public ActionResult ActiveTenderNotices()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<TenderModel> list = new List<TenderModel>();


                var nav = new NavConnection().queries();
                var today = DateTime.Today;
                var result = nav.fnGetInviteTender("");
                string[] info = result.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);

                if (info != null)
                {
                    // Iterate over each split string
                    for (int i = 0; i < info.Length; i++)
                    {
                        string[] arr = info[i].Split('*');

                        if (arr[12] != "" && arr[14] == "Open Tender" && DateTime.Parse(arr[12]) >= today)
                        {
                            TenderModel tender = new TenderModel();
                            tender.Code = arr[0];
                            tender.Procurement_Method = arr[14];
                            tender.Solicitation_Type = arr[1];
                            tender.External_Document_No = arr[2];
                            tender.Procurement_Type = arr[3];
                            tender.Procurement_Category_ID = arr[4];
                            tender.Project_ID = arr[5];
                            tender.Tender_Name = arr[6];
                            tender.Tender_Summary = arr[7];
                            tender.Description = arr[8];

                            if (arr[9] != "")
                            {
                                tender.Document_Date = DateTime.Parse(arr[9]);

                            }
                            if (arr[12] != "")
                            {
                                tender.Submission_End_Date = DateTime.Parse(arr[12]);

                            }
                            if (arr[13] != "")
                            {
                                tender.Submission_Start_Date = DateTime.Parse(arr[13]);

                            }
                            tender.Status = arr[10];
                            tender.Name = arr[11];
                            tender.Published = true;
                            list.Add(tender);

                        }
                    }

                }


                return View(list);

            }
        }
        public ActionResult Dashboard()
        {
            if (Session["vendorNo"] != null)
            {
                if (TempData["search"] != null)
                {
                    dynamic model = new ExpandoObject();
                    List<TenderModel> list = new List<TenderModel>();
                    model = TempData["data"];
                    model.ActiveTenders = model.activ;
                    //list.Add(TempData["data"] as TenderModel);
                    //model.ActiveTenders = list;
                    //model.ActiveTenders = GetActiveTenderDetailFilter();
                    return View(model);
                }
                else
                {
                    dynamic model = new ExpandoObject();
                    model.ActiveTenders = GetActiveTenderDetail();
                    return View(model);
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ePrequalifications()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                ViewBag.Message = "ePrequalifications";
                List<IFPRequestsModel> list = new List<IFPRequestsModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var today = DateTime.Today;
                    var query = nav.fnGetInvitationPrequalification("Invitation For Prequalification");
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            if (arr[5] != "" && DateTime.Parse(arr[5]) >= today)
                            {
                                IFPRequestsModel invite = new IFPRequestsModel();
                                invite.Code = arr[0];
                                invite.Description = arr[1];
                                invite.Tender_Box_Location_Code = arr[2];
                                invite.External_Document_No = arr[3];
                                invite.Tender_Summary = arr[4];
                                invite.Submission_End_Date = Convert.ToString(arr[5]);
                                invite.Submission_Start_Date = Convert.ToString(arr[6]);
                                list.Add(invite);
                            }


                        }
                    }

                }
                catch (Exception e)
                {

                    throw;
                }
                return View(list);
            }
        }
        public ActionResult SupplierRegistration()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                ViewBag.prequalificationNo = vendorNo;
                dynamic model = new ExpandoObject();
                model.Vendors = GetVendors(vendorNo);
                model.BanksDetails = GetBanks(vendorNo);
                model.StakeholdersDetails = GetStakeholders(vendorNo);
                model.PrequalifcationHistory = GetPrequalificationHistory(vendorNo);
                model.PastExperience = GetVendorPastExeprience(vendorNo);
                model.litigationhistory = GetVendorLitigationHistoryDetails(vendorNo);
                model.balancesheet = GetVendorBalanaceDetails(vendorNo);
                model.incomestatement = GetVendorIncomeStatementDetails(vendorNo);
                model.VendorProfessionalStaff = GetVendorProfessionalStaff(vendorNo);
                model.UploadedDocuments = AlreadyRegisteredDocumentsDetails(vendorNo);
                model.RequiredDocuments = RegistrationRequiredDocumentsDetails(vendorNo);
                return View(model);

            }
        }

        public ActionResult ViewPrequalifications(string InvitationNumber, string scoringTemplate)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.PrequalificationDetails = GetPrequalificationsDetails(InvitationNumber);
                model.Categories = GetPrequalificationCategories(InvitationNumber);
                model.TenderAddendums = GetSinglePrequalificatinAddendum(InvitationNumber);
                model.RequiredDocuments = PrequalificationsRequiredDocumentsDetails(InvitationNumber);
                //  model.AttachedDocuments = PopulatePrequalificationDocuments(InvitationNumber);
                model.RFI_SCORING_TEMPLATE = EvaluationTemplate(scoringTemplate);
                Session["inviteNo"] = InvitationNumber;
                return View(model);
            }

        }
        public ActionResult ViewRegistration(string InvitationNumber, string scoringTemplate)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.PrequalificationDetails = GetPrequalificationsDetails(InvitationNumber);
                model.Categories = GetPrequalificationCategories(InvitationNumber);
                model.TenderAddendums = GetSinglePrequalificatinAddendum(InvitationNumber);
                model.RequiredDocuments = RegistrationRequiredDocumentsDetails(InvitationNumber);
                model.AttachedDocuments = PopulatePrequalificationDocuments(InvitationNumber);
                model.RFI_SCORING_TEMPLATE = EvaluationTemplate(scoringTemplate);
                return View(model);
            }

        }
        public ActionResult ViewPrequalificationsAdvert(string InvitationNumber)
        {


            dynamic model = new ExpandoObject();
            model.PrequalificationDetails = GetPrequalificationsDetails(InvitationNumber);
            model.Categories = GetPrequalificationCategories(InvitationNumber);
            model.RequiredDocuments = PrequalificationsRequiredDocumentsDetails(InvitationNumber);
            model.AttachedDocuments = PopulatePrequalificationDocuments(InvitationNumber);
            return View(model);


        }
        public ActionResult ViewSubmittedPrequalifications(string IFPNumber)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.PrequalificationGeneralDetails = GetPrequalificationsGeneralDetails(IFPNumber, vendorNo);
                model.Categories = GetSubmittedPrequalificationCategories(IFPNumber, vendorNo);
                model.AttachedDocuments = GetAttachedPrequalificationsDocuments(IFPNumber, vendorNo);
                return View(model);
            }

        }
        public ActionResult ViewSubmittedOpenTenderResponses(string responseNumber, string tenderNo)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.ResponseDetails = GetResponseGeneralDetails(responseNumber, vendorNo);
                model.BidPersonnel = GetBidResponsePersonnel(responseNumber);
                model.BidPastExperiencent = GetBidResponsePastExperience(responseNumber, vendorNo);
                model.BidEquipments = GetBidResponseEquipments(responseNumber);
                model.SingleTenders = GetSingleTenderDetails(tenderNo);
                model.AttachedDocuments = GetAttachedPrequalificationsDocuments(responseNumber, vendorNo);
                model.AttachedBiddDocuments = GetBidAttachedDocumentsDetails(responseNumber, vendorNo);
                return View(model);
            }

        }
        public ActionResult ViewSubmittedRFQResponses(string responseNumber, string tenderNo)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                Session["res"] = responseNumber;
                Session["tend"] = tenderNo;
                ViewBag.tends = tenderNo;
                ViewBag.ress = responseNumber;
                dynamic model = new ExpandoObject();
                model.ResponseDetails = GetResponseGeneralDetails(responseNumber, vendorNo);
                model.financialresponse = GetFinancialResponse(responseNumber, vendorNo);
                model.SingleTenders = GetSingleRFQDetails(tenderNo);
                model.AttachedDocuments = GetAttachedPrequalificationsDocuments(responseNumber, vendorNo);
                model.AttachedBiddDocuments = GetBidAttachedDocumentsDetails(responseNumber, vendorNo);
                return View(model);
            }

        }
        private static List<PrequalificationGeneralDetailsModel> GetPrequalificationsGeneralDetails(string IFPNumber, string vendorNo)
        {
            List<PrequalificationGeneralDetailsModel> list = new List<PrequalificationGeneralDetailsModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetRFIResponse(vendorNo, IFPNumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        PrequalificationGeneralDetailsModel response = new PrequalificationGeneralDetailsModel();
                        response.Created_Date = Convert.ToString(arr[0]);
                        response.Created_Time = arr[1];
                        response.Date_Submitted = Convert.ToString(arr[2]);
                        response.Final_Evaluation_Score = Convert.ToString(arr[3]);
                        response.Special_Group_Category = arr[4];
                        response.Special_Group_Vendor = Convert.ToString(arr[5]);
                        response.E_Mail = Convert.ToString(arr[6]);
                        response.Post_Code = arr[7];
                        response.Country_Region_Code = arr[8];
                        response.City = arr[9];
                        response.Vendor_Address = arr[10];
                        response.Vendor_Address_2 = arr[11];
                        response.Vendor_Representative_Name = arr[12];
                        response.Vendor_Repr_Designation = arr[13];
                        response.RFI_Document_No = arr[14];
                        response.Vendor_No = vendorNo;
                        response.Vendor_Name = arr[15];
                        response.Document_No = IFPNumber;
                        response.Document_Date = Convert.ToString(arr[16]);
                        response.Document_Type = arr[17];
                        list.Add(response);

                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<SubmittedTenderResponse> GetResponseGeneralDetails(string responseNumber, string vendorNo)
        {
            List<SubmittedTenderResponse> list = new List<SubmittedTenderResponse>();
            try
            {
                var nav = new NavConnection().queries();

                var query = nav.fnGetBidResponseDetails(vendorNo, responseNumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        SubmittedTenderResponse response = new SubmittedTenderResponse();
                        response.InvitationNo = arr[0];
                        response.vendorNo = vendorNo;
                        response.VendorName = arr[1];
                        response.ResponseNo = responseNumber;
                        response.ResponsibilityCentre = arr[2];
                        response.tenderDescription = arr[3];
                        response.BidRepName = arr[4];
                        response.bidderRepDesignation = arr[5];
                        response.bidderRepAddress = arr[17];
                        response.BidderWittnesName = arr[6];
                        response.VAT_Registration_No = arr[7];
                        response.Bidder_Witness_Designation = arr[8];
                        response.Bid_Charge_LCY = Convert.ToString(arr[9]);
                        response.Bidder_witness_Address = arr[10];
                        response.Bid_Charge_Code = arr[11];
                        response.Payment_Reference_No = arr[12];
                        response.BiddeType = arr[13];
                        response.jointPartnerVenture = arr[15];
                        response.TenderDocumentSources = arr[16];

                        list.Add(response);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<SubmittedTenderResponse> GetFinancialResponse(string responseNumber, string vendorNo)
        {
            List<SubmittedTenderResponse> list = new List<SubmittedTenderResponse>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetBidResponseItemLines(vendorNo, responseNumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        SubmittedTenderResponse response = new SubmittedTenderResponse();

                        response.itemDescription = arr[0];
                        response.itemLocation = arr[1];
                        response.itemQuantity = Convert.ToDecimal(arr[2]);
                        response.directunitcost = Convert.ToDecimal(arr[3]);


                        list.Add(response);

                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<SubmittedPrequalificationCategoriesModel> GetSubmittedPrequalificationCategories(string IFPNumber, string vendorNo)
        {
            List<SubmittedPrequalificationCategoriesModel> list = new List<SubmittedPrequalificationCategoriesModel>();
            try
            {
                var nav = new NavConnection().queries();

                var query = nav.fnGetIfpResponseLine(IFPNumber, "", vendorNo, "");
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        SubmittedPrequalificationCategoriesModel response = new SubmittedPrequalificationCategoriesModel();
                        response.Evaluation_Decision = Convert.ToString(arr[5]);
                        response.Evaluation_Score = Convert.ToString(arr[6]);
                        response.Prequalification_End_Date = Convert.ToString(arr[7]);
                        response.Prequalification_Start_Date = Convert.ToString(arr[8]);
                        response.Restricted_RC_ID = arr[8];
                        response.Restricted_Responsbility_Cente = Convert.ToString(arr[10]);
                        response.Global_RC_Prequalification = Convert.ToString(arr[11]);
                        response.Unique_Category_Requirements = Convert.ToString(arr[12]);
                        response.Special_Group_Reservation = Convert.ToString(arr[13]);
                        if (response.Special_Group_Reservation == "True")
                        {

                            response.Special_Group_Reservation = "Yes";
                        }
                        else
                        {
                            response.Special_Group_Reservation = "No";
                        }
                        response.Vendor_No = vendorNo;
                        response.RFI_Document_No = arr[4];
                        response.Category_Description = arr[0];
                        response.Procurement_Category = arr[2];
                        response.Document_No = arr[1];

                        response.Document_Type = arr[14];
                        list.Add(response);

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<IfPDocumentsTModel> GetAttachedPrequalificationsDocuments(string IFPNumber, string vendorNo)
        {
            List<IfPDocumentsTModel> list = new List<IfPDocumentsTModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetRFIResponseFiledDocument(vendorNo, IFPNumber);
                String[] result = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (result != null)
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        String[] arr = result[i].Split('*');
                        IfPDocumentsTModel response = new IfPDocumentsTModel();
                        response.Document_No = Convert.ToString(IFPNumber);
                        response.Description = Convert.ToString(arr[0]);
                        response.Issue_Date = Convert.ToString(arr[1]);
                        response.Expiry_Date = Convert.ToString(arr[2]);
                        response.Vendor_No = vendorNo;
                        response.Certificate_No = Convert.ToString(arr[3]);
                        response.File_Extension = Convert.ToString(arr[4]);
                        response.File_Name = Convert.ToString(arr[5]);
                        response.File_Type = arr[6];
                        list.Add(response);
                    }

                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<VendorStatementModel> GetVendorsStatement(string vendorNo)
        {
            //"Invoice*08/15/23*Invoice PINV00236*PPINV00132*Interways Works Limited*0.00*0.00*0**G/L Account*551*0*0*08/15/23*IPC 3- MMAHIU+SUSWA SGR*0"
            //"Construction of Access Roads to Mai Mahiu and Suswa SGR Stations*PV00162*Interways Works Limited*0.00*0.00*0*BANK014*Bank Account*6736*0*0*08/17/23*NBK 003067*0"
            List<VendorStatementModel> list = new List<VendorStatementModel>();
            try
            {
                var nav = new NavConnection().queries();
                //var query = nav.fnGetVendorStatement(vendorNo);
                var query = nav.fnGetVendorStatement("VEND00473");
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    foreach(var info2 in info)
                    {
                        String[] arr = info2.Split('*');
                        VendorStatementModel statetement = new VendorStatementModel();
                        
                        
                        
                        statetement.Vendor_No = vendorNo;
                        statetement.Document_Type = arr[0];
                        if (arr[1] != "")
                        {
                            statetement.Posting_Date = DateTime.Parse(arr[1]).ToString("dd-MM-yy");

                        }
                        statetement.Description = arr[2];
                        statetement.Document_No = arr[3];
                        statetement.Vendor_Name = arr[4];
                        statetement.Amount = Convert.ToString(arr[5]).Replace("-", " ");
                        statetement.Remaining_Amount = Convert.ToString(arr[6]).Replace("-", " "); 
                        statetement.Amount_LCY = Convert.ToString(arr[7]);
                        statetement.Bal_Account_No = arr[8];
                        statetement.Bal_Account_Type = arr[9];
                        statetement.Transaction_No = Convert.ToString(arr[10]);
                        statetement.Debit_Amount_LCY = Convert.ToString(arr[11]);
                        statetement.Credit_Amount_LCY = Convert.ToString(arr[12]);
                        statetement.Document_Date = Convert.ToString(arr[13]);
                        statetement.External_Document_No = arr[14];
                        statetement.Remaining_Amt_LCY = Convert.ToString(arr[15]);
                        list.Add(statetement);
                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        [HttpGet]
        public ActionResult DisplayPdfInIframe(string PrequalificationNumber)
        {
            try
            {

                var nav = new NavConnection().ObjNav();
                var vendorNo = Session["vendorNo"].ToString();
                String status = nav.FnGeneratePrequalificationPreviewReport(vendorNo, PrequalificationNumber);


            }
            catch(Exception e)
            {
                throw;
            }

            string filePath = "~/Downloads/" + PrequalificationNumber + ".pdf";
            var contentDisposition = new System.Net.Mime.ContentDisposition
            {
                FileName = PrequalificationNumber + ".pdf",
                Inline = true
            };
            Response.Headers.Add("Content-Disposition", contentDisposition.ToString());
            return File(filePath, System.Net.Mime.MediaTypeNames.Application.Pdf);

        }
        [HttpGet]
        public ActionResult DisplayPdfInIframeRegistration(string bidresponseNo)
        {
            try
            {
                var nav = new NavConnection().ObjNav();
                var vendorNo = Session["vendorNo"].ToString();
                String status = nav.FnGenerateRegistrationPreviewReport(vendorNo, bidresponseNo);


            }
            catch
            {

            }

            string filePath = "~/Downloads/" + bidresponseNo + ".pdf";
            var contentDisposition = new System.Net.Mime.ContentDisposition
            {
                FileName = bidresponseNo + ".pdf",
                Inline = true
            };
            Response.Headers.Add("Content-Disposition", contentDisposition.ToString());
            return File(filePath, System.Net.Mime.MediaTypeNames.Application.Pdf);

        }

        [HttpGet]
        public ActionResult DisplayPdfInIframeQuotation(string bidresponseNo)
        {

            try
            {
                var nav = new NavConnection().ObjNav();
                var vendorNo = Session["vendorNo"].ToString();
                if (bidresponseNo == null)
                {
                    bidresponseNo = Session["RFQBideResponseNumber"].ToString();
                }

                String status = nav.FnGenerateRFQPreviewReportBid(vendorNo, bidresponseNo);


            }
            catch
            {
                //BidResponse

            }

            //string filePath = "~/Downloads/" + bidresponseNo + ".pdf";
            //
            string fp = "C:/inetpub/wwwroot/ProcurementLive/Downloads/BidResponse/";
            string fileName = $"{bidresponseNo}.pdf";
            string filePath = Path.Combine(fp, fileName);
            //
            var contentDisposition = new System.Net.Mime.ContentDisposition
            {
                FileName = bidresponseNo + ".pdf",
                Inline = true
            };
            Response.Headers.Add("Content-Disposition", contentDisposition.ToString());
            return File(filePath, System.Net.Mime.MediaTypeNames.Application.Pdf);

        }
        [HttpGet]
        public ActionResult DisplayPdfInIframeTender(string tendernumber)
        {

            try
            {
                var nav = new NavConnection().ObjNav();

                var vendorNo = Session["vendorNo"].ToString();

                if (tendernumber == null)
                {
                    tendernumber = Session["BideResponseNumber"].ToString();
                }

                String status = nav.FnGenerateRFQPreviewReport1(vendorNo, tendernumber);


            }
            catch (Exception e)
            {

            }

            tendernumber = Regex.Replace(tendernumber, ":", "");
            //string path = "~/Downloads/RFQ/";
            //if (!Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path);
            //}
            //string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "RFQ");

            //if (!Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path);
            //}

           // string fp = "C:/inetpub/wwwroot/ProcurementLive/Downloads/RFQ/";
           //// string filePath = "~/Downloads/RFQ/" + tendernumber + ".pdf";
           // string filePath = fp + tendernumber + ".pdf";
            string fp = "C:/inetpub/wwwroot/ProcurementLive/Downloads/RFQ/";
            string fileName = $"{tendernumber}.pdf"; 
            string filePath = Path.Combine(fp, fileName);
            var contentDisposition = new System.Net.Mime.ContentDisposition
            {
                FileName = tendernumber + ".pdf",
                Inline = true
            };
            Response.Headers.Add("Content-Disposition", contentDisposition.ToString());
            return File(filePath, System.Net.Mime.MediaTypeNames.Application.Pdf);


        }
        private static List<RegistrationDocumentsModel> AlreadyRegisteredDocumentsDetails(string vendorNo)
        {
            List<RegistrationDocumentsModel> list = new List<RegistrationDocumentsModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetVendorFiledRegDocuments(vendorNo, "Registration");

                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        RegistrationDocumentsModel documents = new RegistrationDocumentsModel();
                        documents.Procurement_Process = "Registration";
                        documents.Procurement_Document_Type_ID = arr[0];
                        documents.Description = arr[1];
                        documents.Date_Filed = Convert.ToString(arr[2]);
                        documents.Certificate_No = arr[3];
                        documents.Issue_Date = Convert.ToString(arr[4]);
                        documents.Expiry_Date = Convert.ToString(arr[5]);
                        documents.File_Name = arr[6];
                        documents.File_Type = arr[7];
                        documents.File_Extension = arr[8];
                        documents.entryNo = Convert.ToInt32(arr[9]);
                        list.Add(documents);


                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }

        private static List<PreQualificationRequiredDocuments> PrequalificationUploaded(string PrequalificationNo, string vendorNo)
        {
            List<PreQualificationRequiredDocuments> list = new List<PreQualificationRequiredDocuments>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetRFIResponseFiledDocument(vendorNo, PrequalificationNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[7] == "Prequalification")
                        {
                            PreQualificationRequiredDocuments documents = new PreQualificationRequiredDocuments();
                            documents.Procurement_Process = arr[7];
                            documents.Procurement_Document_Type_ID = arr[8];
                            documents.Description = arr[0];
                            documents.Date_Filed = Convert.ToString(arr[9]);
                            documents.Certificate_No = arr[3];
                            documents.Issue_Date = Convert.ToString(arr[1]);
                            documents.Expiry_Date = Convert.ToString(arr[2]);
                            documents.File_Name = arr[5];
                            documents.File_Type = arr[6];
                            documents.File_Extension = arr[4];
                            list.Add(documents);
                        }

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<AttachedBidDocuments> GetBidAttachedDocumentsDetails(string BidResponseNumber, string vendorNo)
        {
            List<AttachedBidDocuments> list = new List<AttachedBidDocuments>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetBidResponseAttachedDocuments(BidResponseNumber, vendorNo);
                String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        AttachedBidDocuments documents = new AttachedBidDocuments();
                        documents.Procurement_Process = arr[1];
                        documents.entryNumber = Convert.ToInt32(arr[2]);
                        documents.Procurement_Document_Type_ID = arr[0];
                        documents.Description = arr[3];
                        documents.Date_Filed = Convert.ToString(arr[4]);
                        documents.Certificate_No = arr[5];
                        documents.Issue_Date = Convert.ToString(arr[6]);
                        documents.Expiry_Date = Convert.ToString(arr[7]);
                        documents.File_Name = arr[8];
                        documents.File_Type = arr[9];
                        documents.File_Extension = arr[10];
                        documents.Document_Link = arr[11];
                        list.Add(documents);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<PreQualificationRequiredDocuments> PrequalificationsRequiredDocumentsDetails(string InvitationNumber)
        {
            List<PreQualificationRequiredDocuments> list = new List<PreQualificationRequiredDocuments>();
            try
            {

                var nav = new NavConnection().queries();
                var query = nav.fnGetIfpReqDocuments(InvitationNumber, "Invitation For Prequalification");
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        PreQualificationRequiredDocuments documents = new PreQualificationRequiredDocuments();

                        documents.Document_No = InvitationNumber;
                        documents.Description = arr[0];
                        documents.Document_Type = arr[5];
                        documents.Procurement_Document_Type_ID = arr[1];
                        documents.Requirement_Type = arr[2];
                        documents.SpecialGroupRequirement = Convert.ToString(arr[3]);
                        if (documents.SpecialGroupRequirement == "True")
                        {

                            documents.SpecialGroupRequirement = "Yes";
                        }
                        else
                        {
                            documents.SpecialGroupRequirement = "No";
                        }
                        documents.SpecialisedRequirement = Convert.ToString(arr[4]);
                        list.Add(documents);

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<RegistrationRequiredDocumentsModel> RegistrationRequiredDocumentsDetails(string vendorNo)
        {
            List<RegistrationRequiredDocumentsModel> list = new List<RegistrationRequiredDocumentsModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetEprocurementDocuments("Registration");
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        RegistrationRequiredDocumentsModel documents = new RegistrationRequiredDocumentsModel();
                        documents.Template_ID = arr[1];
                        documents.Description = arr[0];
                        documents.Procurement_Document_Type = arr[2];
                        documents.Requirement_Type = arr[3];
                        documents.instructions = arr[4];
                        list.Add(documents);

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }

        public JsonResult GetVendorKeyProfessionalStaff(string vendorNo)
        {

            List<ProfessionalStaffModel> staffDetails = new List<ProfessionalStaffModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetVendorProfessionalStaff(vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        ProfessionalStaffModel staff = new ProfessionalStaffModel();
                        staff.StaffNumber = arr[0];
                        staff.StaffName = arr[1];
                        staff.StaffDateofBirth = Convert.ToString(arr[2]);
                        staff.StaffEmail = arr[3];
                        staff.StaffDesignation = arr[4];
                        staff.Years_With_the_Firm = Convert.ToString(arr[5]);
                        staff.Post_Code = arr[6];
                        staff.Address_2 = arr[7];
                        staff.StaffPhonenumber = arr[8];
                        staff.City = arr[9];
                        staff.Citizenship_Type = arr[10];
                        staff.Staff_Category = arr[11];
                        staff.Country_Region_Code = arr[12];
                        staff.StaffProfession = arr[13];
                        staff.StaffJoiningDate = Convert.ToString(arr[14]);
                        staffDetails.Add(staff);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return Json(staffDetails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetKeyProfessionalStaff()
        {

            List<ProfessionalStaffModel> staffDetails = new List<ProfessionalStaffModel>();
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().queries();

                var query = nav.fnGetVendorProfessionalStaff(vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        ProfessionalStaffModel staff = new ProfessionalStaffModel();
                        staff.StaffNumber = arr[0];
                        staff.StaffName = arr[1];
                        staff.StaffDateofBirth = Convert.ToString(arr[2]);
                        staff.StaffEmail = arr[3];
                        staff.StaffDesignation = arr[4];
                        staff.Years_With_the_Firm = Convert.ToString(arr[5]);
                        staff.Post_Code = arr[6];
                        staff.Address_2 = arr[7];
                        staff.StaffPhonenumber = arr[8];
                        staff.City = arr[9];
                        staff.Citizenship_Type = arr[10];
                        staff.Staff_Category = arr[11];
                        staff.Country_Region_Code = arr[12];
                        staff.StaffProfession = arr[13];
                        staff.StaffJoiningDate = Convert.ToString(arr[14]);
                        staffDetails.Add(staff);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return Json(staffDetails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetVendorKeyProffessionalStaffDetails()
        {

            List<ProfessionalStaffModel> staffDetails = new List<ProfessionalStaffModel>();
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().queries();

                var query = nav.fnGetVendorProfessionalStaff(vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        ProfessionalStaffModel staff = new ProfessionalStaffModel();
                        staff.StaffNumber = arr[0];
                        staff.StaffName = arr[1];
                        staff.StaffDateofBirth = Convert.ToString(arr[2]);
                        staff.StaffEmail = arr[3];
                        staff.StaffDesignation = arr[4];
                        staff.Years_With_the_Firm = Convert.ToString(arr[5]);
                        staff.Post_Code = arr[6];
                        staff.Address_2 = arr[7];
                        staff.StaffPhonenumber = arr[8];
                        staff.City = arr[9];
                        staff.Citizenship_Type = arr[10];
                        staff.Staff_Category = arr[11];
                        staff.Country_Region_Code = arr[12];
                        staff.StaffProfession = arr[13];
                        staff.StaffJoiningDate = Convert.ToString(arr[14]);
                        staffDetails.Add(staff);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return Json(staffDetails, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetBidPersonnelDetails(string BidResponseNumber)
        {
            List<BidResponsePersonnel> list = new List<BidResponsePersonnel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetBidStaff(BidResponseNumber);

                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BidResponsePersonnel equipment = new BidResponsePersonnel();
                        equipment.No = arr[0];
                        //equipment.StaffCategory = equipments.Staff_Category;
                        // equipment.StaffName = equipments.Staff_Name;
                        equipment.ProjectRoleCode = arr[1];
                        //  equipment.RequiredProfession = equipments.Required_Project_Role;
                        // equipment.EmailAddress = equipments.E_Mail;
                        //    equipment.EmploymentType = equipments.Employment_Type;
                        equipment.Entry_No = Convert.ToString(arr[2]);
                        list.Add(equipment);
                    }
                }

            }


            catch (Exception e)
            {

                throw;
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetVendorBankAccounts()
        {

            List<BankModel> BankAccounts = new List<BankModel>();
            try
            {

                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().queries();
                var query = nav.fnGetVendorBankAccount(vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BankModel banks = new BankModel();
                        banks.BankCode = arr[0];
                        banks.BankName = arr[1];
                        banks.Post_Code = arr[2];
                        banks.Contact = arr[3];
                        banks.CurrencyCode = arr[4];
                        banks.BankAccountNo = arr[5];
                        banks.Bank_Branch_No = arr[6];
                        banks.bankBranchName = arr[8];
                        banks.City = arr[7];
                        BankAccounts.Add(banks);
                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return Json(BankAccounts, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetShareholders()
        {

            List<DirectorModel> DirectorDetails = new List<DirectorModel>();
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().queries();
                var query = nav.fnGetShareholderDetails(vendorNo);

                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        DirectorModel shareholder = new DirectorModel();
                        shareholder.Entry_No = Convert.ToInt32(arr[0]);
                        shareholder.Fullname = arr[1];
                        shareholder.CitizenshipType = arr[11];
                        shareholder.OwnershipPercentage = Convert.ToDecimal(arr[6]);
                        shareholder.Phonenumber = arr[7];
                        shareholder.Address = arr[3];
                        shareholder.PostCode = arr[15];
                        shareholder.Email = arr[14];
                        shareholder.IdNumber = arr[9];
                        shareholder.Nationality = arr[8];
                        DirectorDetails.Add(shareholder);

                    }


                }


            }
            catch (Exception e)
            {

                throw;
            }

            return Json(DirectorDetails, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetShareholderDetails()
        {
            List<ShareholderModel> ownersdetails = new List<ShareholderModel>();
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().queries();
                var query = nav.fnGetShareholderDetails(vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        ShareholderModel owner = new ShareholderModel();
                        owner.Entry_No = Convert.ToInt32(arr[0]);
                        owner.Vendor_No = vendorNo;
                        owner.Name = arr[1];
                        owner.Address = arr[2];
                        owner.Address_2 = arr[3];
                        owner.City = arr[4];
                        owner.Entity_Ownership = Convert.ToDecimal(arr[5]);
                        owner.Phone_No = arr[6];
                        owner.Nationality_ID = arr[7];
                        owner.ID_Passport_No = arr[8];
                        owner.Share_Types = arr[9];
                        owner.Citizenship_Type = arr[10];
                        owner.Country_Region_Code = arr[11];
                        // owner.Post_Code = owners.Post_Code;
                        owner.County = arr[12];
                        owner.E_Mail = arr[13];
                        ownersdetails.Add(owner);

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return Json(ownersdetails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetBeneficiaryDetails()
        {

            List<BeneficiarryModel> BeneficiaryDetails = new List<BeneficiarryModel>();
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().queries();
                var query = nav.fnGetVendorBeneficiaries(vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BeneficiarryModel beneficiary = new BeneficiarryModel();
                        beneficiary.Entry_No = Convert.ToInt32(arr[0]);
                        beneficiary.Name = arr[1];
                        beneficiary.idType = arr[2];
                        beneficiary.idpassportNumber = arr[3];
                        beneficiary.Phonenumber = Convert.ToInt32(arr[4]);
                        beneficiary.Email = arr[5];
                        beneficiary.AllocatedShares = Convert.ToDecimal(arr[6]);
                        beneficiary.BeneficiaryType = arr[7];
                        BeneficiaryDetails.Add(beneficiary);
                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }

            return Json(BeneficiaryDetails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetVendorLitigationHistory()
        {
            List<LitigationModel> litigationdetails = new List<LitigationModel>();
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().queries();
                var query = nav.fnGetBidLitigationHistory(vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        LitigationModel litigation = new LitigationModel();
                        litigation.Entry_No = Convert.ToInt32(arr[0]);
                        litigation.DisputeDescription = arr[1];
                        litigation.CategoryofDispute = arr[2];
                        litigation.Year = arr[3];
                        litigation.TheotherDisputeparty = arr[4];
                        litigation.DisputeAmount = Convert.ToDecimal(arr[5]);
                        //litigation.Thirdparty = litigations.V3rd_Party_Entity;
                        litigation.AwardType = arr[6];
                        litigationdetails.Add(litigation);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return Json(litigationdetails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetVendorPastExperience()
        {

            List<PastExperienceModel> pastexperienceDetails = new List<PastExperienceModel>();
            try
            {
                var nav = new NavConnection().queries();
                var vendorNo = Session["vendorNo"].ToString();
                var query = nav.fnGetVendorPastExperience(vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        PastExperienceModel pastexperience = new PastExperienceModel();
                        pastexperience.Entry_No = Convert.ToInt32(arr[1]);
                        pastexperience.Vendor_No = vendorNo;
                        pastexperience.Client_Name = arr[0];
                        pastexperience.Address = arr[2];
                        pastexperience.City = arr[12];
                        pastexperience.Phone_No = arr[13];
                        pastexperience.Nationality_ID = arr[14];
                        pastexperience.Date_of_Birth = Convert.ToString(arr[15]);
                        pastexperience.Entity_Ownership = Convert.ToString(arr[16]);
                        pastexperience.Primary_Contact_Person = arr[11];
                        pastexperience.Assignment_Start_Date = Convert.ToString(arr[5]);
                        pastexperience.Assignment_End_Date = Convert.ToString(arr[6]);
                        pastexperience.Total_Nominal_Value = Convert.ToString(arr[17]);
                        pastexperience.Assignment_Value_LCY = Convert.ToString(arr[8]);
                        pastexperience.Assignment_Status = arr[18];
                        pastexperience.Assignment_Project_Name = arr[3];
                        pastexperience.Contract_Ref_No = arr[9];
                        pastexperience.Delivery_Location = arr[10];
                        pastexperience.Project_Scope_Summary = arr[4];
                        pastexperienceDetails.Add(pastexperience);

                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }


            return Json(pastexperienceDetails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetBidEquipmentsDetails(string BidResponseNumber)
        {
            List<BidEquipmentsSpecificationModel> equipmentsdetails = new List<BidEquipmentsSpecificationModel>();
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().queries();

                var query = nav.fnGetBidSpecificationEquipment(BidResponseNumber);

                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BidEquipmentsSpecificationModel equipment = new BidEquipmentsSpecificationModel();
                        equipment.No = arr[0];
                        equipment.Equipment_Type_Code = Convert.ToString(arr[1]);
                        equipment.Ownership_Type = arr[2];
                        equipment.Equipment_Serial = arr[3];
                        equipment.Equipment_Condition_Code = arr[4];
                        equipment.Equipment_Usability_Code = arr[5];
                        equipment.Qty_of_Equipment = Convert.ToDecimal(arr[6]);
                        equipment.Description = arr[7];
                        equipment.Years_of_Previous_Use = Convert.ToString(arr[8]);
                        equipment.Entry_No = Convert.ToString(arr[9]);
                        equipmentsdetails.Add(equipment);

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return Json(equipmentsdetails, JsonRequestBehavior.AllowGet);
        }

        private JsonResult GetStaffDetails(string tendernumber)
        {
            List<TenderKeyStaffModel> list = new List<TenderKeyStaffModel>();
            try
            {

                var nav = new NavConnection().queries();
                var query = nav.fnGetIFSKeyStaff(tendernumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        TenderKeyStaffModel staff = new TenderKeyStaffModel();
                        staff.IFS_Code = tendernumber;
                        staff.Staff_Role_Code = Convert.ToString(arr[0]);
                        staff.Title_Designation_Description = arr[1];
                        staff.Min_No_of_Recomm_Staff = Convert.ToString(arr[2]);
                        staff.Requirement_Type = arr[3];
                        staff.Staff_Category = arr[4];
                        list.Add(staff);

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetVendorBideResponsPastExperience(string BidResponseNumber)
        {
            List<BidPastExperienceModel> pastexperiencedetails = new List<BidPastExperienceModel>();
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().queries();
                var query = nav.fnGetBidPastExperience(BidResponseNumber, vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BidPastExperienceModel pastexperience = new BidPastExperienceModel();
                        pastexperience.No = BidResponseNumber;
                        pastexperience.Address = Convert.ToString(arr[0]);
                        pastexperience.Vendor_No = vendorNo;
                        pastexperience.Client_Name = Convert.ToString(arr[1]);
                        pastexperience.City = Convert.ToString(arr[2]);
                        pastexperience.Address_2 = Convert.ToString(arr[3]);
                        pastexperience.Phone_No = Convert.ToString(arr[4]);
                        pastexperience.Nationality_ID = Convert.ToString(arr[5]);
                        pastexperience.Citizenship_Type = Convert.ToString(arr[6]);
                        pastexperience.Entity_Ownership = Convert.ToString(arr[7]);
                        pastexperience.Share_Types = Convert.ToString(arr[8]);
                        pastexperience.No_of_Shares = Convert.ToString(arr[9]);
                        pastexperience.Nominal_Value_Share = Convert.ToString(arr[10]);
                        pastexperience.Total_Nominal_Value = Convert.ToString(arr[11]);
                        pastexperience.Ownership_Effective_Date = Convert.ToString(arr[32]);
                        pastexperience.Country_Region_Code = Convert.ToString(arr[31]);
                        pastexperience.Post_Code = Convert.ToString(arr[30]);
                        pastexperience.County = Convert.ToString(arr[29]);
                        pastexperience.E_Mail = Convert.ToString(arr[28]);
                        pastexperience.Blocked = Convert.ToString(arr[27]);
                        pastexperience.No_Series = Convert.ToString(arr[26]);
                        pastexperience.Primary_Contact_Person = Convert.ToString(arr[25]);
                        pastexperience.Primary_Contact_Tel = Convert.ToString(arr[24]);
                        pastexperience.Primary_Contact_Designation = Convert.ToString(arr[23]);
                        pastexperience.Primary_Contact_Email = Convert.ToString(arr[22]);
                        pastexperience.Project_Scope_Summary = Convert.ToString(arr[21]);
                        pastexperience.Delivery_Location = Convert.ToString(arr[20]);
                        pastexperience.Contract_Ref_No = Convert.ToString(arr[19]);
                        pastexperience.Assignment_Start_Date = Convert.ToString(arr[18]);
                        pastexperience.Assignment_End_Date = Convert.ToString(arr[17]);
                        pastexperience.Assignment_Value_LCY = Convert.ToString(arr[16]);
                        pastexperience.Assignment_Status = Convert.ToString(arr[15]);
                        pastexperience.Project_Completion_Value = Convert.ToString(arr[14]);
                        pastexperience.Project_Completion_Work = Convert.ToString(arr[13]);
                        pastexperience.Assignment_Project_Name = Convert.ToString(arr[12]);
                        pastexperiencedetails.Add(pastexperience);

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return Json(pastexperiencedetails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetBidResponsePricingDetails(string BidResponseNumber)
        {
            List<BidResponseItemLinesModel> list = new List<BidResponseItemLinesModel>();
            try
            {
                var nav = new NavConnection().queries();
                var vendorNo = Session["vendorNo"].ToString();
                var query = nav.fnGetBidResponseItemLines(vendorNo, BidResponseNumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BidResponseItemLinesModel price = new BidResponseItemLinesModel();
                        price.No = arr[4];
                        price.Document_Type = Convert.ToString(arr[5]);
                        price.Buy_from_Vendor_No = vendorNo;
                        price.Document_No = Convert.ToString(BidResponseNumber);
                        price.Line_No = Convert.ToString(arr[6]);
                        price.Type = Convert.ToString(arr[7]);
                        price.Location_Code = Convert.ToString(arr[1]);
                        price.Expected_Receipt_Date = Convert.ToString(arr[8]);
                        price.Description = Convert.ToString(arr[0]);
                        price.Description_2 = Convert.ToString(arr[9]);
                        price.Unit_of_Measure = Convert.ToString(arr[10]);
                        price.Quantity = Convert.ToString(arr[2]);
                        price.Amount = Convert.ToString(arr[11]);
                        price.Amount_Including_VAT = Convert.ToString(arr[12]);
                        price.Unit_Price_LCY = Convert.ToString(arr[13]);
                        price.Direct_Unit_Cost = Convert.ToString(arr[3]);
                        price.VAT = Convert.ToString(arr[14]);
                        list.Add(price);

                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetBidResponseIncomeStatementDetails(string BidResponseNumber)
        {
            List<BidResponseAuditIncomeStatements> list = new List<BidResponseAuditIncomeStatements>();
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().queries();
                var query = nav.fnGetBidAuditedIncomeStatement(vendorNo, BidResponseNumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BidResponseAuditIncomeStatements incomestatement = new BidResponseAuditIncomeStatements();
                        incomestatement.No = BidResponseNumber;
                        incomestatement.Audit_Year_Code_Reference = Convert.ToString(arr[0]);
                        incomestatement.Vendor_No = vendorNo;
                        incomestatement.Total_Revenue_LCY = Convert.ToString(arr[1]);
                        incomestatement.Total_COGS_LCY = Convert.ToString(arr[2]);
                        incomestatement.Gross_Margin_LCY = Convert.ToString(arr[3]);
                        incomestatement.Total_Operating_Expenses_LCY = Convert.ToString(arr[4]);
                        incomestatement.Operating_Income_EBIT_LCY = Convert.ToString(arr[5]);
                        incomestatement.Other_Non_operating_Re_Exp_LCY = Convert.ToString(arr[6]);
                        incomestatement.Interest_Expense_LCY = Convert.ToString(arr[7]);
                        incomestatement.Income_Before_Taxes_LCY = Convert.ToString(arr[8]);
                        incomestatement.Income_Tax_Expense_LCY = Convert.ToString(arr[9]);
                        incomestatement.Net_Income_from_Ops_LCY = Convert.ToString(arr[10]);
                        incomestatement.Below_the_line_Items_LCY = Convert.ToString(arr[11]);
                        incomestatement.Net_Income = Convert.ToString(arr[12]);
                        incomestatement.Document_Type = Convert.ToString(arr[13]);
                        list.Add(incomestatement);

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTenderSecurityDetails(string BidResponseNumber)
        {
            List<BidResponseContractSecurity> list = new List<BidResponseContractSecurity>();
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().queries();
                var query = nav.fnGetBidContractSecurity(vendorNo, BidResponseNumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {

                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BidResponseContractSecurity security = new BidResponseContractSecurity();
                        security.No = BidResponseNumber;
                        security.Document_Type = Convert.ToString(arr[0]);
                        security.IFS_Code = arr[1];
                        security.Vendor_No = Convert.ToString(vendorNo);
                        security.Security_Type = Convert.ToString(arr[2]);
                        security.Issuer_Institution_Type = Convert.ToString(arr[3]);
                        security.Issuer_Registered_Offices = Convert.ToString(arr[4]);
                        security.Description = Convert.ToString(arr[5]);
                        security.Security_Amount_LCY = Convert.ToString(arr[6]);
                        security.Bid_Security_Effective_Date = Convert.ToString(arr[7]);
                        security.Bid_Security_Validity_Expiry = Convert.ToString(arr[8]);
                        security.Security_ID = Convert.ToString(arr[9]);
                        security.Security_Closure_Date = Convert.ToString(arr[10]);
                        security.Security_Closure_Voucher_No = Convert.ToString(arr[11]);
                        security.Security_Closure_Type = Convert.ToString(arr[12]);
                        security.Form_of_Security = Convert.ToString(arr[13]);
                        security.Issuer_Guarantor_Name = Convert.ToString(arr[14]);
                        list.Add(security);

                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetBidResponseBalanceSheetDetails(string BidResponseNumber)
        {
            List<BidResponseAuditBalanceSheet> list = new List<BidResponseAuditBalanceSheet>();
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().queries();
                var query = nav.fnGetBidAuditedBalanceSheet(vendorNo, BidResponseNumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BidResponseAuditBalanceSheet balancesheet = new BidResponseAuditBalanceSheet();
                        balancesheet.No = BidResponseNumber;
                        balancesheet.Audit_Year_Code_Reference = Convert.ToString(arr[0]);
                        balancesheet.Vendor_No = vendorNo;
                        balancesheet.Current_Assets_LCY = Convert.ToString(arr[1]);
                        balancesheet.Fixed_Assets_LCY = Convert.ToString(arr[2]);
                        balancesheet.Total_Assets_LCY = Convert.ToString(arr[3]);
                        balancesheet.Current_Liabilities_LCY = Convert.ToString(arr[4]);
                        balancesheet.Long_term_Liabilities_LCY = Convert.ToString(arr[5]);
                        balancesheet.Total_Liabilities_LCY = Convert.ToString(arr[6]);
                        balancesheet.Debt_Ratio = Convert.ToString(arr[7]);
                        balancesheet.Working_Capital_LCY = Convert.ToString(arr[8]);
                        balancesheet.Owners_Equity_LCY = Convert.ToString(arr[9]);
                        balancesheet.Current_Ratio = Convert.ToString(arr[10]);
                        balancesheet.Assets_To_Equity_Ratio = Convert.ToString(arr[11]);
                        balancesheet.Debt_To_Equity_Ratio = Convert.ToString(arr[12]);
                        list.Add(balancesheet);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetBalanceSheetDetails()
        {
            List<BalanceSheetTModel> list = new List<BalanceSheetTModel>();
            try
            {

                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().queries();
                var query = nav.fnGetVendorBalanceSheet(vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BalanceSheetTModel balancesheet = new BalanceSheetTModel();
                        balancesheet.Audit_Year_Code_Reference = arr[0];
                        balancesheet.Current_Assets_LCY = Convert.ToDecimal(arr[1]);
                        balancesheet.Fixed_Assets_LCY = Convert.ToDecimal(arr[2]);
                        balancesheet.Total_Assets_LCY = Convert.ToDecimal(arr[3]);
                        balancesheet.Current_Liabilities_LCY = Convert.ToDecimal(arr[4]);
                        balancesheet.Long_term_Liabilities_LCY = Convert.ToDecimal(arr[5]);
                        balancesheet.Total_Liabilities_LCY = Convert.ToDecimal(arr[6]);
                        balancesheet.Owners_Equity_LCY = Convert.ToDecimal(arr[7]);
                        balancesheet.Debt_Ratio = Convert.ToDecimal(arr[8]);
                        balancesheet.Working_Capital_LCY = Convert.ToDecimal(arr[9]);
                        balancesheet.Assets_To_Equity_Ratio = Convert.ToDecimal(arr[10]);
                        balancesheet.Debt_To_Equity_Ratio = Convert.ToDecimal(arr[11]);
                        list.Add(balancesheet);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetIncomeStatementSheetDetails()
        {
            List<IncomeStatementTModel> list = new List<IncomeStatementTModel>();
            try
            {

                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().queries();

                var query = nav.fnGetVendorIncomeStatement(vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        IncomeStatementTModel income = new IncomeStatementTModel();
                        income.Audit_Year_Code_Reference = arr[0];
                        income.Total_Revenue_LCY = Convert.ToDecimal(arr[1]);
                        income.Total_COGS_LCY = Convert.ToDecimal(arr[2]);
                        income.Gross_Margin_LCY = Convert.ToDecimal(arr[3]);
                        income.Total_Operating_Expenses_LCY = Convert.ToDecimal(arr[4]);
                        income.Operating_Income_EBIT_LCY = Convert.ToDecimal(arr[5]);
                        income.Other_Non_operating_Re_Exp_LCY = Convert.ToDecimal(arr[6]);
                        income.Interest_Expense_LCY = Convert.ToDecimal(arr[7]);
                        income.Income_Before_Taxes_LCY = Convert.ToDecimal(arr[8]);
                        income.Income_Tax_Expense_LCY = Convert.ToDecimal(arr[9]);
                        income.Net_Income_from_Ops_LCY = Convert.ToDecimal(arr[10]);
                        income.Net_Income = Convert.ToDecimal(arr[11]);
                        list.Add(income);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSupplierRgistrationDocuments()
        {
            List<RegistrationDocumentsModel> list = new List<RegistrationDocumentsModel>();
            try
            {

                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().queries();
                var query = nav.fnGetVendorFiledRegDocuments(vendorNo, "Registration");

                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        RegistrationDocumentsModel documents = new RegistrationDocumentsModel();
                        documents.Procurement_Process = "Registration";
                        documents.Procurement_Document_Type_ID = arr[0];
                        documents.Description = arr[1];
                        documents.Date_Filed = Convert.ToString(arr[2]);
                        documents.Certificate_No = arr[3];
                        documents.Issue_Date = Convert.ToString(arr[4]);
                        documents.Expiry_Date = Convert.ToString(arr[5]);
                        documents.File_Name = arr[6];
                        documents.File_Type = arr[7];
                        documents.File_Extension = arr[8];
                        documents.entryNo = Convert.ToInt32(arr[9]);
                        list.Add(documents);


                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPrequalificationsDocuments(string PrequalificationNumber)
        {
            List<PreQualificationRequiredDocuments> list = new List<PreQualificationRequiredDocuments>();
            try
            {

                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().queries();

                var query = nav.fnGetRFIResponseFiledDocument(vendorNo, PrequalificationNumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        PreQualificationRequiredDocuments document = new PreQualificationRequiredDocuments();
                        document.Certificate_No = arr[3];
                        document.Procurement_Document_Type = arr[8];
                        document.Procurement_Document_Type_ID = arr[8];
                        document.Description = arr[0];
                        document.Issue_Date = Convert.ToString(arr[1]);
                        document.Expiry_Date = Convert.ToString(arr[2]);
                        document.File_Name = arr[5];
                        document.Date_Filed = Convert.ToString(arr[9]);
                        list.Add(document);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult RegisterSupplier(VendorModel vendormodel)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();

                var nav = new NavConnection().ObjNav();
                DateTime myOpsdate, myIncopdate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                myOpsdate = DateTime.Parse(vendormodel.OpsDate, usCulture.DateTimeFormat);
                myIncopdate = DateTime.Parse(vendormodel.DateofIncorporation, usCulture.DateTimeFormat);
                DateTime effectivedate, expirydate;
                String certNumber, specialGroup, serviceCategory;
                // the values below might be null if one does not have a GPO certificate

                if (vendormodel.Certifcate_No == "" || vendormodel.Certifcate_No == null)
                {
                    certNumber = "";
                }
                else
                {
                    certNumber = vendormodel.Certifcate_No;
                }
                if (vendormodel.Registered_Specia_Group == "" || vendormodel.Registered_Specia_Group == null)
                {
                    specialGroup = "";
                }
                else
                {
                    specialGroup = vendormodel.Registered_Specia_Group;
                }
                if (vendormodel.Products_Service_Category == "" || vendormodel.Products_Service_Category == null)
                {
                    serviceCategory = "";
                }
                else
                {
                    serviceCategory = vendormodel.Products_Service_Category;
                }
                if (vendormodel.Certificate_Effective_Date != null && vendormodel.Certificate_Effective_Date != "")
                {
                    effectivedate = DateTime.Parse(vendormodel.Certificate_Effective_Date, usCulture.DateTimeFormat);
                }
                else
                {
                    effectivedate = new DateTime(); // will initialize with date (01/01/0001) and time (00:00:00)
                }
                if (vendormodel.Certificate_Expiry_Date != null && vendormodel.Certificate_Expiry_Date != "")
                {
                    expirydate = DateTime.Parse(vendormodel.Certificate_Expiry_Date, usCulture.DateTimeFormat);
                }
                else
                {
                    expirydate = new DateTime(); // will initialize with date (01/01/0001) and time (00:00:00)
                }
                bool haveAgpo = false;
                if (vendormodel.Haveagpo == "0")
                {
                    haveAgpo = false;
                }
                else if (vendormodel.Haveagpo == "1")
                {
                    haveAgpo = true;
                }
                var status = nav.fnSupplierRegistration(vendormodel.BusinessType, vendormodel.VendorType, vendormodel.OwnerType, myIncopdate, myOpsdate, vendormodel.LanguageCode, vendorNo, vendormodel.CertofIncorporation, certNumber, specialGroup, serviceCategory, effectivedate, expirydate, haveAgpo);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult BusinessProfile(VendorModel vendormodel)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();

                if (vendormodel.Vision == null)
                {
                    vendormodel.Vision = " ";
                }
                if (vendormodel.Mision == null)
                {
                    vendormodel.Mision = " ";
                }
                if (vendormodel.IndustryGroup == null)
                {
                    vendormodel.IndustryGroup = " ";
                }
                if (vendormodel.PhysicalLocation == null)
                {
                    vendormodel.PhysicalLocation = "";
                }

                var nav = new NavConnection().ObjNav();

                var status = nav.FnSupplierBusinessProfile(vendormodel.IndustryGroup, vendormodel.CompanySize, vendormodel.NominalCap, vendormodel.Vision, vendormodel.Mision, vendormodel.PhysicalLocation, vendormodel.MaxBizValue, vendormodel.MobileNo, vendormodel.NatureofBz, vendorNo);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult CommunicationDetails(VendorModel vendormodel)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();

                if (vendormodel.WebUrl == null)
                {
                    vendormodel.WebUrl = " ";
                }
                //if (vendormodel.HouseNo == null)
                //{
                //    vendormodel.HouseNo = " ";
                //}
                if (vendormodel.Fax == null)
                {
                    vendormodel.Fax = " ";
                }
                if (vendormodel.WebUrl == null)
                {
                    vendormodel.WebUrl = " ";
                }
                if (vendormodel.PlotNo == null)
                {
                    vendormodel.PlotNo = " ";
                }

                //if (vendormodel.StreetorRoad == null)
                //{
                //    vendormodel.StreetorRoad = " ";
                //}





                var nav = new NavConnection().ObjNav();

                CultureInfo usCulture = new CultureInfo("es-ES");


                var status = nav.FnSupplierCommunicationDetails(vendormodel.PostaCode, vendormodel.CountryofOrigin, vendormodel.PoBox, vendormodel.PostaCity, vendormodel.WebUrl, vendormodel.TelephoneNo, vendormodel.HouseNo, vendormodel.FloorNo, vendormodel.PlotNo, vendormodel.StreetorRoad, vendormodel.Fax, vendorNo);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult RegisterSupplierBankDetails(BankModel bankmodel)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var vendorName = Session["name"].ToString();
                var nav = new NavConnection().ObjNav();

                if (bankmodel.BankName == null)
                {
                    bankmodel.BankName = "";
                }

                if (bankmodel.Post_Code == null)
                {
                    bankmodel.Post_Code = "";
                }

                if (bankmodel.Phone_No == null)
                {
                    bankmodel.Phone_No = "";
                }

                var status = nav.fnInsertBankDetails(vendorNo, bankmodel.BankCode, bankmodel.BankName, bankmodel.CurrencyCode, bankmodel.BankAccountNo, bankmodel.Bank_Branch_No, bankmodel.Phone_No, bankmodel.CountryCode, bankmodel.Post_Code);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult DeleteBankDetails(string bankcode)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();

                var status = nav.fnDeleteBank(vendorNo, bankcode);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult DeleteBidSecurityDetails(string bidresponsNumber, string securityid)
        {

            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var securityNumber = Convert.ToInt32(securityid);
                var nav = new NavConnection().ObjNav();
                var status = nav.fnDeleteBidResponTenderSecurity(vendorNo, bidresponsNumber, securityNumber);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }



        }

        public JsonResult DeleteKeyProffessionalStaffDetails(string staffnumber)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.fnDeleteStaffExperience(vendorNo, staffnumber);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }

        public JsonResult DeleteBidResponseStaffDetails(int staffnumber)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.fnDeleteBidResponsePersonel(vendorNo, staffnumber);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        public JsonResult DeleteEquipmentDetails(string serialnumber)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.fnDeleteBidResponseEquipmentDetails(vendorNo, serialnumber);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        public JsonResult DeleteShareholdersDetails(int shareholderCode)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.fnDeleteShareholder(vendorNo, shareholderCode);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }

        public JsonResult DeleteBeneficiaryDetails(int beneficiaryCode)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.fnDeleteBeneficiary(vendorNo, beneficiaryCode);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        public JsonResult DeleteLitigationHistoryDetails(int litigationCode)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.fnDeleteLitigationHistoryDetails(vendorNo, litigationCode);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        public JsonResult DeleteResponsibilityCenter(String regionCode)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.fnDeleteResponsibilityCenter(vendorNo, regionCode);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        public JsonResult DeletePastExperienceDetails(int pastExperienceCode)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.fnDeletePastExperienceDetails(vendorNo, pastExperienceCode);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        public JsonResult DeleteBalanceSheetDetails(string yearCode)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.fnDeleteBalanceSheetDetails(vendorNo, yearCode);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        public JsonResult DeletePastExperienceDetailsDetails(string BidRespNumber)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.fnDeleteBidResponsPastExperienceDetails(vendorNo, BidRespNumber);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        public JsonResult DeleteBidResponseBalanceSheetDetails(string BidRespNumber, string yearCode)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.fnDeleteBidResponsBalanceSheetDetails(vendorNo, yearCode, BidRespNumber);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        public JsonResult DeleteIncomeStatementDetails(string yearCode)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.fnDeleteIncomeStatementDetails(vendorNo, yearCode);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        public JsonResult DeleteBidResponseIncomeStatementDetails(string BidRespNumber, string yearCode)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.fnDeleteBidResponsIncomeStatamentDetails(vendorNo, yearCode, BidRespNumber);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        public JsonResult DeleteBidTenderSecurityDetails(string BidRespNumber, string Securityid)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var securityNumber = Convert.ToInt32(Securityid);
                var nav = new NavConnection().ObjNav();
                var status = nav.fnDeleteBidResponTenderSecurity(vendorNo, BidRespNumber, securityNumber);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult RegisterBidSecurityDetails(BidResponseContractSecurity bidsecurityModel, HttpPostedFileBase browsedfile)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var bidresponsenumber = Session["BideResponseNumber"].ToString();
                DateTime validity, effectivedate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                validity = DateTime.Parse(bidsecurityModel.Bid_Security_Validity_Expiry, usCulture.DateTimeFormat);
                effectivedate = DateTime.Parse(bidsecurityModel.Bid_Security_Effective_Date, usCulture.DateTimeFormat);
                var nav = new NavConnection().ObjNav();
                var status = nav.fnInsertBidResponseSecurityDetails(vendorNo, bidsecurityModel.No, bidsecurityModel.IFS_No,
                    bidsecurityModel.Form_of_Security, Convert.ToInt32(bidsecurityModel.Issuer_Institution_Type), Convert.ToInt32(bidsecurityModel.Security_Type), bidsecurityModel.Issuer_Guarantor_Name,
                   bidsecurityModel.Issuer_Registered_Offices, bidsecurityModel.Description, Convert.ToDecimal(bidsecurityModel.Security_Amount_LCY), effectivedate, validity);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult RegisterSupplierShareholderDetails(ShareholderModel shareholderModel)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                int companyType = 0;

                if (shareholderModel.registrationNumber == null)
                {
                    shareholderModel.registrationNumber = "";
                }
                if (shareholderModel.entityType == null)
                {
                    shareholderModel.entityType = "0";
                }
                if (shareholderModel.Company_Type == null)
                {
                    companyType = 0;
                }
                else
                {
                    companyType = Convert.ToInt32(shareholderModel.Company_Type);
                }
                if (shareholderModel.kraPin == null)
                {
                    shareholderModel.kraPin = "";
                }
                if (shareholderModel.ID_Passport_No == null)
                {
                    shareholderModel.ID_Passport_No = "";
                }
                if (shareholderModel.Nationality_ID == null)
                {
                    shareholderModel.Nationality_ID = "";
                }


                var status = nav.fnInsertDirectorDetails(vendorNo, shareholderModel.Name, shareholderModel.ID_Passport_No, Convert.ToInt32(shareholderModel.Citizenship_Type),
                   Convert.ToDecimal(shareholderModel.Entity_Ownership), shareholderModel.Phone_No, shareholderModel.Address, shareholderModel.E_Mail, shareholderModel.Nationality_ID, shareholderModel.shareholdersDetails,
                   shareholderModel.registrationNumber, shareholderModel.kraPin, shareholderModel.entityType, companyType);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult RegisterSupplierBeneficiaries(BeneficiarryModel beneficiaryModel)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();

                var status = nav.fnInsertBeneficiaries(vendorNo, beneficiaryModel.Name, Convert.ToInt32(beneficiaryModel.BeneficiaryType), Convert.ToInt32(beneficiaryModel.idType),
                   beneficiaryModel.idpassportNumber, beneficiaryModel.Phonenumber, beneficiaryModel.Email, beneficiaryModel.AllocatedShares);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult RegisterLitigationHistoryDetails(LitigationModel litigationmodels)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                string docNo = Session["inviteNo"].ToString();
                var nav = new NavConnection().ObjNav();
                decimal amount = Convert.ToDecimal(litigationmodels.DisputeAmounts);
                string description = litigationmodels.DisputeDescription;
                int category = Convert.ToInt32(litigationmodels.CategoryofDispute);
                string year=litigationmodels.Year;
                string party = litigationmodels.TheotherDisputeparty;
                int type = Convert.ToInt32(litigationmodels.AwardType);
                var status = nav.fnInsertLitigationHistoryDetails(docNo,vendorNo, description, category, year, party, amount, type);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult RegisterPastExperienceDetails(string Client_Name, string Address, string Assignment_Project_Name, string Project_Scope_Summary, string Assignment_Start_Date, string Assignment_End_Date, string Assignment_Value_LCY)
        {
            // ,string Engangement_Type,string Main_Contractor,HttpPostedFileBase browsedfile
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();


                DateTime startdate, enddate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                startdate = DateTime.Parse(Assignment_Start_Date, usCulture.DateTimeFormat);
                enddate = DateTime.Parse(Assignment_End_Date, usCulture.DateTimeFormat);

                var status = nav.fnInsertPastExperienceDetails(vendorNo, Client_Name, Address, Assignment_Project_Name,
                 Project_Scope_Summary, startdate, enddate, Convert.ToDecimal(Assignment_Value_LCY), "", "");
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult RegisterBalanceSheetDetails(BalanceSheetTModel balancesheet)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.fnInsertBalanceSheet(balancesheet.Audit_Year_Code_Reference, Convert.ToDecimal(balancesheet.Total_Assets_LCY), Convert.ToDecimal(balancesheet.Fixed_Assets_LCY),
                 Convert.ToDecimal(balancesheet.Current_Liabilities_LCY), Convert.ToDecimal(balancesheet.Long_term_Liabilities_LCY), Convert.ToDecimal(balancesheet.Owners_Equity_LCY), vendorNo);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult BidResponseBalanceSheetDetails(BalanceSheetTModel balancesheet)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.fnBidResponseInsertBalanceSheet(balancesheet.No, balancesheet.Audit_Year_Code_Reference, Convert.ToDecimal(balancesheet.Total_Assets_LCY), Convert.ToDecimal(balancesheet.Fixed_Assets_LCY),
                 Convert.ToDecimal(balancesheet.Current_Liabilities_LCY), Convert.ToDecimal(balancesheet.Long_term_Liabilities_LCY), Convert.ToDecimal(balancesheet.Owners_Equity_LCY), vendorNo);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult BidResponsePriceDetails(BidResponseItemLinesModel pricedetails)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.fnInsertPurchaseLinesDetails(vendorNo, pricedetails.Document_No, Convert.ToInt32(pricedetails.Line_No), pricedetails.No,
                Convert.ToDecimal(pricedetails.Direct_Unit_Cost), Convert.ToDecimal(pricedetails.Quantity));
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }
        }
        public ActionResult ViewPrequalificationsConstituencies()
        {
            List<ConstituenciesModel> constituencies = new List<ConstituenciesModel>();
            try
            {


            }
            catch (Exception e)
            {

                throw;
            }
            return View(constituencies);
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult BidResponsePastExperienceDetails(BidPastExperienceModel pastexperience)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                DateTime startdate, enddate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                startdate = DateTime.Parse(pastexperience.Assignment_Start_Date, usCulture.DateTimeFormat);
                enddate = DateTime.Parse(pastexperience.Assignment_End_Date, usCulture.DateTimeFormat);
                var nav = new NavConnection().ObjNav();
                var status = nav.fnBidResponsePastExperience(pastexperience.No, pastexperience.Client_Name, pastexperience.Address, pastexperience.Phone_No,
                 pastexperience.Country_Region_Code, pastexperience.Primary_Contact_Email, pastexperience.Project_Scope_Summary, pastexperience.Assignment_Project_Name,
                 pastexperience.Contract_Ref_No, Convert.ToDecimal(pastexperience.Assignment_Value_LCY), Convert.ToInt32(pastexperience.Assignment_Status), startdate, enddate, vendorNo);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }
        }


        [HttpPost]
        [AllowAnonymous]
        public JsonResult PerformanceGuaranteeDetails(performanceGuarantee perfGuarantee)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                DateTime startdate, enddate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                startdate = DateTime.Parse(perfGuarantee.effectiveDate, usCulture.DateTimeFormat);
                enddate = DateTime.Parse(perfGuarantee.expiryDate, usCulture.DateTimeFormat);

                if (string.IsNullOrEmpty(perfGuarantee.docNo))
                {
                    perfGuarantee.docNo = "";
                }

                var nav = new NavConnection().ObjNav();
                var status = nav.FnPerformanceGiarantee(perfGuarantee.docNo, perfGuarantee.purchaseContractId, perfGuarantee.projectId, vendorNo,
                 perfGuarantee.gurantorName, perfGuarantee.policyNo, Convert.ToDecimal(perfGuarantee.amount), perfGuarantee.formOfSec,
                Convert.ToInt32(perfGuarantee.InstType), perfGuarantee.regOffice, perfGuarantee.insurerEmail, startdate, enddate);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        Session["Response"] = res[2];
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }
        }


        [HttpPost]
        [AllowAnonymous]
        public JsonResult fnSubmitPerformanceGuarantee(performanceGuarantee perfGuarantee)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();


                if (string.IsNullOrEmpty(perfGuarantee.docNo))
                {
                    return Json("danger*" + "Application Number cannot be empty", JsonRequestBehavior.AllowGet);
                }

                var nav = new NavConnection().ObjNav();
                var status = nav.FnSubmitPerformanceGiarantee(perfGuarantee.docNo);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult BidResponseIncomeStatementDetails(IncomeStatementTModel incomestatement)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.fnBidResponseInsertIncomestatement(incomestatement.No, incomestatement.Audit_Year_Code_Reference, Convert.ToDecimal(incomestatement.Total_Revenue_LCY), Convert.ToDecimal(incomestatement.Total_COGS_LCY),
                 Convert.ToDecimal(incomestatement.Total_Operating_Expenses_LCY), Convert.ToDecimal(incomestatement.Other_Non_operating_Re_Exp_LCY), Convert.ToDecimal(incomestatement.Interest_Expense_LCY), vendorNo);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult RegisterIncomeStatementDetails(IncomeStatementTModel incomestatement)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.fnInsertIncomestatement(incomestatement.Audit_Year_Code_Reference, Convert.ToDecimal(incomestatement.Total_Revenue_LCY), Convert.ToDecimal(incomestatement.Total_COGS_LCY),
                 Convert.ToDecimal(incomestatement.Total_Operating_Expenses_LCY), Convert.ToDecimal(incomestatement.Other_Non_operating_Re_Exp_LCY), Convert.ToDecimal(incomestatement.Interest_Expense_LCY), vendorNo);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult RegisterSpecialGroupDetails(VendorSpecialGroupModel specialgroup)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                DateTime effectivedate, expirydate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                effectivedate = DateTime.Parse(specialgroup.Certificate_Effective_Date, usCulture.DateTimeFormat);
                expirydate = DateTime.Parse(specialgroup.Certificate_Expiry_Date, usCulture.DateTimeFormat);
                var nav = new NavConnection().ObjNav();
                var status = nav.FnAddVendorSpecialGroupDetails(vendorNo, specialgroup.Certifcate_No, specialgroup.Registered_Specia_Group,
                specialgroup.Products_Service_Category, effectivedate, expirydate);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult RegisterKeyPersonnelDetails(StaffEntryTModel staffmodel)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                CultureInfo usCulture = new CultureInfo("es-ES");
                var stfDateofbirth = DateTime.Parse(staffmodel.StaffDateofBirth, usCulture.DateTimeFormat);
                var stfJoiningDate = DateTime.Parse(staffmodel.StaffJoiningDate, usCulture.DateTimeFormat);

                var status = nav.fnInsertStaffEntry(vendorNo, staffmodel.StaffName, staffmodel.StaffProfession, staffmodel.StaffDesignation, staffmodel.StaffPhonenumber,
                staffmodel.StaffNationality, stfDateofbirth, staffmodel.StaffEmail, stfJoiningDate, staffmodel.StaffYearswithfirm, staffmodel.StaffNumber, staffmodel.employmentType);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }
        }
        public ActionResult SupplierProfile()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.Vendors = GetVendors(vendorNo);
                model.BanksDetails = GetBanks(vendorNo);
                model.StakeholdersDetails = GetStakeholders(vendorNo);
                model.Litigations = GetVendorLitigationHistoryDetails(vendorNo);
                model.VendorPastExperience = GetVendorPastExeprience(vendorNo);
                model.Vendorbalancesheet = GetVendorBalanaceDetails(vendorNo);
                model.Vendorincomestatement = GetVendorIncomeStatementDetails(vendorNo);
                model.VendorProfessionalStaff = GetVendorProfessionalStaff(vendorNo);
                model.AttachedDocuments = PopulateSupplierRegistrationDocuments(vendorNo);
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult ViewSingleAddendumNotice(string AddendumNumber)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.Addendum = GetAddendumDetails(AddendumNumber);

                model.Summary = GetAddendumAmmendmentDetails(AddendumNumber);
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult RespondTenderWizard(string respondtendernumber)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (Session["BideResponseNumber"] == null)
            {
                return RedirectToAction("ActiveTenderNotices", "Home");
            }

            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                var BidResponseNumber = Session["BideResponseNumber"].ToString();
                dynamic model = new ExpandoObject();
                ViewBag.prequalificationNo = BidResponseNumber;
                model.BidDetails = GetBidResponseDetails(BidResponseNumber, vendorNo);
                model.BidEquipments = GetBidResponseEquipments(BidResponseNumber);
                model.BidBalnaceSheet = GetBidResponseBalanceSheet(BidResponseNumber, vendorNo);
                model.BidIncomeStatement = GetBidResponseIncomeStatement(BidResponseNumber, vendorNo);
                model.BidPastExperiencent = GetBidResponsePastExperience(BidResponseNumber, vendorNo);
                model.BidPersonnel = GetBidResponsePersonnel(BidResponseNumber);
                model.BidPricinginformation = GetBidResponsePricingInformation(BidResponseNumber);
                model.RequiredDocuments = GetRequiredTenderDocuments(respondtendernumber);
                model.RequredDocuemnts = GetIFSRequiredEquipments(respondtendernumber);
                model.TenderskeystaffDetails = GetKeyStaffTenderPersonnel(respondtendernumber);
                model.BidSecurity = GetBidSecurityResponse(BidResponseNumber, vendorNo);
                model.AttachedBiddDocuments = GetBidAttachedDocumentsDetails(BidResponseNumber, vendorNo);

                return View(model);
            }
        }

        private static List<BidResponseContractSecurity> GetBidSecurityResponse(string BidResponseNumber, string vendorNo)
        {
            List<BidResponseContractSecurity> list = new List<BidResponseContractSecurity>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetBidContractSecurity(vendorNo, BidResponseNumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BidResponseContractSecurity security = new BidResponseContractSecurity();
                        security.No = BidResponseNumber;
                        security.Document_Type = Convert.ToString(arr[0]);
                        security.IFS_Code = arr[1];
                        security.Vendor_No = Convert.ToString(vendorNo);
                        security.Security_Type = Convert.ToString(arr[2]);
                        security.Issuer_Institution_Type = Convert.ToString(arr[3]);
                        security.Issuer_Registered_Offices = Convert.ToString(arr[4]);
                        security.Description = Convert.ToString(arr[5]);
                        security.Security_Amount_LCY = Convert.ToString(arr[6]);
                        security.Bid_Security_Effective_Date = Convert.ToString(arr[7]);
                        security.Bid_Security_Validity_Expiry = Convert.ToString(arr[8]);
                        security.Security_ID = Convert.ToString(arr[9]);
                        security.Security_Closure_Date = Convert.ToString(arr[10]);
                        security.Security_Closure_Voucher_No = Convert.ToString(arr[11]);
                        security.Security_Closure_Type = Convert.ToString(arr[12]);
                        security.Form_of_Security = Convert.ToString(arr[13]);
                        security.Issuer_Guarantor_Name = Convert.ToString(arr[14]);
                        list.Add(security);

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }

            return list;
        }
        private List<BidResponseItemLinesModel> GetBidResponsePricingInformation(string BidResponseNumber)
        {
            List<BidResponseItemLinesModel> list = new List<BidResponseItemLinesModel>();
            try
            {
                var nav = new NavConnection().queries();
                var vendorNo = Session["vendorNo"].ToString();
                var query = nav.fnGetBidResponseItemLines(vendorNo, BidResponseNumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BidResponseItemLinesModel price = new BidResponseItemLinesModel();
                        price.No = arr[4];
                        price.Document_Type = Convert.ToString(arr[5]);
                        price.Buy_from_Vendor_No = vendorNo;
                        price.Document_No = Convert.ToString(BidResponseNumber);
                        price.Line_No = Convert.ToString(arr[6]);
                        price.Type = Convert.ToString(arr[7]);
                        price.Location_Code = Convert.ToString(arr[1]);
                        price.Expected_Receipt_Date = Convert.ToString(arr[8]);
                        price.Description = Convert.ToString(arr[0]);
                        price.Description_2 = Convert.ToString(arr[9]);
                        price.Unit_of_Measure = Convert.ToString(arr[10]);
                        price.Quantity = Convert.ToString(arr[2]);
                        price.Amount = Convert.ToString(arr[11]);
                        price.Amount_Including_VAT = Convert.ToString(arr[12]);
                        price.Unit_Price_LCY = Convert.ToString(arr[13]);
                        price.Direct_Unit_Cost = Convert.ToString(arr[3]);
                        price.VAT = Convert.ToString(arr[14]);
                        //  price.BoqNumber = prices.BoQ_No;
                        price.ContactTyoe = arr[15];
                        list.Add(price);

                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }

            return list;
        }

        private static List<BidPastExperienceModel> GetBidResponsePastExperience(string BidResponseNumber, string vendorNo)
        {
            List<BidPastExperienceModel> list = new List<BidPastExperienceModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetBidPastExperience(BidResponseNumber, vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BidPastExperienceModel pastexperience = new BidPastExperienceModel();
                        pastexperience.No = BidResponseNumber;
                        pastexperience.Address = Convert.ToString(arr[0]);
                        pastexperience.Vendor_No = vendorNo;
                        pastexperience.Client_Name = Convert.ToString(arr[1]);
                        pastexperience.City = Convert.ToString(arr[2]);
                        pastexperience.Address_2 = Convert.ToString(arr[3]);
                        pastexperience.Phone_No = Convert.ToString(arr[4]);
                        pastexperience.Nationality_ID = Convert.ToString(arr[5]);
                        pastexperience.Citizenship_Type = Convert.ToString(arr[6]);
                        pastexperience.Entity_Ownership = Convert.ToString(arr[7]);
                        pastexperience.Share_Types = Convert.ToString(arr[8]);
                        pastexperience.No_of_Shares = Convert.ToString(arr[9]);
                        pastexperience.Nominal_Value_Share = Convert.ToString(arr[10]);
                        pastexperience.Total_Nominal_Value = Convert.ToString(arr[11]);
                        pastexperience.Ownership_Effective_Date = Convert.ToString(arr[32]);
                        pastexperience.Country_Region_Code = Convert.ToString(arr[31]);
                        pastexperience.Post_Code = Convert.ToString(arr[30]);
                        pastexperience.County = Convert.ToString(arr[29]);
                        pastexperience.E_Mail = Convert.ToString(arr[28]);
                        pastexperience.Blocked = Convert.ToString(arr[27]);
                        pastexperience.No_Series = Convert.ToString(arr[26]);
                        pastexperience.Primary_Contact_Person = Convert.ToString(arr[25]);
                        pastexperience.Primary_Contact_Tel = Convert.ToString(arr[24]);
                        pastexperience.Primary_Contact_Designation = Convert.ToString(arr[23]);
                        pastexperience.Primary_Contact_Email = Convert.ToString(arr[22]);
                        pastexperience.Project_Scope_Summary = Convert.ToString(arr[21]);
                        pastexperience.Delivery_Location = Convert.ToString(arr[20]);
                        pastexperience.Contract_Ref_No = Convert.ToString(arr[19]);
                        pastexperience.Assignment_Start_Date = Convert.ToString(arr[18]);
                        pastexperience.Assignment_End_Date = Convert.ToString(arr[17]);
                        pastexperience.Assignment_Value_LCY = Convert.ToString(arr[16]);
                        pastexperience.Assignment_Status = Convert.ToString(arr[15]);
                        pastexperience.Project_Completion_Value = Convert.ToString(arr[14]);
                        pastexperience.Project_Completion_Work = Convert.ToString(arr[13]);
                        pastexperience.Assignment_Project_Name = Convert.ToString(arr[12]);
                        list.Add(pastexperience);

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }

            return list;
        }
        private static List<BidResponseAuditIncomeStatements> GetBidResponseIncomeStatement(string BidResponseNumber, string vendorNo)
        {
            List<BidResponseAuditIncomeStatements> list = new List<BidResponseAuditIncomeStatements>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetBidAuditedIncomeStatement(vendorNo, BidResponseNumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);

                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BidResponseAuditIncomeStatements incomestatement = new BidResponseAuditIncomeStatements();
                        incomestatement.No = BidResponseNumber;
                        incomestatement.Audit_Year_Code_Reference = Convert.ToString(arr[0]);
                        incomestatement.Vendor_No = vendorNo;
                        incomestatement.Total_Revenue_LCY = Convert.ToString(arr[1]);
                        incomestatement.Total_COGS_LCY = Convert.ToString(arr[2]);
                        incomestatement.Gross_Margin_LCY = Convert.ToString(arr[3]);
                        incomestatement.Total_Operating_Expenses_LCY = Convert.ToString(arr[4]);
                        incomestatement.Operating_Income_EBIT_LCY = Convert.ToString(arr[5]);
                        incomestatement.Other_Non_operating_Re_Exp_LCY = Convert.ToString(arr[6]);
                        incomestatement.Interest_Expense_LCY = Convert.ToString(arr[7]);
                        incomestatement.Income_Before_Taxes_LCY = Convert.ToString(arr[8]);
                        incomestatement.Income_Tax_Expense_LCY = Convert.ToString(arr[9]);
                        incomestatement.Net_Income_from_Ops_LCY = Convert.ToString(arr[10]);
                        incomestatement.Below_the_line_Items_LCY = Convert.ToString(arr[11]);
                        incomestatement.Net_Income = Convert.ToString(arr[12]);
                        incomestatement.Document_Type = Convert.ToString(arr[13]);
                        list.Add(incomestatement);
                    }


                }

            }
            catch (Exception e)
            {

                throw;
            }

            return list;
        }
        private static List<BidResponseAuditBalanceSheet> GetBidResponseBalanceSheet(string BidResponseNumber, string vendorNo)
        {
            List<BidResponseAuditBalanceSheet> list = new List<BidResponseAuditBalanceSheet>();
            try
            {

                var nav = new NavConnection().queries();

                var query = nav.fnGetBidAuditedBalanceSheet(vendorNo, BidResponseNumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BidResponseAuditBalanceSheet balancesheet = new BidResponseAuditBalanceSheet();
                        balancesheet.No = BidResponseNumber;
                        balancesheet.Audit_Year_Code_Reference = Convert.ToString(arr[0]);
                        balancesheet.Vendor_No = vendorNo;
                        balancesheet.Owners_Equity_LCY = Convert.ToString(arr[1]);
                        balancesheet.Current_Assets_LCY = Convert.ToString(arr[2]);
                        balancesheet.Fixed_Assets_LCY = Convert.ToString(arr[3]);
                        balancesheet.Total_Assets_LCY = Convert.ToString(arr[4]);
                        balancesheet.Current_Liabilities_LCY = Convert.ToString(arr[5]);
                        balancesheet.Long_term_Liabilities_LCY = Convert.ToString(arr[6]);
                        balancesheet.Total_Liabilities_LCY = Convert.ToString(arr[7]);
                        balancesheet.Debt_Ratio = Convert.ToString(arr[8]);
                        balancesheet.Working_Capital_LCY = Convert.ToString(arr[9]);
                        balancesheet.Current_Ratio = Convert.ToString(arr[10]);
                        balancesheet.Assets_To_Equity_Ratio = Convert.ToString(arr[11]);
                        balancesheet.Debt_To_Equity_Ratio = Convert.ToString(arr[12]);
                        list.Add(balancesheet);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }

            return list;
        }
        private static List<BidEquipmentsSpecificationModel> GetBidResponseEquipments(string BidResponseNumber)
        {
            List<BidEquipmentsSpecificationModel> list = new List<BidEquipmentsSpecificationModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetBidSpecificationEquipment(BidResponseNumber);

                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BidEquipmentsSpecificationModel equipment = new BidEquipmentsSpecificationModel();
                        equipment.No = arr[0];
                        equipment.Equipment_Type_Code = Convert.ToString(arr[1]);
                        equipment.Ownership_Type = arr[2];
                        equipment.Equipment_Serial = arr[3];
                        equipment.Equipment_Condition_Code = arr[4];
                        equipment.Equipment_Usability_Code = arr[5];
                        equipment.Qty_of_Equipment = Convert.ToDecimal(arr[6]);
                        equipment.Description = arr[7];
                        equipment.Years_of_Previous_Use = Convert.ToString(arr[8]);
                        equipment.Entry_No = Convert.ToString(arr[9]);
                        list.Add(equipment);

                    }
                }

            }


            catch (Exception e)
            {

                throw;
            }

            return list;
        }
        private static List<BidResponsePersonnel> GetBidResponsePersonnel(string BidResponseNumber)
        {
            List<BidResponsePersonnel> list = new List<BidResponsePersonnel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetBidKeyStaffDetails(BidResponseNumber);
                String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BidResponsePersonnel personnel = new BidResponsePersonnel();
                        personnel.No = BidResponseNumber;
                        personnel.StaffCategory = arr[0];
                        personnel.StaffName = arr[1];
                        personnel.ProjectRoleCode = arr[2];
                        personnel.RequiredProfession = arr[3];
                        personnel.EmailAddress = arr[4];
                        personnel.EmploymentType = arr[5];
                        //   personnel.Entry_No = Convert.ToString(arr[2]);
                        list.Add(personnel);

                    }
                }
            }


            catch (Exception e)
            {

                throw;
            }

            return list;
        }
        public JsonResult EditBidIncomeStatementetails(IncomeStatementTModel incomestatement)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.fnEditInsertIncomestatementDetails(incomestatement.No, incomestatement.Audit_Year_Code_Reference, Convert.ToDecimal(incomestatement.Total_Revenue_LCY), Convert.ToDecimal(incomestatement.Total_COGS_LCY),
                 Convert.ToDecimal(incomestatement.Total_Operating_Expenses_LCY), Convert.ToDecimal(incomestatement.Other_Non_operating_Re_Exp_LCY), Convert.ToDecimal(incomestatement.Interest_Expense_LCY), vendorNo);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":

                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult EditBidBalanceSheetDetails(BalanceSheetTModel balancesheet)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.fnEditBidResponseInsertBalanceSheet(balancesheet.No, balancesheet.Audit_Year_Code_Reference, Convert.ToDecimal(balancesheet.Total_Assets_LCY), Convert.ToDecimal(balancesheet.Fixed_Assets_LCY),
                 Convert.ToDecimal(balancesheet.Current_Liabilities_LCY), Convert.ToDecimal(balancesheet.Long_term_Liabilities_LCY), Convert.ToDecimal(balancesheet.Owners_Equity_LCY), vendorNo);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":

                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult AddBidEquipmentsSpecificationDetails(string No, HttpPostedFileBase browsedfile, string Equipment_Type_Code, string Ownership_Type, string Years_of_Previous_Use, string Equipment_Condition_Code,
          string Equipment_Usability_Code, string Equipment_Serial, string Qty_of_Equipment)
        {
            try
            {
                if (Session["vendorNo"] == null)
                {
                    RedirectToAction("Login", "Home");
                }
                string vendorNo = Session["vendorNo"].ToString();               
                var nav = new NavConnection().ObjNav();
                int errCounter = 0;

                if (browsedfile == null)
                {
                    errCounter++;
                    return Json("danger*Select equipment document to upload", JsonRequestBehavior.AllowGet);
                }

                string fileName0 = Path.GetFileName(browsedfile.FileName);
                string ext0 = _getFileextension(browsedfile);
                string savedF0 = vendorNo + "_" + fileName0 + ext0;
                // saving file in local server
                string folder = ConfigurationManager.AppSettings["FilesLocation"] + "Procurement Documents/Equipments/";
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                if (Directory.Exists(folder))
                {
                    String documentDirectory = folder + vendorNo + "/";
                    Boolean createDirectory = true;
                    try
                    {
                        if (!Directory.Exists(documentDirectory))
                        {
                            Directory.CreateDirectory(documentDirectory);
                        }
                    }
                    catch (Exception ex)
                    {
                        createDirectory = false;
                    }
                    if (createDirectory)
                    {
                        string fileLink = documentDirectory + browsedfile.FileName;
                        string filename = vendorNo + "_" + fileName0;
                        browsedfile.SaveAs(fileLink);
                        var status = nav.fnInsertBidEquipmentsDetails(vendorNo, No, Equipment_Type_Code, Convert.ToInt32(Ownership_Type), Convert.ToDecimal(Years_of_Previous_Use),
                       Convert.ToInt32(Equipment_Condition_Code), Convert.ToInt32(Equipment_Usability_Code), Equipment_Serial, Convert.ToDecimal(Qty_of_Equipment), "", filename);
                        var res = status.Split('*');
                        switch (res[0])
                        {
                            case "success":

                                return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                            default:
                                return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json("sharepointerror*", JsonRequestBehavior.AllowGet);
                    }
                }
                return Json("success*", JsonRequestBehavior.AllowGet);




                //    bool up2Sharepoint = _UploadSupplierDocumentToSharepoint(vendorNo, browsedfile, Equipment_Type_Code);


                //if (up2Sharepoint == true)
                //{
                //    string filename = vendorNo + "_" + fileName0;
                //string sUrl = ConfigurationManager.AppSettings["S_URL"];
                //string defaultlibraryname = "Procurement%20Documents/";
                //string customlibraryname = "Vendor Card";
                //string sharepointLibrary = defaultlibraryname + customlibraryname;
                //string sharepointlink = sUrl + sharepointLibrary + "/" + vendorNo + "/" + filename;


                //var status = nav.fnInsertBidEquipmentsDetails(vendorNo, No, Equipment_Type_Code, Convert.ToInt32(Ownership_Type), Convert.ToDecimal(Years_of_Previous_Use),
                //    Convert.ToInt32(Equipment_Condition_Code), Convert.ToInt32(Equipment_Usability_Code), Equipment_Serial, Convert.ToDecimal(Qty_of_Equipment), "", filename);
                //var res = status.Split('*');
                //switch (res[0])
                //{
                //    case "success":

                //        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                //    default:
                //        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                //}
                //}
                //else
                //{
                //    return Json("sharepointError*", JsonRequestBehavior.AllowGet);
                //}

            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult AddBidPersonnelDetails(string No, string StaffName, string StaffCategory, string EmploymentType, string EmailAddress, string Profession, string ProjectRoleCode, string RequiredProfession, HttpPostedFileBase browsedfile)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                int errCounter = 0;

                if (browsedfile == null)
                {
                    errCounter++;
                    return Json("danger*Select Personnel document to upload", JsonRequestBehavior.AllowGet);
                }

                string fileName0 = Path.GetFileName(browsedfile.FileName);
                string ext0 = _getFileextension(browsedfile);
                string savedF0 = vendorNo + "_" + fileName0 + ext0;

                // saving file in local server
                string folder = ConfigurationManager.AppSettings["FilesLocation"] + "Procurement Documents/Personnel/";
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                    if (Directory.Exists(folder))
                {
                    String documentDirectory = folder + vendorNo + "/";
                    Boolean createDirectory = true;
                    try
                    {
                        if (!Directory.Exists(documentDirectory))
                        {
                            Directory.CreateDirectory(documentDirectory);
                        }
                    }
                    catch (Exception ex)
                    {
                        createDirectory = false;
                    }
                    if (createDirectory)
                    {
                        //StaffCategory Number needed
                        string fileLink = documentDirectory + browsedfile.FileName;
                        string filename = vendorNo + "_" + fileName0;
                        browsedfile.SaveAs(fileLink);
                        var status = nav.FnInsertBidPersonnelDetails(vendorNo, No, StaffName, Convert.ToInt32(StaffCategory), Convert.ToInt32(EmploymentType), EmailAddress, Profession, ProjectRoleCode, RequiredProfession, fileLink, filename);
                        var res = status.Split('*');
                        switch (res[0])
                        {
                            case "success":

                                return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                            default:
                                return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                        }
                    }

                }
                else
                {
                    return Json("sharepointerror*", JsonRequestBehavior.AllowGet);
                }
                return Json("success*", JsonRequestBehavior.AllowGet);


                //        bool up2Sharepoint = _UploadSupplierDocumentToSharepoint(vendorNo, browsedfile, StaffName);


                //if (up2Sharepoint == true)
                //{
                //    string filename = vendorNo + "_" + fileName0;
                //    string sUrl = ConfigurationManager.AppSettings["S_URL"];
                //    string defaultlibraryname = "Procurement%20Documents/";
                //    string customlibraryname = "Vendor Card";
                //    string sharepointLibrary = defaultlibraryname + customlibraryname;
                //    string sharepointlink = sUrl + sharepointLibrary + "/" + vendorNo + "/" + filename;



                //    //StaffCategory Number needed

                //    var status = nav.FnInsertBidPersonnelDetails(vendorNo, No, StaffName, Convert.ToInt32(StaffCategory), Convert.ToInt32(EmploymentType),EmailAddress, Profession, ProjectRoleCode, RequiredProfession, sharepointlink, filename);
                //    var res = status.Split('*');
                //    switch (res[0])
                //    {
                //        case "success":

                //            return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                //        default:
                //            return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                //    }
                //}
                //else
                //{
                //    return Json("sharepointError*", JsonRequestBehavior.AllowGet);
                //}
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult AddBidResponseGeneralDetails(BidResponseInsertDataTModel bidmodel, string JointVenture)
        {
            if (bidmodel.PaymentReference == null)
            {
                bidmodel.PaymentReference = "";
            }
            if (JointVenture == null)
            {
                JointVenture = "";
            }
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.fnInserBidGeneralDetails(vendorNo, bidmodel.BidRespNumber, bidmodel.BidderRepName, bidmodel.BidderRepDesignation, bidmodel.BidderRepAddress,
                    bidmodel.BidderWitnessName, bidmodel.BidderWitnessDesignation, bidmodel.BidderWitnessAddress, bidmodel.PaymentReference, bidmodel.BidderType, bidmodel.TenderDocumentsSource, JointVenture);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":

                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult AddRFQBidResponseGeneralDetails(BidResponseInsertDataTModel bidmodel)
        {

            try
            {
                //var vendorNo = Session["vendorNo"].ToString();
                //var nav = new NavConnection().ObjNav();
                //var status = nav.FnInserRFQBidGeneralDetails(vendorNo, bidmodel.BidRespNumber, bidmodel.BidderRepName, bidmodel.BidderRepDesignation, bidmodel.BidderRepAddress);
                //var res = status.Split('*');
                //switch (res[0])
                //{
                //    case "success":

                return Json("success*" + JsonRequestBehavior.AllowGet);

                //    default:
                //        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                //}
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        private static List<IFPRequestsModel> GetPrequalificationsDetails(string InvitationNumber)
        {
            List<IFPRequestsModel> list = new List<IFPRequestsModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetIFPRequest(InvitationNumber);
                String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);

                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        IFPRequestsModel invitation = new IFPRequestsModel();
                        invitation.Code = InvitationNumber;
                        invitation.Document_Date = Convert.ToString(arr[0]);
                        if (arr[1] != "")
                        {
                            invitation.Period_End_Date = DateTime.Parse(arr[1]).ToString("MM/dd/yyyy");

                        }
                        if (arr[2] != "")
                        {
                            invitation.Period_Start_Date = DateTime.Parse(arr[2]).ToString("MM/dd/yyyy");

                        }
                        if (arr[10] != "")
                        {
                            invitation.Submission_End_Date = DateTime.Parse(arr[10]).ToString("MM/dd/yyyy");

                        }
                        if (arr[11] != "")
                        {
                            invitation.Submission_Start_Date = DateTime.Parse(arr[11]).ToString("MM/dd/yyyy");

                        }
                        if (arr[16] != "")
                        {
                            invitation.Submission_End_Date = DateTime.Parse(arr[16]).ToString("MM/dd/yyyy");

                        }
                        invitation.Description = arr[3];
                        invitation.Tender_Box_Location_Code = arr[4];
                        invitation.Tender_Summary = Convert.ToString(arr[5]);
                        invitation.Status = Convert.ToString(arr[6]);
                        invitation.Primary_Target_Vendor_Cluster = Convert.ToString(arr[7]);
                        invitation.External_Document_No = Convert.ToString(arr[8]);
                        invitation.Document_Type = arr[9];
                        invitation.Submission_Start_Time = arr[12];
                        invitation.Vendor_Address = arr[13];
                        invitation.Vendor_Address2 = arr[14];
                        invitation.Region = arr[15];
                        list.Add(invitation);

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<IFPRequestsModel> EvaluationTemplate(string scoringTemplate)
        {
            List<IFPRequestsModel> list = new List<IFPRequestsModel>();
            try
            {
                var nav = new NavConnection().queries();
                //var query = nav.fnGetEvaluationCriteria(scoringTemplate);
                var query = nav.fnGetBidScoringTemplate(scoringTemplate);
                
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        IFPRequestsModel invitation = new IFPRequestsModel();
                        invitation.Code = scoringTemplate;
                        invitation.criteriaGroupId = arr[0];
                        invitation.templateDescription = arr[3];
                        invitation.evaluationType = arr[1];
                        invitation.totalweight = Convert.ToString(arr[14]);

                        list.Add(invitation);

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<BidResponseDetailsModel> GetBidResponseDetails(string BidResponseNumber, string vendorNo)
        {
            List<BidResponseDetailsModel> list = new List<BidResponseDetailsModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetBidResponseDetails(vendorNo, BidResponseNumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BidResponseDetailsModel biddetail = new BidResponseDetailsModel();
                        biddetail.No = BidResponseNumber;
                        biddetail.Bidder_Representative_Name = Convert.ToString(arr[3]);
                        biddetail.Invitation_For_Supply_No = arr[0];
                        biddetail.Plot_No = arr[18];
                        biddetail.Tender_Description = arr[3];
                        biddetail.Bankers_Name = arr[19];
                        biddetail.Bankers_Branch = arr[20];
                        biddetail.KNTC_Agent = Convert.ToString(arr[21]);
                        biddetail.Nominal_Capital_LCY = Convert.ToString(arr[22]);
                        biddetail.Business_Type = Convert.ToString(arr[23]);
                        biddetail.Issued_Capital_LCY = Convert.ToString(arr[24]);
                        biddetail.Status = arr[25];
                        biddetail.Bidder_Representative_Address = arr[26];
                        biddetail.Bidder_Representative_Desgn = Convert.ToString(arr[5]);
                        biddetail.Bidder_Witness_Name = arr[6];
                        biddetail.Tender_Document_Source = Convert.ToString(arr[16]);
                        biddetail.Document_Status = arr[27];
                        biddetail.Bid_Charge_Code = arr[11];
                        biddetail.Bid_Charge_LCY = Convert.ToString(arr[9]);
                        biddetail.Payment_Reference_No = Convert.ToString(arr[14]);
                        biddetail.Posted_Direct_Income_Voucher = Convert.ToString(arr[28]);
                        biddetail.Pay_to_Vendor_No = Convert.ToString(arr[29]);
                        biddetail.Pay_to_Name = arr[1];
                        biddetail.Currency_Code = arr[30];
                        biddetail.Amount = Convert.ToString(arr[31]);
                        biddetail.Location_Code = arr[32];
                        biddetail.Amount_Including_VAT = Convert.ToString(arr[33]);
                        biddetail.VAT_Registration_No = arr[7];
                        biddetail.Purchaser_Code = arr[34];
                        biddetail.Pay_to_Address = arr[35];
                        biddetail.Pay_to_City = arr[36];
                        biddetail.Pay_to_Post_Code = arr[37];
                        biddetail.Pay_to_Country_Region_Code = arr[38];
                        biddetail.Pay_to_Address_2 = arr[39];
                        biddetail.Language_Code = arr[40];
                        biddetail.Bidder_type = arr[13];
                        biddetail.Responsibility_Center = arr[2];
                        biddetail.Bidder_witness_Address = arr[10];
                        biddetail.Bidder_Witness_Name = arr[6];
                        biddetail.Bidder_witness_Designation = arr[8];
                        list.Add(biddetail);

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }

            return list;
        }
        private static List<SingleAddendumNoticeModel> GetAddendumDetails(string AddendumNumber)
        {
            List<SingleAddendumNoticeModel> list = new List<SingleAddendumNoticeModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetTenderAddedNotice1(AddendumNumber);
                String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        SingleAddendumNoticeModel tender = new SingleAddendumNoticeModel();
                        //if (arr[22] == "Published" && arr[10] == "Released")
                        //{
                            tender.Addendum_Notice_No = arr[0];
                            tender.Document_Date = Convert.ToString(arr[2]);
                            tender.Description = arr[6];
                            tender.Addendum_Instructions = arr[3];
                            tender.Primary_Addendum_Type_ID = arr[4];
                            tender.Addendum_Type_Description = arr[5];
                            tender.Tender_No = arr[18];
                            tender.Invitation_Notice_No = AddendumNumber;
                            tender.Tender_Description = arr[7];
                            tender.Responsibility_Center = arr[8];
                            if (arr[9] != "")
                            {
                                tender.New_Submission_Start_Date = DateTime.Parse(arr[9]).ToString("MM/dd/yyyy");

                            }
                            if (arr[23] != "")
                            {
                                tender.New_Submission_End_Date = DateTime.Parse(arr[23]).ToString("MM/dd/yyyy");

                            }
                            if (arr[21] != "")
                            {
                                tender.Original_Submission_End_Date = DateTime.Parse(arr[21]).ToString("MM/dd/yyyy");

                            }
                            if (arr[17] != "")
                            {
                                tender.Original_Bid_Opening_Date = DateTime.Parse(arr[17]).ToString("MM/dd/yyyy");

                            }
                            if (arr[13] != "")
                            {
                                tender.New_Bid_Opening_Date = DateTime.Parse(arr[13]).ToString("MM/dd/yyyy");

                            }
                            if (arr[15] != "")
                            {
                                tender.Original_Prebid_Meeting_Date = DateTime.Parse(arr[15]).ToString("MM/dd/yyyy");

                            }
                            tender.Status = arr[10];
                            tender.Original_Submission_End_Time = arr[25];
                            tender.Original_Bid_Opening_Time = arr[21];
                            tender.New_Bid_Opening_Time = arr[24];
                            tender.Document_Status = arr[22];
                            tender.New_Submission_End_Time = Convert.ToString(arr[19]);
                            tender.Original_Prebid_Meeting_Date = Convert.ToString(arr[15]);

                            list.Add(tender);
                        //}


                    }

                }

            }
            catch (Exception e)
            {

                throw;
            }

            return list;
        }
        private static List<AddendumAmmendmentModel> GetAddendumAmmendmentDetails(string AddendumNumber)
        {
            List<AddendumAmmendmentModel> list = new List<AddendumAmmendmentModel>();
            try
            {
                var nav = new NavConnection().queries();

                var query = nav.fnGetTenderAddednumDocument(AddendumNumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        AddendumAmmendmentModel tender = new AddendumAmmendmentModel();
                        tender.Addendum_Notice_No = AddendumNumber;
                        tender.Amended_Section_of_Tender_Doc = Convert.ToString(arr[1]);
                        tender.Amendment_Description = arr[0];
                        tender.Amendment_Type = arr[2];
                        list.Add(tender);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }

            return list;
        }
        private static List<VendorModel> GetVendors(string vendorNo)
        {

            List<VendorModel> vendorsDetails = new List<VendorModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetVendor(vendorNo);
                String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        VendorModel vendor = new VendorModel();
                        vendor.Vendor_No = vendorNo;
                        vendor.VAT_Registration_No = arr[38];
                        vendor.Name = arr[0];
                        vendor.LanguageCode = arr[1];
                        vendor.BusinessType = arr[2];
                        vendor.Vendor_Type = arr[3];
                        vendor.Owner_Type = arr[4];
                        vendor.OpsDate = Convert.ToString(arr[5]);
                        vendor.CertofIncorporation = arr[6];
                        vendor.Mision = arr[7];
                        vendor.Vision = arr[8];
                        vendor.DateofIncorporation = Convert.ToString(arr[9]);
                        vendor.PoBox = arr[10];
                        vendor.City = arr[11];
                        vendor.Country = arr[12];
                        vendor.WebUrl = arr[13];
                        vendor.PhysicalLocation = arr[14];
                        vendor.E_mail = arr[15];
                        vendor.Phone_No = arr[16];
                        vendor.Currency = arr[17];
                        vendor.Balance = Convert.ToString(arr[18]);
                        vendor.Address = Convert.ToString(arr[39]);
                        vendor.Physical_location = Convert.ToString(arr[19]);
                        vendor.IndustryGroup = arr[21];
                        vendor.Supplier_Type = arr[20];
                        vendor.PostaCode = arr[40];
                        vendor.PostaCity = arr[11];
                        vendor.Address_2 = arr[22];
                        vendor.HouseNo = arr[23];
                        vendor.FloorNo = arr[24];
                        vendor.PlotNo = arr[25];
                        vendor.StreetorRoad = arr[26];
                        vendor.CompanySize = arr[27];
                        vendor.NominalCap = Convert.ToDecimal(arr[28]);
                        vendor.Dealer_Type = Convert.ToString(arr[29]);
                        vendor.MaxBizValue = Convert.ToDecimal(arr[30]);
                        vendor.NatureofBz = arr[32];
                        vendor.Fax = arr[31];
                        vendor.RegistrationNo = arr[33];
                        vendor.Primary_Contact_No = arr[34];
                        vendor.Signatory_Designation = arr[35];
                        vendor.Balance = Convert.ToString(arr[36]);
                        vendor.CountryofOrigin = Convert.ToString(arr[41]);
                        vendor.Issued_Capital = Convert.ToString(arr[36]);
                        vendorsDetails.Add(vendor);

                        if (arr[4] == "Sole Ownership.Partnership")
                        {
                            vendor.Owner_Type = "0";
                        }
                        else if (arr[4] == "Registered Company")
                        {
                            vendor.Owner_Type = "1";
                        }
                        if (arr[20] == "Local")
                        {
                            vendor.Vendor_Type = "0";
                        }
                        else if (arr[20] == "Local")
                        {
                            vendor.Vendor_Type = "1";
                        }

                    }
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }

            return vendorsDetails;
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult SubmitPrequalificationsDetails(PreQualificationModel PrequalificationNumber)
        {
            try
            {
                string vendorNumber = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.FnSubmitPrequalificationResponse(vendorNumber, PrequalificationNumber.Ref_No);
                var res = status.Split('*');
                if (res[0] == "success")
                {
                    return Json("success*" + JsonRequestBehavior.AllowGet);
                }
                if (res[0] == "mandatory")
                {
                    return Json("mandatory*" + res[1], JsonRequestBehavior.AllowGet);
                }
                if (res[0] == "danger")
                {
                    return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
                return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex, JsonRequestBehavior.AllowGet);
            }

        }
        [HandleError]
        public JsonResult SubmitQuotationResponse(string tendernumber)
        {
            try
            {
                string vendorNumber = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.fnSubmitRFQResponse(vendorNumber, tendernumber);
                var res = status.Split('*');
                if (res[0] == "success")
                {
                    Session["RFQBideResponseNumber"] = nav.fngetBidResponseNumber(tendernumber, vendorNumber);
                    return Json("success*" + JsonRequestBehavior.AllowGet);
                }
                if (res[0] == "found")
                {
                    Session["RFQBideResponseNumber"] = nav.fngetBidResponseNumber(tendernumber, vendorNumber);
                    return Json("found*" + res[1], JsonRequestBehavior.AllowGet);
                }
                if (res[0] == "danger")
                {
                    return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
                if (res[0] == "profileincomplete")
                {
                    return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }

                return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpGet]
        public ActionResult RespondQuotationWizard()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (Session["RFQBideResponseNumber"] == null)
            {
                return RedirectToAction("ActiveRFQs", "Home");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                string BidResponseNumber = Session["RFQBideResponseNumber"].ToString();
                dynamic model = new ExpandoObject();
                ViewBag.prequalificationNo = BidResponseNumber;
                model.BidDetails = GetBidResponseDetails(BidResponseNumber, vendorNo);
                model.BidEquipments = GetBidResponseEquipments(BidResponseNumber);
                model.BidPersonnel = GetBidResponsePersonnel(BidResponseNumber);
                model.BidBalnaceSheet = GetBidResponseBalanceSheet(BidResponseNumber, vendorNo);
                model.BidIncomeStatement = GetBidResponseIncomeStatement(BidResponseNumber, vendorNo);
                model.BidPastExperiencent = GetBidResponsePastExperience(BidResponseNumber, vendorNo);
                model.BidPricinginformation = GetBidResponsePricingInformation(BidResponseNumber);
                model.RequiredDocuments = GetRequiredTenderDocuments(BidResponseNumber);
                model.BidSecurity = GetBidSecurityResponse(BidResponseNumber, vendorNo);
                model.AttachedBiddDocuments = GetBidAttachedDocumentsDetails(BidResponseNumber, vendorNo);

                return View(model);
            }
        }
        private static List<PrequalifiedCategoriesModel> GetPrequalificationCategories(string InvitationNumber)
        {

            List<PrequalifiedCategoriesModel> prequalificationDetails = new List<PrequalifiedCategoriesModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetRFIPrequalificationCategory(InvitationNumber);
                String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        PrequalifiedCategoriesModel preference = new PrequalifiedCategoriesModel();
                        preference.Document_No = InvitationNumber;
                        preference.Document_Type = arr[0];
                        preference.Procurement_Type = arr[1];
                        preference.Procurement_Category_Code = arr[2];
                        preference.Description = arr[3];
                        preference.Start_Date = Convert.ToString(arr[4]);
                        preference.End_Date = Convert.ToString(arr[5]);
                        preference.Submission_End_Date = Convert.ToString(arr[7]);
                        preference.Submission_End_Time = Convert.ToString(arr[8]);
                        preference.Submission_Start_Date = Convert.ToString(arr[6]);
                        preference.Submission_Start_Time = arr[9];
                        preference.Application_Location = Convert.ToString(arr[10]);
                        preference.Special_Group = Convert.ToString(arr[11]);
                        if (preference.Special_Group == "True")
                        {

                            preference.Special_Group = "Yes";
                        }
                        else
                        {
                            preference.Special_Group = "No";
                        }
                        prequalificationDetails.Add(preference);
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return prequalificationDetails;
        }
        private static List<PrequalifiedCategoriesModel> GetPrequalificationHistory(string vendorNo)
        {

            List<PrequalifiedCategoriesModel> prequalificationDetails = new List<PrequalifiedCategoriesModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetVendorPrequalificationEntry(vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        PrequalifiedCategoriesModel response = new PrequalifiedCategoriesModel();
                        response.Entry_No = Convert.ToString(arr[7]);
                        response.IFP_No = arr[0];
                        response.Vendor_No = vendorNo;
                        response.Procurement_Type = arr[1];
                        response.Procurement_Category_Code = arr[8];
                        response.Description = arr[2];
                        response.Start_Date = Convert.ToString(arr[3]);
                        response.Block = Convert.ToString(arr[9]);
                        response.Date_Block = Convert.ToString(arr[10]);
                        response.Document_Type = arr[5];
                        response.Document_No = arr[11];
                        response.Posting_Date = Convert.ToString(arr[6]);
                        prequalificationDetails.Add(response);

                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }

            return prequalificationDetails;
        }
        private static List<LitigationModel> GetVendorLitigationHistoryDetails(string vendorNo)
        {

            List<LitigationModel> litigationDetailsHistory = new List<LitigationModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetBidLitigationHistory(vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        LitigationModel litigation = new LitigationModel();
                        litigation.Entry_No = Convert.ToInt32(arr[0]);
                        litigation.DisputeDescription = arr[1];
                        litigation.CategoryofDispute = arr[2];
                        litigation.Year = arr[3];
                        litigation.TheotherDisputeparty = arr[4];
                        litigation.DisputeAmount = Convert.ToDecimal(arr[5]);
                        //litigation.Thirdparty = litigations.V3rd_Party_Entity;
                        litigation.AwardType = arr[6];
                        litigationDetailsHistory.Add(litigation);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }

            return litigationDetailsHistory;
        }
        private static List<BalanceSheetTModel> GetVendorBalanaceDetails(string vendorNo)
        {

            List<BalanceSheetTModel> balancesheetdetails = new List<BalanceSheetTModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetVendorBalanceSheet(vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BalanceSheetTModel balancesheet = new BalanceSheetTModel();
                        balancesheet.Audit_Year_Code_Reference = arr[0];
                        balancesheet.Current_Assets_LCY = Convert.ToDecimal(arr[1]);
                        balancesheet.Fixed_Assets_LCY = Convert.ToDecimal(arr[2]);
                        balancesheet.Total_Assets_LCY = Convert.ToDecimal(arr[3]);
                        balancesheet.Current_Liabilities_LCY = Convert.ToDecimal(arr[4]);
                        balancesheet.Long_term_Liabilities_LCY = Convert.ToDecimal(arr[5]);
                        balancesheet.Total_Liabilities_LCY = Convert.ToDecimal(arr[6]);
                        balancesheet.Owners_Equity_LCY = Convert.ToDecimal(arr[7]);
                        balancesheet.Debt_Ratio = Convert.ToDecimal(arr[8]);
                        balancesheet.Working_Capital_LCY = Convert.ToDecimal(arr[9]);
                        balancesheet.Assets_To_Equity_Ratio = Convert.ToDecimal(arr[10]);
                        balancesheet.Debt_To_Equity_Ratio = Convert.ToDecimal(arr[11]);
                        balancesheetdetails.Add(balancesheet);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }

            return balancesheetdetails;
        }
        private static List<ProfessionalStaffModel> GetVendorProfessionalStaff(string vendorNo)
        {

            List<ProfessionalStaffModel> staffDetails = new List<ProfessionalStaffModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetVendorProfessionalStaff(vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        ProfessionalStaffModel staff = new ProfessionalStaffModel();
                        staff.StaffNumber = arr[0];
                        staff.StaffName = arr[1];
                        staff.StaffDateofBirth = Convert.ToString(arr[2]);
                        staff.StaffEmail = arr[3];
                        staff.StaffDesignation = arr[4];
                        staff.Years_With_the_Firm = Convert.ToString(arr[5]);
                        staff.Post_Code = arr[6];
                        staff.Address_2 = arr[7];
                        staff.StaffPhonenumber = arr[8];
                        staff.City = arr[9];
                        staff.Citizenship_Type = arr[10];
                        staff.Staff_Category = arr[11];
                        staff.Country_Region_Code = arr[12];
                        staff.StaffProfession = arr[13];
                        staff.StaffJoiningDate = Convert.ToString(arr[14]);
                        staffDetails.Add(staff);

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }

            return staffDetails;
        }

        private static List<IncomeStatementTModel> GetVendorIncomeStatementDetails(string vendorNo)
        {

            List<IncomeStatementTModel> incomestatementdetails = new List<IncomeStatementTModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetVendorIncomeStatement(vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        IncomeStatementTModel income = new IncomeStatementTModel();
                        income.Audit_Year_Code_Reference = arr[0];
                        income.Total_Revenue_LCY = Convert.ToDecimal(arr[1]);
                        income.Total_COGS_LCY = Convert.ToDecimal(arr[2]);
                        income.Gross_Margin_LCY = Convert.ToDecimal(arr[3]);
                        income.Total_Operating_Expenses_LCY = Convert.ToDecimal(arr[4]);
                        income.Operating_Income_EBIT_LCY = Convert.ToDecimal(arr[5]);
                        income.Other_Non_operating_Re_Exp_LCY = Convert.ToDecimal(arr[6]);
                        income.Interest_Expense_LCY = Convert.ToDecimal(arr[7]);
                        income.Income_Before_Taxes_LCY = Convert.ToDecimal(arr[8]);
                        income.Income_Tax_Expense_LCY = Convert.ToDecimal(arr[9]);
                        income.Net_Income_from_Ops_LCY = Convert.ToDecimal(arr[10]);
                        income.Net_Income = Convert.ToDecimal(arr[11]);
                        incomestatementdetails.Add(income);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }

            return incomestatementdetails;
        }
        private static List<PastExperienceModel> GetVendorPastExeprience(string vendorNo)
        {

            List<PastExperienceModel> pastexperienceDetails = new List<PastExperienceModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetVendorPastExperience(vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        PastExperienceModel pastexperience = new PastExperienceModel();
                        pastexperience.Entry_No = Convert.ToInt32(arr[1]);
                        pastexperience.Vendor_No = vendorNo;
                        pastexperience.Client_Name = arr[0];
                        pastexperience.Address = arr[2];
                        pastexperience.City = arr[12];
                        pastexperience.Phone_No = arr[13];
                        pastexperience.Nationality_ID = arr[14];
                        pastexperience.Date_of_Birth = Convert.ToString(arr[15]);
                        pastexperience.Entity_Ownership = Convert.ToString(arr[16]);
                        pastexperience.Primary_Contact_Person = arr[11];
                        pastexperience.Assignment_Start_Date = Convert.ToString(arr[5]);
                        pastexperience.Assignment_End_Date = Convert.ToString(arr[6]);
                        pastexperience.Total_Nominal_Value = Convert.ToString(arr[17]);
                        pastexperience.Assignment_Value_LCY = Convert.ToString(arr[8]);
                        pastexperience.Assignment_Status = arr[18];
                        pastexperience.Assignment_Project_Name = arr[3];
                        pastexperience.Contract_Ref_No = arr[9];
                        pastexperience.Delivery_Location = arr[10];
                        pastexperience.Project_Scope_Summary = arr[4];
                        pastexperienceDetails.Add(pastexperience);

                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }

            return pastexperienceDetails;
        }

        private static List<DirectorModel> GetStakeholders(string vendorNo)
        {

            List<DirectorModel> DirectorDetails = new List<DirectorModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetShareholderDetails(vendorNo);

                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        DirectorModel shareholder = new DirectorModel();
                        shareholder.Entry_No = Convert.ToInt32(arr[0]);
                        shareholder.Fullname = arr[1];
                        shareholder.CitizenshipType = arr[11];
                        shareholder.OwnershipPercentage = Convert.ToDecimal(arr[6]);
                        shareholder.Phonenumber = arr[7];
                        shareholder.Address = arr[3];
                        shareholder.PostCode = arr[15];
                        shareholder.Email = arr[14];
                        shareholder.IdNumber = arr[9];
                        shareholder.Nationality = arr[8];
                        DirectorDetails.Add(shareholder);

                    }


                }


            }
            catch (Exception e)
            {

                throw;
            }

            return DirectorDetails;
        }
        private static List<BeneficiarryModel> GetBeneficiaries(string vendorNo)
        {

            List<BeneficiarryModel> BeneficiaryDetails = new List<BeneficiarryModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetVendorBeneficiaries(vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BeneficiarryModel beneficiary = new BeneficiarryModel();

                        beneficiary.Entry_No = Convert.ToInt32(arr[0]);
                        beneficiary.Name = arr[1];
                        beneficiary.idType = arr[2];
                        beneficiary.idpassportNumber = arr[3];
                        beneficiary.Phonenumber = Convert.ToInt32(arr[4]);
                        beneficiary.Email = arr[5];
                        beneficiary.AllocatedShares = Convert.ToDecimal(arr[6]);
                        beneficiary.BeneficiaryType = arr[7];
                        BeneficiaryDetails.Add(beneficiary);

                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }

            return BeneficiaryDetails;
        }

        private static List<BankModel> GetBanks(string vendorNo)
        {

            List<BankModel> BankDetails = new List<BankModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetVendorBankAccount(vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BankModel banks = new BankModel();
                        banks.BankCode = arr[0];
                        banks.BankName = arr[1];
                        banks.Post_Code = arr[2];
                        banks.Contact = arr[3];
                        banks.CurrencyCode = arr[4];
                        banks.BankAccountNo = arr[5];
                        banks.Bank_Branch_No = arr[6];
                        banks.bankBranchName = arr[8];
                        banks.CountryCode = arr[9];
                        banks.Phone_No = arr[10];
                        banks.City = arr[7];
                        BankDetails.Add(banks);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }

            return BankDetails;
        }

        public ActionResult ResetPassword()
        {

            return View();
        }
        public ActionResult ChangePassword()
        {

            return View();
        }
        public ActionResult Register()
        {

            var nav = new NavConnection().queries();
            var query = nav.fnGetProcurementSetup();
            String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
            if (info != null)
            {
                foreach (var allinfo in info)
                {
                    ViewBag.Terms = allinfo;
                }
            }

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult ResetSupplierPassword(ResetPasswordModel passwordmodel)
        {
            try
            {
                var nav = new NavConnection().ObjNav();
                var status = nav.FnResetPassword(passwordmodel.emailaddress);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);
                    case "emailnotfound":
                        return Json("emailnotfound*" + res[1], JsonRequestBehavior.AllowGet);
                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult ChangeSupplierPassword(ResetPasswordModel passwordmodel)
        {
            try
            {
                var nav = new NavConnection().ObjNav();
                var status = nav.FnChangePassword(passwordmodel.emailaddress, passwordmodel.oldpassword, passwordmodel.newpassword, passwordmodel.confirmpassword);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);
                    case "passwordmismatch":
                        return Json("passwordmismatch*" + res[1], JsonRequestBehavior.AllowGet);
                    case "worngcurrentpassword":
                        return Json("worngcurrentpassword*" + res[1], JsonRequestBehavior.AllowGet);
                    case "novendorfound":
                        return Json("worngcurrentpassword*" + res[1], JsonRequestBehavior.AllowGet);
                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult SupplierFirstRegistration(SignupModel signupmodel)
        {
            try
            {
                var nav = new NavConnection().ObjNav();
                var status = nav.FnReqforRegistration(signupmodel.VendorName, signupmodel.Phonenumber, signupmodel.Email, signupmodel.KraPin, signupmodel.ContactName);

                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult UserRegistration(string tbusinessname, string ttaxpinnumber, string tcontactperson, string tprimaryemail, string tmobilephone, string tterms)
        {

            try
            {
                var nav = new NavConnection().ObjNav();
                var status = nav.FnReqforRegistration(tbusinessname, tmobilephone, tprimaryemail, ttaxpinnumber, tcontactperson);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }


        }
        public ActionResult OpenRFQs()
        {

            return View();
        }
        public ActionResult PrequalifiedCategories()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<PrequalifiedCategoriesModel> list = new List<PrequalifiedCategoriesModel>();
                try
                {
                    var vendorNo = Session["vendorNo"].ToString();
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetVendorPrequalificationEntry(vendorNo);
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            PrequalifiedCategoriesModel response = new PrequalifiedCategoriesModel();
                            response.Entry_No = Convert.ToString(arr[7]);
                            response.IFP_No = arr[0];
                            response.Vendor_No = vendorNo;
                            response.Procurement_Type = arr[1];
                            response.Procurement_Category_Code = arr[8];
                            response.Description = arr[2];
                            response.Start_Date = Convert.ToString(arr[3]);
                            response.Block = Convert.ToString(arr[9]);
                            response.Date_Block = Convert.ToString(arr[10]);
                            response.Document_Type = arr[5];
                            response.Document_No = arr[11];
                            response.Posting_Date = Convert.ToString(arr[6]);
                            list.Add(response);

                        }
                    }

                }
                catch (Exception e)
                {

                    throw;
                }
                return View(list);
            }
        }
        public ActionResult RegistrationCategories()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                string Res = "";
                string[] accountsFieldsSeparators = new string[] { "*" };
                List<string> list = new List<string>();

                var list2 = new List<PrequalifiedCategoriesModel>();
                //List<PrequalifiedCategoriesModel> list = new List<PrequalifiedCategoriesModel>();
                try
                {
                    var vendorNo = Session["vendorNo"].ToString();
                    var nav = new NavConnection().ObjNav();
                    nav.FnGetRegisteredCategories(ref Res, vendorNo);

                    string[] ResultArray = Res.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);

                    list = ResultArray.ToList();
                    foreach (string item in list)
                    {
                        string[] categories = item.Split(accountsFieldsSeparators, System.StringSplitOptions.None);

                        list2.Add(new PrequalifiedCategoriesModel
                        {
                            Procurement_Type = categories[0],
                            Procurement_Category_Code = categories[1],
                            Description = categories[2],
                            Start_Date = categories[3],
                            End_Date = categories[4],

                        });

                    }

                    //var res = status.Split('*');
                    //var nav = NavConnection.ReturnNav();
                    //var query = nav.VendorPrequalificationEntries.Where(x => x.Vendor_No == vendorNo).ToList();
                    //foreach (var responses in query)
                    //{
                    //    PrequalifiedCategoriesModel response = new PrequalifiedCategoriesModel();
                    //    response.Entry_No = Convert.ToString(responses.Entry_No);
                    //    response.IFP_No = responses.IFP_No;
                    //    response.Vendor_No = responses.Vendor_No;
                    //    response.Procurement_Type = responses.Procurement_Type;
                    //    response.Procurement_Type = responses.Procurement_Category_Code;
                    //    response.Description = responses.Description;
                    //    response.Start_Date = Convert.ToString(responses.Start_Date);
                    //    response.Start_Date = Convert.ToString(responses.End_Date);
                    //    response.Block = Convert.ToString(responses.Blocked);
                    //    response.Date_Block = Convert.ToString(responses.Date_Blocked);
                    //    response.Document_Type = responses.Document_Type;
                    //    response.Document_No = responses.Document_No;
                    //    list.Add(response);
                    //}

                }
                catch (Exception e)
                {

                    throw;
                }
                return View(list2);
            }
        }
        [HttpGet]
        public ActionResult RFIResponseForm(string InvitationNumber, string PrequalificationNo)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                try
                {
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetVendor(Convert.ToString(Session["vendorNo"]));
                    String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            string test = arr[37];
                            if (arr[37] == "Yes")
                            {

                                var vendorNo = Session["vendorNo"].ToString();
                                dynamic model = new ExpandoObject();
                                model.Vendors = GetVendors(vendorNo);
                                model.Response = ResponseDetails(InvitationNumber, vendorNo);
                                model.GoodsServices = GoodsServicesDetails(InvitationNumber, vendorNo);
                                model.Services = ServicesDetails(InvitationNumber, vendorNo);
                                model.StakeholdersDetails = GetStakeholders(vendorNo);
                                model.Beneficiaries = GetBeneficiaries(vendorNo);
                                model.balancesheet = GetVendorBalanaceDetails(vendorNo);
                                model.VendorProfessionalStaff = GetVendorProfessionalStaff(vendorNo);
                                model.incomestatement = GetVendorIncomeStatementDetails(vendorNo);
                                model.PastExperience = GetVendorPastExeprience(vendorNo);
                                model.litigationhistory = GetVendorLitigationHistoryDetails(vendorNo);
                                model.Works = WorksDetails(InvitationNumber, vendorNo);
                                // model.RequiredDocuments = RequiredDocumentsDetails(InvitationNumber, vendorNo);
                                 model.PrequalificationUploadedDocuments = PrequalificationUploaded(InvitationNumber, vendorNo);
                                return View(model);
                            }

                            else if (arr[37] == "No")
                            {
                                TestModel model = new TestModel();
                                model.ShowDialog = true;
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }

                return RedirectToAction("SupplierRegistration", "Home");
            }
        }

        public ActionResult RegistrationFormResponce(string InvitationNumber, string PrequalificationNo)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                try
                {
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetVendor(Convert.ToString(Session["vendorNo"]));
                    String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            if (arr[37] == "Yes")
                            {


                                var vendorNo = Session["vendorNo"].ToString();
                                dynamic model = new ExpandoObject();
                                model.Vendors = GetVendors(vendorNo);
                                model.Response = RegistrationResponseDetails(InvitationNumber, vendorNo);
                                model.GoodsServices = GoodsServicesDetails(InvitationNumber, vendorNo);
                                model.Services = ServicesDetails(InvitationNumber, vendorNo);
                                model.StakeholdersDetails = GetStakeholders(vendorNo);
                                model.Beneficiaries = GetBeneficiaries(vendorNo);
                                model.balancesheet = GetVendorBalanaceDetails(vendorNo);
                                model.VendorProfessionalStaff = GetVendorProfessionalStaff(vendorNo);
                                model.incomestatement = GetVendorIncomeStatementDetails(vendorNo);
                                model.PastExperience = GetVendorPastExeprience(vendorNo);
                                model.litigationhistory = GetVendorLitigationHistoryDetails(vendorNo);
                                model.Works = WorksDetails(InvitationNumber, vendorNo);
                                //model.RequiredDocuments = RequiredDocumentsDetails(InvitationNumber, vendorNo);
                                //model.PrequalificationUploadedDocuments = PrequalificationUploaded(PrequalificationNo, vendorNo);

                                return View(model);
                            }

                            else if (arr[37] == "No")
                            {
                                TestModel model = new TestModel();
                                model.ShowDialog = true;
                            }

                        }
                    }


                }
                catch
                {

                }

                return RedirectToAction("SupplierRegistration", "Home");
            }
        }


        private static List<IFPRequestsModel> ResponseDetails(string tenderresponseNumber, string vendorNo)
        {
            List<IFPRequestsModel> list = new List<IFPRequestsModel>();
            try
            {

                var navCodeunit = new NavConnection().ObjNav();
                var status = navCodeunit.fnInsertRFIresponseHeader(vendorNo, tenderresponseNumber);
                var res = status.Split('*');
                if (res[0] == "success")
                {
                    //Populate Records
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetInvitationPrequalification("Invitation For Prequalification");

                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            IFPRequestsModel response = new IFPRequestsModel();
                            if (arr[0] == tenderresponseNumber)
                            {
                                response.Code = arr[0];
                                response.PrequalificationNo = res[1];
                                response.Document_Type = "Invitation For Prequalification";
                                response.Vendor_Address = arr[7];
                                response.Primary_Target_Vendor_Cluster = arr[8];
                                response.Vendor_Address2 = arr[9];
                                response.Document_Date = Convert.ToString(arr[10]);
                                response.Period_Start_Date = Convert.ToString(arr[12]);
                                response.Period_End_Date = Convert.ToString(arr[11]);
                                response.Tender_Box_Location_Code = arr[2];
                                response.Tender_Summary = arr[4];
                                response.Region = arr[13];
                                response.constituency = arr[14];
                                response.RFI_Documents_No = arr[0];
                                list.Add(response);
                            }


                        }
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return list;
        }

        private static void errorMessage(string v)
        {
            Console.WriteLine(v);
        }


        private static List<IFPRequestsModel> RegistrationResponseDetails(string vendorNo, string tenderresponseNumber)
        {
            List<IFPRequestsModel> list = new List<IFPRequestsModel>();
            try
            {
                // Create Ne Prequalification Number
                //var vendorNo = Session["vendorNo"].ToString();
                var navCodeunit = new NavConnection().ObjNav();
                var status = navCodeunit.FnInsertRFregresponseHeader(tenderresponseNumber, vendorNo);
                var res = status.Split('*');
                //Populate Records
                var nav = new NavConnection().queries();
                // var query = nav.InvitationPrequalification.Where(x => x.Code == vendorNo && x.Document_Type=="Invitation for Registation" && x.Status == "Released" && x.Published == true).ToList();
                var query = nav.fnGetInvitationPrequalification("Invitation for Registation");
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[0] == vendorNo)
                        {
                            IFPRequestsModel response = new IFPRequestsModel();
                            response.Code = arr[0];
                            response.PrequalificationNo = res[1];
                            response.Document_Type = "Invitation for Registation";
                            response.Vendor_Address = arr[7];
                            response.Primary_Target_Vendor_Cluster = arr[8];
                            response.Vendor_Address2 = arr[9];
                            response.Document_Date = Convert.ToString(arr[10]);
                            response.Period_Start_Date = Convert.ToString(arr[12]);
                            response.Period_End_Date = Convert.ToString(arr[11]);
                            response.Tender_Box_Location_Code = arr[2];
                            response.Tender_Summary = arr[4];
                            response.Region = arr[13];
                            response.constituency = arr[14];
                            response.RFI_Documents_No = arr[0];
                            list.Add(response);

                        }

                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return list;
        }
        private static List<GoodsServicesModel> GoodsServicesDetails(string tenderresponseNumber, string vendorNo)
        {
            List<GoodsServicesModel> list = new List<GoodsServicesModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetRFIPreqList(tenderresponseNumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[9] == "GOODS")
                        {
                            GoodsServicesModel response = new GoodsServicesModel();
                            response.Document_No = tenderresponseNumber;
                            response.Prequalification_Category_ID = arr[0];
                            response.Description = arr[2];
                            response.Period_Start_Date = Convert.ToString(arr[1]);
                            response.Submission_Start_Date = Convert.ToString(arr[4]);
                            response.Submission_End_Date = Convert.ToString(arr[5]);
                            response.Applicable_Location = arr[6];
                            response.Restricted_RC_Type = arr[7];
                            response.SpecialGroupReservations = Convert.ToString(arr[8]);
                            if (response.SpecialGroupReservations == "True")
                            {

                                response.SpecialGroupReservations = "Yes";
                            }
                            else
                            {
                                response.SpecialGroupReservations = "No";
                            }
                            response.Procurement_Type = "GOODS";
                            list.Add(response);
                        }


                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }

        private static List<ServicesModel> ServicesDetails(string tenderresponseNumber, string vendorNo)
        {
            List<ServicesModel> list = new List<ServicesModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetRFIPreqList(tenderresponseNumber);

                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[9] == "SERVICES")
                        {
                            ServicesModel response = new ServicesModel();
                            response.Document_No = tenderresponseNumber;
                            response.Prequalification_Category_ID = arr[0];
                            response.Description = arr[2];
                            response.Period_Start_Date = Convert.ToString(arr[1]);
                            response.Submission_Start_Date = Convert.ToString(arr[4]);
                            response.Submission_End_Date = Convert.ToString(arr[5]);
                            response.Applicable_Location = arr[6];
                            response.Restricted_RC_Type = arr[7];
                            response.SpecialGroupReservations = Convert.ToString(arr[8]);
                            if (response.SpecialGroupReservations == "True")
                            {

                                response.SpecialGroupReservations = "Yes";
                            }
                            else
                            {
                                response.SpecialGroupReservations = "No";
                            }
                            response.Procurement_Type = "SERVICES";
                            list.Add(response);
                        }

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<WorksModel> WorksDetails(string tenderresponseNumber, string vendorNo)
        {
            List<WorksModel> list = new List<WorksModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetRFIPreqList(tenderresponseNumber);

                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[9] == "WORKS")
                        {
                            WorksModel response = new WorksModel();
                            response.Document_No = tenderresponseNumber;
                            response.Prequalification_Category_ID = arr[0];
                            response.Description = arr[2];
                            response.Period_Start_Date = Convert.ToString(arr[1]);
                            response.Submission_Start_Date = Convert.ToString(arr[4]);
                            response.Submission_End_Date = Convert.ToString(arr[5]);
                            response.Applicable_Location = arr[6];
                            response.Restricted_RC_Type = arr[7];
                            response.SpecialGroupReservations = Convert.ToString(arr[8]);
                            if (response.SpecialGroupReservations == "True")
                            {

                                response.SpecialGroupReservations = "Yes";
                            }
                            else
                            {
                                response.SpecialGroupReservations = "No";
                            }
                            response.Procurement_Type = "WORKS";
                            list.Add(response);

                        }

                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<DocumentsTModel> RequiredDocumentsDetails(string tenderresponseNumber, string vendorNo)
        {
            List<DocumentsTModel> list = new List<DocumentsTModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetIfpReqDocuments(tenderresponseNumber, "Invitation for Prequalification");

                String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[4] == "Yes")
                        {
                            DocumentsTModel response = new DocumentsTModel();
                            response.Document_No = tenderresponseNumber;
                            response.Procurement_Document_Type_ID = arr[1];
                            response.Requirement_Type = arr[2];
                            response.Description = arr[0];
                            response.Tracks_Certificate_Expiry = Convert.ToString(arr[6]);
                            if (response.Tracks_Certificate_Expiry == "True")
                            {

                                response.Tracks_Certificate_Expiry = "Yes";
                            }
                            else
                            {
                                response.Tracks_Certificate_Expiry = "No";
                            }
                            response.SpecialGroupRequirement = Convert.ToString(arr[3]);
                            if (response.SpecialGroupRequirement == "True")
                            {

                                response.SpecialGroupRequirement = "Yes";
                            }
                            else
                            {
                                response.SpecialGroupRequirement = "No";
                            }
                            response.SpecialisedRequirement = Convert.ToString(arr[4]);
                            list.Add(response);
                        }


                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<DocumentsTModel> SpecificRequiredDocuments(string tenderresponseNumber, string vendorNo)
        {
            List<DocumentsTModel> list = new List<DocumentsTModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetIfpReqDocuments(tenderresponseNumber, "Invitation for Prequalification");

                String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[4] == "No")
                        {
                            DocumentsTModel response = new DocumentsTModel();
                            response.Document_No = tenderresponseNumber;
                            response.Procurement_Document_Type_ID = arr[1];
                            response.Requirement_Type = arr[2];
                            response.Description = arr[0];
                            response.Tracks_Certificate_Expiry = Convert.ToString(arr[6]);
                            if (response.Tracks_Certificate_Expiry == "True")
                            {

                                response.Tracks_Certificate_Expiry = "Yes";
                            }
                            else
                            {
                                response.Tracks_Certificate_Expiry = "No";
                            }
                            response.SpecialGroupRequirement = Convert.ToString(arr[3]);
                            if (response.SpecialGroupRequirement == "True")
                            {

                                response.SpecialGroupRequirement = "Yes";
                            }
                            else
                            {
                                response.SpecialGroupRequirement = "No";
                            }
                            response.SpecialisedRequirement = Convert.ToString(arr[4]);
                            list.Add(response);
                        }


                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }

        private static List<DocumentsTModel> RegistrationRequiredDocumentsDetails(string tenderresponseNumber, string vendorNo)
        {
            List<DocumentsTModel> list = new List<DocumentsTModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetIfpReqDocuments(tenderresponseNumber, "Invitation for Prequalification");

                String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[4] == "No")
                        {
                            DocumentsTModel response = new DocumentsTModel();
                            response.Document_No = tenderresponseNumber;
                            response.Procurement_Document_Type_ID = arr[1];
                            response.Requirement_Type = arr[2];
                            response.Description = arr[0];
                            response.Tracks_Certificate_Expiry = Convert.ToString(arr[6]);
                            if (response.Tracks_Certificate_Expiry == "True")
                            {

                                response.Tracks_Certificate_Expiry = "Yes";
                            }
                            else
                            {
                                response.Tracks_Certificate_Expiry = "No";
                            }
                            response.SpecialGroupRequirement = Convert.ToString(arr[3]);
                            if (response.SpecialGroupRequirement == "True")
                            {

                                response.SpecialGroupRequirement = "Yes";
                            }
                            else
                            {
                                response.SpecialGroupRequirement = "No";
                            }
                            response.SpecialisedRequirement = Convert.ToString(arr[4]);
                            list.Add(response);
                        }


                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<DocumentsTModel> RegistrationSpecificRequiredDocuments(string tenderresponseNumber, string vendorNo)
        {
            List<DocumentsTModel> list = new List<DocumentsTModel>();
            try
            {
                var nav = new NavConnection().queries();

                var query = nav.fnGetIfpReqDocuments(tenderresponseNumber, "Invitation for Prequalification");

                String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[4] == "No")
                        {
                            DocumentsTModel response = new DocumentsTModel();
                            response.Document_No = tenderresponseNumber;
                            response.Procurement_Document_Type_ID = arr[1];
                            response.Requirement_Type = arr[2];
                            response.Description = arr[0];
                            response.category = arr[7];
                            response.Tracks_Certificate_Expiry = Convert.ToString(arr[6]);
                            if (response.Tracks_Certificate_Expiry == "True")
                            {

                                response.Tracks_Certificate_Expiry = "Yes";
                            }
                            else
                            {
                                response.Tracks_Certificate_Expiry = "No";
                            }
                            response.SpecialGroupRequirement = Convert.ToString(arr[3]);
                            if (response.SpecialGroupRequirement == "True")
                            {

                                response.SpecialGroupRequirement = "Yes";
                            }
                            else
                            {
                                response.SpecialGroupRequirement = "No";
                            }
                            response.SpecialisedRequirement = Convert.ToString(arr[4]);
                            list.Add(response);
                        }


                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        public ActionResult CompanySize()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<BusinessSizeModel> CompanySize = new List<BusinessSizeModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetCompanySizeCodes();
                    String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        foreach (var allinfo in info)
                        {
                            String[] arr = allinfo.Split('*');
                            BusinessSizeModel bizsizes = new BusinessSizeModel();
                            bizsizes.Code = arr[0];
                            bizsizes.Description = arr[1];
                            CompanySize.Add(bizsizes);
                        }
                    }

                }
                catch (Exception e)
                {

                    throw;
                }
                return View(CompanySize);
            }
        }
        public ActionResult DocumentTemplateDroplist()
        {
            List<DocumentsTModel> AllDocuments = new List<DocumentsTModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetIfpReqDocuments("", "Invitation for Prequalification");

                String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[4] == "Yes")
                        {
                            DocumentsTModel response = new DocumentsTModel();

                            response.Procurement_Document_Type_ID = arr[1];
                            response.Description = arr[0];
                            AllDocuments.Add(response);
                        }


                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(AllDocuments);
        }
        public ActionResult TenderDocumentTemplateDroplist()
        {
            List<DocumentsTModel> AllDocuments = new List<DocumentsTModel>();
            try
            {
                var nav = new NavConnection().queries();
                var TenderNumber = Request.QueryString["respondtendernumber"];
                var query = nav.fnGetIfpReqDocuments(TenderNumber, "");

                String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[4] == "Yes")
                        {
                            DocumentsTModel response = new DocumentsTModel();

                            response.Procurement_Document_Type_ID = arr[1];
                            response.Description = arr[0];
                            AllDocuments.Add(response);
                        }


                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return View(AllDocuments);
        }
        public ActionResult PrequalificationDropDownListDocs()
        {
            List<DocumentsTModel> list = new List<DocumentsTModel>();
            try
            {
                string InvitationNumber = Request.QueryString["InvitationNumber"];
                var nav = new NavConnection().queries();
                var query = nav.fnGetIfpReqDocuments(InvitationNumber, "Invitation for Prequalification");

                String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[4] == "Yes")
                        {
                            DocumentsTModel response = new DocumentsTModel();

                            response.Procurement_Document_Type_ID = arr[1];
                            response.Description = arr[0];
                            response.Requirement_Type = Convert.ToString(arr[2]);
                            response.Document_Type = "Invitation for Prequalification";

                            list.Add(response);
                        }


                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(list);
        }
        public ActionResult RegisterDocumentTemplateDroplist()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<RegistrationRequiredDocumentsModel> AllDocuments = new List<RegistrationRequiredDocumentsModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetEprocurementDocuments("Registration");
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            RegistrationRequiredDocumentsModel filedocuments = new RegistrationRequiredDocumentsModel();
                            filedocuments.Template_ID = arr[1];
                            filedocuments.Description = arr[0];
                            filedocuments.Procurement_Document_Type = arr[2];
                            filedocuments.Requirement_Type = arr[3];
                            AllDocuments.Add(filedocuments);

                        }
                    }

                }
                catch (Exception e)
                {

                    throw;
                }
                return View(AllDocuments);
            }
        }
        public ActionResult PostalCodeList()
        {
            List<DropdownListsModel> postacode = new List<DropdownListsModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetPostCodes();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        DropdownListsModel postcodes = new DropdownListsModel();
                        postcodes.Code = arr[0];
                        postcodes.City = arr[1];
                        postcodes.CountryName = arr[2];
                        postacode.Add(postcodes);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(postacode);
        }
        public ActionResult BankCodesList()
        {
            List<DropdownListsModel> postacode = new List<DropdownListsModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetPostCodes();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        DropdownListsModel postcodes = new DropdownListsModel();
                        postcodes.Code = arr[0];
                        postcodes.City = arr[1];
                        postcodes.CountryName = arr[2];
                        postacode.Add(postcodes);
                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return View(postacode);
        }

        public ActionResult selectRegion()
        {
            List<ResponsibilityCenter> postacode = new List<ResponsibilityCenter>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetResponsibilityCenters("Region");
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        ResponsibilityCenter postcodes = new ResponsibilityCenter();
                        postcodes.code = arr[0];
                        postcodes.name = arr[1];
                        postacode.Add(postcodes);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(postacode);
        }
        public ActionResult PrequalificationConstituencies()
        {
            List<ResponsibilityCenter> postacode = new List<ResponsibilityCenter>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetResponsibilityCenters("Constituency");
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        ResponsibilityCenter postcodes = new ResponsibilityCenter();
                        postcodes.code = arr[0];
                        postcodes.name = arr[1];
                        postacode.Add(postcodes);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(postacode);
        }
        public JsonResult SelectedPosta(string postcode)
        {
            List<DropdownListsModel> postacode = new List<DropdownListsModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetPostCodes();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        DropdownListsModel postcodes = new DropdownListsModel();
                        postcodes.Code = arr[0];
                        postcodes.City = arr[1];
                        postcodes.CountryName = arr[2];
                        postacode.Add(postcodes);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            var result = (from a in postacode where a.Code == postcode select a.City).FirstOrDefault();

            if (result != null)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json("notfound", JsonRequestBehavior.AllowGet);
        }

        public JsonResult SelectedBidSecurity(string postcode)
        {
            List<Models.TenderSecurityTypes> list = new List<Models.TenderSecurityTypes>();

            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetTenderSecurityTypes("");
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        TenderSecurityTypes securitytype = new TenderSecurityTypes();
                        securitytype.Code = arr[0];
                        securitytype.Security_Type = arr[2];
                        securitytype.Description = arr[1];
                        securitytype.Nature_of_Security = arr[3];
                        list.Add(securitytype);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            var result = (from a in list where a.Code == postcode select a.Description).FirstOrDefault();

            if (result != null)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json("notfound", JsonRequestBehavior.AllowGet);
        }

        public JsonResult SelectedBank(string bankcode)
        {
            var details = new Object();
            List<BankModel> bank = new List<BankModel>();
            try
            {

                var nav = new NavConnection().queries();
                var query = nav.fnGetBankBranches(bankcode);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BankModel bankcodes = new BankModel();
                        bankcodes.BankCode = bankcode;
                        bankcodes.BankName = arr[0];
                        bankcodes.bankBranchName = arr[1];
                        bankcodes.Bank_Branch_No = arr[2];
                        bank.Add(bankcodes);

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            var result = (from a in bank where a.BankCode == bankcode select new SelectListItem { Text = a.bankBranchName, Value = a.Bank_Branch_No }).Distinct().ToList().FirstOrDefault();
            //var branchname = (from a in bank where a.Bank_Branch_No == bankcode select a.bankBranchName).FirstOrDefault();

            if (bank != null)
            {
                return Json(bank, JsonRequestBehavior.AllowGet);

            }
            return Json("notfound", JsonRequestBehavior.AllowGet);
        }

        public JsonResult selectedResponsibilityCenter(string regionCode)
        {
            List<ResponsibilityCenter> RC = new List<ResponsibilityCenter>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetResponsibilityCenters("Constituency");
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        ResponsibilityCenter postcodes = new ResponsibilityCenter();
                        postcodes.code = arr[0];
                        postcodes.name = arr[1];
                        RC.Add(postcodes);
                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }
            var result = (from a in RC where a.locationCode == regionCode select a.constituencyCode).FirstOrDefault();


            if (result != null)
            {
                return Json(result, JsonRequestBehavior.AllowGet);

            }
            return Json("notfound", JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSelectedDocumentExpiryDate(string SelectedDocument)
        {
            List<DocumentsTModel> expiryDate = new List<DocumentsTModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetEprocurementDocuments("Registration");
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[0] == SelectedDocument)
                        {
                            if (Convert.ToBoolean(arr[5]) == true)
                            {
                                return Json("success*", JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                return Json("danger*", JsonRequestBehavior.AllowGet);
                            }
                        }

                    }

                }
                return Json("danger*", JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {

                throw ex;
            }

        }
        public JsonResult GetSelectedPrequalificationDocumentExpiryDate(string SelectedDocument)
        {
            List<DocumentsTModel> expiryDate = new List<DocumentsTModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetIfpReqDocuments("", "Invitation For Prequalification");
                String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[0] == SelectedDocument)
                        {
                            if (arr[6] == "Yes")
                            {
                                return Json("success*", JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                return Json("danger*", JsonRequestBehavior.AllowGet);
                            }
                        }
                    }

                }
                return Json("danger*", JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public JsonResult GetSelectedTenderDocumentDocumentExpiryDate(string SelectedDocument)
        {
            List<DocumentsTModel> expiryDate = new List<DocumentsTModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetIfpReqDocuments(SelectedDocument, "");
                String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[6] == "Yes")
                        {
                            return Json("success*", JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json("danger*", JsonRequestBehavior.AllowGet);
                        }
                    }

                }
                return Json("danger*", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ActionResult RFIResponse()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<IFPRequestsModel> list = new List<IFPRequestsModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var today = DateTime.Today;
                    var query = nav.fnGetInvitationForPrequalification();
                    String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            //if (arr[0] != "" && arr[10] == "Released" && arr[12] == "Invitation For Prequalification" && arr[15] == "Sub IFP" && DateTime.Parse(arr[0]) >= today)
                            //{
                                IFPRequestsModel tender = new IFPRequestsModel();
                                tender.Code = arr[1];
                                tender.Status = arr[11];
                                tender.Tender_Summary = arr[3];
                                tender.External_Document_No = arr[4];
                                tender.Procurement_Type = arr[5];
                                tender.Description = arr[2];
                                tender.Submission_Start_Date = Convert.ToString(arr[7]);
                                if (arr[0] != "")
                                {
                                    tender.Submission_End_Date = DateTime.Parse(arr[0]).ToString("dd/MM/yyyy");

                                }
                                tender.Submission_Start_Time = arr[8];
                                tender.Document_Date = Convert.ToString(arr[9]);
                                tender.Status = arr[10];
                                tender.Name = arr[6];
                                tender.Tender_Box_Location_Code = arr[13];
                                tender.bidscoringTemplate = arr[14];
                                tender.Published = true;
                                list.Add(tender);
                            //}
                        }
                    }

                }
                catch (Exception e)
                {

                    throw;
                }
                return View(list);

            }
        }
        public ActionResult RegistrationForm()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<IFPRequestsModel> list = new List<IFPRequestsModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var today = DateTime.Today;

                    var query = nav.fnGetInvitationForPrequalification();
                    String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            if (arr[0] != "" && arr[10] == "Released" && arr[12] == "Invitation for Registation" && arr[15] == "Sub IFP" && DateTime.Parse(arr[0]) >= today)
                            {
                                IFPRequestsModel tender = new IFPRequestsModel();
                                tender.Code = arr[1];
                                tender.Tender_Summary = arr[3];
                                tender.External_Document_No = arr[4];
                                tender.Tender_Box_Location_Code = arr[13];
                                tender.Description = arr[2];
                                tender.Submission_Start_Date = Convert.ToString(arr[7]);
                                tender.Submission_Start_Time = arr[8];
                                tender.Procurement_Type = arr[5];
                                tender.bidscoringTemplate = arr[14];
                                tender.Document_Date = Convert.ToString(arr[9]);
                                tender.Status = arr[10];
                                tender.Name = arr[6];

                                tender.Published = true;
                                list.Add(tender);
                            }
                        }
                    }



                }
                catch (Exception e)
                {

                    throw;
                }
                return View(list);

            }
        }
        public ActionResult SubmittedResponses()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<SubmittedResponsesModel> list = new List<SubmittedResponsesModel>();
                try
                {
                    var vendorNo = Session["vendorNo"].ToString();
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetRFIResponse(vendorNo, "");
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            if (arr[17] == "IFP Response")
                            {
                                SubmittedResponsesModel response = new SubmittedResponsesModel();
                                response.Code = arr[18];
                                response.Documents_Date = Convert.ToString(arr[16]);
                                response.RfiDocumentNo = arr[14];
                                response.Vendor_Representative_Name = arr[12];
                                response.Vendor_Repr_Designation = arr[13];
                                response.Final_Evaluation_Score = arr[3];
                                response.Date_Submitted = Convert.ToString(arr[2]); ;
                                list.Add(response);
                            }


                        }
                    }


                }
                catch (Exception e)
                {

                    throw;
                }
                return View(list);

            }
        }
        public ActionResult SubmittedTenders()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<SubmittedTenderResponse> list = new List<SubmittedTenderResponse>();
                try
                {
                    var vendorNo = Session["vendorNo"].ToString();
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetBidResponseList(vendorNo, "Open Tender");
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            SubmittedTenderResponse response = new SubmittedTenderResponse();
                            response.ResponseNo = arr[0];
                            response.vendorNo = vendorNo;
                            response.VendorName = arr[2];
                            response.status = arr[6];
                            response.DocumentStatus = arr[1];
                            response.invitationNoticeType = arr[3];
                            response.InvitationNo = arr[5];
                            response.tenderDescription = arr[7];
                            if (arr[4] != "")
                            {
                                response.endDate = DateTime.Parse(arr[4]).ToString("MM/dd/yyyy");

                            }
                            list.Add(response);

                        }
                    }
                }
                catch (Exception e)
                {

                    throw;
                }
                return View(list);

            }
        }
        public ActionResult submittedRFQ()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<SubmittedTenderResponse> list = new List<SubmittedTenderResponse>();
                try
                {
                    var vendorNo = Session["vendorNo"].ToString();
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetBidResponseList(vendorNo, "RFQ");
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            SubmittedTenderResponse response = new SubmittedTenderResponse();
                            response.ResponseNo = arr[0];
                            response.vendorNo = vendorNo;
                            response.VendorName = arr[2];
                            response.status = arr[6];
                            response.DocumentStatus = arr[1];
                            response.invitationNoticeType = arr[3];
                            response.InvitationNo = arr[5];
                            response.tenderDescription = arr[7];
                            if (arr[4] != "")
                            {
                                response.endDate = DateTime.Parse(arr[4]).ToString("MM/dd/yyyy");

                            }
                            list.Add(response);

                        }
                    }


                }
                catch (Exception e)
                {

                    throw;
                }
                return View(list);

            }
        }
        public ActionResult SubmittedRegistrationResponses()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<SubmittedResponsesModel> list = new List<SubmittedResponsesModel>();
                try
                {
                    var vendorNo = Session["vendorNo"].ToString();
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetRFIResponse(vendorNo, "");
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            if (arr[17] == "IFR Response")
                            {
                                SubmittedResponsesModel response = new SubmittedResponsesModel();
                                response.Code = arr[18];
                                response.Documents_Date = Convert.ToString(arr[16]);
                                response.RfiDocumentNo = arr[14];
                                response.Vendor_Representative_Name = arr[12];
                                response.Vendor_Repr_Designation = arr[13];
                                response.Final_Evaluation_Score = arr[3];
                                response.Date_Submitted = Convert.ToString(arr[2]); ;
                                list.Add(response);
                            }


                        }
                    }


                }
                catch (Exception e)
                {

                    throw;
                }
                return View(list);

            }
        }
        public ActionResult TendersLists()
        {
            List<TenderModel> list = new List<TenderModel>();
            try
            {
                DateTime today = DateTime.Today;
                var nav = new NavConnection().queries();
                var query = nav.fnGetInviteTender("");
                String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');

                        if (arr[12] != "" && arr[14] == "Open Tender" && DateTime.Parse(arr[12]) >= today)
                        {
                            TenderModel tender = new TenderModel();
                            tender.Code = arr[0];
                            tender.Procurement_Method = arr[14];
                            tender.Solicitation_Type = arr[1];
                            tender.External_Document_No = arr[2];
                            tender.Procurement_Type = arr[3];
                            tender.Procurement_Category_ID = arr[4];
                            tender.Project_ID = arr[5];
                            tender.Tender_Name = arr[6];
                            tender.Tender_Summary = arr[7];
                            tender.Description = arr[8];
                            if (arr[9] != "")
                            {
                                tender.Document_Date = DateTime.Parse(arr[9]);

                            }
                            if (arr[13] != "")
                            {
                                tender.Submission_Start_Date = DateTime.Parse(arr[13]);

                            }
                            tender.Status = arr[10];
                            tender.Name = arr[11];
                            tender.Submission_End_Date = DateTime.Parse(arr[12]);
                            tender.Published = true;
                            list.Add(tender);

                        }
                    }

                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(list);
        }
        public ActionResult SingleTender()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                return View();
            }
        }
        public ActionResult EditSupplierProfile()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View();
            }
        }
        public ActionResult SpecialGroupTenders()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<TenderModel> list = new List<TenderModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var today = DateTime.Today;
                    var query = nav.fnGetInviteTender("");

                    String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');

                            if (arr[12] != "" && arr[14] == "Open Tender" && DateTime.Parse(arr[12]) >= today)
                            {
                                TenderModel tender = new TenderModel();
                                tender.Code = arr[0];
                                tender.Procurement_Method = arr[14];
                                tender.Solicitation_Type = arr[1];
                                tender.External_Document_No = arr[2];
                                tender.Procurement_Type = arr[3];
                                tender.Procurement_Category_ID = arr[4];
                                tender.Project_ID = arr[5];
                                tender.Tender_Name = arr[6];
                                tender.Tender_Summary = arr[7];
                                tender.Description = arr[8];
                                if (arr[9] != "")
                                {
                                    tender.Document_Date = DateTime.Parse(arr[9]);

                                }
                                tender.Status = arr[10];
                                tender.Name = arr[11];
                                if (arr[12] != "")
                                {
                                    tender.Submission_End_Date = DateTime.Parse(arr[12]);

                                }
                                if (arr[13] != "")
                                {
                                    tender.Submission_Start_Date = DateTime.Parse(arr[13]);

                                }
                                tender.Bid_Scoring_Template = arr[16];
                                tender.Published = true;
                                list.Add(tender);

                            }
                        }

                    }
                }
                catch (Exception e)
                {

                    throw;
                }
                return View(list);
            }
        }
        public ActionResult TendersbyRegions()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<TenderModel> list = new List<TenderModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var today = DateTime.Today;
                    var query = nav.fnGetInviteTender("");
                    String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');

                            if (arr[12] != "" && arr[14] == "Open Tender" && DateTime.Parse(arr[12]) >= today)
                            {
                                TenderModel tender = new TenderModel();
                                tender.Code = arr[0];
                                tender.Procurement_Method = arr[14];
                                tender.Solicitation_Type = arr[1];
                                tender.External_Document_No = arr[2];
                                tender.Procurement_Type = arr[3];
                                tender.Procurement_Category_ID = arr[4];
                                tender.Project_ID = arr[5];
                                tender.Tender_Name = arr[6];
                                tender.Tender_Summary = arr[7];
                                tender.Description = arr[8];
                                if (arr[9] != "")
                                {
                                    tender.Document_Date = DateTime.Parse(arr[9]);

                                }
                                if (arr[12] != "")
                                {
                                    tender.Submission_End_Date = DateTime.Parse(arr[12]);

                                }
                                if (arr[13] != "")
                                {
                                    tender.Submission_Start_Date = DateTime.Parse(arr[13]);

                                }
                                tender.Status = arr[10];
                                tender.Name = arr[11];
                                tender.Bid_Scoring_Template = arr[16];
                                tender.Published = true;
                                list.Add(tender);

                            }
                        }

                    }

                }
                catch (Exception e)
                {

                    throw;
                }
                return View(list);
            }
        }
        public ActionResult TendersbyClosingDates()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                List<TenderModel> list = new List<TenderModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    DateTime today = DateTime.Now;

                    var ranges = new List<int?> { 0, 14 };
                    var query = nav.fnGetInviteTender("");
                    String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');

                            if (arr[12] != "" && arr[14] == "Open Tender" && DateTime.Parse(arr[12]) >= today)
                            {
                                TenderModel tender = new TenderModel();
                                tender.Code = arr[0];
                                tender.Procurement_Method = arr[14];
                                tender.Solicitation_Type = arr[1];
                                tender.External_Document_No = arr[2];
                                tender.Procurement_Type = arr[3];
                                tender.Procurement_Category_ID = arr[4];
                                tender.Project_ID = arr[5];
                                tender.Tender_Name = arr[6];
                                tender.Tender_Summary = arr[7];
                                tender.Description = arr[8];
                                if (arr[9] != "")
                                {
                                    tender.Document_Date = DateTime.Parse(arr[9]);

                                }
                                if (arr[13] != "")
                                {
                                    tender.Submission_Start_Date = DateTime.Parse(arr[13]);

                                }
                                tender.Status = arr[10];
                                tender.Name = arr[11];
                                tender.Submission_End_Date = DateTime.Parse(arr[12]);
                                tender.Bid_Scoring_Template = arr[16];
                                tender.Published = true;
                                list.Add(tender);

                            }
                        }

                    }


                }
                catch (Exception e)
                {

                    throw;
                }
                return View(list);
            }
        }
        private static List<TenderModel> GetAllTendersClosingToday()
        {
            List<TenderModel> list = new List<TenderModel>();
            try
            {
                var nav = new NavConnection().queries();
                DateTime Today = DateTime.Now;
                var today = DateTime.Today;
                var ranges = new List<int?> { 0, 14 };
                var query = nav.fnGetInviteTender("");
                String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');

                        if (arr[12] != "" && arr[14] == "Open Tender" && DateTime.Parse(arr[12]) >= today)
                        {
                            TenderModel tender = new TenderModel();
                            tender.Code = arr[0];
                            tender.Procurement_Method = arr[14];
                            tender.Solicitation_Type = arr[1];
                            tender.External_Document_No = arr[2];
                            tender.Procurement_Type = arr[3];
                            tender.Procurement_Category_ID = arr[4];
                            tender.Project_ID = arr[5];
                            tender.Tender_Name = arr[6];
                            tender.Tender_Summary = arr[7];
                            tender.Description = arr[8];
                            if (arr[9] != "")
                            {
                                tender.Document_Date = DateTime.Parse(arr[9]);

                            }
                            if (arr[13] != "")
                            {
                                tender.Submission_Start_Date = DateTime.Parse(arr[13]);

                            }
                            tender.Status = arr[10];
                            tender.Name = arr[11];
                            tender.Submission_End_Date = DateTime.Parse(arr[12]);
                            tender.Bid_Scoring_Template = arr[16];
                            tender.Published = true;
                            list.Add(tender);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return list;
        }
        private static List<TenderModel> GetAllTendersClosing7Todays()
        {
            List<TenderModel> list = new List<TenderModel>();
            try
            {
                var nav = new NavConnection().queries();
                DateTime Today = DateTime.Now;
                var today = DateTime.Today;
                var ranges = new List<int?> { 0, 7 };
                var query = nav.fnGetInviteTender("");
                String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');

                        if (arr[12] != "" && arr[14] == "Open Tender" && DateTime.Parse(arr[12]) >= today)
                        {
                            TenderModel tender = new TenderModel();
                            tender.Code = arr[0];
                            tender.Procurement_Method = arr[14];
                            tender.Solicitation_Type = arr[1];
                            tender.External_Document_No = arr[2];
                            tender.Procurement_Type = arr[3];
                            tender.Procurement_Category_ID = arr[4];
                            tender.Project_ID = arr[5];
                            tender.Tender_Name = arr[6];
                            tender.Tender_Summary = arr[7];
                            tender.Description = arr[8];
                            if (arr[9] != "")
                            {
                                tender.Document_Date = DateTime.Parse(arr[9]);

                            }
                            if (arr[13] != "")
                            {
                                tender.Submission_Start_Date = DateTime.Parse(arr[13]);

                            }
                            tender.Status = arr[10];
                            tender.Name = arr[11];
                            tender.Submission_End_Date = DateTime.Parse(arr[12]);
                            tender.Bid_Scoring_Template = arr[16];
                            tender.Published = true;
                            list.Add(tender);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return list;
        }
        public ActionResult ActiveTenderAddedum()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<TenderAddendums> list = new List<TenderAddendums>();
                try
                {
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetTenderAddedNotice("");

                    String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            TenderAddendums addendum = new TenderAddendums();
                            addendum.Addendum_Notice_No = arr[0];
                            addendum.Invitation_Notice_No = arr[18];
                            addendum.Document_Date = Convert.ToString(arr[2]);
                            addendum.Description = arr[6];
                            addendum.Addendum_Instructions = arr[3];
                            addendum.Primary_Addendum_Type_ID = arr[4];
                            addendum.Addendum_Type_Description = arr[5];
                            addendum.Tender_No = arr[18];
                            addendum.Tender_Description = arr[7];
                            addendum.Responsibility_Center = arr[8];
                            addendum.New_Submission_Start_Date = Convert.ToString(arr[9]);
                            addendum.Status = arr[10];
                            addendum.Original_Submission_Start_Date = Convert.ToString(arr[11]);
                            addendum.New_Submission_End_Time = arr[19];
                            addendum.Original_Submission_End_Date = Convert.ToString(arr[21]);
                            addendum.Original_Bid_Opening_Date = Convert.ToString(arr[12]);
                            addendum.New_Bid_Opening_Date = Convert.ToString(arr[13]);
                            addendum.Original_Bid_Opening_Time = arr[20];
                            addendum.Original_Prebid_Meeting_Date = Convert.ToString(arr[15]);
                            addendum.New_Prebid_Meeting_Date = Convert.ToString(arr[16]);
                            addendum.Original_Bid_Opening_Date = Convert.ToString(arr[17]);
                            list.Add(addendum);
                        }
                    }
                }
                catch (Exception e)
                {

                    throw;
                }
                return View(list);
            }
        }
        public ActionResult ClosedTenders()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<TenderModel> list = new List<TenderModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var today = DateTime.Today;
                    var query = nav.fnGetInviteTender("");
                    String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');

                            if (arr[12] != "" && arr[14] == "Open Tender" && arr[17] == "Cancelled" && DateTime.Parse(arr[12]) >= today)
                            {
                                TenderModel tender = new TenderModel();
                                tender.Code = arr[0];
                                tender.Procurement_Method = arr[14];
                                tender.Solicitation_Type = arr[1];
                                tender.External_Document_No = arr[2];
                                tender.Procurement_Type = arr[3];
                                tender.Procurement_Category_ID = arr[4];
                                tender.Project_ID = arr[5];
                                tender.Tender_Name = arr[6];
                                tender.Tender_Summary = arr[7];
                                tender.Description = arr[8];
                                if (arr[9] != "")
                                {
                                    tender.Document_Date = DateTime.Parse(arr[9]);

                                }
                                if (arr[13] != "")
                                {
                                    tender.Submission_Start_Date = DateTime.Parse(arr[13]);

                                }
                                tender.Status = arr[10];
                                tender.Name = arr[11];
                                tender.Submission_End_Date = DateTime.Parse(arr[12]);
                                tender.Bid_Scoring_Template = arr[16];
                                tender.Published = true;
                                list.Add(tender);

                            }
                        }
                    }
                }
                catch (Exception e)
                {

                    throw;
                }
                return View(list);
            }
        }
        public ActionResult ActiveExpressionInterest()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<TenderModel> list = new List<TenderModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var today = DateTime.Today;
                    var query = nav.fnGetInviteTender("");
                    String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');

                            if (arr[12] != "" && arr[14] == "Open Tender" && DateTime.Parse(arr[12]) >= today)
                            {
                                TenderModel tender = new TenderModel();
                                tender.Code = arr[0];
                                tender.Procurement_Method = arr[14];
                                tender.Solicitation_Type = arr[1];
                                tender.External_Document_No = arr[2];
                                tender.Procurement_Type = arr[3];
                                tender.Procurement_Category_ID = arr[4];
                                tender.Project_ID = arr[5];
                                tender.Tender_Name = arr[6];
                                tender.Tender_Summary = arr[7];
                                tender.Description = arr[8];
                                if (arr[9] != "")
                                {
                                    tender.Document_Date = DateTime.Parse(arr[9]);

                                }
                                if (arr[13] != "")
                                {
                                    tender.Submission_Start_Date = DateTime.Parse(arr[13]);

                                }
                                tender.Status = arr[10];
                                tender.Name = arr[11];
                                tender.Submission_End_Date = DateTime.Parse(arr[12]);
                                tender.Published = true;
                                list.Add(tender);

                            }
                        }

                    }

                }
                catch (Exception e)
                {

                    throw;
                }
                return View(list);
            }
        }
        public ActionResult ContractAwards()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<TenderModel> list = new List<TenderModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var today = DateTime.Today;
                    var query = nav.fnGetInviteTender("");
                    String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');

                            if (arr[12] != "" && arr[14] == "Open Tender" && DateTime.Parse(arr[12]) >= today)
                            {
                                TenderModel tender = new TenderModel();
                                tender.Code = arr[0];
                                tender.Procurement_Method = arr[14];
                                tender.Solicitation_Type = arr[1];
                                tender.External_Document_No = arr[2];
                                tender.Procurement_Type = arr[3];
                                tender.Procurement_Category_ID = arr[4];
                                tender.Project_ID = arr[5];
                                tender.Tender_Name = arr[6];
                                tender.Tender_Summary = arr[7];
                                tender.Description = arr[8];
                                if (arr[9] != "")
                                {
                                    tender.Document_Date = DateTime.Parse(arr[9]);

                                }
                                if (arr[13] != "")
                                {
                                    tender.Submission_Start_Date = DateTime.Parse(arr[13]);

                                }
                                tender.Status = arr[10];
                                tender.Name = arr[11];
                                tender.Submission_End_Date = DateTime.Parse(arr[12]);
                                tender.Bid_Scoring_Template = arr[16];
                                tender.Published = true;
                                list.Add(tender);

                            }
                        }

                    }

                }
                catch (Exception e)
                {

                    throw;
                }
                return View(list);
            }
        }


        public ActionResult OpenPerfomanceGuarantee()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<performanceGuarantee> list = new List<performanceGuarantee>();
                try
                {
                    var nav = new NavConnection().queries();
                    var today = DateTime.Today;
                    var vendorNo = Session["vendorNo"].ToString();
                    var query = nav.fnGetOldPerformanceGuarantees(vendorNo, "Performance Guarantee");
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            performanceGuarantee tender = new performanceGuarantee();
                            tender.docNo = arr[0];
                            tender.DocDate = Convert.ToString(arr[1]);
                            tender.contractorName = arr[3];
                            tender.projectId = arr[4];
                            tender.projectName = arr[5];
                            tender.status = arr[6];
                            tender.gurantorName = arr[7];
                            tender.policyNo = arr[8];
                            tender.expiryDate = Convert.ToString(arr[2]);
                            list.Add(tender);
                        }
                    }


                }
                catch (Exception e)
                {

                    throw;
                }
                return View(list);
            }
        }

        public ActionResult DebarmentList()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<TenderVDerbarmentTModel> list = new List<TenderVDerbarmentTModel>();
                try
                {
                    var vendorNo = Session["vendorNo"].ToString();
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetVendorDepartmentEntry(vendorNo);
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            TenderVDerbarmentTModel tender = new TenderVDerbarmentTModel();
                            tender.Entry_no = Convert.ToString(arr[0]);
                            tender.Source_Voucher_No = arr[1];
                            tender.Document_Type = arr[2];
                            tender.Reason_Code = arr[3];
                            tender.Firm_Name = arr[4];
                            tender.Description = arr[6];
                            tender.Ineligibility_End_Date = Convert.ToString(arr[7]);
                            tender.Ineligibility_Start_Date = Convert.ToString(arr[8]);
                            tender.Reinstatement_Date = Convert.ToString(arr[9]);
                            tender.Blocked = Convert.ToBoolean(arr[10]);
                            tender.Country_Region_Code = arr[11];
                            tender.Address = arr[12];
                            tender.Incorporation_Reg_No = arr[13];
                            tender.Tax_Registration_PIN_No = arr[14];
                            list.Add(tender);
                        }
                    }
                }
                catch (Exception e)
                {

                    throw;
                }
                return View(list);
            }
        }
        public ActionResult AnnouncementsList()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<TenderModel> list = new List<TenderModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var today = DateTime.Today;
                    var query = nav.fnGetInviteTender("");
                    String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');

                            if (arr[12] != "" && arr[14] == "Open Tender" && DateTime.Parse(arr[12]) >= today)
                            {
                                TenderModel tender = new TenderModel();
                                tender.Code = arr[0];
                                tender.Procurement_Method = arr[14];
                                tender.Solicitation_Type = arr[1];
                                tender.External_Document_No = arr[2];
                                tender.Procurement_Type = arr[3];
                                tender.Procurement_Category_ID = arr[4];
                                tender.Project_ID = arr[5];
                                tender.Tender_Name = arr[6];
                                tender.Tender_Summary = arr[7];
                                tender.Description = arr[8];
                                if (arr[9] != "")
                                {
                                    tender.Document_Date = DateTime.Parse(arr[9]);

                                }
                                if (arr[12] != "")
                                {
                                    tender.Submission_End_Date = DateTime.Parse(arr[12]);

                                }
                                if (arr[13] != "")
                                {
                                    tender.Submission_Start_Date = DateTime.Parse(arr[13]);

                                }
                                tender.Status = arr[10];
                                tender.Name = arr[11];
                                tender.Bid_Scoring_Template = arr[16];
                                tender.Published = true;
                                list.Add(tender);

                            }
                        }

                    }



                }
                catch (Exception e)
                {

                    throw;
                }
                return View(list);
            }
        }
        public ActionResult LanguageCode()
        {
            List<LanguageModel> list = new List<LanguageModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetLanguage();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        LanguageModel language = new LanguageModel();
                        language.Code = arr[0];
                        language.Name = arr[1];
                        list.Add(language);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(list);
        }
        public ActionResult VendorSpecialGroup()
        {
            List<SpecialGroupCategoryModel> list = new List<SpecialGroupCategoryModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetVendorSpecialGroupCategory();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        SpecialGroupCategoryModel group = new SpecialGroupCategoryModel();
                        group.Code = arr[0];
                        group.Name = arr[1];
                        list.Add(group);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(list);
        }

        public ActionResult supplierCategories()
        {
            List<SupplierCategory> list = new List<SupplierCategory>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetSupplierCategory();
                String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        SupplierCategory group = new SupplierCategory();
                        group.code = arr[0];
                        group.description = arr[1];
                        list.Add(group);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(list);
        }



        public ActionResult IndustryGroups()
        {
            List<IndustryGroupModel> list = new List<IndustryGroupModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetIndustryGroup();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        IndustryGroupModel industries = new IndustryGroupModel();
                        industries.Code = arr[0];
                        industries.Description = arr[1];
                        list.Add(industries);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(list);
        }
        public ActionResult BusinessTypes()
        {
            List<BusinessTypesModel> list = new List<BusinessTypesModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetBusinessType();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BusinessTypesModel businesstypes = new BusinessTypesModel();
                        businesstypes.Code = arr[0];
                        businesstypes.Description = arr[1];
                        businesstypes.Ownership_Type = arr[2];
                        list.Add(businesstypes);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(list);
        }
        public ActionResult BidSecuritiesList()
        {
            List<CountriesModel> list = new List<CountriesModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetCountries();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        CountriesModel country = new CountriesModel();
                        country.Code = arr[0];
                        country.Name = arr[1];
                        list.Add(country);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(list);
        }
        public ActionResult ViewBankCodesList()
        {
            List<BankModel> list = new List<BankModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetBankCodes();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        BankModel bank = new BankModel();
                        bank.BankCode = arr[0];
                        bank.BankName = arr[1];
                        list.Add(bank);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(list);
        }
        public ActionResult viewBankBranches(String bankCode)
        {
            List<BankModel> list = new List<BankModel>();
            //try
            //{
            //    var nav = new NavConnection().queries();
            //    var query = nav.fnGetBankBranch(bankCode);
            //    String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
            //    if (info != null)
            //    {
            //        for (int i = 0; i < info.Length; i++)
            //        {
            //            String[] arr = info[i].Split('*');
            //            BankModel bank = new BankModel();
            //            bank.BankCode = arr[0];
            //            bank.BankName = arr[1];
            //            list.Add(bank);
            //        }
            //    }

            //}
            //catch (Exception e)
            //{

            //    throw;
            //}
            return Json(list, JsonRequestBehavior.AllowGet);

        }
        public ActionResult CurrencyCodeLists()
        {
            List<CurrencyModel> list = new List<CurrencyModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetCurrency();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        CurrencyModel currency = new CurrencyModel();
                        currency.Code = arr[0];
                        currency.Description = arr[1];
                        list.Add(currency);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(list);
        }
        public ActionResult EntityType()
        {
            List<EntityType> list = new List<EntityType>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetBusinessType();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        EntityType currency = new EntityType();
                        currency.Code = arr[0];
                        currency.Description = arr[1];
                        list.Add(currency);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(list);
        }
        public ActionResult VendorBanksCountryList()
        {
            List<CountriesModel> list = new List<CountriesModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetCountries();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        CountriesModel country = new CountriesModel();
                        country.Code = arr[0];
                        country.Name = arr[1];
                        list.Add(country);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(list);
        }
        public ActionResult TenderSecurityLists()
        {

            List<TenderSecurityTypes> list = new List<TenderSecurityTypes>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetTenderSecurityTypes("");
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        TenderSecurityTypes securitytype = new TenderSecurityTypes();
                        securitytype.Code = arr[0];
                        securitytype.Security_Type = arr[2];
                        securitytype.Description = arr[1];
                        securitytype.Nature_of_Security = arr[3];
                        list.Add(securitytype);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(list);
        }
        public ActionResult CountriesList()
        {
            List<CountriesModel> list = new List<CountriesModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetCountries();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        CountriesModel country = new CountriesModel();
                        country.Code = arr[0];
                        country.Name = arr[1];
                        list.Add(country);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(list);
        }
        public ActionResult RegionsList()
        {
            List<CountriesModel> list = new List<CountriesModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetRegions();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        CountriesModel region = new CountriesModel();
                        region.CountyCode = arr[0];
                        region.CountyName = arr[1];
                        list.Add(region);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(list);
        }
        public ActionResult ResponsibilityCenters()
        {
            List<ResponsibilityCenter> list = new List<ResponsibilityCenter>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetResponsibilityCenters("Region");
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        ResponsibilityCenter RC = new ResponsibilityCenter();
                        RC.code = arr[0];
                        RC.name = arr[1];
                        list.Add(RC);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(list);
        }
        public ActionResult ViewPrequalificationsRegions()
        {
            List<CountriesModel> list = new List<CountriesModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetRegions();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        CountriesModel region = new CountriesModel();
                        region.CountyCode = arr[0];
                        region.CountyName = arr[1];
                        list.Add(region);
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return View(list);
        }

        public ActionResult RegistrationPeriod()
        {

            //List<CountriesModel> list = new List<CountriesModel>();
            //try
            //{
            //    var nav = new NavConnection().queries();
            //    var query = nav.per
            //    foreach (var regions in query)
            //    {
            //        CountriesModel region = new CountriesModel();
            //        region.RegistrationCode = regions.Code;
            //        region.RegistrationDescription = regions.Description;
            //        list.Add(region);
            //    }
            //}
            //catch (Exception e)
            //{

            //    throw;
            //}
            return View();
        }


        public ActionResult KeyStaffCountriesList()
        {
            List<CountriesModel> list = new List<CountriesModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetCountries();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        CountriesModel country = new CountriesModel();
                        country.Code = arr[0];
                        country.Name = arr[1];
                        list.Add(country);
                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return View(list);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public JsonResult FnUploadmandatoryDoc(HttpPostedFileBase browsedfile, string typauploadselect, string filedescription, string certificatenumber, DateTime dateofissue, DateTime expirydate)
        {
            try
            {


                var vendorNo = Convert.ToString(Session["vendorNo"]);
                var nav = new NavConnection().ObjNav();
                string storedFilename = "";
                DateTime startdate, enddate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                int errCounter = 0, succCounter = 0;
                if (dateofissue == null && expirydate == null)
                {
                    dateofissue = Convert.ToDateTime("");
                    expirydate = Convert.ToDateTime("");
                }

                if (browsedfile == null)
                {
                    errCounter++;
                    return Json("danger*browsedfilenull", JsonRequestBehavior.AllowGet);
                }

                if (vendorNo.Contains(":"))
                    vendorNo = vendorNo.Replace(":", "[58]");
                vendorNo = vendorNo.Replace("/", "[47]");

                if (filedescription.Contains("/"))
                    filedescription = filedescription.Replace("/", "_");

                if (typauploadselect.Contains("/"))
                    typauploadselect = typauploadselect.Replace("/", "_");


                string fileName0 = Path.GetFileName(browsedfile.FileName);
                string ext0 = _getFileextension(browsedfile);
                string savedF0 = vendorNo + "_" + fileName0 + ext0;

                bool up2Sharepoint = _UploadSupplierDocumentToSharepoint(vendorNo, browsedfile, filedescription);
                if (up2Sharepoint == true)
                {
                    string filename = vendorNo + "_" + fileName0;
                    string sUrl = ConfigurationManager.AppSettings["S_URL"];
                    string defaultlibraryname = "Procurement%20Documents/";
                    string customlibraryname = "Vendor Card";
                    string sharepointLibrary = defaultlibraryname + customlibraryname;
                    vendorNo = vendorNo.Replace('/', '_');
                    vendorNo = vendorNo.Replace(':', '_');
                    //Sharepoint File Link
                    string sharepointlink = sUrl + sharepointLibrary + "/" + vendorNo + "/" + filename;
                    string fsavestatus = nav.fnInsertFiledetails(vendorNo, typauploadselect, filedescription,
                       certificatenumber, dateofissue, expirydate, filename, sharepointlink);
                    var splitanswer = fsavestatus.Split('*');
                    switch (splitanswer[0])
                    {
                        case "success":
                            return Json("success*" + succCounter, JsonRequestBehavior.AllowGet);
                        default:
                            return Json("danger*" + succCounter, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json("sharepointError*", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult uploadMandatoryFiles(HttpPostedFileBase browsedfile, string typauploadselect,
                 string filedescription, string certificatenumber, string dateofissue, string expirydate)
        {
            try
            {
                var vendorNo = Convert.ToString(Session["vendorNo"]);
                var nav = new NavConnection().ObjNav();
                int errCounter = 0, succCounter = 0;
                DateTime startdate, enddate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                DateTime dtofIssue = DateTime.Now;
                DateTime expiryDate = DateTime.Now;
                if (dateofissue == null && expirydate == null)
                {
                    dtofIssue = DateTime.Parse(dateofissue, usCulture.DateTimeFormat);
                    expiryDate = DateTime.Parse(expirydate, usCulture.DateTimeFormat);
                }


                if (browsedfile == null)
                {
                    errCounter++;
                    return Json("danger*browsedfilenull", JsonRequestBehavior.AllowGet);
                }

                if (vendorNo.Contains(":"))
                    vendorNo = vendorNo.Replace(":", "[58]");
                vendorNo = vendorNo.Replace("/", "[47]");

                if (filedescription.Contains("/"))
                    filedescription = filedescription.Replace("/", "_");

                if (typauploadselect.Contains("/"))
                    typauploadselect = typauploadselect.Replace("/", "_");


                string fileName0 = Path.GetFileName(browsedfile.FileName);
                string savedF0 = vendorNo + "_" + fileName0;
                string path1 = ConfigurationManager.AppSettings["FilesLocation"] + "Supplier Documents/";
                string str1 = Convert.ToString(vendorNo);
                string folderName = path1 + str1 + "/";

                if (!Directory.Exists(folderName))
                {
                    Directory.CreateDirectory(folderName);
                }
                if (System.IO.File.Exists(savedF0))
                {
                    System.IO.File.Delete(savedF0);
                }
                browsedfile.SaveAs(folderName + savedF0);
                string fsavestatus = nav.fnInsertFiledetails(vendorNo, typauploadselect, filedescription, certificatenumber, dtofIssue, expiryDate, savedF0, folderName + savedF0);
                var splitanswer = fsavestatus.Split('*');
                switch (splitanswer[0])
                {
                    case "success":
                        return Json("success*" + succCounter, JsonRequestBehavior.AllowGet);
                    default:
                        return Json("danger*" + succCounter, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult FnUploadmandatoryRegistrationDocuments(HttpPostedFileBase browsedfile, string typauploadselect,
          string filedescription, string certificatenumber, string dateofissue, string expirydate)
        {
            try
            {
                var vendorNo = Convert.ToString(Session["vendorNo"]);
                var nav = new NavConnection().ObjNav();
                string storedFilename = "";

                int errCounter = 0, succCounter = 0;
                DateTime startdate, enddate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                DateTime dtofIssue = DateTime.Now;
                DateTime expiryDate = DateTime.Now;
                if (dateofissue == null && expirydate == null)
                {
                    dtofIssue = DateTime.Parse(dateofissue, usCulture.DateTimeFormat);
                    expiryDate = DateTime.Parse(expirydate, usCulture.DateTimeFormat);
                }


                if (browsedfile == null)
                {
                    errCounter++;
                    return Json("danger*browsedfilenull", JsonRequestBehavior.AllowGet);
                }

                if (vendorNo.Contains(":"))
                    vendorNo = vendorNo.Replace(":", "[58]");
                vendorNo = vendorNo.Replace("/", "[47]");

                if (filedescription.Contains("/"))
                    filedescription = filedescription.Replace("/", "_");

                if (typauploadselect.Contains("/"))
                    typauploadselect = typauploadselect.Replace("/", "_");


                string fileName0 = Path.GetFileName(browsedfile.FileName);
                string ext0 = _getFileextension(browsedfile);
                string savedF0 = vendorNo + "_" + fileName0 + ext0;

                bool up2Sharepoint = _UploadSupplierDocumentToSharepoint(vendorNo, browsedfile, filedescription);
                if (up2Sharepoint == true)
                {
                    string filename = vendorNo + "_" + fileName0;
                    string sUrl = ConfigurationManager.AppSettings["S_URL"];
                    string defaultlibraryname = "Procurement%20Documents/";
                    string customlibraryname = "Vendor Card";
                    string sharepointLibrary = defaultlibraryname + customlibraryname;
                    string sharepointlink = sUrl + sharepointLibrary + "/" + vendorNo + "/" + filename;


                    string fsavestatus = nav.fnInsertFiledetails(vendorNo, typauploadselect, filedescription, certificatenumber, dtofIssue, expiryDate, filename, sharepointlink);
                    var splitanswer = fsavestatus.Split('*');
                    switch (splitanswer[0])
                    {
                        case "success":
                            return Json("success*" + succCounter, JsonRequestBehavior.AllowGet);
                        default:
                            return Json("danger*" + succCounter, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json("sharepointError*", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult FnUploadmandatoryPrequalificationDoc(string prequalificationNumber, HttpPostedFileBase browsedfile, string typauploadselect,
            string filedescription, string certificatenumber, string dateofissue, string expirydate)
        {
            try
            {
                var vendorNo = Convert.ToString(Session["vendorNo"]);
                var nav = new NavConnection().ObjNav();
                string storedFilename = "";

                int errCounter = 0, succCounter = 0;
                DateTime startdate, enddate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                DateTime dtofIssue = DateTime.Now;
                DateTime expiryDate = DateTime.Now;
                if (dateofissue != null && expirydate != null)
                {
                    dtofIssue = DateTime.Parse(dateofissue, usCulture.DateTimeFormat);
                    expiryDate = DateTime.Parse(expirydate, usCulture.DateTimeFormat);
                }


                if (browsedfile == null)
                {
                    errCounter++;
                    return Json("danger*browsedfilenull", JsonRequestBehavior.AllowGet);
                }

                if (vendorNo.Contains(":"))
                    vendorNo = vendorNo.Replace(":", "[58]");
                vendorNo = vendorNo.Replace("/", "[47]");

                if (filedescription.Contains("/"))
                    filedescription = filedescription.Replace("/", "_");

                if (typauploadselect.Contains("/"))
                    typauploadselect = typauploadselect.Replace("/", "_");


                string fileName0 = Path.GetFileName(browsedfile.FileName);
                string ext0 = _getFileextension(browsedfile);
                string savedF0 = vendorNo + "_" + fileName0;


                // saving file in local server
                string folder = ConfigurationManager.AppSettings["FilesLocation"] + "Procurement Documents/PrequalificationDocs/";
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                if (Directory.Exists(folder))
                {
                    String documentDirectory = folder + vendorNo + "/";
                    Boolean createDirectory = true;
                    try
                    {
                        if (!Directory.Exists(documentDirectory))
                        {
                            Directory.CreateDirectory(documentDirectory);
                        }
                    }
                    catch (Exception ex)
                    {
                        createDirectory = false;
                    }
                    if (createDirectory)
                    {
                        string fileLink = documentDirectory + browsedfile.FileName;
                        string filename = vendorNo + "_" + fileName0;
                        browsedfile.SaveAs(fileLink);

                        string fsavestatus = nav.fnInsertPrequalificatinDocuments(vendorNo, typauploadselect, filedescription, certificatenumber, dtofIssue, expiryDate, filename, prequalificationNumber, fileLink);
                        var splitanswer = fsavestatus.Split('*');
                        switch (splitanswer[0])
                        {
                            case "success":
                                return Json("success*" + succCounter, JsonRequestBehavior.AllowGet);
                            default:
                                return Json("danger*" + succCounter, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json("danger*", JsonRequestBehavior.AllowGet);
                    }

                }
                else
                {
                    
                    return Json("danger*", JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult FnUploadBidResponseDocumentsc(string BidResponseNumber, HttpPostedFileBase browsedfile, string prodocType,
            string filedescription, string certificatenumber, string dateofissue, string expirydate)
        {
            try
            {
                var vendorNo = Convert.ToString(Session["vendorNo"]);
                var nav = new NavConnection().ObjNav();
                string storedFilename = "";
                CultureInfo usCulture = new CultureInfo("en-ES");
                int errCounter = 0, succCounter = 0;
                DateTime dtofIssue = DateTime.Now;
                DateTime expiryDate = DateTime.Now;
                if (dateofissue == null && expirydate == null)
                {
                    dtofIssue = DateTime.Parse(dateofissue, usCulture.DateTimeFormat);
                    expiryDate = DateTime.Parse(expirydate, usCulture.DateTimeFormat);
                }


                if (browsedfile == null)
                {
                    errCounter++;
                    return Json("danger*browsedfilenull", JsonRequestBehavior.AllowGet);
                }

                if (vendorNo.Contains(":"))
                    vendorNo = vendorNo.Replace(":", "[58]");
                vendorNo = vendorNo.Replace("/", "[47]");

                if (filedescription.Contains("/"))
                    filedescription = filedescription.Replace("/", "_");

                if (prodocType.Contains("/"))
                    prodocType = prodocType.Replace("/", "_");


                string fileName0 = Path.GetFileName(browsedfile.FileName);
                string ext0 = _getFileextension(browsedfile);
                string savedF0 = vendorNo + "_" + prodocType + ext0;

                // saving file in local server
                string folder = ConfigurationManager.AppSettings["FilesLocation"] + "Procurement Documents/TenderDocs/";
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                if (Directory.Exists(folder))
                {
                    String documentDirectory = folder + vendorNo + "/";
                    Boolean createDirectory = true;
                    try
                    {
                        if (!Directory.Exists(documentDirectory))
                        {
                            Directory.CreateDirectory(documentDirectory);
                        }
                    }
                    catch (Exception ex)
                    {
                        createDirectory = false;
                    }
                    if (createDirectory)
                    {
                        string fileLink = documentDirectory + browsedfile.FileName;
                        string filename = vendorNo + "_" + fileName0;
                        browsedfile.SaveAs(fileLink);

                        string fsavestatus = nav.fnInsertBidReponseDocuments(vendorNo, prodocType, filedescription, certificatenumber, dtofIssue, expiryDate, filename, BidResponseNumber, fileLink);
                        var splitanswer = fsavestatus.Split('*');
                        switch (splitanswer[0])
                        {
                            case "success":
                                return Json("success*" + succCounter, JsonRequestBehavior.AllowGet);
                            default:
                                return Json("danger*" + succCounter, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json("sharepointError*", JsonRequestBehavior.AllowGet);
                    }

                }
                else
                {
                    return Json("sharepointerror*", JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult FnUploadRfqBidResponseDocument(string BidResponseNumber, HttpPostedFileBase browsedfile, string prodocType,
           string filedescription, string certificatenumber, string dateofissue, string expirydate)
        {
            try
            {
                var vendorNo = Convert.ToString(Session["vendorNo"]);
                var nav = new NavConnection().ObjNav();
                string storedFilename = "";
                CultureInfo usCulture = new CultureInfo("en-ES");
                int errCounter = 0, succCounter = 0;
                DateTime dtofIssue = DateTime.Now;
                DateTime expiryDate = DateTime.Now;
                if (dateofissue == null && expirydate == null)
                {
                    dtofIssue = DateTime.Parse(dateofissue, usCulture.DateTimeFormat);
                    expiryDate = DateTime.Parse(expirydate, usCulture.DateTimeFormat);
                }


                if (browsedfile == null)
                {
                    errCounter++;
                    return Json("danger*browsedfilenull", JsonRequestBehavior.AllowGet);
                }

                if (vendorNo.Contains(":"))
                    vendorNo = vendorNo.Replace(":", "[58]");
                vendorNo = vendorNo.Replace("/", "[47]");

                if (filedescription.Contains("/"))
                    filedescription = filedescription.Replace("/", "_");

                if (prodocType.Contains("/"))
                    prodocType = prodocType.Replace("/", "_");


                string fileName0 = Path.GetFileName(browsedfile.FileName);
                string ext0 = _getFileextension(browsedfile);
                string savedF0 = vendorNo + "_" + prodocType + ext0;

                // saving file in local server
                string folder = ConfigurationManager.AppSettings["FilesLocation"] + "Procurement Documents/Bid Documents/";
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                if (Directory.Exists(folder))
                {
                    String documentDirectory = folder + vendorNo + "/";
                    Boolean createDirectory = true;
                    try
                    {
                        if (!Directory.Exists(documentDirectory))
                        {
                            Directory.CreateDirectory(documentDirectory);
                        }
                    }
                    catch (Exception ex)
                    {
                        createDirectory = false;
                    }
                    if (createDirectory)
                    {
                        string fileLink = documentDirectory + browsedfile.FileName;
                        string filename = vendorNo + "_" + fileName0;
                        browsedfile.SaveAs(fileLink);
                        string fsavestatus = nav.fnInsertBidReponseDocuments(vendorNo, prodocType, filedescription, certificatenumber, dtofIssue, expiryDate, filename, BidResponseNumber, fileLink);
                        var splitanswer = fsavestatus.Split('*');
                        switch (splitanswer[0])
                        {
                            case "success":
                                return Json("success*" + succCounter, JsonRequestBehavior.AllowGet);
                            default:
                                return Json("danger*" + succCounter, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json("sharepointError*", JsonRequestBehavior.AllowGet);
                    }

                }
                else
                {
                    return Json("sharepointerror*", JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }





        public JsonResult FnUploadPerfomanceGuaranteeDocuments(HttpPostedFileBase browsedfile, string ResponseNumber)
        {
            try
            {
                var vendorNo = Convert.ToString(Session["vendorNo"]);
                var nav = new NavConnection().ObjNav();
                string storedFilename = "";
                CultureInfo usCulture = new CultureInfo("en-ES");
                int errCounter = 0, succCounter = 0;




                if (browsedfile == null)
                {
                    errCounter++;
                    return Json("danger*browsedfilenull", JsonRequestBehavior.AllowGet);
                }

                if (vendorNo.Contains(":"))
                    vendorNo = vendorNo.Replace(":", "[58]");
                vendorNo = vendorNo.Replace("/", "[47]");




                string fileName0 = Path.GetFileName(browsedfile.FileName);
                string ext0 = _getFileextension(browsedfile);
                string savedF0 = vendorNo + "_" + ext0;

                bool up2Sharepoint = _UploadPerformanceGuaranteeDocumentToSharepoint(ResponseNumber, browsedfile);
                if (up2Sharepoint == true)
                {
                    string filename = vendorNo + "_" + fileName0;
                    string sUrl = ConfigurationManager.AppSettings["S_URL"];
                    string defaultlibraryname = "Procurement%20Documents/";
                    string customlibraryname = "Performance Guarantee";
                    string sharepointLibrary = defaultlibraryname + customlibraryname;
                    ResponseNumber = ResponseNumber.Replace('/', '_');
                    ResponseNumber = ResponseNumber.Replace(':', '_');
                    //Sharepoint File Link
                    // string sharepointlink = sUrl + sharepointLibrary + "/" + ResponseNumber + "/" + filename;
                    string sharepointlink = sUrl + sharepointLibrary + "/" + ResponseNumber + "/" + filename;

                    string fsavestatus = nav.FnInsertPerfGuarantDocuments(vendorNo, filename, ResponseNumber, sharepointlink);
                    var splitanswer = fsavestatus.Split('*');
                    switch (splitanswer[0])
                    {
                        case "success":
                            return Json("success*" + succCounter, JsonRequestBehavior.AllowGet);
                        default:
                            return Json("danger*" + succCounter, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json("sharepointError*", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult FnUploadPerfomanceGuaranteeDocumentsLocal(HttpPostedFileBase browsedfile, string typauploadselect, string prn, string indexNo, string ResponseNumber)
        {
            try
            {
                var vendorNo = Convert.ToString(Session["vendorNo"]);
                var nav = new NavConnection().ObjNav();
                string storedFilename = "";
                DateTime startdate, enddate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                int errCounter = 0, succCounter = 0;




                if (browsedfile == null)
                {
                    errCounter++;
                    return Json("danger*browsedfilenull", JsonRequestBehavior.AllowGet);
                }

                if (vendorNo.Contains(":"))
                    vendorNo = vendorNo.Replace(":", "[58]");
                vendorNo = vendorNo.Replace("/", "[47]");


                if (typauploadselect.Contains("/"))
                    typauploadselect = typauploadselect.Replace("/", "_");

                string fileName0 = Path.GetFileName(browsedfile.FileName);
                string ext0 = _getFileextension(browsedfile);
                string savedF0 = prn + "_" + indexNo + "_" + fileName0;
                // create the uploads folder if it doesn't exist               
                var rootFolder = ConfigurationManager.AppSettings["FilesLocation"];
                var subfolder = Path.Combine(rootFolder, "Contract/" + prn);
                if (!Directory.Exists(subfolder))
                    Directory.CreateDirectory(subfolder);
                browsedfile.SaveAs(subfolder + "/" + savedF0);
                var FilePath = subfolder + "/" + savedF0;
                var nav1 = new NavConnection().ObjNav();
                //nav.FnInsertPerfGuarantDocuments(vendorNo, filename, ResponseNumber, sharepointlink);
                var status = nav.fnInsertFiledetailsPerformanceGuarantee(vendorNo, typauploadselect, ResponseNumber, FilePath);
                return Json("success*" + "File uploaded successfully", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }




        public string _getFileextension(HttpPostedFileBase filename)
        {
            return (Path.GetExtension(filename.FileName));
        }
        public JsonResult TenderDocChecker(string tendorNo)
        {
            try
            {
                var fileVirtualPath = (dynamic)null;
                if (tendorNo.Contains(":"))
                    tendorNo = tendorNo.Replace(":", "[58]");
                tendorNo = tendorNo.Replace("/", "[47]");
                fileVirtualPath = HostingEnvironment.MapPath(@"~/Downloads/Tenders/" + tendorNo + "/" + string.Format("{0}.pdf", tendorNo));
                string fileBytes = "";
                if (fileBytes != null)
                {
                    return Json("filefound", JsonRequestBehavior.AllowGet);
                }
                return Json("filenotfound", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("filenotfound", JsonRequestBehavior.AllowGet);
                // return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        protected bool _UploadSupplierDocumentToSharepoint(string vendorNumber, HttpPostedFileBase browsedFile, string filedescription)
        {
            bool fileuploadSuccess = false;
            string sUrl = ConfigurationManager.AppSettings["S_URL"];
            string tfilename = browsedFile.FileName;
            string defaultlibraryname = "Procurement%20Documents/";
            string customlibraryname = "Vendor Card";
            string sharepointLibrary = defaultlibraryname + customlibraryname;
            vendorNumber = vendorNumber.Replace('/', '_');
            vendorNumber = vendorNumber.Replace(':', '_');

            if (!string.IsNullOrWhiteSpace(sUrl) && !string.IsNullOrWhiteSpace(sharepointLibrary) && !string.IsNullOrWhiteSpace(tfilename))
            {
                string username = ConfigurationManager.AppSettings["S_USERNAME"];
                string password = ConfigurationManager.AppSettings["S_PWD"];
                string domainname = ConfigurationManager.AppSettings["S_DOMAIN"];
                bool bbConnected = Connect(sUrl, username, password, domainname);
                try
                {
                    if (bbConnected)
                    {
                        Uri uri = new Uri(sUrl);
                        string sSpSiteRelativeUrl = uri.AbsolutePath;
                        string uploadfilename = vendorNumber + "_" + browsedFile.FileName;
                        Stream uploadfileContent = browsedFile.InputStream;
                        var sDocName = UploadSupplierRegFile(uploadfileContent, uploadfilename, sSpSiteRelativeUrl, sharepointLibrary, vendorNumber);

                        //SharePoint Link to be added to Navison Card
                        string sharepointlink = sUrl + sharepointLibrary + "/" + vendorNumber + "/" + uploadfilename;

                        if (!string.IsNullOrWhiteSpace(sDocName))
                        {
                            //var nav = NavConnection.ReturnNav();
                            //string vendorNumberIdentity = vendorNumber;
                            //string status = nav.FnrfiResponsetLinks(vendorNumberIdentity, uploadfilename, sharepointlink); 
                            fileuploadSuccess = true;
                        }
                    }
                }
                catch (Exception)
                {
                    // throw;
                }
            }
            return fileuploadSuccess;
        }

        protected bool _UploadTenderDocumentToSharepoint(string vendorNumber, HttpPostedFileBase browsedFile, string filedescription)
        {
            bool fileuploadSuccess = false;
            string sUrl = ConfigurationManager.AppSettings["S_URL"];
            string tfilename = browsedFile.FileName;
            string defaultlibraryname = "Procurement%20Documents/";
            string customlibraryname = "Tender Bid Reponses";
            string sharepointLibrary = defaultlibraryname + customlibraryname;
            vendorNumber = vendorNumber.Replace('/', '_');
            vendorNumber = vendorNumber.Replace(':', '_');

            if (!string.IsNullOrWhiteSpace(sUrl) && !string.IsNullOrWhiteSpace(sharepointLibrary) && !string.IsNullOrWhiteSpace(tfilename))
            {
                string username = ConfigurationManager.AppSettings["S_USERNAME"];
                string password = ConfigurationManager.AppSettings["S_PWD"];
                string domainname = ConfigurationManager.AppSettings["S_DOMAIN"];
                bool bbConnected = Connect(sUrl, username, password, domainname);
                try
                {
                    if (bbConnected)
                    {
                        Uri uri = new Uri(sUrl);
                        string sSpSiteRelativeUrl = uri.AbsolutePath;
                        string uploadfilename = vendorNumber + "_" + browsedFile.FileName;
                        Stream uploadfileContent = browsedFile.InputStream;
                        var sDocName = UploadSupplierTenderFile(uploadfileContent, uploadfilename, sSpSiteRelativeUrl, sharepointLibrary, vendorNumber);

                        //SharePoint Link to be added to Navison Card
                        string sharepointlink = sUrl + sharepointLibrary + "/" + vendorNumber + "/" + uploadfilename;

                        if (!string.IsNullOrWhiteSpace(sDocName))
                        {
                            //var nav = NavConnection.ReturnNav();
                            //string vendorNumberIdentity = vendorNumber;
                            //string status = nav.FnrfiResponsetLinks(vendorNumberIdentity, uploadfilename, sharepointlink); 
                            fileuploadSuccess = true;
                        }
                    }
                }
                catch (Exception)
                {
                    // throw;
                }
            }
            return fileuploadSuccess;
        }

        protected bool _UploadPerformanceGuaranteeDocumentToSharepoint(string vendorNumber, HttpPostedFileBase browsedFile)
        {
            bool fileuploadSuccess = false;
            string sUrl = ConfigurationManager.AppSettings["S_URL"];
            string tfilename = browsedFile.FileName;
            string defaultlibraryname = "Procurement%20Documents/";
            string customlibraryname = "Performance Guarantee";
            string sharepointLibrary = defaultlibraryname + customlibraryname;
            vendorNumber = vendorNumber.Replace('/', '_');
            vendorNumber = vendorNumber.Replace(':', '_');

            if (!string.IsNullOrWhiteSpace(sUrl) && !string.IsNullOrWhiteSpace(sharepointLibrary) && !string.IsNullOrWhiteSpace(tfilename))
            {
                string username = ConfigurationManager.AppSettings["S_USERNAME"];
                string password = ConfigurationManager.AppSettings["S_PWD"];
                string domainname = ConfigurationManager.AppSettings["S_DOMAIN"];
                bool bbConnected = Connect(sUrl, username, password, domainname);
                try
                {
                    if (bbConnected)
                    {
                        Uri uri = new Uri(sUrl);
                        string sSpSiteRelativeUrl = uri.AbsolutePath;
                        string uploadfilename = vendorNumber + "_" + browsedFile.FileName;
                        Stream uploadfileContent = browsedFile.InputStream;
                        var sDocName = UploadSupplierPerfGuaranteeFile(uploadfileContent, uploadfilename, sSpSiteRelativeUrl, sharepointLibrary, vendorNumber);

                        //SharePoint Link to be added to Navison Card
                        string sharepointlink = sUrl + sharepointLibrary + "/" + vendorNumber + "/" + uploadfilename;

                        if (!string.IsNullOrWhiteSpace(sDocName))
                        {
                            //var nav = NavConnection.ReturnNav();
                            //string vendorNumberIdentity = vendorNumber;
                            //string status = nav.FnrfiResponsetLinks(vendorNumberIdentity, uploadfilename, sharepointlink); 
                            fileuploadSuccess = true;
                        }
                    }
                }
                catch (Exception)
                {
                    // throw;
                }
            }
            return fileuploadSuccess;
        }
        protected bool _UploadSupplierPrequalificationsDocumentToSharepoint(string prequalificationNumber, HttpPostedFileBase browsedFile, string filedescription)
        {
            bool fileuploadSuccess = false;
            string sUrl = ConfigurationManager.AppSettings["S_URL"];
            string tfilename = browsedFile.FileName;
            string defaultlibraryname = "Procurement%20Documents/";
            string customlibraryname = "Invitation For Prequalification";
            string sharepointLibrary = defaultlibraryname + customlibraryname;
            prequalificationNumber = prequalificationNumber.Replace('/', '_');
            prequalificationNumber = prequalificationNumber.Replace(':', '_');

            if (!string.IsNullOrWhiteSpace(sUrl) && !string.IsNullOrWhiteSpace(sharepointLibrary) && !string.IsNullOrWhiteSpace(tfilename))
            {
                string username = ConfigurationManager.AppSettings["S_USERNAME"];
                string password = ConfigurationManager.AppSettings["S_PWD"];
                string domainname = ConfigurationManager.AppSettings["S_DOMAIN"];
                bool bbConnected = Connect(sUrl, username, password, domainname);
                try
                {
                    if (bbConnected)
                    {
                        Uri uri = new Uri(sUrl);
                        string sSpSiteRelativeUrl = uri.AbsolutePath;
                        string uploadfilename = prequalificationNumber + "_" + browsedFile.FileName;
                        Stream uploadfileContent = browsedFile.InputStream;
                        var sDocName = UploadSupplierPrequalificationFile(uploadfileContent, uploadfilename, sSpSiteRelativeUrl, sharepointLibrary, prequalificationNumber);
                        //SharePoint Link to be added to Navison Card

                        string sharepointlink = sUrl + sharepointLibrary + "/" + prequalificationNumber + "/" + uploadfilename;

                        if (!string.IsNullOrWhiteSpace(sDocName))
                        {
                            //var nav = NavConnection.ReturnNav();
                            //string vendorNumberIdentity = vendorNumber;
                            //string status = nav.FnrfiResponsetLinks(vendorNumberIdentity, uploadfilename, sharepointlink); 
                            fileuploadSuccess = true;
                        }
                    }
                }
                catch (Exception)
                {
                    // throw;
                }
            }
            return fileuploadSuccess;
        }
        protected bool _UploadSupplierTenderDocumentToSharepoint(string prequalificationNumber, string browsedFile, string filedescription)
        {
            FileInfo fi = new FileInfo(browsedFile);
            bool fileuploadSuccess = false;
            string sUrl = ConfigurationManager.AppSettings["S_URL"];
            //string fileName0 = fi.Name;
            string ext0 = fi.Extension;
            string tfilename = fi.Name;
            string defaultlibraryname = "Procurement%20Documents/";
            string customlibraryname = "Tender Bid Reponses";
            string sharepointLibrary = defaultlibraryname + customlibraryname;
            prequalificationNumber = prequalificationNumber.Replace('/', '_');
            prequalificationNumber = prequalificationNumber.Replace(':', '_');

            if (!string.IsNullOrWhiteSpace(sUrl) && !string.IsNullOrWhiteSpace(sharepointLibrary) && !string.IsNullOrWhiteSpace(tfilename))
            {
                string username = ConfigurationManager.AppSettings["S_USERNAME"];
                string password = ConfigurationManager.AppSettings["S_PWD"];
                string domainname = ConfigurationManager.AppSettings["S_DOMAIN"];
                bool bbConnected = Connect(sUrl, username, password, domainname);
                try
                {
                    if (bbConnected)
                    {
                        Uri uri = new Uri(sUrl);
                        string sSpSiteRelativeUrl = uri.AbsolutePath;
                        var vendorNo = Convert.ToString(Session["vendorNo"]);
                        string uploadfilename = vendorNo + "_" + fi.Name;
                        //byte[] doc = Encoding.ASCII.GetBytes(browsedFile);
                        // byte[] byteArray = Convert.FromBase64String(browsedFile);
                        byte[] byteArray = Encoding.ASCII.GetBytes(browsedFile);
                        MemoryStream DocStream = new MemoryStream(byteArray);
                        Stream uploadfileContent = DocStream;
                        var sDocName = UploadSupplierTenderFile(uploadfileContent, uploadfilename, sSpSiteRelativeUrl, sharepointLibrary, prequalificationNumber);

                        //SharePoint Link to be added to Navison Card
                        string sharepointlink = sUrl + sharepointLibrary + "/" + prequalificationNumber + "/" + uploadfilename;

                        if (!string.IsNullOrWhiteSpace(sDocName))
                        {
                            //var nav = NavConnection.ReturnNav();
                            //string vendorNumberIdentity = vendorNumber;
                            //string status = nav.FnrfiResponsetLinks(vendorNumberIdentity, uploadfilename, sharepointlink); 
                            fileuploadSuccess = true;
                        }
                    }
                }
                catch (Exception)
                {
                    // throw;
                }
            }
            return fileuploadSuccess;
        }

        public JsonResult CheckTenderDocumentOnSharepoint(string rfiNumber)
        {
            using (ClientContext ctx = new ClientContext(ConfigurationManager.AppSettings["S_URL"]))
            {
                var vendorNo = Convert.ToString(Session["vendorNo"]);
                string password = ConfigurationManager.AppSettings["S_PWD"];
                string account = ConfigurationManager.AppSettings["S_USERNAME"];
                string domainname = ConfigurationManager.AppSettings["S_DOMAIN"];
                var secret = new SecureString();

                List<SharePointTModel> alldocuments = new List<SharePointTModel>();

                foreach (char c in password)
                {
                    secret.AppendChar(c);
                }
                // context.Credentials = CredentialCache.DefaultNetworkCredentials;
                ctx.Credentials = new NetworkCredential(account, secret, domainname);
                ctx.Load(ctx.Web);
                ctx.ExecuteQuery();
                List list = ctx.Web.Lists.GetByTitle("Procurement%20Documents");

                //Get Unique rfiNumber
                string uniquerfiNumber = rfiNumber;
                uniquerfiNumber = uniquerfiNumber.Replace('/', '_');
                uniquerfiNumber = uniquerfiNumber.Replace(':', '_');

                ctx.Load(list);
                ctx.Load(list.RootFolder);
                ctx.Load(list.RootFolder.Folders);
                ctx.Load(list.RootFolder.Files);
                ctx.ExecuteQuery();
                FolderCollection allFolders = list.RootFolder.Folders;
                foreach (Folder folder in allFolders)
                {
                    if (folder.Name == "Vendor Card")
                    {
                        ctx.Load(folder.Folders);
                        ctx.ExecuteQuery();
                        var uniquerfiNumberFolders = folder.Folders;
                        foreach (Folder rfinumber in uniquerfiNumberFolders)
                        {
                            if (rfinumber.Name == uniquerfiNumber)
                            {
                                ctx.Load(rfinumber.Files);
                                ctx.ExecuteQuery();

                                FileCollection rfinumberFiles = rfinumber.Files;
                                foreach (Microsoft.SharePoint.Client.File file in rfinumberFiles)
                                {
                                    ctx.ExecuteQuery();
                                    alldocuments.Add(new SharePointTModel { FileName = file.Name });

                                }
                            }
                        }
                    }
                }
                return Json(alldocuments, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult PullRfIDocumentsfromSharePoint(string rfiNumber)
        {
            using (ClientContext ctx = new ClientContext(ConfigurationManager.AppSettings["S_URL"]))
            {
                var vendorNo = Convert.ToString(Session["vendorNo"]);
                string password = ConfigurationManager.AppSettings["S_PWD"];
                string account = ConfigurationManager.AppSettings["S_USERNAME"];
                string domainname = ConfigurationManager.AppSettings["S_DOMAIN"];
                var secret = new SecureString();

                List<SharePointTModel> alldocuments = new List<SharePointTModel>();

                foreach (char c in password)
                {
                    secret.AppendChar(c);
                }

                ctx.Credentials = new NetworkCredential(account, secret, domainname);
                ctx.Load(ctx.Web);
                ctx.ExecuteQuery();
                List list = ctx.Web.Lists.GetByTitle("Procurement%20Documents");

                //Get Unique rfiNumber
                string uniquerfiNumber = rfiNumber;
                uniquerfiNumber = uniquerfiNumber.Replace('/', '_');
                uniquerfiNumber = uniquerfiNumber.Replace(':', '_');

                ctx.Load(list);
                ctx.Load(list.RootFolder);
                ctx.Load(list.RootFolder.Folders);
                ctx.Load(list.RootFolder.Files);
                ctx.ExecuteQuery();

                FolderCollection allFolders = list.RootFolder.Folders;
                foreach (Folder folder in allFolders)
                {
                    if (folder.Name == "Procurement%20Documents")
                    {
                        ctx.Load(folder.Folders);
                        ctx.ExecuteQuery();
                        var uniquerfiNumberFolders = folder.Folders;

                        foreach (Folder folders in uniquerfiNumberFolders)
                        {
                            if (folders.Name == "Vendor Card")
                            {
                                ctx.Load(folders.Folders);
                                ctx.ExecuteQuery();
                                var uniqueittpnumberSubFolders = folders.Folders;

                                foreach (Folder rfinumber in uniqueittpnumberSubFolders)
                                {
                                    if (rfinumber.Name == uniquerfiNumber)
                                    {
                                        ctx.Load(rfinumber.Files);
                                        ctx.ExecuteQuery();

                                        FileCollection rfinumberFiles = rfinumber.Files;
                                        foreach (Microsoft.SharePoint.Client.File file in rfinumberFiles)
                                        {
                                            ctx.ExecuteQuery();
                                            alldocuments.Add(new SharePointTModel { FileName = file.Name });

                                        }
                                    }
                                }

                            }
                        }

                    }
                }
                return Json(alldocuments, JsonRequestBehavior.AllowGet);
            }
        }
        public string UploadSupplierPrequalificationFile(Stream fs, string sFileName, string sSpSiteRelativeUrl, string sLibraryName, string vendorNumber)
        {
            string sDocName = string.Empty;
            vendorNumber = vendorNumber.Replace('/', '_');
            vendorNumber = vendorNumber.Replace(':', '_');
            string parent_folderName = "Invitation For Prequalification";
            string subFolderName = vendorNumber;
            //+ "/"+ VendorNumber;
            string filelocation = sLibraryName + "/" + subFolderName;
            try
            {
                // if a folder doesn't exists, create it
                var listTitle = "Procurement Documents";
                if (!FolderExists(SPClientContext.Web, listTitle, parent_folderName + "/" + subFolderName))
                    CreateFolder(SPClientContext.Web, listTitle, parent_folderName + "/" + subFolderName);

                if (SPWeb != null)
                {

                    var sFileUrl = String.Format("{0}/{1}/{2}", sSpSiteRelativeUrl, filelocation, sFileName);
                    Microsoft.SharePoint.Client.File.SaveBinaryDirect(SPClientContext, sFileUrl, fs, true);
                    SPClientContext.ExecuteQuery();
                    sDocName = sFileName;

                }


            }

            catch (Exception ex)
            {
                sDocName = string.Empty;
            }
            return sDocName;
        }

        public string UploadSupplierTenderFile(Stream fs, string sFileName, string sSpSiteRelativeUrl, string sLibraryName, string vendorNumber)
        {
            string sDocName = string.Empty;
            vendorNumber = vendorNumber.Replace('/', '_');
            vendorNumber = vendorNumber.Replace(':', '_');
            string parent_folderName = "Tender Bid Reponses";
            string subFolderName = vendorNumber;
            //+ "/"+ VendorNumber;
            string filelocation = sLibraryName + "/" + subFolderName;
            try
            {
                // if a folder doesn't exists, create it
                var listTitle = "Procurement Documents";
                if (!FolderExists(SPClientContext.Web, listTitle, parent_folderName + "/" + subFolderName))
                    CreateFolder(SPClientContext.Web, listTitle, parent_folderName + "/" + subFolderName);

                if (SPWeb != null)
                {

                    var sFileUrl = String.Format("{0}/{1}/{2}", sSpSiteRelativeUrl, filelocation, sFileName);
                    Microsoft.SharePoint.Client.File.SaveBinaryDirect(SPClientContext, sFileUrl, fs, true);
                    SPClientContext.ExecuteQuery();
                    sDocName = sFileName;

                }


            }

            catch (Exception ex)
            {
                sDocName = string.Empty;
            }
            return sDocName;
        }

        public string UploadSupplierPerfGuaranteeFile(Stream fs, string sFileName, string sSpSiteRelativeUrl, string sLibraryName, string vendorNumber)
        {
            string sDocName = string.Empty;
            vendorNumber = vendorNumber.Replace('/', '_');
            vendorNumber = vendorNumber.Replace(':', '_');
            string parent_folderName = "Performance Guarantee";
            string subFolderName = vendorNumber;
            //+ "/"+ VendorNumber;
            string filelocation = sLibraryName + "/" + subFolderName;
            try
            {
                // if a folder doesn't exists, create it
                var listTitle = "Procurement Documents";
                if (!FolderExists(SPClientContext.Web, listTitle, parent_folderName + "/" + subFolderName))
                    CreateFolder(SPClientContext.Web, listTitle, parent_folderName + "/" + subFolderName);

                if (SPWeb != null)
                {

                    var sFileUrl = String.Format("{0}/{1}/{2}", sSpSiteRelativeUrl, filelocation, sFileName);
                    Microsoft.SharePoint.Client.File.SaveBinaryDirect(SPClientContext, sFileUrl, fs, true);
                    SPClientContext.ExecuteQuery();
                    sDocName = sFileName;

                }


            }

            catch (Exception ex)
            {
                sDocName = string.Empty;
            }
            return sDocName;
        }

        public string UploadSupplierRegFile(Stream fs, string sFileName, string sSpSiteRelativeUrl, string sLibraryName, string vendorNumber)
        {
            string sDocName = string.Empty;
            vendorNumber = vendorNumber.Replace('/', '_');
            vendorNumber = vendorNumber.Replace(':', '_');
            string parent_folderName = "Vendor Card";
            string subFolderName = vendorNumber;
            //+ "/"+ VendorNumber;
            string filelocation = sLibraryName + "/" + subFolderName;
            try
            {
                // if a folder doesn't exists, create it
                var listTitle = "Procurement Documents";
                if (!FolderExists(SPClientContext.Web, listTitle, parent_folderName + "/" + subFolderName))
                    CreateFolder(SPClientContext.Web, listTitle, parent_folderName + "/" + subFolderName);

                if (SPWeb != null)
                {

                    var sFileUrl = String.Format("{0}/{1}/{2}", sSpSiteRelativeUrl, filelocation, sFileName);
                    Microsoft.SharePoint.Client.File.SaveBinaryDirect(SPClientContext, sFileUrl, fs, true);
                    SPClientContext.ExecuteQuery();
                    sDocName = sFileName;

                }


            }

            catch (Exception ex)
            {
                sDocName = string.Empty;
            }
            return sDocName;
        }

        public static bool FolderExists(Web web, string listTitle, string folderUrl)
        {
            var list = web.Lists.GetByTitle(listTitle);
            var folders = list.GetItems(CamlQuery.CreateAllFoldersQuery());
            web.Context.Load(list.RootFolder);
            web.Context.Load(folders);
            web.Context.ExecuteQuery();
            var folderRelativeUrl = string.Format("{0}/{1}", list.RootFolder.ServerRelativeUrl, folderUrl);
            return Enumerable.Any(folders, folderItem => (string)folderItem["FileRef"] == folderRelativeUrl);
        }

        private static void CreateFolder(Web web, string listTitle, string folderName)
        {
            var list = web.Lists.GetByTitle(listTitle);
            var folderCreateInfo = new ListItemCreationInformation
            {
                UnderlyingObjectType = FileSystemObjectType.Folder,
                LeafName = folderName
            };
            var folderItem = list.AddItem(folderCreateInfo);
            folderItem.Update();
            web.Context.ExecuteQuery();
        }
        public bool Connect(string SPURL, string SPUserName, string SPPassWord, string SPDomainName)
        {

            bool bConnected = false;

            try
            {
                ////Sharepoint Onpremise
                SPClientContext = new ClientContext(SPURL);

                SPClientContext.Credentials = new NetworkCredential(SPUserName, SPPassWord, SPDomainName);

                SPClientContext.RequestTimeout = 1000000;

                SPWeb = SPClientContext.Web;

                SPClientContext.Load(SPWeb);

                SPClientContext.ExecuteQuery();

                bConnected = true;


                //Sharepoint Online
                //SPClientContext = new ClientContext(SPURL);
                //SPClientContext.RequestTimeout = 1000000;
                //var passWord = new SecureString();
                //foreach (char c in SPPassWord.ToCharArray()) passWord.AppendChar(c);
                //SPClientContext.Credentials = new SharePointOnlineCredentials(SPUserName, passWord);
                //SPWeb = SPClientContext.Web;
                //SPClientContext.Load(SPWeb);
                //SPClientContext.ExecuteQuery();


                bConnected = true;

            }

            catch (Exception ex)
            {

                bConnected = false;

                SPErrorMsg = ex.Message;
                Response.Write(ex.Message.ToString());

            }

            return bConnected;

        }
        public string UploadFile(Stream fs, string sFileName, string sSpSiteRelativeUrl, string sLibraryName, string rfidocnumber, string vendorNumber)
        {
            string sDocName = string.Empty;
            rfidocnumber = rfidocnumber.Replace('/', '_');
            rfidocnumber = rfidocnumber.Replace(':', '_');

            string parent_folderName = "Vendor Card";
            // string parent_folderName2 = "KeRRA/RFI Response Card/"+ rfidocnumber;

            string subFolderName = rfidocnumber;
            // string subFolderName2 = vendorNumber;

            string filelocation = sLibraryName + "/" + subFolderName;
            try
            {

                // if a folder doesn't exists, create it
                var listTitle = "Procurement Documents";
                if (!FolderExists(SPClientContext.Web, listTitle, parent_folderName + "/" + subFolderName))
                    CreateFolder(SPClientContext.Web, listTitle, parent_folderName + "/" + subFolderName);

                //Creating a folder inside a subfolder
                // if (!FolderExists(WsConfig.SPClientContext.Web, listTitle, parent_folderName2 + "/" + subFolderName2))
                // CreateFolder(WsConfig.SPClientContext.Web, listTitle, parent_folderName2 + "/" + subFolderName2);

                if (SPWeb != null)
                {
                    var sFileUrl = string.Format("{0}/{1}/{2}", sSpSiteRelativeUrl, filelocation, sFileName);
                    Microsoft.SharePoint.Client.File.SaveBinaryDirect(SPClientContext, sFileUrl, fs, true);
                    SPClientContext.ExecuteQuery();
                    sDocName = sFileName;
                }
            }

            catch (Exception ex)
            {
                sDocName = string.Empty;
            }
            return sDocName;
        }

        [HttpGet]

        public ActionResult DownloadRegDocumentsfromSharepoint(string TenderNumber, String filenames)
        {
            var vendorNo = Convert.ToString(Session["vendorNo"]);
        //var sharepointUrl =
        //using (ClientContext ctx = new ClientContext(sharepointUrl))
        //{

        // var secret = new SecureString();
        //foreach (char c in password)
        //{
        //    secret.AppendChar(c);
        //}
        http://ihub/sites/Intranet//ERP DOCUMENTS/Procurement and Sourcing/R48/Invitation To Tender/

            try
            {

                //SharePoint Credentials  
                var sharepointUrl = ConfigurationManager.AppSettings["S_URL"];
                var fileName = filenames;

                String leaveNo = TenderNumber;
                string password = ConfigurationManager.AppSettings["S_PWD"];
                string account = ConfigurationManager.AppSettings["S_USERNAME"];
                string domainname = ConfigurationManager.AppSettings["S_DOMAIN"];
                var filePath = sharepointUrl + "ERP%20DOCUMENTS/Procurement and Sourcing/R48/Invitation To Tender/" + leaveNo + "/" + fileName;

                var secret = new SecureString();
                foreach (char c in password)
                {
                    secret.AppendChar(c);
                }

                var onlineCredentials = new NetworkCredential(account, password, domainname);
                ClientContext clientContext = new ClientContext(filePath);
                var url = string.Format("{0}", filePath);
                WebRequest request = WebRequest.Create(new Uri(url, UriKind.Absolute));
                request.Credentials = onlineCredentials;
                WebResponse response = request.GetResponse();
                Stream fs = response.GetResponseStream() as Stream;
                using (FileStream localfs = System.IO.File.OpenWrite(Server.MapPath("~/Downloads/") + "/" + Path.GetFileName(filePath)))
                {
                    CopyStream(fs, localfs);

                }
                string filename = Path.GetFileName(filePath);
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
                string aaa = Server.MapPath("~/Downloads/" + filename);
                Response.TransmitFile(Server.MapPath("~/Downloads/" + filename));
                Response.End();

                // ScriptManager.RegisterStartupScript(this, this.GetType(), "HidePopup", "$('#downloadFileModal').modal('hide')", true);

            }
            catch (Exception ex)
            {
                // documents.InnerHtml = "<div class='alert alert-danger'>'" + ex.Message + "'<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
            }


            return RedirectToAction("ViewSingleTender", "Home");

        }

        public static void CopyStream(Stream inputStream, Stream outputStream)
        {
            inputStream.CopyTo(outputStream, 4096);
        }



        [HttpPost]
        [AllowAnonymous]
        public ActionResult Download(SharePointTModel documentdetails)
        {
            var sharepointUrl = ConfigurationManager.AppSettings["S_URL"];
            using (ClientContext ctx = new ClientContext(sharepointUrl))
            {
                string password = ConfigurationManager.AppSettings["S_PWD"];
                string account = ConfigurationManager.AppSettings["S_USERNAME"];
                string domainname = ConfigurationManager.AppSettings["S_DOMAIN"];
                var secret = new SecureString();
                foreach (char c in password)
                {
                    secret.AppendChar(c);
                }

                try
                {
                    ctx.Credentials = new NetworkCredential(account, secret, domainname);
                    ctx.Load(ctx.Web);
                    ctx.ExecuteQuery();
                    List list = ctx.Web.Lists.GetByTitle("Procurement Documents");
                    FileCollection files = list.RootFolder.Folders.GetByUrl("/sites/KeRRA/Procurement Documents/Invitation To Tender/" + documentdetails.TenderNumber).Files;
                    ctx.Load(files);
                    ctx.ExecuteQuery();
                    foreach (Microsoft.SharePoint.Client.File file in files)
                    {
                        if (file.Name == documentdetails.FileName)
                        {
                            Response.AppendHeader("Content-Disposition", "attachment; filename=" + documentdetails.FileName);
                            Response.ContentType = "application/pdf";
                            Response.TransmitFile(documentdetails.FileName);
                            Response.End();
                        }
                        else
                        {
                            return Json("danger*", JsonRequestBehavior.AllowGet);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return Json("danger*", JsonRequestBehavior.AllowGet);
                }

            }
            return Json("success*", JsonRequestBehavior.AllowGet);
        }
        public JsonResult TestDownload(SharePointTModel documentdetails)
        {
            try
            {

                String FilePath = @"http://192.168.1.121/sites/Intranet/Procurement%20Documents/Invitation%20To%20Tender/" + documentdetails.TenderNumber + "/" + documentdetails.FileName;
                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.ClearContent();
                response.Clear();
                response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + documentdetails.FileName);
                response.WriteFile(FilePath);
                response.Flush();
                response.End();

            }
            catch (Exception ex)
            {
                return Json("danger*", JsonRequestBehavior.AllowGet);
            }
            return Json("success*", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult DownloadTenderDocumentsfromSharepoint(SharePointTModel documentdetails)
        {
            //var sharepointUrl = ConfigurationManager.AppSettings["S_URL"];
            //using (ClientContext ctx = new ClientContext(sharepointUrl))
            //{
            //    string password = ConfigurationManager.AppSettings["S_PWD"];
            //    string account = ConfigurationManager.AppSettings["S_USERNAME"];
            //    string domainname = ConfigurationManager.AppSettings["S_DOMAIN"];
            //    var secret = new SecureString();
            //    foreach (char c in password)
            //    {
            //        secret.AppendChar(c);
            //    }

            //    try
            //    {
            //        ctx.Credentials = new NetworkCredential(account, secret, domainname);
            //        ctx.Load(ctx.Web);
            //        ctx.ExecuteQuery();
            //        String FilePath= "/sites/KeRRA/Procurement Documents/Invitations To Tender/" + documentdetails.TenderNumber + "/" + documentdetails.FileName;
            //        String FileRlativeUrlPath =Convert.ToString(ctx.Web.GetFileByServerRelativeUrl(FilePath));
            //        System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            //        response.ClearContent();
            //        response.Clear();
            //        response.ContentType = "application/octet-stream";
            //        Response.AppendHeader("Content-Disposition", "attachment; filename=" + documentdetails.FileName);
            //        response.WriteFile(FileRlativeUrlPath);
            //        response.Flush();
            //        response.End();
            //        List list = ctx.Web.Lists.GetByTitle("Procurement Documents");
            //        FileCollection files = list.RootFolder.Folders.GetByUrl("/sites/KeRRA/Procurement Documents/Invitations To Tender/" + documentdetails.TenderNumber).Files;
            //        ctx.Load(files);
            //        ctx.ExecuteQuery();
            //        foreach (Microsoft.SharePoint.Client.File file in files)
            //        {
            //            FileInformation fileinfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(ctx, file.ServerRelativeUrl);
            //            ctx.ExecuteQuery();
            //            using (FileStream filestream = new FileStream("E:/SharepointDemo/" + "\\" + file.Name, FileMode.Create))
            //            {
            //                fileinfo.Stream.CopyTo(filestream);
            //                return Json("success*", JsonRequestBehavior.AllowGet);
            //            }

            //        }
            //    }
            //    catch (Exception ex)
            //    {

            //        return Json("sharepointConnection*", JsonRequestBehavior.AllowGet);
            //    }
            //}
            //return Json("success*", JsonRequestBehavior.AllowGet);
            var vendorNo = Convert.ToString(Session["vendorNo"]);
            var sharepointUrl = ConfigurationManager.AppSettings["S_URL"];
            using (ClientContext ctx = new ClientContext(sharepointUrl))
            {
                string password = ConfigurationManager.AppSettings["S_PWD"];
                string account = ConfigurationManager.AppSettings["S_USERNAME"];
                string domainname = ConfigurationManager.AppSettings["S_DOMAIN"];
                var secret = new SecureString();
                foreach (char c in password)
                {
                    secret.AppendChar(c);
                }

                try
                {
                    ctx.Credentials = new NetworkCredential(account, secret, domainname);
                    ctx.Load(ctx.Web);
                    ctx.ExecuteQuery();
                    string DocumentLink = sharepointUrl + "ERP Documents/" + "Procurement and Sourcing/R48/Invitation To Tender/" + vendorNo + "/" + documentdetails.TenderNumber;



                    DownloadFile(DocumentLink, ctx.Credentials, "E:/SharepointDemo/" + "\\" + documentdetails.TenderNumber);

                }
                catch (Exception ex)
                {

                }
            }

            return View();
        }
        public static bool DownloadFile(string webUrl, ICredentials credentials, string fileRelativeUrl)
        {
            bool downloaded = false;
            using (var client = new WebClient())
            {
                try
                {
                    client.Headers.Add("Accept", "application/pdf");
                    client.Headers.Add("Content-Disposition", "attachment; filename=" + fileRelativeUrl);
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/pdf; charset=utf-8");
                    client.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
                    client.Headers.Add("User-Agent: Other");
                    client.Credentials = credentials;
                    client.DownloadFile(webUrl, fileRelativeUrl);
                    downloaded = true;
                }
                catch (Exception)
                {
                    downloaded = false;
                }
            }
            return downloaded;
        }
        public JsonResult DeleteRegDocfromSharepoint(string filename, int entryNo)
        {
            var vendorNo = Convert.ToString(Session["vendorNo"]);
            var sharepointUrl = ConfigurationManager.AppSettings["S_URL"];
            using (ClientContext ctx = new ClientContext(sharepointUrl))
            {
                string password = ConfigurationManager.AppSettings["S_PWD"];
                string account = ConfigurationManager.AppSettings["S_USERNAME"];
                string domainname = ConfigurationManager.AppSettings["S_DOMAIN"];
                var secret = new SecureString();
                foreach (char c in password)
                {
                    secret.AppendChar(c);
                }
                try
                {
                    ctx.Credentials = new NetworkCredential(account, secret, domainname);
                    ctx.Load(ctx.Web);
                    ctx.ExecuteQuery();

                    Uri uri = new Uri(sharepointUrl);
                    string sSpSiteRelativeUrl = uri.AbsolutePath;
                    string filePath = sSpSiteRelativeUrl + "Procurement Documents/Vendor Card/" + vendorNo + "/" + filename;
                    var file = ctx.Web.GetFileByServerRelativeUrl(filePath);
                    ctx.Load(file, f => f.Exists);
                    file.DeleteObject();
                    ctx.ExecuteQuery();
                    var nav = new NavConnection().ObjNav();
                    var deleteDoc = nav.FnDelDocument(vendorNo, entryNo);

                    if (!file.Exists)
                    {
                        return Json("filenotfound*", JsonRequestBehavior.AllowGet);
                    }
                    return Json("success*", JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
                }
            }
        }

public ActionResult DeleteBidRespDocfromSharepoint(string filename, int entryNo)
    {
        var vendorNo = Convert.ToString(Session["vendorNo"]);
        //string responseNumber = Session["res"].ToString();
        //string tenderNo = Session["tend"].ToString();
        var nav = new NavConnection().ObjNav();
        var deleteDoc = nav.FnDelBidRespDocument(vendorNo, entryNo);
            return Json(deleteDoc, JsonRequestBehavior.AllowGet);
        }


    //var sharepointUrl = ConfigurationManager.AppSettings["S_URL"];
    //using (ClientContext ctx = new ClientContext(sharepointUrl))
    //{
    //    string password = ConfigurationManager.AppSettings["S_PWD"];
    //    string account = ConfigurationManager.AppSettings["S_USERNAME"];
    //    string domainname = ConfigurationManager.AppSettings["S_DOMAIN"];
    //    var secret = new SecureString();
    //    foreach (char c in password)
    //    {
    //        secret.AppendChar(c);
    //    }
    //    try
    //    {
    //        ctx.Credentials = new NetworkCredential(account, secret, domainname);
    //        ctx.Load(ctx.Web);
    //        ctx.ExecuteQuery();

    //        Uri uri = new Uri(sharepointUrl);
    //        string sSpSiteRelativeUrl = uri.AbsolutePath;
    //        string filePath = sSpSiteRelativeUrl + "Procurement Documents/Tender Bid Reponses/" + vendorNo + "/" + filename;
    //        var file = ctx.Web.GetFileByServerRelativeUrl(filePath);
    //        ctx.Load(file, f => f.Exists);
    //        file.DeleteObject();
    //        ctx.ExecuteQuery();
    //        var nav = new NavConnection().ObjNav();
    //        var deleteDoc = nav.FnDelBidRespDocument(vendorNo, entryNo);

    //        if (!file.Exists)
    //        {
    //            return Json("filenotfound*", JsonRequestBehavior.AllowGet);
    //        }
    //        return Json("success*", JsonRequestBehavior.AllowGet);
    //    }
    //    catch (Exception ex)
    //    {
    //        return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
    //    }
    //}
    //}

    public JsonResult DeleteperformancedDocfromSharepoint(string filename, string docNo)
        {
            var vendorNo = Convert.ToString(Session["vendorNo"]);
            var sharepointUrl = ConfigurationManager.AppSettings["S_URL"];
            using (ClientContext ctx = new ClientContext(sharepointUrl))
            {
                string password = ConfigurationManager.AppSettings["S_PWD"];
                string account = ConfigurationManager.AppSettings["S_USERNAME"];
                string domainname = ConfigurationManager.AppSettings["S_DOMAIN"];
                var secret = new SecureString();
                foreach (char c in password)
                {
                    secret.AppendChar(c);
                }
                try
                {
                    ctx.Credentials = new NetworkCredential(account, secret, domainname);
                    ctx.Load(ctx.Web);
                    ctx.ExecuteQuery();

                    Uri uri = new Uri(sharepointUrl);
                    string sSpSiteRelativeUrl = uri.AbsolutePath;
                    string filePath = sSpSiteRelativeUrl + "Procurement Documents/Performance Guarantee/" + docNo + "/" + filename;
                    var file = ctx.Web.GetFileByServerRelativeUrl(filePath);
                    ctx.Load(file, f => f.Exists);
                    file.DeleteObject();
                    ctx.ExecuteQuery();

                    return Json("success*", JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
                }
            }
        }

        private static List<SharePointTModel> PopulateTenderDocumentsfromSpTable(string ittpnumber)
        {
            List<SharePointTModel> alldocuments = new List<SharePointTModel>();
            using (ClientContext ctx = new ClientContext(ConfigurationManager.AppSettings["S_URL"]))
            {
                string password = ConfigurationManager.AppSettings["S_PWD"];
                string account = ConfigurationManager.AppSettings["S_USERNAME"];
                string domainname = ConfigurationManager.AppSettings["S_DOMAIN"];
                var secret = new SecureString();

                var arraydocs = new List<string>();

                foreach (char c in password)
                {
                    secret.AppendChar(c);
                }
                ctx.Credentials = new NetworkCredential(account, secret, domainname);
                ctx.Load(ctx.Web);
                ctx.ExecuteQuery();
                List list = ctx.Web.Lists.GetByTitle("ERP Documents");
                //Get Unique IttNumber
                string uniqueittpnumber = ittpnumber;
                uniqueittpnumber = uniqueittpnumber.Replace('/', '_');
                uniqueittpnumber = uniqueittpnumber.Replace(':', '_');

                ctx.Load(list);
                ctx.Load(list.RootFolder);
                ctx.Load(list.RootFolder.Folders);
                ctx.Load(list.RootFolder.Files);
                ctx.ExecuteQuery();

                FolderCollection allFolders = list.RootFolder.Folders;
                List<string> allFiles = new List<string>();
                foreach (Folder folder in allFolders)
                {
                    if (folder.Name == "Procurement and Sourcing")
                    {

                        ctx.Load(folder.Folders);
                        ctx.ExecuteQuery();
                        FolderCollection innerFolders = folder.Folders;
                        foreach (Folder folder1 in innerFolders)
                        {

                            if (folder1.Name == "R48")
                            {
                                ctx.Load(folder1.Folders);
                                ctx.ExecuteQuery();
                                FolderCollection inner2Folders = folder1.Folders;
                                foreach (Folder folder2 in inner2Folders)
                                {
                                    if (folder2.Name == "Invitation To Tender")
                                    {
                                        ctx.Load(folder2.Folders);
                                        ctx.ExecuteQuery();
                                        var uniqueittpnumberFolders = folder2.Folders;
                                        foreach (Folder noticefolder in uniqueittpnumberFolders)
                                        {
                                            if (noticefolder.Name == uniqueittpnumber)
                                            {
                                                ctx.Load(noticefolder.Files);
                                                ctx.ExecuteQuery();
                                                FileCollection ittnumberFiles = noticefolder.Files;
                                                foreach (Microsoft.SharePoint.Client.File file in ittnumberFiles)
                                                {
                                                    ctx.ExecuteQuery();
                                                    alldocuments.Add(new SharePointTModel { FileName = file.Name });

                                                }
                                            }
                                        }
                                    }
                                }
                            }

                        }


                        //var uniqueittpnumberFolders = folder.Folders;
                        //foreach (Folder noticefolder in uniqueittpnumberFolders)
                        //{
                        //    if (noticefolder.Name == uniqueittpnumber)
                        //    {
                        //        ctx.Load(noticefolder.Files);
                        //        ctx.ExecuteQuery();
                        //        FileCollection ittnumberFiles = noticefolder.Files;
                        //        foreach (Microsoft.SharePoint.Client.File file in ittnumberFiles)
                        //        {
                        //            ctx.ExecuteQuery();
                        //            alldocuments.Add(new SharePointTModel { FileName = file.Name });

                        //        }
                        //    }
                        //}

                    }
                }
                return alldocuments;
            }
        }
        private static List<IfsDocumentTModel> PopulatePerformanceDocumentsfromSpTable(string ittpnumber)
        {
            List<IfsDocumentTModel> list = new List<IfsDocumentTModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetContractRequirements(ittpnumber);
                String[] info = query.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[9] != "")
                        {
                            IfsDocumentTModel document = new IfsDocumentTModel();
                            document.Document_No = arr[0];
                            document.Procurement_Document_Type_ID = Convert.ToString(arr[1]);
                            document.Description = arr[2];
                            document.Track_Certificate_Expiry = Convert.ToString(arr[3]);
                            document.prnNo = arr[4];
                            document.ifsNo = arr[5];
                            document.processArea = arr[6];
                            document.instructions = arr[7];
                            if (document.Track_Certificate_Expiry == "True")
                            {

                                document.Track_Certificate_Expiry = "Yes";
                            }
                            else
                            {
                                document.Track_Certificate_Expiry = "No";
                            }
                            document.Requirement_Type = arr[8];
                            document.filelink = arr[9];

                            list.Add(document);
                        }

                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return list;

            //List<SharePointTModel> alldocuments = new List<SharePointTModel>();
            //using (ClientContext ctx = new ClientContext(ConfigurationManager.AppSettings["S_URL"]))
            //{
            //    string password = ConfigurationManager.AppSettings["S_PWD"];
            //    string account = ConfigurationManager.AppSettings["S_USERNAME"];
            //    string domainname = ConfigurationManager.AppSettings["S_DOMAIN"];
            //    var secret = new SecureString();

            //    var arraydocs = new List<string>();

            //    foreach (char c in password)
            //    {
            //        secret.AppendChar(c);
            //    }
            //    ctx.Credentials = new NetworkCredential(account, secret, domainname);
            //    ctx.Load(ctx.Web);
            //    ctx.ExecuteQuery();
            //    List list = ctx.Web.Lists.GetByTitle("Procurement Documents");
            //    //Get Unique IttNumber
            //    if (!string.IsNullOrEmpty(ittpnumber))
            //    {
            //        string uniqueittpnumber = ittpnumber;
            //        uniqueittpnumber = uniqueittpnumber.Replace('/', '_');
            //        uniqueittpnumber = uniqueittpnumber.Replace(':', '_');

            //        ctx.Load(list);
            //        ctx.Load(list.RootFolder);
            //        ctx.Load(list.RootFolder.Folders);
            //        ctx.Load(list.RootFolder.Files);
            //        ctx.ExecuteQuery();


            //        FolderCollection allFolders = list.RootFolder.Folders;
            //        List<string> allFiles = new List<string>();
            //        foreach (Folder folder in allFolders)
            //        {
            //            if (folder.Name == "Performance Guarantee")
            //            {

            //                ctx.Load(folder.Folders);
            //                ctx.ExecuteQuery();
            //                FolderCollection innerFolders = folder.Folders;
            //                foreach (Folder folder1 in innerFolders)
            //                {

            //                    if (folder1.Name == uniqueittpnumber)
            //                    {
            //                        ctx.Load(folder1.Files);
            //                        ctx.ExecuteQuery();
            //                        FileCollection ittnumberFiles = folder1.Files;
            //                        foreach (Microsoft.SharePoint.Client.File file in ittnumberFiles)
            //                        {
            //                            ctx.ExecuteQuery();
            //                            alldocuments.Add(new SharePointTModel { FileName = file.Name });

            //                        }
            //                    }
            //                }




            //            }

            //        }
            //    }
            //}
            //    return alldocuments;

        }
        //private static List<DocumentsTModel> AttachedPrequalificationDocuments(string prequalificationNo)
        //{
        //    List<DocumentsTModel> list = new List<DocumentsTModel>();
        //    try
        //    {
        //        var nav = new NavConnection().queries();
        //        var query = nav.fnGetBidResponseAttachedDocuments(prequalificationNo);
        //        String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
        //        if (info != null)
        //        {
        //            for (int i = 0; i < info.Length; i++)
        //            {
        //                String[] arr = info[i].Split('*');
        //                DocumentsTModel documents = new DocumentsTModel();
        //                documents.Procurement_Document_Type_ID = arr[0];
        //                documents.Description = arr[3];
        //                documents.category = Convert.ToString(arr[4]);
        //                list.Add(documents);
        //            }
        //        }

        //    }
        //    catch (Exception e)
        //    {

        //        throw;
        //    }
        //    return list;
        //}
        
        private static List<SharePointTModel> PopulateSupplierRegistrationDocuments(string ittpnumber)
        {
            List<SharePointTModel> alldocuments = new List<SharePointTModel>();
            using (ClientContext ctx = new ClientContext(ConfigurationManager.AppSettings["S_URL"]))
            {
                string password = ConfigurationManager.AppSettings["S_PWD"];
                string account = ConfigurationManager.AppSettings["S_USERNAME"];
                string domainname = ConfigurationManager.AppSettings["S_DOMAIN"];
                var secret = new SecureString();

                var arraydocs = new List<string>();

                foreach (char c in password)
                {
                    secret.AppendChar(c);
                }
                ctx.Credentials = new NetworkCredential(account, secret, domainname);
                ctx.Load(ctx.Web);
                ctx.ExecuteQuery();
                List list = ctx.Web.Lists.GetByTitle("Procurement Documents");
                //Get Unique IttNumber
                string uniqueittpnumber = ittpnumber;
                uniqueittpnumber = uniqueittpnumber.Replace('/', '_');
                uniqueittpnumber = uniqueittpnumber.Replace(':', '_');

                ctx.Load(list);
                ctx.Load(list.RootFolder);
                ctx.Load(list.RootFolder.Folders);
                ctx.Load(list.RootFolder.Files);
                ctx.ExecuteQuery();

                FolderCollection allFolders = list.RootFolder.Folders;
                List<string> allFiles = new List<string>();
                foreach (Folder folder in allFolders)
                {
                    if (folder.Name == "Vendor Card")
                    {
                        ctx.Load(folder.Folders);
                        ctx.ExecuteQuery();
                        var uniqueittpnumberFolders = folder.Folders;
                        foreach (Folder noticefolder in uniqueittpnumberFolders)
                        {
                            if (noticefolder.Name == uniqueittpnumber)
                            {
                                ctx.Load(noticefolder.Files);
                                ctx.ExecuteQuery();
                                FileCollection ittnumberFiles = noticefolder.Files;
                                foreach (Microsoft.SharePoint.Client.File file in ittnumberFiles)
                                {
                                    ctx.ExecuteQuery();
                                    alldocuments.Add(new SharePointTModel { FileName = file.Name });

                                }
                            }
                        }

                    }
                }
                return alldocuments;
            }
        }
        private static List<SharePointTModel> PopulatePrequalificationDocuments(string ittpnumber)
        {
            List<SharePointTModel> alldocuments = new List<SharePointTModel>();
            using (ClientContext ctx = new ClientContext(ConfigurationManager.AppSettings["S_URL"]))
            {
                string password = ConfigurationManager.AppSettings["S_PWD"];
                string account = ConfigurationManager.AppSettings["S_USERNAME"];
                string domainname = ConfigurationManager.AppSettings["S_DOMAIN"];
                var secret = new SecureString();

                var arraydocs = new List<string>();

                foreach (char c in password)
                {
                    secret.AppendChar(c);
                }
                ctx.Credentials = new NetworkCredential(account, secret, domainname);
                ctx.Load(ctx.Web);
                ctx.ExecuteQuery();
                List list = ctx.Web.Lists.GetByTitle("Procurement Documents");
                //Get Unique IttNumber
                string uniqueittpnumber = ittpnumber;
                uniqueittpnumber = uniqueittpnumber.Replace('/', '_');
                uniqueittpnumber = uniqueittpnumber.Replace(':', '_');

                ctx.Load(list);
                ctx.Load(list.RootFolder);
                ctx.Load(list.RootFolder.Folders);
                ctx.Load(list.RootFolder.Files);
                ctx.ExecuteQuery();

                FolderCollection allFolders = list.RootFolder.Folders;
                List<string> allFiles = new List<string>();
                foreach (Folder folder in allFolders)
                {
                    if (folder.Name == "Invitation For Prequalification")
                    {
                        ctx.Load(folder.Folders);
                        ctx.ExecuteQuery();
                        var uniqueittpnumberFolders = folder.Folders;
                        foreach (Folder noticefolder in uniqueittpnumberFolders)
                        {
                            if (noticefolder.Name == uniqueittpnumber)
                            {
                                ctx.Load(noticefolder.Files);
                                ctx.ExecuteQuery();
                                FileCollection ittnumberFiles = noticefolder.Files;
                                foreach (Microsoft.SharePoint.Client.File file in ittnumberFiles)
                                {
                                    ctx.ExecuteQuery();
                                    alldocuments.Add(new SharePointTModel { FileName = file.Name });

                                }
                            }
                        }

                    }
                }
                return alldocuments;
            }
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var nav = new NavConnection().queries();
                    var user = nav.fnGetPortalUser(model.Email, model.Password);
                    string[] userDetails = user.Split('*');
                    if (userDetails[0] == "success")
                    {
                        string fname = userDetails[1];
                        string username = userDetails[2];
                        string phoneNumber = userDetails[3];
                        Session["prequalified"] = userDetails[4];
                        Session["email"] = model.Email;
                        Session["name"] = fname;
                        Session["userNo"] = userDetails[6];
                        Session["vendorNo"] = userDetails[6];
                        Session["username"] = username;
                        Session["fullname"] = fname;
                        Session["PhoneNumber"]= phoneNumber;
                        // //check if the contact is registered in the vendor table
                        var query1 = nav.fnGetVendor(userDetails[6]);
                        String[] info = query1.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                        if (info != null)
                        {
                            for (int i = 0; i < info.Length; i++)
                            {
                                String[] arr = info[i].Split('*');
                                // && Convert.ToBoolean(userDetails[7]) == true
                                if ((userDetails[4]) == "Enabled")
                                {

                                    Session["vendorName"] = userDetails[1];
                                    Session["userNo"] = userDetails[6];
                                    Session["vatNumber"] = arr[33];

                                    if (arr[37] == "Yes")
                                    {

                                        return RedirectToAction("Dashboard", "Home");
                                    }
                                    else if (arr[37] == "No")
                                    {
                                        return RedirectToAction("SupplierRegistration", "Home");
                                    }


                                }
                                if (userDetails[4] != "Enabled")
                                {
                                    TempData["error"] = "Your account is deactivated";

                                }
                                else
                                {
                                    return RedirectToAction("ChangePassword", "Home");
                                }


                            }


                        }

                    }


                    else
                    {
                        TempData["error"] = "The Email Address or Password provided is incorrect. Kindly try Again with the Correct Credentials";
                    }

                }
            }

            catch (Exception ex)
            {
                TempData["error"] = ex.Message;

            }
            return View(model);
        }


        public JsonResult SubmitRegistrationDetails()
        {
            try
            {
                var vendorNo = Convert.ToString(Session["vendorNo"]);
                var nav = new NavConnection().ObjNav();
                var status = nav.fnCompleteSupplierReg(vendorNo);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*", JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json("danger", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Checkout()
        {
            Session.RemoveAll();
            Session.Clear();
            Session.Abandon();
            Response.AppendHeader("Cache-Control", "no-store");
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult SearchData(string tenderNumber, string tenderName, string closingDate)
        {
            if (Session["vendorNo"] != null)
            {
                ViewBag.TenderNumber = tenderNumber;
                ViewBag.TenderName = tenderName;
                ViewBag.ClosingDate = closingDate;
                TempData["search"] = tenderNumber;
                dynamic model = new ExpandoObject();
                string nn = TempData["search"].ToString();
                model.activ = GetActiveTenderDetailFilter();
                TempData["data"] = model;
                
                return RedirectToAction("Dashboard");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        [HandleError]
        public ActionResult ClosedRFQs()
        {
            if (Session["vendorNo"] == null)
            {
                RedirectToAction("Login", "Home");
            }

            List<ActiveRfqModel> list = new List<ActiveRfqModel>();
            try
            {
                var nav = new NavConnection().queries();
                string vendorNo = Session["vendorNo"].ToString();
                var today = DateTime.Today;
                var result = nav.fnGetInvitationForRFQ(vendorNo);
                String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        string[] arr = info[i].Split('*');

                        if (arr[0] != "" && DateTime.Parse(arr[0]) >= today && arr[12] == "RFQ" && arr[14] =="Closed")
                        {
                            ActiveRfqModel tender = new ActiveRfqModel();
                            tender.Code = arr[6];
                            tender.Procurement_Method = arr[12];
                            tender.Solicitation_Type = arr[1];
                            tender.External_Document_No = arr[2];
                            tender.Procurement_Type = arr[11];
                            tender.Procurement_Category_ID = arr[3];
                            tender.Project_ID = arr[4];
                            tender.Tender_Name = arr[5];
                            tender.Tender_Summary = arr[7];
                            tender.Description = arr[8];
                            if (arr[13] != "")
                            {
                                tender.Document_Date = DateTime.Parse(arr[13]);

                            }
                            if (arr[10] != "")
                            {
                                tender.Submission_Start_Date = DateTime.Parse(arr[10]);

                            }
                            tender.Status = arr[9];
                            tender.Name = arr[5];
                            tender.Submission_End_Date = DateTime.Parse(arr[0]);
                            tender.Published = true;
                            list.Add(tender);
                        }

                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View(list);
        }

        [HandleError]
        public ActionResult AwardedQuotations()
        {
            if (Session["vendorNo"] == null)
            {
                RedirectToAction("Login", "Home");
            }

            List<ActiveRfqModel> list = new List<ActiveRfqModel>();
            try
            {
                var nav = new NavConnection().queries();
                string vendorNo = Session["vendorNo"].ToString();
                var today = DateTime.Today;
                var result = nav.fnGetInvitationForRFQ(vendorNo);

                String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        string[] arr = info[i].Split('*');

                        if (arr[0] != "" && DateTime.Parse(arr[0]) >= today && arr[12] == "RFQ" && arr[14] == "Published")
                        {
                            ActiveRfqModel tender = new ActiveRfqModel();
                            tender.Code = arr[6];
                            tender.Procurement_Method = arr[12];
                            tender.Solicitation_Type = arr[1];
                            tender.External_Document_No = arr[2];
                            tender.Procurement_Type = arr[11];
                            tender.Procurement_Category_ID = arr[3];
                            tender.Project_ID = arr[4];
                            tender.Tender_Name = arr[5];
                            tender.Tender_Summary = arr[7];
                            tender.Description = arr[8];
                            if (arr[13] != "")
                            {
                                tender.Document_Date = DateTime.Parse(arr[13]);

                            }
                            if (arr[10] != "")
                            {
                                tender.Submission_Start_Date = DateTime.Parse(arr[10]);


                            }
                            tender.Status = arr[9];
                            tender.Name = arr[5];
                            tender.Submission_End_Date = DateTime.Parse(arr[0]);
                            tender.Published = true;
                            list.Add(tender);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View(list);
        }
       

        public ActionResult DownloadDocuments(string filename,string link)
        {


            string filePath = link;
            string[] info = filename.Split('_');
            string actualFilename = info[1];

            if (System.IO.File.Exists(filePath))
            {
                return File(filePath, MimeMapping.GetMimeMapping(filePath), actualFilename);
            }
            else
            {
                return HttpNotFound();
            }
        }


    }

}