using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;

namespace MtlMiriDemo_V1.MTLMiriLib
    {
  public class RestHelper
    {

        public string applianceurl = "https://mmauth.com";

        public string Post(Uri url, string value)
        {
            var request = HttpWebRequest.Create(url);
            var byteData = Encoding.ASCII.GetBytes(value);
            request.ContentType = "application/json";
            request.Method = "POST";

            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(byteData, 0, byteData.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                if (response != null)
                    {
                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    //Controllers.logging.WriteThis("Request RestHelper returned:"+responseString);

                    return responseString;
                    }
                else
                    {
                    string newStr = "Could not get the response";
                    return newStr;
                    }
              
            }
            catch (WebException e)
            {
                Controllers.logging.WriteThis("Request RestHelper returned:" + e.Message);

                return null;
            }
        }

        public string Get(Uri url)
        {
            var request = HttpWebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "GET";

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                if (response != null) {
                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    Controllers.logging.WriteThis(responseString);
                    return responseString;
                    }
                else
                    { string newStr = "Could not get the response"; return newStr; }
           
            }
            catch (WebException ex)
            {
                return null;
            }
        }


    }


}
