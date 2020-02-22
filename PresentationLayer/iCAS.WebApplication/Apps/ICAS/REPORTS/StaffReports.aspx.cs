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
using Micro.Objects.ICAS.STAFFS;
using Micro.BusinessLayer.ICAS.STAFFS;
using Micro.BusinessLayer.Administration;
using Micro.Commons;
using Micro.Objects.Administration;
using Micro.Framework.ReadXML;
using Micro.Objects.FinancialAccounts;
using Micro.BusinessLayer.FinancialAccounts;

namespace TCon.iCAS.WebApplication.APPS.ICAS.REPORTS
{
    public partial class StaffReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Employeeeport_Multi.SetActiveView(InputControls);
            }
        }
        protected void btn_SearchNow_Click(object sender, EventArgs e)
        {
            ReportDocument rpt = new ReportDocument();
            String Condition=string.Empty;
           CrystalReportViewer_Employee.Enabled = true;
           string str = "StaffsReport.rpt";
            rpt.Load(Server.MapPath(str));
           
            if(ddl_SearchField.SelectedIndex== 0 && ddl_SearchOperator.SelectedIndex==0)
            {
                rpt.SetDataSource(StaffMasterManagement.GetInstance.GetEmployeeList());
            }
            else 
            {
                if (ddl_SearchField.SelectedIndex != 0 && ddl_SearchOperator.SelectedValue == "2")
                {
                    Condition = ddl_SearchField.SelectedValue + MicroConstants.OPERATOR_LIKE + " '%" + txt_SearchText.Text + "%'";
                }
                else if (ddl_SearchField.SelectedIndex != 0 && ddl_SearchOperator.SelectedValue == "1")
                {
                    Condition = ddl_SearchField.SelectedValue + MicroConstants.OPERATOR_LIKE + " '" + txt_SearchText.Text + "%'";
                }
                else if (ddl_SearchField.SelectedIndex != 0 && ddl_SearchOperator.SelectedValue == "3")
                {
                    Condition = ddl_SearchField.SelectedValue + MicroConstants.OPERATOR_EQUALSTO + " '" + txt_SearchText.Text + "'";
                }
                rpt.SetDataSource(StaffMasterManagement.GetInstance.GetEmployeesSearchAll(Condition));
                
            }
            CrystalReportViewer_Employee.ReportSource = rpt;
            CrystalReportViewer_Employee.DataBind();
            CrystalReportViewer_Employee.Visible = true;
            Employeeeport_Multi.SetActiveView(ViewReport);
        }

        protected void btn_SearchNew_Click(object sender, EventArgs e)
        {
            Employeeeport_Multi.SetActiveView(InputControls);
        }
    }
}