using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.BusinessLayer.ICAS.ESTBLMT;
using Micro.Objects.ICAS.ESTBLMT;
using Micro.Commons;
using System.Text;
using System.Configuration;

namespace LTPL.ICAS.WebApplication.App_UserControls.ICAS
{
	public partial class UC_EstablishmentZone : System.Web.UI.UserControl
	{

		#region Declaration
		public static class PageVariables
		{

			public static Establishment TheEstablishment
			{
				get
				{
					Establishment TheEstablishment = HttpContext.Current.Session["theestablishment"] as Establishment;
					return TheEstablishment;
				}
				set
				{
					HttpContext.Current.Session.Add("TheEstablishment", value);
				}
			}

			public static List<Establishment> TheEstablishmentList
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

		}
		#endregion

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				radioList_Estb.SelectedIndex = (int)(MicroEnums.EstablishmentType.All);
				BindGridview(radioList_Estb.SelectedValue);
			}
		}

		public void BindGridview(string estbTypeCode)
		{
			if (estbTypeCode.Equals("A")) // View All Records
			{
				PageVariables.TheEstablishmentList = EstablishmentManagement.GetInstance.GetEstablishmentListByTypeCodes("N,T,C,R,S"); //.Find(a=> a.EstbViewEndDate < DateTime.Today).ToList();
				List<Establishment> theTotalist = (from abc in PageVariables.TheEstablishmentList
												   where (abc.EstbStatusFlag.Equals("A") && (abc.EstbViewStartDate <= DateTime.Today && abc.EstbViewEndDate >= DateTime.Today))
												   select abc).OrderByDescending(y => y.EstbID).ToList();

				gridViewEstb.DataSource = theTotalist;
				gridViewEstb.DataBind();
				return;
			}
			if (PageVariables.TheEstablishmentList == null)
			{
				PageVariables.TheEstablishmentList = EstablishmentManagement.GetInstance.GetEstablishmentListByTypeCodes("N,T,C,R,S"); //.Find(a=> a.EstbViewEndDate < DateTime.Today).ToList();
			}

			List<Establishment> TheFilterList = new List<Establishment>();
			TheFilterList = (from xyz in PageVariables.TheEstablishmentList
							 where ((xyz.EstbStatusFlag.Equals("A"))
									&& (xyz.EstbViewStartDate <= DateTime.Today && xyz.EstbViewEndDate >= DateTime.Today)
									&& (xyz.EstbTypeCode.Equals(estbTypeCode))
									)
							 select xyz).OrderByDescending(x => x.EstbID).ToList();

			gridViewEstb.DataSource = TheFilterList;
			gridViewEstb.DataBind();
		}

		protected void radioList_Estb_SelectedIndexChanged(object sender, EventArgs e)
		{
			string typeCode = radioList_Estb.SelectedValue;
			if (typeCode == "0")
			{
				Response.Redirect("~/Publications.aspx");
			}
			else
			{
				BindGridview(typeCode);
			}

		}

		protected void gridViewEstb_RowCommand(object sender, GridViewCommandEventArgs e)
		{			
			if (e.CommandName == "ViewEstablishment")
			{
				string theTitle = string.Empty;
				string theDialogTitle = string.Empty;
				int index = Convert.ToInt32(e.CommandArgument);
				GridViewRow row = gridViewEstb.Rows[index];
				Literal ltrlID = (Literal)gridViewEstb.Rows[index].FindControl("lit_EstbID");
				List<Establishment> TheFilterList = new List<Establishment>();
				if (PageVariables.TheEstablishmentList == null)
				{
					PageVariables.TheEstablishmentList = EstablishmentManagement.GetInstance.GetEstablishmentList();
				}

				var TheFilterList1 = (from xyz in PageVariables.TheEstablishmentList
									  where xyz.EstbID == int.Parse(ltrlID.Text.ToString())
									  select xyz).ToList();

				StringBuilder sbHtml = new StringBuilder("<ul id='DialogEstablishmentUL>");
				string theProdUrl = ConfigurationManager.AppSettings["WebServerIP"].ToString();

				foreach (Establishment theRecord in TheFilterList1)
				{
					string strType = string.Format("<li class='estb-type'>{0}<br/>{1}</li>", theRecord.EstbTypeCodeDesc, theRecord.EstbViewStartDate.ToLongDateString());
					string strTitle = string.Format("<li class='estb-title'>{0}</li>", theRecord.EstbTitle);
					string strMessage = string.Format("<li class='estb-desc'>{0}</li>", theRecord.EstbDescription);
					sbHtml.AppendLine("<li>&nbsp;<hr/></li>");
					string strFile = string.Empty;
					if ((theRecord.FileNameWithPath.Equals(DBNull.Value)))
					{
						strFile = string.Format("<li class='estb-attachment'>No documents uloaded for this notice</li>");
					}
					else
					{
						if (!(theRecord.FileNameWithPath.Equals("NA")) && !(theRecord.FileNameWithPath.Equals(string.Empty)))
						{
							strFile = string.Format("<span class='attachmentLink'>" +
														"<a class='btn btn-primary' " +
														"href='{0}/Documents/{1}' target='_blank'>Display the Attached Document</a></span>", theProdUrl, theRecord.FileNameWithPath);
						}
					}
					sbHtml.AppendLine(strType);
					sbHtml.AppendLine(strTitle);
					sbHtml.AppendLine(strMessage);
					sbHtml.AppendLine(strFile);
				}
				sbHtml.AppendLine("<li>&nbsp;<hr/></li>");
				sbHtml.AppendLine("</ul>");


				lit_DialogMessageDetails.Text = sbHtml.ToString();
				dialog_Message.Show();
				//ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('" + theTitle + "');", true);
			}
		}		

		protected void gridViewEstb_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			gridViewEstb.PageIndex = e.NewPageIndex;
			BindGridview(radioList_Estb.SelectedValue);
		}
	}
}