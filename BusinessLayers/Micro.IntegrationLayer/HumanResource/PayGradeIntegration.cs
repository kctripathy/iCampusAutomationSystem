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
    public partial class PayGradeIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertPayGrade(PayGrade thePayGrade)
        {
            return PayGradeDataAccess.GetInstance.InsertPayGrade(thePayGrade);
        }

        public static int UpdatePayGrade(PayGrade thePayGrade)
        {
            return PayGradeDataAccess.GetInstance.UpdatePayGrade(thePayGrade);
        }

        public static int DeletePayGrade(PayGrade thePayGrade)
        {
            return PayGradeDataAccess.GetInstance.DeletePayGrade(thePayGrade);
        }

        #endregion

        #region Data Retrive Mathods

        public static List<PayGrade> GetPayGrades(string searchText)
        {
            List<PayGrade> PayGradeList = new List<PayGrade>();

            DataTable PayGradeTable = new DataTable();
            PayGradeTable = PayGradeDataAccess.GetInstance.GetPayGrade(searchText);

            foreach (DataRow dr in PayGradeTable.Rows)
            {
                PayGrade ThePayGrade = new PayGrade();

                ThePayGrade.PayGradeID = int.Parse(dr["PayGradeID"].ToString());
                ThePayGrade.PayGradeDescription = dr["PayGradeDescription"].ToString();

                PayGradeList.Add(ThePayGrade);
            }

            return PayGradeList;
        }

        public static PayGrade GetPayGrdaeById(int recordId)
        {
            DataRow PayGradeRow = PayGradeDataAccess.GetInstance.GetPayGradeById(recordId);

            PayGrade ThePayGrade = new PayGrade();

            ThePayGrade.PayGradeID = int.Parse(PayGradeRow["PayGradeID"].ToString());
            ThePayGrade.PayGradeDescription = PayGradeRow["PayGradeDescription"].ToString();
            ThePayGrade.IsActive = bool.Parse(PayGradeRow["IsActive"].ToString());

            return ThePayGrade;
        }

        #endregion
    }
}
