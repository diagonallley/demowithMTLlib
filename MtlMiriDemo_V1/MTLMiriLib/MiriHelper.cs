using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using Newtonsoft.Json;
namespace MtlMiriDemo_V1.MTLMiriLib
    {


    public class MiriHelper
    {
        // public string applianceurl = "https://mmcpayment.manipaltechnologies.com";
        public string applianceurl = "https://mmcpayment.com";
        //public MiriHelper(string appurl = "https://mmcpayment.manipaltechnologies.com")
        
        public MiriHelper(string appurl)

        {
            applianceurl = appurl;
        }


        public class UserFields
        {   public string ResponseData2;
            public string ResponseData3;
        }


        public class ResponseData
        {
            public string ResponseData1;
            public string ResponseData2;
            public string ResponseData3;
        }

        public class RegisterRequest
        {
            public string IssuerNumber="";
            public string ExpiryDate="";
            public string ActivationFieldOne="";
            public string ActivationFieldTwo="";
            public string FirstName="";
            public string LastName="";
            public string AccountIssueDate;
            public string LookUpDataOne="";
            public string LookUpDataTwo="";
            public int  UserProfileId = 0;
            public string Cvv = "";
            public string ResponseDataOne = "";
        }
        

        public class MiriTokenChallengeResponseResult
        {
            public string StatusCode;
            public string StatusMessage;
            public string AccountBin;
            public string AccountFirstName;
            public string AccountLastName;
            public string AccountMiddleName;
            public string AcccountSwapData;
            public string MerchantID;
            public string MiriAccountNumberB10;
            public string TransactionDate;
            public string TransactionNumber;
            public string MiriAccountNumberB31;
            public string ResponseData1 = "";
            public string ResponseData2 = "";
            public string ResponseData3 = "";

        }


        public class MiriIdTransactionRestResponse
        {
            public string StatusCode { get; set; }
            public string StatusMessage { get; set; }
            public string AccountBin { get; set; }
            public string AccountDisplayMonth { get; set; }
            public string AccountDisplayYear { get; set; }
            public string AccountFirstName { get; set; }
            public string AccountLastName { get; set; }
            public string AccountMiddleName { get; set; }
            public string AccountSwapData { get; set; }
            public string MerchantID { get; set; }
            public string MiriAccountNumberB10 { get; set; }
            public string MiriAccountNumberB21 { get; set; }
            public string MiriAccountNumberB31 { get; set; }

            public string MiriAccountNumberBase31 { get; set; }
            public string MiriDynamicNumber { get; set; }
            public string NameOnCard { get; set; }
            public string ResponseData1 { get; set; }

            public string ResponseData2 { get; set; }

            public string ResponseData3 { get; set; }
            public string TransactionDate { get; set; }
            public string TransactionNumber { get; set; }
            public object UserFields { get; set; }

            public ResponseData ResponseData { get; set; }
            public string UserProfileNumber { get; set; }
        }

        public class MiriIdTransactionResult
        {
            public string StatusCode;
            public string StatusMessage;
            public string AccountBin;
            public string AccountFirstName;
            public string AccountLastName;
            public string AccountMiddleName;
            public string MiriAccountNumberB31;
            public string MiriAccountNumberBase31;
            public string TransactionDate;
            public string TransactionNumber;
            public string UserProfileNumber;
            public string ResponseData1;
            public string ResponseData2;
            public string ResponseData3;

        }



        public class MiriTokenTransactionRestResponse
        {
            public string StatusCode { get; set; }
            public string StatusMessage { get; set; }
            public string AccountBin { get; set; }
            public string AccountDisplayMonth { get; set; }
            public string AccountDisplayYear { get; set; }
            public string AccountFirstName { get; set; }
            public string AccountLastName { get; set; }
            public string AccountMiddleName { get; set; }
            public string AccountSwapData { get; set; }
            public string MerchantID { get; set; }
            public string MiriAccountNumberB10 { get; set; }
            public string MiriAccountNumberB21 { get; set; }
            public string MiriAccountNumberB31 { get; set; }
            public string MiriDynamicNumber { get; set; }
            public string NameOnCard { get; set; }
            public string ResponseData1 { get; set; } = "";
            public string ResponseData2 { get; set; } = "";
            public string ResponseData3 { get; set; } = "";

            public string TransactionDate { get; set; }
            public string TransactionNumber { get; set; }
            public object UserFields { get; set; }

            public ResponseData ResponseData { get; set; }

            public string MiriAccountNumberBase31 { get; set; }

            public string UserProfileNumber { get; set; }
        }





        public class MiriCardTransactionRestResponse
        {
            public string StatusCode { get; set; }
            public string StatusMessage { get; set; }
            public string AccountBin { get; set; }
            public string AccountDisplayMonth { get; set; }
            public string AccountDisplayYear { get; set; }
            public string AccountFirstName { get; set; }
            public string AccountLastName { get; set; }
            public string AccountMiddleName { get; set; }
            public string AccountSwapData { get; set; }
            public string MerchantID { get; set; }
            public string MiriAccountNumberB10 { get; set; }
            public string MiriAccountNumberB21 { get; set; }
            public string MiriAccountNumberB31 { get; set; }
            public string MiriDynamicNumber { get; set; }
            public string NameOnCard { get; set; }
            public string ResponseData1 { get; set; } = "";
            public string ResponseData2 { get; set; } = "";
            public string ResponseData3 { get; set; } = "";

            public string TransactionDate { get; set; }
            public string TransactionNumber { get; set; }
            public object UserFields { get; set; }

            public ResponseData ResponseData { get; set; }

            public string MiriAccountNumberBase31 { get; set; }

            public string UserProfileNumber { get; set; }
        }









        public class AccountCheckResponse
        {
            public string StatusCode;
            public string StatusMessage;
        }


        public class MiriTransactionV3ResponseResult
        {
            public string StatusCode;
            public string StatusMessage;
            public string AccountBin;
            public string AccountFirstName;
            public string AccountLastName;
            public string AccountMiddleName;
            public string MiriAccountNumberB31;
            public string TransactionDate;
            public string TransactionNumber;

        }



        public class ActivationStepOneResponse
        {
            public string StatusCode;
            public string StatusMessage;
            public string ActivationTicket;
            public string EncoderToken;
            public string InstitutionName;
        }

        public class ActivationStepTwoResponse
        {
            public string StatusCode;
            public string StatusMessage;
            public string ApplicationDisplayName;
            public string SeedData;
            public string UserFullName;
            public string IssuerName;
        }
        public class ActivationStepThreeResponse
        {
            public string StatusCode;
            public string StatusMessage;
            public string UserFullName;
            public string XmlTemplate;
            public string UserXml;
            public string UserProfileImage;
        }




        public AccountCheckResponse AccountCheckRequest(string ActivationCode, string MiriAccountNumber)
        {
            string action = "AccountCheckRequest";
            SoapHelper soap = new SoapHelper();
            soap.serviceType = "A";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ActivationCode", ActivationCode);
            parameters.Add("MiriAccountNumber", MiriAccountNumber);

            string response = soap.InvokeService(action, parameters);
            AccountCheckResponse res = new AccountCheckResponse();
            res.StatusCode = GetXmlValue(response, action, "StatusCode");
            res.StatusMessage = GetXmlValue(response, action, "StatusMessage");

            return res;
        }

        public MiriTokenChallengeResponseResult MiriTokenChallengeResponse(string identifier, string token, string challenge)
        {
            string action = "MiriTokenChallengeResponse";
            MiriTokenChallengeResponseResult res = new MiriTokenChallengeResponseResult();
            SoapHelper soap = new SoapHelper();
            soap.serviceType = "T";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("MiriIdentifier", identifier);
            parameters.Add("token", token);
            parameters.Add("challenge", challenge);
            string response = soap.InvokeService(action, parameters);

            res.StatusCode = GetXmlValue(response, action, "StatusCode");
            res.StatusMessage = GetXmlValue(response, action, "StatusMessage");
            res.AccountFirstName = GetXmlValue(response, action, "AccountFirstName");
            res.AccountLastName = GetXmlValue(response, action, "AccountLastName");
            res.TransactionDate = GetXmlValue(response, action, "TransactionDate");
            res.TransactionNumber = GetXmlValue(response, action, "TransactionNumber");

            return res;

        }
        public ServiceCheckResponse ServiceCheck(string serviceType)
        {
            SoapHelper soap = new SoapHelper();
            soap.serviceType = serviceType;
            string response = soap.InvokeService("ServiceCheck", null);
            ServiceCheckResponse res = new ServiceCheckResponse();
            res.StatusCode = GetXmlValue(response, "ServiceCheck", "StatusCode");
            res.StatusMessage = GetXmlValue(response, "ServiceCheck", "StatusMessage");
            return res;
        }


        public MiriIdTransactionResult MiriIdTransaction(string MiriId)
        {
            string action = "MiriIDTransaction";
            SoapHelper soap = new SoapHelper(applianceurl);
            soap.serviceType = "T";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("NumberToVerify", MiriId);

            string response = soap.InvokeService(action, parameters);
            MiriIdTransactionResult res = new MiriIdTransactionResult();
            res.StatusCode = GetXmlValue(response, action, "StatusCode");
            res.StatusMessage = GetXmlValue(response, action, "StatusMessage");

            res.AccountFirstName = GetXmlValue(response, action, "AccountFirstName");
            res.AccountLastName = GetXmlValue(response, action, "AccountLastName");
            res.MiriAccountNumberB31 = GetXmlValue(response, action, "MiriAccountNumberB31");
            res.ResponseData1 = GetXmlValue(response, action, "ResponseData1");
            res.ResponseData2 = GetXmlValue(response, action, "ResponseData2");
            res.ResponseData3 = GetXmlValue(response, action, "ResponseData3");


            return res;
        }




        public MiriIdTransactionResult MiriIdTransactionRest(string MiriId)
        {
            try
            {

                //String url = applianceurl + @"/MIRISYSTEMS/Services/MIServiceDecoder/Verify/MiriId/" + MiriId;

               
                //String url = applianceurl + @"/MIRISYSTEMS/Services/MiriDecoderServices/MiriDecoderService.svc/Rest/MiriIDTransaction/" + MiriId;

                string url = "";
                RestHelper helper = new RestHelper();
                helper.applianceurl = applianceurl;
                string response = helper.Get(new Uri(url));

                Controllers.logging.WriteThis("response::"+response);

                MiriIdTransactionRestResponse obj = JsonConvert.DeserializeObject<MiriIdTransactionRestResponse>(response);

                Controllers.logging.WriteThis("obj::"+obj);


                MiriIdTransactionResult res = new MiriIdTransactionResult();
                res.StatusCode = obj.StatusCode;
                res.StatusMessage = obj.StatusMessage;

                if (res.StatusCode.Trim() == "0")

                {
                    res.AccountFirstName = obj.AccountFirstName;
                    res.AccountLastName = obj.AccountLastName;
                    res.MiriAccountNumberB31 = obj.MiriAccountNumberB31;
                    //res.MiriAccountNumberB31 = obj.MiriAccountNumberBase31;
                    res.ResponseData1 = obj.ResponseData1;
                    //  res.ResponseData = obj.ResponseData;
                    dynamic userfields = obj.UserFields;
                    if (userfields != null)
                    {
                        res.ResponseData2 = userfields[0].Value;
                        res.ResponseData3 = userfields[1].Value;
                    }

                   // ResponseData responseData = JsonConvert.DeserializeObject<ResponseData>(obj.ResponseData);


                    if (obj.ResponseData != null)
                    {
                        res.ResponseData1 = obj.ResponseData.ResponseData1;
                        res.ResponseData2 = obj.ResponseData.ResponseData2;
                        res.ResponseData3 = obj.ResponseData.ResponseData3;
                    }

                    //   res.ResponseData2 = obj.UserFields.ResponseData2;
                    //   res.ResponseData3 = obj.UserFields.ResponseData3;
                }



                return res;
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        public MiriTokenChallengeResponseResult MiriTokenTransactionRest(string identifier, string token)
        {
            String url = applianceurl + @"/MIRISYSTEMS/Services/MiriDecoderServices/MiriDecoderService.svc/Rest/MiriTokenTransaction/" + identifier + @"/" + token;

            RestHelper helper = new RestHelper();
            helper.applianceurl = applianceurl;
            string response = helper.Get(new Uri(url));
            MiriTokenTransactionRestResponse obj = JsonConvert.DeserializeObject<MiriTokenTransactionRestResponse>(response);
            MiriTokenChallengeResponseResult res = new MiriTokenChallengeResponseResult();
            res.StatusCode = obj.StatusCode;
            res.StatusMessage = obj.StatusMessage;

            res.AccountFirstName = obj.AccountFirstName;
            res.AccountLastName = obj.AccountLastName;
            res.MiriAccountNumberB31 = obj.MiriAccountNumberB31;
            res.ResponseData1 = obj.ResponseData1;

            dynamic userfields = obj.UserFields;
            if (userfields != null)
            {
                res.ResponseData2 = userfields[0].Value;
                res.ResponseData3 = userfields[1].Value;
            }

            if (obj.ResponseData != null)
            {
                res.ResponseData1 = obj.ResponseData.ResponseData1;
                res.ResponseData2 = obj.ResponseData.ResponseData2;
                res.ResponseData3 = obj.ResponseData.ResponseData3;
            }
            return res;
        }


        public MiriCardTransactionRestResponse MiriCardTransactionRest(string nameoncard, string cardnumber, string month,  string year, string cvv, string transactionid = "123", string merchantid="merchant123")
        {

            String url = applianceurl + @"/MIRISYSTEMS/Services/MiriDecoderServices/MiriDecoderService.svc/Rest/MiriCardTransaction/" + transactionid + @"/" + month+@"/" + year + @"/" + nameoncard + @"/" + cardnumber + @"/" + merchantid;

            RestHelper helper = new RestHelper();

            string response = helper.Get(new Uri(url));
            MiriCardTransactionRestResponse obj = JsonConvert.DeserializeObject<MiriCardTransactionRestResponse>(response);
            MiriCardTransactionRestResponse res = new MiriCardTransactionRestResponse();
            res.StatusCode = obj.StatusCode;
            res.StatusMessage = obj.StatusMessage;
            res.TransactionDate = obj.TransactionDate;
            res.TransactionNumber = obj.TransactionNumber;
            res.MiriAccountNumberB31 = obj.MiriAccountNumberB31;
           // res.MiriAccountNumberB31 = obj.MiriAccountNumberBase31;
            res.UserProfileNumber = obj.UserProfileNumber;
   

            dynamic userfields = obj.UserFields;
            if (userfields != null)
            {
                res.ResponseData2 = userfields[0].Value;
                res.ResponseData3 = userfields[1].Value;
            }

            if (obj.ResponseData != null)
            {
                res.ResponseData1 = obj.ResponseData.ResponseData1;
                res.ResponseData2 = obj.ResponseData.ResponseData2;
                res.ResponseData3 = obj.ResponseData.ResponseData3;
            }
            return res;
        }

        public MiriTransactionV3ResponseResult MiriCardTransactionRest(string firstname, string lastname, string number, string month, string year, string cvv)
        {
            string action = "MiriTransaction_V3";
            SoapHelper soap = new SoapHelper(applianceurl);
            soap.serviceType = "C";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("FirstName", firstname);
            parameters.Add("LastName", lastname);
            parameters.Add("NumberToVerify", number);
            parameters.Add("DisplayMonth", month);
            parameters.Add("DisplayYear", year);
            parameters.Add("CVV", cvv);

            string response = soap.InvokeService(action, parameters);
            MiriTransactionV3ResponseResult res = new MiriTransactionV3ResponseResult();
            res.StatusCode = GetXmlValue(response, action, "StatusCode");
            res.StatusMessage = GetXmlValue(response, action, "StatusMessage");
            res.AccountFirstName = GetXmlValue(response, action, "AccountFirstName");
            res.AccountLastName = GetXmlValue(response, action, "AccountLastName");
            res.MiriAccountNumberB31 = GetXmlValue(response, action, "MiriAccountNumberB31");

            return res;
        }


        public RegisterResponse RegisterUser(RegisterRequest req)
        {
            //  { "IssuerNumber": "37",   "ExpiryDate": "07/30/2020",  "ActivationFieldOne": "john",   "ActivationFieldTwo": "doe",   "AccountIssueDate": "07/30/2019", "LookUpDataOne": "john@manipal" }



            String url = applianceurl + @"/MIRISYSTEMS/Services/MiriUserManagementServices/UserManagementService.svc/rest/RegisterUser";

            RestHelper helper = new RestHelper();
            helper.applianceurl = applianceurl;

         
            string reqbody = JsonConvert.SerializeObject(req);


            string response = helper.Post(new Uri(url), reqbody);

            RegisterResponse res = JsonConvert.DeserializeObject<RegisterResponse>(response);


            return res;
        }


        public RegisterResponse ResetUserForCard(string OldActivationCode, string MiriAccountNumber, string cvvnumber2)
        {
            //  { "IssuerNumber": "37",   "ExpiryDate": "07/30/2020",   "ActivationFieldOne": "john",   "ActivationFieldTwo": "doe",   "AccountIssueDate": "07/30/2019", "LookUpDataOne": "john@manipal" }



            String url = applianceurl + @"/MIRISYSTEMS/Services/MiriUserManagementServices/UserManagementService.svc/rest/ResetUser";

            RestHelper helper = new RestHelper();
            helper.applianceurl = applianceurl;
            

            ResetRequest req = new ResetRequest();
            req.OldActivationCode = OldActivationCode;
            req.MiriAccountNumber = MiriAccountNumber;
            req.Cvv = cvvnumber2;

            string reqbody = JsonConvert.SerializeObject(req);


            string response = helper.Post(new Uri(url), reqbody);

            RegisterResponse res = JsonConvert.DeserializeObject<RegisterResponse>(response);


            return res;
        }

        public RegisterResponse ResetUser(string OldActivationCode, string MiriAccountNumber)
        {
            //  { "IssuerNumber": "37",   "ExpiryDate": "07/30/2020",   "ActivationFieldOne": "john",   "ActivationFieldTwo": "doe",   "AccountIssueDate": "07/30/2019", "LookUpDataOne": "john@manipal" }



            String url = applianceurl + @"/MIRISYSTEMS/Services/MiriUserManagementServices/UserManagementService.svc/rest/ResetUser";

            RestHelper helper = new RestHelper();
            helper.applianceurl = applianceurl;


            ResetRequest req = new ResetRequest();
            req.OldActivationCode = OldActivationCode;
            req.MiriAccountNumber = MiriAccountNumber;
            

            string reqbody = JsonConvert.SerializeObject(req);


            string response = helper.Post(new Uri(url), reqbody);

            RegisterResponse res = JsonConvert.DeserializeObject<RegisterResponse>(response);


            return res;
        }


        public RegisterResponse DeRegisterUser(string OldActivationCode, string MiriAccountNumber)
        {
            //  { "IssuerNumber": "37",   "ExpiryDate": "07/30/2020",   "ActivationFieldOne": "john",   "ActivationFieldTwo": "doe",   "AccountIssueDate": "07/30/2019", "LookUpDataOne": "john@manipal" }



            String url = applianceurl + @"/MIRISYSTEMS/Services/MiriUserManagementServices/UserManagementService.svc/rest/DeRegisterUser";

            RestHelper helper = new RestHelper();
            helper.applianceurl = applianceurl;

            ResetRequest req = new ResetRequest();
            req.OldActivationCode = OldActivationCode;
            req.MiriAccountNumber = MiriAccountNumber;
            string reqbody = JsonConvert.SerializeObject(req);


            string response = helper.Post(new Uri(url), reqbody);

            RegisterResponse res = JsonConvert.DeserializeObject<RegisterResponse>(response);


            return res;
        }


        private string GetXmlValue(string xml, string Node, string field)
        {

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);
            //  var nsmgr = new XmlNamespaceManager(xmlDocument.NameTable);
            //  nsmgr.AddNamespace("s", "http://schemas.xmlsoap.org/soap/envelope/");
            //  //Create a XML Node List with XPath Expression  
            ////  XmlNodeList xmlNodeList = xmlDocument.SelectNodes(Node,nsmgr);
            XmlNodeList nodes = xmlDocument.GetElementsByTagName(Node + "Result");
            string value = nodes[0][field].InnerText;
            return value;
        }



        public ActivationStepOneResponse ActivationStepOneRequest(string actcode)
        {
            string action = "ActivationStepOneRequest";
            SoapHelper soap = new SoapHelper(applianceurl);
            soap.serviceType = "A";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ActivationCode", actcode);

            string response = soap.InvokeService(action, parameters);
            ActivationStepOneResponse res = new ActivationStepOneResponse();
            res.StatusCode = GetXmlValue(response, action, "StatusCode");
            res.StatusMessage = GetXmlValue(response, action, "StatusMessage");

            res.ActivationTicket = GetXmlValue(response, action, "ActivationTicket");
            res.EncoderToken = GetXmlValue(response, action, "EncoderToken");
            res.InstitutionName = GetXmlValue(response, action, "InstitutionName");
            //   res.Response1 = GetXmlValue(response, action, "ResponseData");
            return res;

        }



        public ServiceCheckResponse ServiceCheck()
        {
            String url = applianceurl + @"/MIRISYSTEMS/Services/MiriDecoderServices/MiriDecoderService.svc/Rest/ServiceCheck";

            RestHelper helper = new RestHelper();
            helper.applianceurl = applianceurl;
            string response = helper.Get(new Uri(url));

            ServiceCheckResponse res=  JsonConvert.DeserializeObject<ServiceCheckResponse>(response);
            return res;

        }
        

        public ActivationStepTwoResponse ActivationStepTwoRequest(string ticket, string fieldonetwo, string password, string deviceid, string devicetype, string nickname)
        {
            string action = "ActivationStepTwoRequest";
            SoapHelper soap = new SoapHelper(applianceurl);
            soap.serviceType = "A";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ActivationTicket", ticket);
            parameters.Add("FieldOneTwo", fieldonetwo);
            parameters.Add("ApplicationPassword", password);
            parameters.Add("DeviceId", deviceid);
            parameters.Add("DeviceType", devicetype);
            parameters.Add("NickName", nickname);


            string response = soap.InvokeService(action, parameters);
            ActivationStepTwoResponse res = new ActivationStepTwoResponse();
            res.StatusCode = GetXmlValue(response, action, "StatusCode");
            res.StatusMessage = GetXmlValue(response, action, "StatusMessage");

            res.ApplicationDisplayName = GetXmlValue(response, action, "ApplicationDisplayName");
            res.IssuerName = GetXmlValue(response, action, "IssuerName");
            res.SeedData = GetXmlValue(response, action, "SeedData");
            res.UserFullName = GetXmlValue(response, action, "UserFullName");
            //   res.Response1 = GetXmlValue(response, action, "ResponseData");
            return res;

        }



        public ActivationStepThreeResponse ActivationStepThreeRequest(string actcode)
        {
            string action = "ActivationStepThreeRequest";
            SoapHelper soap = new SoapHelper(applianceurl);
            soap.serviceType = "A";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ActivationCode", actcode);
            parameters.Add("Width", "508");
            parameters.Add("Height", "320");
            parameters.Add("DeviceType", "I");


            string response = soap.InvokeService(action, parameters);
            ActivationStepThreeResponse res = new ActivationStepThreeResponse();
            res.StatusCode = GetXmlValue(response, action, "StatusCode");
            res.StatusMessage = GetXmlValue(response, action, "StatusMessage");

            res.XmlTemplate = GetXmlValue(response, action, "XmlTemplate");
            res.UserXml = GetXmlValue(response, action, "UserXML");
            res.UserFullName = GetXmlValue(response, action, "UserFullName");

            XmlDocument xDoc = new XmlDocument();
            // Load Xml
            // xDoc.LoadXml(res.XmlTemplate);
            // XmlNodeList nodes = xDoc.SelectNodes("//img[@name='UserPhoto']");
            xDoc.LoadXml(res.UserXml);
            XmlNodeList nodes = xDoc.SelectNodes("//row[@name='UserPhoto']");


            //   res.Response1 = GetXmlValue(response, action, "ResponseData");
            if (nodes != null && nodes.Count > 0 && nodes[0].Attributes["value"] != null)
            {
                //  string base64image = nodes[0].Attributes["src"].Value.Substring(nodes[0].Attributes["src"].Value.IndexOf(',')+1);
                string base64image = nodes[0].Attributes["value"].Value.Trim();
                res.UserProfileImage = base64image;
            }
            return res;

        }



        public class RegisterResponse
        {
            public string ActivationCode;
            public string MiriAccountNumber;
            public string StatusCode;
            public string StatusMessage;
            public string UserProfileId;
            public string ResponseDataOne;
        }

        public class ResetRequest
        {
            public string OldActivationCode;
            public string MiriAccountNumber;
            public string StatusCode;
            public string StatusMessage;
            public string Cvv;

        }

        public class ResetResponse
        {
            public string ActivationCode;
            public string StatusCode;
            public string StatusMessage;

        }


        public class DeregisterResponse
        {
            public string ActivationCode;
            public string StatusCode;
            public string StatusMessage;

        }

        public class ServiceCheckResponse
        {
            public string StatusCode;
            public string StatusMessage;
            public string wsVersion;
            public string Created;
            public string DatabaseStatus;

        }


      







    }


}
