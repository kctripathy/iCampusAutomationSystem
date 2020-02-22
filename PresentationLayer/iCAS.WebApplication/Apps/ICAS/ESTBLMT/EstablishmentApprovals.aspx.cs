using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.Objects.ICAS.ESTBLMT;
using Micro.BusinessLayer.ICAS.ESTBLMT;
using System.Drawing;

namespace LTPL.ICAS.WebApplication.APPS.ICAS.ESTBLMT
{
    public partial class EstablishmentApprovals : BasePage
    {

        #region Declaration
        protected static class PageVariables
        {

            public static Establishment theEstablishmentObject
            {
                get
                {
                    Establishment TheEstablishment = HttpContext.Current.Session["theestablishment"] as Establishment;
                    return TheEstablishment;
                }
                set
                {
                    HttpContext.Current.Session.Add("theestablishment", value);
                }
            }

            public static List<Establishment> EstablishmentList
            {
                get
                {
                    List<Establishment> TheEstablishmentList = HttpContext.Current.Session["EstablishmentrList"] as List<Establishment>;
                    return TheEstablishmentList;
                }
                set
                {
                    HttpContext.Current.Session.Add("EstablishmentrList", value);
                }
            }

        }
        #endregion


        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btn_Approve.Text = string.Format(" Apply \"{0}\" Status To Checked Establishments", ddl_EstablishmentStatus.SelectedItem.Text);
                rbl_EstablishmentTypeCode.SelectedIndex = (int)(MicroEnums.EstablishmentType.All);
                BindGridview();
            }
        }

        protected void rbl_EstablishmentTypeCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridview();
        }

        protected void btn_Approve_Click(object sender, EventArgs e)
        {
            int Ctr = 0;
            string EstbStatus = ddl_EstablishmentStatus.Text.ToString().Substring(0, 1);
            for (int i = 0; i < gview_EstablishmentApprovals.Rows.Count; i++)
            {
                GridViewRow row = gview_EstablishmentApprovals.Rows[i];
                CheckBox chkb = (CheckBox)row.FindControl("chk_EstablishmentID");
                if (chkb.Checked)
                {
                    Label lblEstbID = (Label)row.FindControl("lbl_EstablishmentID");
                    int EstbId = int.Parse(lblEstbID.Text);
                    //int estbId = (int)lblEstbID.Text.ToString();
                    int x = EstablishmentManagement.GetInstance.UpdateEstablishmentStatus(EstbId, EstbStatus);
                    Ctr++;
                    row.BackColor = Color.LightGreen;
                }
            }
            lbl_TheMessage.Text = string.Format(" <b>{0}</b> items {1} Sucessfully.",Ctr,ddl_EstablishmentStatus.SelectedItem.Text);
            BindGridview();
        }
        #endregion


        #region Methods & Implementation
        public void BindGridview()
        {
            string x=rbl_EstablishmentTypeCode.Text;
            PageVariables.EstablishmentList = EstablishmentManagement.GetInstance.GetEstablishmentListFreshRecords();

            List<Establishment> filterlist = new List<Establishment>();

            if (rbl_EstablishmentTypeCode.SelectedValue.Equals("T"))
            {
                filterlist = (from xyz in PageVariables.EstablishmentList
                              where xyz.EstbTypeCode.Equals("T") 
                              select xyz).ToList();
            }
            if (rbl_EstablishmentTypeCode.SelectedValue.Equals("C"))
            {
                filterlist = (from xyz in PageVariables.EstablishmentList
                              where xyz.EstbTypeCode.Equals("C") 
                              select xyz).ToList();
            }
            if (rbl_EstablishmentTypeCode.SelectedValue.Equals("N"))
            {
                filterlist = (from xyz in PageVariables.EstablishmentList
                              where xyz.EstbTypeCode.Equals("N") 
                              select xyz).ToList();
            }
            if (rbl_EstablishmentTypeCode.SelectedValue.Equals("P"))
            {
                List<Establishment> ListPublication = new List<Establishment>();
                ListPublication = EstablishmentManagement.GetInstance.GetEstablishmentListByTypeCodes("1,2,3,4,5,6,7,8,9");
                filterlist = (from xyz in PageVariables.EstablishmentList
                              where xyz.EstbTypeCode.Equals("N") 
                              select xyz).ToList();
            }
            //All
            if (rbl_EstablishmentTypeCode.SelectedValue.Equals("A"))
            {
                filterlist = (from xyz in PageVariables.EstablishmentList
                              select xyz).ToList();
            }
            //else
            //{
            //    filterlist = (from xyz in PageVariables.EstablishmentList
            //                  where xyz.EstbTypeCode.Equals(rbl_EstablishmentTypeCode.SelectedValue) //&& xyz.EstbStatusFlag.Equals("P")
            //                  select xyz).ToList();
            //}

            gview_EstablishmentApprovals.DataSource = filterlist; // PageVariables.EstablishmentrList; // filterlist;
            gview_EstablishmentApprovals.DataBind();
        }

        protected void ddl_EstablishmentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Approve.Text = string.Format(" Apply \"{0}\" Status To Checked Establishments", ddl_EstablishmentStatus.SelectedItem.Text);
            if (ddl_EstablishmentStatus.SelectedItem.Value.ToString().Equals("A"))
            {
                btn_Approve.CssClass = "btn btn-sucesss btn_Approve";
            }
            else
            {
                btn_Approve.CssClass = "btn btn-primary btn_Approve";
            }
        }

        //public int ChangeEstablishmentStatus()
        //{
        //    int ReturnValue = 0;
        //    try
        //    {
        //        string EstbIds = GetCheckedItemsValue(gview_EstablishmentApprovals);
        //        string status= ddl_EstablishmentStatus.SelectedValue;
                 
        //        //ReturnValue = EstablishmentManagement.GetInstance.UpdateEstablishment(EstbIds, status);
                      
        //    }
        //    catch
        //    {
        //    }
        //    return ReturnValue;
		
        
        //}
       

        //public static string GetCheckedItemsValue(GridView parentControl)
        //{

        //    string CheckedItemsValue = string.Empty;

        //    int Counter = 0;
        //    for (int i = 0; i < parentControl.Rows.Count; i++)
        //    {

        //        GridViewRow row = parentControl.Rows[i];
        //        CheckBox chkb = (CheckBox)row.FindControl("chk_EstablishmentID");
        //        if (chkb.Checked)
        //        {
        //            Label lblEstbId = (Label)row.FindControl("lbl_EstablishmentID");
        //            string status ;
        //            int ReturnValue = EstablishmentManagement.GetInstance.UpdateEstablishment(lblEstbId.Text, );

        //            //if (Counter.Equals(0))
        //            //{
        //            //    CheckedItemsValue = parentControl.Rows[i].Cells[1].Text;

        //            //    CheckedItemsValue = string.Format("{0}, {1}", CheckedItemsValue, parentControl.Rows[i].Cells[1].Text);
        //            //}
        //            //else
        //            //{
        //            //    CheckedItemsValue = string.Format("{0}, {1}", CheckedItemsValue, parentControl.Rows[i].Cells[1].Text);
        //            //}
        //            // string name = gview_OldDisplay.Rows[i].Cells[2].Text;
        //            Counter = Counter + 1;
        //        }
        //    }

        //    return CheckedItemsValue;

        //}

        #endregion
    }
}

