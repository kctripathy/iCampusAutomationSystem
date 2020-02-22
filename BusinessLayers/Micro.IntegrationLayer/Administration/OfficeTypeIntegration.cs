using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

using Micro.Objects.Administration;
using Micro.DataAccessLayer.Administration;

namespace Micro.IntegrationLayer.Administration
{
    public class OfficeTypeIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertOfficeType(OfficeType officeType)
        {
            try
            {
                return OfficeTypesDataAccess.GetInstance.InsertOfficeType(officeType);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int UpdateOfficeType(OfficeType officeType)
        {
            try
            {
                return OfficeTypesDataAccess.GetInstance.UpdateOfficeType(officeType);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int DeleteOfficeType(int OfficeTypeID)
        {
            try
            {
                return OfficeTypesDataAccess.GetInstance.DeleteOfficeType(OfficeTypeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public static OfficeType ConvertFromDatarowToObject(DataRow dataRow)
        {
            try
            {
                OfficeType officeType = new OfficeType();

                if (dataRow != null)
                {
                    officeType.OfficeTypeID = int.Parse(dataRow["OfficeTypeID"].ToString());
                    officeType.OfficeTypeName = dataRow["OfficeTypeName"].ToString();
                    officeType.OfficeTypeDescription = dataRow["OfficeTypeDescription"].ToString();
                    officeType.OfficeTypeAbbreviation = dataRow["OfficeTypeAbbreviation"].ToString();

                    if (dataRow["ParentOfficeTypeID"].ToString() != "")
                    {
                        officeType.ParentOfficeTypeID = int.Parse(dataRow["ParentOfficeTypeID"].ToString());
                        //officeType.ParentOfficeTypeName = dataRow["ParentOfficeTypeName"].ToString();
                    }
                    else
                    {
                        officeType.ParentOfficeTypeID = -1;
                        officeType.ParentOfficeTypeName = "";
                    }

                    officeType.HierarchyIndex = (dataRow["HierarchyIndex"].ToString() == string.Empty? -1 : int.Parse(dataRow["HierarchyIndex"].ToString()));

                    officeType.IsActive = (bool)dataRow["IsActive"];
                    officeType.IsDeleted = (bool)dataRow["IsDeleted"];
                }
                return officeType;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        public static OfficeType GetOfficeTypeByOfficeTypeID(int OfficeTypeID)
        {
            try
            {
                return ConvertFromDatarowToObject( OfficeTypesDataAccess.GetInstance.GetOfficeTypesByOfficeTypeID(OfficeTypeID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        public static OfficeType GetOfficeTypeByOfficeTypeAbbreviation(string OfficeTypeAbbreviation)
        {
            try
            {
                return ConvertFromDatarowToObject(OfficeTypesDataAccess.GetInstance.GetOfficeTypesByAbbreviation(OfficeTypeAbbreviation));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<OfficeType> GetOfficeTypesByHierarchyIndex(int HierarchyIndex)
        {
            try
            {
                DataTable OfficeTypesTable = OfficeTypesDataAccess.GetInstance.GetOfficeTypesByHierarchyIndex (HierarchyIndex);
                List<OfficeType> OfficeTypeList = new List<OfficeType>();
                foreach (DataRow dr in OfficeTypesTable.Rows)
                {
                    OfficeTypeList.Add(ConvertFromDatarowToObject(dr));
                }
                return OfficeTypeList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<OfficeType> GetOfficeTypesByParentOfficeTypeID(int ParentOfficeTypeID)
        {
            try
            {
                DataTable OfficeTypesTable = OfficeTypesDataAccess.GetInstance.GetOfficeTypesByParentOfficeTypeID(ParentOfficeTypeID);
                List<OfficeType> OfficeTypeList = new List<OfficeType>();
                foreach (DataRow dr in OfficeTypesTable.Rows)
                {
                    OfficeTypeList.Add(ConvertFromDatarowToObject(dr));
                }
                return OfficeTypeList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<OfficeType> GetOfficeTypesAll(bool showDeleted = false)
        {
            try
            {
                DataTable OfficeTypesTable = OfficeTypesDataAccess.GetInstance.GetOfficeTypesAll( showDeleted);
                List<OfficeType> OfficeTypeList = new List<OfficeType>();
                foreach (DataRow dr in OfficeTypesTable.Rows)
                {
                    OfficeTypeList.Add(ConvertFromDatarowToObject(dr));
                }
                return OfficeTypeList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<OfficeType> GetOfficeTypeList(bool showDeleted = false)
        {
            try
            {
                DataTable OfficeTypesTable = OfficeTypesDataAccess.GetInstance.GetOfficeTypesAll(showDeleted);
                List<OfficeType> OfficeTypeList = new List<OfficeType>();
                foreach (DataRow dr in OfficeTypesTable.Rows)
                {
                    OfficeTypeList.Add(ConvertFromDatarowToObject(dr));
                }
                return OfficeTypeList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<OfficeType> GetOfficeTypeListByUserID(int UserID)
        {
            try
            {
                DataTable OfficeTypesTable = OfficeTypesDataAccess.GetInstance.GetOfficeTypeListByUserID(UserID);
                List<OfficeType> OfficeTypeList = new List<OfficeType>();
                foreach (DataRow dr in OfficeTypesTable.Rows)
                {
                    OfficeTypeList.Add(ConvertFromDatarowToObject(dr));
                }
                return OfficeTypeList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<OfficeType> GetOfficeTypesByCompanyID(int CompanyID=-1)
        {
            try
            {
                DataTable OfficeTypesTable = OfficeTypesDataAccess.GetInstance.GetOfficeTypesByCompanyID(CompanyID);
                List<OfficeType> OfficeTypeList = new List<OfficeType>();
                foreach (DataRow dr in OfficeTypesTable.Rows)
                {
                    OfficeTypeList.Add(ConvertFromDatarowToObject(dr));
                }
                return OfficeTypeList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
         #endregion
    }
}
