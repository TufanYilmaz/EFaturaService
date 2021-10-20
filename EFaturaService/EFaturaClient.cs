using EFaturaService.Classes.EFatura;
using EFaturaService.Helpers;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Deserializer = Newtonsoft.Json.JsonConvert;
namespace EFaturaService
{
    public enum MODE
    {
        Debug = 0,
        Real = 1
    }
    public class EFaturaClient
    {
        Dictionary<MODE, string> URL = new Dictionary<MODE, string>()
        {
            {MODE.Debug,"https://earsivportaltest.efatura.gov.tr"},
            {MODE.Real,"https://earsivportal.efatura.gov.tr" }
        };
        const string BASE_URL = "https://earsivportal.efatura.gov.tr";
        const string TEST_URL = "https://earsivportaltest.efatura.gov.tr";

        private MODE mod = MODE.Real;
        public MODE Mod
        {
            get => mod;
            set
            {
                mod = value;
                restClient = new RestClient(URL[value]);
            }
        }
        //JsonDeserializer Deserializer = new JsonDeserializer();
        RestClient restClient;
        public EFaturaClient()
        {
            restClient = new RestClient(URL[Mod]);
        }
        const string DISPATCH_PATH = "/earsiv-services/dispatch";
        const string TOKEN_PATH = "/earsiv-services/assos-login";
        const string REFERRER_PATH = "/intragiris.html";
        const string TEST_USER_PATH = "/earsiv-services/esign";


        public string username = "3333333315";

        public string password = "1";

        protected string token = "";

        protected string language = "TR";


        protected List<Invoice> invoices = new List<Invoice>();

        protected string oid;

        public static List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>
        {
            {new KeyValuePair<string, string>("accept" , "*/*" )},
            {new KeyValuePair<string, string>("accept-language","tr,en-US;q=0.9,en;q=0.8" )},
            {new KeyValuePair<string, string>("cache-control" , "no-cache" )},
            {new KeyValuePair<string, string>("content-type" , "application/x-www-form-urlencoded;charset=UTF-8" )},
            {new KeyValuePair<string, string>("pragma" , "no-cache" )},
            {new KeyValuePair<string, string>("sec-fetch-mode" , "cors" )},
            {new KeyValuePair<string, string>("sec-fetch-site" , "same-origin" )},
            {new KeyValuePair<string, string>("User-Agent" , "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.67 Safari/537.36" )},
        };


        public void GetTestUser()
        {
            var request = new RestRequest(TEST_USER_PATH)
                .AddParameter("assoscmd", "kullaniciOner")
                .AddParameter("rtype", "json");
            try
            {

                var response = restClient.Post(request);
                EfaturaUser res = Deserializer.DeserializeObject<EfaturaUser>(response.Content);
                this.username = res.userid;
                this.password = res.password;
            }
            catch (Exception ex)
            {

            }
        }
        public void GetToken()
        {
            string method = Mod == MODE.Debug ? "login" : "anologin";
            var request = new RestRequest(TOKEN_PATH);
            request.AddHeaders(headers);
            request.AddHeader("referrer", URL[Mod] + "/intragiris.html");
            request.AddParameter("assoscmd", method);
            request.AddParameter("rtype", "json");
            request.AddParameter("userid", username);
            request.AddParameter("sifre", password);
            request.AddParameter("sifre2", password);
            request.AddParameter("parola", password);

            try
            {

                var response = restClient.Post(request);
                var res = Deserializer.DeserializeObject<TokenResponse>(response.Content);
                this.token = res.token;
            }
            catch (Exception ex)
            {

            }
        }
        public List<InvoiceInfo> GetInvoicesByDateRange(DateTime start,DateTime end)
        {
            List<InvoiceInfo> result = new List<InvoiceInfo>();
            var requestObject = new RequestInvoicesObject();
            requestObject.baslangic = start.ToString("dd/MM/yyyy").Replace('.','/');
            requestObject.bitis = end.ToString("dd/MM/yyyy").Replace('.', '/');

            var request = new RestRequest(DISPATCH_PATH);
            request.AddHeaders(headers);
            request.AddHeader("referrer", URL[Mod] + "/login.jsp");
            request.AddParameter("cmd", COMMANDS.getAllInvoicesByDateRange.Command);
            request.AddParameter("callid", Guid.NewGuid().ToString());
            request.AddParameter("pageName", COMMANDS.getAllInvoicesByDateRange.PageName);
            request.AddParameter("token", token);
            request.AddParameter("jp", Deserializer.SerializeObject(requestObject));
            try
            {

                var response = restClient.Post(request);
                var res = Deserializer.DeserializeObject<Invoices>(response.Content);
                result = res.data;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public List<InvoiceInfo> CreateDraftInvoice(Invoice invoice= null)
        {
            if (invoice == null)
                invoice = new Invoice();
            var request = new RestRequest(DISPATCH_PATH);
            request.AddHeaders(headers);
            request.AddHeader("referrer", URL[Mod] + "/login.jsp");
            request.AddParameter("cmd", COMMANDS.createDraftInvoice.Command);
            request.AddParameter("callid", Guid.NewGuid().ToString());
            request.AddParameter("pageName", COMMANDS.createDraftInvoice.PageName);
            request.AddParameter("token", token);
            request.AddParameter("jp", Deserializer.SerializeObject(invoice));
            try
            {

                var response = restClient.Post(request);
                
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public InvoiceInfo FindInvoice(string ettnUUID,DateTime date)
        {
            var invoices = GetInvoicesByDateRange(date, date);
            var res = invoices.First(i => i.ettn == ettnUUID);
            return res;
        }
        public InvoiceInfo FindInvoice(Invoice invoice)
        {
            return FindInvoice(invoice.faturaUuid,Convert.ToDateTime(invoice.faturaTarihi));
        }
        public void SignDraftInvoice(InvoiceInfo invoice)
        {
            var request = new RestRequest(DISPATCH_PATH);
            var requestObject = new SignDrfatInvoiceObject();
            requestObject.imzalanacaklar.Add(invoice);
            request.AddHeaders(headers);
            request.AddHeader("referrer", URL[Mod] + "/login.jsp");
            request.AddParameter("cmd", COMMANDS.signDraftInvoice.Command);
            request.AddParameter("callid", Guid.NewGuid().ToString());
            request.AddParameter("pageName", COMMANDS.signDraftInvoice.PageName);
            request.AddParameter("token", token);
            request.AddParameter("jp", Deserializer.SerializeObject(requestObject));
            try
            {

                var response = restClient.Post(request);

            }
            catch (Exception ex)
            {

            }
        }
        public void  GetInvoiceHTML(string ettnUUID,bool signed)
        {
            var request = new RestRequest(DISPATCH_PATH);
            var requestObject = new RequestInvoiceHTMLObject();
            requestObject.onayDurumu = signed ? "Onaylandı" : "Onaylanmadı";
            requestObject.ettn = ettnUUID;
            request.AddHeaders(headers);
            request.AddHeader("referrer", URL[Mod] + "/login.jsp");
            request.AddParameter("cmd", COMMANDS.getInvoiceHTML.Command);
            request.AddParameter("callid", Guid.NewGuid().ToString());
            request.AddParameter("pageName", COMMANDS.getInvoiceHTML.PageName);
            request.AddParameter("token", token);
            request.AddParameter("jp", Deserializer.SerializeObject(requestObject));
            try
            {

                var response = restClient.Post(request);

            }
            catch (Exception ex)
            {

            }
        }
        public void DownloadInvoice(InvoiceInfo invoice, bool signed)
        {
            DownloadInvoice(invoice.ettn, signed);
        }
        public void DownloadInvoice(string ettnUUID, bool signed)
        {
            var onayDurumu = signed ? "Onaylandı" : "Onaylanmadı";
            string reqStr = $"/earsiv-services/download?token={token}&ettn={ettnUUID}&belgeTip=FATURA&onayDurumu={onayDurumu}&cmd=EARSIV_PORTAL_BELGE_INDIR";
                      
            try
            {
                FileDownloader.DownloadFile(URL[Mod] + reqStr, $@"C:\Efatura\{ettnUUID}.zip", 5000);
            }
            catch (Exception ex)
            {

            }
        }
        public void SendSignSMSCode(string Phone)
        {
            var request = new RestRequest(DISPATCH_PATH);
            var requestObject = new RequestSMSSendObject();
            requestObject.CEPTEL = Phone;
            request.AddHeaders(headers);
            request.AddHeader("referrer", URL[Mod] + "/login.jsp");
            request.AddParameter("cmd", COMMANDS.sendSignSMSCode.Command);
            request.AddParameter("callid", Guid.NewGuid().ToString());
            request.AddParameter("pageName", COMMANDS.sendSignSMSCode.PageName);
            request.AddParameter("token", token);
            request.AddParameter("jp", Deserializer.SerializeObject(requestObject));
            try
            {

                var response = restClient.Post(request);

            }
            catch (Exception ex)
            {

            }
        }
        public void VerifySignSMSCode(string smsCode,string operationId)
        {
            var request = new RestRequest(DISPATCH_PATH);
            var requestObject = new RequestSMSVerifyObject();
            requestObject.SIFRE = smsCode;
            requestObject.OID = operationId;
            request.AddHeaders(headers);
            request.AddHeader("referrer", URL[Mod] + "/login.jsp");
            request.AddParameter("cmd", COMMANDS.verifySMSCode.Command);
            request.AddParameter("callid", Guid.NewGuid().ToString());
            request.AddParameter("pageName", COMMANDS.verifySMSCode.PageName);
            request.AddParameter("token", token);
            request.AddParameter("jp", Deserializer.SerializeObject(requestObject));
            try
            {

                var response = restClient.Post(request);

            }
            catch (Exception ex)
            {

            }
        }
        public UserData GetUserData()
        {
            var result = new UserData();
            var request = new RestRequest(DISPATCH_PATH);

            request.AddHeaders(headers);
            request.AddHeader("referrer", URL[Mod] + "/login.jsp");
            request.AddParameter("cmd", COMMANDS.getUserData.Command);
            request.AddParameter("callid", Guid.NewGuid().ToString());
            request.AddParameter("pageName", COMMANDS.getUserData.PageName);
            request.AddParameter("token", token);
            try
            {

                var response = restClient.Post(request);
                var res = Deserializer.DeserializeObject<UserData>(response.Content);
                result = res;

            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public UserData UpdateUserData(UserData userData)
        {
            var result = new UserData();
            var request = new RestRequest(DISPATCH_PATH);
            request.AddHeaders(headers);
            request.AddHeader("referrer", URL[Mod] + "/login.jsp");
            request.AddParameter("cmd", COMMANDS.updateUserData.Command);
            request.AddParameter("callid", Guid.NewGuid().ToString());
            request.AddParameter("pageName", COMMANDS.updateUserData.PageName);
            request.AddParameter("token", token);
            request.AddParameter("jp", Deserializer.SerializeObject(userData));
            try
            {

                var response = restClient.Post(request);
                var res = Deserializer.DeserializeObject<UserData>(response.Content);
                result = res;

            }
            catch (Exception ex)
            {

            }
            return result;
        }


    }
}
