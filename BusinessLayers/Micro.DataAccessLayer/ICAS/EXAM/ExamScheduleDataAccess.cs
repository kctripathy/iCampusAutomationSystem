using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Micro.Commons;
using System.Data;
using System.Data.SqlClient;
using Micro.Objects.ICAS.EXAM;

namespace Micro.DataAccessLayer.ICAS.EXAM
{
    public class ExamScheduleDataAccess:AbstractData_SQLClient
    {

        #region Code to Make This As singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>

        private static ExamScheduleDataAccess _Instance;
        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static ExamScheduleDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ExamScheduleDataAccess();
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

        public int InsertExamSedhule(ObjExamSehedules theSeduleExam)
        {
            int ReturnValue = 0;
            using (SqlCommand InsertCommand = new SqlCommand { CommandType = CommandType.StoredProcedure })
            {
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;                
                InsertCommand.Parameters.Add(GetParameter("@ExamScheduleName", SqlDbType.VarChar, theSeduleExam.ExamScheduleName));
                InsertCommand.Parameters.Add(GetParameter("@ExamID", SqlDbType.Int, theSeduleExam.ExamID));
                InsertCommand.Parameters.Add(GetParameter("@StreamID", SqlDbType.Int, theSeduleExam.StreamID));                
                InsertCommand.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, theSeduleExam.QualID));
                InsertCommand.Parameters.Add(GetParameter("@ClassID", SqlDbType.Int, theSeduleExam.ClassID));
                InsertCommand.Parameters.Add(GetParameter("@SubjectID", SqlDbType.Int, theSeduleExam.SubjectID));
                InsertCommand.Parameters.Add(GetParameter("@FullMark", SqlDbType.Int, theSeduleExam.FullMark));
                InsertCommand.Parameters.Add(GetParameter("@PassMark", SqlDbType.Int, theSeduleExam.PassMark));
                InsertCommand.Parameters.Add(GetParameter("@ExamDate", SqlDbType.VarChar, theSeduleExam.ExamDate));
                InsertCommand.Parameters.Add(GetParameter("@StartTime", SqlDbType.Decimal, Decimal.Parse(theSeduleExam.StartTime.ToString())));
                InsertCommand.Parameters.Add(GetParameter("@CloseTime", SqlDbType.Decimal, Decimal.Parse(theSeduleExam.CloseTime)));
                InsertCommand.Parameters.Add(GetParameter("@InvisilatorUserID", SqlDbType.Int, theSeduleExam.InvisilatorUserID));
                InsertCommand.Parameters.Add(GetParameter("@RoomNo", SqlDbType.Int, theSeduleExam.RoomNo));
                InsertCommand.Parameters.Add(GetParameter("@IsActive", SqlDbType.Bit, theSeduleExam.IsActive));
                InsertCommand.Parameters.Add(GetParameter("@IsDeleted", SqlDbType.Bit, theSeduleExam.IsDeleted));                                             
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));
                //InsertCommand.Parameters.Add(GetParameter("@DateModified", SqlDbType.DateTime,DateTime.Now));
                //InsertCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, 18));
                InsertCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, 1));//TO DO :KP:Remove HardCode
                //TODO: KP: Remove hardcoding
                InsertCommand.CommandText = "iCAS_Exam_Sehdule_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
            }
            return ReturnValue;
        }
        public int UpdateExamSedhule(ObjExamSehedules theSeduleExam)
        {
            int ReturnValue = 0;
            using (SqlCommand UpdateCommand = new SqlCommand { CommandType = CommandType.StoredProcedure })
            {
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@ExamScheduleID", SqlDbType.Int, theSeduleExam.ExamScheduleID));
                UpdateCommand.Parameters.Add(GetParameter("@ExamScheduleName", SqlDbType.VarChar, theSeduleExam.ExamScheduleName));
                UpdateCommand.Parameters.Add(GetParameter("@ExamID", SqlDbType.Int, theSeduleExam.ExamID));
                UpdateCommand.Parameters.Add(GetParameter("@StreamID", SqlDbType.Int, theSeduleExam.StreamID));
                UpdateCommand.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, theSeduleExam.QualID));
                UpdateCommand.Parameters.Add(GetParameter("@ClassID", SqlDbType.Int, theSeduleExam.ClassID));
                UpdateCommand.Parameters.Add(GetParameter("@SubjectID", SqlDbType.Int, theSeduleExam.SubjectID));
                UpdateCommand.Parameters.Add(GetParameter("@FullMark", SqlDbType.Int, theSeduleExam.FullMark));
                UpdateCommand.Parameters.Add(GetParameter("@PassMark", SqlDbType.Int, theSeduleExam.PassMark));
                UpdateCommand.Parameters.Add(GetParameter("@ExamDate", SqlDbType.VarChar, theSeduleExam.ExamDate));
                UpdateCommand.Parameters.Add(GetParameter("@StartTime", SqlDbType.Decimal, Decimal.Parse(theSeduleExam.StartTime.ToString())));
                UpdateCommand.Parameters.Add(GetParameter("@CloseTime", SqlDbType.Decimal, Decimal.Parse(theSeduleExam.CloseTime)));
                UpdateCommand.Parameters.Add(GetParameter("@InvisilatorUserID", SqlDbType.Int, theSeduleExam.InvisilatorUserID));
                UpdateCommand.Parameters.Add(GetParameter("@RoomNo", SqlDbType.Int, theSeduleExam.RoomNo));
                UpdateCommand.Parameters.Add(GetParameter("@IsActive", SqlDbType.Bit, theSeduleExam.IsActive));
                UpdateCommand.Parameters.Add(GetParameter("@IsDeleted", SqlDbType.Bit, theSeduleExam.IsDeleted));
                UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));
                //UpdateCommand.Parameters.Add(GetParameter("@DateModified", SqlDbType.DateTime,DateTime.Now));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, 1));//TO DO:hard code //SqlDbType.Int,Micro.Commons.Connection.LoggedOnUser.UserID)
                UpdateCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, 44));//TO DO:hard code KP
                UpdateCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, 1));//TO DO:hard code
                //TODO: KP: Remove hardcoding
                UpdateCommand.CommandText = "pICAS_Exam_Schedule_Update";
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
            }
            return ReturnValue;
        }
        public int DeleteExamSedhule(ObjExamSehedules theSeduleExam)
        {
            int ReturnValue = 0;
            using (SqlCommand DeleteCommand = new SqlCommand { CommandType = CommandType.StoredProcedure })
            {                
                DeleteCommand.Parameters.Add(GetParameter("@ExamScheduleID", SqlDbType.Int, theSeduleExam.ExamScheduleID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int,1)); ;//TO DO:hard code //SqlDbType.Int,Micro.Commons.Connection.LoggedOnUser.UserID)                             
                DeleteCommand.CommandText = "pICAS_Exam_Schedule_Delete";
                ExecuteStoredProcedure(DeleteCommand);
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
            }
            return ReturnValue;
        }
        public DataTable GetExamSeduleList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, 44)); //TO DO KP :Micro.Commons.Connection.LoggedOnUser.OfficeID
                SelectCommand.CommandText = "iCAS_ExamSeduleList_SelectAll";

                return  ExecuteGetDataTable(SelectCommand);

            }
        }
        public DataTable GetStudentList_ByExamSedule(bool allOffices, bool showDeleted,int SeculeID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;

                SelectCommand.Parameters.Add(GetParameter("@ExamScheduleID", SqlDbType.Int, SeculeID));
                SelectCommand.CommandText = "pICAS_Student_SelectAll_ByScheduleID";

                return ExecuteGetDataTable(SelectCommand);

            }
        }
    }
}
