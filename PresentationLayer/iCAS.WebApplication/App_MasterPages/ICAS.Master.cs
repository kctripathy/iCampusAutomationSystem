using System;
using System.Configuration;
using System.Web.UI;
using Micro.Commons;

namespace Micro.WebApplication.App_MasterPages
{
	public partial class ICAS : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{

            if (ConfigurationManager.AppSettings["UnavailableDateTime"] != null && ConfigurationManager.AppSettings["UnavailableDateTimeDisplay"] == "YES")
            {
                Response.Redirect("~/App_Error/Maintenance.aspx");
            }
			string html_code;
			string photoUrl;
			string pageUrl = ConfigurationManager.AppSettings["WebServerIP"].ToString();

			if (Connection.LoggedOnUser == null)
			{
				photoUrl = string.Format("<img class='img-responsive img-user-login-photo' src='http://" + pageUrl + @"/Images/User/default-user.png' alt='Guest'></img>");
			}
			else
			{
				photoUrl = string.Format("<img class='img-responsive img-user-login-photo' src='http://" + pageUrl + @"/Images/User/default-user.png' alt='{0}'></img>", (Connection.LoggedOnUser.UserReferenceName == null ? "Guest" : Connection.LoggedOnUser.UserReferenceName));
			}


			if (Connection.LoggedOnUser != null)
			{
				if (Connection.LoggedOnUser.ImageUrl_Smallest != null && Connection.LoggedOnUser.ImageUrl_Smallest.Length > 0)
				{
					photoUrl = Connection.LoggedOnUser.ImageUrl_Smallest;
					photoUrl = string.Format("<img class='img-responsive img-user-login-photo' src='http://" + pageUrl + @"/Images/User/{0}.png' alt='Guest'></img>", photoUrl);
			
				}
				else if (Connection.LoggedOnUser.UserPhoto_SmallSize != null && Connection.LoggedOnUser.UserPhoto_SmallSize.Length>0)
				{
					 
					photoUrl = Connection.LoggedOnUser.UserPhoto_SmallSize;
					photoUrl = string.Format("<img class='img-responsive img-user-login-photo' src='http://" + pageUrl + @"/Images/User/{0}.png' alt='Guest'></img>", photoUrl);
			
			
				}
				else if (Connection.LoggedOnUser.UserPhoto_MediumSize != null && Connection.LoggedOnUser.UserPhoto_MediumSize.Length > 0)
				{
					photoUrl = Connection.LoggedOnUser.UserPhoto_MediumSize;
					photoUrl = string.Format("<img class='img-responsive img-user-login-photo' src='http://" + pageUrl + @"/Images/User/{0}.png' alt='Guest'></img>", photoUrl);
			
			
				}
				else
				{
					photoUrl = string.Format("<img class='img-responsive img-user-login-photo' src='http://" + pageUrl + @"/Images/User/default-user.png' alt='Guest'></img>");
			
				}
				html_code = string.Format(@"
					<div class='login-welcome'>
							<div class='login-photo'>{2}</div>
							<div class='login-text'> 
								<div class='dropdown login-area'>
								  <button class='btn btn-primary login-btn dropdown-toggle' type='button' data-toggle='dropdown'> Welcome {0} 
								  <span class='caret'></span></button>
								  <ul class='dropdown-menu'>								
									<li><a href='feedback'>Submit Feedback</a></li>
									<li><a href='logout'>Logout</a></li>
								  </ul>
								</div>
						</div>
					</div>", Connection.LoggedOnUser.UserReferenceName, Connection.LoggedOnUser.UserName, photoUrl);

			}
			else
			{
				html_code = string.Format(@"
					<div class='login-welcome'>
							<div class='login-photo'>{0}</div>
							<div class='login-text'> 
								<div class='dropdown login-area'>
								  <button class='btn btn-primary login-btn dropdown-toggle' type='button' data-toggle='dropdown'> Welcome User
								  <span class='caret'></span></button>
								  <ul class='dropdown-menu'>
										<li><a href='login'>Login</a></li>
										<li><a href='register'>Register</a></li>
								  </ul>
								</div>
						</div>
					</div>", photoUrl);
			}

			lit_Welcome.Text = html_code;
		}
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			Page.Header.DataBind();
		}
	}
}