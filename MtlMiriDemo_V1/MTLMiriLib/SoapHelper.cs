using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;

namespace MtlMiriDemo_V1.MTLMiriLib
    {
   public class SoapHelper
    {
        public string applianceurl;
        string activation_service = @"https://mmauth.com/MIRISYSTEMS/Services/ClientAppServices/ClientAppService.svc";
        string transaction_service = @"https://mmauth.com/MIRISYSTEMS/Services/MiriDecoderServices/MiriDecoderService.svc/soap";
        string card_service = @"https://mmauth.com/MIRISYSTEMS/Services/MiriDecoderServices/MiriDecoderService.svc/soap";


        public SoapHelper(string appurl = @"https://mmcpayment.com")
        {
            applianceurl = appurl;


            activation_service = appurl + @"/MIRISYSTEMS/Services/ClientAppServices/ClientAppService.svc";
            transaction_service = appurl + @"/MIRISYSTEMS/Services/MiriDecoderServices/MiriDecoderService.svc/soap";
            card_service = appurl + @"/MIRISYSTEMS/Services/MiriDecoderServices/MiriDecoderService.svc/soap";
        }


        public string serviceType = "";
        string prefix = "cli";

        public Dictionary<string, string> soapParams = new Dictionary<string, string>();
        public string InvokeService(string ActionName, Dictionary<string, string> parameters)
        {
            //Calling CreateSOAPWebRequest method  
            HttpWebRequest request = CreateSOAPWebRequest(ActionName, serviceType);
            if (serviceType == "T" || serviceType == "C") { prefix = "dec"; }
            XmlDocument SOAPReqBody = new XmlDocument();

            string paramlist = "";
            if (parameters != null)
            {
                foreach (string key in parameters.Keys)
                {
                    paramlist += "<" + prefix + ":" + key + ">" + parameters[key] + @"</" + prefix + ":" + key + ">";
                }
            }
            //SOAP Body Request  
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:dec=""http://mirisystemsapps.com/decoderservices/"" xmlns:cli=""http://mirisystemsapps.com/clientappservices/"">  
 <soapenv:Header/>             
 <soapenv:Body><" + prefix + ":" + ActionName + @">" +
      paramlist +
      @"</" + prefix + ":" + ActionName + @">
   </soapenv:Body>
</soapenv:Envelope>");


            /*
             
             *<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:cli="http://mirisystemsapps.com/clientappservices/">
   <soapenv:Header/>
   <soapenv:Body>
      <cli:ServiceCheck/>
   </soapenv:Body>
</soapenv:Envelope>
             */

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request  
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream  
                    var ServiceResult = rd.ReadToEnd();
                    //writting stream result on console  
                    return ServiceResult;

                }
            }
        }

        public HttpWebRequest CreateSOAPWebRequest(String ActionName, string Type)
        {
            //Making Web Request  
            HttpWebRequest Req;
            if (Type == "A")
            {
                Req = (HttpWebRequest)WebRequest.Create(activation_service);
                Req.Headers.Add(@"SOAPAction:http://mirisystemsapps.com/clientappservices/IClientAppService/" + ActionName);

                // Req.Headers.Add(@"SOAPAction:https://mirisystemsapps.com/clientappservices/IClientAppService" + ActionName);
            }
            else if (Type == "C")

            {
                Req = (HttpWebRequest)WebRequest.Create(card_service);
                Req.Headers.Add(@"SOAPAction:http://mirisystemsapps.com/decoderservices/IMiriDecoderService/" + ActionName);

            }
            else

            {
                Req = (HttpWebRequest)WebRequest.Create(transaction_service);
                Req.Headers.Add(@"SOAPAction:http://mirisystemsapps.com/decoderservices/IMiriDecoderService/" + ActionName);

            }

            //SOAPAction  

            //Content_type  
            Req.ContentType = "text/xml;charset=\"utf-8\"";
            Req.Accept = "text/xml";
            //HTTP method  
            Req.Method = "POST";
            //return HttpWebRequest  
            return Req;
        }

    }

}
