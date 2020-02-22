using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
	public partial class FieldForceChainManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static FieldForceChainManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static FieldForceChainManagement GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new FieldForceChainManagement();
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
        public string DefaultColumns = "FieldForceCode, FieldForceName, FieldForceRankName, FieldForceRankDescription, ReportingToFieldForceName, ReportingToRankName";
        public string DisplayMember = "FieldForceName";
        public string ValueMember = "FieldForceChainID";
        #endregion

        #region Methods & Implementation
        public List<FieldForceChain> GetFieldForceChain(int fieldForceID)
		{
			return FieldForceChainIntegration.GetFieldForceChain(fieldForceID);
		}

		public List<FieldForceChain> GetFieldForceChainsByFieldForceID(int fieldForceId)
		{
			return FieldForceChainIntegration.GetFieldForceChainsByFieldForceID(fieldForceId);
		}

		public int InsertFieldForceChain(FieldForce theFieldForce)
		{
			return FieldForceChainIntegration.InsertFieldForceChain(theFieldForce);
		}

		public int UpdateFieldForceChain(FieldForce theFieldForce)
		{
			return FieldForceChainIntegration.UpdateFieldForceChain(theFieldForce);
		}
		#endregion
	}
}
