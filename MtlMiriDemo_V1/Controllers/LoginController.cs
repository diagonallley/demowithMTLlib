using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft;
using System.Data.SqlClient;
//using MTLMiriLib;
using MtlMiriDemo_V1.MTLMiriLib;
using System.IO;

namespace MtlMiriDemo_V1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult SignOut()
        {
            Session.Abandon();
            Session.Clear();
            Response.Cookies.Clear();
            Session.RemoveAll();
            Session["userid"] = null;
            return RedirectToAction("Index", "Login");
            
        }
       // [OutputCache(NoStore = true, Duration = 0)]
        private bool ValidateAdminUser(string userid)
        {
            try { 
            string empid = "";
            string name = "";
            string designation = "";
            string email = "";
            string mobile = "";
            string usertype = "";
            SqlHelper sql = new SqlHelper();
            // DataSet ds = sql.GetDatasetByCommand("get_employee");
            sql.AddParameterToSQLCommand("@userid", SqlDbType.VarChar);
            sql.SetSQLCommandParameterValue("@userid", userid);

            DataSet ds = sql.GetDatasetByCommand("Users_Validate");
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
            {
                userid = ds.Tables[0].Rows[0]["userid"].ToString().Trim();
                name = ds.Tables[0].Rows[0]["name"].ToString().Trim();
                designation = ds.Tables[0].Rows[0]["designation"].ToString().Trim();
                email = ds.Tables[0].Rows[0]["email"].ToString().Trim();
                mobile = ds.Tables[0].Rows[0]["mobile"].ToString().Trim();
                usertype = ds.Tables[0].Rows[0]["usertype"].ToString().Trim();
                Session["name"] = name;
                Session["designation"] = designation;
                Session["email"] = email;
                Session["mobile"] = mobile;
                Session["userid"] = userid;
                Session["usertype"] = usertype;
                return true;
            }
            else
            {
                return false;
            }
            }
            catch(Exception ex)
            {

                ExceptionLogging.SendExcepToDB(ex);
                return false;
            }

        }
        public string ValidateAdminMiriID(string id)
        {
            try
            {
                System.Threading.Thread.Sleep(1000);

                string validationurl = ConfigHelper.GetValidationDomain();

                //MiriHelper miri = new MiriHelper("https://mmauth.com");
                MiriHelper miri = new MiriHelper(validationurl);
                id = id.Replace("-", "");
                id = id.Replace(" ", "");
            
            MiriHelper.MiriIdTransactionResult res = miri.MiriIdTransactionRest(id);
                //logging.WriteThis(res);



                LogApiResponse(res.ResponseData1,res.AccountFirstName,res.AccountLastName,res.MiriAccountNumberB31,res.StatusCode,res.StatusMessage);

            if (res != null && res.StatusCode == "0")
            {
                string accountnumber = res.MiriAccountNumberB31;
                string responsedata1 = res.ResponseData1;
                Session["userid"] = responsedata1.ToString();

                if (ValidateAdminUser(responsedata1.ToString()))
                {
                    return "000:Valid User";
                }
                else
                {
                    return "001:INVALID:User not found";
                }
            }

            else if (res != null && res.StatusCode == "536")

            {
                return "004:Fraud Alert";
            }

            else
            {
                return "002:INVALID:Invalid MIRI ID";
            }
            }
            catch (Exception ex)
            {
                logging.WriteThis(ex.Message);

                ExceptionLogging.SendExcepToDB(ex);
                return "003:INVALID:Database Connection Issue" + ex;


            }

        }

        public void LogApiResponse(string Userid,string FirstName, string LastName, string AccountNumber,string StatusCode, string StatusMessage)
        {
            try
            {
                SqlHelper sql = new SqlHelper();
                sql.AddParameterToSQLCommand("@UserID", SqlDbType.VarChar);
                sql.SetSQLCommandParameterValue("@UserID", Userid);
                sql.AddParameterToSQLCommand("@UserName", SqlDbType.VarChar);
                sql.SetSQLCommandParameterValue("@UserName", FirstName);
                sql.AddParameterToSQLCommand("@UserLastName", SqlDbType.VarChar);
                sql.SetSQLCommandParameterValue("@UserLastName", LastName);
                sql.AddParameterToSQLCommand("@MiriAccountNumber", SqlDbType.VarChar);
                sql.SetSQLCommandParameterValue("@MiriAccountNumber", AccountNumber);
                sql.AddParameterToSQLCommand("@StatusCode", SqlDbType.VarChar);
                sql.SetSQLCommandParameterValue("@StatusCode", StatusCode);
                sql.AddParameterToSQLCommand("@StatusMessage", SqlDbType.VarChar);
                sql.SetSQLCommandParameterValue("@StatusMessage", StatusMessage);
                int r = sql.GetExecuteNonQueryByCommand("LogApiLogin");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
            }
        }
    }
}