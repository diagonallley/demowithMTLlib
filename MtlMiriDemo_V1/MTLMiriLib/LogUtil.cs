using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;


namespace MtlMiriDemo_V1.MTLMiriLib
    {
    public class LogUtil
    {


       


        public void WriteToDb(string logtype, string data1, string data2, DateTime logtime)
        {
            try
            {
                SqlHelper sql = new SqlHelper();
                sql.ClearParameters();

                sql.AddParameterToSQLCommand("@logtype", SqlDbType.VarChar);

                sql.AddParameterToSQLCommand("@data1", SqlDbType.VarChar);
                sql.AddParameterToSQLCommand("@data2", SqlDbType.VarChar);
                sql.AddParameterToSQLCommand("@logtime", SqlDbType.DateTime);

                sql.SetSQLCommandParameterValue("@logtype", logtype);
                sql.SetSQLCommandParameterValue("@data1", data1);
                sql.SetSQLCommandParameterValue("@data2", data2);
                sql.SetSQLCommandParameterValue("@logtime", logtime);

                sql.GetExecuteNonQueryByCommand("insert_servicelog");
            }
            catch (Exception ex)
            {

            }

        }
        public void WriteToFile(string Message, string Filename = "GeneralLog")
        {
            try
            {
                string path = "\\Logs";
                // string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string filepath = "\\Logs\\" + Filename + "_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
                if (!File.Exists(filepath))
                {
                    // Create a file to write to.   
                    using (StreamWriter sw = File.CreateText(filepath))
                    {
                        sw.WriteLine(Message);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        sw.WriteLine(Message);
                    }
                }
            }

            catch (Exception ex)
            {

            }

        }

    }
}
