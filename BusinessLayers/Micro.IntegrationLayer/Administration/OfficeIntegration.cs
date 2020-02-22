using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

using Micro.DataAccessLayer.Administration;
using Micro.Objects.Administration;

namespace Micro.IntegrationLayer.Administration
{
    public partial class OfficeIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertMicroOffice(Office objOffice)
        {
            try
            {
                return OfficeDataAccess.GetInstance.InsertOffice(objOffice);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int UpdateMicroOffice(Office objOffice)
        {
            try
            {
                return OfficeDataAccess.GetInstance.UpdateOffice(objOffice);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int DeleteMicroOffice(int OfficeID)
        {
            try
            {
                return OfficeDataAccess.GetInstance.DeleteOffice(OfficeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Methods & Implementation

        public static Office DataRowToObject(DataRow dataRow,Boolean  IsList=false )
        {
            Office objOffice = new Office();

            objOffice.OfficeID = int.Parse(dataRow["OfficeID"].ToString());
            objOffice.OfficeName = dataRow["OfficeName"].ToString();
            objOffice.OfficeTypeID = int.Parse(dataRow["OfficeTypeID"].ToString());
            objOffice.OfficeTypeDescription = dataRow["OfficeTypeDescription"].ToString();
            objOffice.OfficeCode = dataRow["OfficeCode"].ToString();
			if (!(string.IsNullOrWhiteSpace(dataRow["EstablishmentDate"].ToString())))
			{
                objOffice.EstablishmentDate =DateTime.Parse( dataRow["EstablishmentDate"].ToString());
			}
            if (dataRow["ParentOfficeName"].ToString() != "")
            {
                objOffice.ParentOfficeID = int.Parse(dataRow["ParentOfficeID"].ToString());
                objOffice.ParentOfficeName = dataRow["ParentOfficeName"].ToString();
            }
            else
            {
                //objOffice.ParentOfficeID = nothing;
                //objOffice.ParentOfficeName = "";
            }
			if (dataRow["ManagerEmployeeID"].ToString() != "")
			{
				objOffice.ManagerEmployeeID = int.Parse(dataRow["ManagerEmployeeID"].ToString());
				objOffice.ManagerEmployeeName = dataRow["ManagerEmployeeName"].ToString();
			}

            objOffice.Address_TownOrCity = dataRow["Address_TownOrCity"].ToString();
            objOffice.Address_Landmark = dataRow["Address_Landmark"].ToString();
            objOffice.Address_StateName = dataRow["Address_StateName"].ToString();

			if (dataRow["Address_DistrictID"].ToString() != "")
			{
				objOffice.Address_DistrictID = int.Parse(dataRow["Address_DistrictID"].ToString());
			}
            objOffice.Address_DistrictName = dataRow["Address_DistrictName"].ToString();
            objOffice.Address_PinCode = dataRow["Address_PinCode"].ToString();

            if (IsList == false)
            {
                objOffice.ContactPerson1 = dataRow["ContactPerson1"].ToString();
                objOffice.ContactPerson2 = dataRow["ContactPerson2"].ToString();
                objOffice.ContactPerson3 = dataRow["ContactPerson3"].ToString();

                objOffice.StdCodePhone = dataRow["StdCodePhone"].ToString();
                objOffice.Phone1 = dataRow["Phone1"].ToString();
                objOffice.Phone2 = dataRow["Phone2"].ToString();
                objOffice.Phone3 = dataRow["Phone3"].ToString();

                objOffice.Extension1 = dataRow["Extension1"].ToString();
                objOffice.Extension2 = dataRow["Extension2"].ToString();
                objOffice.Extension3 = dataRow["Extension3"].ToString();

                objOffice.StdCodeFax = dataRow["StdCodeFax"].ToString();
                objOffice.Fax1 = dataRow["Fax1"].ToString();
                objOffice.Fax2 = dataRow["Fax2"].ToString();
                objOffice.Fax3 = dataRow["Fax3"].ToString();

                objOffice.Mobile1 = dataRow["Mobile1"].ToString();
                objOffice.Mobile2 = dataRow["Mobile2"].ToString();
                objOffice.Mobile3 = dataRow["Mobile3"].ToString();

                objOffice.Email1 = dataRow["Email1"].ToString();
                objOffice.Email2 = dataRow["Email2"].ToString();
                objOffice.Email3 = dataRow["Email3"].ToString();
                objOffice.IsHavingShift = bool.Parse(dataRow["IsHavingShift"].ToString());
            }

			if (dataRow["CompanyID"].ToString() != "")
			{
				objOffice.CompanyID = int.Parse(dataRow["CompanyID"].ToString());
				objOffice.CompanyCode = dataRow["CompanyCode"].ToString();
				objOffice.CompanyName = dataRow["CompanyName"].ToString();
			}

            return objOffice;
        }

        public static List<Office> GetOfficeList()
        {
            List<Office> MicroOfficeList = new List<Office>();
            DataTable MicroOfficeTable = OfficeDataAccess.GetInstance.GetOfficeList();

            foreach (DataRow dr in MicroOfficeTable.Rows)
            {
                MicroOfficeList.Add(DataRowToObject(dr));
            }

            return MicroOfficeList;
        }

        public static List<Office> GetOfficeListByUserID(int userID)
        {
            List<Office> MicroOfficeList = new List<Office>();
            DataTable MicroOfficeTable = OfficeDataAccess.GetInstance.GetOfficeListByUserID(userID);

            foreach (DataRow dr in MicroOfficeTable.Rows)
            {
                MicroOfficeList.Add(DataRowToObject(dr));
            }

            return MicroOfficeList;
        }

        public static List<Office> GetOfficeByCompanyID(int CompanyID)
        {
            List<Office> MicroOfficeList = new List<Office>();
            DataTable MicroOfficeTable = OfficeDataAccess.GetInstance.GetOfficeByCompanyID(CompanyID);

            foreach (DataRow dr in MicroOfficeTable.Rows)
            {
                MicroOfficeList.Add(DataRowToObject(dr));
            }

            return MicroOfficeList;
        }

        public static Office GetOfficeByID(int officeID)
        {
          return   DataRowToObject(OfficeDataAccess.GetInstance.GetOfficeByID(officeID));
        }

        public static List<Office> GetOfficeListByTypeID(int officeTypeID)
        {
            List<Office> OfficeList = new List<Office>();
            DataTable OfficeTable = OfficeDataAccess.GetInstance.GetOfficeListByTypeID(officeTypeID);

            foreach (DataRow dr in OfficeTable.Rows)
            {
                OfficeList.Add(DataRowToObject(dr));
            }

            return OfficeList;
        }

        public static List<Office> GetOfficeListByUserOfficeTypeID(int officeTypeID)
        {
            List<Office> OfficeList = new List<Office>();
            DataTable OfficeTable = OfficeDataAccess.GetInstance.GetOfficeListByUserOfficeTypeID(officeTypeID);

            foreach (DataRow dr in OfficeTable.Rows)
            {
                OfficeList.Add(DataRowToObject(dr));
            }

            return OfficeList;
        }

        public static List<Office> GetUnitOfficeListByCompanyID()
        {
            List<Office> MicroOfficeList = new List<Office>();
            DataTable MicroOfficeTable = OfficeDataAccess.GetInstance.GetUnitOfficeListByCompanyID();

            foreach (DataRow dr in MicroOfficeTable.Rows)
            {
                MicroOfficeList.Add( DataRowToObject(dr));
            }

            return MicroOfficeList;
        }

        public static List<Office> GetOfficeListByReportingOfficeID(int officeID)
        {
            List<Office> OfficeList = new List<Office>();
            DataTable OfficeTable = OfficeDataAccess.GetInstance.GetOfficeListByReportingOfficeID(officeID);

            foreach (DataRow dr in OfficeTable.Rows)
            {
                OfficeList.Add(DataRowToObject(dr));
            }

            return OfficeList;
        }

        public static List<Office> GetBranchOfficeListByOfficeID(int officeID)
        {
            List<Office> OfficeList = new List<Office>();
            DataTable OfficeTable = OfficeDataAccess.GetInstance.GetBranchOfficeListByOfficeID(officeID);

            foreach (DataRow dr in OfficeTable.Rows)
            {
                OfficeList.Add(DataRowToObject(dr));
            }

            return OfficeList;
        }

        public static List<Office> GetBranchOfficeListByOfficeTypeID(int officeID, int officeTypeID, bool showChildOffices)
        {
            List<Office> OfficeList = new List<Office>();
            DataTable OfficeTable = OfficeDataAccess.GetInstance.GetBranchOfficeListByOfficeTypeID(officeID, officeTypeID, showChildOffices);

            foreach (DataRow dr in OfficeTable.Rows)
            {
                OfficeList.Add(DataRowToObject(dr));
            }

            return OfficeList;
        }

        public static List<Office> GetOfficeTreeByUserID(int userID)
        {
            List<Office> OfficeList = new List<Office>();
            DataTable OfficeTable = OfficeDataAccess.GetInstance.GetOfficeTreeByUserID(userID);

            foreach (DataRow dr in OfficeTable.Rows)
            {
                OfficeList.Add( DataRowToObject(dr));
            }

            return OfficeList;
        }

        public static List<Office> GetOfficeListByCompanyID(int CompanyID=-1)
        {
            List<Office> MicroOfficeList = new List<Office>();
            DataTable MicroOfficeTable = OfficeDataAccess.GetInstance.GetOfficeListByCompanyID(CompanyID );

            foreach (DataRow dr in MicroOfficeTable.Rows)
            {
                MicroOfficeList.Add(DataRowToObject(dr,true));
            }

            return MicroOfficeList;
        }
        #endregion
    }
}


