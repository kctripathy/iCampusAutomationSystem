using System;
using System.Data;
using System.Data.SqlClient;
using Micro.Commons;
using Micro.Objects.Administration;
using System.Configuration;

namespace Micro.DataAccessLayer
{
    /// <summary> 
    /// Provides CRUD (CREATE, READ, UPDATE, DELETE) functionality for database
    /// </summary>
    /// <author>Kishor Tripathy</author>
    public abstract class AbstractData_SQLClient
    {
        #region Methods & Implementations
        /// <summary>
        /// Key of the connection string in web.config
        /// </summary>
        private string _ConnectionKey;

        /// <summary>
        /// Key of the connection string in web.config
        /// </summary>
        public string ConnectionKey
        {
            get
            {
				//_ConnectionKey = ConfigurationManager.AppSettings["DefaultDatabaseEnviroment"];
                return _ConnectionKey;
            }
            set
            {
                _ConnectionKey = value;
            }
        }

        public User LoggedOnUser
        {
            get;
            set;
        }

        /// <summary>
        /// Context from MultiCompaniesCompCode in web.config defines in BusinessDataAccess Layer
        /// </summary>
        private string _Context;

        /// <summary>
        /// Context from MultiCompaniesCompCode in web.config defines in BusinessDataAccess Layer
        /// </summary>
        public string Context
        {
            get { return _Context; }
            set { _Context = value; }
        }

        /// <summary>
        /// No argument constructor for Abstract Data
        /// </summary>
        protected void AbstractData_SqlClient()
        {
        }

        /// <summary>
        /// Exception Policy to sue to handle the exception
        /// </summary>
        private const string ExceptionPolicyValue = "Data Policy";

        /// <summary>
        /// Replace single quote with its ASCII equivalent.
        /// </summary>
        /// <param name="input">String contains single quote</param>
        /// <returns>Parsed string</returns>
        private string parseString(string input)
        {
            return input.Replace("'", "&#39");
        }

        /// <summary>
        /// Execute the SQL command and return single value (Used for return count from SQL)
        /// </summary>
        /// <param name="strSQL">SqlClient command</param>
        /// <returns>Return single query result</returns>
        protected object ExecuteScalar(string strSQL)
        {
            // Variables
            object objResult = null;
			using(SqlCommand oCommand = new SqlCommand())
			{
				try
				{
					oCommand.Connection = ConnectionFactory.GetInstance.GetConnection(_ConnectionKey);
					oCommand.Connection.Open();
					oCommand.CommandText = strSQL;
					objResult = oCommand.ExecuteScalar();
				}
				catch(Exception e)
				{
					if(strSQL != null)
					{
						Exception ex = new Exception(strSQL, e);
						Log.Error(ex, true);
					}
					else
					{
						Log.Error(e, true);
					}
				}
				finally
				{
					ConnectionFactory.GetInstance.CloseConnection(oCommand.Connection);
				}
			}

            // Returning object
            return objResult;
        }

        /// <summary>
        /// Execute the SQL command and return single value (Used for return count from SQL)
        /// </summary>
        /// <param name="oCommand">Sql command</param>
        /// <returns>Return single query result</returns>
        protected object ExecuteScalar(SqlCommand oCommand)
        {
            // Variables
            object objResult = null;

            try
            {
                oCommand.Connection = ConnectionFactory.GetInstance.GetConnection(_ConnectionKey);
                oCommand.Connection.Open();

                oCommand.CommandType = CommandType.StoredProcedure;

                objResult = oCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                bool rethrow = true;
                if (oCommand != null)
                {
                    string ErrorMessage = "Procedure :" + oCommand.CommandText.ToString() + "\n Message: " + e.Message.ToString();
                    Exception ex = new Exception(ErrorMessage, e);
                    Log.Error(ex, true);
                }
                else
                {
                    Log.Error(e, true);
                }
                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                ConnectionFactory.GetInstance.CloseConnection(oCommand.Connection);
            }

            // Returning object
            return objResult;
        }

        /// <summary>
        /// Execute the SQL command and return a datarow containing data.
        /// </summary>
        /// <param name="oCommand">Sql command</param>
        /// <returns>Datarow containing data</returns>
        protected DataRow ExecuteGetDataRow(SqlCommand oCommand)
        {
            // Variables
			using(DataSet DsResult = new DataSet())
			{
				DataRow drowObject = null;
				using(SqlDataAdapter oAdapter = new SqlDataAdapter())
				{
					try
					{
						oCommand.Connection = ConnectionFactory.GetInstance.GetConnection(_ConnectionKey);
						oCommand.Connection.Open();
						oCommand.CommandType = CommandType.StoredProcedure;
						oAdapter.SelectCommand = oCommand;
						oAdapter.Fill(DsResult);
						if(DsResult.Tables.Count != 0 && DsResult.Tables[0].Rows.Count != 0)
							drowObject = DsResult.Tables[0].Rows[0];
						// Genetating an exception if more than one record has been found.
						if(DsResult.Tables[0].Rows.Count > 1)
							throw new Exception("More than 1 record found for stored procedure " + oCommand.CommandText + ".");
					}
					catch(Exception e)
					{
						if(oCommand != null)
						{
							Exception ex = new Exception(oCommand.CommandText, e);
							Log.Error(ex, true, e);
						}
						else
							Log.Error(e, true);
					}
					finally
					{
						ConnectionFactory.GetInstance.CloseConnection(oCommand.Connection);
					}
				}
				return drowObject;
			}
        }

        /// <summary>
        /// Execute the SQL command and return a datable containing data.
        /// </summary>
        /// <param name="oCommand">Oledb command</param>
        /// <returns>Datarow containing data</returns>
        protected DataTable ExecuteGetDataTable(SqlCommand oCommand)
        {
            // Variables
			using(DataSet DsResult = new DataSet())
			{
				DataTable dtableObject = new DataTable();
				using(SqlDataAdapter oAdapter = new SqlDataAdapter())
				{
					try
					{
						oCommand.Connection = ConnectionFactory.GetInstance.GetConnection(_ConnectionKey);
						oCommand.Connection.Open();
						oCommand.CommandType = CommandType.StoredProcedure;
						oAdapter.SelectCommand = oCommand;
						oAdapter.Fill(DsResult);
						dtableObject = DsResult.Tables[0];
					}
					catch(Exception e)
					{
						if(oCommand != null)
						{
							string ErrorAtProcName = this.GetType().FullName.ToString() + "~" + oCommand.CommandText;
							Exception ex = new Exception(ErrorAtProcName, e);
							Log.Error(ex, true);
						}
						else
							Log.Error(e, true);
					}
					finally
					{
						ConnectionFactory.GetInstance.CloseConnection(oCommand.Connection);
					}
				}
				return dtableObject;
			}
        }

        /// <summary>
        /// Execute the SQL command and return a datable containing data.
        /// </summary>
        /// <param name="oCommand">Oledb command</param>
        /// <returns>Datarow containing data</returns>
        protected DataTable ExecuteGetDualRequest(SqlCommand oCommandSP, string strSQL)
        {
            // Variables
			using(DataSet DsResult = new DataSet())
			{
				DataTable dtableObject = new DataTable();
				using(SqlDataAdapter oAdapter = new SqlDataAdapter())
				{
					SqlCommand oCommand = new SqlCommand();
					try
					{
						oCommand.Connection = ConnectionFactory.GetInstance.GetConnection(_ConnectionKey);
						oCommand.Connection.Open();
						oCommand.CommandType = CommandType.Text;
						oCommand.CommandText = strSQL;
						oAdapter.SelectCommand = oCommand;
						oAdapter.SelectCommand.ExecuteScalar();
						oCommand.CommandType = CommandType.StoredProcedure;
						foreach(SqlParameter OP in oCommandSP.Parameters)
							oCommand.Parameters.Add(GetParameter(OP.ParameterName, OP.SqlDbType, OP.Value)).Direction = OP.Direction;
						oCommand.CommandText = oCommandSP.CommandText;
						oAdapter.SelectCommand = oCommand;
						oAdapter.Fill(DsResult);
						dtableObject = DsResult.Tables[0];
					}
					catch(Exception e)
					{
						if(oCommand != null)
						{
							Exception ex = new Exception(oCommand.CommandText, e);
							Log.Error(ex, true);
						}
						else
							Log.Error(e, true);
					}
					finally
					{
						ConnectionFactory.GetInstance.CloseConnection(oCommand.Connection);
					}
				}
				return dtableObject;
			}
        }

        /// <summary>
        /// Execute the SQL query and return a datable containing data.
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns>Datarow containing data</returns>
        protected DataTable ExecuteGetDataTable(string strSQL)
        {
            // Variables
            DataTable dtableObject = new DataTable();
			using(SqlDataAdapter oAdapter = new SqlDataAdapter())
			{
				SqlCommand oCommand = new SqlCommand();
				try
				{
					oCommand.Connection = ConnectionFactory.GetInstance.GetConnection(_ConnectionKey);
					oCommand.Connection.Open();
					oCommand.CommandText = strSQL;
					oAdapter.SelectCommand = oCommand;
					oAdapter.Fill(dtableObject);
				}
				catch(Exception e)
				{
					if(oCommand != null)
					{
						Exception ex = new Exception(oCommand.CommandText, e);
						Log.Error(ex, true);
					}
					else
						Log.Error(e, true);
				}
				finally
				{
					ConnectionFactory.GetInstance.CloseConnection(oCommand.Connection);
				}
			}

            return dtableObject;
        }

        ///// <summary>
        ///// Execute the stored procedure stored in oCommand
        ///// </summary>
        ///// <param name="oCommand">the Command to execute (stored procedure)</param>
        ///// <param name="oBlobParameters">the Oledb blob parameters to store the contents in</param>
        ///// <param name="oContents">the binary contents (in same order than oBlobParameters)</param>
        //protected void ExecuteStoredProcedureWithBlob(SqlCommand oCommand, SqlParameter[] oBlobParameters, Byte[][] oContents)
        //{
        //    // OledbParameter currentParameter;
        //    SqlTransaction oTransaction = null;
        //    OledbLob[] oOledbLobs = null;
        //    OledbConnection oConnection = ConnectionFactory.GetInstance.GetConnection(_ConnectionKey);
        //    try
        //    {
        //        OledbCommand blobCommands = new OledbCommand();
        //        oConnection.Open();
        //       

        //        // Create the transaction within the blob inserts will be executed
        //        oTransaction = oConnection.BeginTransaction();
        //        blobCommands.Connection = oConnection;
        //        blobCommands.Transaction = oTransaction;

        //        int i = 0;
        //        oOledbLobs = new OledbLob[oBlobParameters.Length];
        //        foreach (OledbParameter currentParameter in oBlobParameters)
        //        {
        //            // Create temporary blob Oledb parameters
        //            blobCommands.CommandText = "declare xx blob; begin dbms_lob.createtemporary(xx, false, 0); :tempblob" + i + ":= xx; end;";
        //            blobCommands.Parameters.Add(new OledbParameter("tempblob" + i, OledbType.Blob)).Direction = ParameterDirection.Output;
        //            blobCommands.Transaction = oTransaction;
        //            blobCommands.CommandType = CommandType.Text;
        //            blobCommands.ExecuteNonQuery();

        //            // We get the the previously created parameter from the command
        //            // and fill in the content with oContents argument
        //            oOledbLobs[i] = (OledbLob)blobCommands.Parameters[0].Value;
        //            oOledbLobs[i].BeginBatch(OledbLobOpenMode.ReadWrite);
        //            oOledbLobs[i].Write(oContents[i], 0, oContents[i].Length);
        //            // This operation is made under the same transaction than 
        //            // the insert one (see oTransaction)
        //            oOledbLobs[i].EndBatch();
        //            oBlobParameters[i].Value = oOledbLobs[i];

        //            i++;
        //        }
        //        // Then execute the main command
        //        oCommand.Connection = oConnection;
        //        oCommand.Transaction = oTransaction;
        //        oCommand.CommandType = CommandType.StoredProcedure;
        //        oCommand.ExecuteNonQuery();

        //        oCommand.Transaction.Commit();
        //    }
        //    catch (Exception e)
        //    {
        //        if (oConnection.State == ConnectionState.Open)
        //        {
        //            if (oTransaction != null)
        //            {
        //                oTransaction.Rollback();
        //            }
        //        }
        //        if (oCommand != null)
        //        {
        //            Exception ex = new Exception(oCommand.CommandText, e);
        //            Log.Error(ex, true);
        //        }
        //        else
        //        {
        //            Log.Error(e, true);
        //        }
        //    }
        //    finally
        //    {
        //        ConnectionFactory.GetInstance.CloseConnection(oCommand.Connection);
        //    }
        //}

        /// <summary>
        /// Execute the SQL query and return a datable containing data.
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns>Datarow containing data</returns>
        protected DataRow ExecuteGetDataRow(string strSQL)
        {
            // Variables
			using(DataSet DsResult = new DataSet())
			{
				DataRow drowObject = null;
				using(SqlDataAdapter oAdapter = new SqlDataAdapter())
				{
					SqlCommand oCommand = new SqlCommand();
					try
					{
						oCommand.Connection = ConnectionFactory.GetInstance.GetConnection(_ConnectionKey);
						oCommand.Connection.Open();
						oCommand.CommandText = strSQL;
						oAdapter.SelectCommand = oCommand;
						oAdapter.Fill(DsResult);
						if(DsResult.Tables.Count != 0 && DsResult.Tables[0].Rows.Count != 0)
							drowObject = DsResult.Tables[0].Rows[0];
						// Genetating an exception if more than one record has been found.
						if(DsResult.Tables[0].Rows.Count > 1)
							throw new Exception("More than 1 record found for stored procedure " + oCommand.CommandText + ".");
					}
					catch(Exception e)
					{
						bool rethrow = true;
						if(oCommand != null)
						{
							Exception ex = new Exception(oCommand.CommandText, e);
							Log.Error(ex, true);
						}
						else
							Log.Error(e, true);
						if(rethrow)
							throw;
					}
					finally
					{
						ConnectionFactory.GetInstance.CloseConnection(oCommand.Connection);
					}
				}
				return drowObject;
			}
        }

        /// <summary>
        /// Execute the SQL command and return a dataset containing data.
        /// </summary>
        /// <param name="oCommand">Oledb command</param>
        /// <param name="strTableName">Name of the table to fill</param>
        /// <param name="dsetObject">DataSet containing data</param>
        protected void ExecuteGetDataSet(SqlCommand oCommand, string strTableName, DataSet dsetObject)
        {
			using(SqlDataAdapter oAdapter = new SqlDataAdapter())
			{
				try
				{
					oCommand.Connection = ConnectionFactory.GetInstance.GetConnection(_ConnectionKey);
					oCommand.Connection.Open();
					oCommand.CommandType = CommandType.StoredProcedure;
					oAdapter.SelectCommand = oCommand;
					oAdapter.Fill(dsetObject, strTableName);
				}
				catch(Exception e)
				{
					if(oCommand != null)
					{
						Exception ex = new Exception(oCommand.CommandText, e);
						Log.Error(ex, true);
					}
					else
						Log.Error(e, true);
				}
				finally
				{
					ConnectionFactory.GetInstance.CloseConnection(oCommand.Connection);
				}
			}
        }

        protected void ExecuteSqlStatement(SqlCommand oCommand)
        {
            try
            {
                oCommand.Connection = ConnectionFactory.GetInstance.GetConnection(_ConnectionKey);
                oCommand.Connection.Open();
                oCommand.CommandType = CommandType.Text;
                oCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                if (oCommand != null)
                {
                    Exception ex = new Exception(oCommand.CommandText, e);
                    Log.Error(ex, true);
                }
                else
                {
                    Log.Error(e, true);
                }
            }
            finally
            {
                ConnectionFactory.GetInstance.CloseConnection(oCommand.Connection);
            }
        }

        /// <summary>
        /// Execute the stored procedure
        /// </summary>
        /// <param name="strSPName">Name of procedure to be executed</param>
        /// <param name="parametersList">List of input parameter for stored procedure</param>
        protected void ExecuteStoredProcedure(SqlCommand oCommand)
        {
            try
            {
                oCommand.Connection = ConnectionFactory.GetInstance.GetConnection(_ConnectionKey);
                oCommand.Connection.Open();
                oCommand.CommandTimeout = 50000;

                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                if (oCommand != null)
                {
                    Exception ex = new Exception(oCommand.CommandText, e);
                    Log.Error(ex, true);
                }
                else
                {
                    Log.Error(e, true);
                }
            }
            finally
            {
                ConnectionFactory.GetInstance.CloseConnection(oCommand.Connection);
            }
        }

        /// <summary>
        /// Execute the stored procedure
        /// </summary>
        /// <param name="strSPName">Name of procedure to be executed</param>
        /// <param name="parametersList">List of input parameter for stored procedure</param>
        protected int ExecuteStoredProcedureGetID(SqlCommand oCommand)
        {
            int RetValue = 0;
            try
            {
                oCommand.Connection = ConnectionFactory.GetInstance.GetConnection(_ConnectionKey);
                oCommand.Connection.Open();

                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                if (oCommand != null)
                {
                    Exception ex = new Exception(oCommand.CommandText, e);
                    Log.Error(ex, true);
                }
                else
                {
                    Log.Error(e, true);
                }
            }
            finally
            {
                ConnectionFactory.GetInstance.CloseConnection(oCommand.Connection);
            }
            return RetValue;
        }

        /// <summary>
        /// Execute the stored procedure list under same transaction.
        /// </summary>
        /// <param name="strSPName">Name of procedure to be executed</param>
        /// <param name="commandList">List of Command object to be executed under same transaction</param>
        protected int ExecuteStoredProcedure(SqlCommand[] commandList)
        {
            SqlTransaction oTransaction = null;
            string currentProcedure = "";
            int count = 0;

            SqlConnection oConn = ConnectionFactory.GetInstance.GetConnection(_ConnectionKey);

            try
            {
                oConn.Open();
                
                oTransaction = oConn.BeginTransaction();

                foreach (SqlCommand command in commandList)
                {
                    command.Transaction = oTransaction;
                    command.Connection = oConn;
                    command.CommandType = CommandType.StoredProcedure;
                    currentProcedure = command.CommandText;
                    count += command.ExecuteNonQuery();
                }

                oTransaction.Commit();
            }
            catch (Exception e)
            {
                if (oConn.State == ConnectionState.Open)
                {
                    if (oTransaction != null)
                    {
                        oTransaction.Rollback();
                    }
                }

                Log.Error(e, true);
            }
            finally
            {
                ConnectionFactory.GetInstance.CloseConnection(oConn);
            }

            return count;
        }

        /// <summary>
        /// Get the Next seed value of auto generated column.
        /// </summary>
        /// <param name="strSequenceName">Name of sequence to be get</param>
        /// <returns>Next seed value</returns>
        protected int GetNextSequence(string strSequenceName)
        {
            // Variables
            int intReturn = -1;
			using(SqlCommand oCommand = new SqlCommand())
			{
				SqlDataReader oReader;
				try
				{
					oCommand.Connection = ConnectionFactory.GetInstance.GetConnection(_ConnectionKey);
					oCommand.Connection.Open();
					oCommand.CommandText = "SELECT " + strSequenceName + ".NEXTVAL SEQVALUE FROM DUAL";
					oReader = oCommand.ExecuteReader();
					// Generating string
					if(oReader.Read())
						intReturn = int.Parse(oReader["SEQVALUE"].ToString());
				}
				catch(Exception e)
				{
					if(strSequenceName != null)
					{
						Exception ex = new Exception(strSequenceName, e);
						Log.Error(ex, true);
					}
					else
						Log.Error(e, true);
				}
				finally
				{
					ConnectionFactory.GetInstance.CloseConnection(oCommand.Connection);
				}
			}

            // Returning string.
            return intReturn;
        }

        /// <summary>
        /// Return Oledb parameter object.
        /// </summary>
        /// <param name="paramName">Oledb parameter name</param>
        /// <param name="paramType">Oledb parameter type</param>
        /// <param name="paramValue">Oledb parameter value</param>
        /// <returns>Oledb parameter</returns>
        protected SqlParameter GetParameter(string paramName, SqlDbType paramType, object paramValue)
        {
            return GetParameter(paramName, paramType, paramValue, 0);
        }

        /// <summary>
        /// Return Oledb parameter object.
        /// </summary>
        /// <param name="paramName">Oledb parameter name</param>
        /// <param name="paramType">Oledb parameter type</param>
        /// <param name="paramValue">Oledb parameter value</param>
        /// <param name="paramSize">Oledb parameter size</param>
        /// <returns>Oledb parameter</returns>
        protected SqlParameter GetParameter(string paramName, SqlDbType paramType, object paramValue, int paramSize)
        {
            SqlParameter oParameter = new SqlParameter();
            oParameter.ParameterName = paramName;
            oParameter.SqlDbType = paramType;

            if (paramType == SqlDbType.VarChar)
            {
                oParameter.Value = (paramValue == null) ? "" : (string)paramValue;
            }
            else
            {
                oParameter.Value = paramValue;
            }

            if (paramType == SqlDbType.VarChar || paramType == SqlDbType.Int)
            {
                if (paramSize != 0)
                {
                    oParameter.Size = paramSize;
                }
            }

            oParameter.Direction = ParameterDirection.Input;
            return oParameter;
        }
        #endregion

        #region InnerClass ConnectionFactory
        /// <summary>
        /// It give connection objects. It is a singleton class.
        /// </summary>
        private sealed class ConnectionFactory
        {
            #region Variables
            /// <summary>
            /// Static memeber of connection factory class.
            /// </summary>
            private static ConnectionFactory _instance = new ConnectionFactory();
            #endregion Variables

            #region Properties
            /// <summary>
            /// Static property, it returns the static private member of connection factory. Its
            /// for implementing singleton.
            /// </summary>
            public static ConnectionFactory GetInstance
            {
                get
                {
                    return _instance;
                }
            }
            #endregion Properties

            #region Methods & Implementation
            /// <summary>
            /// Construtor of connection factory.
            /// </summary>
            private ConnectionFactory()
            {
            }

            /// <summary>
            /// Returns Oledb connection object.
            /// </summary>
            /// <returns>Oledb connection object.</returns>
            public SqlConnection GetConnection(string ConnectionKey)
            {
				//string myConnString = Micro.Commons.Connection.ConnectionString;
				//SqlConnection oConn = new SqlConnection(myConnString);

                //String DefaultDatabaseEnviroment = ConfigurationManager.AppSettings["DefaultDatabaseEnviroment"];
                //Micro.Commons.Connection.ConnectionString = Micro.Commons.MicroSecurity.Decrypt(ConfigurationManager.ConnectionStrings[DefaultDatabaseEnviroment].ToString());
                //string myConnString = Micro.Commons.Connection.ConnectionKeyValue;
                //string ConnectionKeyName = Micro.Commons.Connection.ConnectionKeyName;
                //Micro.Commons.Connection.ConnectionString = Micro.Commons.MicroSecurity.Decrypt(Micro.Commons.Connection.ConnectionKeyValue);

                //SqlConnection oConn = new SqlConnection(Micro.Commons.MicroSecuritty.DecryptStringAES(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["DefaultDatabaseEnviroment"]].ToString(), "micro"));


                Connection.ConnectionKeyName = ConfigurationManager.AppSettings["DefaultDatabaseEnviroment"].ToString();
                Connection.ConnectionKeyValue = Micro.Commons.MicroSecurity.Decrypt(ConfigurationManager.ConnectionStrings[Connection.ConnectionKeyName].ToString());
                Connection.ConnectionString = Connection.ConnectionKeyValue;

                SqlConnection oConn = new SqlConnection(Micro.Commons.Connection.ConnectionKeyValue);
                return oConn;
            }

            /// <summary>
            /// Close the connection state.
            /// </summary>
            /// <param name="oConn">Connection object to be closed.</param>
            public void CloseConnection(SqlConnection oConn)
            {
                if (oConn != null)
                {
                    if (oConn.State == ConnectionState.Open)
                    {
                        oConn.Close();
                    }
                    oConn.Dispose();
                }
            }


            private string EncryptBase64(string thePassword)
            {
                try
                {
                    byte[] encData_byte = new byte[thePassword.Length];
                    encData_byte = System.Text.Encoding.UTF8.GetBytes(thePassword);
                    string encodedData = Convert.ToBase64String(encData_byte);
                    return encodedData;
                }
                catch (Exception ex)
                {
					Log.Error(ex);
                    throw new Exception("Error in EncryptBase64" + ex.Message);
                }
            }

            private string DecryptBase64(string thePassword)
            {
                try
                {
                    System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                    System.Text.Decoder utf8Decode = encoder.GetDecoder();
                    byte[] todecode_byte = Convert.FromBase64String(thePassword);
                    int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                    char[] decoded_char = new char[charCount];
                    utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                    string result = new String(decoded_char);
                    return result;
                }
                catch (Exception ex)
                {
					Log.Error(ex);
					throw new Exception("Error in DecryptBase64" + ex.Message);
                }

            }
            #endregion Methods & Implementation
        }
        #endregion InnerClass ConnectionFactory
    }
}
