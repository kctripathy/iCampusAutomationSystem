using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using System.Data;
using Micro.Objects.HumanResource;
using System.Configuration;
using System.Drawing;

namespace Micro.WebApplication.MicroERP.HRMS
{
	public partial class ManageDevicePermissions :Page
	{
        #region Variable Declaration

        DataTable ObjDataTable = new DataTable();
        BioMetricDevice bioDevice = new BioMetricDevice();

        #endregion

        //#region Bio-Metric Device Functions
        /////// <summary>
        /////// Establish a connection with Bio-Metric Device
        /////// </summary>
        //public void ConnectBioMetricsDevice()
        //{

        //    if (ConfigurationManager.AppSettings["DeviceNumber"].ToString() != null)
        //    {
        //        bioDevice.IPAddress = ConfigurationManager.AppSettings["DeviceIP"].ToString();
        //    }
        //    else
        //    {
        //        bioDevice.IPAddress = "192.168.0.17";
        //    }

        //    if (ConfigurationManager.AppSettings["DeviceNumber"].ToString() != null)
        //    {
        //        bioDevice.DeviceNumber = int.Parse(ConfigurationManager.AppSettings["DeviceNumber"].ToString());
        //    }
        //    else
        //    {
        //        bioDevice.DeviceNumber = 1;
        //    }

        //    if (ConfigurationManager.AppSettings["DeviceDataClear"].ToString() != null)
        //    {
        //        bioDevice.DataClear = int.Parse(ConfigurationManager.AppSettings["DeviceDataClear"].ToString());
        //    }
        //    else
        //    {
        //        bioDevice.DataClear = 0;
        //    }

        //    try
        //    {
        //        if (bioDevice.IPAddress != "")
        //        {
                  
        //            if (CZKEM1.Connect_Net(bioDevice.IPAddress, 4370) == true)
        //            {

        //                txt_DeviceStatus.Text = "CONNECTED";
        //                txt_DeviceStatus.BackColor = Color.Green;


        //                btn_Import.Enabled = true;
        //                btn_Import.Visible = true;

        //               // btn_Retry.Enabled = false;
        //               // btn_Retry.Visible = false;
        //            }
        //            else
        //            {
        //                txt_DeviceStatus.Text = "DIS-CONNECTED";
        //                txt_DeviceStatus.BackColor = Color.Red;

        //                btn_Import.Enabled = false;
        //                btn_Import.Visible = false;

        //                //btn_Retry.Enabled = true;
        //                //btn_Retry.Visible = true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
               
        //    }
        //}

        // //<summary>
        // //Read Bio-Metric Device Settings
        // //</summary>
        //public void Device_GetSettings()
        //{
        //    String Ver = "";

        //    CZKEM1.GetFirmwareVersion(bioDevice.DeviceNumber, ref Ver);

        //    bioDevice.Version = Ver;

        //    if (bioDevice.Version != "")
        //    {
        //        switch (bioDevice.Version.Substring(bioDevice.Version.Length - 4))
        //        {
        //            case "2009":
        //                bioDevice.DeviceModule = 2;
        //                break;
        //            case "2010":
        //                bioDevice.DeviceModule = 1;
        //                break;
        //            case "2011":
        //                bioDevice.DeviceModule = 1;
        //                break;
        //            default:
        //                bioDevice.DeviceModule = 0;
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        bioDevice.DeviceModule = 0;
        //    }

        //    String ST = "";
        //    CZKEM1.GetDeviceIP(bioDevice.DeviceNumber, ref ST);
        //    bioDevice.IPAddress = ST;

        //    CZKEM1.GetDeviceMAC(bioDevice.DeviceNumber, ref ST);
        //    bioDevice.MACAddress = ST;

        //    int dwValue = 0;
        //    CZKEM1.GetDeviceInfo(bioDevice.DeviceNumber, 2, ref dwValue);
        //    bioDevice.DeviceNumber = dwValue;

        //    CZKEM1.GetDeviceInfo(bioDevice.DeviceNumber, 34, ref dwValue);
        //    bioDevice.DateFormat = dwValue;

        //    int dwYear = 0;
        //    int dwMonth = 0;
        //    int dwHour = 0;
        //    int dwDay = 0;
        //    int dwMinute = 0;
        //    int dwSecond = 0;

        //    CZKEM1.GetDeviceTime(bioDevice.DeviceNumber, ref dwYear, ref dwMonth, ref dwDay, ref dwHour, ref dwMinute, ref  dwSecond);

        //    string dwSerialNumber = "";
        //    CZKEM1.GetSerialNumber(bioDevice.DeviceNumber, out dwSerialNumber);
        //    bioDevice.DeviceSerialNo = dwSerialNumber;

        //    string ipsxProductCode = "";
        //    CZKEM1.GetProductCode(bioDevice.DeviceNumber, out ipsxProductCode);
        //    bioDevice.DeviceCode = ipsxProductCode;

        //    string strVersion = "";
        //    CZKEM1.GetSDKVersion(ref strVersion);
        //    bioDevice.SDKVersion = strVersion;
        //}

        // //<summary>
        // //Connect to the bio metrics device and get the attendance 
        // //</summary>
        // //<returns>The list of attendance records</returns>
        //public List<string> GetAttendanceFromDevice()
        //{
        //    List<string> AttendanceRecords = new List<string>();

        //    return AttendanceRecords;
        //}


        // //<summary>
        // //Read Attendace/Punch from Bio-Metric Device and Convert into a array
        // //</summary>
        // //<returns></returns>
        //public string[,] Device_GetAttendance()
        //{
        //    int dwVerifyMode = 0;
        //    int dwInOutMode = 0;
        //    int dwYear = 0;
        //    int dwMonth = 0;
        //    int dwDay = 0;
        //    int dwHour = 0;
        //    int dwMinute = 0;
        //    int dwSecond = 0;
        //    int dwWorkcode = 0;

        //    string timeStr = null;

        //    #region DeviceModuleCheckPoint

        //     FIRMWARE VERSION & MODEL TYPE
        //    int DeviceModelType = 0;
        //    string DeviceVersion = "";
        //    CZKEM1.GetFirmwareVersion(bioDevice.DeviceNumber, ref DeviceVersion);

        //    if (!string.IsNullOrEmpty(DeviceVersion))
        //    {
        //        switch (DeviceVersion.Substring(DeviceVersion.Length - 4))
        //        {
        //            case "2009":
        //                DeviceModelType = 2;
        //                break;
        //            case "2010":
        //                DeviceModelType = 1;
        //                break;
        //            case "2011":
        //                DeviceModelType = 1;
        //                break;
        //        }
        //    }

        //    if (DeviceModelType == 1)
        //    {
        //        if (CZKEM1.ReadGeneralLogData(bioDevice.DeviceNumber))
        //        {
        //            string dwEnrollNumber;
        //            while (CZKEM1.SSR_GetGeneralLogData(bioDevice.DeviceNumber, out dwEnrollNumber, out dwVerifyMode,
        //                out dwInOutMode, out dwYear, out dwMonth, out dwDay, out dwHour, out dwMinute, out dwSecond, ref dwWorkcode))
        //            {
        //                //Application.DoEvents();

        //                if (int.Parse(dwEnrollNumber) == 0 | int.Parse(dwEnrollNumber) < 0 | int.Parse(dwEnrollNumber) > 9999)
        //                {
        //                    DeviceModelType = (DeviceModelType == 1 ? 2 : 1);
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    else if (DeviceModelType == 2)
        //    {
        //        int dwEnrollNumber = 0;
        //        CZKEM1.ReadAllGLogData(bioDevice.DeviceNumber);

        //        while (CZKEM1.GetGeneralLogDataStr(bioDevice.DeviceNumber, ref dwEnrollNumber, ref dwVerifyMode, ref dwInOutMode, ref timeStr))
        //        {
        //            Application.DoEvents();

        //            if (dwEnrollNumber == 0 | dwEnrollNumber < 0 | dwEnrollNumber > 9999)
        //            {
        //                DeviceModelType = (DeviceModelType == 1 ? 2 : 1);
        //                break;
        //            }
        //        }
        //    }

        //    #endregion


        //    string[,] PunchData = null;

        //    long RecordCnt = 0;
        //    try
        //    {
        //        if (DeviceModelType == 1)
        //        {
        //            string dwEnrollNumber;
        //            if (CZKEM1.ReadGeneralLogData(bioDevice.DeviceNumber))
        //            {
        //                while (CZKEM1.SSR_GetGeneralLogData(bioDevice.DeviceNumber, out dwEnrollNumber, out dwVerifyMode, out dwInOutMode,
        //                    out dwYear, out dwMonth, out dwDay, out dwHour, out dwMinute, out dwSecond, ref dwWorkcode))
        //                {
        //                    RecordCnt = RecordCnt + 1;
        //                }
        //            }

        //            if (RecordCnt > 0)
        //            {
        //                PunchData = new string[RecordCnt, 2];
        //                RecordCnt = 0;

        //                PunchData[RecordCnt, 0] = "-99";
        //                PunchData[RecordCnt, 1] = "-99";

        //                if (CZKEM1.ReadGeneralLogData(bioDevice.DeviceNumber))
        //                {
        //                    while (CZKEM1.SSR_GetGeneralLogData(bioDevice.DeviceNumber, out dwEnrollNumber, out dwVerifyMode, out dwInOutMode,
        //                        out dwYear, out dwMonth, out dwDay, out dwHour, out dwMinute, out dwSecond, ref dwWorkcode))
        //                    {
        //                        Application.DoEvents();

        //                        PunchData[RecordCnt, 0] = dwEnrollNumber;
        //                        PunchData[RecordCnt, 1] = Convert.ToDateTime(String.Format("{0}/{1}/{2} {3}:{4}:{5}", dwYear, dwMonth, dwDay, dwHour, dwMinute, dwSecond)).ToString("dd-MM-yyyy HH:mm:ss");

        //                        RecordCnt = RecordCnt + 1;
        //                    }
        //                }
        //            }
        //        }
        //        else if (DeviceModelType == 2)
        //        {
        //            int dwEnrollNumber = 0;
        //            CZKEM1.ReadAllGLogData(bioDevice.DeviceNumber);
        //            while (CZKEM1.GetGeneralLogDataStr(bioDevice.DeviceNumber, ref dwEnrollNumber, ref dwVerifyMode, ref dwInOutMode, ref timeStr))
        //            {
        //                RecordCnt = RecordCnt + 1;
        //            }
        //            if (RecordCnt > 0)
        //            {
        //                PunchData = new string[RecordCnt, 2];
        //                RecordCnt = 0;

        //                PunchData[RecordCnt, 0] = "-99";
        //                PunchData[RecordCnt, 1] = "-99";

        //                CZKEM1.ReadAllGLogData(bioDevice.DeviceNumber);

        //                while (CZKEM1.GetGeneralLogDataStr(bioDevice.DeviceNumber, ref dwEnrollNumber, ref dwVerifyMode, ref dwInOutMode, ref timeStr))
        //                {
        //                    PunchData[RecordCnt, 0] = dwEnrollNumber.ToString();
        //                    PunchData[RecordCnt, 1] = Convert.ToDateTime(timeStr).ToString("dd-MM-yyyy HH:mm:ss");
        //                    RecordCnt = RecordCnt + 1;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
               
        //    }

        //    return (PunchData);
        //}

        ///// <summary>
        ///// Fill Attendance/Punch into grid for view purpose
        ///// </summary>
        //public void FillAttendanceIntoGrid()
        //{

        //    ObjDataTable.Rows.Clear();

        //    string[,] AttendanceTableArray = Device_GetAttendance();

        //    if (AttendanceTableArray != null)
        //    {
        //        for (int I = 0; I <= AttendanceTableArray.GetUpperBound(0) - 1; I++)
        //        {
        //            DataRow row = ObjDataTable.NewRow();
        //            if (AttendanceTableArray[0, 0] == "-99" & AttendanceTableArray[0, 1] == "-99")
        //            {
        //                break;
        //            }

        //            string empCodeInit = ConfigurationManager.AppSettings["DeviceEmpCodeInitializer"];

        //            string emp = empCodeInit + string.Format("{0:00000}", int.Parse(AttendanceTableArray[I, 0]));
        //            DateTime dte = Convert.ToDateTime(AttendanceTableArray[I, 1]);

        //            row["attnid"] = ObjDataTable.Rows.Count + 1;
        //            row["EmployeeCode"] = emp;
        //            row["PunchDate"] = dte;
        //            row["PunchDay"] = dte.Day;
        //            row["PunchMonth"] = dte.Month;
        //            row["PunchYear"] = dte.Year;
        //            row["PunchTime"] = dte;

        //            ObjDataTable.Rows.Add(row);
        //        }

        //        gridview_ImportList.DataSource = ObjDataTable;
        //        GetMonthNames();

        //        //ProgBr_TotalRecords.Properties.Maximum = GridCntrlView_BioMetricData.RowCount;
        //        //ProgBr_TotalRecords.EditValue = 0;

        //        if (gridview_ImportList.Rows.Count <= 0)

        //            btn_Import.Enabled = false;
        //        else
        //            btn_Import.Enabled = true;
        //    }
        //}

        ///// <summary>
        ///// Get Distinct Month and Years from Attendance Log of Current data grid.
        ///// We can use these month and year names in preparing the attendance at the end of data import process.
        ///// </summary>
        //public void GetMonthNames()
        //{
        //    //Cmb_YearMonth.Properties.Items.Clear();
        //    string LastYear = "";
        //    for (int i = 0; i < gridview_ImportList.Rows.Count - 1; i++)
        //    //for (int i = 0; i < GridCntrlView_BioMetricData.RowCount - 1; i++)
        //    {
        //        String DateOnly = DateTime.Parse(GridCntrlView_BioMetricData.GetRowCellValue(i, "PunchDate").ToString()).ToString("yyyy-MM-dd");
        //        String TimeOnly = DateTime.Parse(GridCntrlView_BioMetricData.GetRowCellValue(i, "PunchTime").ToString()).ToString("HH:mm:ss");
        //        DateTime FullDateTime = DateTime.Parse(DateOnly + " " + TimeOnly);

        //        String Lx = FullDateTime.Date.Year.ToString() + "-" + FullDateTime.Date.Month.ToString();

        //        //if (Lx != LastYear)
        //        //{
        //        //    if (Cmb_YearMonth.Properties.Items.IndexOf(Lx) < 0)
        //        //    {
        //        //        Cmb_YearMonth.Properties.Items.Add(Lx);
        //        //    }
        //        //}
        //    }
        //}

        //#endregion
        
        
        
        
        protected void Page_Load(object sender, EventArgs e)
		{
            //DATA TABLE COLUMNS... 
            ObjDataTable.Columns.Clear();

            ObjDataTable.Columns.Add("AttnID", typeof(Int16));
            ObjDataTable.Columns.Add("EmployeeCode", typeof(string));
            ObjDataTable.Columns.Add("PunchDate", typeof(DateTime));
            ObjDataTable.Columns.Add("PunchDay", typeof(Int16));
            ObjDataTable.Columns.Add("PunchMonth", typeof(Int16));
            ObjDataTable.Columns.Add("PunchYear", typeof(Int16));
            ObjDataTable.Columns.Add("PunchTime", typeof(DateTime));

           // CZKEM1.Visible = false;

            //btn_Retry_Click(sender, e);

		}

        protected void btn_Connect_Click(object sender, EventArgs e)
        {

            //btn_Connect.Enabled = false;
            ////Application.DoEvents();

            //ConnectBioMetricsDevice();


            //btn_Connect.Enabled = true;
            ////Application.DoEvents();

            //if (txt_DeviceStatus.Text == "CONNECTED")
            //{
            //    FillAttendanceIntoGrid();
            //}		
        }
        protected void btn_Import_Click(object sender, EventArgs e)
        {

            //this.Cursor = Cursors.WaitCursor;
            //ProgBr_TotalRecords.Visible = true;
            //try
            //{
            //    int Result;
            //    for (int i = 0; i < GridCntrlView_BioMetricData.RowCount - 1; i++)
            //    {
            //        String DateOnly = DateTime.Parse(GridCntrlView_BioMetricData.GetRowCellValue(i, "PunchDate").ToString()).ToString("yyyy-MM-dd");
            //        String TimeOnly = DateTime.Parse(GridCntrlView_BioMetricData.GetRowCellValue(i, "PunchTime").ToString()).ToString("HH:mm:ss");

            //        Result = BioMetricDeviceManagement.GetInstance.InsertBioDeviceData(GridCntrlView_BioMetricData.GetRowCellValue(i, "EmployeeCode").ToString(), DateTime.Parse(DateOnly + " " + TimeOnly));

            //        //                    AttendanceManagement.GetInstance.InsertAttendance(int.Parse(GridCntrlView_BioMetricData.GetRowCellValue(i, "EmployeeCode").ToString()), DateTime.Parse(DateOnly + " " + TimeOnly));

            //        ProgBr_TotalRecords.EditValue = i + 1;

            //        this.Refresh();
            //    }

            //    ProgBr_TotalRecords.EditValue = ProgBr_TotalRecords.Properties.Maximum;
            //    this.Refresh();
            //    for (int i = 0; i <= Cmb_YearMonth.Properties.Items.Count - 1; i++)
            //    {
            //        string CurMonthYear = Cmb_YearMonth.Properties.Items[i].ToString();

            //        string xYear = CurMonthYear.Substring(0, CurMonthYear.IndexOf("-"));
            //        string xMonth = CurMonthYear.Substring(xYear.Length + 1, CurMonthYear.Length - xYear.Length - 1);

            //        Result = BioMetricDeviceManagement.GetInstance.PrepareMusterSheetByOffice(int.Parse(xMonth), int.Parse(xYear));
            //    }

            //    //TODO: to clear or to not clear data after import
            //    if (bioDevice.DataClear == 1)
            //    {
            //        CZKEM1.ClearGLog(bioDevice.DeviceNumber);
            //    }

            //    FillAttendanceIntoGrid();

            //    UCAlerts.Alert("DATA IMPORT SUCCESSFULLY DONE", UserControls.MicroUserCtrlAlerts.AlertTypes.Success);

            //}
            //catch (Exception ex)
            //{
            //    UCAlerts.Alert("FAILED TO IMPORT DATA", UserControls.MicroUserCtrlAlerts.AlertTypes.Error);
            //    ErrorLog.CreateLog(ex);
            //}
            //ProgBr_TotalRecords.Visible = false;
            //this.Cursor = Cursors.Default;
        }




        protected void gridview_ImportList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridview_ImportList.PageIndex = e.NewPageIndex;
           
        }
	}
}