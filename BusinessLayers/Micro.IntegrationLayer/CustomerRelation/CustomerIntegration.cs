using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
	public partial class CustomerIntegration
	{
		#region Declaration
		#endregion

		#region Methods & Implementation
		public static Customer DataRowToObject(DataRow dr)
		{
			Customer TheCustomer = new Customer
			{
				CustomerID = int.Parse(dr["CustomerID"].ToString()),
				CustomerCode = dr["CustomerCode"].ToString(),
				Salutation = dr["Salutation"].ToString(),
				CustomerName = dr["CustomerName"].ToString(),
				FatherName = dr["FatherName"].ToString(),
				HusbandName = dr["HusbandName"].ToString(),
				Gender = dr["Gender"].ToString(),
				MaritalStatus = dr["MaritalStatus"].ToString(),
				DateOfBirth = DateTime.Parse(dr["DateOfBirth"].ToString()).ToString(MicroConstants.DateFormat),
				Age = int.Parse(dr["Age"].ToString()),
				Address_Present_TownOrCity = dr["Address_Present_TownOrCity"].ToString(),
				Address_Present_Landmark = dr["Address_Present_Landmark"].ToString(),
				Address_Present_PinCode = dr["Address_Present_PinCode"].ToString(),
				Address_Present_DistrictID = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["Address_Present_DistrictID"].ToString())),
				Address_Present_DistrictName = dr["Address_Present_DistrictName"].ToString(),
				Address_Present_StateName = dr["Address_Present_StateName"].ToString(),
				Address_Present_CountryName = dr["Address_Present_CountryName"].ToString(),
				Address_Permanent_TownOrCity = dr["Address_Permanent_TownOrCity"].ToString(),
				Address_Permanent_Landmark = dr["Address_Permanent_Landmark"].ToString(),
				Address_Permanent_PinCode = dr["Address_Permanent_PinCode"].ToString(),
				Address_Permanent_DistrictID = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["Address_Permanent_DistrictID"].ToString())),
				Address_Permanent_DistrictName = dr["Address_Permanent_DistrictName"].ToString(),
				Address_Permanent_StateName = dr["Address_Permanent_StateName"].ToString(),
				Address_Permanent_CountryName = dr["Address_Permanent_CountryName"].ToString(),
				PhoneNumber = dr["PhoneNumber"].ToString(),
				Mobile = dr["Mobile"].ToString(),
				EMailID = dr["EMailID"].ToString(),
				Occupation = dr["Occupation"].ToString(),
				OfficeID = int.Parse(dr["OfficeID"].ToString()),
				OfficeName = dr["OfficeName"].ToString()
			};

			return TheCustomer;
		}

		public static List<Customer> GetCustomerList(bool allOffices = false, bool showDeleted = false)
		{
			List<Customer> CustomerList = new List<Customer>();
			DataTable CustomerTable = CustomerDataAccess.GetInstance.GetCustomerList(allOffices, showDeleted);

			foreach (DataRow dr in CustomerTable.Rows)
			{
				Customer TheCustomer = DataRowToObject(dr);

				CustomerList.Add(TheCustomer);
			}

			return CustomerList;
		}

		public static List<Customer> GetDuplicateCustomerList(string customerName, string fatherName, string dateofBirth, bool allOffices = false, bool showDeleted = false)
		{
			List<Customer> TheCustomerList = GetCustomerList(allOffices, showDeleted);
			List<Customer> TheDuplicateCustomerList = new List<Customer>();

			if (TheCustomerList.Count > 0)
			{
				var DuplicateCustomerList = (from CustomerList in TheCustomerList
											 where CustomerList.CustomerName.ToUpper() == customerName.ToUpper()
											 && CustomerList.FatherName.ToUpper() == fatherName.ToUpper()
											 && CustomerList.DateOfBirth.ToUpper() == dateofBirth.ToUpper()
											 select CustomerList).ToList();

				foreach (Customer EachCustomer in DuplicateCustomerList)
				{
					Customer TheCustomer = (Customer)EachCustomer;

					TheDuplicateCustomerList.Add(TheCustomer);
				}
			}

			return TheDuplicateCustomerList;
		}

		public static List<Customer> GetCustomerListByOfficeIDs(bool allOffices, string officeIDs)
		{
			List<Customer> CustomerList = new List<Customer>();
			DataTable CustomerTable = CustomerDataAccess.GetInstance.GetCustomerListByOfficeIDs(allOffices, officeIDs);

			foreach (DataRow dr in CustomerTable.Rows)
			{
				Customer TheCustomer = DataRowToObject(dr);

				CustomerList.Add(TheCustomer);
			}

			return CustomerList;
		}

		public static List<Customer> GetCustomerListByCustomerLoans(bool allOffices, string officeIDs)
		{
			List<Customer> CustomerList = new List<Customer>();
			DataTable CustomerTable = CustomerDataAccess.GetInstance.GetCustomerListByCustomerLoans(allOffices, officeIDs);

			foreach (DataRow dr in CustomerTable.Rows)
			{
				Customer TheCustomer = DataRowToObject(dr);

				CustomerList.Add(TheCustomer);
			}

			return CustomerList;
		}

		public static List<Customer> GetCustomerMediclaimEligibilityList(bool allOffices = false)
		{
			List<Customer> CustomerList = new List<Customer>();

			DataTable CustomerTable = CustomerDataAccess.GetInstance.GetCustomerMediclaimEligibilityList(allOffices);

			foreach (DataRow dr in CustomerTable.Rows)
			{
				Customer TheCustomer = DataRowToObject(dr);

				CustomerList.Add(TheCustomer);
			}
			return CustomerList;
		}

		public static Customer GetCustomerByID(int customerID)
		{
			DataRow TheCustomerRow = CustomerDataAccess.GetInstance.GetCustomerByID(customerID);

			Customer TheCustomer = DataRowToObject(TheCustomerRow);

			return TheCustomer;
		}

		public static int InsertCustomer(Customer theCustomer)
		{
			return CustomerDataAccess.GetInstance.InsertCustomer(theCustomer);
		}

		public static int UpdateCustomer(Customer theCustomer)
		{
			return CustomerDataAccess.GetInstance.UpdateCustomer(theCustomer);
		}

		public static int DeleteCustomer(Customer theCustomer)
		{
			return CustomerDataAccess.GetInstance.DeleteCustomer(theCustomer);
		}
		#endregion
	}
}
