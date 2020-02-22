using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Micro.DataAccessLayer.ICAS.STUDENT
{
    public partial class QualClassDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static QualClassDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static QualClassDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new QualClassDataAccess();
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
        public DataTable GetClassListByQualID(int QualID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;

                SelectCommand.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, QualID));
                //TODO: SUBRAT: Replace id
                //SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int,
                //    (officeID == -1 ? Micro.Commons.Connection.LoggedOnUser.OfficeID : officeID)));
                SelectCommand.CommandText = "pICAS_Classes_SelectAll_ByQualID";

                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetClassListByStreamAndQual(int QualID, int StreamID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));
                SelectCommand.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, QualID));
                SelectCommand.Parameters.Add(GetParameter("@StreamID", SqlDbType.Int, StreamID));
                SelectCommand.CommandText = "pICAS_Classes_SelectAll_ByStreamAndQual";
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        #endregion
    }
}
