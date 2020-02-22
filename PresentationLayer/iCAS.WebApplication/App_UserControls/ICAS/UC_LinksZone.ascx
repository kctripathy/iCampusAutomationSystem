<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_LinksZone.ascx.cs" Inherits="LTPL.ICAS.WebApplication.App_UserControls.ICAS.UC_LinksZone" %>
<style type="text/css">
	#LibraryZone
	{
		display: block;
		float: left;
		width: 100%;
		margin: 5px 0px 0px 0px;
		padding: 0;
		/*background-image: linear-gradient(#54b4eb, #2fa4e7 60%, #1d9ce5);*/
		background-image: linear-gradient(#04519b, #044687 60%, #033769);
		background-repeat: no-repeat;
	}

	.eLibraryBox1
	{
		width: 100%;
		padding: 0px;
		margin: 0px;
	}

	.AdminBox1
	{
		width: 100%;
		padding: 0px;
		margin: 0px;
	}

	.AlumniBox1
	{
		width: 100%;
		padding: 0px;
		margin: 0px;
	}

	#LibraryZone > div
	{
		display: block;
		float: left;
		width: 100%;
	}


		#LibraryZone > div > a
		{
			/*transition: all 0.7s ease;
		text-decoration: none;
		font-size: 1em;
		font-weight: normal;
		color: white;
		display: block;
		float: left;
		width: 50%;
		text-align: center;
		margin: 2px 0px;
		padding: 4px 0px;*/
			display: block;
			float: left;
			width: 50%;
			padding: 1%;
			color: white;
			font-size: 1em;
			background-image: linear-gradient(#04519b, #044687 0%, #033769);
			background-repeat: no-repeat;
			text-align: center;
		}

			#LibraryZone > div > a:hover
			{
				display: block;
				float: left;
				width: 50%;
				padding: 1%;
				color: floralwhite;
				font-weight: bold;
				font-size: 1em;
				text-align: center;
				background-image: linear-gradient(#04519b, #044687 10%, #033769);
				background-repeat: no-repeat;
			}

	@media only screen and (max-device-width: 480px)
	{

		#LibraryZone
		{
			display: block;
			float: left;
			width: 99%;
			margin: 0;
			padding: 0;
		}



			#LibraryZone > div > a
			{
				transition: all 0.7s ease;
				text-decoration: none;
				font-size: 1em;
				/*text-shadow: 1px 2px 1px #1e1ee4;*/
				font-weight: normal;
				color: white;
				display: block;
				float: left;
				width: 100%;
				text-align: center;
				margin: 4px 0px;
				padding: 8px 0px;
				border-bottom: solid 1px white;
			}

				#LibraryZone > div > a:hover
				{
					transition: all 0.7s ease;
					text-decoration: none;
					font-size: 1em;
					/*text-shadow: 1px 2px 1px #1e1ee4;*/
					font-weight: bold;
					background-color: whitesmoke;
					color: navy;
					display: block;
					float: left;
					width: 100%;
					text-align: center;
					margin: 4px 0px;
					padding: 8px 0px;
					border: solid 1px white;
				}
	}
</style>
<div id="LibraryZone" class="row">
	<div>
		<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/Publications.aspx" class="eLibraryBox1">Research & Publications </a>
		<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/Library/Books.aspx">College Library</a>
		<a href="hhttp://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/StaffResearchPublications.aspx" class="eLibraryBox1">Books/Study Materials</a>
		<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/photo-gallery" class="eLibraryBox1">Photo Gallery</a>
		<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/apps/icas/estblmt/default.aspx" class="AdminBox1">Recent Activities</a>
		<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/AdminAuditActivities.aspx" class="AdminBox2">Audit Activities</a>
		<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/MinutesOfMeeting.aspx" class="AdminBox1">MinutesOfMeetings</a>
		<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/AdminWorldBank.aspx" class="AdminBox1">World Bank Assisted OHEPEE Project</a>
		<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/Alumni.aspx" class="AlumniBox1">Online Alumni Registration</a>
		<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/Downloads.aspx" class="AlumniBox1">Download Registration Form</a>
		<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/Students.aspx" class="AlumniBox1">Alumni/ex-Students List</a>
		<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/Alumni.aspx" class="AlumniBox1">Search an Alumni</a>
	</div>
</div>
