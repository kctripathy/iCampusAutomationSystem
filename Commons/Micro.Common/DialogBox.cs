using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using System.Web;
using System.Security.Permissions;
using System.Reflection;
using AjaxControlToolkit;

namespace Micro.Commons
{
	[ToolboxData("<{0}:DialogBox runat=server></{0}:DialogBox>")]
	[ParseChildren(true)]
	[PersistChildren(false)]
	[AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class DialogBox : CompositeControl
	{
		private Control _ContainerControl;
		private ModalPopupExtender _MPE;
		private Button _HiddenButton;

		#region "Properties"

		[Browsable(false),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateInstance(TemplateInstance.Single)]
		public virtual ITemplate ItemTemplate
		{
			get;
			set;
		}

		[Category("Appearance"),
		Description("CssClass for modal background")]
		public string BackgroundCssClass
		{
			get
			{
				if (ViewState["BackgroundCssClass"] == null)
					return "";
				return (string)ViewState["BackgroundCssClass"];
			}
			set
			{
				ViewState["BackgroundCssClass"] = value;
			}
		}

		[Category("Appearance"),
		Description("Target for the modalpopupextender")]
		public string TargetControlID
		{
			get
			{
				if (ViewState["TargetControlID"] == null)
					return "";
				return (string)ViewState["TargetControlID"];
			}
			set
			{
				ViewState["TargetControlID"] = value;
			}
		}

		[Category("Appearance"),
		Description("Target for the modalpopupextender")]
		public string BehaviorID
		{
			get
			{
				if (ViewState["BehaviorID"] == null)
					return "";
				return (string)ViewState["BehaviorID"];
			}
			set
			{
				ViewState["BehaviorID"] = value;
			}
		}

		[Category("Appearance"),
		Description("Target for the modalpopupextender")]
		public string CancelControlID
		{
			get
			{
				if (ViewState["CancelControlID"] == null)
					return "";
				return (string)ViewState["CancelControlID"];
			}
			set
			{
				ViewState["CancelControlID"] = value;
			}
		}

		[Category("Appearance"),
		Description("Title for the dialog box")]
		public string Title
		{
			get
			{
				if (ViewState["Text"] == null)
					return this.ID;
				return (string)ViewState["Text"];
			}
			set
			{
				ViewState["Text"] = value;
			}
		}

		#endregion

		#region Methods
		public DialogBox()
		{

		}

		protected override void OnInit(EventArgs e)
		{
			EnsureChildControls();
			_MPE = new ModalPopupExtender();
			_MPE.PopupControlID = this.ID;
			//			_MPE.PopupDragHandleControlID = this.ID;

			//Defines TargetControlID for the modalpopupExtender
			if (string.IsNullOrEmpty(this.TargetControlID))
			{
				_MPE.TargetControlID = _HiddenButton.ID;
			}
			else
			{
				_MPE.TargetControlID = this.TargetControlID;
			}

			// Defines BehaviorId for use in Javascript
			if (string.IsNullOrEmpty(this.BehaviorID))
			{
				_MPE.BehaviorID = this.ClientID + "_BehaviorID";
			}
			else
			{
				_MPE.BehaviorID = this.BehaviorID;
			}
			CloseButton.OnClientClick = "$find('" + _MPE.BehaviorID + "').hide();return false;";

			_MPE.BackgroundCssClass = this.BackgroundCssClass;
			Controls.Add(_MPE);
			base.OnInit(e);
		}

		/// <summary>
		/// Display the dialog box
		/// </summary>
		public void Show()
		{
			_MPE.Show();
		}

		/// <summary>
		/// Hide the dialog box
		/// </summary>
		public void Hide()
		{
			_MPE.Hide();
		}
		//Add the img for the close button
		ImageButton CloseButton = new ImageButton();

		protected override void CreateChildControls()
		{
			//Set up some default values, if these are not provided to us.
			if (this.ID == null)
			{
				this.ID = "popup";
			}

			// General Table
			HtmlTable GeneralTable = new HtmlTable();
			GeneralTable.CellPadding = 0;
			GeneralTable.CellSpacing = 0;
			GeneralTable.Border = 0;

			//First Row
			HtmlTableRow Row = new HtmlTableRow();

			// Top left corner
			HtmlTableCell Cell = new HtmlTableCell();
			Cell.Attributes["class"] = "modalPopupTopLeft";
			Row.Cells.Add(Cell);

			// Top center cell
			Cell = new HtmlTableCell();
			Cell.Attributes["class"] = "modalPopupTopCenter";
			Row.Cells.Add(Cell);

			// Top right corner
			Cell = new HtmlTableCell();
			Cell.Attributes["class"] = "modalPopupTopRight";
			Row.Cells.Add(Cell);

			GeneralTable.Rows.Add(Row);
			//End first row

			//Second row
			Row = new HtmlTableRow();

			// middle left border
			Cell = new HtmlTableCell();
			Cell.Attributes["class"] = "modalPopupMiddleLeft";
			Row.Cells.Add(Cell);

			// Middle center cell
			Cell = new HtmlTableCell();
			Cell.Attributes["class"] = "modalPopupContent";

			// Add the div for the modalPopupContent
			HtmlGenericControl DivGeneral = new HtmlGenericControl("Div");
			DivGeneral.Attributes["ID"] = "modalPopupGeneral";
			Cell.Controls.Add(DivGeneral);

			//Add the div for the title background
			HtmlGenericControl DivTitleBkg = new HtmlGenericControl("Div");
			DivTitleBkg.Attributes["ID"] = "modalPopupTitleBkg";
			DivGeneral.Controls.Add(DivTitleBkg);

			//Add the div for the title puce
			HtmlGenericControl DivPopupTitlePuce = new HtmlGenericControl("Div");
			DivPopupTitlePuce.Attributes["ID"] = "modalPopupTitlePuce";
			DivTitleBkg.Controls.Add(DivPopupTitlePuce);

			//Add the div for the title
			HtmlGenericControl DivPopupTitle = new HtmlGenericControl("Div");
			DivPopupTitle.Attributes["ID"] = "modalPopupTitle";
			DivTitleBkg.Controls.Add(DivPopupTitle);
			DivPopupTitle.Controls.Add(new LiteralControl(Title));

			//Add the div for the close button
			HtmlGenericControl DivPopupClose = new HtmlGenericControl("Div");
			DivPopupClose.Attributes["ID"] = "modalPopupClose";
			DivTitleBkg.Controls.Add(DivPopupClose);

			CloseButton.ImageUrl = "~/Themes/" + this.Page.Theme + "/Images/ModalPopup/ModalPopup_Close.gif";
			DivPopupClose.Controls.Add(CloseButton);

			//Add the div for the popup content
			HtmlGenericControl DivPopupContent = new HtmlGenericControl("Div");
			DivPopupContent.Attributes["ID"] = "modalPopupInnerContent";

			//This is where the ItemTemplate is created
			_ContainerControl = new Control();
			if (ItemTemplate != null)
			{
				ItemTemplate.InstantiateIn(_ContainerControl);
			}
			else
			{
				_ContainerControl.Controls.Add(new LiteralControl(Title));
			}

			DivPopupContent.Controls.Add(_ContainerControl);
			DivGeneral.Controls.Add(DivPopupContent);
			Row.Cells.Add(Cell);

			//Add the div for the footer
			HtmlGenericControl DivFooter = new HtmlGenericControl("Div");
			DivFooter.Attributes["ID"] = "modalPopupFooter";
			DivFooter.InnerHtml = string.Format("{0} :: {1} | v{2}", DateTime.Now.ToString("dd-MMM-yy"), DateTime.Now.ToShortTimeString(), CallingAssemblyVersion);
			DivGeneral.Controls.Add(DivFooter);

			// Middle right border
			Cell = new HtmlTableCell();
			Cell.Attributes["class"] = "modalPopupMiddleRight";
			Row.Cells.Add(Cell);

			GeneralTable.Rows.Add(Row);
			//End second row

			//Third row
			Row = new HtmlTableRow();

			// Bottom left corner
			Cell = new HtmlTableCell();
			Cell.Attributes["class"] = "modalPopupBottomLeft";
			Row.Cells.Add(Cell);

			// Bottom center cell
			Cell = new HtmlTableCell();
			Cell.Attributes["class"] = "modalPopupBottomCenter";
			Row.Cells.Add(Cell);

			// Bottom right corner
			Cell = new HtmlTableCell();
			Cell.Attributes["class"] = "modalPopupBottomRight";
			Row.Cells.Add(Cell);

			GeneralTable.Rows.Add(Row);
			//End Third row

			Controls.Add(GeneralTable);

			_HiddenButton = new Button();
			_HiddenButton.ID = "HiddenButton";
			_HiddenButton.Style.Add(HtmlTextWriterStyle.Display, "none");
			Controls.Add(_HiddenButton);
		}

		//This method is present just to be able to force correct rendering during design-time
		internal void GetDesignTimeHtml()
		{
			this.EnsureChildControls();
		}

		//This method is overriden to ensure that the outer control is rendered as a 
		//DIV-tag.  It is normally rendered as a SPAN-tag, which would cause incorrect
		//behaviour.
		protected override HtmlTextWriterTag TagKey
		{
			get
			{
				return HtmlTextWriterTag.Div;
			}
		}

		public static string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		public static string CallingAssemblyVersion
		{
			get
			{
				return Assembly.GetCallingAssembly().GetName().Version.ToString();
			}
		}
		#endregion
	}
}
