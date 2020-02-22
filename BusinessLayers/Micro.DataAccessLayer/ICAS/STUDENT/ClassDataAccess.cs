using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Micro.DataAccessLayer.ICAS.STUDENT
{
   public partial class ClassDataAccess :AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static ClassDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
       public static ClassDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ClassDataAccess();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

       

        #endregion

        #region Data Retrive Mathods
        public DataTable GetClassListByOfficeID( int officeID)
       {
           using (SqlCommand SelectCommand = new SqlCommand())
           {
               SelectCommand.CommandType = CommandType.StoredProcedure;               
               SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));             
               SelectCommand.CommandText = "pICAS_Classes_SelectAll";
               return ExecuteGetDataTable(SelectCommand);
           }
       }
        
        #endregion
    }
}
