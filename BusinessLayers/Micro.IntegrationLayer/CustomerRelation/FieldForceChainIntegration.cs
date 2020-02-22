using System;
using System.Collections.Generic;
using Micro.Objects.CustomerRelation;
using System.Data;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Commons;

namespace Micro.IntegrationLayer.CustomerRelation
{
	public partial class FieldForceChainIntegration
	{
		#region Methods & Implementation
		public static FieldForceChain DataRowToObject(DataRow dr)
		{
			FieldForceChain TheFieldForceChain = new FieldForceChain();

			TheFieldForceChain.FieldForceChainID = int.Parse(dr["FieldForceChainID"].ToString());
			TheFieldForceChain.FieldForceID = int.Parse(dr["FieldForceID"].ToString());
			TheFieldForceChain.FieldForceCode = dr["FieldForceCode"].ToString();
			TheFieldForceChain.FieldForceName = dr["FieldForceName"].ToString();
			TheFieldForceChain.FieldForceRankID = int.Parse(dr["FieldForceRankID"].ToString());
			TheFieldForceChain.FieldForceRankName = dr["FieldForceRankName"].ToString();
			TheFieldForceChain.FieldForceRankDescription = dr["FieldForceRankDescription"].ToString();
			TheFieldForceChain.ReportingToFieldForceID = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["ReportingToFieldForceID"].ToString()));
			if(TheFieldForceChain.ReportingToFieldForceID > 0)
			{
				TheFieldForceChain.ReportingToFieldForceCode = dr["ReportingToFieldForceCode"].ToString();
				TheFieldForceChain.ReportingToFieldForceName = dr["ReportingToFieldForceName"].ToString();
				TheFieldForceChain.ReportingToRankID = int.Parse(dr["ReportingToRankID"].ToString());
				TheFieldForceChain.ReportingToRankName = dr["ReportingToRankName"].ToString();
				TheFieldForceChain.ReportingToRankDescription = dr["ReportingToRankDescription"].ToString();
			}
			TheFieldForceChain.ChainCode = dr["ChainCode"].ToString();
			TheFieldForceChain.OfficeID = int.Parse(dr["OfficeID"].ToString());
			TheFieldForceChain.OfficeName = dr["OfficeName"].ToString();
			TheFieldForceChain.EffectiveDateFrom = DateTime.Parse(dr["EffectiveDateFrom"].ToString()).ToString(MicroConstants.DateFormat);
			if(!string.IsNullOrEmpty(dr["EffectiveDateTo"].ToString()))
			{
				TheFieldForceChain.EffectiveDateTo = DateTime.Parse(dr["EffectiveDateTo"].ToString()).ToString(MicroConstants.DateFormat);
			}

			return TheFieldForceChain;
		}

		public static List<FieldForceChain> GetFieldForceChain(int fieldForceID)
		{
			List<FieldForceChain> FieldForceChainList = new List<FieldForceChain>();

			DataTable FieldForceChainTable = new DataTable();
			FieldForceChainTable = FieldForceChainDataAccess.GetInstance.GetFieldForceChain(fieldForceID);

			foreach(DataRow dr in FieldForceChainTable.Rows)
			{
				FieldForceChain TheFieldForceChain = DataRowToObject(dr);

				FieldForceChainList.Add(TheFieldForceChain);
			}

			return FieldForceChainList;
		}

		public static List<FieldForceChain> GetFieldForceChainsByFieldForceID(int fieldForceId)
		{
			List<FieldForceChain> FieldForceChainList = new List<FieldForceChain>();

			DataTable FieldForceChainTable = new DataTable();
			FieldForceChainTable = FieldForceChainDataAccess.GetInstance.GetFieldForceChainsByFieldForceID(fieldForceId);

			foreach (DataRow dr in FieldForceChainTable.Rows)
			{
				FieldForceChain TheFieldForceChain = DataRowToObject(dr);

				FieldForceChainList.Add(TheFieldForceChain);
			}

			return FieldForceChainList;
		}

		public static int InsertFieldForceChain(FieldForce theFieldForce)
		{
			return FieldForceChainDataAccess.GetInstance.InsertFieldForceChain(theFieldForce);
		}

		public static int UpdateFieldForceChain(FieldForce theFieldForce)
		{
			return FieldForceChainDataAccess.GetInstance.UpdateFieldForceChain(theFieldForce);
		}
		#endregion
	}
}
