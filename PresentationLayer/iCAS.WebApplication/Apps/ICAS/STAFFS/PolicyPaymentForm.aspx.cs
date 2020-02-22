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
    public partial class PolicyPaymentForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                Multiview_Policy.SetActiveView(view_InputControls);
                BindEmployeePayComponents();
            }
        }
                
        protected void btnPayslip_Click(object sender, EventArgs e)
        {
            
        }
        void BindEmployeePayComponents()
        {
            decimal x = 0;
            lbl_HeadingText.Text = string.Empty;
            gview_Employee.DataSource = StaffMasterManagement.GetInstance.GetPolicyEmployeesAll();
            gview_Employee.DataBind();
            //foreach (GridViewRow gr in GridBindEmpPolicy.Rows)
            //{
            //    x = x + decimal.Parse(gr.Cells[22].Text);
            //}
            //txt_NetPayMonth.Text = x.ToString();
            //lbl_HeadingText.Text = "For period [" + DropDown_Month.SelectedItem.Text + "-" + DropDown_Year.SelectedItem.Text + "] of season " + DropDown_Session.SelectedItem.Text + " on dated :" + txt_DateOfPay.Text;
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
            GridBindEmpPolicy.AllowPaging = false;
            //Change the Header Row back to white color
            GridBindEmpPolicy.HeaderRow.Style.Add("background-color", "#FFFFFF");
            //Applying stlye to gridview header cells
            for (int i = 0; i < GridBindEmpPolicy.HeaderRow.Cells.Count; i++)
            {
                GridBindEmpPolicy.HeaderRow.Cells[i].Style.Add("background-color", "#507CD1");
            }
            int j = 1;
            //This loop is used to apply stlye to cells based on particular row
            foreach (GridViewRow gvrow in GridBindEmpPolicy.Rows)
            {
                gvrow.BackColor = Color.White;
                if (j <= GridBindEmpPolicy.Rows.Count)
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
            GridBindEmpPolicy.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }

        protected void btn_PolicyCancel_Click(object sender, EventArgs e)
        {

        }

        protected void lnk_ViewPolicy_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            String s = lnk.CommandArgument;
            GridBindEmpPolicy.DataSource = PolicyApplicationManagement.GetInstance.GetPolicySelectAll_By_Employee(int.Parse(s));
            GridBindEmpPolicy.DataBind();
            DetailsView1.DataSource = null;
            DetailsView1.DataBind();
            lbl_HeadingText.Text = "Employee ID In:" + s;
            Multiview_Policy.SetActiveView(view_GridView);
            pnlPayment.Visible = false;
        //    foreach (DetailsViewRow gvrow in DetailsView1.Rows)
        //    {
        //        if (j <= DetailsView1.Rows.Count)
        //        {
        //            if (j == 12)
        //            {
        //                for (int k = 0; k < gvrow.Cells.Count; k++)
        //                {
        //                    gvrow.Cells[k].Style.Add("background-color", "green");
        //                    gvrow.Cells[k].Style.Add("color", "white");
        //                }
        //            }
        //            if (j == 16)
        //            {
        //                for (int k = 0; k < gvrow.Cells.Count; k++)
        //                {
        //                    gvrow.Cells[k].Style.Add("background-color", "black");
        //                    gvrow.Cells[k].Style.Add("color", "white");
        //                }
        //            }
        //            if (j == 19)
        //            {
        //                for (int k = 0; k < gvrow.Cells.Count; k++)
        //                {
        //                    gvrow.Cells[k].Style.Add("background-color", "black");
        //                    gvrow.Cells[k].Style.Add("color", "white");
        //                }
        //            }
        //            if (j == 20)
        //            {
        //                for (int k = 0; k < gvrow.Cells.Count; k++)
        //                {
        //                    gvrow.Cells[k].Style.Add("background-color", "maroon");
        //                    gvrow.Cells[k].Style.Add("color", "white");
        //                }
        //            }
        //            if (j == 21)
        //            {
        //                for (int k = 0; k < gvrow.Cells.Count; k++)
        //                {
        //                    gvrow.Cells[k].Style.Add("background-color", "#004600");
        //                    gvrow.Cells[k].Style.Add("color", "white");
        //                }
        //            }
        //        }
        //        j++;
        //    }
        }
        
        protected void btn_AddApplication_Click(object sender, EventArgs e)
        {
            Multiview_Policy.SetActiveView(view_InputControls);
        }

        protected void lnk_ViewEmpPolicy_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            String s = lnk.CommandArgument;
            var closeLink = (Control)sender;
            GridViewRow row = (GridViewRow)closeLink.NamingContainer;
            string firstCellText = row.Cells[10].Text;
            lbl_IntalmentAmount.Text = firstCellText;

            pnlPayment.Visible = true;
            DetailsView1.DataSource = PolicyApplicationManagement.GetInstance.GetPolicySelectAll_By_Employee(int.Parse(s));
            DetailsView1.DataBind();
            Multiview_Policy.SetActiveView(view_GridView);
        }

        protected void btn_NewPolicy_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffLICPolicies.aspx");
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {

        }

        protected void btn_Reset_Click(object sender, EventArgs e)
        {

        }

        protected void txt_NoOfInstal_TextChanged(object sender, EventArgs e)
        {
            int x=int.Parse(txt_NoOfInstal.Text);
            decimal y=decimal.Parse(lbl_IntalmentAmount.Text);
            decimal result = x * y;
            txt_InstalAmount.Text = result.ToString();
            txt_InstalAmount.Enabled = false;
        }
    }
        
    }
