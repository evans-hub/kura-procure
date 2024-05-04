using E_Procurement.Models;
using E_Procurement.Models.Contractor;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace E_Procurement.Controllers
{
    public class ContractorController : Controller
    {
        // GET: Contractor
        public ActionResult HomePage()
        {

            List<ProjectTasksModel> list = new List<ProjectTasksModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetJobTasks();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if(info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        ProjectTasksModel projecttask = new ProjectTasksModel();
                        projecttask.Job_No = arr[0];
                        projecttask.Description = arr[1];
                        projecttask.Department_Code = arr[2];
                        projecttask.Directorate_Code = arr[3];
                        projecttask.Division = arr[4];
                        projecttask.Commitments = Convert.ToString(arr[5]);
                        projecttask.Start_Point_Km = Convert.ToString(arr[6]);
                        projecttask.End_Point_Km = Convert.ToString(arr[7]);
                        projecttask.Start_Date = Convert.ToString(arr[8]);
                        projecttask.End_Date = Convert.ToString(arr[9]);
                        projecttask.Funding_Source = arr[11];
                        projecttask.Procurement_Method = arr[10];
                        projecttask.Surface_Types = arr[12];
                        projecttask.Road_Condition = arr[13];
                        projecttask.Completed_Length_Km = Convert.ToString(arr[14]);
                        projecttask.Roads_Category = arr[15];
                        projecttask.Fund_Type = arr[16];
                        projecttask.Execution_Method = arr[17];
                        projecttask.Region = arr[18];
                        projecttask.Constituency = arr[20];
                      
                        list.Add(projecttask);
                    }
                }
               
            }
            catch (Exception e)
            {

                throw;
            }
            return View(list);
        }
        public ActionResult CompletedContracts()
        {
            List<ContractsModel> list = new List<ContractsModel>();
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().queries();
                var query = nav.fnGetPurchaseHeader("Blanket Order", vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if(info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[34] == "Signed" && arr[17]== "Blanket Order")
                        {
                            ContractsModel contract = new ContractsModel();
                            contract.Document_Type = "Blanket Order";
                            contract.Buy_from_Vendor_No = arr[22];
                            contract.No = arr[0];
                            contract.Pay_to_Name = arr[1];
                            contract.Pay_to_Vendor_No = vendorNo;
                            contract.Pay_to_Name_2 = arr[23];
                            contract.Pay_to_Address = arr[24];
                            contract.Pay_to_Address_2 =arr[25];
                            contract.Pay_to_Contact = arr[26];
                            contract.Your_Reference = arr[27];
                            contract.Order_Date = Convert.ToString(arr[28]);
                            contract.Posting_Date = Convert.ToString(arr[29]);
                            contract.Location_Code = arr[30];
                            contract.Region_Code = arr[4];
                            contract.Link_Name = arr[31];
                            contract.Works_Length = Convert.ToString(arr[32]);
                            contract.Invatition_for_supply = arr[13];
                            contract.Tender_Description = arr[19];
                            contract.Contract_Description = arr[6];
                            contract.Contract_End_Date = Convert.ToString(arr[10]);
                            contract.Contract_Start_Date = Convert.ToString(arr[9]);
                            contract.Contract_Value = Convert.ToString(arr[33]);
                            list.Add(contract);

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
        public ActionResult ProjectsPendingMinutes()
        {
            List<ActiveContracts> list = new List<ActiveContracts>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetInviteTender("");
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if(info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        ActiveContracts tender = new ActiveContracts();
                        tender.Code =arr[0];
                        tender.Procurement_Method = arr[14];
                        tender.Solicitation_Type = arr[1];
                        tender.External_Document_No = arr[2];
                        tender.Procurement_Type = arr[3];
                        tender.Procurement_Category_ID =arr[4];
                        tender.Project_ID = arr[5];
                        tender.Tender_Name = arr[6];
                        tender.Tender_Summary =arr[7];
                        tender.Description = arr[8];
                        tender.Document_Date =DateTime.Parse(arr[9]);
                        tender.Status = arr[10];
                        tender.Name = arr[11];
                        tender.Submission_End_Date = DateTime.Parse(arr[12]);
                        tender.Submission_Start_Date = DateTime.Parse(arr[13]);
                        tender.Published = true;
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
        public ActionResult UpcomingMeetingsAppointments()
        {
            List<ActiveContracts> list = new List<ActiveContracts>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetInviteTender("");
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[6] != "")
                        {
                            ActiveContracts tender = new ActiveContracts();
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
                            tender.Document_Date =DateTime.Parse(arr[9]);
                            tender.Status = arr[10];
                            tender.Name = arr[11];
                            tender.Submission_End_Date = DateTime.Parse(arr[12]);
                            tender.Submission_Start_Date =DateTime.Parse(arr[13]);
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
        public ActionResult ActiveContracts()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.VendorActiveContracts = GetActiveContracts(vendorNo);
                model.CancelledContracts = GetCancelledActiveContracts(vendorNo);
                model.Vendors = GetVendors(vendorNo);
                return View(model);
            }
        }
        public ActionResult HealthandSafetyMeetings()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.VendorActiveContracts = GetActiveContracts(vendorNo);
                model.CancelledContracts = GetCancelledActiveContracts(vendorNo);
                model.Vendors = GetVendors(vendorNo);
                return View(model);
            }
        }
        public ActionResult AccidentandIncidents()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.VendorActiveContracts = GetActiveContracts(vendorNo);
                model.CancelledContracts = GetCancelledActiveContracts(vendorNo);
                model.Vendors = GetVendors(vendorNo);
                return View(model);
            }
        }
        public ActionResult EmergencyDrillLog()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.VendorActiveContracts = GetActiveContracts(vendorNo);
                model.CancelledContracts = GetCancelledActiveContracts(vendorNo);
                model.Vendors = GetVendors(vendorNo);
                return View(model);
            }
        }
        public ActionResult InductionBriefingLogs()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.VendorActiveContracts = GetActiveContracts(vendorNo);
                model.CancelledContracts = GetCancelledActiveContracts(vendorNo);
                model.Vendors = GetVendors(vendorNo);
                return View(model);
            }
        }
        public ActionResult WorkSiteInspections()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.VendorActiveContracts = GetActiveContracts(vendorNo);
                model.CancelledContracts = GetCancelledActiveContracts(vendorNo);
                model.Vendors = GetVendors(vendorNo);
                return View(model);
            }
        }
        public ActionResult WorkPermitsApplication()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.VendorActiveContracts = GetActiveContracts(vendorNo);
                model.CancelledContracts = GetCancelledActiveContracts(vendorNo);
                model.Vendors = GetVendors(vendorNo);
                return View(model);
            }
        }
        private static List<ContractsModel> GetActiveContracts(string vendorNo)
        {
                List<ContractsModel> list = new List<ContractsModel>();
                try
                {
                    var nav = new NavConnection().queries();
                var query = nav.fnGetPurchaseHeader("Blanket Order", vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[34] == "Signed" && arr[17] == "Blanket Order")
                        {
                            ContractsModel contract = new ContractsModel();
                            contract.Document_Type = "Blanket Order";
                            contract.Buy_from_Vendor_No = arr[22];
                            contract.No = arr[0];
                            contract.Pay_to_Name = arr[1];
                            contract.Pay_to_Vendor_No = vendorNo;
                            contract.Pay_to_Name_2 = arr[23];
                            contract.Pay_to_Address = arr[24];
                            contract.Pay_to_Address_2 = arr[25];
                            contract.Pay_to_Contact = arr[26];
                            contract.Your_Reference = arr[27];
                            contract.Order_Date = Convert.ToString(arr[28]);
                            contract.Posting_Date = Convert.ToString(arr[29]);
                            contract.Location_Code = arr[30];
                            contract.Region_Code = arr[4];
                            contract.Link_Name = arr[31];
                            contract.Works_Length = Convert.ToString(arr[32]);
                            contract.Invatition_for_supply = arr[13];
                            contract.Tender_Description = arr[19];
                            contract.Contract_Description = arr[6];
                            contract.Contract_End_Date = Convert.ToString(arr[10]);
                            contract.Contract_Start_Date = Convert.ToString(arr[9]);
                            contract.Contract_Value = Convert.ToString(arr[33]);
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
        private static List<ContractsModel> GetCancelledActiveContracts(string vendorNo)
        {
            List<ContractsModel> list = new List<ContractsModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetPurchaseHeader("Blanket Order", vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[34] == "Cancelled" && arr[17] == "Blanket Order")
                        {
                            ContractsModel contract = new ContractsModel();
                            contract.Document_Type = "Blanket Order";
                            contract.Buy_from_Vendor_No = arr[22];
                            contract.No = arr[0];
                            contract.Pay_to_Name = arr[1];
                            contract.Pay_to_Vendor_No = vendorNo;
                            contract.Pay_to_Name_2 = arr[23];
                            contract.Pay_to_Address = arr[24];
                            contract.Pay_to_Address_2 = arr[25];
                            contract.Pay_to_Contact = arr[26];
                            contract.Your_Reference = arr[27];
                            contract.Order_Date = Convert.ToString(arr[28]);
                            contract.Posting_Date = Convert.ToString(arr[29]);
                            contract.Location_Code = arr[30];
                            contract.Region_Code = arr[4];
                            contract.Link_Name = arr[31];
                            contract.Works_Length = Convert.ToString(arr[32]);
                            contract.Invatition_for_supply = arr[13];
                            contract.Tender_Description = arr[19];
                            contract.Contract_Description = arr[6];
                            contract.Contract_End_Date = Convert.ToString(arr[10]);
                            contract.Contract_Start_Date = Convert.ToString(arr[9]);
                            contract.Contract_Value = Convert.ToString(arr[33]);
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
        public ActionResult NewMeasurementsSheets()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.Response = GetVendors(vendorNo);
              

                return View(model);
            }
        }
        public JsonResult GetWEPKeyProfessionalStaff(string ExecutionPlanNumber)
        {

            List<WEPContractorTeamModel> list = new List<WEPContractorTeamModel>();
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().queries();
                var query = nav.fnGetWEPContractorTeam(ExecutionPlanNumber, vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        WEPContractorTeamModel order = new WEPContractorTeamModel();
                        order.Document_No = ExecutionPlanNumber;
                        order.Contractor_No = Convert.ToString(vendorNo);
                        order.Name = arr[0];
                        order.Address = arr[1];
                        order.Address_2 = arr[2];
                        order.City = arr[3];
                        order.Post_Code = arr[4];
                        order.Country_Region_Code = arr[5];
                        order.Role_Code =arr[6];
                        order.Designation = arr[7];
                        order.Effective_Date = Convert.ToString(arr[8]);
                        order.Expiry_Date = Convert.ToString(arr[9]);
                        order.Staff_Category = arr[10];
                        order.Contractor_Staff_No = arr[11];
                        list.Add(order);
                    }
                }
               
            }
            catch (Exception e)
            {

                throw;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetWEPEquipmentsRegisterDetails(string ExecutionPlanNumber)
        {

            List<WEPContractorEquipment> list = new List<WEPContractorEquipment>();
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().queries();
                var query = nav.fnGetWEPContractorEqquipment(ExecutionPlanNumber, vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if(info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        WEPContractorEquipment project = new WEPContractorEquipment();
                        project.Document_No = ExecutionPlanNumber;
                        project.Document_Type = arr[0];
                        project.Contractor_No = Convert.ToString(vendorNo);
                        project.Equipment_No = Convert.ToString(arr[8]);
                        project.Equipment_Type_Code = Convert.ToString(arr[1]);
                        project.Description = arr[2];
                        project.Ownership_Type = Convert.ToString(arr[3]);
                        project.Equipment_Serial_No = arr[4];
                        project.Equipment_Usability_Code =arr[5];
                        project.Years_of_Previous_Use = Convert.ToString(arr[6]);
                        project.Equipment_Condition_Code = arr[7];
                        list.Add(project);

                    }
                }
               

            }
            catch (Exception e)
            {

                throw;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetWEPProjectScheduleDetails(string ExecutionPlanNumber)
        {

            List<WEPExecutionLinesModel> list = new List<WEPExecutionLinesModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetWEPExecutionSchedule(ExecutionPlanNumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if(info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        WEPExecutionLinesModel project = new WEPExecutionLinesModel();
                        project.Document_No = arr[0];
                        project.Job_No = arr[1];
                        project.Job_Task_No = Convert.ToString(arr[7]);
                        project.Scheduled_End_Date = Convert.ToString(arr[2]);
                        project.Scheduled_Start_Date = Convert.ToString(arr[3]);
                        project.Description = arr[4];
                        project.Budget_Total_Cost = Convert.ToString(arr[5]);
                        project.Job_Task_Type = arr[6];
                        list.Add(project);

                    }
                }
              

            }
            catch (Exception e)
            {

                throw;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ApprovedDailyWorkRecords()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                List<ActiveContracts> list = new List<ActiveContracts>();
                try
                {
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetInviteTender("");
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            if (arr[6] != "")
                            {
                                ActiveContracts tender = new ActiveContracts();
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
                                tender.Document_Date = DateTime.Parse(arr[9]);
                                tender.Status = arr[10];
                                tender.Name = arr[11];
                                tender.Submission_End_Date = DateTime.Parse(arr[12]);
                                tender.Submission_Start_Date = DateTime.Parse(arr[13]);
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
        public ActionResult PendingEngineerDailyWorks()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                List<ActiveContracts> list = new List<ActiveContracts>();
                try
                {
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetInviteTender("");
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            if (arr[6] != "")
                            {
                                ActiveContracts tender = new ActiveContracts();
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
                                tender.Document_Date =DateTime.Parse(arr[9]);
                                tender.Status = arr[10];
                                tender.Name = arr[11];
                                tender.Submission_End_Date = DateTime.Parse(arr[12]);
                                tender.Submission_Start_Date = DateTime.Parse(arr[13]);
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
        public ActionResult DraftDailyWorksRecords()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                List<ActiveContracts> list = new List<ActiveContracts>();
                try
                {
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetInviteTender("");
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            if (arr[6] != "")
                            {
                                ActiveContracts tender = new ActiveContracts();
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
                                tender.Document_Date = DateTime.Parse(arr[9]);
                                tender.Status = arr[10];
                                tender.Name = arr[11];
                                tender.Submission_End_Date = DateTime.Parse(arr[12]);
                                tender.Submission_Start_Date = DateTime.Parse(arr[13]);
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
        public ActionResult ApprovedExecutionsPlans()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                List<WorkExecutionPlanModel> list = new List<WorkExecutionPlanModel>();
                try
                {
                    var vendorNo = Session["vendorNo"].ToString();
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetProjectMobilizationHeader(vendorNo, "Released");
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if(info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            WorkExecutionPlanModel roadwork = new WorkExecutionPlanModel();
                            roadwork.Document_No = arr[0];
                            roadwork.Commencement_Order_ID = arr[1];
                            roadwork.Description = arr[2];
                            roadwork.Project_ID = arr[3];
                            roadwork.Region_ID = arr[4];
                            roadwork.Document_Date = Convert.ToString(arr[5]);
                            roadwork.Purchase_Contract_ID = arr[6];
                            roadwork.Contractor_Name = arr[7];
                            roadwork.Project_Name =arr[8];
                            roadwork.Road_Code = Convert.ToString(arr[9]);
                            roadwork.Road_Section_No = Convert.ToString(arr[10]);                          
                            roadwork.Project_Start_Date = Convert.ToString(arr[11]);
                            roadwork.Project_End_Date = Convert.ToString(arr[12]);
                            roadwork.Status = Convert.ToString(arr[13]);
                            list.Add(roadwork);
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
        public ActionResult PendingExecutionsPlans()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                List<WorkExecutionPlanModel> list = new List<WorkExecutionPlanModel>();
                try
                {
                    var vendorNo = Session["vendorNo"].ToString();
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetProjectMobilizationHeader(vendorNo, "Released");
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            WorkExecutionPlanModel roadwork = new WorkExecutionPlanModel();
                            roadwork.Document_No = arr[0];
                            roadwork.Commencement_Order_ID = arr[1];
                            roadwork.Description = arr[2];
                            roadwork.Project_ID = arr[3];
                            roadwork.Region_ID = arr[4];
                            roadwork.Document_Date = Convert.ToString(arr[5]);
                            roadwork.Purchase_Contract_ID = arr[6];
                            roadwork.Contractor_Name = arr[7];
                            roadwork.Project_Name = arr[8];
                            roadwork.Road_Code = Convert.ToString(arr[9]);
                            roadwork.Road_Section_No = Convert.ToString(arr[10]);
                            roadwork.Project_Start_Date = Convert.ToString(arr[11]);
                            roadwork.Project_End_Date = Convert.ToString(arr[12]);
                            roadwork.Status = Convert.ToString(arr[13]);
                            list.Add(roadwork);
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
        public ActionResult ViewUpcomingMeeting()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                return View();
            }

        }

        public ActionResult WorkRegionList()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                List<Models.Contractor.CountriesModel> list = new List<Models.Contractor.CountriesModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetRegions();
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if(info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            Models.Contractor.CountriesModel region = new Models.Contractor.CountriesModel();
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
        }
        public ActionResult ContractorEquipmentTypeLists()
        {
            List<ContractorEquipmentTypeModel> list = new List<ContractorEquipmentTypeModel>();
            try
            {
                var nav = new NavConnection().queries();

                var query = nav.fnGetWorkEquipmentCategories();
                String[] info =query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if(info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        ContractorEquipmentTypeModel type = new ContractorEquipmentTypeModel();
                        type.Code = arr[0];
                        type.Description = arr[1];
                        list.Add(type);
                    }
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }
            return View(list);
        }
        public JsonResult RegisterWorkExecutionPlan(string OrderNumber)
        {

            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                DateTime startdate, enddate;
                var nav = new NavConnection().ObjNav();               
                var status = nav.fnCreatWorkExecutionScheduleDetails(vendorNo, OrderNumber);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        Session["WorkExecutionPlanNumber"] = nav.fngetWorkExecutionPlanNumber(vendorNo, OrderNumber);
                        Session["WorkExecutionPlanProjectNumber"] = nav.fngetWorkExecutionPlanProjectNumber(vendorNo, OrderNumber);
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
        public JsonResult RegisterWorkExecutionPlanScheduleDetails(WEPExecutionLinesModel weplines)
        {

            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                DateTime startdate, enddate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                startdate = DateTime.Parse(weplines.Scheduled_Start_Date, usCulture.DateTimeFormat);
                enddate = DateTime.Parse(weplines.Scheduled_End_Date, usCulture.DateTimeFormat);
                var nav = new NavConnection().ObjNav(); 
                var status = nav.fnSubmitWorkExecutionPlanScheduleDetails(weplines.Document_No, weplines.Job_No, weplines.Job_Task_No, startdate,enddate);
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
        public JsonResult RegisterWorkExecutionPlanContractorTeamDetails(WEPContractorTeamModel team)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                DateTime startdate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                startdate = DateTime.Parse(team.Effective_Date, usCulture.DateTimeFormat);
                var nav = new NavConnection().ObjNav();
                var status = "";/*nav.FnSubmitWorkExecutionPlanContractorTeam(team.Document_No,vendorNo, team.Contractor_Staff_No, team.Name, team.Emailaddress, team.Address, team.Address_2, team.City, team.Country_Region_Code, team.Post_Code, team.Telephone, team.Designation,Convert.ToInt32(team.Staff_Category), startdate);*/
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
        public ActionResult GoPrevious1()
        {
            int step;
            try
            {
                step = Convert.ToInt32(Request.QueryString["step"].Trim());
            }
            catch (Exception ex)
            {
                step = 0;
            }
            int step1 = 1;
            return RedirectToAction("NewDailyWorkRecords", "Contractor", new { step = step1 });
        }
        public ActionResult GoPrevious2()
        {
            int step;
            try
            {
                step = Convert.ToInt32(Request.QueryString["step"].Trim());
            }
            catch (Exception ex)
            {
                step = 0;
            }
            int step1 = 2;
            return RedirectToAction("NewDailyWorkRecords", "Contractor", new { step = step1 });
        }
        public ActionResult GoPrevious3()
        {
            int step;
            try
            {
                step = Convert.ToInt32(Request.QueryString["step"].Trim());
            }
            catch (Exception ex)
            {
                step = 0;
            }
            int step1 = 3;
            return RedirectToAction("NewDailyWorkRecords", "Contractor", new { step = step1 });
        }
        public ActionResult GoNext()
        {
            int step;
            try
            {
                step = Convert.ToInt32(Request.QueryString["step"].Trim());
            }
            catch (Exception ex)
            {
                step = 0;
            }
            int step1 = step + 1;
            return RedirectToAction("NewDailyWorkRecords", "Contractor", new { step= step1 });
        }
        public ActionResult GoNextStep2()
        {
            int step;
            try
            {
                step = Convert.ToInt32(Request.QueryString["step"].Trim());
            }
            catch (Exception ex)
            {
                step = 0;
            }
            int step1 = 2;
            return RedirectToAction("NewDailyWorkRecords", "Contractor", new { step = step1 });
        }
        public ActionResult GoNextStep3()
        {
            int step;
            try
            {
                step = Convert.ToInt32(Request.QueryString["step"].Trim());
            }
            catch (Exception ex)
            {
                step = 0;
            }
            int step1 = 3;
            return RedirectToAction("NewDailyWorkRecords", "Contractor", new { step = step1 });
        }
        public ActionResult GoNextStep4()
        {
            int step;
            try
            {
                step = Convert.ToInt32(Request.QueryString["step"].Trim());
            }
            catch (Exception ex)
            {
                step = 0;
            }
            int step1 = 4;
            return RedirectToAction("NewDailyWorkRecords", "Contractor", new { step = step1 });
        }
        public ActionResult GoNextStep5()
        {
            int step;
            try
            {
                step = Convert.ToInt32(Request.QueryString["step"].Trim());
            }
            catch (Exception ex)
            {
                step = 0;
            }
            int step1 = 5;
            return RedirectToAction("NewDailyWorkRecords", "Contractor", new { step = step1 });
        }
        public ActionResult NavigationMenu()
        {
            return View();
        }
        public ActionResult NavigationFooter()
        {
            return View();
        }
        public ActionResult NewProjectMeetingRegister()
        {
            return View();
        }
        public ActionResult NewDailyWorkRecords()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult RegisterWorkExecutionPlanEquipmentsDetails(WEPContractorEquipment equipments)
        {
            try
            {
                var vendorNo = Session["vendorNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = "";
                    //nav.FnSubmitWorkExecutionPlanEquipments(equipments.Document_No, vendorNo, equipments.Equipment_No, equipments.Equipment_Type_Code, equipments.Description, Convert.ToInt32(equipments.Ownership_Type), 
                    //equipments.Equipment_Serial_No, Convert.ToInt32(equipments.Equipment_Usability_Code), Convert.ToInt32(equipments.Years_of_Previous_Use), Convert.ToInt32(equipments.Equipment_Condition_Code),equipments.Equipment_Availability);
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
        public ActionResult ContractorStaffCountryList()
        {
            List<Models.Contractor.CountriesModel> list = new List<Models.Contractor.CountriesModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetCountries();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if(info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        Models.Contractor.CountriesModel country = new Models.Contractor.CountriesModel();
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
        public ActionResult ContractorPostCodesList()
        {
            List<Models.Contractor.DropdownListsModel> postacode = new List<Models.Contractor.DropdownListsModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetPostCodes();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if(info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        Models.Contractor.DropdownListsModel postcodes = new Models.Contractor.DropdownListsModel();
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
        public ActionResult ProjectStaffRoleCodeList()
        {
            List<Models.Contractor.DropdownListsModel> postacode = new List<Models.Contractor.DropdownListsModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetProjectStaffRoleCode();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        Models.Contractor.DropdownListsModel role = new Models.Contractor.DropdownListsModel();
                        role.Code = arr[0];
                        role.Description = arr[1];
                        postacode.Add(role);
                    }
                }
               
            }
            catch (Exception e)
            {

                throw;
            }
            return View(postacode);
        }
        public ActionResult ProjectTasksList()
        {
            List<ProjectTasksModel> list = new List<ProjectTasksModel>();
            try
            {
                var ProjectNumber = Session["WorkExecutionPlanProjectNumber"].ToString();
                var nav = new NavConnection().queries();
                var query = nav.fnGetJobTasks();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[0] == ProjectNumber)
                        {
                            ProjectTasksModel task = new ProjectTasksModel();
                            task.Job_Task_No = arr[21];
                            task.Description = arr[1];
                            list.Add(task);
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
        public ActionResult FileNewWorkExecutionPlan()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                var ExecutionPlanNumber = Session["WorkExecutionPlanNumber"].ToString();
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.GeneralDetails = GetProjectExecutionPlanDetails(ExecutionPlanNumber, vendorNo);
                model.WEPTeam = GetWEPContractorTeamDetails(ExecutionPlanNumber, vendorNo);
                model.WEPLines = GetWEPExecutionPlanLinesDetails(ExecutionPlanNumber, vendorNo);
                model.PlanningLines = GetJobPlanningLinesDetails(ExecutionPlanNumber);
                model.Equipment = GetWEPExecutionPlanEquipments(ExecutionPlanNumber, vendorNo);
                model.Vendors = GetVendors(vendorNo);
                return View(model);
            }

        }
        public ActionResult ViewWorkExecutionPlan(string ExecutionPlanNumber)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.GeneralDetails = GetProjectExecutionPlanDetails(ExecutionPlanNumber, vendorNo);
                model.WEPTeam = GetWEPContractorTeamDetails(ExecutionPlanNumber, vendorNo);
                model.WEPLines = GetWEPExecutionPlanLinesDetails(ExecutionPlanNumber, vendorNo);
                model.PlanningLines = GetJobPlanningLinesDetails(ExecutionPlanNumber);
                model.Equipment = GetWEPExecutionPlanEquipments(ExecutionPlanNumber, vendorNo);
                model.Vendors = GetVendors(vendorNo);
                return View(model);
            }

        }
        public ActionResult ViewOrdertoCommence(string OrderNumber)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.GeneralDetails = GetOrdertoCommenceDetails(OrderNumber);
                model.InternalTeam = GetProjectInternalTeamDetails(OrderNumber);
                model.PlannedMeetings = GetPCOPlannedMeeting(OrderNumber);
                model.RequiredDocuments = GetPCORequiredDocuments(OrderNumber);
                return View(model);
            }

        }
        private static List<WEPExecutionLinesModel> GetWEPExecutionPlanLinesDetails(string ExecutionPlanNumber,string vendorNo)
        {

            List<WEPExecutionLinesModel> list = new List<WEPExecutionLinesModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetWEPExecutionSchedule(ExecutionPlanNumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        WEPExecutionLinesModel project = new WEPExecutionLinesModel();
                        project.Document_No = arr[0];
                        project.Job_No = arr[1];
                        project.Job_Task_No = Convert.ToString(arr[7]);
                        project.Scheduled_End_Date = Convert.ToString(arr[2]);
                        project.Scheduled_Start_Date = Convert.ToString(arr[3]);
                        project.Description = arr[4];
                        project.Budget_Total_Cost = Convert.ToString(arr[5]);
                        project.Job_Task_Type = arr[6];
                        list.Add(project);

                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }

            return list;

        }
        private static List<WEPContractorEquipment> GetWEPExecutionPlanEquipments(string ExecutionPlanNumber,string vendorNo)
        {

            List<WEPContractorEquipment> list = new List<WEPContractorEquipment>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetWEPContractorEqquipment(ExecutionPlanNumber, vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        WEPContractorEquipment project = new WEPContractorEquipment();
                        project.Document_No = ExecutionPlanNumber;
                        project.Document_Type = arr[0];
                        project.Contractor_No = Convert.ToString(vendorNo);
                        project.Equipment_No = Convert.ToString(arr[8]);
                        project.Equipment_Type_Code = Convert.ToString(arr[1]);
                        project.Description = arr[2];
                        project.Ownership_Type = Convert.ToString(arr[3]);
                        project.Equipment_Serial_No = arr[4];
                        project.Equipment_Usability_Code = arr[5];
                        project.Years_of_Previous_Use = Convert.ToString(arr[6]);
                        project.Equipment_Condition_Code = arr[7];
                        list.Add(project);

                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return list;

        }
        private static List<ProjectWorksModel> GetProjectDetails(string vendorNo,string ProjectNumber)
        {

            List<ProjectWorksModel> list = new List<ProjectWorksModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetJobs();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if(info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[2] == ProjectNumber)
                        {
                            ProjectWorksModel project = new ProjectWorksModel();

                            project.Project_No = arr[2];
                            project.No = arr[0];
                            project.Project_Start_Date = Convert.ToString(arr[3]);
                            project.Project_End_Date = Convert.ToString(arr[4]);
                            project.Description = arr[1];
                            project.Person_Responsible =arr[5];
                            project.Project_Manager =arr[5];
                            project.Contractor_No = arr[6];
                            project.Contractor_Name = arr[7];
                            project.Road_Section_No = arr[8];
                            project.Status = arr[9];
                            project.IFS_Code = arr[10];
                            project.Road_Class_ID = arr[11];
                            project.Road_Code = arr[12];
                            project.Road_Section_No = arr[8];
                            project.Funding_Source = arr[13];
                            project.Section_Name = arr[14];                        
                            project.Total_Road_Section_Length_KM = Convert.ToString(arr[15]);
                            project.Constituency_ID = arr[16];
                            project.Creation_Date = Convert.ToString(arr[17]);
                            project.Contract_Start_Date = Convert.ToString(arr[18]);
                            project.Contract_End_Date = Convert.ToString(arr[19]);
                            project.Directorate_Code = arr[20];
                            list.Add(project);
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
        private static List<ProjectWorksModel> GetCompletedProjecttDetails(string vendorNo, string ProjectNumber)
        {

            List<ProjectWorksModel> list = new List<ProjectWorksModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetJobs();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[2] == ProjectNumber)
                        {
                            ProjectWorksModel project = new ProjectWorksModel();


                            project.Project_No = arr[2];
                            project.No = arr[0];
                            project.Project_Start_Date = Convert.ToString(arr[3]);
                            project.Project_End_Date = Convert.ToString(arr[4]);
                            project.Description = arr[1];
                            project.Person_Responsible = arr[5];
                            project.Project_Manager = arr[5];
                            project.Contractor_No = arr[6];
                            project.Contractor_Name = arr[7];
                            project.Road_Section_No = arr[8];
                            project.Status = arr[9];
                            project.IFS_Code = arr[10];
                            project.Road_Class_ID = arr[11];
                            project.Road_Code = arr[12];
                            project.Road_Section_No = arr[8];
                            project.Funding_Source = arr[13];
                            project.Section_Name = arr[14];
                            project.Total_Road_Section_Length_KM = Convert.ToString(arr[15]);
                            project.Constituency_ID = arr[16];
                            project.Creation_Date = Convert.ToString(arr[17]);
                            project.Contract_Start_Date = Convert.ToString(arr[18]);
                            project.Contract_End_Date = Convert.ToString(arr[19]);
                            project.Directorate_Code = arr[20];
                            list.Add(project);
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
        private static List<ProjectWorkExecutionPlanModel> GetProjectExecutionPlanDetails(string ExecutionPlanNumber,string vendorNo)
        {
            List<ProjectWorkExecutionPlanModel> list = new List<ProjectWorkExecutionPlanModel>();
            try
            {

                var nav = new NavConnection().queries();
                var query = nav.fnGetProjectMobilizationHeader(vendorNo, "Released");
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if(info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[0] == ExecutionPlanNumber)
                        {
                            ProjectWorkExecutionPlanModel roadwork = new ProjectWorkExecutionPlanModel();
                            roadwork.Document_No = arr[0];
                            roadwork.Commencement_Order_ID = arr[1];
                            roadwork.Description = arr[2];
                            roadwork.Project_ID = arr[3];
                            roadwork.Region_ID = arr[4];
                            roadwork.Document_Date = Convert.ToString(arr[5]);                           
                            roadwork.Contractor_Name = arr[7];
                            roadwork.Project_Name = arr[8];
                            roadwork.Road_Code = Convert.ToString(arr[9]);
                            roadwork.Road_Section_No = Convert.ToString(arr[10]);
                            roadwork.Project_Start_Date = Convert.ToString(arr[11]);                           
                            roadwork.status = Convert.ToString(arr[13]);
                            roadwork.Contractor_No =vendorNo;
                            roadwork.Section_Name = arr[14];
                            roadwork.Directorate_ID = arr[15];
                            roadwork.Constituency_ID = arr[16];
                            roadwork.Department_ID = arr[17];
                            list.Add(roadwork);
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
        private static List<OrderToCommenceModel> GetOrdertoCommenceDetails(string OrderNumber)
        {
            List<OrderToCommenceModel> list = new List<OrderToCommenceModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetCommencementOrders(OrderNumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if(info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        OrderToCommenceModel order = new OrderToCommenceModel();
                        order.Notice_No = OrderNumber;
                        order.Document_Date = Convert.ToString(arr[5]);
                        order.Purchase_Contract_ID = arr[6];
                        order.Project_ID = arr[3];
                        order.Description = arr[2];
                        order.Staff_Appointment_Voucher_No = arr[14];
                        order.Contractor_No = arr[15];
                        order.Contractor_Name = arr[7];
                        order.Vendor_Address = arr[16];
                        order.Vendor_Address_2 = arr[17];
                        order.Vendor_Post_Code =arr[18];
                        order.Status = arr[13];
                        order.Vendor_City = arr[19];
                        order.Primary_E_mail = arr[20];
                        order.IFS_Code = arr[21];
                        order.Tender_Name =arr[22];
                        order.Project_Name = arr[8];
                        order.Road_Code = arr[9];
                        order.Road_Section_No = arr[10];
                        order.Section_Name = arr[23];
                        order.Project_Start_Date = Convert.ToString(arr[11]);
                        order.Project_End_Date = Convert.ToString(arr[12]);
                        order.Region_ID = arr[24];
                        order.Directorate_ID = arr[25];
                        order.Constituency_ID = arr[28];
                        order.Department_ID = arr[26];
                        order.Contract_No = arr[27];
                        list.Add(order);
                    }
                }
                

            }
            catch (Exception e)
            {

                throw;
            }

            return list;
        }
        private static List<JobPlanningLinesModel> GetJobPlanningLinesDetails(string ProjectNumber)
        {
            List<JobPlanningLinesModel> list = new List<JobPlanningLinesModel>();
            try
            {
                var nav =new NavConnection().queries();
                var query = nav.fnGetJobPlanningLines(ProjectNumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if(info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        JobPlanningLinesModel order = new JobPlanningLinesModel();
                        order.Description = arr[0];
                        order.Line_Amount_LCY = Convert.ToString(arr[1]);
                        order.Unit_Cost = Convert.ToString(arr[2]);
                        order.Total_Cost = Convert.ToString(arr[3]);
                        order.Unit_Price = Convert.ToString(arr[4]);
                        order.Total_Price = Convert.ToString(arr[5]);
                        order.Line_No = Convert.ToString(arr[6]);
                        order.Job_No = ProjectNumber;
                        order.Job_Task_No = arr[7];
                        order.Planning_Date = Convert.ToString(arr[8]);
                        order.Document_No = arr[10];
                        order.Type = arr[11];                       
                        order.Quantity = Convert.ToString(arr[12]);
                        order.Direct_Unit_Cost_LCY = Convert.ToString(arr[13]);
                        order.Unit_Cost_LCY = Convert.ToString(arr[14]);
                        order.Total_Cost_LCY = Convert.ToString(arr[15]);
                        order.Document_Date = Convert.ToString(arr[9]);
                        order.Line_Amount = Convert.ToString(arr[16]);
                        order.Line_Discount_Amount = Convert.ToString(arr[17]);
                        order.Line_Discount_Amount_LCY = Convert.ToString(arr[18]);
                        list.Add(order);
                    }
                }
               

            }
            catch (Exception e)
            {

                throw;
            }

            return list;
        }
        private static List<PCORequredDocumentsModel> GetPCORequiredDocuments(string OrderNumber)
        {
            List<PCORequredDocumentsModel> list = new List<PCORequredDocumentsModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetPCORequiredDocument(OrderNumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if(info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        PCORequredDocumentsModel order = new PCORequredDocumentsModel();
                        order.Notice_No = arr[0];
                        order.Description = Convert.ToString(arr[1]);
                        order.Document_Type = Convert.ToString(arr[2]);
                        order.Requirement_Type = arr[3];
                        order.Guidelines_Instructions = Convert.ToString(arr[4]);
                        order.Due_Date = Convert.ToString(arr[5]);
                        list.Add(order);
                    }
                }
               
            }
            catch (Exception e)
            {

                throw;
            }

            return list;
        }
        private static List<PCOPlannedMeetingModel> GetPCOPlannedMeeting(string OrderNumber)
        {
            List<PCOPlannedMeetingModel> list = new List<PCOPlannedMeetingModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetPCOPlannedMeeting(OrderNumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if(info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        PCOPlannedMeetingModel order = new PCOPlannedMeetingModel();
                        order.Notice_No = OrderNumber;
                        order.Meeting_Type = arr[0];
                        order.Description = Convert.ToString(arr[1]);
                        order.Start_Date = Convert.ToString(arr[2]);
                        order.Start_Time = arr[3];
                        order.End_Date = Convert.ToString(arr[4]);
                        order.End_Time = arr[5];
                        order.Venue_Location = arr[6];
                        list.Add(order);
                    }
                }
               
            }
            catch (Exception e)
            {

                throw;
            }

            return list;
        }
        private static List<WEPContractorTeamModel> GetWEPContractorTeamDetails(string ExecutionPlanNumber,string vendorNo)
        {
            List<WEPContractorTeamModel> list = new List<WEPContractorTeamModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetWEPContractorTeam(ExecutionPlanNumber, vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if(info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        WEPContractorTeamModel order = new WEPContractorTeamModel();
                        order.Document_No = ExecutionPlanNumber;
                        order.Contractor_No = Convert.ToString(vendorNo);
                        order.Name = arr[0];
                        order.Address = arr[1];
                        order.Address_2 = arr[2];
                        order.City = arr[3];
                        order.Post_Code = arr[4];
                        order.Country_Region_Code = arr[5];
                        order.Role_Code = arr[6];
                        order.Designation = arr[7];
                        order.Effective_Date = Convert.ToString(arr[8]);
                        order.Expiry_Date = Convert.ToString(arr[9]);
                        order.Staff_Category = arr[10];
                        order.Contractor_Staff_No = arr[11];
                        list.Add(order);
                    }
                }
              
            }
            catch (Exception e)
            {

                throw;
            }

            return list;
        }
        private static List<ProjectinternalTeamModel> GetProjectInternalTeamDetails(string CommencmentOrderNumber)
        {
            List<ProjectinternalTeamModel> list = new List<ProjectinternalTeamModel>();
            try
            {
                var nav =new NavConnection().queries();
                var query = nav.fnGetPCOInternalProjectTeam(CommencmentOrderNumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if(info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        ProjectinternalTeamModel order = new ProjectinternalTeamModel();
                        order.Commencement_Order_No = CommencmentOrderNumber;
                        order.Resource_No = Convert.ToString(arr[0]);
                        order.Name = arr[1];
                        order.Email = arr[2];
                        order.Address = arr[3];
                        order.Address_2 = arr[4];
                        order.City = arr[5];
                        order.Post_Code = arr[6];
                        order.Country_Region_Code = arr[7];
                        order.Phone_No = arr[8];
                        order.Role_Code = arr[9];
                        order.Designation = arr[10];
                        list.Add(order);
                    }
                }
               
            }
            catch (Exception e)
            {

                throw;
            }

            return list;
        }
        public ActionResult DraftWorkExecutionPlans()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                List<WorkExecutionPlanModel> list = new List<WorkExecutionPlanModel>();
                try
                {
                    var vendorNo = Session["vendorNo"].ToString();
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetProjectMobilizationHeader(vendorNo, "Open");
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            WorkExecutionPlanModel roadwork = new WorkExecutionPlanModel();
                            roadwork.Document_No = arr[0];
                            roadwork.Commencement_Order_ID = arr[1];
                            roadwork.Description = arr[2];
                            roadwork.Project_ID = arr[3];
                            roadwork.Region_ID = arr[4];
                            roadwork.Document_Date = Convert.ToString(arr[5]);
                            roadwork.Purchase_Contract_ID = arr[6];
                            roadwork.Contractor_Name = arr[7];
                            roadwork.Project_Name = arr[8];
                            roadwork.Road_Code = Convert.ToString(arr[9]);
                            roadwork.Road_Section_No = Convert.ToString(arr[10]);
                            roadwork.Project_Start_Date = Convert.ToString(arr[11]);
                            roadwork.Project_End_Date = Convert.ToString(arr[12]);
                            roadwork.Status = Convert.ToString(arr[13]);
                            list.Add(roadwork);
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
        public ActionResult CancelledContracts()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                List<ContractsModel> list = new List<ContractsModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var vendorNo = Session["vendorNo"].ToString();
                    var query = nav.fnGetPurchaseHeader("Blanket Order", vendorNo);
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            if (arr[34] == "Cancelled" && arr[17] == "Blanket Order")
                            {
                                ContractsModel contract = new ContractsModel();
                                contract.Document_Type = "Blanket Order";
                                contract.Buy_from_Vendor_No = arr[22];
                                contract.No = arr[0];
                                contract.Pay_to_Name = arr[1];
                                contract.Pay_to_Vendor_No = vendorNo;
                                contract.Pay_to_Name_2 = arr[23];
                                contract.Pay_to_Address = arr[24];
                                contract.Pay_to_Address_2 = arr[25];
                                contract.Pay_to_Contact = arr[26];
                                contract.Your_Reference = arr[27];
                                contract.Order_Date = Convert.ToString(arr[28]);
                                contract.Posting_Date = Convert.ToString(arr[29]);
                                contract.Location_Code = arr[30];
                                contract.Region_Code = arr[4];
                                contract.Link_Name = arr[31];
                                contract.Works_Length = Convert.ToString(arr[32]);
                                contract.Invatition_for_supply = arr[13];
                                contract.Tender_Description = arr[19];
                                contract.Contract_Description = arr[6];
                                contract.Contract_End_Date = Convert.ToString(arr[10]);
                                contract.Contract_Start_Date = Convert.ToString(arr[9]);
                                contract.Contract_Value = Convert.ToString(arr[33]);
                                list.Add(contract);

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

        public ActionResult CompletedProjectWorks()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.OngoingWorks = GetOngoingProjectsWorks(vendorNo);
                model.CompletedWorks = GetCompletedProjectsWorks(vendorNo);
                return View(model);
            }
        }  
        public ActionResult RegisterUpcomingMeeting()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                return View();
            }
        }
        public ActionResult OngoingProjectWorks()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.OngoingWorks = GetOngoingProjectsWorks(vendorNo);
                model.CompletedWorks = GetCompletedProjectsWorks(vendorNo);
                return View(model);
            }
        }
        private static List<ProjectWorksModel> GetOngoingProjectsWorks(string VendorNo)
        {
            List<ProjectWorksModel> list = new List<ProjectWorksModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetProjectWorks(VendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if(info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        ProjectWorksModel work = new ProjectWorksModel();
                        work.No = arr[0];
                        work.Road_Section_No = arr[1];
                        work.Search_Description = arr[31];
                        work.Description = arr[2];
                        work.Description_2 = arr[3];
                        work.Bill_to_Customer_No = arr[4];
                        work.Creation_Date = Convert.ToString(arr[5]);
                        work.Ending_Date = Convert.ToString(arr[6]);
                        work.Status = arr[7];
                        work.Person_Responsible = arr[8];
                        work.Project_Manager = arr[9];
                        work.Project_Budget = Convert.ToString(arr[10]);
                        work.Actual_Project_Costs = Convert.ToString(arr[11]);
                        work.Project_Start_Date = Convert.ToString(arr[12]);
                        work.Project_End_Date = Convert.ToString(arr[13]);
                        work.Road_Length_KM = Convert.ToString(arr[14]);
                        work.Funding_Source = arr[15];
                        work.Project_Category = arr[16];
                        work.Road_Project_Sub_Category =arr[32] ;
                        work.Road_Project_Type = arr[33];
                        work.Road_Code = arr[34];
                        work.Record_Type = arr[35];
                        work.Road_Project_Catergory = arr[17];
                        work.Road_Class_ID = arr[18];
                        work.Section_Name = arr[19];
                        work.County_ID = arr[20];
                        work.Region_ID = arr[21];
                        work.Section_Start_Chainage_Km = Convert.ToString(arr[22]);
                        work.Section_End_Chainage_KM = Convert.ToString(arr[23]);
                        work.Total_Road_Section_Length_KM = Convert.ToString(arr[24]);
                        work.Contractor_No =VendorNo;
                        work.Contractor_Name = arr[27];
                        work.Contract_Start_Date = Convert.ToString(arr[25]);
                        work.Contract_End_Date = Convert.ToString(arr[26]);
                        work.Notice_of_Award_Date = Convert.ToString(arr[28]);
                        work.IFS_Code =arr[29];
                        work.Project_Commencement_Order = arr[30];
                        work.Road_Works_Category = arr[31];                      
                        list.Add(work);

                    }
                }
               
            }
            catch (Exception e)
            {

                throw;
            }
            return list;

        }
        private static List<ProjectWorksModel> GetCompletedProjectsWorks(string VendorNo)
        {
            List<ProjectWorksModel> list = new List<ProjectWorksModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetJobs();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[6] == VendorNo)
                        {
                            ProjectWorksModel project = new ProjectWorksModel();

                            project.Project_No = arr[2];
                            project.No = arr[0];
                            project.Project_Start_Date = Convert.ToString(arr[3]);
                            project.Project_End_Date = Convert.ToString(arr[4]);
                            project.Description = arr[1];
                            project.Person_Responsible = arr[5];
                            project.Project_Manager = arr[5];
                            project.Contractor_No = arr[6];
                            project.Contractor_Name = arr[7];
                            project.Road_Section_No = arr[8];
                            project.Status = arr[9];
                            project.IFS_Code = arr[10];
                            project.Road_Class_ID = arr[11];
                            project.Road_Code = arr[12];
                            project.Road_Section_No = arr[8];
                            project.Funding_Source = arr[13];
                            project.Section_Name = arr[14];
                            project.Total_Road_Section_Length_KM = Convert.ToString(arr[15]);
                            project.Constituency_ID = arr[16];
                            project.Creation_Date = Convert.ToString(arr[17]);
                            project.Contract_Start_Date = Convert.ToString(arr[18]);
                            project.Contract_End_Date = Convert.ToString(arr[19]);
                            project.Directorate_Code = arr[20];
                            list.Add(project);
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
        public ActionResult PendingCommencementWorksOrders()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                List<ActiveContracts> list = new List<ActiveContracts>();
                try
                {
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetInviteTender("");
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            if (arr[6] != "")
                            {
                                ActiveContracts tender = new ActiveContracts();
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
                                tender.Document_Date = DateTime.Parse(arr[9]);
                                tender.Status = arr[10];
                                tender.Name = arr[11];
                                tender.Submission_End_Date = DateTime.Parse(arr[12]);
                                tender.Submission_Start_Date = DateTime.Parse(arr[13]);
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
        public ActionResult MyTransactions()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                List<BidResponseDetailsModel> list = new List<BidResponseDetailsModel>();
                try
                {
                    var nav =new NavConnection().queries();
                    var vendorNo = Session["vendorNo"].ToString();
                    var query = nav.fnGetPurchaseHeader("Quote",vendorNo);
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if(info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            if (arr[17] == "Quote")
                            {
                                BidResponseDetailsModel tender = new BidResponseDetailsModel();
                                tender.No = arr[0];
                                tender.Invitation_For_Supply_No = arr[13];
                                tender.Pay_to_Vendor_No = arr[22];
                                tender.Bidder_type = arr[18];
                                tender.Tender_Description = arr[20];
                                tender.Tender_Name = arr[19];
                                tender.Location_Code = arr[12];
                                tender.Amount = Convert.ToString(arr[16]);
                                tender.Document_Date = Convert.ToString(arr[2]);
                                tender.Status = arr[21];
                                tender.Amount_Including_VAT = Convert.ToString(arr[6]);
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
        public ActionResult ViewProjectContracts()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                List<ActiveContracts> list = new List<ActiveContracts>();
                try
                {
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetInviteTender("");
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            if (arr[6] != "")
                            {
                                ActiveContracts tender = new ActiveContracts();
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
                                tender.Document_Date =DateTime.Parse(arr[9]);
                                tender.Status = arr[10];
                                tender.Name = arr[11];
                                tender.Submission_End_Date = DateTime.Parse(arr[12]);
                                tender.Submission_Start_Date = DateTime.Parse(arr[13]);
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
        public ActionResult MyStatement()
        {
            var vendorNo = Session["vendorNo"].ToString();
            dynamic model = new ExpandoObject();
            model.Vendors = GetVendors(vendorNo);
            model.Statement = GetVendorsStatement(vendorNo);
            return View(model);

        }
        public ActionResult RoadGeneralDetails(string roadLinkCode)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.Vendors = GetVendors(vendorNo);
                model.RoadLinkCode = GetRoadInventoryGeneralDetails(roadLinkCode);
                model.RoadSections = GetRoadInventorySectionDetails(roadLinkCode);
                //model.RoadStructures = GetRoadInventoryStructuresDetails(roadLinkCode);
                model.RoadEnvirons = GetRoadInventoryEnvironsDetails(roadLinkCode);
                model.RoadConditions = GetRoadInventoryConditionsDetails(roadLinkCode);
                return View(model);
            }

        }
        private static List<RoadsInventoryModel> GetRoadInventoryGeneralDetails(string roadLinkCode)
        {
            List<RoadsInventoryModel> list = new List<RoadsInventoryModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetRoadInventory(roadLinkCode);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if(info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        RoadsInventoryModel roadlink = new RoadsInventoryModel();
                        roadlink.Road_Code = roadLinkCode;
                        roadlink.Link_Name = arr[0];
                        roadlink.Road_Category =arr[1];
                        roadlink.Carriageway_Type = arr[2];
                        roadlink.Primary_County_ID = arr[3];
                        roadlink.Start_Chainage_KM = Convert.ToString(arr[4]);
                        roadlink.End_Chainage_KM = Convert.ToString(arr[5]);
                        roadlink.Gazetted_Road_Length_KMs = Convert.ToString(arr[6]);
                        roadlink.No_of_Road_Sections = Convert.ToString(arr[7]);
                        roadlink.General_Road_Surface_Condition = arr[8];
                        roadlink.Start_Point_Longitude = Convert.ToString(arr[10]);
                        roadlink.Start_Point_Latitude = Convert.ToString(arr[9]);
                        roadlink.End_Point_Longitude = Convert.ToString(arr[12]);
                        roadlink.End_Point_Latitude = Convert.ToString(arr[11]);
                        roadlink.Paved_Road_Length_Km = Convert.ToString(arr[13]);
                        roadlink.Paved_Road_Length = Convert.ToString(arr[14]);
                        roadlink.Unpaved_Road_Length = Convert.ToString(arr[15]);
                        roadlink.Original_Road_Agency = Convert.ToString(arr[16]);
                        list.Add(roadlink);
                    }
                }
                
            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<RoadLinkConditionModel> GetRoadInventoryConditionsDetails(string roadLinkCode)
        {
            List<RoadLinkConditionModel> list = new List<RoadLinkConditionModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetPavementSurfaceEntry(roadLinkCode);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if(info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        RoadLinkConditionModel roadlink = new RoadLinkConditionModel();
                        roadlink.Enrty_No = Convert.ToString(arr[0]);
                        roadlink.Posting_Date = Convert.ToString(arr[1]);
                        roadlink.Document_No = arr[3];
                        roadlink.Road_Code = Convert.ToString(arr[4]);
                        roadlink.Road_Section_No = Convert.ToString(arr[13]);
                        roadlink.Pavement_Surface_Type = Convert.ToString(arr[5]);
                        roadlink.Pavement_Category = Convert.ToString(arr[2]);
                        roadlink.Start_Chainage = Convert.ToString(arr[6]);
                        roadlink.End_Chainage = Convert.ToString(arr[7]);
                        roadlink.Road_Length_Kms = Convert.ToString(arr[8]);
                        roadlink.Road_Class_ID = Convert.ToString(arr[9]);
                        roadlink.Constituency_ID = Convert.ToString(arr[10]);
                        roadlink.County_ID = Convert.ToString(arr[11]);
                        roadlink.Region_ID = Convert.ToString(arr[12]);
                        list.Add(roadlink);
                    }
                }
              
            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<RoadSectionsModel> GetRoadInventorySectionDetails(string roadLinkCode)
        {
            List<RoadSectionsModel> list = new List<RoadSectionsModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetRoadSections(roadLinkCode);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if(info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        RoadSectionsModel roadlinksection = new RoadSectionsModel();
                        roadlinksection.Road_Code = roadLinkCode;
                        roadlinksection.Road_Section_No = arr[0];
                        roadlinksection.Road_Category = arr[1];
                        roadlinksection.CarriageAwayType = arr[2];
                        roadlinksection.Constituency = arr[3];
                        roadlinksection.Region = Convert.ToString(arr[4]);
                        roadlinksection.Start_Chainage = Convert.ToString(arr[5]);
                        roadlinksection.End_Chainage = Convert.ToString(arr[6]);
                        roadlinksection.Total_Road_Length = Convert.ToString(arr[7]);
                        roadlinksection.Start_Point_Longitude = Convert.ToString(arr[9]);
                        roadlinksection.Start_Point_Latitude = Convert.ToString(arr[8]);
                        roadlinksection.End_Point_Longitude = Convert.ToString(arr[11]);
                        roadlinksection.End_Point_Latitude = Convert.ToString(arr[10]);
                        roadlinksection.Paved_Road_Lenght_Km = Convert.ToString(arr[12]);
                        roadlinksection.Paved_Road_Length = Convert.ToString(arr[12]);
                        roadlinksection.UnPaved_Road_Length = Convert.ToString(arr[13]);
                        list.Add(roadlinksection);

                    }
                }
                
            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
 
        private static List<RoadLinkEnvironsModel> GetRoadInventoryEnvironsDetails(string roadLinkCode)
        {
            List<RoadLinkEnvironsModel> list = new List<RoadLinkEnvironsModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetRoadEnviron();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if(info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        RoadLinkEnvironsModel roadlinkenviron = new RoadLinkEnvironsModel();
                        // roadlinkenviron.Entry_No = Convert.ToString(roadlinkenvirons.Entry_No);
                        roadlinkenviron.Road_Environ_Category = arr[0];
                        roadlinkenviron.Description = arr[1];
                        roadlinkenviron.Road_Code = arr[2];
                        roadlinkenviron.Road_Section_No = arr[3];
                        roadlinkenviron.Connected_to_Road_Link = Convert.ToString(arr[4]);
                        roadlinkenviron.Location_Details = arr[5];
                        roadlinkenviron.Road_Class_ID = arr[6];
                        roadlinkenviron.Constituency_ID = arr[7];
                        roadlinkenviron.Region_ID = arr[8];
                        list.Add(roadlinkenviron);
                    }
                }               
            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        public ActionResult PendingTasks()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                List<ProjectTasksModel> list = new List<ProjectTasksModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetJobTasks();

                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            ProjectTasksModel projecttask = new ProjectTasksModel();
                            projecttask.Job_No = arr[0];
                            projecttask.Description = arr[1];
                            projecttask.Department_Code = arr[2];
                            projecttask.Directorate_Code = arr[3];
                            projecttask.Division = arr[4];
                            projecttask.Commitments = Convert.ToString(arr[5]);
                            projecttask.Start_Point_Km = Convert.ToString(arr[6]);
                            projecttask.End_Point_Km = Convert.ToString(arr[7]);
                            projecttask.Start_Date = Convert.ToString(arr[8]);
                            projecttask.End_Date = Convert.ToString(arr[9]);
                            projecttask.Funding_Source = arr[11];
                            projecttask.Procurement_Method = arr[10];
                            projecttask.Surface_Types = arr[12];
                            projecttask.Road_Condition = arr[13];
                            projecttask.Completed_Length_Km = Convert.ToString(arr[14]);
                            projecttask.Roads_Category = arr[15];
                            projecttask.Fund_Type = arr[16];
                            projecttask.Execution_Method = arr[17];
                            projecttask.Region = arr[18];
                            projecttask.Constituency = arr[22];

                            list.Add(projecttask);
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
        public ActionResult NoticeofCompletedWorks()
        {
          return  View();

        }
        public ActionResult CompletedTasks()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                List<ProjectTasksModel> list = new List<ProjectTasksModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetJobTasks();
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            ProjectTasksModel projecttask = new ProjectTasksModel();
                            projecttask.Job_No = arr[0];
                            projecttask.Description = arr[1];
                            projecttask.Department_Code = arr[2];
                            projecttask.Directorate_Code = arr[3];
                            projecttask.Division = arr[4];
                            projecttask.Commitments = Convert.ToString(arr[5]);
                            projecttask.Start_Point_Km = Convert.ToString(arr[6]);
                            projecttask.End_Point_Km = Convert.ToString(arr[7]);
                            projecttask.Start_Date = Convert.ToString(arr[8]);
                            projecttask.End_Date = Convert.ToString(arr[9]);
                            projecttask.Funding_Source = arr[11];
                            projecttask.Procurement_Method = arr[10];
                            projecttask.Surface_Types = arr[12];
                            projecttask.Road_Condition = arr[13];
                            projecttask.Completed_Length_Km = Convert.ToString(arr[14]);
                            projecttask.Roads_Category = arr[15];
                            projecttask.Fund_Type = arr[16];
                            projecttask.Execution_Method = arr[17];
                            projecttask.Region = arr[18];
                            projecttask.Constituency = arr[22];

                            list.Add(projecttask);
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
        public ActionResult AllTasks(string ProjectCode)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.ActiveProjectTasksDetails = GetProjectTasksDetails(ProjectCode);
                model.OpenProjectTasksDetails = GetOpenProjectTasksDetails(ProjectCode);
                model.PendingProjectTasksDetails = GetPendingProjectTasksDetails(ProjectCode);
                model.CompletedProjectTasksDetails = GetCompletedProjectTasksDetails(ProjectCode);
                return View(model);

            }
        }

        public ActionResult ProjectUpcomingMeetings()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                return View();
            }
        }
        public ActionResult DraftStatusReports()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                List<ProjectTasksModel> list = new List<ProjectTasksModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetJobTasks();
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            ProjectTasksModel projecttask = new ProjectTasksModel();
                            projecttask.Job_No = arr[0];
                            projecttask.Description = arr[1];
                            projecttask.Department_Code = arr[2];
                            projecttask.Directorate_Code = arr[3];
                            projecttask.Division = arr[4];
                            projecttask.Commitments = Convert.ToString(arr[5]);
                            projecttask.Start_Point_Km = Convert.ToString(arr[6]);
                            projecttask.End_Point_Km = Convert.ToString(arr[7]);
                            projecttask.Start_Date = Convert.ToString(arr[8]);
                            projecttask.End_Date = Convert.ToString(arr[9]);
                            projecttask.Funding_Source = arr[11];
                            projecttask.Procurement_Method = arr[10];
                            projecttask.Surface_Types = arr[12];
                            projecttask.Road_Condition = arr[13];
                            projecttask.Completed_Length_Km = Convert.ToString(arr[14]);
                            projecttask.Roads_Category = arr[15];
                            projecttask.Fund_Type = arr[16];
                            projecttask.Execution_Method = arr[17];
                            projecttask.Region = arr[18];
                            projecttask.Constituency = arr[22];

                            list.Add(projecttask);
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
        private static List<ProjectTasksModel> GetCompletedProjectTasksDetails(string ProjectCode)
        {
            List<ProjectTasksModel> list = new List<ProjectTasksModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetJobTasks();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        ProjectTasksModel projecttask = new ProjectTasksModel();
                        projecttask.Job_No = arr[0];
                        projecttask.Description = arr[1];
                        projecttask.Department_Code = arr[2];
                        projecttask.Directorate_Code = arr[3];
                        projecttask.Division = arr[4];
                        projecttask.Commitments = Convert.ToString(arr[5]);
                        projecttask.Start_Point_Km = Convert.ToString(arr[6]);
                        projecttask.End_Point_Km = Convert.ToString(arr[7]);
                        projecttask.Start_Date = Convert.ToString(arr[8]);
                        projecttask.End_Date = Convert.ToString(arr[9]);
                        projecttask.Funding_Source = arr[11];
                        projecttask.Procurement_Method = arr[10];
                        projecttask.Surface_Types = arr[12];
                        projecttask.Road_Condition = arr[13];
                        projecttask.Completed_Length_Km = Convert.ToString(arr[14]);
                        projecttask.Roads_Category = arr[15];
                        projecttask.Fund_Type = arr[16];
                        projecttask.Execution_Method = arr[17];
                        projecttask.Region = arr[18];
                        projecttask.Constituency = arr[22];

                        list.Add(projecttask);
                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<ProjectTasksModel> GetPendingProjectTasksDetails(string ProjectCode)
        {
            List<ProjectTasksModel> list = new List<ProjectTasksModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetJobTasks();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        ProjectTasksModel projecttask = new ProjectTasksModel();
                        projecttask.Job_No = arr[0];
                        projecttask.Description = arr[1];
                        projecttask.Department_Code = arr[2];
                        projecttask.Directorate_Code = arr[3];
                        projecttask.Division = arr[4];
                        projecttask.Commitments = Convert.ToString(arr[5]);
                        projecttask.Start_Point_Km = Convert.ToString(arr[6]);
                        projecttask.End_Point_Km = Convert.ToString(arr[7]);
                        projecttask.Start_Date = Convert.ToString(arr[8]);
                        projecttask.End_Date = Convert.ToString(arr[9]);
                        projecttask.Funding_Source = arr[11];
                        projecttask.Procurement_Method = arr[10];
                        projecttask.Surface_Types = arr[12];
                        projecttask.Road_Condition = arr[13];
                        projecttask.Completed_Length_Km = Convert.ToString(arr[14]);
                        projecttask.Roads_Category = arr[15];
                        projecttask.Fund_Type = arr[16];
                        projecttask.Execution_Method = arr[17];
                        projecttask.Region = arr[18];
                        projecttask.Constituency = arr[22];

                        list.Add(projecttask);
                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<ProjectTasksModel> GetOpenProjectTasksDetails(string ProjectCode)
        {
            List<ProjectTasksModel> list = new List<ProjectTasksModel>();
            try
            {
                var nav =new NavConnection().queries();
                var query = nav.fnGetJobTasks();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        ProjectTasksModel projecttask = new ProjectTasksModel();
                        projecttask.Job_No = arr[0];
                        projecttask.Description = arr[1];
                        projecttask.Department_Code = arr[2];
                        projecttask.Directorate_Code = arr[3];
                        projecttask.Division = arr[4];
                        projecttask.Commitments = Convert.ToString(arr[5]);
                        projecttask.Start_Point_Km = Convert.ToString(arr[6]);
                        projecttask.End_Point_Km = Convert.ToString(arr[7]);
                        projecttask.Start_Date = Convert.ToString(arr[8]);
                        projecttask.End_Date = Convert.ToString(arr[9]);
                        projecttask.Funding_Source = arr[11];
                        projecttask.Procurement_Method = arr[10];
                        projecttask.Surface_Types = arr[12];
                        projecttask.Road_Condition = arr[13];
                        projecttask.Completed_Length_Km = Convert.ToString(arr[14]);
                        projecttask.Roads_Category = arr[15];
                        projecttask.Fund_Type = arr[16];
                        projecttask.Execution_Method = arr[17];
                        projecttask.Region = arr[18];
                        projecttask.Constituency = arr[22];

                        list.Add(projecttask);
                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        private static List<ProjectTasksModel> GetProjectTasksDetails(string ProjectCode)
        {
            List<ProjectTasksModel> list = new List<ProjectTasksModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetJobTasks();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        ProjectTasksModel projecttask = new ProjectTasksModel();
                        projecttask.Job_No = arr[0];
                        projecttask.Description = arr[1];
                        projecttask.Department_Code = arr[2];
                        projecttask.Directorate_Code = arr[3];
                        projecttask.Division = arr[4];
                        projecttask.Commitments = Convert.ToString(arr[5]);
                        projecttask.Start_Point_Km = Convert.ToString(arr[6]);
                        projecttask.End_Point_Km = Convert.ToString(arr[7]);
                        projecttask.Start_Date = Convert.ToString(arr[8]);
                        projecttask.End_Date = Convert.ToString(arr[9]);
                        projecttask.Funding_Source = arr[11];
                        projecttask.Procurement_Method = arr[10];
                        projecttask.Surface_Types = arr[12];
                        projecttask.Road_Condition = arr[13];
                        projecttask.Completed_Length_Km = Convert.ToString(arr[14]);
                        projecttask.Roads_Category = arr[15];
                        projecttask.Fund_Type = arr[16];
                        projecttask.Execution_Method = arr[17];
                        projecttask.Region = arr[18];
                        projecttask.Constituency = arr[22];

                        list.Add(projecttask);
                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        public ActionResult RoadsInventory()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                List<RoadsInventoryModel> list = new List<RoadsInventoryModel>();
                try
                {
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetRoadInventory("");
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            RoadsInventoryModel roadlink = new RoadsInventoryModel();
                            roadlink.Road_Code = arr[17];
                            roadlink.Link_Name = arr[0];
                            roadlink.Road_Category = arr[1];
                            roadlink.Carriageway_Type = arr[2];
                            roadlink.Primary_County_ID = arr[3];
                            roadlink.Start_Chainage_KM = Convert.ToString(arr[4]);
                            roadlink.End_Chainage_KM = Convert.ToString(arr[5]);
                            roadlink.Gazetted_Road_Length_KMs = Convert.ToString(arr[6]);
                            roadlink.No_of_Road_Sections = Convert.ToString(arr[7]);
                            roadlink.General_Road_Surface_Condition = arr[8];
                            roadlink.Start_Point_Longitude = Convert.ToString(arr[10]);
                            roadlink.Start_Point_Latitude = Convert.ToString(arr[9]);
                            roadlink.End_Point_Longitude = Convert.ToString(arr[12]);
                            roadlink.End_Point_Latitude = Convert.ToString(arr[11]);
                            roadlink.Paved_Road_Length_Km = Convert.ToString(arr[13]);
                            roadlink.Paved_Road_Length = Convert.ToString(arr[14]);
                            roadlink.Unpaved_Road_Length = Convert.ToString(arr[15]);
                            roadlink.Original_Road_Agency = Convert.ToString(arr[16]);
                            list.Add(roadlink);
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

        public ActionResult ContractorProfile()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
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
        private static List<Models.Contractor.SharePointTModel> PopulateSupplierRegistrationDocuments(string ittpnumber)
        {
            List<Models.Contractor.SharePointTModel> alldocuments = new List<Models.Contractor.SharePointTModel>();
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
                                    alldocuments.Add(new Models.Contractor.SharePointTModel { FileName = file.Name });

                                }
                            }
                        }

                    }
                }
                return alldocuments;
            }
        }
        public ActionResult MyAccount()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.Vendors = GetVendors(vendorNo);
                model.BanksDetails = GetBanks(vendorNo);
                model.StakeholdersDetails = GetStakeholders(vendorNo);
                model.PrequalifcationHistory = GetPrequalificationHistory(vendorNo);
                model.PastExperience = GetVendorPastExeprience(vendorNo);
                model.litigationhistory = GetVendorLitigationHistoryDetails(vendorNo);
                model.balancesheet = GetVendorBalanaceDetails(vendorNo);
                model.incomestatement = GetVendorIncomeStatementDetails(vendorNo);
                return View(model);
            }
        }
        public  ActionResult ViewOngoingProject( string ProjectNumber)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.Vendors = GetVendors(vendorNo);
                model.Project = GetProjectDetails(vendorNo,ProjectNumber);
                model.ProjectPackages = GetProjectPackages(vendorNo, ProjectNumber);
                model.ProjectBillsItems = GetProjectBillItems(vendorNo, ProjectNumber);
                return View(model);
            }
        }
        public ActionResult ViewCompletedProject(string ProjectNumber)
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.Vendors = GetVendors(vendorNo);
                model.Project = GetCompletedProjecttDetails(vendorNo, ProjectNumber);
                model.ProjectPackages = GetProjectPackages(vendorNo, ProjectNumber);
                model.ProjectBillsItems = GetProjectBillItems(vendorNo, ProjectNumber);
                return View(model);
            }
        }
        private static List<ProjectTasksLinesModel> GetProjectPackages(string vendorNo, string ProjectNumber)
        {

            List<ProjectTasksLinesModel> list = new List<ProjectTasksLinesModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetJobTasks();
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[0] == ProjectNumber)
                        {
                            ProjectTasksLinesModel projectsline = new ProjectTasksLinesModel();
                            projectsline.Job_No = arr[0];
                            projectsline.Job_Task_No = arr[21];                          
                            projectsline.Description = arr[1];
                            projectsline.Department_Code = arr[2];
                            projectsline.Directorate_Code = arr[3];                            
                            projectsline.Start_Point_Km = Convert.ToString(arr[6]);
                            projectsline.End_Point_Km = Convert.ToString(arr[7]);
                            projectsline.Start_Date = Convert.ToString(arr[8]);
                            projectsline.End_Date = Convert.ToString(arr[9]);                            
                            projectsline.Surface_Types = arr[12];
                            projectsline.Road_Condition = arr[13];
                            projectsline.Completed_Length_Km = Convert.ToString(arr[14]);
                            projectsline.Roads_Category = arr[15];                         

                            list.Add(projectsline);

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
        private static List<ProjectPlanningLinesModel> GetProjectBillItems(string vendorNo, string ProjectNumber)
        {

            List<ProjectPlanningLinesModel> list = new List<ProjectPlanningLinesModel>();
            try
            {
                var nav = new NavConnection().queries();               
                var query = nav.fnGetJobPlanningLines(ProjectNumber);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        ProjectPlanningLinesModel projectsline = new ProjectPlanningLinesModel();
                        projectsline.Description = arr[0];
                        projectsline.No = arr[19];
                        projectsline.Road_Category = Convert.ToString(arr[20]);
                        projectsline.Unit_of_Measure = Convert.ToString(arr[21]);                        
                        projectsline.Line_No = Convert.ToString(arr[6]);
                        projectsline.Job_No = ProjectNumber;
                        projectsline.Job_Task_No = arr[7];                        
                        projectsline.Type = arr[11];
                        projectsline.Quantity = Convert.ToString(arr[12]);
                       
                        list.Add(projectsline);
                    }
                }
               
            }
            catch (Exception e)
            {

                throw;
            }
            return list;

        }
        private static List<ContractorStatementModel> GetVendorsStatement(string vendorNo)
        {

            List<ContractorStatementModel> list = new List<ContractorStatementModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetVendorStatement(vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        ContractorStatementModel statetement = new ContractorStatementModel();
                        statetement.Vendor_No = vendorNo;
                        statetement.Document_Type = arr[0];
                        statetement.Posting_Date = DateTime.Parse(arr[1]).ToString("dd-MM-yy");
                        statetement.Description = arr[2];
                        statetement.Document_No = arr[3];
                        statetement.Vendor_Name = arr[4];
                        statetement.Amount = Convert.ToString(arr[5]).Replace("-", " ");
                        statetement.Remaining_Amount = Convert.ToString(arr[6]).Replace("-", " "); ;
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
        private static List<ContractorIncomeStatementTModel> GetVendorIncomeStatementDetails(string vendorNo)
        {

            List<ContractorIncomeStatementTModel> incomestatementdetails = new List<ContractorIncomeStatementTModel>();
            try
            {
                var nav = new NavConnection().queries();
                var query = nav.fnGetVendorStatement(vendorNo);
                String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        ContractorIncomeStatementTModel income = new ContractorIncomeStatementTModel();
                        // Table missing these entries. 
                        //income.Audit_Year_Code_Reference = incomestatement.Audit_Year_Code_Reference;
                        //income.Total_Revenue_LCY = incomestatement.Total_Revenue_LCY;
                        //income.Total_COGS_LCY = incomestatement.Total_COGS_LCY;
                        //income.Gross_Margin_LCY = incomestatement.Gross_Margin_LCY;
                        //income.Total_Operating_Expenses_LCY = incomestatement.Total_Operating_Expenses_LCY;
                        //income.Operating_Income_EBIT_LCY = incomestatement.Operating_Income_EBIT_LCY;
                        //income.Other_Non_operating_Re_Exp_LCY = incomestatement.Other_Non_operating_Re_Exp_LCY;
                        //income.Interest_Expense_LCY = incomestatement.Interest_Expense_LCY;
                        //income.Income_Before_Taxes_LCY = incomestatement.Income_Before_Taxes_LCY;
                        //income.Income_Tax_Expense_LCY = incomestatement.Income_Tax_Expense_LCY;
                        //income.Net_Income_from_Ops_LCY = incomestatement.Net_Income_from_Ops_LCY;
                        //income.Net_Income = incomestatement.Net_Income;
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
        private static List<ContractorsBalanceSheetTModel> GetVendorBalanaceDetails(string vendorNo)
        {

            List<ContractorsBalanceSheetTModel> balancesheetdetails = new List<ContractorsBalanceSheetTModel>();
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
                        ContractorsBalanceSheetTModel balancesheet = new ContractorsBalanceSheetTModel();
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
        private static List<ContractorLitigationModel> GetVendorLitigationHistoryDetails(string vendorNo)
        {

            List<ContractorLitigationModel> litigationDetailsHistory = new List<ContractorLitigationModel>();
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
                        ContractorLitigationModel litigation = new ContractorLitigationModel();
                       // litigation.Entry_No = Convert.ToInt32(arr[0]);
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
        private static List<ContractorPastExperienceModel> GetVendorPastExeprience(string vendorNo)
        {

            List<ContractorPastExperienceModel> pastexperienceDetails = new List<ContractorPastExperienceModel>();
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
                        ContractorPastExperienceModel pastexperience = new ContractorPastExperienceModel();                        
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
        private static List<ContractorPrequalifiedCategoriesModel> GetPrequalificationHistory(string vendorNo)
        {

            List<ContractorPrequalifiedCategoriesModel> prequalificationDetails = new List<ContractorPrequalifiedCategoriesModel>();
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
                        ContractorPrequalifiedCategoriesModel response = new ContractorPrequalifiedCategoriesModel();
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
        private static List<ContractorProfileModel> GetVendors(string vendorNo)
        {

            List<ContractorProfileModel> vendorsDetails = new List<ContractorProfileModel>();
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
                        ContractorProfileModel vendor = new ContractorProfileModel();
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
                            vendor.Issued_Capital = Convert.ToString(arr[37]);
                            vendorsDetails.Add(vendor);
                      

                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }

            return vendorsDetails;
        }
        private static List<ContractorDirectorsModel> GetStakeholders(string vendorNo)
        {

            List<ContractorDirectorsModel> DirectorDetails = new List<ContractorDirectorsModel>();
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
                        ContractorDirectorsModel shareholder = new ContractorDirectorsModel();
                        shareholder.Entry_No = Convert.ToInt32(arr[0]);
                        shareholder.Address = arr[31];
                        shareholder.Fullname = arr[1];
                        shareholder.CitizenshipType = arr[11];
                        shareholder.OwnershipPercentage = Convert.ToDecimal(arr[6]);
                        shareholder.Phonenumber = arr[7];
                        shareholder.Address = arr[3];
                        shareholder.PostCode = arr[5];
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
        private static List<ContractorBanksModel> GetBanks(string vendorNo)
        {

            List<ContractorBanksModel> BankDetails = new List<ContractorBanksModel>();
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
                        ContractorBanksModel bank = new ContractorBanksModel();
                        bank.BankCode = arr[0];
                        bank.BankName = arr[1];
                        bank.Post_Code = arr[2];
                        bank.Contact = arr[3];
                        bank.CurrencyCode = arr[4];
                        bank.BankAccountNo = arr[5];
                        bank.Bank_Branch_No = arr[6];                       
                        bank.CountryCode = arr[9];
                        bank.Phone_No = arr[10];
                        bank.City = arr[7];
                        BankDetails.Add(bank);
                    }
                }
                

            }
            catch (Exception e)
            {

                throw;
            }

            return BankDetails;
        }
        public ActionResult ActiveTenderNotices()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                List<ActiveContracts> list = new List<ActiveContracts>();
                try
                {
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetInviteTender("");
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            if (arr[6] != "")
                            {
                                ActiveContracts tender = new ActiveContracts();
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
                                tender.Document_Date = DateTime.Parse(arr[9]);
                                tender.Status = arr[10];
                                tender.Name = arr[11];
                                tender.Submission_End_Date = DateTime.Parse(arr[12]);
                                tender.Submission_Start_Date =DateTime.Parse(arr[13]);
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
        public ActionResult ProjectsViewLists()
        {
            List<ProjectListModel> ProjectDetails = new List<ProjectListModel>();
            try
            {
                var nav = new NavConnection().queries();
                var vendorNo = Session["vendorNo"].ToString();
                var result = nav.fnGetJobs();
                String[] info = result.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        String[] arr = info[i].Split('*');
                        if (arr[21] == vendorNo && arr[22] == "Open")
                        {
                            ProjectListModel project = new ProjectListModel();
                            project.No = arr[0];
                            project.Description = arr[1];
                            ProjectDetails.Add(project);
                        }
                       
                       
                    }
                }
               
               

            }
            catch (Exception e)
            {

                throw;
            }
            return View(ProjectDetails);
        }
        public ActionResult DraftMeasurementsSheets()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                List<MeasurementSheetModel> list = new List<MeasurementSheetModel>();
                try
                {
                    var vendorNo = Session["vendorNo"].ToString();
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetMeasurements(vendorNo);
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if(info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            if (arr[0] == "Open" && arr[1] == "Draft")
                            {
                                MeasurementSheetModel measurement = new MeasurementSheetModel();
                                measurement.Document_Date = Convert.ToString(arr[2]);
                                measurement.Documents_No = arr[15];
                                measurement.Project_ID = arr[3];
                                measurement.Description = arr[4];
                                measurement.Works_Start_Chainage = Convert.ToString(arr[5]);
                                measurement.Contractor_No = arr[7];
                                measurement.Contractor_Name =arr[8];
                                measurement.Works_End_Chainage = Convert.ToString(arr[6]);
                                measurement.Status = arr[0];
                                measurement.Project_Name = arr[9];
                                measurement.Road_Section_No =arr[10];
                                measurement.Project_Start_Date = Convert.ToString(arr[11]);
                                measurement.Region_ID = arr[12];
                                measurement.Directorate_ID = arr[13];
                                measurement.Constituency_ID = arr[14];
                                list.Add(measurement);
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
        public ActionResult SubmittedMeasurementsSheets()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                List<MeasurementSheetModel> list = new List<MeasurementSheetModel>();
                try
                {
                    var vendorNo = Session["vendorNo"].ToString();
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetMeasurements(vendorNo);
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            if (arr[0] == "Open" && arr[1] == "Submitted")
                            {
                                MeasurementSheetModel measurement = new MeasurementSheetModel();
                                measurement.Document_Date = Convert.ToString(arr[2]);
                                measurement.Documents_No = arr[15];
                                measurement.Project_ID = arr[3];
                                measurement.Description = arr[4];
                                measurement.Works_Start_Chainage = Convert.ToString(arr[5]);
                                measurement.Contractor_No = arr[7];
                                measurement.Contractor_Name = arr[8];
                                measurement.Works_End_Chainage = Convert.ToString(arr[6]);
                                measurement.Status = arr[0];
                                measurement.Project_Name = arr[9];
                                measurement.Road_Section_No = arr[10];
                                measurement.Project_Start_Date = Convert.ToString(arr[11]);
                                measurement.Region_ID = arr[12];
                                measurement.Directorate_ID = arr[13];
                                measurement.Constituency_ID = arr[14];
                                list.Add(measurement);
                            }

                        }
                    }



                }
                catch (Exception ex)
                {

                    throw;
                }
                return View(list);

            }
        }
        public ActionResult ApprovedMeasurementsSheets()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                List<MeasurementSheetModel> list = new List<MeasurementSheetModel>();
                try
                {
                    var vendorNo = Session["vendorNo"].ToString();
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetMeasurements(vendorNo);
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            if (arr[0] == "Released" && arr[1] == "Submitted")
                            {
                                MeasurementSheetModel measurement = new MeasurementSheetModel();
                                measurement.Document_Date = Convert.ToString(arr[2]);
                                measurement.Documents_No = arr[15];
                                measurement.Project_ID = arr[3];
                                measurement.Description = arr[4];
                                measurement.Works_Start_Chainage = Convert.ToString(arr[5]);
                                measurement.Contractor_No = arr[7];
                                measurement.Contractor_Name = arr[8];
                                measurement.Works_End_Chainage = Convert.ToString(arr[6]);
                                measurement.Status = arr[0];
                                measurement.Project_Name = arr[9];
                                measurement.Road_Section_No = arr[10];
                                measurement.Project_Start_Date = Convert.ToString(arr[11]);
                                measurement.Region_ID = arr[12];
                                measurement.Directorate_ID = arr[13];
                                measurement.Constituency_ID = arr[14];
                                list.Add(measurement);
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
        public ActionResult FiledOrders()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                List<OrderToCommenceModel> list = new List<OrderToCommenceModel>();
                try
                {
                    var vendorNo = Session["vendorNo"].ToString();
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetCommencementOrders("");
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            if (arr[28] == vendorNo)
                            {
                                OrderToCommenceModel order = new OrderToCommenceModel();
                                order.Notice_No = arr[29];
                                order.Document_Date = Convert.ToString(arr[5]);
                                order.Purchase_Contract_ID = arr[6];
                                order.Project_ID = arr[3];
                                order.Description = arr[2];
                                order.Staff_Appointment_Voucher_No = arr[14];
                                order.Contractor_No = arr[15];
                                order.Contractor_Name = arr[7];
                                order.Vendor_Address = arr[16];
                                order.Vendor_Address_2 = arr[17];
                                order.Vendor_Post_Code = arr[18];
                                order.Status = arr[13];
                                order.Vendor_City = arr[19];
                                order.Primary_E_mail = arr[20];
                                order.IFS_Code = arr[21];
                                order.Tender_Name = arr[22];
                                order.Project_Name = arr[8];
                                order.Road_Code = arr[9];
                                order.Road_Section_No = arr[10];
                                order.Section_Name = arr[23];
                                order.Project_Start_Date = Convert.ToString(arr[11]);
                                order.Project_End_Date = Convert.ToString(arr[12]);
                                order.Region_ID = arr[24];
                                order.Directorate_ID = arr[25];
                                order.Constituency_ID = arr[28];
                                order.Department_ID = arr[26];
                                order.Contract_No = arr[27];
                                list.Add(order);
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
        public ActionResult ContractorDashboard()
        {
            if (Session["vendorNo"] != null)
            {
                List<ProjectTasksModel> list = new List<ProjectTasksModel>();
                try
                {
                   
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetJobTasks();
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            ProjectTasksModel projecttask = new ProjectTasksModel();
                            projecttask.Job_No = arr[0];
                            projecttask.Description = arr[1];
                            projecttask.Department_Code = arr[2];
                            projecttask.Directorate_Code = arr[3];
                            projecttask.Division = arr[4];
                            projecttask.Commitments = Convert.ToString(arr[5]);
                            projecttask.Start_Point_Km = Convert.ToString(arr[6]);
                            projecttask.End_Point_Km = Convert.ToString(arr[7]);
                            projecttask.Start_Date = Convert.ToString(arr[8]);
                            projecttask.End_Date = Convert.ToString(arr[9]);
                            projecttask.Funding_Source = arr[11]; 
                            projecttask.Procurement_Method = arr[10];
                            projecttask.Surface_Types = arr[12];
                            projecttask.Road_Condition = arr[13];
                            projecttask.Completed_Length_Km = Convert.ToString(arr[14]);
                            projecttask.Roads_Category = arr[15];
                            projecttask.Fund_Type = arr[16];
                            projecttask.Execution_Method = arr[17];
                            projecttask.Region = arr[18];
                            projecttask.Constituency = arr[22];

                            list.Add(projecttask);
                        }
                    }

                }
                catch (Exception e)
                {

                    throw;
                }
                return View(list);
            }
            else
            {
                return RedirectToAction("Login", "Contractor");
            }
        }
        public ActionResult PlannedProjects()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                List<ActiveContracts> list = new List<ActiveContracts>();
                try
                {
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetInviteTender("");
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            if (arr[6] != "")
                            {
                                ActiveContracts tender = new ActiveContracts();
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
                                tender.Document_Date = DateTime.Parse(arr[9]);
                                tender.Status = arr[10];
                                tender.Name = arr[11];
                                tender.Submission_End_Date = DateTime.Parse(arr[12]);
                                tender.Submission_Start_Date = DateTime.Parse(arr[13]);
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
        public ActionResult CompletedProjects()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                var vendorNo = Session["vendorNo"].ToString();
                dynamic model = new ExpandoObject();
                model.OngoingWorks = GetOngoingProjectsWorks(vendorNo);
                model.CompletedWorks = GetCompletedProjectsWorks(vendorNo);
                return View(model);
            }
        }

        public ActionResult UpcomingProjects()
        {
            if (Session["vendorNo"] == null)
            {
                return RedirectToAction("Login", "Contractor");
            }
            else
            {
                List<ActiveContracts> list = new List<ActiveContracts>();
                try
                {
                    var nav = new NavConnection().queries();
                    var query = nav.fnGetInviteTender("");
                    String[] info = query.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (info != null)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            String[] arr = info[i].Split('*');
                            if (arr[6] != "")
                            {
                                ActiveContracts tender = new ActiveContracts();
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
                                tender.Document_Date = DateTime.Parse(arr[9]);
                                tender.Status = arr[10];
                                tender.Name = arr[11];
                                tender.Submission_End_Date = DateTime.Parse(arr[12]);
                                tender.Submission_Start_Date = DateTime.Parse(arr[13]);
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
        // GET: Contractor/Create
        public ActionResult Create()
        {
            return View();
        }

   
        // GET: Contractor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

     
        // GET: Contractor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contractor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Microsoft.SharePoint.Client.FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ResetPassword()
        {

            return View();
        }
        public ActionResult Register()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(LoginViewModel model)
        //{

            //try
            //{
            //    if (ModelState.IsValid)
            //    {

            //        var nav = NavConnection.ReturnNav();
            //        var user = nav.PortalUsers.Where(x => x.Authentication_Email == model.Email && x.Password_Value == model.Password).ToList();
            //        var result = user.FirstOrDefault();
            //        if (result != null)
            //        {
            //            foreach (var supplier in user)
            //            {
            //                string fname = supplier.Full_Name;
            //                string username = supplier.User_Name;
            //                string phoneNumber = supplier.Mobile_Phone_No;
            //                Session["prequalified"] = supplier.State;
            //                Session["email"] = supplier.Authentication_Email;
            //                Session["password"] = supplier.Password_Value;
            //                Session["name"] = supplier.Full_Name;
            //                Session["email"] = supplier.Authentication_Email;
            //                Session["userNo"] = supplier.Record_ID;
            //                Session["vendorNo"] = supplier.Record_ID;
            //                Session["username"] = username;
            //                Session["fullname"] = fname;

            //            }
            //            //check if the contact is registered in the vendor table
            //            var vendor = nav.eProVendorQT.ToList();
            //            var vendorDetails = (from a in vendor where a.No == (string)Session["vendorNo"] select a).ToList();
            //            if (result.State == "Enabled")
            //            {
            //                foreach (var vendordetail in vendorDetails)
            //                {
            //                    Session["vendorNo"] = vendordetail.No;
            //                    Session["vendorName"] = vendordetail.Name;
            //                    Session["userNo"] = vendordetail.No;
            //                    Session["vatNumber"] = vendordetail.VAT_Registration_No;
            //                }
            //                return RedirectToAction("ContractorDashboard", "Contractor");
            //            }
            //            if (result.State != "Enabled")
            //            {
            //                TempData["error"] = "Your account is deactivated";

            //            }
            //        }
            //        else
            //        {
            //            TempData["error"] = "The Email Address or Password provided is incorrect. Kindly try Again with the Correct Credentials";
            //        }
            //    }
            //}

            //catch (Exception ex)
            //{
            //    TempData["error"] = ex.Message;

            //}
            //return View(model);
       // }
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

    }
}
