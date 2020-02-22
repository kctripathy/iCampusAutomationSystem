using System.Collections.Generic;
using System.Data;
using System.Linq;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
	public partial class FieldForceRankIntegration
	{
		#region Methods & Implementation
		public static FieldForceRank DataRowToObject(DataRow dr)
		{
			FieldForceRank TheFieldForceRank = new FieldForceRank();

			TheFieldForceRank.FieldForceRankID = int.Parse(dr["FieldForceRankID"].ToString());
			TheFieldForceRank.FieldForceRankName = dr["FieldForceRankName"].ToString();
			TheFieldForceRank.FieldForceRankDescription = dr["FieldForceRankDescription"].ToString();
			TheFieldForceRank.HierarchyIndex= int.Parse(dr["HierarchyIndex"].ToString());
			TheFieldForceRank.FieldForceAbbrText=dr["FieldForceAbbrText"].ToString();
			TheFieldForceRank.NumberOfDigitsInCode=int.Parse(dr["NumberOfDigitsInCode"].ToString());
			TheFieldForceRank.IsActive=bool.Parse(dr["IsActive"].ToString());
			TheFieldForceRank.IsDeleted=bool.Parse(dr["IsDeleted"].ToString());

			return TheFieldForceRank;
		}

		public static List<FieldForceRank> GetFieldForceRanks(int fieldForceRankID = 0)
		{
			List<FieldForceRank> FieldForceRankList = new List<FieldForceRank>();

			DataTable FieldForceTable = new DataTable();
			FieldForceTable = FieldForceRankDataAccess.GetInstance.GetFieldForceRanks(fieldForceRankID);

			foreach(DataRow dr in FieldForceTable.Rows)
			{
				FieldForceRank TheFieldForceRank = DataRowToObject(dr);

				FieldForceRankList.Add(TheFieldForceRank);
			}

			return FieldForceRankList;
		}

		public static FieldForceRank GetFieldForceRankByID(int fieldForceRankID)
		{
			FieldForceRank TheFieldForceRank = new FieldForceRank();

			var FieldForceRankList = from FieldForceRankTable in GetFieldForceRanks()
									 where FieldForceRankTable.FieldForceRankID== fieldForceRankID
									 select FieldForceRankTable;

			foreach(FieldForceRank EachRank in FieldForceRankList)
			{
				TheFieldForceRank = EachRank;
			}

			return TheFieldForceRank;
		}
		#endregion
	}
}
