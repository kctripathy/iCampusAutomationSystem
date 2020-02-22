using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

#region MicroNamespaces

#endregion

namespace Micro.DataAccessLayer.Administration
{
   public partial class WebFormDataAccess:AbstractData_SQLClient
   {
       #region Code to make this class as Singleton Class
       /// <summary>
       /// Private static member to implement Singleton Desing Pattern
       /// </summary>
       private static WebFormDataAccess instance = new WebFormDataAccess();
       // <summary>
       /// Static property of the class which will provide the singleton instance of it
       /// </summary>
       public static WebFormDataAccess GetInstance

       {
           get
           {
              return instance;
           }
       }
       #endregion

       #region Declaration
       #endregion

       #region Transaction Methods(Insert,Update,Delete)

       #endregion

       #region Methods & Implementation
       public DataTable GetWebFormsAll()
       {
           try
           {
               SqlCommand SelectCommand = new SqlCommand();
               SelectCommand.CommandType = CommandType.StoredProcedure;
               SelectCommand.CommandText = "pADM_WebForms_SelectAll";
               return ExecuteGetDataTable(SelectCommand);
           }
           catch(Exception ex)
           {
               throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
           }
       }
       #endregion
   }
}
