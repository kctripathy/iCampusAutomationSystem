using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.ESTBLMT;
using System.Data;
using System.Data.SqlClient;
 
 

namespace Micro.DataAccessLayer.ICAS.ESTBLMT
{
    public partial class EstablishmentDataAccess:AbstractData_SQLClient
    {
        #region code to make this as singleton class

        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static EstablishmentDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static EstablishmentDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new EstablishmentDataAccess();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion


        #region  declaration
        #endregion


        #region Methods & Implementation
        public DataTable GetEstablishmentList( bool showDeleted = false)
        {
            using(SqlCommand Selectcommand=new SqlCommand())
            {
                Selectcommand.CommandType = CommandType.StoredProcedure;
                Selectcommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                Selectcommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, 44)); //TODO:  Micro.Commons.Connection.LoggedOnUser.OfficeID));
                Selectcommand.CommandText = "pICAS_Establishments_SelectAllByOfficeID";
                return ExecuteGetDataTable(Selectcommand);
            }
        }
        public DataTable GetEstablishmentListByTypeCode(string typeCode = "T", bool showDeleted = false)
        {
            using (SqlCommand Selectcommand = new SqlCommand())
            {
                Selectcommand.CommandType = CommandType.StoredProcedure;
                Selectcommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                Selectcommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, 44)); //TODO:  Micro.Commons.Connection.LoggedOnUser.OfficeID));
                Selectcommand.Parameters.Add(GetParameter("@TypeCode", SqlDbType.VarChar, typeCode));
                Selectcommand.CommandText = "[pICAS_Establishments_SelectAllByTypeCode]";
                return ExecuteGetDataTable(Selectcommand);
            }
        }
        public DataTable GetEstablishmentListByTypeCodes(string typeCodes = "1,2,3,4,5,6,7,8,9,10", bool showDeleted = false)
        {
            using (SqlCommand Selectcommand = new SqlCommand())
            {
                Selectcommand.CommandType = CommandType.StoredProcedure;
                Selectcommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                Selectcommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, 44)); //TODO:  Micro.Commons.Connection.LoggedOnUser.OfficeID));
                Selectcommand.Parameters.Add(GetParameter("@TypeCodes", SqlDbType.VarChar, typeCodes));
                Selectcommand.CommandText = "[pICAS_Establishments_SelectAllByTypeCodes]";
                return ExecuteGetDataTable(Selectcommand);
            }
        }
        public int InsertEstablishment(Establishment oEstb)
        {
            int ReturnValue = 0;
            using (SqlCommand insCmd=new SqlCommand())
            {
                insCmd.CommandType = CommandType.StoredProcedure;
                insCmd.Parameters.Add(GetParameter("@ReturnValue",SqlDbType.Int, ReturnValue)).Direction=ParameterDirection.Output;
                insCmd.Parameters.Add(GetParameter("@ESTB_TITLE", SqlDbType.VarChar, oEstb.EstbTitle));
                insCmd.Parameters.Add(GetParameter("@ESTB_TYPE_CODE", SqlDbType.Char, oEstb.EstbTypeCode));
                //insCmd.Parameters.Add(GetParameter("@ESTB_DATE", SqlDbType.DateTime, DateTime.Today));
                insCmd.Parameters.Add(GetParameter("@ESTB_MESSAGE", SqlDbType.VarChar, oEstb.EstbDescription));
                insCmd.Parameters.Add(GetParameter("@ESTB_UPLOADED_FILE", SqlDbType.VarBinary, oEstb.EstbUploadFile));
                insCmd.Parameters.Add(GetParameter("@ESTB_UPLOADED_FILETYPE", SqlDbType.VarChar, oEstb.EstbUploadFileType));
                insCmd.Parameters.Add(GetParameter("@ESTB_VIEW_START_DATE", SqlDbType.DateTime, oEstb.EstbViewStartDate));
                insCmd.Parameters.Add(GetParameter("@ESTB_VIEW_END_DATE", SqlDbType.DateTime, oEstb.EstbViewEndDate));
                insCmd.Parameters.Add(GetParameter("@ESTBSTATUSFLAG", SqlDbType.VarChar, "Pending"));
                insCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                insCmd.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserReferenceID));
                insCmd.Parameters.Add(GetParameter("@VC_FIELD2", SqlDbType.VarChar, oEstb.FileNameWithPath));
                
                //InsertCommand.Parameters.Add(GetParameter("@IsActive", SqlDbType.Int, 1));
                //InsertCommand.Parameters.Add(GetParameter("@IsDeleted", SqlDbType.Int, 0));
                insCmd.CommandText = "[pICAS_Establishments_Insert]";
                //TODO: KT: remove hardcode
                ExecuteStoredProcedure(insCmd);
                 
                ReturnValue =  int.Parse(insCmd.Parameters[0].Value.ToString());
            }
            return ReturnValue;

        }

        public int UpdateEstablishment(Establishment theestablishment)
        {
            int ReturnValue = 0;
            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@EstbID", SqlDbType.Int, theestablishment.EstbID));
                UpdateCommand.Parameters.Add(GetParameter("@EstbTypeCode", SqlDbType.Char, theestablishment.EstbTypeCode));
                UpdateCommand.Parameters.Add(GetParameter("@EstbTitle", SqlDbType.VarChar, theestablishment.EstbTitle));
                //if (theestablishment.EstbUploadFile != null)
                //{
                //    UpdateCommand.Parameters.Add(GetParameter("@EstbUploadFile", SqlDbType.VarBinary, theestablishment.EstbUploadFile));
                //}
                UpdateCommand.Parameters.Add(GetParameter("@EstbDescription", SqlDbType.VarChar, theestablishment.EstbDescription));
                UpdateCommand.Parameters.Add(GetParameter("@EstbDate", SqlDbType.DateTime, theestablishment.EstbDate));
                UpdateCommand.Parameters.Add(GetParameter("@EstbMessage", SqlDbType.VarChar, theestablishment.EstbMessage));
               // UpdateCommand.Parameters.Add(GetParameter("@EstbUploadFile", SqlDbType.VarBinary, theestablishment.EstbUploadFile));
                UpdateCommand.Parameters.Add(GetParameter("@EstbViewStartDate", SqlDbType.DateTime, theestablishment.EstbViewStartDate));
                UpdateCommand.Parameters.Add(GetParameter("@EstbViewEndDate", SqlDbType.DateTime, theestablishment.EstbViewEndDate));
                UpdateCommand.Parameters.Add(GetParameter("@VC_FIELD2", SqlDbType.VarChar, theestablishment.FileNameWithPath));
               UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, 1));

                UpdateCommand.CommandText = "pICAS_ESTB_Update";
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

            }
            return ReturnValue;
        
        }

        public int DeleteEstablishment(Establishment theestablishment)
        {
            int ReturnValue= 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@EstbID", SqlDbType.Int, theestablishment.EstbID));
               // DeleteCommand.Parameters.Add(GetParameter("@DateModified", SqlDbType.DateTime, theestablishment.DateModified));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, 1));
                DeleteCommand.CommandText = "pICAS_ESTB_Delete";
                ExecuteStoredProcedure(DeleteCommand);
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }

           
        
        }


        public int UpdateEstablishmentStatus(int estbId, string estbStatus)
        {
            int ReturnValue = 0;
            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@ESTB_ID", SqlDbType.Int, estbId));
                UpdateCommand.Parameters.Add(GetParameter("@ESTB_STATUS_FLAG", SqlDbType.VarChar, estbStatus));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, 1)); //TODO: Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pICAS_Establishments_UpdateStatus";
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }

        }

        public int ApproveEstablishment( string EstbIDS,string status)
        {
            int ReturnValue = 0;
            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@EstbIDS", SqlDbType.VarChar, EstbIDS));
                //TODO :Requriad LoginId
               // UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));

                UpdateCommand.Parameters.Add(GetParameter("@EstbSatusFlag", SqlDbType.VarChar, status));
                UpdateCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, 21));
                UpdateCommand.CommandText = "pICAS_ESTB_UpdateApprovalStatuss";
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
           
        }

        //public int RejectEstablishment(string EstbIDS)
        //{
        //    int ReturnValue = 0;
        //    using (SqlCommand RejectCommand = new SqlCommand())
        //    {
        //        RejectCommand.Parameters.Add(GetParameter("@ReturnValue",SqlDbType.Int,ReturnValue)).Direction= ParameterDirection.Output;
        //        RejectCommand.Parameters.Add(GetParameter("@EstbIDS", SqlDbType.VarChar, EstbIDS));
        //        RejectCommand.Parameters.Add(GetParameter("@OfficeID",SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
        //        RejectCommand.Parameters.Add(GetParameter("@EstbSatusFlag", SqlDbType.VarChar, EstbSatusFlag));
        //        RejectCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
        //        ExecuteStoredProcedure(RejectCommand);
        //        ReturnValue = int.Parse(RejectCommand.Parameters[0].Value.ToString());
            
        //    }
        //    return ReturnValue;
        
        //}
      
       
        #endregion



        public object EstbSatusFlag { get; set; }
    }
}
