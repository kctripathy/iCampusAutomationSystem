using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.Objects.ICAS.ESTBLMT;
using Micro.BusinessLayer.ICAS.ESTBLMT;

namespace LTPL.ICAS.WebApplication.APPS.ICAS.ESTBLMT
{
    public partial class AdminApprovals : BasePage
    {

        #region Declaration
        protected static class PageVariables
        {

            public static Establishment theestablishment
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

            public static List<Establishment> EstablishmentrList
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
                }
            }
            lbl_TheMessage.Text = string.Format("{0} items {1} Sucessfully",Ctr,ddl_EstablishmentStatus.SelectedItem.Text);
            BindGridview();
        }
        #endregion


        #region Methods & Implementation
        public void BindGridview()
        {
            string x=rbl_EstablishmentTypeCode.Text;
            PageVariables.EstablishmentrList = EstablishmentManagement.GetInstance.GetEstablishmentList();

            List<Establishment> filterlist = new List<Establishment>();
            
            //if (rbl_EstablishmentTypeCode.SelectedValue.Equals("T"))
            //{
            //    filterlist = (from xyz in PageVariables.EstablishmentrList
            //                  where xyz.EstbTypeCode.Equals("T") //&& xyz.EstbStatusFlag.Equals("P")
            //                  select xyz).ToList();
            //}
            //if (rbl_EstablishmentTypeCode.SelectedValue.Equals("C"))
            //{
            //    filterlist = (from xyz in PageVariables.EstablishmentrList
            //                  where xyz.EstbTypeCode.Equals("C") //&& xyz.EstbStatusFlag.Equals("P")
            //                  select xyz).ToList();
            //}
            //if (rbl_EstablishmentTypeCode.SelectedValue.Equals("N"))
            //{
            //    filterlist = (from xyz in PageVariables.EstablishmentrList
            //                  where xyz.EstbTypeCode.Equals("N") && xyz.EstbStatusFlag.Equals("P")
            //                  select xyz).ToList();
            //}
            if (rbl_EstablishmentTypeCode.SelectedValue.Equals("A"))
            {
                filterlist = (from xyz in PageVariables.EstablishmentrList
                              select xyz).ToList();
            }
            else
            {
                filterlist = (from xyz in PageVariables.EstablishmentrList
                              where xyz.EstbTypeCode.Equals(rbl_EstablishmentTypeCode.SelectedValue) //&& xyz.EstbStatusFlag.Equals("P")
                              select xyz).ToList();
            }

            gview_EstablishmentApprovals.DataSource = filterlist; // PageVariables.EstablishmentrList; // filterlist;
            gview_EstablishmentApprovals.DataBind();
        }

        protected void ddl_EstablishmentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Approve.Text = string.Format(" Apply \"{0}\" Status To Checked Establishments", ddl_EstablishmentStatus.SelectedItem.Text);
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

