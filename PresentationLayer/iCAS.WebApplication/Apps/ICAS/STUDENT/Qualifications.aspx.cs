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
using Micro.Objects.FinancialAccounts;
using Micro.BusinessLayer.FinancialAccounts;
namespace LTPL.ICAS.WebApplication.APPS.ICAS.STUDENT
{
    public partial class Qualifications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                multiview_Qualification.SetActiveView(InputControls);
                BindGrid();
            }
        }
        private int InsertQuals()
        {
            int Returnvalue = 0;

            Qualification TheQuals = new Qualification();
            TheQuals.QualCode = txt_QualificationCode.Text;
            TheQuals.QualType = txt_QualificationType.Text;
            TheQuals.QualName = txt_QualificationName.Text;

            Returnvalue = QualManagement.GetInstance.InsertQuals(TheQuals);
            return Returnvalue;
        }
        private int UpdateTheQualifications()
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
           gridview_Qualification.DataSource = QualManagement.GetInstance.GetQualsList();
           gridview_Qualification.DataBind();

       }
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            lbl_TheMessage.Text = string.Empty;
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
            {
                ProcReturnValue = InsertQuals();
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    dialog_Message.Show();
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_DATA_ADDED");
                    multiview_Qualification.SetActiveView(InputControls);
                }
                else
                {
                    dialog_Message.Show();
                    lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_DATA_ADDED");
                }
            }
            else
            {
                ProcReturnValue = UpdateTheQualifications();
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
            multiview_Qualification.SetActiveView(view_Grid);
           
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
            multiview_Qualification.SetActiveView(InputControls);
        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {
           
        }
       
        
          
        }
    }


