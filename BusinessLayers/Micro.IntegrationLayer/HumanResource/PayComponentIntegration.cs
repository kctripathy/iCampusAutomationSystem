#region System Namespace

using System.Collections.Generic;
using System.Data;

#endregion

#region Micro Namespaces

using Micro.Objects.HumanResource;
using Micro.DataAccessLayer.HumanResource;

#endregion

namespace Micro.IntegrationLayer.HumanResource
{
    public partial class PayComponentIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertPayComponent(PayComponent thePayComponent)
        {
            return PayComponentDataAccess.GetInstance.InsertPayComponent(thePayComponent);
        }

        public static int UpdatePayComponent(PayComponent thePayComponent)
        {
            return PayComponentDataAccess.GetInstance.UpdatePayCompenent(thePayComponent);
        }

        public static int DeletePayComponent(PayComponent thePayComponent)
        {
            return PayComponentDataAccess.GetInstance.DeletePayCompenent(thePayComponent);
        }

        #endregion

        #region Data Retrive Mathods

        public static List<PayComponent> GetPayComponents(string searchText)
        {
            List<PayComponent> PayComponentList = new List<PayComponent>();

            DataTable PayComponentTable = new DataTable();
            PayComponentTable = PayComponentDataAccess.GetInstance.GetPayComponents(searchText);

            foreach (DataRow dr in PayComponentTable.Rows)
            {
                PayComponent ThePayComponent = new PayComponent();

                ThePayComponent.PayComponentID = int.Parse(dr["PayComponentID"].ToString());
                ThePayComponent.PayComponentDescription = dr["PayComponentDescription"].ToString();
                ThePayComponent.PayComponentType = dr["PayComponentType"].ToString();
                ThePayComponent.DisplayOrder = int.Parse(dr["DisplayOrder"].ToString());

                PayComponentList.Add(ThePayComponent);
            }

            return PayComponentList;
        }

        public static PayComponent GetPayComponentById(int recordId)
        {
            DataRow PayComponentRow = PayComponentDataAccess.GetInstance.GetPayComponentById(recordId);

            PayComponent ThePayComponent = new PayComponent();

            ThePayComponent.PayComponentID = int.Parse(PayComponentRow["PayComponentID"].ToString());
            ThePayComponent.PayComponentDescription = PayComponentRow["PayComponentDescription"].ToString();
            ThePayComponent.PayComponentType = PayComponentRow["PayComponentType"].ToString();
            ThePayComponent.DisplayOrder = int.Parse(PayComponentRow["DisplayOrder"].ToString());

            ThePayComponent.IsActive = bool.Parse(PayComponentRow["IsActive"].ToString());

            return ThePayComponent;
        }

        #endregion
    }
}
