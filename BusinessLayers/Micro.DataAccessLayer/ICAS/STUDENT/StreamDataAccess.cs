using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using Micro.Objects.ICAS.STUDENT;
using Micro.Commons;

namespace Micro.DataAccessLayer.ICAS.STUDENT
{
    public class StreamDataAccess:AbstractData_SQLClient
    {
        /// <summary>
        /// Declare a private static variable
        /// </summary>

        private static StreamDataAccess _Instance;
        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static StreamDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new StreamDataAccess();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        

        #region Declaration
        #endregion

        public DataTable GetStreamAll()
        {
            try
            {
                SqlCommand GetExamcommand = new SqlCommand();
                GetExamcommand.CommandType = CommandType.StoredProcedure;

                GetExamcommand.CommandText = "iCAS_Streams_SelectAll";

                return ExecuteGetDataTable(GetExamcommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        
    }
    
}
