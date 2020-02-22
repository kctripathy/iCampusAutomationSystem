using System.Collections.Generic;
using Micro.Objects.CustomerRelation;
using System.Data.SqlClient;
using System.Data;
using Micro.Commons;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class BrokerageFeeStructureOfficeWiseDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static BrokerageFeeStructureOfficeWiseDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static BrokerageFeeStructureOfficeWiseDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BrokerageFeeStructureOfficeWiseDataAccess();
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
        public DataTable GetBrokerageFeeStructureOfficeWise(int officeId)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, officeId));
            SelectCommand.CommandText = "pCRM_BrokerageFeeStructuresOfficewise_SelectByControllingOfficeID";

            return ExecuteGetDataTable(SelectCommand);
        }

        public DataTable GetBrokerageFeeStructureOfficeWiseList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pCRM_BrokerageFeeStructuresOfficewise_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetBrokerageFeeStructureSelectByOfficeID(bool ShowInOfficewise = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@ShowInOfficewise", SqlDbType.Bit, ShowInOfficewise));
                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pCRM_BrokerageFeeStructures_SelectByOfficeID";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        //public DataTable GetBrokerageFeeStructureOfficeWiseSelectByControllingOfficeID(string searchText)
        //{
        //    SqlCommand SelectCommand = new SqlCommand();

        //    SelectCommand.CommandType = CommandType.StoredProcedure;
        //    SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
        //    SelectCommand.CommandText = "pCRM_BrokerageFeeStructuresOfficewise_SelectByControllingOfficeID_SelectAll";

        //    return ExecuteGetDataTable(SelectCommand);
        //}

        public int UpdateBrokerageFeeStructureOfficeWise(List<BrokerageFeeStructureOfficeWise> theBrokerageFeeStructureOfficeWiseList)
        {
            int ReturnValue = 0;

            int ListCount = theBrokerageFeeStructureOfficeWiseList.Count;
            int ListCounter = 0;

            SqlCommand[] UpdateCommand = new SqlCommand[ListCount];

            foreach (BrokerageFeeStructureOfficeWise TheBrokerageFeeStructureOfficeWise in theBrokerageFeeStructureOfficeWiseList)
            {

                UpdateCommand[ListCounter] = new SqlCommand();

                UpdateCommand[ListCounter].CommandType = CommandType.StoredProcedure;
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                //UpdateCommand[ListCounter].Parameters.Add(GetParameter("@BrokerageFeeStructureOfficewiseID", SqlDbType.Int, TheBrokerageFeeStructureOfficeWise.BrokerageFeeStructureOfficewiseID));
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@BrokerageFeeStructureID", SqlDbType.Int, TheBrokerageFeeStructureOfficeWise.BrokerageFeeStructureID));
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, TheBrokerageFeeStructureOfficeWise.OfficeID));
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@IsActive", SqlDbType.Bit, TheBrokerageFeeStructureOfficeWise.IsActive));
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@IsDeleted", SqlDbType.Bit, TheBrokerageFeeStructureOfficeWise.IsDeleted));
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand[ListCounter].CommandText = "pCRM_BrokerageFeeStructuresOfficewise_Update";

                ListCounter++;
            }
            ReturnValue = ExecuteStoredProcedure(UpdateCommand);

            if ((ReturnValue + ListCount).Equals(0))
            {
                ReturnValue = (int)MicroEnums.DataOperationResult.Success + 1;
            }
            else
            {
                ReturnValue = (int)MicroEnums.DataOperationResult.Failure;
            }

            return ReturnValue;
        }

        public int InsertBrokerageFeeStructureOfficeWise(string BrokerageFeeStructureIDs, string EffectiveDateFrom)
        {

            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@BrokerageFeeStructureIDs", SqlDbType.VarChar, BrokerageFeeStructureIDs));
                InsertCommand.Parameters.Add(GetParameter("@EffectiveDateFrom", SqlDbType.VarChar, EffectiveDateFrom));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_BrokerageFeeStructuresOfficewise_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int DeleteBrokerageFeeStructureOfficeWise(string BrokerageFeeStructureIDs)
        {
            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@BrokerageFeeStructureIDs", SqlDbType.VarChar, BrokerageFeeStructureIDs));
                DeleteCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                DeleteCommand.CommandText = "pCRM_BrokerageFeeStructuresOfficewise_Delete";
                ExecuteStoredProcedure(DeleteCommand);
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }
        #endregion
    }
}
