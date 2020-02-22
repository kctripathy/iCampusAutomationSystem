using System.Data;
using System.Data.SqlClient;

namespace Micro.DataAccessLayer.CustomerRelation
{
   public partial  class BranchAbstractDataAccess:AbstractData_SQLClient
   {
       #region Declaration
       #endregion

       #region Code to make this as Singleton Class
       /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static BranchAbstractDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
       public static BranchAbstractDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BranchAbstractDataAccess();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

       #region Methods & Implementation

       public DataTable BranchAbstractList(string DateOfTransaction)
       {
           using (SqlCommand SelectCommand = new SqlCommand())
           {
               SelectCommand.Parameters.Add(GetParameter("@DateOfTransaction", SqlDbType.VarChar, DateOfTransaction));
               SelectCommand.CommandText = "pCRM_BranchAbstracts";

               return ExecuteGetDataTable(SelectCommand);
           }
       }
       #endregion
   }
}
