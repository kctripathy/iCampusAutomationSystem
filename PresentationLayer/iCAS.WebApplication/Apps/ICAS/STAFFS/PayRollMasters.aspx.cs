using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Objects.ICAS.STAFFS;
using Micro.BusinessLayer.ICAS.STAFFS;
//need to download .dll
using System.IO;
using System.Drawing;

namespace LTPL.ICAS.WebApplication.APPS.ICAS.STAFFS
{
    public partial class PayRollMasters : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Multiview_Payroll.SetActiveView(view_InputControls);
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {

        }        
        protected void btnPayslip_Click(object sender, EventArgs e)
        {
            BindEmployeePayComponents();
        }
        void BindEmployeePayComponents()
        {
            decimal x = 0;
            lbl_HeadingText.Text = string.Empty;
            GridBindEmpPayroll.DataSource = EmployeePayrollManagement.GetInstance.GetEmployeePayrollList();
            GridBindEmpPayroll.DataBind();
            foreach (GridViewRow gr in GridBindEmpPayroll.Rows)
            {
                x = x + decimal.Parse(gr.Cells[22].Text);
            }
            txt_NetPayMonth.Text = x.ToString();
            lbl_HeadingText.Text = "For period [" + DropDown_Month.SelectedItem.Text + "-" + DropDown_Year.SelectedItem.Text + "] of season " + DropDown_Session.SelectedItem.Text + " on dated :" + txt_DateOfPay.Text;
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        protected void btnexport_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Customers.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridBindEmpPayroll.AllowPaging = false;
            //Change the Header Row back to white color
            GridBindEmpPayroll.HeaderRow.Style.Add("background-color", "#FFFFFF");
            //Applying stlye to gridview header cells
            for (int i = 0; i < GridBindEmpPayroll.HeaderRow.Cells.Count; i++)
            {
                GridBindEmpPayroll.HeaderRow.Cells[i].Style.Add("background-color", "#507CD1");
            }
            int j = 1;
            //This loop is used to apply stlye to cells based on particular row
            foreach (GridViewRow gvrow in GridBindEmpPayroll.Rows)
            {
                gvrow.BackColor = Color.White;
                if (j <= GridBindEmpPayroll.Rows.Count)
                {
                    if (j % 2 != 0)
                    {
                        for (int k = 0; k < gvrow.Cells.Count; k++)
                        {
                            gvrow.Cells[k].Style.Add("background-color", "#EFF3FB");
                        }
                    }
                }
                j++;
            }
            GridBindEmpPayroll.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }

        protected void btn_PayrollCancel_Click(object sender, EventArgs e)
        {

        }

        protected void lnk_ViewPayRoll_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            String s = lnk.CommandArgument;
            List<EmployeePayroll> objPayroll = new List<EmployeePayroll>();
            objPayroll = (from xyz in EmployeePayrollManagement.GetInstance.GetEmployeePayrollList()
                                         where xyz.EmployeeID == int.Parse(s)
                                         select xyz).ToList();
            DetailsView1.DataSource = objPayroll;
            DetailsView1.DataBind();
            int j = 1;
            foreach (DetailsViewRow gvrow in DetailsView1.Rows)
            {
                if (j <= DetailsView1.Rows.Count)
                {
                    if (j == 12)
                    {
                        for (int k = 0; k < gvrow.Cells.Count; k++)
                        {
                            gvrow.Cells[k].Style.Add("background-color", "green");
                            gvrow.Cells[k].Style.Add("color", "white");
                        }
                    }
                    if (j == 16)
                    {
                        for (int k = 0; k < gvrow.Cells.Count; k++)
                        {
                            gvrow.Cells[k].Style.Add("background-color", "black");
                            gvrow.Cells[k].Style.Add("color", "white");
                        }
                    }
                    if (j == 19)
                    {
                        for (int k = 0; k < gvrow.Cells.Count; k++)
                        {
                            gvrow.Cells[k].Style.Add("background-color", "black");
                            gvrow.Cells[k].Style.Add("color", "white");
                        }
                    }
                    if (j == 20)
                    {
                        for (int k = 0; k < gvrow.Cells.Count; k++)
                        {
                            gvrow.Cells[k].Style.Add("background-color", "maroon");
                            gvrow.Cells[k].Style.Add("color", "white");
                        }
                    }
                    if (j == 21)
                    {
                        for (int k = 0; k < gvrow.Cells.Count; k++)
                        {
                            gvrow.Cells[k].Style.Add("background-color", "#004600");
                            gvrow.Cells[k].Style.Add("color", "white");
                        }
                    }
                }
                j++;
            }
        }
    }
        
    }
