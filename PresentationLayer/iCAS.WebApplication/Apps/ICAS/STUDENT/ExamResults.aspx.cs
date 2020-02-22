using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
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
    public partial class ExamResults : BasePage
    {
        protected static class PageVariables
        {
            public static ExamResult ThisExamResult
            {
                get
                {
                    ExamResult ThisExamResult = HttpContext.Current.Session["ThisExamResult"] as ExamResult;
                    return ThisExamResult;
                }
                set
                {
                    HttpContext.Current.Session.Add("ThisExamResult", value);
                }
            }
            public static List<ExamResult> ExamResultList
            {
                get
                {
                    List<ExamResult> ExamResultList = HttpContext.Current.Session["ExamResultList"] as List<ExamResult>;
                    return ExamResultList;
                }
                set
                {
                    HttpContext.Current.Session.Add("ExamResultList", value);
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {

                SetValidationMessages();
                BindDropdown_Exams();                                          
            }
        }

        private void SetValidationMessages()
        {
            if (Connection.LoggedOnUser.UserType == "Student")
            {
                ExamResults_Multi.SetActiveView(InputControls);
                btn_View.Visible = false;
            }
            else
            {
                Bind_AllExamResult_List();                
            }
        }               
        public List<ObjExamSehedules> BindThisSechedule()
        {           
            ObjExamSehedules objSechedule = new ObjExamSehedules();
            objSechedule = (from xyzl in ExamScheduleManagement.GetInstance.GetExamSeduleList()
                                              where xyzl.ExamScheduleID ==int.Parse(drpdwn_ExamResultSeheduleID.SelectedValue)
                                              select xyzl).Single();
            List<ObjExamSehedules> obj = new List<ObjExamSehedules>();
            obj.Add(objSechedule);
            return obj;
        }
        private void BindDropdown_Exams()
        {
            drpdwn_ExamResultSeheduleID.DataSource = ExamManagement.GetInstance.GetExamsList();
            drpdwn_ExamResultSeheduleID.DataTextField = ExamManagement.GetInstance.DisplayMember;
            drpdwn_ExamResultSeheduleID.DataValueField = ExamManagement.GetInstance.ValueMember;
            drpdwn_ExamResultSeheduleID.DataBind();
            drpdwn_ExamResultSeheduleID.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT, "0"));
        }
        
        protected void btn_View_Click(object sender, EventArgs e)
        {
            ExamResults_Multi.SetActiveView(view_Grid);
            Bind_ExamResult_List();
        }
        protected void Bind_ExamResult_List()
        {
            ExamResult ExResult = new ExamResult();
            ExResult.StudentCode= txt_StudentID.Text;
            ExResult.ExamID = drpdwn_ExamResultSeheduleID.SelectedValue==""?0:int.Parse(drpdwn_ExamResultSeheduleID.SelectedValue);
            gridview_ExamResultList.DataSource = ExamResultManagement.GetInstance.GetExamResultList(ExResult); //PageVariables.SehedulesList;
            gridview_ExamResultList.DataBind();
            ResetSet();
            //ExamResults_Multi.SetActiveView(view_Grid);
        }
        void ResetSet()
        {
            val_StudentCode.Text = string.Empty;
            value_ExamName.Text = string.Empty;
            value_ExamName.Text = drpdwn_ExamResultSeheduleID.SelectedIndex == 0 ? "" : drpdwn_ExamResultSeheduleID.SelectedItem.Text;            
            if (txt_StudentID.Text != string.Empty)
            {
                Student Stobj = new Student();
                val_StudentCode.Text = txt_StudentID.Text;
                Stobj = (from xyzl in StudentManagement.GetInstance.GetStudentList()
                         where xyzl.StudentCode ==(txt_StudentID.Text)
                         select xyzl).Single();
                val_StudentName.Text = Stobj.StudentName;
            }
        }
        protected void Bind_AllExamResult_List()
        {
            ExamResult ExResult = new ExamResult();
            ExResult.StudentCode = txt_StudentID.Text;
            ExResult.ExamID = drpdwn_ExamResultSeheduleID.SelectedValue == "" ? 0 : int.Parse(drpdwn_ExamResultSeheduleID.SelectedValue);
            gridview_ViewExamResult.DataSource = ExamResultManagement.GetInstance.GetExamResultList(ExResult); //PageVariables.SehedulesList;
            gridview_ViewExamResult.DataBind();
            ExamResults_Multi.SetActiveView(view_Grid);
        }
        protected void btn_reset_Click(object sender, EventArgs e)
        {
           
        }
        
        protected void btn_AddNew_Click(object sender, EventArgs e)
        {
           
            ExamResults_Multi.SetActiveView(InputControls);
        }        
        
        private static int DeleteRecord()
        {
            return 0;
        }                
        protected void gridview_ExamResultList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }

        protected void gridview_ExamResultList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    BasePage.GridViewOnClientMouseOver(e);
                    BasePage.GridViewOnClientMouseOut(e);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void gridview_ExamResultList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gridview_ExamResultList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }

        protected void drpdwn_ExamResultSeheduleID_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void gridview_ExamResultList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           
        }

        protected void btn_go_Click(object sender, EventArgs e)
        {
            Bind_ExamResult_List();
        }

        
    }
}