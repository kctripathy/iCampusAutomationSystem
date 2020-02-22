<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl_Chart_StudentStrength.ascx.cs" Inherits="TCon.iCAS.WebApplication.App_UserControls.Charts.WebUserControl_Chart_StudentStrength" %>
 

<script type="text/javascript">
	google.charts.load('current', { 'packages': ['bar'] });
	google.charts.setOnLoadCallback(drawChart);


	//google.charts.load('current', { packages: ['corechart', 'bar'] });
	//google.charts.setOnLoadCallback(drawTrendlines);


	function drawChart()
	{
		var data = google.visualization.arrayToDataTable([
		  ['Year', 'Arts', 'Science'],
		  ['2016-17', 1138, 765],
		  ['2015-16', 1012, 460],
		  ['2014-15', 996, 400],
		  ['2013-14', 930, 540]
		]);


	  //  var data = google.visualization.arrayToDataTable([
	  //  ['Element', 'Density', { role: 'style' }],
	  //  ['Copper', 8.94, '#b87333'],            // RGB value
	  //  ['Silver', 10.49, 'silver'],            // English color name
	  //  ['Gold', 19.30, 'gold'],

	  //['Platinum', 21.45, 'color: #e5e4e2'], // CSS-style declaration
	  //  ]);


		var options = {
			colors: ['#033769', 'green'],
			chart: {
				title: 'Student Strength (Yearwise)',
				subtitle: 'Arts & Science students : 2014-2017',
			}
		};

		var chart = new google.charts.Bar(document.getElementById('columnchart_material'));

		chart.draw(data, options);
	}

	function drawChart_StudentStrength()
	{
		var data = google.visualization.arrayToDataTable([
		  ['Year', 'Visitations', { role: 'style' }],
		  ['2010', 10, 'color: gray'],
		  ['2020', 14, 'color: #76A7FA'],
		  ['2030', 16, 'opacity: 0.2'],
		  ['2040', 22, 'stroke-color: #703593; stroke-width: 4; fill-color: #C5A5CF'],
		  ['2050', 28, 'stroke-color: #871B47; stroke-opacity: 0.6; stroke-width: 8; fill-color: #BC5679; fill-opacity: 0.2']
		]);

		var options = {
			chart: {
				title: 'Student Strength (Yearwise)',
				subtitle: 'Arts & Science students : 2014-2017',
			}
		};

		var chart = new google.charts.Bar(document.getElementById('columnchart_material'));

		chart.draw(data, options);
	}


	function drawTrendlines()
	{
		var data = new google.visualization.DataTable();
		data.addColumn('timeofday', 'Time of Day');
		data.addColumn('number', 'Motivation Level');
		data.addColumn('number', 'Energy Level');

		data.addRows([
		  [{ v: [8, 0, 0], f: '8 am' }, 1, .25],
		  [{ v: [9, 0, 0], f: '9 am' }, 2, .5],
		  [{ v: [10, 0, 0], f: '10 am' }, 3, 1],
		  [{ v: [11, 0, 0], f: '11 am' }, 4, 2.25],
		  [{ v: [12, 0, 0], f: '12 pm' }, 5, 2.25],
		  [{ v: [13, 0, 0], f: '1 pm' }, 6, 3],
		  [{ v: [14, 0, 0], f: '2 pm' }, 7, 4],
		  [{ v: [15, 0, 0], f: '3 pm' }, 8, 5.25],
		  [{ v: [16, 0, 0], f: '4 pm' }, 9, 7.5],
		  [{ v: [17, 0, 0], f: '5 pm' }, 10, 10],
		]);

		var options = {
			title: 'Motivation and Energy Level Throughout the Day',
			trendlines: {
				0: { type: 'linear', lineWidth: 5, opacity: .3 },
				1: { type: 'exponential', lineWidth: 10, opacity: .3 }
			},
			hAxis: {
				title: 'Time of Day',
				format: 'h:mm a',
				viewWindow: {
					min: [7, 30, 0],
					max: [17, 30, 0]
				}
			},
			vAxis: {
				title: 'Rating (scale of 1-10)'
			}
		};

		var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));
		chart.draw(data, options);
	}
</script>
 
<div id="columnchart_material" style="width: 850px; height: 500px;"></div>
