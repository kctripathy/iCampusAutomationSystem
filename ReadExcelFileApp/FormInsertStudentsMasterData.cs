using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Drawing;

// Author : Kishor Tripathy
// Date : 3/12/2014
namespace ReadExcelFileApp
{
    public partial class FormInsertStudentsMasterData : Form
    {
        public DataTable dtExcel;
        public FormInsertStudentsMasterData()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            comboBox1.SelectedIndex = 0;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog();//open dialog to choose file
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)//if there is a file choosen by the user
            {
                filePath = file.FileName;//get the path of the file
                fileExt = Path.GetExtension(filePath);//get the file extension
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        dtExcel = new DataTable();
                        dtExcel = ReadExcel(filePath, fileExt);//read excel file
                        dataGridView1.Visible = true;
                        dataGridView1.DataSource = dtExcel;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please choose a ''.xls'' or ''.xlsx'' file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);//custom messageBox to show error
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();//to close the window(Form1)
        }

        public DataTable ReadExcel(string fileName, string fileExt)
        {
            string conn = string.Empty;
            DataTable dtexcel = new DataTable();
            if (fileExt.CompareTo(".xls") == 0)//compare the extension of the file
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';";//for below excel 2007
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1';";//for above excel 2007
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                try
                {
                    string sheetNameQuery = string.Format("select * from [{0}$]", comboBox1.Text);
                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter(sheetNameQuery, con);//here we read data from sheet1
                    //OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [+21starts$]", con);//here we read data from sheet1

                    oleAdpt.Fill(dtexcel);//fill excel data into dataTable
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            return dtexcel;
        }

        private void btnWrite2Web_Click(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;

            progressBar1.Maximum = dtExcel.Rows.Count;
            int ctr = 0;
            foreach (DataRow dRow in dtExcel.Rows)
            {
                ctr++;
                //if (ctr == 1)
                //{
                //    continue; // dont read first row
                //}
                progressBar1.Value = ctr;
                label1.Text = string.Format("Now Writing the record#{0} /{1}'s info into the web database.", ctr, dRow[1].ToString());
                if (ctr >= 1)
                {
                    //if (ctr == 8) break;
                    //dataGridView1.Rows[ctr-1].Visible = false;

                    DataGridViewRow dgvRow = dataGridView1.Rows[ctr - 1];


                    Student objStudent = FillStudentObject(dRow);
                    List<StudentSubjectTaken> objStudSubjTaken = FillStudentSubjects(dRow);
                    List<StudentPreviousQual> StudentPreQualList = FillStudentPreQualList(dRow);
                    try
                    {
                        int newStudentID = StudentDataAccess.InsertStudent(objStudent, objStudSubjTaken, StudentPreQualList);
                        if (newStudentID > 0)
                        {
                            //update excel sheet
                            dgvRow.DefaultCellStyle.BackColor = Color.Green;
                        }
                    }
                    catch (Exception ex)
                    {
                        // MessageBox.Show(ex.Message.ToString());

                        textBox2.Text = textBox2.Text + objStudent.RollNo + ",\n ";
                        dgvRow.DefaultCellStyle.BackColor = Color.Red;
                        Application.DoEvents();
                        //write log 
                        continue;
                    }

                }
                Application.DoEvents();
                System.Threading.Thread.Sleep(100); //1 sec=1000 millisecond



            }
            progressBar1.Value = 0;
            label1.Text = string.Format("Completed inserting {0} records", ctr);
        }


        private Student FillStudentObject(DataRow dRowStudent)
        {
            //CLASS	Roll No	    MRIN	        Applicant Name	    Father's Name	Gender	DOB	        Blood Group	Address	Category	Mobile	Admission Date
            //9	    IA17-002	11162102/0034	BARSHA RANI RATH	JAGANNATH RATH	Female	3-Feb-2002	A+	        AT/PO- B D PUR, VIA- BARAGAM, PS- J N PRASAD,761120	Gen	9668249308	16-Jun-2017			

            //
            //  0   1           2               3                    4                  5   6           7           8                                                     9   10            11                        


            Student objStudent = new Student();
            Int32 pinCode = 761120;
            try
            {

                objStudent.SessionID = 38;//2017-18 | 35=2015-16
                objStudent.TCNo = "NA";
                objStudent.ReceiptNo = "NA";  
                
                objStudent.ClassID = int.Parse(dRowStudent[0].ToString());
                objStudent.RollNo = dRowStudent[1].ToString();
                objStudent.MRINO = dRowStudent[2].ToString();
                objStudent.StudentName = dRowStudent[3].ToString();
                objStudent.FatherName = dRowStudent[4].ToString();
                objStudent.Gender = dRowStudent[5].ToString();
                objStudent.DateOfBirth = dRowStudent[6].ToString(); //
                objStudent.BloodGroup = dRowStudent[7].ToString();
                objStudent.Address_Present_TownOrCity = dRowStudent[8].ToString();
                objStudent.Address_Present_DistrictID = 366;                
                if (objStudent.Address_Present_TownOrCity.Length > 6)
                {
                    try
                    {
                        pinCode = Int32.Parse(objStudent.Address_Present_TownOrCity.Substring(objStudent.Address_Present_TownOrCity.Length - 6));
                    }
                    catch (Exception)
                    {

                        pinCode = 0;
                    }
                    objStudent.Address_Present_PinCode = pinCode.ToString();
                }
                
                objStudent.Caste = dRowStudent[9].ToString();
                objStudent.PhoneNumber = dRowStudent[11].ToString();
                objStudent.Mobile = objStudent.PhoneNumber;
                objStudent.DateOfAdmission = dRowStudent[12].ToString();


                return objStudent;
            }
            catch (Exception ex)
            {
                return objStudent;
            }

        }

        private List<StudentSubjectTaken> FillStudentSubjects(DataRow dRowStudent)
        {
            List<StudentSubjectTaken> objStudentSubjectTaken = new List<StudentSubjectTaken>();

            return objStudentSubjectTaken;
        }

        //List<StudentPreviousQual> StudentPreQualList
        private List<StudentPreviousQual> FillStudentPreQualList(DataRow dRowStudent)
        {
            List<StudentPreviousQual> objStudentPreQualList = new List<StudentPreviousQual>();

            return objStudentPreQualList;
        }
    }

    /// <summary>
    /// student data access object
    /// </summary>
    public static class StudentDataAccess
    {
        public static int InsertStudent(Student theStudent, List<StudentSubjectTaken> StudentSubjects, List<StudentPreviousQual> StudentPreQualList)
        {
            int ReturnValueStudent = 0;
            int ReturnValueSubjects = 0;
            int ReturnValuePreQuals = 0;
            using (SqlCommand InsertCommand = new SqlCommand())
            {
                theStudent.MRINO = ".";

                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValueStudent)).Direction = ParameterDirection.Output;
                //InsertCommand.Parameters.Add(GetParameter("@StudentCode", SqlDbType.VarChar, theStudent.StudentCode));
                InsertCommand.Parameters.Add(GetParameter("@MRINO", SqlDbType.VarChar, theStudent.MRINO));
                InsertCommand.Parameters.Add(GetParameter("@ReceiptNo", SqlDbType.VarChar, theStudent.ReceiptNo));
                InsertCommand.Parameters.Add(GetParameter("@TCNo", SqlDbType.VarChar, theStudent.TCNo));
                InsertCommand.Parameters.Add(GetParameter("@ClassID", SqlDbType.Int, theStudent.ClassID));
                InsertCommand.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, theStudent.QualID));
                InsertCommand.Parameters.Add(GetParameter("@StreamID", SqlDbType.Int, theStudent.StreamID));
                InsertCommand.Parameters.Add(GetParameter("@RollNo", SqlDbType.VarChar, theStudent.RollNo));
                InsertCommand.Parameters.Add(GetParameter("@Salutation", SqlDbType.VarChar, theStudent.Salutation));
                InsertCommand.Parameters.Add(GetParameter("@StudentName", SqlDbType.VarChar, theStudent.StudentName.ToUpper()));
                InsertCommand.Parameters.Add(GetParameter("@FatherName", SqlDbType.VarChar, theStudent.FatherName.ToUpper()));
                InsertCommand.Parameters.Add(GetParameter("@MotherName", SqlDbType.VarChar, theStudent.MotherName));
                InsertCommand.Parameters.Add(GetParameter("@Gender", SqlDbType.VarChar, theStudent.Gender));
                InsertCommand.Parameters.Add(GetParameter("@Caste", SqlDbType.VarChar, theStudent.Caste));
                InsertCommand.Parameters.Add(GetParameter("@PHStatus", SqlDbType.VarChar, theStudent.PHStatus));
                InsertCommand.Parameters.Add(GetParameter("@Status", SqlDbType.VarChar, theStudent.Status));
                //InsertCommand.Parameters.Add(GetParameter("@TotalFeesPaid", SqlDbType.VarChar, theStudent.TotalFeesPaid));
                InsertCommand.Parameters.Add(GetParameter("@DateOfBirth", SqlDbType.DateTime, DateTime.Parse(theStudent.@DateOfBirth).ToString(MicroConstants.DateFormat)));
                //InsertCommand.Parameters.Add(GetParameter("@DateOfAdmission", SqlDbType.DateTime, theStudent.DateOfAdmission == string.Empty ? Convert.DBNull : DateTime.Parse(theStudent.DateOfAdmission).ToString(MicroConstants.DateFormat)));
                //InsertCommand.Parameters.Add(GetParameter("@DateOfLeaving", SqlDbType.DateTime, Convert.DBNull));
                InsertCommand.Parameters.Add(GetParameter("@Age", SqlDbType.Int, theStudent.Age));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_TownOrCity", SqlDbType.VarChar, theStudent.Address_Present_TownOrCity));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_Landmark", SqlDbType.VarChar, theStudent.Address_Present_Landmark));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_PinCode", SqlDbType.VarChar, theStudent.Address_Present_PinCode));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_DistrictID", SqlDbType.Int, theStudent.Address_Present_DistrictID));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_TownOrCity", SqlDbType.VarChar, theStudent.Address_Permanent_TownOrCity));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_Landmark", SqlDbType.VarChar, theStudent.Address_Permanent_Landmark));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_PinCode", SqlDbType.VarChar, theStudent.Address_Permanent_PinCode));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_DistrictID", SqlDbType.Int, theStudent.Address_Permanent_DistrictID));
                InsertCommand.Parameters.Add(GetParameter("@PhoneNumber", SqlDbType.VarChar, theStudent.PhoneNumber));
                InsertCommand.Parameters.Add(GetParameter("@Mobile", SqlDbType.VarChar, theStudent.Mobile));
                InsertCommand.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, theStudent.SessionID));
                InsertCommand.Parameters.Add(GetParameter("@EmailID", SqlDbType.VarChar, theStudent.EMailID));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));
                InsertCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, 8));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, 1));

                InsertCommand.Parameters.Add(GetParameter("@SLCNo", SqlDbType.VarChar, theStudent.SLCNo));
                //InsertCommand.Parameters.Add(GetParameter("@SLCDate", SqlDbType.DateTime, theStudent.SLCDate == string.Empty ? Convert.DBNull : DateTime.Parse(theStudent.SLCDate).ToString(MicroConstants.DateFormat)));

                InsertCommand.CommandText = "[pICAS_Students_Insert_excel_short]";
                ExecuteStoredProcedure(InsertCommand);
                if (InsertCommand.Parameters[0].Value.ToString() == "")
                {
                    ReturnValueStudent = -1;
                }
                else
                {
                    ReturnValueStudent = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                }

            }

            if (StudentSubjects.Count > 0)
            {
                foreach (StudentSubjectTaken StSubjects in StudentSubjects)
                {
                    using (SqlCommand InsertCommandSubjects = new SqlCommand())
                    {
                        InsertCommandSubjects.CommandType = CommandType.StoredProcedure;
                        InsertCommandSubjects.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValueSubjects)).Direction = ParameterDirection.Output;
                        InsertCommandSubjects.Parameters.Add(GetParameter("@StudentID", SqlDbType.Int, ReturnValueStudent));
                        InsertCommandSubjects.Parameters.Add(GetParameter("@SubjectID", SqlDbType.Int, StSubjects.SubjectID));
                        InsertCommandSubjects.Parameters.Add(GetParameter("@SubjectType", SqlDbType.VarChar, StSubjects.SubjectType));
                        InsertCommandSubjects.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, theStudent.SessionID));//TO DO KP Remove HardCode
                        InsertCommandSubjects.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));//TO DO KP Remove HardCode
                        InsertCommandSubjects.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, 8));//TO DO KP Remove HardCode
                        InsertCommandSubjects.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, 1));//TO DO KP Remove HardCode
                        InsertCommandSubjects.CommandText = "pICAS_Student_Subjects_Insert";
                        ExecuteStoredProcedure(InsertCommandSubjects);
                        ReturnValueSubjects = int.Parse(InsertCommandSubjects.Parameters[0].Value.ToString());
                    }
                }
            }
            if (StudentPreQualList.Count > 0)
            {
                foreach (StudentPreviousQual thePreQualifications in StudentPreQualList)
                {
                    using (SqlCommand InsertCommandPreQuals = new SqlCommand())
                    {
                        InsertCommandPreQuals.CommandType = CommandType.StoredProcedure;
                        InsertCommandPreQuals.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValuePreQuals)).Direction = ParameterDirection.Output;
                        InsertCommandPreQuals.Parameters.Add(GetParameter("@StudentID", SqlDbType.Int, ReturnValueStudent));
                        InsertCommandPreQuals.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, thePreQualifications.QualID));
                        InsertCommandPreQuals.Parameters.Add(GetParameter("@PassingYear", SqlDbType.VarChar, thePreQualifications.PassingYear));
                        InsertCommandPreQuals.Parameters.Add(GetParameter("@Board", SqlDbType.VarChar, thePreQualifications.Board));
                        InsertCommandPreQuals.Parameters.Add(GetParameter("@Division", SqlDbType.VarChar, thePreQualifications.Division));
                        InsertCommandPreQuals.Parameters.Add(GetParameter("@Percentage", SqlDbType.VarChar, thePreQualifications.Percentage));
                        InsertCommandPreQuals.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, 1));//TO DO
                        InsertCommandPreQuals.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));//TO DO
                        InsertCommandPreQuals.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, 8));//TO DO

                        InsertCommandPreQuals.CommandText = "piCAS_Student_PreQuals_Insert";
                        ExecuteStoredProcedure(InsertCommandPreQuals);
                        ReturnValuePreQuals = int.Parse(InsertCommandPreQuals.Parameters[0].Value.ToString());
                    }
                }
            }
            return ReturnValueStudent;
        }


        /// <summary>
        /// Return Oledb parameter object.
        /// </summary>
        /// <param name="paramName">Oledb parameter name</param>
        /// <param name="paramType">Oledb parameter type</param>
        /// <param name="paramValue">Oledb parameter value</param>
        /// <returns>Oledb parameter</returns>
        private static SqlParameter GetParameter(string paramName, SqlDbType paramType, object paramValue)
        {
            return GetParameter(paramName, paramType, paramValue, 0);
        }

        /// <summary>
        /// Return Oledb parameter object.
        /// </summary>
        /// <param name="paramName">Oledb parameter name</param>
        /// <param name="paramType">Oledb parameter type</param>
        /// <param name="paramValue">Oledb parameter value</param>
        /// <param name="paramSize">Oledb parameter size</param>
        /// <returns>Oledb parameter</returns>
        private static SqlParameter GetParameter(string paramName, SqlDbType paramType, object paramValue, int paramSize)
        {
            SqlParameter oParameter = new SqlParameter();
            oParameter.ParameterName = paramName;
            oParameter.SqlDbType = paramType;

            if (paramType == SqlDbType.VarChar)
            {
                oParameter.Value = (paramValue == null) ? "" : (string)paramValue;
            }
            else
            {
                oParameter.Value = paramValue;
            }

            if (paramType == SqlDbType.VarChar || paramType == SqlDbType.Int)
            {
                if (paramSize != 0)
                {
                    oParameter.Size = paramSize;
                }
            }

            oParameter.Direction = ParameterDirection.Input;
            return oParameter;
        }

        private static void ExecuteStoredProcedure(SqlCommand oCommand)
        {
            try
            {
                oCommand.Connection = GetConnection();
                oCommand.Connection.Open();
                oCommand.CommandTimeout = 50000;

                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                if (oCommand != null)
                {
                    Exception ex = new Exception(oCommand.CommandText, e);

                }
                else
                {

                }
            }
            finally
            {
                CloseConnection(oCommand.Connection);
            }
        }


        private static SqlConnection GetConnection()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ToString();
            SqlConnection oConn = new SqlConnection(ConnectionString);
            return oConn;
        }

        public static void CloseConnection(SqlConnection oConn)
        {
            if (oConn != null)
            {
                if (oConn.State == ConnectionState.Open)
                {
                    oConn.Close();
                }
                oConn.Dispose();
            }
        }

    }


    /// <summary>
    /// student object
    /// </summary>
    public class Student
    {

        public int StudentID
        {
            get;
            set;
        }

        public string RegistrationNumber
        {
            get;
            set;
        }
        public string StudentCode
        {
            get;
            set;
        }
        public string MRINO
        {
            get;
            set;
        }
        public string ReceiptNo
        {
            get;
            set;
        }
        public string TCNo
        {
            get;
            set;
        }
        public string RollNo
        {
            get;
            set;
        }
        public int ClassID
        {
            get;
            set;
        }
        public int QualID
        {
            get;
            set;
        }
        public int StreamID
        {
            get;
            set;
        }
        public string Salutation
        {
            get;
            set;
        }
        public string StudentName
        {
            get;
            set;
        }
        public string FatherName
        {
            get;
            set;
        }
        public string MotherName
        {
            get;
            set;
        }
        public string Gender
        {
            get;
            set;
        }
        public string Caste
        {
            get;
            set;
        }
        public string PHStatus
        {
            get;
            set;
        }
        public string Status
        {
            get;
            set;
        }
        public string BloodGroup
        {
            get;
            set;
        }

        
        public string TotalFeesPaid
        {
            get;
            set;
        }
        public string DateOfBirth
        {
            get;
            set;
        }
        public string DateOfAdmission
        {
            get;
            set;
        }
        public string DateOfLeaving
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        public string Address_Present_TownOrCity
        {
            get;
            set;
        }
        public string Address_Present_Landmark
        {
            get;
            set;
        }
        public string Address_Present_PinCode
        {
            get;
            set;
        }
        public int Address_Present_DistrictID
        {
            get;
            set;
        }
        public string Address_Present_DistrictName
        {
            get;
            set;
        }

        public int Address_Present_StateID
        {
            get;
            set;
        }

        public string Address_Present_StateName
        {
            get;
            set;
        }

        public int Address_Present_CountryID
        {
            get;
            set;
        }

        public string Address_Present_CountryName
        {
            get;
            set;
        }

        public string Address_Permanent_TownOrCity
        {
            get;
            set;
        }

        public string Address_Permanent_Landmark
        {
            get;
            set;
        }

        public string Address_Permanent_PinCode
        {
            get;
            set;
        }

        public int Address_Permanent_DistrictID
        {
            get;
            set;
        }

        public string Address_Permanent_DistrictName
        {
            get;
            set;
        }

        public int Address_Permanent_StateID
        {
            get;
            set;
        }

        public string Address_Permanent_StateName
        {
            get;
            set;
        }

        public int Address_Permanent_CountryID
        {
            get;
            set;
        }

        public string Address_Permanent_CountryName
        {
            get;
            set;
        }

        public string PhoneNumber
        {
            get;
            set;
        }

        public string Mobile
        {
            get;
            set;
        }
        public string EMailID
        {
            get;
            set;
        }

        public int SessionID
        {
            get;
            set;
        }
        //Student Account Pass Varibles
        public string AccountIDs
        {
            get;
            set;
        }

        public string AccountCodes
        {
            get;
            set;
        }

        public string AccountNames
        {
            get;
            set;
        }

        public string AccountFees
        {
            get;
            set;
        }

        public string BalanceTypes
        {
            get;
            set;
        }
        public string Narations
        {
            get;
            set;
        }



        public string AlumniFlag
        {
            get;
            set;
        }


        public int OfficeID
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }
        public int CompanyID
        {
            get;
            set;
        }
        public int AddedBy
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public string DateAdded
        {
            get;
            set;
        }
        public string DateModified
        {
            get;
            set;
        }
        public string LifeMemberStatus
        {
            get;
            set;
        }
        public int AlumniMembershipFeesPaid
        {
            get;
            set;
        }
        public string AlumniMembershipFeesPaidDetails
        {
            get;
            set;
        }
        public string AlumniPresentOccupation
        {
            get;
            set;
        }
        public string AlumniYearOfPassing
        {
            get;
            set;
        }
        public string SLCNo
        {
            get;
            set;
        }
        public string SLCDate
        {
            get;
            set;
        }

        public static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }
    }

    public class StudentSubjectTaken
    {
        public int StudentSubjectsTakenID
        {
            get;
            set;
        }
        public int StudentID
        {
            get;
            set;
        }
        public string SubjectType
        {
            get;
            set;
        }
        public int SubjectID
        {
            get;
            set;
        }
        public string SubjectName
        {
            get;
            set;
        }
        public int SessionID
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int AddedBy
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public string DateAdded
        {
            get;
            set;
        }
        public string DateModified
        {
            get;
            set;
        }
        public int OfficeID
        {
            get;
            set;
        }
        public int CompanyID
        {
            get;
            set;
        }
    }


    public class StudentPreviousQual
    {
        public string QualName
        {
            get;
            set;
        }
        public string QualCode
        {
            get;
            set;
        }
        public string PassingYear
        {
            get;
            set;
        }
        public int PreQualID
        {
            get;
            set;
        }
        public int StudentID
        {
            get;
            set;
        }
        public int QualID
        {
            get;
            set;
        }
        public string Board
        {
            get;
            set;
        }
        public string Division
        {
            get;
            set;
        }
        public string Percentage
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int AddedBy
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public string DateAdded
        {
            get;
            set;
        }
        public string DateModified
        {
            get;
            set;
        }
        public int OfficeID
        {
            get;
            set;
        }
        public int CompanyID
        {
            get;
            set;
        }
    }



    public class MicroConstants
    {
        /// <summary>
        /// DateFormat = "dd-MMM-yyyy"
        /// </summary>
        public const string DateFormat = "dd-MMM-yyyy";
    }
}
