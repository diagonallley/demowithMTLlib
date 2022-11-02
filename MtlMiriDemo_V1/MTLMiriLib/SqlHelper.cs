using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MtlMiriDemo_V1.MTLMiriLib
    {
    public class SqlHelper
    {
        public static string ConnectionString;
        private SqlConnection objSqlConnection;
        private SqlCommand objSqlCommand;
        private int CommandTimeout = 30;
        static public string LocalSqlIP;
        static public string LocalSqlDb;
        public static string constr;
        static private string SyncDbIP;
        static public string SyncDbName;

        public enum ExpectedType
        {

            StringType = 0,
            NumberType = 1,
            DateType = 2,
            BooleanType = 3,
            ImageType = 4
        }
        
        public SqlHelper()
        {
            try
            {
                //ConnectionString = "Data Source = 172.27.15.26; Initial Catalog = MiriDemoSuite; Persist Security Info = True; User ID = sa; Password = P@ssword12;"; // Vinay 
                //ConnectionString = "Data Source = 10.13.146.7,21443; Initial Catalog = MTLMiriDemo; Persist Security Info = True; User ID = sqladmin; Password = P@ssword12;"; // Vinay 
                //ConnectionString = "Data Source = 10.13.146.7,21443; Initial Catalog = MTLMiriDemo; Persist Security Info = True; User ID = sqladmin; Password = P@ssword12;"; // Vinay 
                //ConnectionString = "Data Source = (local); Initial Catalog = MTLMiriDemo; Persist Security Info = True; User ID = sa; Password = P@ssword12;"; // Vinay 
                //ConnectionString = "Data Source = LAPTOP-ERIFFO7F; Initial Catalog = MTLMiriDemo; Persist Security Info = True; User ID = sa; Password = 12345;"; // Sushil

                ConnectionString = ConfigHelper.GetConnectionString();
                objSqlConnection = new SqlConnection(ConnectionString);
                objSqlCommand = new SqlCommand();
                objSqlCommand.Parameters.Clear();
                objSqlCommand.CommandTimeout = CommandTimeout;
                objSqlCommand.Connection = objSqlConnection;

                //ParseConnectionString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error initializing data class." + Environment.NewLine + ex.Message);
            }
        }


      


        public void Dispose()
        {
            try
            {
                //Clean Up Connection Object
                if (objSqlConnection != null)
                {
                    if (objSqlConnection.State != ConnectionState.Closed)
                    {
                        objSqlConnection.Close();
                    }
                    objSqlConnection.Dispose();
                }

                //Clean Up Command Object
                if (objSqlCommand != null)
                {
                    objSqlCommand.Dispose();
                }

            }

            catch (Exception ex)
            {
                throw new Exception("Error disposing data class." + Environment.NewLine + ex.Message);
            }

        }
        public void OpenConnection()
        {
            if (objSqlConnection.State != ConnectionState.Open) objSqlConnection.Open();
        }
        public void ClearParameters()
        {
            objSqlCommand.Parameters.Clear();
        }
        public void CloseConnection()
        {
            if (objSqlConnection.State != ConnectionState.Closed) objSqlConnection.Close();
        }
        public object GetExecuteScalarByCommand(string Command)
        {

            object obj = 0;
            try
            {
                objSqlCommand.CommandText = Command;
                objSqlCommand.CommandTimeout = CommandTimeout;
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //objSqlConnection.Open();
                OpenConnection();
                objSqlCommand.Connection = objSqlConnection;
                obj = objSqlCommand.ExecuteScalar();
                CloseConnection();
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
            return obj;
        }

        public int GetExecuteNonQueryByCommand(string Command)
        {
            try
            {
                int rowsaffected = 0;
                objSqlCommand.CommandText = Command;
                objSqlCommand.CommandTimeout = CommandTimeout;
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                // objSqlConnection.Open();
                OpenConnection();
                objSqlCommand.Connection = objSqlConnection;
                rowsaffected = objSqlCommand.ExecuteNonQuery();

                CloseConnection();
                return rowsaffected;
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
        }

        public int GetExecuteNonQueryBySQL(string query)
        {
            int rowsaffected = 0;
            try
            {
                objSqlCommand.CommandText = query;
                objSqlCommand.CommandTimeout = CommandTimeout;
                objSqlCommand.CommandType = CommandType.Text;

                // objSqlConnection.Open();
                OpenConnection();
                objSqlCommand.Connection = objSqlConnection;
                rowsaffected = objSqlCommand.ExecuteNonQuery();
                ;
                CloseConnection();
                return rowsaffected;
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
        }

        public DataSet GetDatasetByCommand(string Command)
        {
            try
            {
                objSqlCommand.CommandText = Command;
                objSqlCommand.CommandTimeout = CommandTimeout;
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlConnection.Open();

                SqlDataAdapter adpt = new SqlDataAdapter(objSqlCommand);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataSet GetDatasetBySQL(string query)
        {
            try
            {
                objSqlCommand.CommandText = query;
                objSqlCommand.CommandTimeout = CommandTimeout;
                objSqlCommand.CommandType = CommandType.Text;

                objSqlConnection.Open();

                SqlDataAdapter adpt = new SqlDataAdapter(objSqlCommand);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        public SqlDataReader GetReaderBySQL(string strSQL)
        {
            objSqlConnection.Open();
            try
            {
                SqlCommand myCommand = new SqlCommand(strSQL, objSqlConnection);
                return myCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
        }

        public SqlDataReader GetReaderByCmd(string Command)
        {
            SqlDataReader objSqlDataReader = null;
            try
            {
                objSqlCommand.CommandText = Command;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.CommandTimeout = CommandTimeout;

                objSqlConnection.Open();
                objSqlCommand.Connection = objSqlConnection;

                objSqlDataReader = objSqlCommand.ExecuteReader();
                return objSqlDataReader;
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }

        }

        public void AddParameterToSQLCommand(string ParameterName, SqlDbType ParameterType)
        {
            try
            {
                SqlParameter param = new SqlParameter(ParameterName, ParameterType);

                objSqlCommand.Parameters.Add(param);

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddParameterToSQLCommand(string ParameterName, SqlDbType ParameterType, int ParameterSize)
        {
            try
            {
                objSqlCommand.Parameters.Add(new SqlParameter(ParameterName, ParameterType, ParameterSize));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetSQLCommandParameterValue(string ParameterName)
        {
            try
            {
                return objSqlCommand.Parameters[ParameterName].Value;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetSQLCommandParameterValue(string ParameterName, object Value)
        {
            try
            {
                objSqlCommand.Parameters[ParameterName].Value = Value;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }





        //private void BulkCopy()
        //{
        //    string Source = ConnectionString;
        //    string Destination = ConfigurationManager.ConnectionStrings["Destination"]
        //                         .ConnectionString;
        //    using (SqlConnection sourceCon = new SqlConnection(Source))
        //    {
        //        SqlCommand cmd = new SqlCommand("SELECT [Id],[Name],[Desc] FROM [manish_db].[dbo].                                             Products]", sourceCon);
        //        sourceCon.Open();
        //        using (SqlDataReader rdr = cmd.ExecuteReader())
        //        {
        //            using (SqlConnection destinationCon = new SqlConnection(Destination))
        //            {
        //                using (SqlBulkCopy bc = new SqlBulkCopy(destinationCon))
        //                {
        //                    bc.BatchSize = 10000;
        //                    bc.NotifyAfter = 5000;
        //                    bc.SqlRowsCopied += (sender, eventArgs) =>
        //                    {
        //                        lblProgRpt.Text += eventArgs.RowsCopied + " loaded...."
        //                        + "<br/>";
        //                        lblMsg.Text = "In " + bc.BulkCopyTimeout +
        //                         " Sec " + eventArgs.RowsCopied + "
        //                            Copied.";  
        //                      };

        //                    bc.DestinationTableName = "Products";
        //                    bc.ColumnMappings.Add("Id", "Id");
        //                    bc.ColumnMappings.Add("Name", "Name");
        //                    bc.ColumnMappings.Add("Desc", "Desc");
        //                    destinationCon.Open();
        //                    bc.WriteToServer(rdr);
        //                }
        //            }
        //        }
        //    }

        //}


    }
}

