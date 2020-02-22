using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Micro.Commons;
using Micro.BusinessLayer.Administration;
using Micro.Objects.Administration;

public partial class UC_SelectDatabase : System.Web.UI.UserControl
{
	public static string DefaultDatabaseEnviroment
	{
		get
		{
			return ConfigurationManager.AppSettings["DefaultDatabaseEnviroment"].ToString();
		}
	}

	private string _ConnectionName;
	public string ConnectionName
	{
		get
		{
			if (ajaxComboBox_Database.SelectedItem == null)
			{
				_ConnectionName = "";
			}
			else
			{
				_ConnectionName = ajaxComboBox_Database.SelectedItem.Text;
			}

			return (_ConnectionName);
		}
	}

	private string _ConnectionValue;
	public string ConnectionValue
	{
		get
		{

			if (ajaxComboBox_Database.SelectedItem == null)
			{
				_ConnectionValue = "";
			}
			else
			{
				_ConnectionValue = ajaxComboBox_Database.SelectedValue;
			}

			return _ConnectionValue;
		}
	}

	public Int32 SelectedIndex
	{
		get
		{
			if (ajaxComboBox_Database.SelectedItem == null)
			{
				return 0;
			}
			else
			{
				return ajaxComboBox_Database.SelectedIndex;
			}

		}
		set
		{
			BindDropdown_DatabaseList();
			ajaxComboBox_Database.SelectedIndex = value;
			ajaxComboBox_Database_SelectedIndexChanged(null, null);
		}
	}

	public int SelectedCompanyIndex
	{
		get 
		{ 
			return ajaxComboBox_Company.SelectedIndex; 
		}
		set
		{
			ajaxComboBox_Company.SelectedIndex = value;
		}
	}



	public int SelectedCompanyID
	{
		get
		{
			return int.Parse(ajaxComboBox_Company.SelectedValue);
		}

	}

	public string SelectedCompanyCode
	{
		get
		{
			return ajaxComboBox_Company.SelectedValue;
		}

	}

	public string SelectedCompanyName
	{
		get
		{
			return ajaxComboBox_Company.SelectedItem.Text;
		}

	}
	

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			BindDropdown_DatabaseList();
		}
	}


	protected void ajaxComboBox_Database_SelectedIndexChanged(object sender, EventArgs e)
	{
		lbl_Message.Text = string.Empty;
		Connection.ConnectionString = Micro.Commons.MicroSecurity.Decrypt(ajaxComboBox_Database.SelectedValue);
		FillCompanies();
	}




	private void BindDropdown_DatabaseList()
	{

		List<Connection> ConnectionList = new List<Connection>();

		//ddl_Database.Items.Clear();
		//ddl_Database.Items.Add(new ListItem("--select database--"));
		foreach (ConnectionStringSettings conString in ConfigurationManager.ConnectionStrings)
		{
			Connection c = new Connection();
			c.Key = conString.Name;
			c.Value = conString.ConnectionString;
			ConnectionList.Add(c);

			//ListItem newListItem = new ListItem();
			//newListItem.Text = conString.Name;
			//newListItem.Value = conString.ConnectionString;
			//ddl_Database.Items.Add(newListItem);
			//newListItem = null;
		}

		//ddl_Database.Items.Clear();
		//ddl_Database.DataSource = ConnectionList;
		//ddl_Database.DataTextField = "Key";
		//ddl_Database.DataValueField = "Value";
		//ddl_Database.DataBind();
		ajaxComboBox_Database.DropDownStyle = AjaxControlToolkit.ComboBoxStyle.DropDownList;
		ajaxComboBox_Database.Items.Clear();
		ajaxComboBox_Database.DataSource = ConnectionList;
		ajaxComboBox_Database.DataTextField = "Key";
		ajaxComboBox_Database.DataValueField = "Value";
		ajaxComboBox_Database.DataBind();

		//ajaxComboBox_Database.Items.Insert(0, "--select database--");
		//ajaxComboBox_Database.SelectedIndex = 0;
		FillCompanies();
	}

	/// <summary>
	/// Fill the list of companies from the database and populate at drop down list
	/// </summary>
	private void FillCompanies()
	{
		try
		{
			if (!(string.IsNullOrEmpty(Connection.ConnectionString)))
			{
				List<Company> MicroCompanyList = CompanyManagement.GetInstance.GetMicroCompanyList();
				if (MicroCompanyList.Count > 0)
				{

					ajaxComboBox_Company.DataSource = MicroCompanyList;
					ajaxComboBox_Company.DataTextField = CompanyManagement.GetInstance.DisplayMember;
					ajaxComboBox_Company.DataValueField = CompanyManagement.GetInstance.ValueMember;
					ajaxComboBox_Company.DataBind();
					//ajaxComboBox_Company.SelectedIndex = 0;
				}
				else
				{
					ajaxComboBox_Company.Items.Clear();				
				}
			}
		}
		catch (Exception ex)
		{
			lbl_Message.Text = ex.Message.ToString();

		}
	}
}
