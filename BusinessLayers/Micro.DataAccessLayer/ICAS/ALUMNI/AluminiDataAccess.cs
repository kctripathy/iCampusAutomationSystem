using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Micro.Objects.ICAS.ALUMNI;

namespace Micro.DataAccessLayer.ICAS.ALUMNI
{
    public partial class AluminiDataAccess: AbstractData_SQLClient
    {
        #region Code to Make This As singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>

        private static AluminiDataAccess _Instance;
        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static AluminiDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AluminiDataAccess();
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

        public DataTable GetAluminiList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, 44)); //Micro.Commons.Connection.LoggedOnUser.OfficeID
                SelectCommand.CommandText = "pICAS_Alumini_SelectAll";

                return ExecuteGetDataTable(SelectCommand);

            }
        }

        public int InsertAlumini(Alumini theAlumini)
        {
            int ReturnValue = 0;
            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@AluminiCode", SqlDbType.VarChar, theAlumini.AluminiCode));
                InsertCommand.Parameters.Add(GetParameter("@Salutation", SqlDbType.VarChar, theAlumini.Salutation));
                InsertCommand.Parameters.Add(GetParameter("@AluminiName", SqlDbType.VarChar, theAlumini.AluminiName));
                InsertCommand.Parameters.Add(GetParameter("@FatherName", SqlDbType.VarChar, theAlumini.FatherName));
                InsertCommand.Parameters.Add(GetParameter("@MotherName", SqlDbType.VarChar, theAlumini.MotherName));
                InsertCommand.Parameters.Add(GetParameter("@Gender", SqlDbType.VarChar, theAlumini.Gender));
                InsertCommand.Parameters.Add(GetParameter("@Caste", SqlDbType.VarChar, theAlumini.Caste));
                InsertCommand.Parameters.Add(GetParameter("@Status", SqlDbType.VarChar, theAlumini.Status));
                InsertCommand.Parameters.Add(GetParameter("@DateOfBirth", SqlDbType.DateTime, theAlumini.@DateOfBirth));
                InsertCommand.Parameters.Add(GetParameter("@DateOfAdmission", SqlDbType.DateTime, theAlumini.DateOfAdmission));
                InsertCommand.Parameters.Add(GetParameter("@DateOfLeaving", SqlDbType.DateTime, theAlumini.DateOfLeaving));
                InsertCommand.Parameters.Add(GetParameter("@Age", SqlDbType.Int, theAlumini.Age));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_TownOrCity", SqlDbType.VarChar, theAlumini.Address_Present_TownOrCity));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_Landmark", SqlDbType.VarChar, theAlumini.Address_Present_Landmark));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_PinCode", SqlDbType.VarChar, theAlumini.Address_Present_PinCode));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_DistrictID", SqlDbType.Int, theAlumini.Address_Present_DistrictID));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_TownOrCity", SqlDbType.VarChar, theAlumini.Address_Permanent_TownOrCity));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_Landmark", SqlDbType.VarChar, theAlumini.Address_Permanent_Landmark));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_PinCode", SqlDbType.VarChar, theAlumini.Address_Permanent_PinCode));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_DistrictID", SqlDbType.Int, theAlumini.Address_Permanent_DistrictID));
                InsertCommand.Parameters.Add(GetParameter("@PhoneNumber", SqlDbType.VarChar, theAlumini.PhoneNumber));
                InsertCommand.Parameters.Add(GetParameter("@Mobile", SqlDbType.VarChar, theAlumini.Mobile));
                InsertCommand.Parameters.Add(GetParameter("@EmailID", SqlDbType.VarChar, theAlumini.EMailID));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));
                InsertCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, 21));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, 1));
                InsertCommand.CommandText = "pICAS_Alumini_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
            }
            return ReturnValue;

        }

        public int UpdateAlumini(Alumini theAlumini)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@AluminiID", SqlDbType.Int, theAlumini.AluminiID));
                UpdateCommand.Parameters.Add(GetParameter("@AluminiCode", SqlDbType.VarChar, theAlumini.AluminiCode));
                UpdateCommand.Parameters.Add(GetParameter("@Salutation", SqlDbType.VarChar, theAlumini.Salutation));
                UpdateCommand.Parameters.Add(GetParameter("@AluminiName", SqlDbType.VarChar, theAlumini.AluminiName));
                UpdateCommand.Parameters.Add(GetParameter("@FatherName", SqlDbType.VarChar, theAlumini.FatherName));
                UpdateCommand.Parameters.Add(GetParameter("@MotherName", SqlDbType.VarChar, theAlumini.MotherName));
                UpdateCommand.Parameters.Add(GetParameter("@Gender", SqlDbType.VarChar, theAlumini.Gender));
                UpdateCommand.Parameters.Add(GetParameter("@Caste", SqlDbType.VarChar, theAlumini.Caste));
                UpdateCommand.Parameters.Add(GetParameter("@Status", SqlDbType.VarChar, theAlumini.Status));
                UpdateCommand.Parameters.Add(GetParameter("@DateOfBirth", SqlDbType.DateTime, theAlumini.@DateOfBirth));
                UpdateCommand.Parameters.Add(GetParameter("@DateOfAdmission", SqlDbType.DateTime, theAlumini.DateOfAdmission));
                UpdateCommand.Parameters.Add(GetParameter("@DateOfLeaving", SqlDbType.DateTime, theAlumini.DateOfLeaving));
                UpdateCommand.Parameters.Add(GetParameter("@Age", SqlDbType.Int, theAlumini.Age));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_TownOrCity", SqlDbType.VarChar, theAlumini.Address_Present_TownOrCity));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_Landmark", SqlDbType.VarChar, theAlumini.Address_Present_Landmark));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_PinCode", SqlDbType.VarChar, theAlumini.Address_Present_PinCode));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_DistrictID", SqlDbType.Int, theAlumini.Address_Present_DistrictID));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_TownOrCity", SqlDbType.VarChar, theAlumini.Address_Permanent_TownOrCity));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_Landmark", SqlDbType.VarChar, theAlumini.Address_Permanent_Landmark));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_PinCode", SqlDbType.VarChar, theAlumini.Address_Permanent_PinCode));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_DistrictID", SqlDbType.Int, theAlumini.Address_Permanent_DistrictID));
                UpdateCommand.Parameters.Add(GetParameter("@PhoneNumber", SqlDbType.VarChar, theAlumini.PhoneNumber));
                UpdateCommand.Parameters.Add(GetParameter("@Mobile", SqlDbType.VarChar, theAlumini.Mobile));
                UpdateCommand.Parameters.Add(GetParameter("@EmailID", SqlDbType.VarChar, theAlumini.EMailID));
                UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));
                UpdateCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, 21));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, 11));
                UpdateCommand.CommandText = "pICAS_Alumini_Update";
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
            }
            return ReturnValue;
        }

        public int DeleteAlumini(Alumini theAlumini)
        {
            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@AluminiID", SqlDbType.Int, theAlumini.AluminiID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, 1));
                DeleteCommand.CommandText = "pICAS_Alumini_Delete";
                ExecuteStoredProcedure(DeleteCommand);
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }
        #endregion
    }
}
