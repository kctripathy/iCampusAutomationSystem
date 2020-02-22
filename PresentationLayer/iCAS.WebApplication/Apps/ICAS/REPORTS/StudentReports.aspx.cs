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
using Micro.Objects.ICAS.STUDENT;
using Micro.BusinessLayer.ICAS.STUDENT;
using Micro.BusinessLayer.Administration;
using Micro.Commons;
using Micro.Objects.Administration;
using Micro.Framework.ReadXML;
using Micro.Objects.FinancialAccounts;
using Micro.BusinessLayer.FinancialAccounts;
using Microsoft.Reporting.WebForms;

namespace TCon.iCAS.WebApplication.APPS.ICAS.REPORTS
{
    public partial class StudentReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Studenteport_Multi.SetActiveView(InputControls);
            }
        }
        protected void btn_SearchNow_Click(object sender, EventArgs e)
        {

           // ReportViewer1.ServerReport.set
           // ReportDocument rpt = new ReportDocument();
           // String Condition=string.Empty;
           //CrystalReportViewer1.Enabled = true;

           // string str = "StudentsReport.rpt";
            
           // rpt.Load(Server.MapPath(str));
           
           // if(ddl_SearchField.SelectedIndex== 0 && ddl_SearchOperator.SelectedIndex==0)
           // {
           //     rpt.SetDataSource(StudentManagement.GetInstance.GetStudentList());
           // }
           // else 
           // {
           //     if (ddl_SearchField.SelectedIndex != 0 && ddl_SearchOperator.SelectedValue == "2")
           //     {
           //         Condition = ddl_SearchField.SelectedValue + MicroConstants.OPERATOR_LIKE + " '%" + txt_SearchText.Text + "%'";
           //     }
           //     else if (ddl_SearchField.SelectedIndex != 0 && ddl_SearchOperator.SelectedValue == "1")
           //     {
           //         Condition = ddl_SearchField.SelectedValue + MicroConstants.OPERATOR_LIKE + " '" + txt_SearchText.Text + "%'";
           //     }
           //     else if (ddl_SearchField.SelectedIndex != 0 && ddl_SearchOperator.SelectedValue == "3")
           //     {
           //         Condition = ddl_SearchField.SelectedValue + MicroConstants.OPERATOR_EQUALSTO + " '" + txt_SearchText.Text + "'";
           //     }
           //     rpt.SetDataSource(StudentManagement.GetInstance.GetStudentListReport(Condition));
                
           // }
           // CrystalReportViewer1.ReportSource = rpt;
           // CrystalReportViewer1.DataBind();
           // CrystalReportViewer1.Visible = true;

            //ReportViewer1.da 

            Studenteport_Multi.SetActiveView(ViewReport);
        }

        protected void btn_SearchNew_Click(object sender, EventArgs e)
        {
            Studenteport_Multi.SetActiveView(InputControls);
        }
    }
}