using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

using Micro.Objects.Administration;

namespace Micro.DataAccessLayer.Administration
{
    public partial class OfficeDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static OfficeDataAccess instance = new OfficeDataAccess();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static OfficeDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public int InsertOffice(Office objOffice)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                sqlCmd.Parameters.Add(GetParameter("@OfficeName", SqlDbType.VarChar, objOffice.OfficeName));
                sqlCmd.Parameters.Add(GetParameter("@OfficeTypeID", SqlDbType.Int, objOffice.OfficeTypeID));
                sqlCmd.Parameters.Add(GetParameter("@ParentOfficeID", SqlDbType.Int, objOffice.ParentOfficeID));
                sqlCmd.Parameters.Add(GetParameter("@EstablishmentDate", SqlDbType.DateTime, objOffice.EstablishmentDate));
                sqlCmd.Parameters.Add(GetParameter("@ManagerEmployeeID", SqlDbType.Int, objOffice.ManagerEmployeeID));

                sqlCmd.Parameters.Add(GetParameter("@Address_TownOrCity", SqlDbType.VarChar, objOffice.Address_TownOrCity));
                sqlCmd.Parameters.Add(GetParameter("@Address_Landmark", SqlDbType.VarChar, objOffice.Address_Landmark));
                sqlCmd.Parameters.Add(GetParameter("@Address_DistrictID", SqlDbType.Int, objOffice.Address_DistrictID));
                sqlCmd.Parameters.Add(GetParameter("@Address_PinCode", SqlDbType.VarChar, objOffice.Address_PinCode));

                sqlCmd.Parameters.Add(GetParameter("@ContactPerson1", SqlDbType.VarChar, objOffice.ContactPerson1));
                sqlCmd.Parameters.Add(GetParameter("@ContactPerson2", SqlDbType.VarChar, objOffice.ContactPerson2));
                sqlCmd.Parameters.Add(GetParameter("@ContactPerson3", SqlDbType.VarChar, objOffice.ContactPerson3));

                sqlCmd.Parameters.Add(GetParameter("@StdCodePhone", SqlDbType.VarChar, objOffice.StdCodePhone));
                sqlCmd.Parameters.Add(GetParameter("@Phone1", SqlDbType.VarChar, objOffice.Phone1));
                sqlCmd.Parameters.Add(GetParameter("@Phone2", SqlDbType.VarChar, objOffice.Phone2));
                sqlCmd.Parameters.Add(GetParameter("@Phone3", SqlDbType.VarChar, objOffice.Phone3));

                sqlCmd.Parameters.Add(GetParameter("@Extension1", SqlDbType.VarChar, objOffice.Extension1));
                sqlCmd.Parameters.Add(GetParameter("@Extension2", SqlDbType.VarChar, objOffice.Extension2));
                sqlCmd.Parameters.Add(GetParameter("@Extension3", SqlDbType.VarChar, objOffice.Extension3));

                sqlCmd.Parameters.Add(GetParameter("@StdCodeFax", SqlDbType.VarChar, objOffice.StdCodeFax));
                sqlCmd.Parameters.Add(GetParameter("@Fax1", SqlDbType.VarChar, objOffice.Fax1));
                sqlCmd.Parameters.Add(GetParameter("@Fax2", SqlDbType.VarChar, objOffice.Fax2));
                sqlCmd.Parameters.Add(GetParameter("@Fax3", SqlDbType.VarChar, objOffice.Fax3));

                sqlCmd.Parameters.Add(GetParameter("@Mobile1", SqlDbType.VarChar, objOffice.Mobile1));
                sqlCmd.Parameters.Add(GetParameter("@Mobile2", SqlDbType.VarChar, objOffice.Mobile2));
                sqlCmd.Parameters.Add(GetParameter("@Mobile3", SqlDbType.VarChar, objOffice.Mobile3));

                sqlCmd.Parameters.Add(GetParameter("@EMailID1", SqlDbType.VarChar, objOffice.Email1));
                sqlCmd.Parameters.Add(GetParameter("@EMailID2", SqlDbType.VarChar, objOffice.Email2));
                sqlCmd.Parameters.Add(GetParameter("@EMailID3", SqlDbType.VarChar, objOffice.Email3));
                //sqlCmd.Parameters.Add(GetParameter("@IsHavingShift", SqlDbType.Bit, objOffice.IsHavingShift));

                sqlCmd.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                sqlCmd.CommandText = "pADM_Offices_Insert";

                ExecuteStoredProcedure(sqlCmd);

                return int.Parse(sqlCmd.Parameters[0].Value.ToString());
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateOffice(Office objOffice)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                sqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, objOffice.OfficeID));
                sqlCmd.Parameters.Add(GetParameter("@OfficeName", SqlDbType.VarChar, objOffice.OfficeName));
                sqlCmd.Parameters.Add(GetParameter("@OfficeTypeID", SqlDbType.Int, objOffice.OfficeTypeID));
                sqlCmd.Parameters.Add(GetParameter("@ParentOfficeID", SqlDbType.Int, objOffice.ParentOfficeID));
                sqlCmd.Parameters.Add(GetParameter("@EstablishmentDate", SqlDbType.DateTime, objOffice.EstablishmentDate));
                sqlCmd.Parameters.Add(GetParameter("@ManagerEmployeeID", SqlDbType.Int, objOffice.ManagerEmployeeID));

                sqlCmd.Parameters.Add(GetParameter("@Address_TownOrCity", SqlDbType.VarChar, objOffice.Address_TownOrCity));
                sqlCmd.Parameters.Add(GetParameter("@Address_Landmark", SqlDbType.VarChar, objOffice.Address_Landmark));
                sqlCmd.Parameters.Add(GetParameter("@Address_DistrictID", SqlDbType.Int, objOffice.Address_DistrictID));
                sqlCmd.Parameters.Add(GetParameter("@Address_PinCode", SqlDbType.VarChar, objOffice.Address_PinCode));

                sqlCmd.Parameters.Add(GetParameter("@ContactPerson1", SqlDbType.VarChar, objOffice.ContactPerson1));
                sqlCmd.Parameters.Add(GetParameter("@ContactPerson2", SqlDbType.VarChar, objOffice.ContactPerson2));
                sqlCmd.Parameters.Add(GetParameter("@ContactPerson3", SqlDbType.VarChar, objOffice.ContactPerson3));

                sqlCmd.Parameters.Add(GetParameter("@StdCodePhone", SqlDbType.VarChar, objOffice.StdCodePhone));
                sqlCmd.Parameters.Add(GetParameter("@Phone1", SqlDbType.VarChar, objOffice.Phone1));
                sqlCmd.Parameters.Add(GetParameter("@Phone2", SqlDbType.VarChar, objOffice.Phone2));
                sqlCmd.Parameters.Add(GetParameter("@Phone3", SqlDbType.VarChar, objOffice.Phone3));

                sqlCmd.Parameters.Add(GetParameter("@Extension1", SqlDbType.VarChar, objOffice.Extension1));
                sqlCmd.Parameters.Add(GetParameter("@Extension2", SqlDbType.VarChar, objOffice.Extension2));
                sqlCmd.Parameters.Add(GetParameter("@Extension3", SqlDbType.VarChar, objOffice.Extension3));

                sqlCmd.Parameters.Add(GetParameter("@StdCodeFax", SqlDbType.VarChar, objOffice.StdCodeFax));
                sqlCmd.Parameters.Add(GetParameter("@Fax1", SqlDbType.VarChar, objOffice.Fax1));
                sqlCmd.Parameters.Add(GetParameter("@Fax2", SqlDbType.VarChar, objOffice.Fax2));
                sqlCmd.Parameters.Add(GetParameter("@Fax3", SqlDbType.VarChar, objOffice.Fax3));

                sqlCmd.Parameters.Add(GetParameter("@Mobile1", SqlDbType.VarChar, objOffice.Mobile1));
                sqlCmd.Parameters.Add(GetParameter("@Mobile2", SqlDbType.VarChar, objOffice.Mobile2));
                sqlCmd.Parameters.Add(GetParameter("@Mobile3", SqlDbType.VarChar, objOffice.Mobile3));

                sqlCmd.Parameters.Add(GetParameter("@Email1", SqlDbType.VarChar, objOffice.Email1));
                sqlCmd.Parameters.Add(GetParameter("@Email2", SqlDbType.VarChar, objOffice.Email2));
                sqlCmd.Parameters.Add(GetParameter("@Email3", SqlDbType.VarChar, objOffice.Email3));
                //sqlCmd.Parameters.Add(GetParameter("@IsHavingShift", SqlDbType.Bit, objOffice.IsHavingShift));

                sqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                sqlCmd.CommandText = "pADM_Offices_Update";

                ExecuteStoredProcedure(sqlCmd);

                return int.Parse(sqlCmd.Parameters[0].Value.ToString());
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteOffice(int OfficeID)
        {
            try
            {
                int ReturnValue = 0;
                
                SqlCommand DeleteCommand = new SqlCommand();

                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, OfficeID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                DeleteCommand.CommandText = "pADM_Offices_Delete";

                ExecuteStoredProcedure(DeleteCommand);
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Methods & Implementations
        public DataTable GetOfficeList()
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.CommandText = "pADM_Offices_SelectAll";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetOfficeListByUserID(int userID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@UserID", SqlDbType.Int, userID));
                SelectCommand.CommandText = "pADM_Offices_SelectByUserID";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetOfficeByCompanyID(int CompanyID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, CompanyID));
                SelectCommand.CommandText = "pADM_Offices_SelectByCompanyID";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetOfficeByID(int officeID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, officeID));
                SelectCommand.CommandText = "pADM_Offices_SelectByOfficeID";
                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public DataTable GetOfficeListByTypeID(int officeTypeID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@OfficeTypeID", SqlDbType.Int, officeTypeID));
                SelectCommand.CommandText = "pADM_Offices_SelectByOfficeTypeID";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetOfficeListByUserOfficeTypeID(int officeTypeID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@OfficeTypeID", SqlDbType.Int, officeTypeID));
                SelectCommand.Parameters.Add(GetParameter("@UserID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                SelectCommand.CommandText = "pADM_Offices_SelectByUserID";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetUnitOfficeListByCompanyID()
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
                SelectCommand.CommandText = "pADM_Offices_SelectAllUnitsByCompanyID";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetOfficeListByReportingOfficeID(int officeID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				SelectCommand.CommandText = "pADM_Offices_SelectAllReportingOfficesByOfficeID"; // "pADM_Offices_SelectReportingOfficesByOfficeID";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetBranchOfficeListByOfficeID(int officeID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, officeID));
                SelectCommand.CommandText = "pADM_Offices_SelectAllBranchesByOfficeID";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetBranchOfficeListByOfficeTypeID(int officeID, int officeTypeID, bool showChildOffices)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, officeID));
                SelectCommand.Parameters.Add(GetParameter("@OfficeTypeID", SqlDbType.Int, officeTypeID));
                SelectCommand.Parameters.Add(GetParameter("@ShowChild", SqlDbType.Bit, showChildOffices));
                SelectCommand.CommandText = "pADM_Offices_SelectAllBranchesByOfficeID";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetOfficeTreeByUserID(int userID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@UserID", SqlDbType.Int, userID));
                SelectCommand.CommandText = "pADM_Offices_SelectOfficeTreeByUserID";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetOfficeListByCompanyID(int CompanyID = -1)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;

                SelectCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int,
                            (CompanyID == -1 ? Micro.Commons.Connection.LoggedOnUser.CompanyID : CompanyID)));

                SelectCommand.CommandText = "pADM_Offices_SelectByCompanyID";
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        #endregion
    }
}
