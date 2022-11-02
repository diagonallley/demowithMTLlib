using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtlMiriDemo_V1.MTLMiriLib
    {
  public class LogHelper

    {

        List<ActivityLog> activityLogs;


        public class ActivityLog
        {
            public string ip;
            public string id;
            public string user_agent;
            public string sessionid;
            public string statuscode;
            public string statusmessage;
            public string mirinumber;
            public string status;
            public string remark;
            public string username;
            public string activity;
            public DateTime date;
            public string miri_account_no;
            public string profile_number;
            public string productcode;
            public string LoginId;
            public string UserName;
            public string LoginDate;
            public string FirstName;
            public string LastName;
            public string Email;
            public string Designation;
            public string Mobile;
            public string Product;
            public string Company;
            public string RegistrationDate;

        }

        public class MiriTransactionLog
        {
            public string ip;
            public string id;
            public string user_agent;
            public string sessionid;
            public string statuscode;
            public string statusmessage;
            public string mirinumber;
            public string status;
            public string remark;
            public string username;
            public DateTime date;
            public string miri_account_no;
            public string profile_number;
            public string nameoncard;
            public string expiry;
            public string cvv;
            public string productcode;


        }

        public class MiriActivationLog
        {
            public string ip;
            public string id;
            public string user_agent;
            public string sessionid;
            public string statuscode;
            public string statusmessage;
            public string activationcode;
            public string status;
            public string remark;
            public string userid;
            public DateTime date;
            public string miri_account_no;
            public string profile_number;
        }



        public void LogTransactionToDb(MiriTransactionLog logdata)
        {
            try
            {
                SqlHelper sql = new SqlHelper();
                sql.AddParameterToSQLCommand("@ip", SqlDbType.VarChar);
                sql.AddParameterToSQLCommand("@user_agent", SqlDbType.VarChar);
                sql.AddParameterToSQLCommand("@sessionid", SqlDbType.VarChar);
                //  sql.AddParameterToSQLCommand("@challenge_code", SqlDbType.VarChar);
                sql.AddParameterToSQLCommand("@mirinumber", SqlDbType.VarChar);
                sql.AddParameterToSQLCommand("@statuscode", SqlDbType.VarChar);
                sql.AddParameterToSQLCommand("@statusmessage", SqlDbType.VarChar);
                sql.AddParameterToSQLCommand("@remark", SqlDbType.VarChar);
                sql.AddParameterToSQLCommand("@userid", SqlDbType.VarChar);
                sql.AddParameterToSQLCommand("@transaction_date", SqlDbType.DateTime);
                sql.AddParameterToSQLCommand("@miri_account_no", SqlDbType.VarChar);
                sql.AddParameterToSQLCommand("@expiry", SqlDbType.VarChar);
                sql.AddParameterToSQLCommand("@nameoncard", SqlDbType.VarChar);
                sql.AddParameterToSQLCommand("@cvv", SqlDbType.VarChar);
                sql.AddParameterToSQLCommand("@productcode", SqlDbType.VarChar);

                sql.SetSQLCommandParameterValue("@ip", logdata.ip);
                sql.SetSQLCommandParameterValue("@user_agent", logdata.user_agent);
                sql.SetSQLCommandParameterValue("@sessionid", logdata.sessionid);
                //  sql.AddParameterToSQLCommand("@challenge_code", SqlDbType.VarChar);
                sql.SetSQLCommandParameterValue("@mirinumber", logdata.mirinumber);
                sql.SetSQLCommandParameterValue("@statuscode", logdata.statuscode);
                sql.SetSQLCommandParameterValue("@statusmessage", logdata.statusmessage);
                sql.SetSQLCommandParameterValue("@remark", logdata.remark);
                sql.SetSQLCommandParameterValue("@userid", logdata.username);
                sql.SetSQLCommandParameterValue("@transaction_date", DateTime.Now);
                sql.SetSQLCommandParameterValue("@miri_account_no", logdata.miri_account_no);
                sql.SetSQLCommandParameterValue("@expiry", logdata.expiry);
                sql.SetSQLCommandParameterValue("@nameoncard", logdata.nameoncard);
                sql.SetSQLCommandParameterValue("@cvv", logdata.cvv);
                sql.SetSQLCommandParameterValue("@productcode", logdata.productcode);

                sql.GetExecuteScalarByCommand("insert_log_miri_transaction");

            }
            catch (Exception ex)
            {


            }
        }

        public void LogActivationToDb(MiriTransactionLog logdata)
        {
            try
            {
                SqlHelper sql = new SqlHelper();
                sql.AddParameterToSQLCommand("@ip", SqlDbType.VarChar);
                sql.AddParameterToSQLCommand("@user_agent", SqlDbType.VarChar);
                sql.AddParameterToSQLCommand("@sessionid", SqlDbType.VarChar);
                //  sql.AddParameterToSQLCommand("@challenge_code", SqlDbType.VarChar);
                sql.AddParameterToSQLCommand("@miriid", SqlDbType.VarChar);
                sql.AddParameterToSQLCommand("@status", SqlDbType.VarChar);
                sql.AddParameterToSQLCommand("@remark", SqlDbType.VarChar);
                sql.AddParameterToSQLCommand("@userid", SqlDbType.VarChar);
                sql.AddParameterToSQLCommand("@date", SqlDbType.DateTime);
                sql.AddParameterToSQLCommand("@miri_account_no", SqlDbType.VarChar);


                sql.SetSQLCommandParameterValue("@ip", logdata.ip);

                sql.SetSQLCommandParameterValue("@user_agent", logdata.user_agent);
                //  sql.SetSQLCommandParameterValue("@challenge_code", challenge_code);

                sql.SetSQLCommandParameterValue("@sessionid", logdata.sessionid);
                sql.SetSQLCommandParameterValue("@miriid", logdata.mirinumber);
                sql.SetSQLCommandParameterValue("@status", logdata.status);
                sql.SetSQLCommandParameterValue("@remark", logdata.remark);
                sql.SetSQLCommandParameterValue("@username", logdata.username);
                sql.SetSQLCommandParameterValue("@date", logdata.date);
                sql.SetSQLCommandParameterValue("@miri_account_no", logdata.miri_account_no);
                sql.GetExecuteScalarByCommand("insert_log_miri_transaction");
            }
            catch (Exception ex)
            {


            }
        }

        public List<ActivityLog> GetActivityLog(string userid = "")
        {
            try
            {
                activityLogs = new List<ActivityLog>();
                SqlHelper sql = new SqlHelper();
                //  DataSet ds=   sql.GetDatasetByCommand("Select fullname,miri_account_no from miri_account where " +
                //      "username='" + this.UserName + "' and password ='"+ password + "'");
                if (userid != "")
                {
                    sql.AddParameterToSQLCommand("@userid", SqlDbType.VarChar);
                    //  sql.AddParameterToSQLCommand("@password", SqlDbType.VarChar);
                    sql.SetSQLCommandParameterValue("@userid", userid);
                    // sql.SetSQLCommandParameterValue("@empid", );
                }
                DataSet ds = sql.GetDatasetByCommand("get_log_activity");
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {


                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        ActivityLog data = new ActivityLog();

                        //data.activity = r["activity"] != null ? r["activity"].ToString().Trim() : "";
                        //if (r["activity_date"] != null) data.date = Convert.ToDateTime(r["activity_date"]);
                        //data.username = r["userid"] != null ? r["userid"].ToString().Trim() : "";
                        //data.mirinumber = r["mirinumber"] != null ? r["mirinumber"].ToString().Trim() : "";
                        //data.miri_account_no = r["miri_account_no"] != null ? r["miri_account_no"].ToString().Trim() : "";
                        //data.user_agent = r["user_agent"] != null ? r["user_agent"].ToString().Trim() : "";


                        //data.statuscode = r["statuscode"] != null ? r["statuscode"].ToString().Trim() : "";
                        //data.statusmessage = r["statusmessage"] != null ? r["statusmessage"].ToString().Trim() : "";
                        data.LoginId = r["LoginId"].ToString().Trim();
                        data.UserName = r["UserName"].ToString().Trim();
                        data.LoginDate = r["LoginDate"].ToString().Trim();
                        data.FirstName = r["FirstName"].ToString().Trim();
                        data.LastName = r["LastName"].ToString().Trim();
                        data.Email = r["Email"].ToString().Trim();
                        data.Mobile = r["Mobile"].ToString().Trim();
                        data.Designation = r["Designation"].ToString().Trim();
                        data.Company = r["Company"].ToString().Trim();
                        data.RegistrationDate = r["RegistrationDate"].ToString().Trim();
                        data.Product = r["Product"].ToString().Trim();
                        activityLogs.Add(data);

                    }
                }

                return activityLogs;


            }
            catch (Exception ex)
            {
                return null;

            }
        }


    }
}
