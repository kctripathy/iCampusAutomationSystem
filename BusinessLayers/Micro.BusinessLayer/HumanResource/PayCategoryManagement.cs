using System.Collections.Generic;
using Micro.IntegrationLayer.HumanResource;
using Micro.Objects.HumanResource;

namespace Micro.BusinessLayer.HumanResource
{
	public partial class PayCategoryManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static PayCategoryManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static PayCategoryManagement GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new PayCategoryManagement();
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
		#endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public int InsertPayCategory(PayCategory thePayCategory)
		{
			return PayCategoryIntegration.InsertPayCategory(thePayCategory);
		}

		public int UpdatePayCategory(PayCategory thePayCategory)
		{
			return PayCategoryIntegration.UpdatePayCategory(thePayCategory);
		}

		public int DeletePayCategory(PayCategory thePayCategory)
		{
			return PayCategoryIntegration.DeletePayCategory(thePayCategory);
		}

        #endregion
        
        #region Data Retrive Mathods

        public List<PayCategory> GetPayCategories(string searchText)
        {
            return PayCategoryIntegration.GetPayCategories(searchText);
        }

		public PayCategory GetPayCategoryById(int recordId)
		{
			return PayCategoryIntegration.GetPayCategoryById(recordId);
		}

		#endregion

        #region Data Fill Mathods( Fill Data Into DevxDataGrid,DevxLookupEdit)
        #endregion
    }
}
