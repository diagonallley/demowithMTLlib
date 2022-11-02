using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MtlMiriDemo_V1.MTLMiriLib
    {
  public class ConfigHelper
    {
        //  string val=System.Configuration.ConfigurationManager.AppSettings["StartingMonthColumn"];

        //static string server = "DEV";
        static string server = ConfigurationManager.AppSettings["SERVER"];

      
        static public string GetIdIssuer()
        {
            GetServer();
            string val = ConfigurationManager.AppSettings[server+ "_ID_ISSUER"];
            return val;
        }
        static public string GetTokenIssuer()
        {
            GetServer();
            string val = ConfigurationManager.AppSettings[server + "_TOKEN_ISSUER"];
            return val;
        }

        static public string GetVisaCardIssuer()
        {
            GetServer();
            string val = ConfigurationManager.AppSettings[server + "_CARD_VISA_ISSUER"];
            return val;
        }
        static public string GetMasterCardIssuer()
        {
            GetServer();
            string val = ConfigurationManager.AppSettings[server + "_CARD_MASTER_ISSUER"];
            return val;
        }
        static public string GetRupayCardIssuer()
        {
            GetServer();
            string val = ConfigurationManager.AppSettings[server + "_CARD_RUPAY_ISSUER"];
            return val;
        }
        static public string GetServer()
        { 
            string val = ConfigurationManager.AppSettings["SERVER"];
            server = val;
            return val;
        }

        static public string GetConnectionString()
        {
            GetServer();
            //server val=dev;`
            string val = ConfigurationManager.AppSettings[server+ "_CONSTR"];
            return val;
        }

        static public string GetValidationDomain()
        {
            GetServer();
            string val = ConfigurationManager.AppSettings[server + "_LOGINVALIDATION"];
            return val;
        }

        static public string GetDomain()
        {
            GetServer();
            string val = ConfigurationManager.AppSettings[server + "_DOMAIN"];
            return val;
        }

    }
}
