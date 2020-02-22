using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Micro.Objects.Administration;

namespace Micro.DataAccessLayer.Administration
{
    public partial class MicroFormDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static MicroFormDataAccess instance = new MicroFormDataAccess();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static MicroFormDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Methods & Implementation
        public DataTable GetMicroForms()
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.CommandText = "pADM_Forms_SelectAll";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetMicroFormsByModuleMenuText(string moduleMenuText)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@ModuleMenuText", SqlDbType.VarChar, moduleMenuText));
                SelectCommand.CommandText = "pADM_Forms_SelectByModuleMenuText";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetMicroFormByName(string formName)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@FormName", SqlDbType.VarChar, formName));
                SelectCommand.CommandText = "pADM_Forms_SelectByName";
                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public DataRow GetMicroFormByActualName(string actualFormName)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@ActualFormName", SqlDbType.VarChar, actualFormName));
                SelectCommand.CommandText = "pADM_Forms_SelectByActualName";
                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public void UpdateRecords(List<MicroForm> microFormUpdateList)
        {
            int ListCount = microFormUpdateList.Count;
            int ListCounter = 0;

            SqlCommand[] UpdateCommand = new SqlCommand[ListCount];

            foreach (MicroForm EachMicroForm in microFormUpdateList)
            {
                UpdateCommand[ListCounter] = new SqlCommand();

                UpdateCommand[ListCounter].CommandType = CommandType.StoredProcedure;
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@FormName", SqlDbType.VarChar, EachMicroForm.FormName));
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@ActualFormName", SqlDbType.VarChar, EachMicroForm.ActualFormName));
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@ActualFormClassName", SqlDbType.Char, EachMicroForm.ActualFormClassName));
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@ModuleID", SqlDbType.Int, EachMicroForm.ModuleID));
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@AddedBy", SqlDbType.Bit, 1)); //Micro.Commons.Connection.LoggedOnUser.UserId));
                UpdateCommand[ListCounter].CommandText = "pADM_Forms_Update";

                ListCounter++;
            }

            ExecuteStoredProcedure(UpdateCommand);
        }
        #endregion
    }
}
