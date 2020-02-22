using System.Data;
using System.Data.SqlClient;
using Micro.Objects.HumanResource;

namespace Micro.DataAccessLayer.HumanResource
{
    public class DepartmentDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        /// 
        private static DepartmentDataAccess _Instance;

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        /// 
        public static DepartmentDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DepartmentDataAccess();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }

        #endregion

		#region Methods & Implementation

		public DataTable GetDepartmentsAll(string SearchText = "", bool ShowDeleted = false)
		{

			SqlCommand SelectCommand = new SqlCommand();
			SelectCommand.CommandType = CommandType.StoredProcedure;

			//SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, SearchText));
			//SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, ShowDeleted));

			SelectCommand.CommandText = "pHRM_Department_Select";

			return ExecuteGetDataTable(SelectCommand);

		}

		public DataTable GetDepartmentsAllByOffice(int OfficeID = -1, string searchText = "", bool showDeleted = false)
		{

			SqlCommand SelectCmd = new SqlCommand();
			SelectCmd.CommandType = CommandType.StoredProcedure;

            SelectCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID ));
				//(OfficeID == -1 ? Micro.Commons.Connection.LoggedOnUser.OfficeID : OfficeID)));

			SelectCmd.CommandText = "pHRM_DepartmentsOfficewise_SelectByOfficeID";

			return ExecuteGetDataTable(SelectCmd);


		}

		public DataRow GetDepartmentsByDepartmentID(int DepartmentID)
		{

			SqlCommand SelectCommand = new SqlCommand();
			SelectCommand.CommandType = CommandType.StoredProcedure;

			SelectCommand.Parameters.Add(GetParameter("@DepartmentId", SqlDbType.Int, DepartmentID));

			SelectCommand.CommandText = "pHRM_Department_SelectById";

			return ExecuteGetDataRow(SelectCommand);

		}

		public int InsertDepartment(Department theDepartment)
        {
                int ReturnValue = 0;

                SqlCommand InsertCommand = new SqlCommand();
                InsertCommand.CommandType = CommandType.StoredProcedure;

                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

				InsertCommand.Parameters.Add(GetParameter("@DepartmentDescription", SqlDbType.VarChar, theDepartment.DepartmentDescription));
				InsertCommand.Parameters.Add(GetParameter("@ParentDepartmentId", SqlDbType.Int, theDepartment.ParentDepartmentId));

                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                InsertCommand.CommandText = "pHRM_Department_Insert";

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
           
        }

        public int UpdateDepartment(Department Dept)
        {
                int ReturnValue = 0;

                SqlCommand UpdateCommand = new SqlCommand();
                UpdateCommand.CommandType = CommandType.StoredProcedure;

				UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

				UpdateCommand.Parameters.Add(GetParameter("@DepartmentID", SqlDbType.Int, Dept.DepartmentID));
				UpdateCommand.Parameters.Add(GetParameter("@DepartmentDescription", SqlDbType.VarChar, Dept.DepartmentDescription));
				UpdateCommand.Parameters.Add(GetParameter("@ParentDepartmentID", SqlDbType.Int, Dept.ParentDepartmentId));
				//UpdateCommand.Parameters.Add(GetParameter("@IsActive", SqlDbType.Int, Dept.IsActive));

				UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

				UpdateCommand.CommandText = "pHRM_Departments_Update";

                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            
        }

        public int DeleteDepartment(Department theDepartment)
        {
			int ReturnValue = 0;

			using (SqlCommand DeleteCommand = new SqlCommand())
			{
				DeleteCommand.CommandType = CommandType.StoredProcedure;
				DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				DeleteCommand.Parameters.Add(GetParameter("@DepartmentId", SqlDbType.Int, theDepartment.DepartmentID));
				DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				DeleteCommand.CommandText = "pHRM_Department_Delete";
				ExecuteStoredProcedure(DeleteCommand);
				ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
				return ReturnValue;
			}
        }
       
        #endregion
    }
}
