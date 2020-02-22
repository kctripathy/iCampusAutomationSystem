using ClosedXML.Excel;
using Micro.Commons;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TCon.iCAS.WebApplication
{
    public partial class Reports : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Micro.Commons.Connection.LoggedOnUser == null)
            //{
            //    Response.Redirect("~/App_Error/AccessDenied.aspx");
            //}
        }

        protected void ExportExcelReport(object sender, EventArgs e)
        {
            
            Button btn = sender as Button;
            int ClassID = int.Parse(btn.CommandName.ToString());
            int SessionID = int.Parse(ddlSession.Text.ToString());

            GenerateStudentsReportInExcel(ClassID, SessionID);
        }

        public void GenerateStudentsReport(int ClassID, int SessionID)
        {
            DataTable dtStudents;
             
             
            string constr = Connection.ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SessionID", SessionID);
                cmd.Parameters.AddWithValue("@ClassID", ClassID);
                cmd.CommandText = "pICAS_RPT_GetStudentList_BySessionAndClass";

                 
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            string SheetName = string.Format("Sheet_{0}_plus_{1}", ddlSession.Text.ToString(), ClassID.ToString());

                            wb.Worksheets.Add(dt, SheetName);
                            Response.Clear();
                            Response.Buffer = true;
                            Response.Charset = "";
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment;filename=TSDC_Students_Report" + ddlSession.Text.ToString() + "_Plus" + ClassID.ToString() +  ".xlsx");
                            using (MemoryStream MyMemoryStream = new MemoryStream())
                            {
                                wb.SaveAs(MyMemoryStream);
                                MyMemoryStream.WriteTo(Response.OutputStream);
                                Response.Flush();
                                Response.End();
                            }
                        }
                    }
                    //}
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        public void GenerateStudentsReportInExcel(int ClassID, int SessionID)
        {
            DataTable dtStudents;


            string constr = Connection.ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SessionID", SessionID);
                cmd.Parameters.AddWithValue("@ClassID", ClassID);
                cmd.CommandText = "pICAS_RPT_GetStudentList_BySessionAndClass";


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        dt.TableName = "TSDC_" + ddlSession.Text.ToString() + "_Plus" + ClassID.ToString();
                        Response.ClearContent();
                        Response.AppendHeader("content-disposition", "attachment;filename=TSDC_Students_Report" + ddlSession.Text.ToString() + "_Plus" + ClassID.ToString() + ".xlsx");
                        Response.ContentType ="application/excel";

                        StringWriter sWriterObj = new StringWriter();
                        HtmlTextWriter htmlWriterObj = new HtmlTextWriter(sWriterObj);

                        GridViewReport.DataSource = dt;
                        GridViewReport.DataBind();

                        GridViewReport.RenderControl(htmlWriterObj);
                        
                        //GridViewReport.HeaderRow.Style.Add("background-color", "#ffffff");
                        //foreach (TableCell itemCell in GridViewReport.Rows)
                        //{
                        //    itemCell.Style["background-color"] = "#00ff00";
                        //}
                        Response.Write(sWriterObj.ToString());
                        Response.End();
                        //using (XLWorkbook wb = new XLWorkbook())
                        //{
                        //    string SheetName = string.Format("Sheet_{0}_plus_{1}", ddlSession.Text.ToString(), ClassID.ToString());

                        //    wb.Worksheets.Add(dt, SheetName);
                        //    Response.Clear();
                        //    Response.Buffer = true;
                        //    Response.Charset = "";
                        //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        //    Response.AddHeader("content-disposition", "attachment;filename=TSDC_Students_Report" + ddlSession.Text.ToString() + "_Plus" + ClassID.ToString() + ".xlsx");
                        //    using (MemoryStream MyMemoryStream = new MemoryStream())
                        //    {
                        //        wb.SaveAs(MyMemoryStream);
                        //        MyMemoryStream.WriteTo(Response.OutputStream);
                        //        Response.Flush();
                        //        Response.End();
                        //    }
                        //}
                    }
                    //}
                }
            }
        }

        protected void lnk_test_Click(object sender, EventArgs e)
        {

        }


        //protected void ExportExcel(object sender, EventArgs e)
        //{
        //    //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        //    string constr = Connection.ConnectionString;

        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("SELECT * FROM iCAS_Students"))
        //        {
        //            using (SqlDataAdapter sda = new SqlDataAdapter())
        //            {
        //                cmd.Connection = con;
        //                sda.SelectCommand = cmd;
        //                using (DataTable dt = new DataTable())
        //                {
        //                    sda.Fill(dt);
        //                    using (XLWorkbook wb = new XLWorkbook())
        //                    {
        //                        wb.Worksheets.Add(dt, "Students");

        //                        Response.Clear();
        //                        Response.Buffer = true;
        //                        Response.Charset = "";
        //                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //                        Response.AddHeader("content-disposition", "attachment;filename=TSDC_Students_Report.xlsx");
        //                        using (MemoryStream MyMemoryStream = new MemoryStream())
        //                        {
        //                            wb.SaveAs(MyMemoryStream);
        //                            MyMemoryStream.WriteTo(Response.OutputStream);
        //                            Response.Flush();
        //                            Response.End();
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}


        //public DataTable GetStudentList_BySessionAndClass(int SubjectID, int SectionID)
        //{
        //    using (SqlCommand SelectCommand = new SqlCommand())
        //    {
        //        SelectCommand.CommandType = CommandType.StoredProcedure;

        //        SelectCommand.Parameters.Add(GetParameter("@SubjectID", SqlDbType.Int, SubjectID));
        //        SelectCommand.Parameters.Add(GetParameter("@SectionID", SqlDbType.Int, SectionID));
        //        SelectCommand.CommandText = "pICAS_RPT_GetStudentList_BySessionAndClass";
        //        return ExecuteGetDataTable(SelectCommand);

        //    }
        //}

        //protected DataTable ExecuteGetDataTable(SqlCommand oCommand)
        //{
        //    // Variables
        //    using (DataSet DsResult = new DataSet())
        //    {
        //        DataTable dtableObject = new DataTable();
        //        using (SqlDataAdapter oAdapter = new SqlDataAdapter())
        //        {
        //            try
        //            {
        //                oCommand.Connection = Connection.ConnectionString;
        //                oCommand.Connection.Open();
        //                oCommand.CommandType = CommandType.StoredProcedure;
        //                oAdapter.SelectCommand = oCommand;
        //                oAdapter.Fill(DsResult);
        //                dtableObject = DsResult.Tables[0];
        //            }
        //            catch (Exception e)
        //            {
        //                if (oCommand != null)
        //                {
        //                    string ErrorAtProcName = this.GetType().FullName.ToString() + "~" + oCommand.CommandText;
        //                    Exception ex = new Exception(ErrorAtProcName, e);
        //                    Log.Error(ex, true);
        //                }
        //                else
        //                    Log.Error(e, true);
        //            }
        //            finally
        //            {
        //                ConnectionFactory.GetInstance.CloseConnection(oCommand.Connection);
        //            }
        //        }
        //        return dtableObject;
        //    }
        //}
    }
}