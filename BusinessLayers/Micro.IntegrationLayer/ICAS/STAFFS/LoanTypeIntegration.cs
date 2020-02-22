using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STAFFS;
using System.Data;
using Micro.DataAccessLayer.ICAS.STAFFS;

namespace Micro.IntegrationLayer.ICAS.STAFFS
{
  public partial  class LoanTypeIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation

        public static LoanType DataRowToObject(DataRow dr)
        {
            LoanType TheLoanType = new LoanType();
            TheLoanType.LoanID = int.Parse(dr["LoanID"].ToString());
            TheLoanType.LoanTypeDescriptions = dr["LoanTypeDescriptions"].ToString();


            return TheLoanType;
        }

        public static List<LoanType> GetLoanTypeList(bool allOffices = false, bool showDeleted = false)
        {
            List<LoanType> LoanTypeList = new List<LoanType>();
            DataTable LoanTypeTable = LoanTypeDataAccess.GetInstance.GetLoanTypeList(allOffices,showDeleted);

            foreach (DataRow dr in LoanTypeTable.Rows)
            {
                LoanType TheLoanType = DataRowToObject(dr);

                LoanTypeList.Add(TheLoanType);
            }

            return LoanTypeList;
        }

        #endregion
    
    }
}
