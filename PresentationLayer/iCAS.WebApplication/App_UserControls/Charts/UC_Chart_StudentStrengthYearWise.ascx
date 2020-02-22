<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Chart_StudentStrengthYearWise.ascx.cs" Inherits="TCon.iCAS.WebApplication.App_UserControls.Charts.UC_Chart_StudentStrengthYearWise" %>
<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script type="text/javascript" src="https://www.google.com/jsapi"></script>

<script type="text/javascript">
	// Global variable to hold data  
	// Load the Visualization API and the piechart package.  

	//google.load('visualization', '1', { packages: ['corechart'] });

 

	google.load('visualization', '1', { packages: ['corechart', 'bar'] });
</script>
<script type="text/javascript">

	$(document).ready(function ()
	{
		//var apiUrl = '<%=ConfigurationManager.AppSettings["WebServerIP"].ToString() %>';
		//var apiUrl = "http://tsdcollege.in/api/chart?chart_name='student'";
		//var apiUrl = "http://localhost/iCAS.WebApp/api/chart?chart_name='student'";
		var apiUrl = "http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/api/chart?chart_name='student'";

		//alert(apiUrl);
		$("#LoadingDiv").css("display", "block");
		//debugger
		$.ajax({
			type: "GET",
			url: apiUrl,
			data: "{}",
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			success: function (result)
			{
				drawGoogleChart_MultiColumn(result);
			},
			error: function ()
			{
				alert("Error loading data! Please try again.");
			}
		});
		//alert('end');
		$("#LoadingDiv").css("display", "none");

		function LoadGoogle()
		{
			google.load('visualization', '1', { packages: ['corechart'] });

			if (typeof google != 'undefined' && google && google.load)
			{
				// Now you can use google.load() here...
			}
			else
			{
				// Retry later...
				setTimeout(LoadGoogle, 30);
			}
		}

		function drawChart(dataValues)
		{
			//var jsonData = $.ajax({
			//	url: "",
			//	dataType: "json",
			//	async: false
			//}).responseText;

			// Create our data table out of JSON data loaded from server.
			var data = new google.visualization.DataTable(jsonData);

			// Instantiate and draw our chart, passing in some options.
			var chart = new google.visualization.PieChart(document.getElementById('chart_div'));
			chart.draw(data, { width: 400, height: 240 });
		}
	});

	function drawGoogleChart(dataValues)
	{
		var data = new google.visualization.DataTable();

		data.addColumn('string', 'Year');
		data.addColumn('number', 'Total Students');

		for (var i = 0; i < dataValues.length; i++)
		{
			data.addRow([dataValues[i].ACC_YEAR_CODE, dataValues[i].total]);
		}


		var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));

		chart.draw(data,
		{
			title: "STUDENT STENGTH OF THE COLLEGE",
			position: "top",
			fontsize: "14px",
			chartArea: { width: '50%', height: '50%' },
		});
	}

	function drawGoogleChart_MultiColumn(dataValues)
	{
		debugger

		var data = new google.visualization.DataTable();

		data.addColumn('string', 'YEAR');
		data.addColumn('number', 'ARTS');
		data.addColumn('number', 'SCIENCE');

		for (var i = 0; i < dataValues.length; i++)
		{
			data.addRow([dataValues[i].ACC_YEAR_CODE, dataValues[i].ARTS, dataValues[i].SCIENCE]);
		}

		var options = {
			width: 800,
			height: 400,
			colors: ['#033769', 'deepskyblue'],
			chart: {
				title: 'Student Strength (Yearwise)',
				subtitle: 'Arts & Science students : 2014-2017',
			}
		};


		var chart = new google.charts.Bar(document.getElementById('chart_div'));
		chart.draw(data, options);

	}
</script>
<div id="LoadingDiv">
	<h3>Loading Chart....</h3>
	<img src="../../Images/lightbox-ico-loading.gif" />
</div>
<div id="chart_div"></div>
