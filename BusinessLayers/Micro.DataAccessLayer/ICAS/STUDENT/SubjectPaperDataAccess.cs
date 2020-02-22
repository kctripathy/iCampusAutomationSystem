using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using Micro.Objects.ICAS.STUDENT;
namespace Micro.DataAccessLayer.ICAS.STUDENT
{
    public class SubjectPaperDataAccess:AbstractData_SQLClient
    {
        #region Code to Make This As singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>

        private static SubjectPaperDataAccess _Instance;
        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static SubjectPaperDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SubjectPaperDataAccess();
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

        #region Methods & Implementation
       
        #endregion
        public DataTable GetPaperListBySubjectID(int StreamID, string searchText = null, bool showDeleted = false)
        {
            try
            {
                SqlCommand GetSubjectPapercommand = new SqlCommand();
                GetSubjectPapercommand.CommandType = CommandType.StoredProcedure;
                GetSubjectPapercommand.Parameters.Add(GetParameter("@SubjectID", SqlDbType.Int, StreamID));
                GetSubjectPapercommand.CommandText = "iCAS_SubjectPapers_SelectAllBySubjectID";

                return ExecuteGetDataTable(GetSubjectPapercommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
    }
}
