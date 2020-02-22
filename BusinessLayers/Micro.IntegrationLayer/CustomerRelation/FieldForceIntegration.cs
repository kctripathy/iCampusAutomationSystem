using System;
using System.Collections.Generic;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class FieldForceIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation
        public static FieldForce DataRowToObject(DataRow dr)
        {
            FieldForce TheFieldForce = new FieldForce();

            TheFieldForce.FieldForceID = int.Parse(dr["FieldForceID"].ToString());
            TheFieldForce.FieldForceCode = dr["FieldForceCode"].ToString();
            TheFieldForce.FieldForceRankID = int.Parse(dr["FieldForceRankID"].ToString());
            TheFieldForce.FieldForceRankName = dr["FieldForceRankName"].ToString();
            TheFieldForce.FieldForceRankDescription = dr["FieldForceRankDescription"].ToString();
            TheFieldForce.ReportingToFieldForceRankID = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["ReportingToFieldForceRankID"].ToString()));
            if (TheFieldForce.ReportingToFieldForceRankID > 0)
            {
                TheFieldForce.ReportingToFieldForceRankName = dr["ReportingToFieldForceRankName"].ToString();
                TheFieldForce.ReportingToFieldForceRankDescription = dr["ReportingToFieldForceRankDescription"].ToString();
                TheFieldForce.ReportingToFieldForceID = int.Parse(dr["ReportingToFieldForceID"].ToString());
                TheFieldForce.ReportingToFieldForceCode = dr["ReportingToFieldForceCode"].ToString();
                TheFieldForce.ReportingToFieldForceName = dr["ReportingToFieldForceName"].ToString();
            }
            TheFieldForce.Salutation = dr["Salutation"].ToString();
            TheFieldForce.FieldForceName = dr["FieldForceName"].ToString();
            TheFieldForce.FatherName = dr["FatherName"].ToString();
            TheFieldForce.HusbandName = dr["HusbandName"].ToString();
            TheFieldForce.Gender = dr["Gender"].ToString();
            TheFieldForce.MaritalStatus = dr["MaritalStatus"].ToString();
            TheFieldForce.DateOfBirth = DateTime.Parse(dr["DateOfBirth"].ToString()).ToString(MicroConstants.DateFormat);
            TheFieldForce.Age = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["Age"].ToString()));
            TheFieldForce.Address_Present_TownOrCity = dr["Address_Present_TownOrCity"].ToString();
            TheFieldForce.Address_Present_Landmark = dr["Address_Present_Landmark"].ToString();
            TheFieldForce.Address_Present_PinCode = dr["Address_Present_PinCode"].ToString();
            TheFieldForce.Address_Present_DistrictID = int.Parse(dr["Address_Present_DistrictID"].ToString());
            TheFieldForce.Address_Present_DistrictName = dr["Address_Present_DistrictName"].ToString();
            TheFieldForce.Address_Present_StateName = dr["Address_Present_StateName"].ToString();
            TheFieldForce.Address_Present_CountryName = dr["Address_Present_CountryName"].ToString();
            TheFieldForce.Address_Permanent_TownOrCity = dr["Address_Permanent_TownOrCity"].ToString();
            TheFieldForce.Address_Permanent_Landmark = dr["Address_Permanent_Landmark"].ToString();
            TheFieldForce.Address_Permanent_PinCode = dr["Address_Permanent_PinCode"].ToString();
            TheFieldForce.Address_Permanent_DistrictID = int.Parse(dr["Address_Permanent_DistrictID"].ToString());
            TheFieldForce.Address_Permanent_DistrictName = dr["Address_Permanent_DistrictName"].ToString();
            TheFieldForce.Address_Permanent_StateName = dr["Address_Permanent_StateName"].ToString();
            TheFieldForce.Address_Permanent_CountryName = dr["Address_Permanent_CountryName"].ToString();
            TheFieldForce.PhoneNumber = dr["PhoneNumber"].ToString();
            TheFieldForce.Mobile = dr["Mobile"].ToString();
            TheFieldForce.EMailID = dr["EMailID"].ToString();
            TheFieldForce.FieldForce_Qualification = dr["FieldForce_Qualification"].ToString();
            TheFieldForce.Occupation = dr["Occupation"].ToString();
            TheFieldForce.Nationality = dr["Nationality"].ToString();
            TheFieldForce.Religion = dr["Religion"].ToString();
            TheFieldForce.Caste = dr["Caste"].ToString();
            TheFieldForce.NomineeName = dr["NomineeName"].ToString();
            TheFieldForce.Nominee_Permanent_TownOrCity = dr["Nominee_Permanent_TownOrCity"].ToString();
            TheFieldForce.Nominee_Permanent_Landmark = dr["Nominee_Permanent_Landmark"].ToString();
            TheFieldForce.Nominee_Permanent_PinCode = dr["Nominee_Permanent_PinCode"].ToString();
            TheFieldForce.Nominee_Permanent_DistrictID = int.Parse(dr["Nominee_Permanent_DistrictID"].ToString());
            TheFieldForce.Nominee_Permanent_DistrictName = dr["Nominee_Permanent_DistrictName"].ToString();
            TheFieldForce.Nominee_Permanent_StateName = dr["Nominee_Permanent_StateName"].ToString();
            TheFieldForce.Nominee_Permanent_CountryName = dr["Nominee_Permanent_CountryName"].ToString();
            TheFieldForce.NomineeRelationship = dr["NomineeRelationship"].ToString();
            TheFieldForce.NomineeAge = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["NomineeAge"].ToString()));
            TheFieldForce.IsNomineeACoWorker = bool.Parse(dr["IsNomineeACoWorker"].ToString());
            TheFieldForce.Nominee_Qualification = dr["Nominee_Qualification"].ToString();
            TheFieldForce.BankBranchID = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["BankBranchID"].ToString()));
            if (TheFieldForce.BankBranchID > 0)
            {
                TheFieldForce.BankName = dr["BankName"].ToString();
                TheFieldForce.BankBranchName = dr["BankBranchName"].ToString();
                TheFieldForce.BankAccountNumber = dr["BankAccountNumber"].ToString();
            }
            TheFieldForce.HasServiceComplain = bool.Parse(dr["HasServiceComplain"].ToString());
            TheFieldForce.OfficeID = int.Parse(dr["OfficeID"].ToString());
            TheFieldForce.OfficeName = dr["OfficeName"].ToString();
            return TheFieldForce;
        }

		public static System.Data.DataTable GetFieldForceTable(bool allOffices = false, bool showDeleted = false)
		{
			DataTable FieldForceDataTable = FieldForceDataAccess.GetInstance.GetFieldForceList(allOffices, false);
			return FieldForceDataTable;
		}

        public static List<FieldForce> GetFieldForceList(bool allOffices = false, bool showDeleted = false)
        {
            List<FieldForce> FieldForceList = new List<FieldForce>();

            DataTable GetFieldForce = FieldForceDataAccess.GetInstance.GetFieldForceList(allOffices, showDeleted);

            foreach (DataRow dr in GetFieldForce.Rows)
            {
                FieldForce TheFieldForce = DataRowToObject(dr);

                FieldForceList.Add(TheFieldForce);
            }

            return FieldForceList;
        }

		public static List<FieldForce> GetFieldForceListByOfficeID(int OfficeID,bool allOffices = false, bool showDeleted = false)
		{
			List<FieldForce> FieldForceList = new List<FieldForce>();

			DataTable GetFieldForce = FieldForceDataAccess.GetInstance.GetFieldForceListByOfficeID(OfficeID,allOffices, showDeleted);

			foreach (DataRow dr in GetFieldForce.Rows)
			{
				FieldForce TheFieldForce = DataRowToObject(dr);

				FieldForceList.Add(TheFieldForce);
			}

			return FieldForceList;
		}

        public static FieldForce GetFieldForceById(int recordId)
        {
            DataRow FieldForceRow = FieldForceDataAccess.GetInstance.GetFieldForceById(recordId);

            FieldForce TheFieldForce = DataRowToObject(FieldForceRow);

            return TheFieldForce;
        }




        public static FieldForce GetFieldForceByCode(string fieldForceCode)
        {
            FieldForce TheFieldForce;
            DataRow FieldForceRow = FieldForceDataAccess.GetInstance.GetFieldForceByCode(fieldForceCode);
            if (FieldForceRow != null)

                TheFieldForce = DataRowToObject(FieldForceRow);

            else
                TheFieldForce = new FieldForce();
            return TheFieldForce;
        }

        public static List<FieldForce> GetFieldForceByFieldForceRankID(int fieldForceRankID = 0, bool allOffices = false)
        {
            List<FieldForce> FieldForceList = new List<FieldForce>();

            DataTable FieldForceTable = FieldForceDataAccess.GetInstance.GetFieldForceByFieldForceRankID(fieldForceRankID, allOffices);

            foreach (DataRow dr in FieldForceTable.Rows)
            {
                FieldForce TheFieldForce = DataRowToObject(dr);

                FieldForceList.Add(TheFieldForce);
            }

            return FieldForceList;
        }

        public static List<FieldForce> GetFieldForceChainByFieldForceID(int fieldForceID)
        {
            List<FieldForce> FieldForceList = new List<FieldForce>();

            DataTable FieldForceTable = FieldForceDataAccess.GetInstance.GetFieldForceChainByFieldForceID(fieldForceID);

            foreach (DataRow dr in FieldForceTable.Rows)
            {
                FieldForce TheFieldForce = DataRowToObject(dr);

                FieldForceList.Add(TheFieldForce);
            }

            return FieldForceList;
        }

        public static decimal GetAverageCommissionByFieldForceId(int fieldForceID)
        {
            DataRow FieldForceDataRow = FieldForceDataAccess.GetInstance.GetAverageCommissionByFieldForceId(fieldForceID);
            decimal ReturnValue = decimal.Parse(FieldForceDataRow["AverageCommission"].ToString());

            return ReturnValue;
        }

        public static int InsertFieldForce(FieldForce theFieldForce, FieldForceProfile thePhoto, FieldForceProfile theSignature)
        {
            return FieldForceDataAccess.GetInstance.InsertFieldForce(theFieldForce, thePhoto, theSignature);
        }

        public static int UpdateFieldForce(FieldForce theFieldForce, FieldForceProfile thePhoto, FieldForceProfile theSignature)
        {
            return FieldForceDataAccess.GetInstance.UpdateFieldForce(theFieldForce, thePhoto, theSignature);
        }

        public static int DeleteFieldForce(FieldForce theFieldForce)
        {
            return FieldForceDataAccess.GetInstance.DeleteFieldForce(theFieldForce);
        }
        #endregion
    }
}
