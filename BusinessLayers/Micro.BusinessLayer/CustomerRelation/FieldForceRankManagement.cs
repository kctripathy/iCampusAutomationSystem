using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
	public partial class FieldForceRankManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static FieldForceRankManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static FieldForceRankManagement GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new FieldForceRankManagement();
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
        public string DefaultColumns = "FieldForceRankName, FieldForceRankDescription";
        public string DisplayMember = "FieldForceRankName";
        public string ValueMember = "FieldForceRankID";
        #endregion

        #region Methods & Implementation
        /// <summary>
		/// Returns Field Force Ranks.
		/// </summary>
		/// <param name="fieldForceRankID">If 0 returns all ranks else returns only those ranks whose HierarchyIndex is higher to the given FieldForceRankID</param>
		/// <returns></returns>
		public List<FieldForceRank> GetFieldForceRanks(int fieldForceRankID = 0)
		{
			return FieldForceRankIntegration.GetFieldForceRanks(fieldForceRankID);
		}

		public FieldForceRank GetFieldForceRankByID(int fieldForceRankID)
		{
			return FieldForceRankIntegration.GetFieldForceRankByID(fieldForceRankID);
		}
		#endregion
	}
}
