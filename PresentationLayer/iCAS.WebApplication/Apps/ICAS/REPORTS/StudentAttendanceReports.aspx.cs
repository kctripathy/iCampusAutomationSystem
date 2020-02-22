using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using Micro.BusinessLayer.ICAS.STUDENT;
using Micro.BusinessLayer.Administration;
using Micro.Commons;
using Micro.Objects.Administration;
using Micro.Framework.ReadXML;
using Micro.Objects.FinancialAccounts;
using Micro.BusinessLayer.FinancialAccounts;

namespace TCon.iCAS.WebApplication.APPS.ICAS.REPORTS
{
    public partial class StudentAttendanceReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StuAttnport_Multi.SetActiveView(InputControls);
            }
        }
        protected void btn_SearchNow_Click(object sender, EventArgs e)
        {
            ReportDocument rpt = new ReportDocument();
            String Condition=string.Empty;
           CrystalReportViewer_Employee.Enabled = true;
           string str = "StudentAttendanceReport.rpt";
            rpt.Load(Server.MapPath(str));
           
            if(ddl_SearchField.SelectedIndex== 0 && ddl_SearchOperator.SelectedIndex==0)
            {
                //rpt.SetDataSource(StaffMasterManagement.GetInstance.GetEmployeeList());
            }
            else 
            {
                if (ddl_SearchField.SelectedIndex != 0 && ddl_SearchOperator.SelectedValue == "2")
                {
                    Condition = Convert.ToDateTime(txt_SearchText.Text).ToString(MicroConstants.DateFormat);
                    rpt.SetDataSource(StudentAttendanceReportManagement.GetInstance.GetAbsentAttnsListByDate(Condition));
                }
                else if (ddl_SearchField.SelectedIndex != 0 && ddl_SearchOperator.SelectedValue == "1")
                {
                    Condition = Convert.ToDateTime(txt_SearchText.Text).ToString(MicroConstants.DateFormat);
                    rpt.SetDataSource(StudentAttendanceReportManagement.GetInstance.GetPresentAttnsListByDate(Condition));
                }
                //else if (ddl_SearchField.SelectedIndex != 0 && ddl_SearchOperator.SelectedValue == "3")
                //{
                //    Condition = ddl_SearchField.SelectedValue + MicroConstants.OPERATOR_EQUALSTO + " '" + txt_SearchText.Text + "'";
                //}                                
            }
            CrystalReportViewer_Employee.ReportSource = rpt;
            CrystalReportViewer_Employee.DataBind();
            CrystalReportViewer_Employee.Visible = true;
            
            StuAttnport_Multi.SetActiveView(ViewReport);
        }

        protected void btn_SearchNew_Click(object sender, EventArgs e)
        {
            StuAttnport_Multi.SetActiveView(InputControls);
        }
    }
}