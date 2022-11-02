using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using context = System.Web.HttpContext;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web;

namespace MtlMiriDemo_V1.MTLMiriLib
    {
    public static class ExceptionLogging
    {

        private static String exepurl;

        public static void SendExcepToDB(Exception exdb)
        {


            SqlConnection con = new SqlConnection(ConfigHelper.GetConnectionString());
            //server=dev;
            // connecttion();
            //System.Web.HttpContext currentContext = System.Web.HttpContext.Current;
            SqlHelper sql = new SqlHelper();
            exepurl = context.Current.Request.Url.ToString();
            SqlCommand com = new SqlCommand("ExceptionLoggingToDataBase", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ExceptionMsg", exdb.Message.ToString());
            com.Parameters.AddWithValue("@ExceptionType", exdb.GetType().Name.ToString());
            com.Parameters.AddWithValue("@ExceptionURL", exepurl);
            com.Parameters.AddWithValue("@ExceptionSource", exdb.StackTrace.ToString());
            try
            {
                con.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }


        }

    }
}
