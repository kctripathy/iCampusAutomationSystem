<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_StudentZone.ascx.cs" Inherits="LTPL.ICAS.WebApplication.App_UserControls.ICAS.UC_StudentZone" %>

<style type="text/css">
	#StudentZone
	{
		display: block;
		float: left;
	}

		#StudentZone > ul
		{
			display: block;
			float: left;
		}

			#StudentZone > ul > li
			{
				display: block;
				float: left;
				width: 100%;
				margin: 1px;
				padding: 1px;
			}
</style>
<div id="StudentZone" class="col-md-6">
	<ul class="AskLoginStudent">
		<li class="StudentZoneLink">
			<strong>Students Zone:</strong>
			<asp:Panel runat="server" ID="before_login">
				<asp:Literal runat="server" ID="lit_BeforeLogin" />
			</asp:Panel>
			<asp:Panel runat="server" ID="after_login">
				<asp:Literal runat="server" ID="lit_Welcome" Text="" />
				<asp:Literal runat="server" ID="lit_AfterLogin" />
			</asp:Panel>
		</li>
		<li class="StudentZoneLink">
			<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/about-student-union">College Association</a>
		</li>
		<li class="StudentZoneLink">
			<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/about-student-composition">Students Composition</a>
		</li>
		<li class="StudentZoneLink">
			<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/about-prides-of-college">Prides of College</a>
		</li>
		<li class="StudentZoneLink">
			<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/about-student-achievements">Students Achievements</a>
		</li>
		<li class="StudentZoneLink">
			<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/about-best-links">Some Best & Useful Links</a>
		</li>
		<li class="StudentZoneLink">
			<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/apps/icas/admin/studentfeedback.aspx">Submit Your Feedback</a>
		</li>
		<li class="StudentZoneLink">
			<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/about-upload-articles">Upload Your Articles</a>
		</li>
	</ul>
</div>

