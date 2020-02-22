using System;
using System.Data;
using Micro.BusinessLayer;
using Micro.Commons;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;

namespace Micro.WebApplication.App_UserControls.MLFL
{
	public partial class UC_Chart_Finance : System.Web.UI.UserControl
	{
		public int TheOfficeId
		{
			get;
			set;
		}

		public int Height
		{
			get;
			set;
		}

		public int Width
		{
			get;
			set;
		}


		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				PopulateChartData();
			}
		}

		public void PopulateChartData()
		{
			int TheId = this.TheOfficeId;
			DataTable dt = ChartManagement.GetReceiptPaymentReport(TheId);
			//foreach (DataRow drow in dt.Rows)
			//{
			//    Random rnd = new Random();
			//    int randomNumber1 = rnd.Next(1, 50); // creates a number between 1 and 12
			//    drow["Receipt"] = int.Parse(drow["Receipt"].ToString()) + randomNumber1;

			//    int randomNumber2 = rnd.Next(1, 20); // creates a number between 1 and 20				
			//    drow["Payment"] = int.Parse(drow["Payment"].ToString()) + randomNumber2;
			//}
			try
			{
				chart_ReceiptPayment.Width = this.Width;
				chart_ReceiptPayment.Height = this.Height;

				chart_ReceiptPayment.DataSource = dt;
				chart_ReceiptPayment.DataBind();

				// if all values labels are not displaying, set the interval for AxisX or AxisY
				chart_ReceiptPayment.ChartAreas[0].AxisX.Interval = -1;
				chart_ReceiptPayment.ChartAreas[0].AxisX.TextOrientation = TextOrientation.Rotated90;

				// to change the Label font style set the font
				chart_ReceiptPayment.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Verdana", 9f);
				chart_ReceiptPayment.ChartAreas[0].AxisX.LabelStyle.ForeColor = GetChartLabelColor();
				chart_ReceiptPayment.ChartAreas[0].AxisY.LabelStyle.ForeColor = GetChartLabelColor();

				// Changing the backgroud color of the charting area
				chart_ReceiptPayment.ChartAreas[0].BackColor = GetChartBackColor();

				// Changing the backgroud image
				//chart_ReceiptPayment.ChartAreas[0].BackImage = "~/Themes/Common/Images/ChartBackground_MLFL.png";
				//chart_ReceiptPayment.ChartAreas[0].BackGradientStyle = GradientStyle.TopBottom;
				//chart_ReceiptPayment.ChartAreas[0].BackImageAlignment = ChartImageAlignmentStyle.TopRight;

				chart_ReceiptPayment.Series[0].BackSecondaryColor = GetChartBackColor();
				chart_ReceiptPayment.Series[1].BackSecondaryColor = GetChartBackColor();
				//chart_ReceiptPayment.Series[0].BorderColor = GetChartLabelColor();

				//chart_ReceiptPayment.ChartAreas[0].AxisX.TitleForeColor = GetChartLabelColor();
			}
			catch (Exception ex)
			{
				Log.Error(ex);
			}
		}

		private static System.Drawing.Color GetChartBackColor()
		{
			Color TheColor = Color.FromArgb(0xCC, 0xFF, 0xFF);
			string CurrentTheme = Micro.WebApplication.App_UserControls.UC_CustomisedMenu.GetCurrentMenuStyle();

			if (CurrentTheme.Trim().Equals(MicroEnums.UserTheme.Micro_DarkGreen.ToString()))
			{
				TheColor = Color.FromArgb(0xFF, 0xFF, 0xCC);
			}
			return TheColor;
		}

		private static System.Drawing.Color GetChartLabelColor()
		{
			Color TheColor = Color.FromArgb(0x00, 0x00, 0x99);
			if (UC_CustomisedMenu.GetCurrentMenuStyle().Trim().Equals(MicroEnums.UserTheme.Micro_DarkGreen.ToString()))
			{
				TheColor = Color.FromArgb(0x00, 0x66, 0x00);
			}
			return TheColor;
		}
	}
}