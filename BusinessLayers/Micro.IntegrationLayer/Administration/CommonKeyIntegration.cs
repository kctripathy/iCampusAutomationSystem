using System;
using System.Collections.Generic;
using System.Data;
using Micro.DataAccessLayer.Administration;
using Micro.Objects.Administration;

namespace Micro.IntegrationLayer.Administration
{
	public partial class CommonKeyIntegration
	{
		#region Methods and Implementation
		public static CommonKey DataRowToObject(DataRow dr)
		{
			CommonKey TheCommonKey;

			if(dr != null)
			{
				TheCommonKey = new CommonKey
				{
					CommonKeyID = (dr["CommonKeyID"] == null? 0 : int.Parse(dr["CommonKeyID"].ToString())),
					CommonKeyName = dr["CommonKeyName"].ToString(),
					CommonKeyValue =(dr["CommonKeyValue"] == null? string.Empty : dr["CommonKeyValue"].ToString()),
					IsActive = (dr["IsActive"] == null? false :Boolean.Parse(dr["IsActive"].ToString())),
					IsDeleted = (dr["IsActive"] == null? false :Boolean.Parse(dr["IsDeleted"].ToString()))
				};
			}
			else
				TheCommonKey = new CommonKey();

			return TheCommonKey;
		}

		public static CommonKey ConvertDataRowToObject(DataRow dr)
		{
			CommonKey TheCommonKey;

			if (dr != null)
			{
				TheCommonKey = new CommonKey
				{
					CommonKeyName = dr["CommonKeyName"].ToString()
				};
			}
			else
				TheCommonKey = new CommonKey();

			return TheCommonKey;
		}

		public static List<CommonKey> GetCommonKeyList(string searchText)
		{
			List<CommonKey> TheCommonKeyList = new List<CommonKey>();
			DataTable TheCommonKeyTable = CommonKeyDataAccess.GetInstance.GetCommonKeyList(searchText);

			foreach(DataRow dr in TheCommonKeyTable.Rows)
			{
				CommonKey TheCommonKey;
				if (searchText == "#DISTINCT#")
				{
					TheCommonKey = ConvertDataRowToObject(dr);
				}
				else
				{
					TheCommonKey = DataRowToObject(dr);
				}
				TheCommonKeyList.Add(TheCommonKey);
			}

			return TheCommonKeyList;
		}

		public static List<CommonKey> GetCommonKeyListByName(string commonKeyName)
		{
			List<CommonKey> TheCommonKeyList = new List<CommonKey>();
			DataTable TheCommonKeyTable = CommonKeyDataAccess.GetInstance.GetCommonKeyListByName(commonKeyName);

			foreach(DataRow dr in TheCommonKeyTable.Rows)
			{
				CommonKey TheCommonKey = DataRowToObject(dr);

				TheCommonKeyList.Add(TheCommonKey);
			}

			return TheCommonKeyList;
		}

		public static List<CommonKey> GetCommonKeyByName(string commonKeyName)
		{
			List<CommonKey> TheCommonKeyList = new List<CommonKey>();
			DataTable TheCommonKeyTable = CommonKeyDataAccess.GetInstance.GetCommonKeyByName(commonKeyName);

			foreach (DataRow dr in TheCommonKeyTable.Rows)
			{
				CommonKey TheCommonKey = DataRowToObject(dr);

				TheCommonKeyList.Add(TheCommonKey);
			}

			return TheCommonKeyList;
		}

		public static CommonKey GetCommonKeyByID(int commonKeyID)
		{
			DataRow TheCommonKeyRow = CommonKeyDataAccess.GetInstance.GetCommonKeyByID(commonKeyID);
			CommonKey TheCommonKey = DataRowToObject(TheCommonKeyRow);

			return TheCommonKey;
		}

		public static int InsertCommonKey(CommonKey theCommonKey)
		{
			return CommonKeyDataAccess.GetInstance.InsertCommonKey(theCommonKey);
		}

		public static int UpdateCommonKey(CommonKey theCommonKey)
		{
			return CommonKeyDataAccess.GetInstance.UpdateCommonKey(theCommonKey);
		}

		public static int DeleteCommonKey(CommonKey theCommonKey)
		{
			return CommonKeyDataAccess.GetInstance.DeleteCommonKey(theCommonKey);
		}
		#endregion
	}
}
