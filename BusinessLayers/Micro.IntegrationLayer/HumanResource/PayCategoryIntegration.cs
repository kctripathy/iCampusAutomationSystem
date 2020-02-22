#region System Namespace

using System.Collections.Generic;
using System.Data;

#endregion

#region Micro Namespaces

using Micro.DataAccessLayer.HumanResource;
using Micro.Objects.HumanResource;

#endregion

namespace Micro.IntegrationLayer.HumanResource
{
    public partial class PayCategoryIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertPayCategory(PayCategory thePayCategory)
        {
            return PayCategoryDataAccess.GetInstance.InsertPayCategory(thePayCategory);
        }

        public static int UpdatePayCategory(PayCategory thePayCategory)
        {
            return PayCategoryDataAccess.GetInstance.UpdatePayCategory(thePayCategory);
        }

        public static int DeletePayCategory(PayCategory thePayCategory)
        {
            return PayCategoryDataAccess.GetInstance.DeletePayCategory(thePayCategory);
        }

        #endregion

        #region Data Retrive Mathods

        public static PayCategory GetPayCategoryById(int recordId)
        {
            DataRow PayCategoryRow = PayCategoryDataAccess.GetInstance.GetPayCategoryById(recordId);

            PayCategory ThePayCategory = new PayCategory();

            ThePayCategory.PayCategoryID = int.Parse(PayCategoryRow["PayCategoryID"].ToString());
            ThePayCategory.PayCategoryDescription = PayCategoryRow["PayCategoryDescription"].ToString();
            ThePayCategory.IsActive = bool.Parse(PayCategoryRow["IsActive"].ToString());

            return ThePayCategory;
        }

        public static List<PayCategory> GetPayCategories(string searchText)
        {
            List<PayCategory> PayCategoryList = new List<PayCategory>();

            DataTable PayCategoryTable = new DataTable();
            PayCategoryTable = PayCategoryDataAccess.GetInstance.GetPayCategories(searchText);

            foreach (DataRow dr in PayCategoryTable.Rows)
            {
                PayCategory ThePayCategory = new PayCategory();

                ThePayCategory.PayCategoryID = int.Parse(dr["PayCategoryID"].ToString());
                ThePayCategory.PayCategoryDescription = dr["PayCategoryDescription"].ToString();

                PayCategoryList.Add(ThePayCategory);
            }

            return PayCategoryList;
        }

        #endregion
    }
}
