using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web.UI;
using Micro.BusinessLayer.ICAS.STAFFS;
using Micro.Objects.ICAS.STAFFS;

namespace LTPL.ICAS.WebApplication.iCAS
{
	public partial class ABOUT : System.Web.UI.Page
	{

		public static string theFileName;
		public string TheFileName4HTMLString
		{
			get
			{
				//if (theFileName.Contains("department"))
				//{
				//	theFileName = theFileName.Replace("-", "-of-");
				//}
				return theFileName;
			}
			set
			{
				theFileName = value;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				lit_About.Text = ReadFileAndGetHTML();
			}
		}


		private string ReadFileAndGetHTML()
		{
			string htmlCode = string.Empty;
			try
			{
				using (WebClient client = new WebClient())
				{

					string sFileName = Request.QueryString["Page"]; // get it from query string
					try
					{
						if (sFileName == string.Empty || sFileName == null)
						{
							//check if pageurl has come on request.
							sFileName = Page.RouteData.Values["thePage"].ToString();
						}
					}
					catch
					{
						sFileName = (Request.Url.ToString().Split('/')[Request.Url.ToString().Split('/').Length - 1]).ToString();
					}
					this.TheFileName4HTMLString = sFileName;
					string sFileNameWithPath = string.Empty;
					sFileNameWithPath = string.Concat(Server.MapPath("~"), @"\App_Data\ICAS\html\", sFileName, @".htm");


				TryAgain:
					if (System.IO.File.Exists(sFileNameWithPath))
					{
						htmlCode = client.DownloadString(sFileNameWithPath);


						if (sFileName.Contains("department")) //if the page is for a department then show all the employees of that department
						{
							StringBuilder sb = GetDepartmentEmployees(sFileName);
							htmlCode = htmlCode.Replace("#DEPTINFO#", sb.ToString());
						}
						else
						{
							htmlCode = htmlCode.Replace("#DEPTINFO#", "");
						}
					}
					else
					{
						// if that file doesn't exists then create a new one using  default template and show the same
						bool didCreateHtmlFile = CreateOrWriteNewHTMLFile(sFileNameWithPath);
						if (didCreateHtmlFile == true)
						{
							//ReadFileAndGetHTML();
							goto TryAgain;
						}

						////check if the same name with html extension
						//sFileNameWithPath = string.Concat(Server.MapPath("~"), @"\App_Data\ICAS\html\", sFileName, @".html");

						//if (System.IO.File.Exists(sFileNameWithPath)) //----------------------------------------------- search if html file exists
						//{
						//	htmlCode = client.DownloadString(sFileNameWithPath);
						//}
						//else if (System.IO.File.Exists(sFileNameWithPath + @"file-not-found.html")) //----------------- search if html file exists
						//{
						//	//=======================================================================================================================
						//	htmlCode = client.DownloadString(sFileNameWithPath);
						//	//========================================================================================================================
						//}
						//else
						//{
						//	htmlCode = string.Format(@"<h1 class=""PageSubTitle"">Content updation in progress! ...</h1><p   class=""PageSubTitle"">Missing file : {0}</p>", sFileNameWithPath);
						//}
					}
					client.Dispose();
				}

			}
			catch (Exception ex)
			{
				htmlCode = ex.Message.ToString();
			}
			return htmlCode;
		}

		private static StringBuilder GetDepartmentEmployees(string sFileName)
		{
			StringBuilder sb = new StringBuilder("<ul id='dept-staffs'>");
			
			string dept_name = sFileName.Replace("department-", ""); //							"MANAGEMENT";
			sb.AppendLine("<li class='PageSubTitle'>Staffs of the " + dept_name + " department:</li>");
			List<StaffMaster> staffList = StaffMasterManagement.GetInstance.GetEmployeeListByDepartment(dept_name);
			if (staffList.Count > 0)
			{
				//string s = string.Format("<li class='emp-photo'>&nbsp</li><li class='emp-name'><b>{0}</b></li><li class='desig'><b>{1}</b></li><li class='qual'><b>{2}</b></li><li class='mobile'><b>{3}</b></li>"
				//		, "Name"
				//		, "Designation"
				//		, "Qualification"
				//		, "Mobile");
				////string s = string.Format("<li class='emp-name'><b>Name of the Staff</b></li><li class='desig'><b>Designation</b></li><li class='emp-name'><b>Name of the Staff</b></li><li class='desig'><b>Designation</b></li>");
				//sb.AppendLine(s);
				foreach (StaffMaster item in staffList)
				{

					string s1 = string.Format("<li class='emp-photo'><a href='http://{5}/icas/staffs.aspx?id={4}'><img src='../Images/Staffs/{4}.jpg' class='img-responsive img-circle' alt='{0}' />&nbsp;</a></li>" +
												"<li class='emp-name'><a href='http://{5}/icas/staffs.aspx?id={4}'>{0}&nbsp;</a></li>" +
												"<li class='emp-desig'>{1}&nbsp;</li>" +
												"<li class='emp-qual'>{2}&nbsp;</li>" +
												"<li class='emp-mobile'>{3}&nbsp;</li>"
					 	, item.EmployeeName
						, item.DesignationDescription
						, item.LastQualification
						, item.Mobile
						,item.EmployeeID
						, ConfigurationManager.AppSettings["WebServerIP"].ToString());
					sb.AppendLine(s1);
				}
			}
			sb.AppendLine("</ul>");
			return sb;
		}
		private bool CreateOrWriteNewHTMLFile(string strPathName)
		{
			bool bReturn = false;
			StreamWriter sw = null;
			StringBuilder strHtml = new StringBuilder();
			try
			{
				sw = new StreamWriter(strPathName, true);
				sw.WriteLine(GetHTMLString().Trim());
				sw.Flush();
				sw.Close();
				bReturn = true;
			}
			catch (Exception)
			{
				bReturn = false;
			}
			return bReturn;
		}

		private string GetHTMLString()
		{
			string theHTML = string.Format(
							@"
                            <h1 class='PageTitle'>{0}</h1>
                            <div class='innercontent'>
								 
                                <div id='PageContentDept1' class='PageContentDept PageContent'>
                                    <p>
                                        Lorem ipsum dolor sit amet, singulis scriptorem his ei. At antiopam scribentur pro, sea et justo numquam delicata. Ut error saepe nonumes per, corpora luptatum pertinax cu mei. Et est omnes aperiam mentitum, mei magna dicant te, omittam volutpat instructior vis in. Eu quidam ocurreret qui.
                                    </p>        
                                    <p>
                                        Eos ne corrumpit ingulis scriptorem Lorem ipsum dolor sit amet, singulis scriptorem his ei. At antiopam scribentur pro, sea antiopam scribentur antiopam 
										<a href='#l' class='LearnMoreLink' onclick=""javascript:contentPanel.style.display='block';"">Learn more... </a>
                                    </p>        
                                    <div id='contentPanel' style='display:none;'>
                                        <p>
                                            Eos ne corrumpit euripidis. Ut augue liber officiis sed. Ex cum liber sententiae, quando suscipiantur interpretaris nec ea. Mea at lorem iusto option. Ei ius eleifend indoctum consequuntur.
                                            Please <a href='#2' class='LearnMoreLink' onclick=""javascript:contentPanel2.style.display='block';"">Learn more... </a>
                                        </p>
                                    </div>
                                    <div id='contentPanel2' style='display:none;'>
                                        <p>
                                            Eos ne corrumpit euripidis. Ut augue liber officiis sed. Ex cum liber sententiae, quando suscipiantur interpretaris nec ea. Mea at lorem iusto option. Ei ius eleifend indoctum consequuntur.
                                        </p>            
                                    </div>
                                </div>
                                <div id='PageContentDept2' class='PageContentDept'>
                                    <a href='photo-gallery'>
										<img src='Images/About/Departments/{1}.jpg' alt='{0}' class='img-responsive img-circle InnerContentImage'  />
									</a>
                                </div>
								#DEPTINFO#
                            </div>
                            ", this.TheFileName4HTMLString.Replace("-", " of ")
							 , this.TheFileName4HTMLString);
			return theHTML.Trim();
		}


	}
}