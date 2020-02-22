using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.Objects.ICAS.EXAM;
using Micro.Objects.ICAS.STUDENT;
using Micro.BusinessLayer.ICAS.STUDENT;
using Micro.BusinessLayer.ICAS.EXAM;
using Micro.Objects.Administration;
using Micro.Framework.ReadXML;
using Micro.Objects.ICAS.FINANCE;
using Micro.BusinessLayer.ICAS.FINANCE;
namespace LTPL.ICAS.WebApplication.APPS.ICAS.STUDENT
{
    public partial class DefaultFeeSetups : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                multiview_DefaultFeeSetup.SetActiveView(InputControls);
                BindGrid();
                BindDropdown_Quals();
                BindDropdown_Streams();
                FillPrimaryGroup();
                //BindAccountingYear(string.Empty);
            }
        }
        //public void BindAccountingYear(string SearctText)
        //{
        //    List<AccountingYear> AccountingYearlist = new List<AccountingYear>();
        //    AccountingYearlist = AccountingYearManagement.GetInstance.GetAccountingYearList(SearctText);
        //    ddl_AcademicYear.DataSource = AccountingYearlist;
        //    ddl_AcademicYear.DataValueField = "AccountingYearID";
        //    ddl_AcademicYear.DataTextField = "AccountingYearDescription";
        //    ddl_AcademicYear.DataBind();
        //}
        
        private void BindDropdown_Streams()
        {
            DropDown_StreamList.Items.Clear();
            DropDown_StreamList.DataSource = StreamManagement.GetInstance.GetStreamList();
            DropDown_StreamList.DataTextField = "StreamName";//StreamManagement.GetInstance.DisplayMember;
            DropDown_StreamList.DataValueField = "StreamID";//StreamManagement.GetInstance.ValueMember;
            DropDown_StreamList.DataBind();
            DropDown_StreamList.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }

        public void FillPrimaryGroup()
        {
            ddl_ParentAccountGroup.Items.Clear();
            List<AccountGroup> TheAccountGroupList = AccountGroupManagement.GetInstance.GetMasterAccountGroupList();

            if (TheAccountGroupList.Count > 0)

                ddl_ParentAccountGroup.DataSource = TheAccountGroupList;
            ddl_ParentAccountGroup.DataTextField = AccountGroupManagement.GetInstance.DisplayMember;
            ddl_ParentAccountGroup.DataValueField = AccountGroupManagement.GetInstance.ValueMember;
            ddl_ParentAccountGroup.DataBind();
            ddl_ParentAccountGroup.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }
        private void BindDropdown_Quals()
        {
            ddl_Qualification.Items.Clear();
            List<Qualification> objQuals = new List<Qualification>();
            objQuals = (from xyzl in QualManagement.GetInstance.GetQualsList()
                        where xyzl.QualType == "C"
                        select xyzl).ToList();
            ddl_Qualification.DataSource = objQuals;
            ddl_Qualification.DataTextField = "QualCode";
            ddl_Qualification.DataValueField = "QualID";
            ddl_Qualification.DataBind();
            ddl_Qualification.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));          
        }
        private int InsertDefaultFee()
        {
            int Returnvalue = 0;

            DefaultFeeSetup TheFees = new DefaultFeeSetup();
            TheFees.QualID =int.Parse(ddl_Qualification.SelectedValue);
            TheFees.StreamID = int.Parse(DropDown_StreamList.SelectedValue);
            TheFees.AccountTypeID = int.Parse(ddl_ParentAccountGroup.SelectedValue);
            TheFees.AccountGroupID = int.Parse(ddl_AccountGroup.SelectedValue);
            TheFees.AccountID = int.Parse(ddl_AccountHeads.SelectedValue);
            TheFees.AddedBy = 1;
            TheFees.DefaultFee = decimal.Parse(txt_DefaultAmount.Text);
            Returnvalue = DefaultFeeManagement.GetInstance.InsertDefaultFee(TheFees);
            return Returnvalue;
        }
        private int UpdateDefaultFee()
        {
            int Returnvalue = 0;

            //  Qualification TheQuals= new Qualification();
            //TheQuals.Quatxt_QualificationCode.Text;
            //TheQuals.QualificationType =txt_QualificationType.Text;
            //TheQuals.QualificationName = txt_QualificationName.Text;

            //Returnvalue = ExamScheduleManagement.GetInstance.InsertSchedules(TheScdules);
            return Returnvalue;
        }
        private void BindGrid()
       {
           gridview_DefaultFee.DataSource = DefaultFeeManagement.GetInstance.GetDefaultFeeList();
           gridview_DefaultFee.DataBind();

       }
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            lbl_TheMessage.Text = string.Empty;
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
            {
                ProcReturnValue = InsertDefaultFee();
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    dialog_Message.Show();
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_DATA_ADDED");
                    multiview_DefaultFeeSetup.SetActiveView(InputControls);
                    Reset();
                    BindGrid();
                }
                else
                {
                    dialog_Message.Show();
                    lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_DATA_ADDED");
                }
            }
            else
            {
                ProcReturnValue = UpdateDefaultFee();
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    dialog_Message.Show();
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_DATA_UPDATED");
                }
                else
                {
                    dialog_Message.Show();
                    lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_DATA_UPDATED");
                }
            }
            
        }

        protected void btn_View_Click(object sender, EventArgs e)
        {
            multiview_DefaultFeeSetup.SetActiveView(view_Grid);            
        }

        protected void Qualification_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void Qualification_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void Qualification_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void Qualification_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void btn_AddNew_Click(object sender, EventArgs e)
        {
            multiview_DefaultFeeSetup.SetActiveView(InputControls);
            Reset();
        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        
        void Reset()
        {
            ddl_ParentAccountGroup.SelectedIndex = MicroConstants.NUMERIC_VALUE_ZERO;
            ddl_Qualification.SelectedIndex = MicroConstants.NUMERIC_VALUE_ZERO;
            DropDown_StreamList.SelectedIndex = MicroConstants.NUMERIC_VALUE_ZERO;
            ddl_AccountGroup.Items.Clear();
            ddl_AccountHeads.Items.Clear();
            txt_DefaultAmount.Text = string.Empty;
        }
        private void FillAccounts(int accountGroupParentID)
        {
            ddl_AccountGroup.Items.Clear();
            List<AccountGroup> theAccountGroupList = AccountGroupManagement.GetInstance.GetAccountGroupList();
            var FilterdAccountGroupList = (from mm in theAccountGroupList
                                           where
                                               mm.AccountGroupParentID == accountGroupParentID
                                           select mm).ToList();
            if (FilterdAccountGroupList.Count > 0)
            {
                ddl_AccountGroup.DataSource = FilterdAccountGroupList;
                ddl_AccountGroup.DataTextField = AccountGroupManagement.GetInstance.DisplayMember;
                ddl_AccountGroup.DataValueField = AccountGroupManagement.GetInstance.ValueMember;
                ddl_AccountGroup.DataBind();
                ddl_AccountGroup.Items.Insert(MicroConstants.NUMERIC_VALUE_ZERO, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
            }
        }
        protected void ddl_ParentAccountGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillAccounts(int.Parse(ddl_ParentAccountGroup.SelectedValue));
        }

        protected void ddl_AccountGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_AccountHeads.Items.Clear();
            List<AccountMaster> objAccList = new List<AccountMaster>();
            objAccList = (from xyzl in AccountMasterManagement.GetInstance.GetAccountMasterList()
                        where xyzl.AccountGroupID == int.Parse(ddl_AccountGroup.SelectedValue)
                        select xyzl).ToList();
            ddl_AccountHeads.DataSource = objAccList;
            ddl_AccountHeads.DataTextField = AccountMasterManagement.GetInstance.DisplayMember;
            ddl_AccountHeads.DataValueField = AccountMasterManagement.GetInstance.ValueMember;
            ddl_AccountHeads.DataBind();
            ddl_AccountHeads.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }
       
        
          
        }
    }


