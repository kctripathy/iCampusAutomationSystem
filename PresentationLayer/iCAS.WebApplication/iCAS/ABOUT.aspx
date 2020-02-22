<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/ICAS.Master" AutoEventWireup="true" CodeBehind="ABOUT.aspx.cs" Inherits="LTPL.ICAS.WebApplication.iCAS.ABOUT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<style type="text/css">
		/*#TheContainerICAS #WebContentICAS #WebBodyICAS
        {
            height: 355px;
        }*/

		.InnerContentImage
		{
			border: solid 1px red;
			width: 350px;
			height: 260px;
			margin: 15px 0px 0px 25px;
			border: 4px solid #eaeaea;
			box-shadow: 1px 1px 5px rgba(0,0,0,0.7);
		}

		.PageContentDept
		{
			display: block;
			float: left;
			width: 50%;
			margin: 0;
			padding: 0;
		}

		#PageContentDept1 > p > a,
		#PageContentDept1 > div > p > a,
		#PageContentDept1 > a,
		#contentPanel > p > a,
		#contentPanel2 > p > a
		{
			color: red;
			font-size: 0.9em;
			text-decoration: underline;
			padding: 0px 5px;
		}

			#PageContentDept1 > p > a:hover,
			#PageContentDept1 > a:hover,
			#PageContentDept1 > div > p > a:hover,
			#contentPanel > p > a:hover,
			#contentPanel2 > p > a:hover
			{
				color: red;
				font-size: 0.9em;
				text-decoration: none;
			}


		#PageContentDept1
		{
			width: 60%;
			min-height: 260px;
		}

		#PageContentDept2
		{
			width: 40%;
		}

		.inner-content-page-image-dept,
		.inner-content-page-image-hod
		{
			border: solid 1px #fff;
			text-align: center;
		}

		.inner-content-page-image-hod
		{
			border: solid 2px #ccc;
			display: block;
			float: left;
			position: absolute;
		}

		p
		{
			margin: 0px 7px 5px 10px;
			padding: 2px;
			text-align: justify;
			font-size: 1.4em;
		}

		.intro
		{
			text-align: justify;
		}

		.PageTitleDepartments
		{
			color: #000;
			padding-top: 6px;
			padding-left: 6px;
			min-height: 25px;
			width: 100%;
			font-family: Lato, sans-serif;
			font-size: 11pt;
			background: linear-gradient(lightcyan 31%, #b5c2ca 88%, lightcyan);
			text-transform: capitalize;
			font: 600 17px/22px Lato, sans-serif;
		}

		.PageBullets
		{
			list-style-type: circle;
			margin: 0;
			padding: 0;
			width: 95%;
			margin-left: 2%;
			margin-top: 1%;
		}

			.PageBullets > li
			{
				font-family: Lato,sans-serif;
				font-size: 1.5em;
			}

		.PageContent p::first-letter
		{
			text-align: justify;
			padding: 0px;
			margin: 0px;
			font-size: 1.1em;
			font-family: Lato,Verdana, Helvetica, Sans-Serif;
			line-height: inherit;
			color: navy;
			font-size: 150%;
			font-weight: 800;
		}

		#ExamOL
		{
			list-style-type: circle;
			display: block;
			float: left;
			margin: 0;
			padding: 0;
			width: 100%;
		}

			#ExamOL > li
			{
				display: block;
				float: left;
				margin: 0;
				padding: 0;
				width: 100%;
				text-align: left;
				margin: 5px 0px;
				padding: 10px;
			}

		.innercontent > h1
		{
			font-size: 1.5em;
			font-weight: 800;
			width: 100%;
			text-align: center;
		}

		.innercontent > h2
		{
			font-size: 1.3em;
			font-weight: 600;
			text-align: center;
			color: darkblue;
		}

		.innercontent > h3
		{
			font-size: 1.2em;
			font-weight: bolder;
			text-align: center;
			width: 100%;
			text-decoration: double;
		}

		/*#about-content, #dept-staffs
		{
			width: 100%;
			height: 400px;
			display: block;
			float: left;
			border: solid 1px #ccc;
			overflow: auto;
		}*/

		#about-content
		{
			width: 100%;
			height: auto;
			display: block;
			float: left;
			overflow: auto;
			margin: 0px;
			padding: 0px;
		}

		ul#dept-staffs
		{
			width: 100%;
			height: auto;
			display: block;
			float: left;
			overflow: hidden;
			margin: 0px;
			padding: 0px;
			list-style-type: none;
		}


			ul#dept-staffs > li
			{
				display: block;
				float: left;
				width: 20%;
				border-bottom: solid 1px #ccc;
				height: 100px;
				margin: 0;
				padding: 15px;
				text-align: left;
				word-wrap: normal;
				overflow-wrap: normal;
			}

				ul#dept-staffs > li.PageSubTitle
				{
					display: block;
					float: left;
					width: 100%;
					background-image: none;
					border-bottom: solid 1px cyan;
				}

				ul#dept-staffs > li.emp-photo
				{
					width: 12%;
				}

				ul#dept-staffs > li.emp-name
				{
					width: 27%;
				}

				ul#dept-staffs > li.emp-photo > a > img
				{
					border: solid 1px #ccc1c1;
					height: 71px;
					width: 100px;
				}
	</style>
	<div id="about-content">
		<asp:Literal runat="server" ID="lit_About" Text="." />

	</div>
</asp:Content>
