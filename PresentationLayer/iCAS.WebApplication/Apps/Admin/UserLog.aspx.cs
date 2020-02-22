using System;
using Micro.Commons;
using System.Configuration;

namespace Micro.WebApplication.MicroERP.ADMIN
{

    /// <summary>
    /// Manages user Log
    /// </summary>
	public partial class UserLog : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
		{
            //SetConnection();
        
		}

        private void SetConnection()
        {

            Connection.ConnectionKeyName = ConfigurationManager.AppSettings["DefaultDatabaseEnviroment"].ToString();
            Connection.ConnectionKeyValue = ConfigurationManager.ConnectionStrings[Connection.ConnectionKeyName].ToString();
            Connection.ConnectionString = Micro.Commons.MicroSecurity.Decrypt(Connection.ConnectionKeyValue);

            // Uncomment below code to user the Select Database control 
            //Connection.ConnectionKeyName = ctrl_SelectDatabase.ConnectionName;
            //Connection.ConnectionKeyValue = ctrl_SelectDatabase.ConnectionValue;
        }

        
	}
}