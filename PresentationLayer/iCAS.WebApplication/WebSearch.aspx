<%@ Page Title="" Language="C#"
     MasterPageFile="~/App_MasterPages/ICAS.Master" 
    AutoEventWireup="true" 
    CodeBehind="WebSearch.aspx.cs" 
    Inherits="LTPL.ICAS.WebApplication.WebSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<style type="text/css">
		.gsc-control
		{
			margin: 5% 2%;
			width: 96%;
			background-color: #FFFFFF;
			padding: 20px;
		}
		
		
		
		.gsc-results-wrapper-nooverlay gsc-results-wrapper-visible
		{
			margin: 5% 2%;
			width: 96%;
			background-color: #0000CD;
			border: solid 1px #000033;
		}
		#content
		{
			margin-top: 0px;
			width: 100%;
			background-color: #F5F5F5;
			border-bottom: double 3px #000033;
		}
	</style>

	<script src="http://www.google.com/jsapi?key=AIzaSyA5m1Nc8ws2BbmPRwKu5gFradvD_hgq6G0" type="text/javascript"></script>

	<script type="text/javascript">
		/*
		*  The Hello World of the AJAX Search API
		*/

		google.load('search', '1');

		function OnLoad() {
			// Create a search control
			var searchControl = new google.search.SearchControl();

			// Add in a full set of searchers
			//var localSearch = new google.search.LocalSearch();
			//searchControl.addSearcher(localSearch);
			searchControl.addSearcher(new google.search.WebSearch());
			//searchControl.addSearcher(new google.search.VideoSearch());
			//searchControl.addSearcher(new google.search.BlogSearch());
			searchControl.addSearcher(new google.search.NewsSearch());
			//searchControl.addSearcher(new google.search.ImageSearch());
			//searchControl.addSearcher(new google.search.BookSearch());
			//searchControl.addSearcher(new google.search.PatentSearch());

			// Set the Local Search center point
			//localSearch.setCenterPoint("New Delhi, IN");

			// tell the searcher to draw itself and tell it where to attach
			searchControl.draw(document.getElementById("content"));

			// execute an inital search
			searchControl.execute("TSD College");
		}

		google.setOnLoadCallback(OnLoad);
    
	</script>

	<div id="content">
		Loading content from Google...</div>
</asp:Content>
