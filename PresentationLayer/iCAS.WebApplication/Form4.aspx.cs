using Micro.Objects.ICAS.STUDENT;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCon.iCAS.WebApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnk_test_Click(object sender, EventArgs e)
        {
            //DataTable dt = Micro.BusinessLayer.ICAS.STUDENT.StudentManagement.GetInstance.GetStudentListReport("");
            //PrintClientList(dt);
            List<Student> studentList = Micro.BusinessLayer.ICAS.STUDENT.StudentManagement.GetInstance.GetStudentList();
            PrintClientList(studentList);

        }


        public void PrintClientList(List<Student> studentList)
        {
            //Cursor.Current = Cursors.WaitCursor;
            CExcel MyXls = new CExcel();
            MyXls.NewFile(false);
            string sheetName = "Students";
            MyXls.AddSheet(sheetName, "L", 10, 10, 10, 10);
            MyXls.SetActiveSheet(sheetName);

            int currentRow = 1;
            MyXls.WriteCell(currentRow, 1, "XYZ COLLEGE", string.Empty);
            MyXls.SetCellsFont(currentRow, currentRow, currentRow, currentRow, "Arial Black", 12, "Black", true, false, false);

            currentRow++;
            MyXls.WriteCell(currentRow, 1, "STUDENTS REPORT - AS ON DATE: " + DateTime.Now.ToString(), string.Empty);
            MyXls.SetCellsFont(currentRow, currentRow, currentRow, currentRow, "Arial Black", 10, "Black", true, false, false);
            MyXls.SetCellsColor(1, 1, 2, 7, "LightYellow", 0);

            currentRow++;
            MyXls.WriteCell(currentRow, 1, "Sl#", string.Empty);
            MyXls.WriteCell(currentRow, 2, "Name", string.Empty);
            MyXls.WriteCell(currentRow, 3, "Email", string.Empty);
            MyXls.WriteCell(currentRow, 4, "Mobile", string.Empty);
            MyXls.WriteCell(currentRow, 5, "Fees Paid", string.Empty);
            MyXls.WriteCell(currentRow, 6, "Code", string.Empty);
            MyXls.WriteCell(currentRow, 7, "Status", string.Empty);

            MyXls.SetCellsFont(3, 1, 3, 7, "Arial", 10, "Black", true, false, false);
            MyXls.SetCellsColor(3, 1, 3, 7, "LightBlue", 0);

            //int i = 2;
            //int iRow = currentRow+1;
            //while (iRow < Dt.Rows.Count)
            //{
            //    dr = Dt.Rows[iRow];

            //    MyXls.WriteCell(i, 1, dr["ClientID"].ToString(), string.Empty);
            //    MyXls.WriteCell(i, 2, dr["Client Name"].ToString(), string.Empty);
            //    //MyXls.WriteCell(i, 3, dr["Nationality"].ToString(), string.Empty);
            //    MyXls.WriteCell(i, 3, dr["Email"].ToString(), string.Empty);
            //    MyXls.WriteCell(i, 4, dr["Mobile#"].ToString(), string.Empty);
            //    MyXls.WriteCell(i, 5, dr["Account Manager"].ToString(), string.Empty);
            //    MyXls.WriteCell(i, 6, dr["Status"].ToString(), string.Empty);

            //    iRow++;
            //    i++;
            //}
            int ctr = 0;
            foreach (Student s in studentList)
            {
                ctr++;
                currentRow++;
                MyXls.WriteCell(currentRow, 1, ctr.ToString(), string.Empty);
                MyXls.WriteCell(currentRow, 2, s.StudentName, string.Empty);
                MyXls.WriteCell(currentRow, 3, s.EMailID, string.Empty);
                MyXls.WriteCell(currentRow, 4, s.Mobile, string.Empty);
                MyXls.WriteCell(currentRow, 5, s.TotalFeesPaid, string.Empty);
                MyXls.WriteCell(currentRow, 6, s.StudentCode, string.Empty);
                MyXls.WriteCell(currentRow, 7, s.Status, string.Empty);


            }

            MyXls.SetColumnWidth(1, 1, 6);
            MyXls.SetColumnWidth(2, 2, 30);
            MyXls.SetColumnWidth(3, 3, 40);
            MyXls.SetColumnWidth(4, 4, 15);
            MyXls.SetColumnWidth(5, 5, 15);
            MyXls.SetColumnWidth(6, 6, 10);
            MyXls.SetColumnWidth(7, 7, 5);



            //MyXls.SetCellsBorder(1, 1, i - 1, 6, 1);
            //MyXls.SetCellsFont(2, 1, i - 1, 6, "Ariel", 9, "Black", false, false, false);
            //MyXls.SetTitleRows("$1:$1");



            MyXls.Show();
            MyXls.Dispose();
            //Cursor.Current = Cursors.Default;
        }

        protected void btnXls_Click(object sender, EventArgs e)
        {
            //var products = GetProducts();
            List<Student> studentList = Micro.BusinessLayer.ICAS.STUDENT.StudentManagement.GetInstance.GetStudentList();

            GridView1.DataSource = studentList;
            GridView1.DataBind();
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Students");
            var totalCols = GridView1.Rows[0].Cells.Count;
            var totalRows = GridView1.Rows.Count;
            var headerRow = GridView1.HeaderRow;

            //workSheet.Cells[1, 1].Value = "STUDENTS REPORT";

            for (var i = 1; i <= totalCols; i++)
            {
                workSheet.Cells[1, i].Value = headerRow.Cells[i - 1].Text;
            }
            for (var j = 1; j <= totalRows; j++)
            {
                for (var i = 1; i <= totalCols; i++)
                {
                    var product = studentList.ElementAt(j - 1);
                    workSheet.Cells[j + 1, i].Value = product.GetType().GetProperty(headerRow.Cells[i - 1].Text).GetValue(product, null);
                }
            }
            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=products.xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }



        /// <summary>
        /// http://www.smslane.com/developer/csharpsample.pdf
        /// </summary>
        /// <param name="sNumber"></param>
        private void SendSMS(string sNumber)
        {
            string sUserID = "UserName";
            string sPwd = "Password";
            string sSID = "WebSMS";
            string sMessage = "Test SMS From SMSLane";
            string sURL = "http://smslane.com/vendorsms/pushsms.aspx?user=" + sUserID + "& password = " + sPwd + " & msisdn = " + sNumber + " & sid = " + sSID + " & msg = " + sMessage + "&mt=0&fl=0";
            string sResponse = GetResponse(sURL);
            txt_Response.Text = sResponse;
                //Response.Write(sResponse);

        }

        public static string GetResponse(string sURL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
            request.MaximumAutomaticRedirections = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string sResponse = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                return sResponse;
            }
            catch
            {
                return "";
            }
        }

        protected void Button_SendSMS_Click(object sender, EventArgs e)
        {
            string sNumber = txt_Phone.Text.ToString(); //"919898123456,919227123456";
            SendSMS(sNumber);
        }

		protected void ButtonEncrypt_Click(object sender, EventArgs e)
		{
			txt_ResultEncrypt.Text = Micro.Commons.MicroSecurity.Encrypt(txt_Text2Encrypt.Text);
			
			 
		}

		protected void ButtonDecrypt_Click(object sender, EventArgs e)
		{
			txt_ResultDecrypt.Text = Micro.Commons.MicroSecurity.Decrypt(txt_Text2Decrypt.Text);
		}
    }


}