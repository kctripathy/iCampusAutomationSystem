using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.CustomerRelation;
using System.Data;
using System.Data.SqlClient;

namespace Micro.DataAccessLayer.CustomerRelation
{
   public partial class DUMMYDataAccess:AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static DUMMYDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static DUMMYDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DUMMYDataAccess();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion
        
       #region Declaration
        #endregion

        #region Methods&implementation
        public DataRow getstudentbyId(int STUDID)
        {
            using (SqlCommand selectcommand = new SqlCommand())
            {
                selectcommand.CommandType = CommandType.StoredProcedure;
                selectcommand.Parameters.Add(GetParameter("@STUDID", SqlDbType.Int, STUDID));
                selectcommand.CommandText = "VIEW_STUDENT";
                return ExecuteGetDataRow(selectcommand);
            }
 
        }
        #endregion

    }
}
