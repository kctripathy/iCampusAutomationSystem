using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Micro.Objects.ICAS.STAFFS;
using Micro.BusinessLayer.ICAS.STAFFS;

using System.Data;
using Micro.Framework.ReadXML;
using Micro.Objects.Administration;
using Micro.Commons;
using Micro.BusinessLayer.Administration;
using Micro.BusinessLayer.HumanResource;

using System.Web.UI.WebControls;

namespace LTPL.ICAS.WebApplication.APPS.ICAS.STAFFS
{
    public partial class MasterPayComponents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack && !IsCallback)
            {
                multiview_EmployeePayrollComponents.SetActiveView(InputControls);
                //BindGridView();
                BindComponent();
            }
        }
        void BindComponent()
        {
            //Dropdown_PayComponentID.DataSource = PayrollComponentManagement.GetInstance.GetPayrollComponentList();
            //Dropdown_PayComponentID.DataTextField = PayrollComponentManagement.GetInstance.DisplayMember;
            //Dropdown_PayComponentID.DataValueField = PayrollComponentManagement.GetInstance.DefaultColumns;
            //Dropdown_PayComponentID.DataBind();
            //Dropdown_PayComponentID.Items.Insert(0,MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);

            DropDown_ParentComponent.DataSource = PayrollComponentManagement.GetInstance.GetPayrollComponentList();
            DropDown_ParentComponent.DataTextField = PayrollComponentManagement.GetInstance.DisplayMember;
            DropDown_ParentComponent.DataValueField = PayrollComponentManagement.GetInstance.DefaultColumns;
            DropDown_ParentComponent.DataBind();
            DropDown_ParentComponent.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
        }
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            //int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;
            //DataTable dt1 = new DataTable();           
            //if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
            //{
            //    dt1 = (DataTable)ViewState["Data"];
            //    ProcReturnValue = InsertEmployeeComponents(dt1);
            //    if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
            //    {
            //        lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_Student_ADDED");
            //        multiview_EmployeePayrollComponents.SetActiveView(InputControls);
            //    }
            //    else
            //    {
            //        lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_Student_ADDED");
            //    }
            //}
            //else
            //{
                //ProcReturnValue = UpdateTheQualifications();
                //if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                //{
                //    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_Student_UPDATED");
                //}
                //else
                //{
                //    lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_Student_UPDATED");
                //}
            //}

            //dialog_Message.Show();
        }

        //private int InsertEmployeeComponents(DataTable dt)
        //{
        //    EmpPayrollcomponent TheComponent = new EmpPayrollcomponent();
        //    TheComponent.EmployeeID = int.Parse(lblemployeeBind.Text);
        //    TheComponent.SessionID = 1;
        //    int ReturnValue = PayrollComponentManagement.GetInstance.InsertEmpPayRollComponent(dt,TheComponent);
        //    return ReturnValue;
        //}

        protected void btn_View_Click(object sender, EventArgs e)
        {

        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {

        }        

        protected void btn_AddNew_Click(object sender, EventArgs e)
        {

        }
        //public void BindGridView()
        //{
        //    ListView1.DataSource = StaffMasterManagement.GetInstance.GetOfficeEmployeeList();
        //    ListView1.DataBind();
        //}        
        //void BindEmployeePayComponents(int EmployeeID)
        //{
        //    GridBindEmpPayComponents.DataSource = PayrollComponentManagement.GetInstance.GetEmployeePayrollComponentList(EmployeeID);
        //    GridBindEmpPayComponents.DataBind();
        //}
        //protected void Dropdown_PayComponentID_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    lbl_message.Text = string.Empty;
        //    if (Dropdown_PayComponentID.SelectedValue.Contains("||"))
        //    {
        //        string[] values = Dropdown_PayComponentID.SelectedValue.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
        //        if (values.Length > 0)
        //        {
        //            string ComponentType = values[0];
        //            string ComponentID = values[1];
        //            DropDown_PayComponentType.SelectedValue = ComponentType;
        //            lbl_PaycomponentID.Text = ComponentID;                    
        //        }               
        //    }
        //}
        //bool CheckDuplicate()
        //{
        //    lbl_message.Text=string.Empty;
        //    bool RetVal = true;
        //    foreach (GridViewRow gr in gview_Component.Rows)
        //    {
        //        if (gr.Cells[1].Text == lbl_PaycomponentID.Text)
        //        {
        //            RetVal = false;
        //            lbl_message.Text = "Sorry This Component is Exist in the List";
        //        }
        //    }
        //    return RetVal;
        //}
        //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (lblemployeeBind.Text != string.Empty && CheckDuplicate()==true)
        //    {
        //        if (ViewState["Data"] == null)
        //        {
        //            DataTable dt = new DataTable();
        //            dt.Columns.Add("EmployeeID");
        //            dt.Columns.Add("PayComponentID");
        //            dt.Columns.Add("PayComponentName");
        //            dt.Columns.Add("ComponentValue");
        //            dt.Columns.Add("ComponentType");
        //            dt.Columns.Add("SessionID");
        //            dt.Columns.Add("AddedBy");
        //            ViewState["Data"] = dt;
        //            createrow(dt,lblemployeeBind.Text,lbl_PaycomponentID.Text, Dropdown_PayComponentID.SelectedItem.Text, txt_PayAmount.Text, DropDown_PayComponentType.SelectedValue,"1","1");
        //            gview_Component.DataSource = (DataTable)ViewState["Data"];
        //            gview_Component.DataBind();
        //            ResetComponentValues();
        //        }
        //        else
        //        {
        //            DataTable dt1 = new DataTable();
        //            dt1 = (DataTable)ViewState["Data"];
        //            createrow(dt1,lblemployeeBind.Text, lbl_PaycomponentID.Text, Dropdown_PayComponentID.SelectedItem.Text, txt_PayAmount.Text, DropDown_PayComponentType.SelectedValue, "1", "1");
        //            gview_Component.DataSource = (DataTable)ViewState["Data"];
        //            gview_Component.DataBind();
        //            ResetComponentValues();
        //        }
        //    }
        //    else
        //    {
        //        lblemployeeBind.Text = "Please Select a Employee>>";
        //    }
        //}
        //void createrow(DataTable dt, string s1, string s2, string s3, string s4, string s5, string s6,string s7)
        //{
        //    DataTable dt1 = (DataTable)ViewState["Data"];
        //    DataRow dr1 = dt1.NewRow();
        //    dr1["EmployeeID"] = s1;
        //    dr1["PayComponentID"] = s2;
        //    dr1["PayComponentName"] = s3;
        //    dr1["ComponentValue"] = s4;
        //    dr1["ComponentType"] = s5;
        //    dr1["SessionID"] = s6;
        //    dr1["AddedBy"] = s7;   
        //    dt1.Rows.Add(dr1);

        //}
        //private void ResetComponentValues()
        //{
        //    txt_PayAmount.Text = string.Empty;
        //    DropDown_PayComponentType.SelectedIndex = 0;
        //    Dropdown_PayComponentID.SelectedIndex = 0;
        //    lbl_PaycomponentID.Text = string.Empty;           
        //}

        //protected void GridBindEmpPayComponents_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    GridBindEmpPayComponents.EditIndex = -1;
        //    BindEmployeePayComponents(int.Parse(lblemployeeBind.Text));
        //}

        //protected void GridBindEmpPayComponents_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName.Equals("Insert"))
        //    {
        //        string ComponentType = string.Empty;
        //        string ComponentID = string.Empty;
        //        TextBox txtPCaddValue = (TextBox)GridBindEmpPayComponents.FooterRow.FindControl("txtPCaddValue");
        //        DropDownList ddladdPayComponent = (DropDownList)GridBindEmpPayComponents.FooterRow.FindControl("ddladdPayComponent");
        //        DropDownList ddladdPayComponentType = (DropDownList)GridBindEmpPayComponents.FooterRow.FindControl("ddladdPayComponentType");
        //        if (ddladdPayComponent.SelectedValue.Contains("||"))
        //        {
        //            string[] values = ddladdPayComponent.SelectedValue.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
        //            if (values.Length > 0)
        //            {
        //                ComponentType = values[0];
        //                ComponentID = values[1];
        //                ddladdPayComponentType.SelectedValue = ComponentType;                        
        //            }
        //        }              
        //        EmpPayrollcomponent TheComponent = new EmpPayrollcomponent();
        //        TheComponent.EmployeeID = int.Parse(lblemployeeBind.Text);
        //        TheComponent.PayComponentID = int.Parse(ComponentID);
        //        TheComponent.PayComponentAmount = txtPCaddValue.Text;
        //        TheComponent.SessionID = 1;
        //        TheComponent.AddedBy = 1;
        //        PayrollComponentManagement.GetInstance.InsertSingleEmployeeComponent(TheComponent);
        //        BindEmployeePayComponents(int.Parse(lblemployeeBind.Text));
        //    }            
        //}

        //protected void GridBindEmpPayComponents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    int RecordID = Convert.ToInt32(GridBindEmpPayComponents.DataKeys[e.RowIndex].Value);
        //    EmpPayrollcomponent TheComponent = new EmpPayrollcomponent();
        //    TheComponent.RecordNo = RecordID;
        //    PayrollComponentManagement.GetInstance.DeleteSingleEmployeeComponent(TheComponent);
        //    BindEmployeePayComponents(int.Parse(lblemployeeBind.Text));
        //}

        //protected void GridBindEmpPayComponents_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    GridBindEmpPayComponents.EditIndex = e.NewEditIndex;           
        //    BindEmployeePayComponents(int.Parse(lblemployeeBind.Text));
        //}

        //protected void GridBindEmpPayComponents_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    string ComponentType = string.Empty;
        //    string ComponentID = string.Empty;
        //    int RecordID = int.Parse(((Label)(GridBindEmpPayComponents.Rows[e.RowIndex].Cells[1].FindControl("lbleid"))).Text);
        //    string PayComponentVal = ((DropDownList)(GridBindEmpPayComponents.Rows[e.RowIndex].Cells[1].FindControl("ddlPayComponent"))).SelectedValue;
        //    string ComponentValue = ((TextBox)(GridBindEmpPayComponents.Rows[e.RowIndex].Cells[1].FindControl("txtPCValue"))).Text;
        //    if (PayComponentVal.Contains("||"))
        //    {
        //        string[] values = PayComponentVal.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
        //        if (values.Length > 0)
        //        {
        //            ComponentType = values[0];
        //            ComponentID = values[1];                    
        //        }
        //    }
        //    EmpPayrollcomponent TheComponent = new EmpPayrollcomponent();
        //    TheComponent.RecordNo = RecordID;
        //    TheComponent.EmployeeID = int.Parse(lblemployeeBind.Text);
        //    TheComponent.PayComponentID = int.Parse(ComponentID);
        //    TheComponent.PayComponentAmount = ComponentValue;
        //    TheComponent.SessionID = 1;
        //    TheComponent.ModifiedBy = 1;
        //    PayrollComponentManagement.GetInstance.UpdateSingleEmployeeComponent(TheComponent);
        //    GridBindEmpPayComponents.EditIndex = -1;
        //    BindEmployeePayComponents(int.Parse(lblemployeeBind.Text));
        //}

        //protected void GridBindEmpPayComponents_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
            
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        if ((e.Row.RowState & DataControlRowState.Edit) > 0)
        //        {
        //            DropDownList ddlpayCompo = (DropDownList)e.Row.FindControl("ddlPayComponent");
        //            DropDownList ddlpayCompoType = (DropDownList)e.Row.FindControl("ddlPayComponentType");
        //            Label lblPaycomponent = (Label)e.Row.FindControl("lblPaycomponent");
        //            Label lblPaycomponentType = (Label)e.Row.FindControl("lblPaycomponentType");
        //            //bind dropdownlist
        //            if (ddlpayCompo != null)
        //            {
        //                ddlpayCompo.DataSource = PayrollComponentManagement.GetInstance.GetPayrollComponentList();
        //                ddlpayCompo.DataTextField = PayrollComponentManagement.GetInstance.DisplayMember;
        //                ddlpayCompo.DataValueField = PayrollComponentManagement.GetInstance.DefaultColumns;
        //                ddlpayCompo.DataBind();
        //                ddlpayCompo.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
        //            }
        //            ddlpayCompo.SelectedValue=lblPaycomponent.Text;
        //            ddlpayCompoType.SelectedValue = lblPaycomponentType.Text;
        //            //ddlpayCompo.Items.FindByValue((e.Row.FindControl("lblPaycomponent") as Label).Text).Selected = true;
        //            //DataRowView dr = e.Row.DataItem as DataRowView;
        //            //ddlpayCompo.SelectedValue = dr["PayComponentType"].ToString()+"-"+dr["PayComponentID"].ToString();
        //        }
        //    }
            
        //    if (e.Row.RowType == DataControlRowType.Footer)
        //    {
        //        DropDownList ddlpayCompoAdd = (DropDownList)e.Row.FindControl("ddladdPayComponent");
        //        ddlpayCompoAdd.DataSource = PayrollComponentManagement.GetInstance.GetPayrollComponentList();
        //        ddlpayCompoAdd.DataTextField = PayrollComponentManagement.GetInstance.DisplayMember;
        //        ddlpayCompoAdd.DataValueField = PayrollComponentManagement.GetInstance.DefaultColumns;
        //        ddlpayCompoAdd.DataBind();
        //        ddlpayCompoAdd.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
        //    }
        //}

        //protected void ddladdPayComponent_SelectedIndexChanged(object sender, EventArgs e)
        //{          
        //    string ComponentType = string.Empty;
        //    string ComponentID = string.Empty;
        //    bool CheckVal = true;
        //    DropDownList ddl = (DropDownList)sender;
        //    GridViewRow row = (GridViewRow)ddl.NamingContainer;
        //    DropDownList ddladdPayComponent = ((DropDownList)row.FindControl("ddladdPayComponent"));
        //    DropDownList ddladdPayComponentType = ((DropDownList)row.FindControl("ddladdPayComponentType"));
        //    foreach (GridViewRow gr in GridBindEmpPayComponents.Rows)
        //    {
        //        Label lblPaycomponentbind=(Label)gr.FindControl("lblPaycomponentbind");
        //        if (lblPaycomponentbind != null)//Check Weather null or not
        //        {
        //            if (lblPaycomponentbind.Text == ddladdPayComponent.SelectedItem.Text)
        //            {
        //                CheckVal = false;
        //            }
        //        }
        //    }
        //    if (CheckVal == true)
        //    {
        //        lbl_message.Text = string.Empty;
        //        if (ddladdPayComponent.SelectedValue.Contains("||"))
        //        {
        //            string[] values = ddladdPayComponent.SelectedValue.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
        //            if (values.Length > 0)
        //            {
        //                ComponentType = values[0];
        //                ComponentID = values[1];
        //                ddladdPayComponentType.SelectedValue = ComponentType;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        lbl_message.Text = "!!!Sorry Item Already in the List:Choose Another";
        //        ddladdPayComponentType.SelectedIndex = 0;
        //        ddladdPayComponent.SelectedIndex = 0;
        //    }
        //}

        //protected void ddlPayComponent_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string ComponentType = string.Empty;
        //    string ComponentID = string.Empty;
        //    bool CheckVal = true;
        //    DropDownList ddl = (DropDownList)sender;
        //    GridViewRow row = (GridViewRow)ddl.NamingContainer;
        //    DropDownList ddlPayComponent = ((DropDownList)row.FindControl("ddlPayComponent"));
        //    DropDownList ddlPayComponentType = ((DropDownList)row.FindControl("ddlPayComponentType"));
        //    foreach (GridViewRow gr in GridBindEmpPayComponents.Rows)
        //    {
        //        Label lblPaycomponentbind = (Label)gr.FindControl("lblPaycomponentbind");
        //        if (lblPaycomponentbind != null)//Check Weather null or not
        //        {
        //            if (lblPaycomponentbind.Text == ddlPayComponent.SelectedItem.Text)
        //            {
        //                CheckVal = false;
        //            }
        //        }
        //    }
        //    if (CheckVal == true)
        //    {
        //        lbl_message.Text = string.Empty;
        //        if (ddlPayComponent.SelectedValue.Contains("||"))
        //        {
        //            string[] values = ddlPayComponent.SelectedValue.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
        //            if (values.Length > 0)
        //            {
        //                ComponentType = values[0];
        //                ComponentID = values[1];
        //                ddlPayComponentType.SelectedValue = ComponentType;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        lbl_message.Text = "!!!Sorry Item Already in the List:Choose Another";
        //        ddlPayComponentType.SelectedIndex = 0;
        //        ddlPayComponent.SelectedIndex = 0;
        //    }
        //}

        protected void DropDown_Relation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDown_Relation.SelectedValue == "3")
            {
                txtPerchantage.Visible = true;
                txtPerchantage.Text = string.Empty;
            }
            else
            {
                txtPerchantage.Visible = false;
                txtPerchantage.Text = string.Empty;
            }
        }

        protected void RadioSelectComponent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDown_Relation.SelectedValue == "Yes")
            {
                pnlParentStaffDetail.Visible = true;
                DropDown_ParentComponent.SelectedIndex = 0;
                DropDown_Relation.SelectedIndex = 0;
                txtPerchantage.Text = string.Empty;                
            }
            else
            {
                pnlParentStaffDetail.Visible = false;
                DropDown_ParentComponent.SelectedIndex = 0;
                DropDown_Relation.SelectedIndex = 0;
                txtPerchantage.Text = string.Empty;
            }
        }
        
    }
    
}