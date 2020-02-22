using System;

using System.Data;
using System.Data.OleDb;

using Micro.Objects.Administration;

namespace Micro.DataAccessLayer
{
    /// <summary> 
    /// Provides CRUD (CREATE, READ, UPDATE, DELETE) functionality for database to use with OleDb
    /// </summary>
    /// <author>Kishor Tripathy</author>
    public abstract class AbstractData_OleDb
    {

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

        ///// <summary>
        ///// No argument constructor for Abstract Data
        ///// </summary>
        //protected void AbstractData_OleDb()
        //{
        //}
        
        #region Methods & Implementations

        /// <summary>
        /// Execute the SQL command and return single value (Used for return count from SQL)
        /// </summary>
        /// <param name="strSQL">SqlClient command</param>
        /// <returns>Return single query result</returns>
        protected object ExecuteScalar(string strSQL)
        {
            // Variables
            object objResult = null;
            OleDbCommand oCommand = new OleDbCommand();

            try
            {
                oCommand.Connection = ConnectionFactory.GetInstance.GetConnection(_ConnectionKey);
                oCommand.Connection.Open();

                oCommand.CommandText = strSQL;

                objResult = oCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                if (strSQL != null)
                {
                    Exception ex = new Exception(strSQL, e);
                    //Log.Error(ex, true);
                }
                else
                {
                    //Log.Error(e, true);
                }
            }
            finally
            {
                ConnectionFactory.GetInstance.CloseConnection(oCommand.Connection);
            }

            // Returning object
            return objResult;
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
            public OleDbConnection GetConnection(string ConnectionKey)
            {

                //OFFICE 2007 & Later
                //"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ExcelFilePath + ";Extended Properties=" + (char)34 + "Excel 12.0;HDR=YES" + (char)34 + ";";
                
                //OFFICE 2003
                //"provider=Microsoft.Jet.OLEDB.4.0;data source=" + ExcelFilePath + ";Extended Properties=Excel 8.0;";
                
                string myConnString = Micro.Commons.Connection.ConnectionString;
                OleDbConnection oConn = new OleDbConnection(myConnString);

                return oConn;
            }

            /// <summary>
            /// Close the connection state.
            /// </summary>
            /// <param name="oConn">Connection object to be closed.</param>
            public void CloseConnection(OleDbConnection oConn)
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
                    throw new Exception("Error in DecryptBase64" + ex.Message);
                }

            }
            #endregion Methods & Implementation
        }
        #endregion InnerClass ConnectionFactory

    }



}