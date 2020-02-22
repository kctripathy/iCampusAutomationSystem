#region System Namespaces
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.Reflection;
#endregion

#region Micro Namespaces
using Micro.Objects.HumanResource;

#endregion

namespace Micro.DataAccessLayer.HumanResource
{
    public class BioMetricDeviceDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        /// 
        private static BioMetricDeviceDataAccess _Instance;

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        /// 
        public static BioMetricDeviceDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BioMetricDeviceDataAccess();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region BioMetric Mathods

        /// <summary>
        /// Read Bio-Matric Settings from App.Config
        /// </summary>
        public BioMetricDevice GetDeviceSettings()
        {
            try
            {
                BioMetricDevice BioDevice = new BioMetricDevice();

                BioDevice.DeviceType = int.Parse(ConfigurationManager.AppSettings["DeviceType"].ToString());
                BioDevice.DeviceSerialNo = ConfigurationManager.AppSettings["DeviceSerialNo"].ToString();
                BioDevice.IPAddress = ConfigurationManager.AppSettings["DeviceIP"].ToString();
                BioDevice.AccessFilePath = ConfigurationManager.AppSettings["AccessFilePath"].ToString();
                BioDevice.ExcelFilePath = ConfigurationManager.AppSettings["ExcelFilePath"].ToString();
                BioDevice.DataImportMode = int.Parse(ConfigurationManager.AppSettings["DataImportMode"].ToString());
                BioDevice.DataImportType = ConfigurationManager.AppSettings["DataImportType"].ToString().ToString();
                BioDevice.DataExportMode = int.Parse(ConfigurationManager.AppSettings["DataExportMode"].ToString());
                BioDevice.ImportTime = int.Parse(ConfigurationManager.AppSettings["DataImportTime"].ToString());
                BioDevice.ExportTime = int.Parse(ConfigurationManager.AppSettings["DataExportTime"].ToString());

                return BioDevice;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// Import Data from Bio-Metric Data File(Access)
        /// </summary>
        public DataTable ImportDataFromBioMetricDeviceViaAccess()
        {

            // Initialize a AttendanceTableData  to store biometric punch data
            DataTable ObjAttendanceTable = new DataTable();
            ObjAttendanceTable = AttendaceTable();

            // Read Bio-Metric Device Settings From App.Config
            BioMetricDevice BioDevice = new BioMetricDevice();
            BioDevice = GetDeviceSettings();

            #region Find LastImportDate
            ///Read Last Import Date, therefore it will import data which are punched after that date...

            DataRow DtR;
            try
            {
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.CommandText = "pHRM_Attendances_SelectLastImportDate";

                DtR = ExecuteGetDataRow(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

            DateTime LastImportDate;
            LastImportDate = (DtR["LastImportDate"].ToString() == "" ? DateTime.Parse("2011-01-01 00:00:00") : DateTime.Parse(DtR["LastImportDate"].ToString()));
            #endregion

            try
            {
                string connectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + BioDevice.AccessFilePath + ";User Id=admin;Jet OLEDB:Database Password=Timmy;";
                OleDbConnection conn = new OleDbConnection(connectionString);
                conn.Open();

                OleDbCommand OledbCmd = new OleDbCommand();
                OledbCmd.CommandText = "SELECT * FROM tmpTRecords where kqdate>#" + LastImportDate.Date.ToString() + "# and kqtime>#" + LastImportDate.TimeOfDay.ToString() + "# order by KqDate,KqTime";
                OledbCmd.Connection = conn;

                DataTable data = new DataTable();
                OleDbDataAdapter OledbAdapter = new OleDbDataAdapter(OledbCmd);
                OledbAdapter.Fill(data);

                foreach (DataRow dr in data.Rows)
                {
                    DataRow row = ObjAttendanceTable.NewRow();
                    row["EmployeeID"] = dr["emp_id"].ToString();
                    row["EmployeeCode"] = "";
                    row["PunchDate"] = DateTime.Parse(dr["KqDate"].ToString());
                    row["PunchTime"] = DateTime.Parse(dr["KqTime"].ToString());

                    row["dday"] = DateTime.Parse(dr["KqDate"].ToString()).Day;
                    row["dmonth"] = DateTime.Parse(dr["KqDate"].ToString()).Month;
                    row["dyear"] = DateTime.Parse(dr["KqDate"].ToString()).Year;

                    row["PunchSource"] = 0;

                    ObjAttendanceTable.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
            return ObjAttendanceTable;
        }

        /// <summary>
        /// Import Data from Bio-Metric Data File(Excel)
        /// </summary>
        public DataTable ImportDataFromBioMetricDeviceViaExcel()
        {
            // Read Bio-Metric Device Settings From App.Config
            BioMetricDevice BioDevice = new BioMetricDevice();
            BioDevice = GetDeviceSettings();

            // Initialize a AttendanceTableData  to store biometric punch data
            DataTable ObjAttendanceTable = new DataTable();
            ObjAttendanceTable = AttendaceTable();

            try
            {
                OleDbConnection oleCon = new OleDbConnection();

                // Excel Connection String
                if (BioDevice.ExcelFilePath.Contains(".xlsx") == true)
                {
                    //OFFICE 2007 or LATER
                     oleCon.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + BioDevice.ExcelFilePath + ";Extended Properties=" + (char)34 + "Excel 12.0;HDR=YES" + (char)34 + ";";
                }
                else if (BioDevice.ExcelFilePath.Contains(".xls") == true)
                {
                    //OFFICE 2003
                    oleCon.ConnectionString = "provider=Microsoft.Jet.OLEDB.4.0;data source=" + BioDevice.ExcelFilePath + ";Extended Properties=Excel 8.0;";
                }
                oleCon.Open();

                //Check the current ExcelFile is a valid Bio-Metric Data File or not
                System.Data.DataTable dtx = null;
                dtx = oleCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (dtx == null)
                {
                    return ObjAttendanceTable;
                }

                string ExcelSheetName = "Sheet1$";

                //foreach (DataRow row in dtx.Rows)
                //{
                //    OleDbCommand oleCmdSelect = new OleDbCommand("select top 1 *  from [" + row["TABLE_NAME"].ToString() + "]", oleCon);
                //    DataTable datax = new DataTable();
                //    OleDbDataAdapter OledbAdapterx = new OleDbDataAdapter(oleCmdSelect);
                //    OledbAdapterx.Fill(datax);

                //    if (datax.Columns[3].ColumnName == "SlotCardDate" && datax.Columns[5].ColumnName == "SlotCardTime")
                //    {
                //        ExcelSheetName=row["TABLE_NAME"].ToString();
                //        break; 
                //    }
                //    datax.Dispose();
                //}

                //if (ExcelSheetName == "")
                //{
                //    return ObjAttendanceTable;
                //}

                //Read Data from Bio_Matric File
                OleDbCommand OledbCmd = new OleDbCommand("select *  from [" + ExcelSheetName + "]", oleCon);
                DataTable data = new DataTable();
                OleDbDataAdapter OledbAdapter = new OleDbDataAdapter(OledbCmd);
                OledbAdapter.Fill(data);

                foreach (DataRow dr in data.Rows)
                {
                    string EmployeeID = dr["JobId"].ToString();
                    string SlotCardDate = dr["SlotCardDate"].ToString();

                    string[] SlotCardTimes = dr["SlotCardTime"].ToString().Split(new char[] { ' ' });

                    foreach (string pTime in SlotCardTimes)
                    {
                        if (pTime != "")
                        {
                            DataRow row = ObjAttendanceTable.NewRow();
                            row["EmployeeID"] = EmployeeID;
                            row["EmployeeCode"] = "";
                            row["PunchDate"] = DateTime.Parse(SlotCardDate);
                            row["PunchTime"] = pTime;

                            row["dday"] = DateTime.Parse(SlotCardDate).Day;
                            row["dmonth"] = DateTime.Parse(SlotCardDate).Month;
                            row["dyear"] = DateTime.Parse(SlotCardDate).Year;

                            row["PunchSource"] = 0;

                            ObjAttendanceTable.Rows.Add(row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

            return ObjAttendanceTable;
        }

        /// <summary>
        /// Create a tempoary Data Table to store Import Data
        /// </summary>
        public DataTable AttendaceTable()
        {
            ///A DataTable Created
            DataTable DtTable = new DataTable();
            DataSet DtSet = new DataSet();

            DtTable.TableName = "TempTable";

            DataColumn DataCol1 = new DataColumn();
            DataColumn DataCol2 = new DataColumn();
            DataColumn DataCol3 = new DataColumn();
            DataColumn DataCol4 = new DataColumn();
            DataColumn DataCol5 = new DataColumn();
            DataColumn DataCol6 = new DataColumn();
            DataColumn DataCol7 = new DataColumn();
            DataColumn DataCol8 = new DataColumn();

            DataCol1.ColumnName = "EmployeeID";
            DataCol2.ColumnName = "EmployeeCode";
            DataCol3.ColumnName = "PunchDate";
            DataCol4.ColumnName = "PunchTime";
            DataCol5.ColumnName = "PunchSource";
            DataCol6.ColumnName = "dday";
            DataCol7.ColumnName = "dmonth";
            DataCol8.ColumnName = "dyear";

            DataCol1.DataType = Type.GetType("System.String");
            DataCol2.DataType = Type.GetType("System.String");
            DataCol3.DataType = Type.GetType("System.DateTime");
            DataCol4.DataType = Type.GetType("System.DateTime");
            DataCol5.DataType = Type.GetType("System.Int16");
            DataCol6.DataType = Type.GetType("System.Int16");
            DataCol7.DataType = Type.GetType("System.Int16");
            DataCol8.DataType = Type.GetType("System.Int16");

            if (DtTable.Columns.Count > 0)
            {
                DtTable.Columns.Remove("EmployeeID");
                DtTable.Columns.Remove("EmployeeCode");
                DtTable.Columns.Remove("PunchDate");
                DtTable.Columns.Remove("PunchTime");
                DtTable.Columns.Remove("PunchSource");
                DtTable.Columns.Remove("dday");
                DtTable.Columns.Remove("dmonth");
                DtTable.Columns.Remove("dyear");
            }

            DtTable.Columns.AddRange(new System.Data.DataColumn[] { DataCol1, DataCol2, DataCol3, DataCol4, DataCol5, DataCol6, DataCol7, DataCol8 });
            DtSet.Tables.AddRange(new System.Data.DataTable[] { DtTable });

            return DtTable; 
        }

        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

		public int InsertBioDeviceData(string EmployeeCode, DateTime PunchDateTime)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand InsertCommand = new SqlCommand();
                InsertCommand.CommandType = CommandType.StoredProcedure;

				InsertCommand.Parameters.Add(GetParameter("@EmployeeCode", SqlDbType.VarChar, EmployeeCode));
                InsertCommand.Parameters.Add(GetParameter("@DateOfAttendance", SqlDbType.DateTime, PunchDateTime));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
                InsertCommand.Parameters.Add(GetParameter("@AddedOrModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                InsertCommand.CommandText = "pHRM_Attendances_InsertBioDevicePunchData";

                ExecuteStoredProcedure(InsertCommand);

                //ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Attendance Prepare Mathods

        public int PrepareMonthAttendanceRegister(string BioDeviceEmployeeID, int Month, int Year)
        {
            try
            {
                int ReturnValue = 0;

                DateTime PunchDateTime = DateTime.Parse(DateTime.DaysInMonth(Year, Month) + "-" + Month + "-" + Year + " 23:59:59");
                SqlCommand InsertCommand = new SqlCommand();
                InsertCommand.CommandType = CommandType.StoredProcedure;

                InsertCommand.Parameters.Add(GetParameter("@BioDeviceEmployeeID", SqlDbType.VarChar, BioDeviceEmployeeID));
                InsertCommand.Parameters.Add(GetParameter("@PrepareUpto", SqlDbType.DateTime, PunchDateTime));
                InsertCommand.CommandText = "pHRM_Attendances_Prepare";

                ExecuteStoredProcedure(InsertCommand);

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int PrepareMonthAttendanceRegisterForOffice(int Month, int Year)
        {
            try
            {
                int ReturnValue = 0;

                DateTime PunchDateTime = DateTime.Parse(DateTime.DaysInMonth(Year, Month) + "-" + Month + "-" + Year + " 23:59:59");

                SqlCommand InsertCommand = new SqlCommand();
                InsertCommand.CommandType = CommandType.StoredProcedure;

                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
                InsertCommand.Parameters.Add(GetParameter("@PrepareUpto", SqlDbType.DateTime, PunchDateTime));

                InsertCommand.CommandText = "pHRM_Attendances_PrepareForOffice";

                ExecuteStoredProcedure(InsertCommand);

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int PrepareMusterSheetByOffice(int Month, int Year, int OfficeID = -1, Boolean IncludeReportingOffice = false)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand InsertCommand = new SqlCommand();
                InsertCommand.CommandType = CommandType.StoredProcedure;

                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, (OfficeID == -1 ? Micro.Commons.Connection.LoggedOnUser.CompanyID : OfficeID)));
                InsertCommand.Parameters.Add(GetParameter("@RollMonth", SqlDbType.Int, Month));
                InsertCommand.Parameters.Add(GetParameter("@RollYear", SqlDbType.Int, Year));
                InsertCommand.Parameters.Add(GetParameter("@IncludeReportingOffice", SqlDbType.Bit, IncludeReportingOffice));

                InsertCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                InsertCommand.CommandText = "pHRM_Attendances_MusterRollPreparation";

                ExecuteStoredProcedure(InsertCommand);

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods
        #endregion
    }
}
