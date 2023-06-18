﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.BusinessLayer.ICAS.ESTBLMT;
using Micro.Objects.ICAS.ESTBLMT;
using System.IO;


namespace Micro.WebApplication.APPS.ICAS.ESTBLMT
{
    public partial class Default : BasePage
    {

        public static string typeCodesToShow = String.Concat(
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

            public static List<Establishment> EstablishmentList
            {
                get
                {
                    List<Establishment> TheEstablishmentList = HttpContext.Current.Session["TheEstablishmentList"] as List<Establishment>;
                    return TheEstablishmentList;
                }
                set
                {
                    HttpContext.Current.Session.Add("TheEstablishmentList", value);
                }
            }




            //public static FileUpload TheFileupload
            //{
            //    get
            //    {
            //        FileUpload TheFileupload = HttpContext.Current.Session["TheFileupload"] as FileUpload;
            //        return TheFileupload;
            //    }
            //    set
            //    {
            //        HttpContext.Current.Session.Add("TheFileupload", value);
            //    }
            //}


        }
        #endregion

        #region  events

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack && !IsCallback)
            {
                Session["fileName"] = "NA";
                if (Request.QueryString["type"] == null)
                {
                    lit_PageTitle.Text = "MANAGE ESTABLISHMENTS";
                    BindEstbTypeDropdown();
                }
                else if (Request.QueryString["type"] == "publication")
                {
                    lit_PageTitle.Text = "MANAGE PUBLICATIONS";
                    typeCodesToShow = typeCodesToShowForPublication;
                    BindEstbTypeDropdownForPublication();
                }
                //BindEstbTypeDropdown();
                Establishment_multi.SetActiveView(InputControls);

            }
            

        }

        private void BindEstbTypeDropdown()
        {
            ddlEstbType.Items.Clear();
            ddlEstbType.Items.Add(new ListItem("-- SELECT --", ""));
            ddlEstbType.Items.Add(new ListItem("RECENT ACTIVITY", EstbTypeConstants.RECENT_ACTIVITY));
            ddlEstbType.Items.Add(new ListItem("NOTICE", EstbTypeConstants.NOTICE));
            ddlEstbType.Items.Add(new ListItem("TENDER", EstbTypeConstants.TENDER));
            ddlEstbType.Items.Add(new ListItem("CIRCULAR", EstbTypeConstants.CIRCULAR));
            ddlEstbType.Items.Add(new ListItem("SYLLABUS", EstbTypeConstants.SYLLABUS));
            ddlEstbType.Items.Add(new ListItem("NAAC", EstbTypeConstants.NAAC));
            ddlEstbType.Items.Add(new ListItem("AQAR", EstbTypeConstants.AQAR));
            ddlEstbType.Items.Add(new ListItem("IQAC", EstbTypeConstants.IQAC));
            ddlEstbType.Items.Add(new ListItem("MINUTES OF MEETING", EstbTypeConstants.MoM));
            ddlEstbType.Items.Add(new ListItem("PHOTO GALLERY", EstbTypeConstants.PHOTO));
            ddlEstbType.Items.Add(new ListItem("DOWNLOAD", EstbTypeConstants.DOWNLOAD));
            ddlEstbType.Items.Add(new ListItem("WORLD BANK", EstbTypeConstants.WORLDBANK));


            ddlEstbTypeView.Items.Clear();
            ddlEstbTypeView.Items.Add(new ListItem("-- VIEW ALL --", ""));
            ddlEstbTypeView.Items.Add(new ListItem("RECENT ACTIVITY", EstbTypeConstants.RECENT_ACTIVITY));
            ddlEstbTypeView.Items.Add(new ListItem("NOTICE", EstbTypeConstants.NOTICE));
            ddlEstbTypeView.Items.Add(new ListItem("TENDER", EstbTypeConstants.TENDER));
            ddlEstbTypeView.Items.Add(new ListItem("CIRCULAR", EstbTypeConstants.CIRCULAR));
            ddlEstbTypeView.Items.Add(new ListItem("SYLLABUS", EstbTypeConstants.SYLLABUS));
            ddlEstbTypeView.Items.Add(new ListItem("NAAC", EstbTypeConstants.NAAC));
            ddlEstbTypeView.Items.Add(new ListItem("AQAR", EstbTypeConstants.AQAR));
            ddlEstbTypeView.Items.Add(new ListItem("IQAC", EstbTypeConstants.IQAC));
            ddlEstbTypeView.Items.Add(new ListItem("MINUTES OF MEETING", EstbTypeConstants.MoM));
            ddlEstbTypeView.Items.Add(new ListItem("PHOTO GALLERY", EstbTypeConstants.PHOTO));
            ddlEstbTypeView.Items.Add(new ListItem("DOWNLOAD", EstbTypeConstants.DOWNLOAD));
            ddlEstbTypeView.Items.Add(new ListItem("WORLD BANK", EstbTypeConstants.WORLDBANK));
        }

        private void BindEstbTypeDropdownForPublication()
        {
            ddlEstbType.Items.Clear();
            ddlEstbType.Items.Add(new ListItem("-- VIEW ALL --", ""));
            ddlEstbType.Items.Add(new ListItem("BOOK", EstbTypeConstants.BOOK));
            ddlEstbType.Items.Add(new ListItem("ARTCLE", EstbTypeConstants.ARTCLE));
            ddlEstbType.Items.Add(new ListItem("PROJECT PAPER", EstbTypeConstants.PROJECT_PAPER));
            ddlEstbType.Items.Add(new ListItem("SEMINAR PAPER", EstbTypeConstants.SEMINAR_PAPER));
            ddlEstbType.Items.Add(new ListItem("STUDY MATERIAL", EstbTypeConstants.STUDY_MATERIAL));
            ddlEstbType.Items.Add(new ListItem("LITERATURE", EstbTypeConstants.LITERATURE));
            ddlEstbType.Items.Add(new ListItem("STAFF PROFILE", EstbTypeConstants.STAFF_PROFILE));
            ddlEstbType.SelectedIndex = (int)(MicroEnums.EstablishmentType.All);


            ddlEstbTypeView.Items.Clear();
            ddlEstbTypeView.Items.Add(new ListItem("-- VIEW ALL --", ""));
            ddlEstbTypeView.Items.Add(new ListItem("BOOK", EstbTypeConstants.BOOK));
            ddlEstbTypeView.Items.Add(new ListItem("ARTCLE", EstbTypeConstants.ARTCLE));
            ddlEstbTypeView.Items.Add(new ListItem("PROJECT PAPER", EstbTypeConstants.PROJECT_PAPER));
            ddlEstbTypeView.Items.Add(new ListItem("SEMINAR PAPER", EstbTypeConstants.SEMINAR_PAPER));
            ddlEstbTypeView.Items.Add(new ListItem("STUDY MATERIAL", EstbTypeConstants.STUDY_MATERIAL));
            ddlEstbTypeView.Items.Add(new ListItem("LITERATURE", EstbTypeConstants.LITERATURE));
            ddlEstbTypeView.Items.Add(new ListItem("STAFF PROFILE", EstbTypeConstants.STAFF_PROFILE));
            ddlEstbTypeView.SelectedIndex = (int)(MicroEnums.EstablishmentType.All);

        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            PageVariables.EstablishmentList = null;
            Establishment_multi.SetActiveView(view_gridView);
            BindGridview();
        }

        protected void gridview_Establishment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex = 0;
            if (!e.CommandName.Equals(MicroEnums.DataOperation.Page.GetStringValue()))
            {

                RowIndex = Convert.ToInt32(e.CommandArgument);
                int RecodrId = int.Parse(((Label)gridview_Establishment.Rows[RowIndex].FindControl("lbl_EstbID")).Text);

                //BindGridview();
                PageVariables.theestablishment = null;
                PageVariables.theestablishment = (from establishment in PageVariables.EstablishmentList
                                                  where establishment.EstbID == RecodrId
                                                  select establishment).Single();
                if (e.CommandName.Equals(MicroEnums.DataOperation.Select.GetStringValue()))
                {
                    lbl_TheMessage.Text = PageVariables.theestablishment.EstbTitle;
                    string theNavigateUrl = Path.Combine(Server.MapPath("~/Documents"), PageVariables.theestablishment.FileNameWithPath); //string.Format("{0}/Documents/{1}", Server.MapPath("."), PageVariables.theestablishment.FileNameWithPath);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('" + theNavigateUrl + "');", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "window.open('../../../Documents/" + PageVariables.theestablishment.FileNameWithPath + "');", true);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "window.open('" + theNavigateUrl + "','PoP_Up','width=500,height=500,menubar=yes,toolbar=yes,resizable=yes,fullscreen=1');", true);
                    //dialog_Message.CssClass = "modalPopupCssClass";
                    //dialog_Message.Show();
                }
                else if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
                {
                    // EDIT COMMAND CLICKED
                    PopulateFormField(PageVariables.theestablishment);
                    Establishment_multi.SetActiveView(InputControls);
                    btnSubmit.Text = MicroEnums.DataOperation.Update.GetStringValue();
                }
                else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
                {
                    // DELETE COMMAND CLICKED
                    int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

                    ProcReturnValue = DeleteEstablishment();

                    if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                    {
                        BindGridview();
                    }
                }

            }

        }

        protected void gridview_Establishment_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gridview_Establishment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            e.Cancel = true;
        }

        protected void btn_AddNew_Click(object sender, EventArgs e)
        {
            Reset();
            PageVariables.theestablishment = null;
            btnSubmit.Text = MicroEnums.DataOperation.Save.GetStringValue();
            Establishment_multi.SetActiveView(InputControls);
        }

        #endregion

        #region Methods

        public void BindGridview()
        {
            string typeCodes = typeCodesToShow;
            if (ddlEstbTypeView.SelectedValue != "")
            {
                typeCodes = ddlEstbTypeView.SelectedValue;
            }
            PageVariables.EstablishmentList = EstablishmentManagement.GetInstance.GetEstablishmentListByTypeCodes(typeCodes);
            gridview_Establishment.DataSource = PageVariables.EstablishmentList;
            gridview_Establishment.DataBind();
        }



        private int InsertEstablishment()
        {

            int ReturnValue = 0;


            //string theNewFileName = UploadFileGetNewFileName();

            Establishment objEstablishment = new Establishment();
            objEstablishment.EstbTypeCode = ddlEstbType.SelectedValue; // rbl_EstablishmentTypeCode.SelectedValue;
            objEstablishment.EstbTitle = txt_NoticeTitle.Text;
            objEstablishment.EstbViewStartDate = DateTime.Parse(txt_Startdate.Text);
            objEstablishment.EstbViewEndDate = DateTime.Parse(txt_Startdate.Text).AddYears(99);
            objEstablishment.EstbDescription = txt_Description.Text;
            objEstablishment.EstbDescription1 = txt_Description1.Text;
            objEstablishment.EstbDescription2 = txt_Description2.Text;

            if (Session["fileName"].ToString() != "NA")
            {
                objEstablishment.FileNameWithPath = Session["fileName"].ToString();
            }

            ReturnValue = EstablishmentManagement.GetInstance.InsertEstablishment(objEstablishment);

            return ReturnValue;

        }

        private int UpdateEstablishment()
        {

            //string theNewFileName = UploadFileGetNewFileName();

            int ProReturnValue = 0;
            PageVariables.theestablishment.EstbTypeCode = ddlEstbType.SelectedValue; // rbl_EstablishmentTypeCode.SelectedValue;
            PageVariables.theestablishment.EstbTitle = txt_NoticeTitle.Text;
            PageVariables.theestablishment.EstbViewStartDate = DateTime.Parse(txt_Startdate.Text);
            PageVariables.theestablishment.EstbViewEndDate = DateTime.Parse(txt_Startdate.Text).AddYears(99);
            PageVariables.theestablishment.EstbDescription = txt_Description.Text.Replace("\n", "<br/>");
            PageVariables.theestablishment.EstbDescription1 = txt_Description1.Text.Replace("\n", "<br/>");
            PageVariables.theestablishment.EstbDescription2 = txt_Description2.Text.Replace("\n", "<br/>");
            //PageVariables.theestablishment.EstbMessage = txt_Description.Text.Replace("\n", "<br/>");
            if (Session["fileName"].ToString() != "NA")
            {
                PageVariables.theestablishment.FileNameWithPath = Session["fileName"].ToString();
            }

            ProReturnValue = EstablishmentManagement.GetInstance.UpdateEstablishment(PageVariables.theestablishment);

            return ProReturnValue;
        }

        private int DeleteEstablishment()
        {
            int ProReturnvalue = EstablishmentManagement.GetInstance.DeleteEstablishment(PageVariables.theestablishment);
            return ProReturnvalue;
        }

        public void PopulateFormField(Establishment theestablishment)
        {
            ddlEstbType.SelectedValue = theestablishment.EstbTypeCode;
            //rbl_EstablishmentTypeCode.SelectedValue = theestablishment.EstbTypeCode;
            txt_NoticeTitle.Text = theestablishment.EstbTitle;
            txt_Startdate.Text = theestablishment.EstbViewStartDate.ToString();
            //txt_Enddate.Text = theestablishment.EstbViewEndDate.ToString();
            txt_Description.Text = theestablishment.EstbDescription.Replace("<br/>","\n");
            txt_Description1.Text = theestablishment.EstbDescription1.Replace("<br/>","\n");
            txt_Description2.Text = theestablishment.EstbDescription1.Replace("<br/>","\n");

        }

        public void Reset()
        {
            //rbl_EstablishmentTypeCode.ClearSelection();
            txt_NoticeTitle.Text = string.Empty;
            txt_Startdate.Text = string.Empty;
            //txt_Enddate.Text = string.Empty;
            txt_Description.Text = string.Empty;
            txt_Description1.Text = string.Empty;
            txt_Description2.Text = string.Empty;
            lbl_FileUploadStatus.Text = string.Empty;

        }

        private string UploadFileGetNewFileName()
        {
            try
            {
                string theNewFileName = string.Empty;
                string fileNameWithPath = string.Empty;
                if (fileUploadEstb.HasFile)
                {
                    string[] validFileTypes = { "pdf", "docx", "doc" };
                    if (ddlEstbType.SelectedValue.Equals(EstbTypeConstants.PHOTO))
                    {
                        List<string> list = new List<string>();
                        list.Add("jpg");
                        list.Add("jpeg");
                        list.Add("png");
                        list.Add("gif");
                        validFileTypes = list.ToArray();
                    } 
                    
                    string ext = System.IO.Path.GetExtension(fileUploadEstb.PostedFile.FileName).ToLower();
                    bool isValidFile = false;
                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (ext == "." + validFileTypes[i])
                        {
                            isValidFile = true;
                            break;
                        }
                    }
                    if (!isValidFile)
                    {
                        lbl_FileUploadStatus.Text = "Invalid! please upload a file with extension " + string.Join(",", validFileTypes);
                        return "NA";
                    }
                    else
                    {


                        //create the path to save the file to
                        theNewFileName = string.Format("ESTB_{0}_Y{1}_M{2}_D{3}-H{4}_M{5}_S{6}{7}",
                                            ddlEstbType.SelectedValue,
                                            DateTime.Now.Year.ToString(),
                                            DateTime.Now.Month.ToString(),
                                            DateTime.Now.Day.ToString(),
                                            DateTime.Now.Hour.ToString(),
                                            DateTime.Now.Minute.ToString(),
                                            DateTime.Now.Second.ToString(),
                                            ext
                                            );

                        fileNameWithPath = Path.Combine(Server.MapPath("~/Documents"), theNewFileName);
                        //save the file to our local path
                        fileUploadEstb.SaveAs(fileNameWithPath);
                        fileUploadEstb = null;
                    }
                }
                else
                {
                    lbl_FileUploadStatus.Text = "File couldn't be uploaded! it seems some problem is there";
                    return "NA";
                }
                return theNewFileName;

            }
            catch (Exception ex)
            {
                lbl_FileUploadStatus.Text = ex.Message;
                return "NA";
            }
        }


        #endregion



        

         

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
            {
                ProcReturnValue = InsertEstablishment();
                if (ProcReturnValue > 0)
                {
                    lbl_TheMessage.Text = "Record Inserted Successfully!";
                    Reset();
                }
                else
                {
                    lbl_TheMessage.Text = "Failed to insert the record!";
                }
            }
            else
            {
                ProcReturnValue = UpdateEstablishment();
                if (ProcReturnValue > 0)
                {
                    lbl_TheMessage.Text = "Record Updated Successfully!";
                    btnSubmit.Text = MicroEnums.DataOperation.Save.GetStringValue();
                }
                else
                {
                    lbl_TheMessage.Text = "Failed to Updated the record!";
                }
                 
                //btnSubmit.Text = MicroEnums.DataOperation.Save.GetStringValue();
            }

            if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
            {
                Reset();
            }
            //else if (ProcReturnValue < 0)
            //{
            //    lbl_TheMessage.Text = string.Format("{0} operation failed", btnSubmit.Text);
            //}


            if (!string.IsNullOrEmpty(lbl_TheMessage.Text))
            {
                dialog_Message.Show();
            }
        }

        protected void Async_Upload_File(object sender, EventArgs e)
        {
            bool HasFile = fileUploadEstb.HasFile;
        }
        protected void Upload_File(object sender, EventArgs e)
        {
           
            try
            {
                bool HasFile = fileUploadEstb.HasFile;
                lbl_FileUploadStatus.Visible = false;
                
                if (HasFile)
                {
                    Session["fileName"] = UploadFileGetNewFileName();
                    lbl_FileUploadStatus.Visible = true;
                    if (!(Session["fileName"].ToString().Equals("NA")))
                    {
                        lbl_FileUploadStatus.Text = string.Format("Uploaded the file as {0}", Session["fileName"].ToString());
                        lbl_FileUploadStatus.ForeColor = System.Drawing.Color.White;
                        lbl_FileUploadStatus.BackColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lbl_FileUploadStatus.ForeColor = System.Drawing.Color.White;
                        lbl_FileUploadStatus.BackColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                Session["fileName"] = "NA";
                lbl_FileUploadStatus.Visible = true;
                lbl_FileUploadStatus.ForeColor = System.Drawing.Color.DarkRed;
                dialog_Message.Show();
            }
        }

        protected void rbl_EstablishmentTypeCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_NoticeTitle.Text = string.Format("Please enter the title for ", ddlEstbType.Text);
        }

        protected void gridview_Establishment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lit_CurrentPage.Text = string.Format("<span class='CurrentPage'>Page# {0}/{1}", (e.NewPageIndex +1).ToString(), gridview_Establishment.PageCount.ToString());
            gridview_Establishment.PageIndex = e.NewPageIndex;

            BindGridview();
            
        }

        protected void btnViewEstbType_Click(object sender, EventArgs e)
        {
            BindGridview();
        }

        protected void gridview_Establishment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (Button button in e.Row.Cells[8].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete?')){ return false; };";
                    }
                }

                string item = e.Row.Cells[5].Text;
                if (item.ToUpper().Trim() == "APPROVED")
                {
                    e.Row.Cells[5].BackColor = System.Drawing.Color.LightGreen;
                }
                else
                {
                    e.Row.Cells[5].BackColor = System.Drawing.Color.LightYellow;
                }

            }
        }
    }
}