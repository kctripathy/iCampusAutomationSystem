using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.DataAccessLayer.ICAS.STAFFS;
using System.Reflection;
using Micro.Objects.ICAS.STAFFS;
using System.Data;
using Micro.Commons;

namespace Micro.IntegrationLayer.ICAS.STAFFS
{
   public    class AttendanceIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static void InsertAttendance(int EmployeeID, DateTime PunchDateTime)
        {
            try
            {
                AttendanceDataAccess.GetInstance.InsertAttendance(EmployeeID, PunchDateTime);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static void InsertAttendance(int EmployeeID, DateTime PunchDateTime, Micro.Commons.MicroEnums.AttendanceType AttendanceType)
        {
            try
            {
                AttendanceDataAccess.GetInstance.InsertAttendance(EmployeeID, PunchDateTime, AttendanceType);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        //public static DataTable GetEmployeeDetailsAttendanceRegister(int EmployeeID, int _Month, int _Year)
        //{
        //    try
        //    {
        //        return AttendanceDataAccess.GetInstance.GetEmployeeDetailsAttendanceRegister(EmployeeID, _Month, _Year);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        public static List<Attendance> GetEmployeeDetailsAttendanceRegister(int EmployeeID, int _Month, int _Year)
        {
            List<Attendance> AttendanceList = new List<Attendance>();
            DataTable AttendanceTable = AttendanceDataAccess.GetInstance.GetEmployeeDetailsAttendanceRegister(EmployeeID, _Month, _Year);

            foreach (DataRow dr in AttendanceTable.Rows)
            {
                Attendance TheAttendance = DataRowToObject(dr);

                AttendanceList.Add(TheAttendance);
            }

            return AttendanceList;
        }

        public static Attendance DataRowToObject(DataRow dr)
        {
            Attendance TheAttendance = new Attendance();
            TheAttendance.EmployeeID = int.Parse(dr["EmployeeID"].ToString());
            TheAttendance.DateOfAttendance = DateTime.Parse(dr["DateOfAttendance"].ToString()).ToString(MicroConstants.DateFormat);
            TheAttendance.InTime = dr["InTime"].ToString();



            TheAttendance.OutTime = dr["OutTime"].ToString();
            TheAttendance.ShiftAlias = dr["ShiftAlias"].ToString();
            TheAttendance.IsAbsent = Boolean.Parse(dr["IsAbsent"].ToString());
            TheAttendance.IsHoliday = Boolean.Parse(dr["IsHoliday"].ToString());
            TheAttendance.IsLate = Boolean.Parse(dr["IsLate"].ToString());
            TheAttendance.IsLeave = Boolean.Parse(dr["IsLeave"].ToString());
            TheAttendance.IsPresent = Boolean.Parse(dr["IsPresent"].ToString());
            TheAttendance.IsPresentOnHoliday = Boolean.Parse(dr["IsPresentOnHoliday"].ToString());
            TheAttendance.IsPresentOnWeeklyOff = Boolean.Parse(dr["IsPresentOnWeeklyOff"].ToString());
            TheAttendance.IsWeeklyOff = Boolean.Parse(dr["IsWeeklyOff"].ToString());


            return TheAttendance;
        }
        //public static Attendance GetEmployeeDetailsAttendanceRegister(int EmployeeID, int _Month, int _Year)
        //{
        //    DataRow AttendanceRow = AttendanceDataAccess.GetInstance.GetEmployeeDetailsAttendanceRegister(EmployeeID, _Month, _Year);

        //    Attendance TheAttendance = DataRowToObject(AttendanceRow);

        //    return TheAttendance;
        //}
        public static Attendance GetEmployeeAttendanceByDate(int EmployeeID, DateTime DateOfAttendance)
        {
            try
            {
                Attendance Attn = new Attendance();
                DataRow dr = AttendanceDataAccess.GetInstance.GetEmployeeAttendanceByDate(EmployeeID, DateOfAttendance);
                if (dr != null)
                {
                    Attn.AttendanceID = int.Parse(dr["AttendanceID"].ToString());
                    Attn.ShiftAlias = DateTime.Parse(dr["DateOfAttendance"].ToString()).ToString(MicroConstants.DateFormat);

                    if (dr["InTime"].ToString() != "")
                    {
                        Attn.InTime = dr["InTime"].ToString();
                        Attn.InSource = (Boolean.Parse(dr["InSource"].ToString()) == false ? 0 : 1);
                    }

                    if (dr["OutTime"].ToString() != "")
                    {
                        Attn.OutTime = dr["OutTime"].ToString();
                        Attn.OutSource = (Boolean.Parse(dr["OutSource"].ToString()) == false ? 0 : 1);
                    }
                }
                else
                {
                    Attn = null;
                }

                return Attn;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion





        public static List<Attendance> GetEmployeeDetailsAttendanceRegisterSummaryByDepartmentID(int DepartmentID, int _Month, int _Year)
        {
            List<Attendance> AttendanceList1 = new List<Attendance>();
            DataTable AttendanceTable1 = AttendanceDataAccess.GetInstance.GetEmployeeDetailsAttendanceRegisterSummaryByDepartmentID(DepartmentID, _Month, _Year);

            foreach (DataRow dr in AttendanceTable1.Rows)
            {
                Attendance TheAttendance1 = DataRowToObject1(dr);

                AttendanceList1.Add(TheAttendance1);
            }

            return AttendanceList1;
        }



        public static Attendance DataRowToObject1(DataRow dr)
        {
            Attendance TheAttendance = new Attendance();
            TheAttendance.EmployeeID = int.Parse(dr["EmployeeID"].ToString());
            TheAttendance.EmployeeName = dr["EmployeeName"].ToString();
            TheAttendance.EmployeeCode = dr["EmployeeCode"].ToString();
            TheAttendance.DesignationDescription = dr["DesignationName"].ToString();
            TheAttendance.DepartmentDescription = dr["DepartmentName"].ToString();
            TheAttendance.TotalPresent = int.Parse(dr["P"].ToString());
            TheAttendance.TotalAbsent = int.Parse(dr["A"].ToString());
            TheAttendance.TotalWeeklyOff = int.Parse(dr["WO"].ToString());
            TheAttendance.TotalPresentonWeeklyOff = int.Parse(dr["PW"].ToString());
            TheAttendance.TotalHoliday = int.Parse(dr["H"].ToString());
            TheAttendance.TotalLeave = int.Parse(dr["L"].ToString());
            return TheAttendance;
        }

    }
}
