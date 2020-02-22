using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
	public partial class BrokerageFeeStructureManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static BrokerageFeeStructureManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static BrokerageFeeStructureManagement GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new BrokerageFeeStructureManagement();
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
        public string DefaultColumn = "BrokerageType,  DatabaseTableName, StoredProcedureName";
        public string DisplayMember = "BrokerageType";
        public string ValueMember = "BrokerageFeeStructureID";
		#endregion

		#region Methods & Implemetations
        public List<BrokerageFeeStructure> GetBrokerageFeeStructureList(bool allOffices = false, bool showDeleted = false)
		{
            return BrokerageFeeStructureIntegration.GetBrokerageFeeStructureList(allOffices,showDeleted);
		}

        public BrokerageFeeStructure GetBrokerageFeeStructuresById(int BrokerageFeeStructureID)
		{
            return BrokerageFeeStructureIntegration.GetBrokerageFeeStructuresById(BrokerageFeeStructureID);
		}

		public int InsertBrokerageFeeStructure(BrokerageFeeStructure theBrokerageFeeStructureList)
		{
			return BrokerageFeeStructureIntegration.InsertBrokerageFeeStructure(theBrokerageFeeStructureList);
		}

		public int UpdateBrokerageFeeStructure(BrokerageFeeStructure theBrokerageFeeStructureList)
		{
            return BrokerageFeeStructureIntegration.UpdateBrokerageFeeStructure(theBrokerageFeeStructureList);
		}

		public int DeleteBrokerageFeeStructure(BrokerageFeeStructure theBrokerageFeeStructure)
		{
			return BrokerageFeeStructureIntegration.DeleteBrokerageFeeStructure(theBrokerageFeeStructure);
		}
		#endregion
	}
}


