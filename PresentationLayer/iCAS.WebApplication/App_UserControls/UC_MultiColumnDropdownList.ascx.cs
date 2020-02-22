using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Objects.CustomerRelation;
using Micro.BusinessLayer.CustomerRelation;
using Micro.Commons;
using Micro.Objects.HumanResource;
using Micro.Framework.ReadXML;
using Micro.BusinessLayer.HumanResource;

namespace Micro.WebApplication.App_UserControls
{
    [ValidationProperty("Text")]
    public partial class UC_MultiColumnDropdownList : System.Web.UI.UserControl
    {
        #region Declaration
        protected static class PageVariables
        {
            public static int FirstFieldLength = 20;
            public static int SecondFieldLength = 25;
            public static string SelectedTextField;
            public static int ValueForSelectedText;
            public static List<DCAccount> TheDCAccountList = null;
            public static List<Customer> TheCustomerList = null;
            public static List<CustomerAccount> TheCustomerAccountList = null;
            public static List<FieldForce> TheFieldForceList = null;
            public static List<CustomerAccountReceipt> TheCustomerAccountReceiptList = null;
            public static List<CustomerLoan> TheCustomerLoanList = null;
            public static List<CustomerLoanReceipt> TheCustomerLoanReceiptList = null;
            public static List<Employee> TheEmployeeList = null;
        }

        public event System.EventHandler SelectedIndexChenge;
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //FillDCAccounts();
                SetValidationMessages();
            }
        }

        protected void ddl_MultiColumn_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedIndexChanged(sender);
        }

        /// <summary> 
        /// Function that called by change selected index which
        /// in turns fires the selectedindexchange event 
        /// trapped by the client 
        /// </summary> 
        protected virtual void OnSelectedIndexChanged(object sender)
        {
            // Raise the SelectedIndexChenge event. 
            if (this.SelectedIndexChenge != null)
            {
                this.SelectedIndexChenge(sender, new EventArgs());
            }
        }
        #endregion

        #region Control Properties
        public string DataTextField
        {
            set
            {
                ddl_MultiColumn.DataTextField = value;
            }
            get
            {
                string dttextfield = ddl_MultiColumn.DataTextField;
                return dttextfield;
            }
        }

        public string Text
        {
            set
            {
                ddl_MultiColumn.Text = value;
            }
            get
            {
                string txt = ddl_MultiColumn.Text;
                return txt;
            }
        }

        public string DataValueField
        {
            set
            {
                ddl_MultiColumn.DataValueField = value;
                ddl_MultiColumn.DataBind();
            }
        }

        public object DataSource
        {
            get
            {
                object dtSource = ddl_MultiColumn.DataSource;
                return dtSource;
            }
            set
            {
                ddl_MultiColumn.DataSource = value;
                //ddl_MultiColumn.DataBind();
            }
        }

        public bool Enabled
        {
            set
            {
                ddl_MultiColumn.Enabled = value;
            }
        }

        public bool Visible
        {
            set
            {
                ddl_MultiColumn.Visible = value;
            }
        }

        public int SelectedRecordID
        {
            get
            {
                int SelId = int.Parse(ddl_MultiColumn.SelectedValue.ToString());
                return SelId;
            }
        }

        public string SelectedValue
        {
            get
            {
                string SelVal = ddl_MultiColumn.SelectedValue;
                return SelVal;
            }
            set
            {
                ddl_MultiColumn.SelectedValue = value;
            }
        }

        public int SelectedIndex
        {
            get
            {
                int SelIndex = ddl_MultiColumn.SelectedIndex;
                return SelIndex;
            }
            set
            {
                ddl_MultiColumn.SelectedIndex = value;
            }
        }

        public string SelectedText
        {
            get
            {
                string SelectText = "";
                if (PageVariables.ValueForSelectedText == 0)//For Dcaccount
                {
                    var _SelText = (from DCCust in PageVariables.TheDCAccountList
                                    where DCCust.DCAccountID == SelectedRecordID
                                    select DCCust.CustomerName).Last();

                    SelectText = _SelText.ToString();
                }

                if (PageVariables.ValueForSelectedText == 1)//For Customer
                {
                    var _SelText = (from Cust in PageVariables.TheCustomerList
                                    where Cust.CustomerID == SelectedRecordID
                                    select Cust.CustomerName).Last();

                    SelectText = _SelText.ToString();
                }

                if (PageVariables.ValueForSelectedText == 2)//For CustomerAccount
                {
                    var _SelText = (from CustAccount in PageVariables.TheCustomerAccountList
                                    where CustAccount.CustomerAccountID == SelectedRecordID
                                    select CustAccount.CustomerName).Last();

                    SelectText = _SelText.ToString();
                }

                if (PageVariables.ValueForSelectedText == 3)//For FieldForce
                {
                    var _SelText = (from FF in PageVariables.TheFieldForceList
                                    where FF.FieldForceID == SelectedRecordID
                                    select FF.FieldForceName).Last();

                    SelectText = _SelText.ToString();
                }

                if (PageVariables.ValueForSelectedText == 4)//For CustomerAccountReceipt
                {
                    //TODO: write code here
                    SelectText = "";
                }

                if (PageVariables.ValueForSelectedText == 5)//For CustomerLoan
                {
                    //TODO: write code here
                    SelectText = "";
                }

                if (PageVariables.ValueForSelectedText == 6)//For CustomerLoanReceipt
                {
                    //TODO: write code here
                    SelectText = "";
                }

                if (PageVariables.ValueForSelectedText == 7)//For Employee
                {
                    //TODO: write code here
                    SelectText = "";
                }
                return SelectText;
            }
        }

        //public object ListObject
        //{
        //set
        //{
        //    List<DCAccount> theDCAccountList = new List<DCAccount>();
        //    List<Customer> theCustomerList = new List<Customer>();
        //    List<CustomerAccount> theCustomerAccountList = new List<CustomerAccount>();

        //    if (value.Equals(theDCAccountList))
        //    {
        //        ddl_MultiColumn.DataSource = value;
        //        ddl_MultiColumn.DataTextField = DCAccountsManagement.GetInstance.DisplayMember;
        //        ddl_MultiColumn.DataValueField = DCAccountsManagement.GetInstance.ValueMember;
        //        ddl_MultiColumn.DataBind();
        //    }

        //    if (value.Equals(theCustomerList))
        //    {
        //        ddl_MultiColumn.DataSource = value;
        //        ddl_MultiColumn.DataTextField = CustomerManagement.GetInstance.DisplayMember;
        //        ddl_MultiColumn.DataValueField = CustomerManagement.GetInstance.ValueMember;
        //        ddl_MultiColumn.DataBind();
        //    }
        //    if (value.Equals(theCustomerAccountList))
        //    {
        //        ddl_MultiColumn.DataSource = value;
        //        ddl_MultiColumn.DataTextField = CustomerAccountManagement.GetInstance.DisplayMember;
        //        ddl_MultiColumn.DataValueField = CustomerAccountManagement.GetInstance.ValueMember;
        //        ddl_MultiColumn.DataBind();
        //    }
        //}
        //}
        #endregion

        #region Methods & Implementation
        public void BindDCAccountList(List<DCAccount> theDCAccountList)
        {
			//ddl_MultiColumn.Items.Clear();
            ddl_MultiColumn.DataSource = null;
            ddl_MultiColumn.DataBind();
            PageVariables.ValueForSelectedText = 0;
            PageVariables.TheDCAccountList = theDCAccountList;

            List<DCAccount> newdcacclist = new List<DCAccount>();
            foreach (DCAccount dcac in theDCAccountList)
            {
                DCAccount newdcaccount = new DCAccount();
                TextBox t1 = new TextBox();
                t1.Text = AlignLeft(dcac.CustomerName, PageVariables.FirstFieldLength) + " | " + AlignLeft(dcac.DCAccountCode, PageVariables.SecondFieldLength);
                newdcaccount.DCAccountID = dcac.DCAccountID;
                newdcaccount.CustomerName = t1.Text;
                newdcacclist.Add(newdcaccount);
            }
            //
            ddl_MultiColumn.DataSource = newdcacclist;

            ddl_MultiColumn.DataTextField = DCAccountManagement.GetInstance.DisplayMember;
            ddl_MultiColumn.DataValueField = DCAccountManagement.GetInstance.ValueMember;
            ddl_MultiColumn.DataBind();

            ddl_MultiColumn.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }

        public void BindCustomerList(List<Customer> theCustomerList)
        {
			//ddl_MultiColumn.Items.Clear();
            ddl_MultiColumn.DataSource = null;
            ddl_MultiColumn.DataBind();
            PageVariables.ValueForSelectedText = 1;
            PageVariables.TheCustomerList = theCustomerList;

            List<Customer> newcustlist = new List<Customer>();
            foreach (Customer NewCust in theCustomerList)
            {
                Customer newcust = new Customer();
                TextBox t1 = new TextBox();
                t1.Text = AlignLeft(NewCust.CustomerName, PageVariables.FirstFieldLength) + " | " + AlignLeft(NewCust.CustomerCode, PageVariables.SecondFieldLength);
                newcust.CustomerID = NewCust.CustomerID;
                newcust.CustomerName = t1.Text;
                newcustlist.Add(newcust);
            }
            //
            ddl_MultiColumn.DataSource = newcustlist;

            ddl_MultiColumn.DataTextField = CustomerManagement.GetInstance.DisplayMember;
            ddl_MultiColumn.DataValueField = CustomerManagement.GetInstance.ValueMember;
            ddl_MultiColumn.DataBind();

            ddl_MultiColumn.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }

        public void BindCustomerAccountList(List<CustomerAccount> theCustomerAccountList)
        {
			//ddl_MultiColumn.Items.Clear();
            ddl_MultiColumn.DataSource = null;
            ddl_MultiColumn.DataBind();
            PageVariables.ValueForSelectedText = 2;
            PageVariables.TheCustomerAccountList = theCustomerAccountList;

            List<CustomerAccount> newcustaccountlist = new List<CustomerAccount>();
            foreach (CustomerAccount NewCustAccount in theCustomerAccountList)
            {
                CustomerAccount newcustaccount = new CustomerAccount();
                TextBox t1 = new TextBox();
                t1.Text = AlignLeft(NewCustAccount.CustomerName, PageVariables.FirstFieldLength) + " | " + AlignLeft(NewCustAccount.CustomerAccountCode, PageVariables.SecondFieldLength);
                newcustaccount.CustomerAccountID = NewCustAccount.CustomerAccountID;
                newcustaccount.CustomerName = t1.Text;
                newcustaccountlist.Add(newcustaccount);
            }
            //
            ddl_MultiColumn.DataSource = newcustaccountlist;

            ddl_MultiColumn.DataTextField = CustomerAccountManagement.GetInstance.DisplayMember;
            ddl_MultiColumn.DataValueField = CustomerAccountManagement.GetInstance.ValueMember;
            ddl_MultiColumn.DataBind();

            ddl_MultiColumn.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }

        public void BindFieldForceList(List<FieldForce> theFieldForceList)
        {
			//ddl_MultiColumn.Items.Clear();
            ddl_MultiColumn.DataSource = null;
            ddl_MultiColumn.DataBind();
            PageVariables.ValueForSelectedText = 3;
            PageVariables.TheFieldForceList = theFieldForceList;

            List<FieldForce> newfieldforcelist = new List<FieldForce>();
            foreach (FieldForce NewFieldForce in theFieldForceList)
            {
                FieldForce newfieldforce = new FieldForce();
                TextBox t1 = new TextBox();
                t1.Text = AlignLeft(NewFieldForce.FieldForceName, PageVariables.FirstFieldLength) + " | " + AlignLeft(NewFieldForce.FieldForceCode, PageVariables.SecondFieldLength);
                newfieldforce.FieldForceID = NewFieldForce.FieldForceID;
                newfieldforce.FieldForceName = t1.Text;
                newfieldforcelist.Add(newfieldforce);
            }
            //
            ddl_MultiColumn.DataSource = newfieldforcelist;

            ddl_MultiColumn.DataTextField = FieldForceManagement.GetInstance.DisplayMember;
            ddl_MultiColumn.DataValueField = FieldForceManagement.GetInstance.ValueMember;
            ddl_MultiColumn.DataBind();

            ddl_MultiColumn.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }

        public void BindCustomerAccountReceiptList(List<CustomerAccountReceipt> theCustomerAccountReceiptList)
        {
			//ddl_MultiColumn.Items.Clear();
            ddl_MultiColumn.DataSource = null;
            ddl_MultiColumn.DataBind();
            PageVariables.ValueForSelectedText = 4;
            PageVariables.TheCustomerAccountReceiptList = theCustomerAccountReceiptList;
            //TODO: write rest of code here
        }

        public void BindCustomerLoanList(List<CustomerLoan> theCustomerLoanList)
        {
			//ddl_MultiColumn.Items.Clear();
            ddl_MultiColumn.DataSource = null;
            ddl_MultiColumn.DataBind();
            PageVariables.ValueForSelectedText = 5;
            PageVariables.TheCustomerLoanList = theCustomerLoanList;

            List<CustomerLoan> newCustomerLoanlist = new List<CustomerLoan>();
            foreach (CustomerLoan NewCustomerLoan in theCustomerLoanList)
            {
                CustomerLoan newcustomerLoan = new CustomerLoan();
                TextBox t1 = new TextBox();
                t1.Text = AlignLeft(NewCustomerLoan.CustomerName, PageVariables.FirstFieldLength) + " | " + AlignLeft(NewCustomerLoan.CustomerLoanCode, PageVariables.SecondFieldLength);
                newcustomerLoan.CustomerLoanID = NewCustomerLoan.CustomerLoanID;
                newcustomerLoan.CustomerLoanCode = t1.Text;
                newCustomerLoanlist.Add(newcustomerLoan);
            }
            //
            ddl_MultiColumn.DataSource = newCustomerLoanlist;

            ddl_MultiColumn.DataTextField = CustomerLoanManagement.GetInstance.DisplayMember;
            ddl_MultiColumn.DataValueField = CustomerLoanManagement.GetInstance.ValueMember;
            ddl_MultiColumn.DataBind();

            ddl_MultiColumn.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }

        public void BindCustomerLoanReceiptList(List<CustomerLoanReceipt> theCustomerLoanReceiptList)
        {
			//ddl_MultiColumn.Items.Clear();
            ddl_MultiColumn.DataSource = null;
            ddl_MultiColumn.DataBind();
            PageVariables.ValueForSelectedText = 6;
            PageVariables.TheCustomerLoanReceiptList = theCustomerLoanReceiptList;
            //TODO: write rest of code here

        }

        public void BindEmployeeList(List<Employee> theEmployeeList)
        {
			//ddl_MultiColumn.Items.Clear();
            ddl_MultiColumn.DataSource = null;
            ddl_MultiColumn.DataBind();
            PageVariables.ValueForSelectedText = 4;
            PageVariables.TheEmployeeList = theEmployeeList;
    
            //TODO: write rest of code here
            List<Employee> newemplist = new List<Employee>();
            foreach (Employee NewEmp in theEmployeeList)
            {
                Employee newemp = new Employee();
                TextBox t1 = new TextBox();
                t1.Text = AlignLeft(NewEmp.EmployeeName, PageVariables.FirstFieldLength) + " | " + AlignLeft(NewEmp.EmployeeCode, PageVariables.SecondFieldLength);
                newemp.EmployeeID = NewEmp.EmployeeID;
                newemp.EmployeeName = t1.Text;
                newemplist.Add(newemp);
            }
            //
            ddl_MultiColumn.DataSource = newemplist;

            ddl_MultiColumn.DataTextField = EmployeeManagement.GetInstance.DisplayMember;
            ddl_MultiColumn.DataValueField = EmployeeManagement.GetInstance.ValueMember;
            ddl_MultiColumn.DataBind();

            ddl_MultiColumn.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }

        private string AlignLeft(string vStr, int vSpace)
        {
            string returnvalue = "";
            if ((vStr.Trim()).Length > vSpace)
            {
                returnvalue = vStr.Substring(0, (vSpace - 3)) + "...";
            }
            else
            {
                returnvalue = vStr + AddSpace((vSpace - (vStr.Trim()).Length), "\xA0");
            }
            return returnvalue;
        }

        private string AlignRight(string vStr, int vSpace)
        {
            string returnvalue = "";
            returnvalue = AddSpace((vSpace - (vStr.Trim()).Length), "\xA0") + vStr;
            return returnvalue;
        }

        private string AddSpace(int totChar, string chrStr)
        {
            string retValue = "";

            for (int i = 0; i <= totChar - 1; i++)
            {
                retValue += chrStr;
            }
            return retValue;
        }

        private void SetValidationMessages()
        {
            requiredFieldValidator_MultiColumn.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_MultiColumn.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "From List");
            SetFormMessageCSSClass("ValidateMessage");
        }

        private void SetFormMessageCSSClass(string theClassName)
        {
            requiredFieldValidator_MultiColumn.CssClass = theClassName;
        }
        #endregion
    }
}