using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;
using System.Data;
using System.Web;
using System;

namespace Micro.BusinessLayer.CustomerRelation
{
	public partial class FieldForceManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static FieldForceManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static FieldForceManagement GetInstance
		{
			get
			{
				if (_Instance == null)
				{
					_Instance = new FieldForceManagement();
				}
				return _Instance;
			}
			set
			{
				_Instance = value;
			}
		}
		#endregion

		#region Declaration
		public string DefaultColumns = "FieldForceName, FieldForceCode, FieldForceRankName, ReportingToFieldForceName, ReportingToFieldForceCode, ReportingToFieldForceRankName";
		public string DisplayFieldForceCode = "FieldForceCode";
		public string DisplayMember = "FieldForceName";
		public string ValueMember = "FieldForceID";
		#endregion

		#region Methods & Imlpementation
		public DataTable GetFieldForceTable(bool allOffices = false, bool showDeleted = false)
		{

			return FieldForceIntegration.GetFieldForceTable(allOffices, showDeleted);
		}

		public List<FieldForce> GetFieldForceList(bool allOffices = false, bool showDeleted = false)
		{
			string UniqueKey = String.Format("GetFieldForceList_allOffices_{0}_showDeleted_{1}", allOffices, showDeleted);
			if (HttpRuntime.Cache[UniqueKey] == null)
			{
				List<FieldForce> FieldForceList = FieldForceIntegration.GetFieldForceList(allOffices, showDeleted);
				HttpRuntime.Cache[UniqueKey] = FieldForceList;
			}
			return (List<FieldForce>)(HttpRuntime.Cache[UniqueKey]);
			//return FieldForceIntegration.GetFieldForceList(allOffices, showDeleted);
		}

		public List<FieldForce> GetFieldForceListByOfficeID(int OfficeID,bool allOffices = false, bool showDeleted = false)
		{
			return FieldForceIntegration.GetFieldForceListByOfficeID(OfficeID,allOffices, showDeleted);
		}

		public FieldForce GetFieldForceById(int recordId)
		{
			return FieldForceIntegration.GetFieldForceById(recordId);
		}

		public FieldForce GetFieldForceByCode(string fieldForceCode)
		{
			return FieldForceIntegration.GetFieldForceByCode(fieldForceCode);
		}

		public List<FieldForce> GetFieldForceByFieldForceRankID(int fieldForceRankID = 0, bool allOffices = false)
		{
			return FieldForceIntegration.GetFieldForceByFieldForceRankID(fieldForceRankID, allOffices);
		}

		public List<FieldForce> GetFieldForceChainByFieldForceID(int fieldForceID)
		{
			return FieldForceIntegration.GetFieldForceChainByFieldForceID(fieldForceID);
		}

		public decimal GetAverageCommissionByFieldForceId(int fieldForceID)
		{
			return FieldForceIntegration.GetAverageCommissionByFieldForceId(fieldForceID);
		}

		public int InsertFieldForce(FieldForce theFieldForce, FieldForceProfile thePhoto, FieldForceProfile theSignature)
		{
			return FieldForceIntegration.InsertFieldForce(theFieldForce, thePhoto, theSignature);
		}

		public int UpdateFieldForce(FieldForce theFieldForce, FieldForceProfile thePhoto, FieldForceProfile theSignature)
		{
			return FieldForceIntegration.UpdateFieldForce(theFieldForce, thePhoto, theSignature);
		}

		public int DeleteFieldForce(FieldForce theFieldForce)
		{
			return FieldForceIntegration.DeleteFieldForce(theFieldForce);
		}
		#endregion
	}
}
