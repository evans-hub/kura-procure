using E_Procurement.OData;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace E_Procurement.Models
{
    public class NavConnection
    {
        public static ClientContext SPClientContext { get; set; }

        public static Web SPWeb { get; set; }

        public static string SPErrorMsg { get; set; }

        
        // remote connection data
         public ProcurementQueriesTest.eprocurementQueries queries()
        {
            var ws = new ProcurementQueriesTest.eprocurementQueries();
            try
            {
                var credentials = new NetworkCredential(ConfigurationManager.AppSettings["W_USER"],
                   ConfigurationManager.AppSettings["W_PWD"], ConfigurationManager.AppSettings["DOMAIN"]);
        ws.Credentials = credentials;
                ws.PreAuthenticate = true;

            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return ws;
        }
        public ProcurementTest.procurement ObjNav()
        {
            var ws = new ProcurementTest.procurement();
            try
            {
                var credentials = new NetworkCredential(ConfigurationManager.AppSettings["W_USER"],
                    ConfigurationManager.AppSettings["W_PWD"], ConfigurationManager.AppSettings["DOMAIN"]);
                ws.Credentials = credentials;
                ws.PreAuthenticate = true;


            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return ws;
        }
      
        public static bool Connect(string SPURL, string SPUserName, string SPPassWord, string SPDomainName)
        {

            bool bConnected = false;

            try
            {
                var
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

            }

            return bConnected;

        }   

}
}


