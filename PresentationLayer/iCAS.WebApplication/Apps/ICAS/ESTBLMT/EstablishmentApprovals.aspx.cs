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

        public string typeCodesToShow = String.Concat(
                        EstbTypeConstants.RECENT_ACTIVITY,
                        ",", EstbTypeConstants.NOTICE,
                        ",", EstbTypeConstants.TENDER,
                        ",", EstbTypeConstants.CIRCULAR,
                        ",", EstbTypeConstants.SYLLABUS,
                        ",", EstbTypeConstants.NAAC,
                        ",", EstbTypeConstants.AQAR,
                        ",", EstbTypeConstants.IQAC,
                        ",", EstbTypeConstants.DOWNLOAD,
                        ",", EstbTypeConstants.MoM,
                        ",", EstbTypeConstants.PHOTO,
                        ",", EstbTypeConstants.WORLDBANK
                );

        public string typeCodesToShowForPublication = String.Concat(
                       EstbTypeConstants.ARTCLE,
                       ",", EstbTypeConstants.PROJECT_PAPER,
                       ",", EstbTypeConstants.SEMINAR_PAPER,
                       ",", EstbTypeConstants.BOOK,
                       ",", EstbTypeConstants.LITERATURE,
                       ",", EstbTypeConstants.STAFF_PROFILE,
                       ",", EstbTypeConstants.STUDY_MATERIAL
               );
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
                if (Request.QueryString["type"] == null)
                {
                    lit_pageTitle.Text = "MANAGE ESTABLISHMENT APPROVALS";
                    BindEstbTypeDropdown();
                }
                else if (Request.QueryString["type"] == "publication")
                {
                    lit_pageTitle.Text = "MANAGE PUBLICATION APPROVALS";
                    typeCodesToShow = typeCodesToShowForPublication;
                    BindEstbTypeDropdownForPublication();
                }
                BindGridview();
            }
        }

        private void BindEstbTypeDropdown()
        {
            ddl_EstablishmentTypeCode.Items.Clear();
            ddl_EstablishmentTypeCode.Items.Add(new ListItem("-- VIEW ALL --", ""));
            ddl_EstablishmentTypeCode.Items.Add(new ListItem("RECENT ACTIVITY", EstbTypeConstants.RECENT_ACTIVITY));
            ddl_EstablishmentTypeCode.Items.Add(new ListItem("NOTICE", EstbTypeConstants.NOTICE));
            ddl_EstablishmentTypeCode.Items.Add(new ListItem("TENDER", EstbTypeConstants.TENDER));
            ddl_EstablishmentTypeCode.Items.Add(new ListItem("CIRCULAR", EstbTypeConstants.CIRCULAR));
            ddl_EstablishmentTypeCode.Items.Add(new ListItem("SYLLABUS", EstbTypeConstants.SYLLABUS));
            ddl_EstablishmentTypeCode.Items.Add(new ListItem("NAAC", EstbTypeConstants.NAAC));
            ddl_EstablishmentTypeCode.Items.Add(new ListItem("AQAR", EstbTypeConstants.AQAR));
            ddl_EstablishmentTypeCode.Items.Add(new ListItem("IQAC", EstbTypeConstants.IQAC));
            ddl_EstablishmentTypeCode.Items.Add(new ListItem("WORLDBANK", EstbTypeConstants.WORLDBANK));
            ddl_EstablishmentTypeCode.Items.Add(new ListItem("MINUTES OF MEETING", EstbTypeConstants.MoM));
            ddl_EstablishmentTypeCode.Items.Add(new ListItem("PHOTO GALLERY", EstbTypeConstants.PHOTO));
            ddl_EstablishmentTypeCode.Items.Add(new ListItem("DOWNLOAD", EstbTypeConstants.DOWNLOAD));
            ddl_EstablishmentTypeCode.SelectedIndex = (int)(MicroEnums.EstablishmentType.All);

        }

        private void BindEstbTypeDropdownForPublication()
        {
            ddl_EstablishmentTypeCode.Items.Clear();
            ddl_EstablishmentTypeCode.Items.Add(new ListItem("-- VIEW ALL --", ""));
            ddl_EstablishmentTypeCode.Items.Add(new ListItem("BOOK", EstbTypeConstants.BOOK));
            ddl_EstablishmentTypeCode.Items.Add(new ListItem("ARTCLE", EstbTypeConstants.ARTCLE));
            ddl_EstablishmentTypeCode.Items.Add(new ListItem("PROJECT PAPER", EstbTypeConstants.PROJECT_PAPER));
            ddl_EstablishmentTypeCode.Items.Add(new ListItem("SEMINAR PAPER", EstbTypeConstants.SEMINAR_PAPER));
            ddl_EstablishmentTypeCode.Items.Add(new ListItem("STUDY MATERIAL", EstbTypeConstants.STUDY_MATERIAL));
            ddl_EstablishmentTypeCode.Items.Add(new ListItem("LITERATURE", EstbTypeConstants.LITERATURE));
            ddl_EstablishmentTypeCode.Items.Add(new ListItem("STAFF PROFILE", EstbTypeConstants.STAFF_PROFILE));
            ddl_EstablishmentTypeCode.SelectedIndex = (int)(MicroEnums.EstablishmentType.All);

        }


        protected void btn_Approve_Click(object sender, EventArgs e)
        {
            int Ctr = 0;
            string EstbStatus = ((Button)sender).CommandArgument; // rbl_EstablishmentStatus.Text.ToString().Substring(0, 1);
            for (int i = 0; i < gview_EstablishmentApprovals.Rows.Count; i++)
            {
                GridViewRow row = gview_EstablishmentApprovals.Rows[i];
                CheckBox chkb = (CheckBox)row.FindControl("chk_EstablishmentID");
                if (chkb.Checked)
                {
                    Label lblEstbID = (Label)row.FindControl("lbl_EstablishmentID");
                    int EstbId = int.Parse(lblEstbID.Text);
                    int x = EstablishmentManagement.GetInstance.UpdateEstablishmentStatus(EstbId, EstbStatus);
                    Ctr++;
                    row.BackColor = Color.LightGreen;
                }
            }
            if (Ctr == 0)
            {
                lit_Message.Text = "<div class='apply-message'>Please select at least one record to apply any action.</div>";
            }
            else
            {
                lit_Message.Text = string.Format("<div class='apply-message'>{0} item{1} {2} sucessfully.</div>",
                                                        Ctr,
                                                        Ctr > 1 ? "s" : "",
                                                        EstbStatus == "A" ? "approved" : "made pending");
                BindGridview();
            }
            
        }
        #endregion


        #region Methods & Implementation
        public void BindGridview()
        {

            string typeCodes = typeCodesToShow;
            if (ddl_EstablishmentTypeCode.SelectedValue != "")
            {
                typeCodes = ddl_EstablishmentTypeCode.SelectedValue;
            }

            PageVariables.EstablishmentList = EstablishmentManagement.GetInstance.GetEstablishmentListByTypeCodes(typeCodes);
            List<Establishment> filterlist = new List<Establishment>();
            if (!chk_ShowApproved.Checked)
            {
                filterlist = (from records in PageVariables.EstablishmentList
                              where records.EstbStatusFlag.Equals("P")
                              select records).ToList();
            }
            else
            {
                filterlist = PageVariables.EstablishmentList;
            }
            gview_EstablishmentApprovals.DataSource = filterlist.OrderByDescending((record)=> record.EstbID);
            gview_EstablishmentApprovals.DataBind();

            //string x=rbl_EstablishmentTypeCode.Text;
            //PageVariables.EstablishmentList = EstablishmentManagement.GetInstance.GetEstablishmentListFreshRecords();

            //List<Establishment> filterlist = new List<Establishment>();

            //if (rbl_EstablishmentTypeCode.SelectedValue.Equals("T"))
            //{
            //    filterlist = (from xyz in PageVariables.EstablishmentList
            //                  where xyz.EstbTypeCode.Equals("T") 
            //                  select xyz).ToList();
            //}
            //if (rbl_EstablishmentTypeCode.SelectedValue.Equals("C"))
            //{
            //    filterlist = (from xyz in PageVariables.EstablishmentList
            //                  where xyz.EstbTypeCode.Equals("C") 
            //                  select xyz).ToList();
            //}
            //if (rbl_EstablishmentTypeCode.SelectedValue.Equals("N"))
            //{
            //    filterlist = (from xyz in PageVariables.EstablishmentList
            //                  where xyz.EstbTypeCode.Equals("N") 
            //                  select xyz).ToList();
            //}
            //if (rbl_EstablishmentTypeCode.SelectedValue.Equals("Z"))
            //{
            //    filterlist = (from xyz in PageVariables.EstablishmentList
            //                  where xyz.EstbTypeCode.Equals("Z")
            //                  select xyz).ToList();
            //}
            //if (rbl_EstablishmentTypeCode.SelectedValue.Equals("P"))
            //{
            //    List<Establishment> ListPublication = new List<Establishment>();
            //    ListPublication = EstablishmentManagement.GetInstance.GetEstablishmentListByTypeCodes("1,2,3,4,5,6,7,8,9");
            //    filterlist = (from xyz in PageVariables.EstablishmentList
            //                  where xyz.EstbTypeCode.Equals("N") 
            //                  select xyz).ToList();
            //}
            ////All
            //if (rbl_EstablishmentTypeCode.SelectedValue.Equals("A"))
            //{
            //    filterlist = (from xyz in PageVariables.EstablishmentList
            //                  select xyz).ToList();
            //}
            ////else
            ////{
            ////    filterlist = (from xyz in PageVariables.EstablishmentList
            ////                  where xyz.EstbTypeCode.Equals(rbl_EstablishmentTypeCode.SelectedValue) //&& xyz.EstbStatusFlag.Equals("P")
            ////                  select xyz).ToList();
            ////}

            //gview_EstablishmentApprovals.DataSource = filterlist.OrderByDescending(s => s.EstbID); // PageVariables.EstablishmentrList; // filterlist;
            //gview_EstablishmentApprovals.DataBind();
        }

        protected void btn_View_Click(object sender, EventArgs e)
        {
            BindGridview();
        }



        #endregion

        protected void chk_ShowApproved_CheckedChanged(object sender, EventArgs e)
        {
            BindGridview();
        }
    }
}

