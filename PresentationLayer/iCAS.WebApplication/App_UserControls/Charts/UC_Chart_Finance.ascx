<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Chart_Finance.ascx.cs" Inherits="Micro.WebApplication.App_UserControls.MLFL.UC_Chart_Finance" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<div class="ProtectFromCopy"></div>
<asp:Chart ID="chart_ReceiptPayment" runat="server" Width="777px" Height="500px" >
	<Titles>
		<asp:Title Text="TOTAL RECEIPT AND PAYMENT GRAPH FOR YEAR 2012-13" Docking="Top" ForeColor="#003366" TextStyle="Shadow"  />
	</Titles>
	<Legends>
		<asp:Legend Title="" TableStyle="Auto" Alignment="Center" Docking="Bottom" LegendStyle="Row"/>
	</Legends>
	<Series>
		<asp:Series Name="Receipts" ChartType="Column" Color="#21b6a8" BackGradientStyle="DiagonalLeft" XValueMember="Name" YValueMembers="Receipt" IsValueShownAsLabel="true" />
		<asp:Series Name="Payments" ChartType="Column" Color="#FFCbf4" BackGradientStyle="TopBottom" XValueMember="Name" YValueMembers="Payment" IsValueShownAsLabel="true" />
	</Series>
	
	<ChartAreas>
	
		<asp:ChartArea Name="ChartArea_ReceiptPayment" Area3DStyle-Enable3D="false"  IsSameFontSizeForAllAxes="false" BorderColor="#000000" BorderWidth="1" BorderDashStyle="Solid">
			<AxisX>
				
				<MajorGrid LineColor="Silver" />
				<LabelStyle Font="Trebuchet MS, 8pt, style=Bold" />
			</AxisX>
			<AxisY>
				<MajorGrid LineColor="Silver" />	
				<LabelStyle Font="Trebuchet MS, 8pt, style=Bold" />		
			</AxisY>
		</asp:ChartArea>
	</ChartAreas>
</asp:Chart>

