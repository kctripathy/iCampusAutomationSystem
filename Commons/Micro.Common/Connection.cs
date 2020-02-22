using Micro.Objects.Administration;
using System.Web;

namespace Micro.Commons
{
    public class Connection
    {

		private string _Key;
		public string Key
		{
			get { return _Key; }
			set
			{
				_Key = value;
			}
		}

		private string _Value;
		public string Value
		{
			get { return _Value; }
			set
			{
				_Value = value;
			}
		}

		// Gets or Sets the logged on user
		public static User LoggedOnUser
		{
			get 
			{
				User TheCurrentUser = HttpContext.Current.Session["CurrentUser"] as User;
				if (TheCurrentUser != null)
				{
					if (
						TheCurrentUser.RoleDescription.ToString().ToUpper().Equals("SUPER ADMIN") ||
						TheCurrentUser.RoleDescription.ToString().ToUpper().Equals("ADMINISTRATOR") ||
						TheCurrentUser.RoleDescription.ToString().ToUpper().Equals("UM") || TheCurrentUser.RoleDescription.ToString().ToUpper().Equals("UNIT MANAGER") ||
						TheCurrentUser.RoleDescription.ToString().ToUpper().Equals("MD") || TheCurrentUser.RoleDescription.ToString().ToUpper().Equals("MANAGING DIRECTOR") ||
						TheCurrentUser.RoleDescription.ToString().ToUpper().Equals("CEO") || TheCurrentUser.RoleDescription.ToString().ToUpper().Equals("CHIEF EXECUTIVE OFFICER") ||
                        TheCurrentUser.RoleDescription.ToString().ToUpper().Equals("CHAIRMAN") || TheCurrentUser.RoleDescription.ToString().ToUpper().Equals("SHIFT SUPERVISOR")
						)
					{
						TheCurrentUser.CanAccessAllOffices = true;
					}
				}
				return TheCurrentUser; 
				//return BasePage.CurrentLoggedOnUser.TheUser;
			}
			set
			{
				//BasePage.CurrentLoggedOnUser.TheUser = value;
				HttpContext.Current.Session.Add("CurrentUser", value);
			}
		}

        public static string OleDbConnectionString
        {
            get;
            set;
        }

		public static string ConnectionKeyName
        {
            get;
            set;
        }

		public static string ConnectionKeyValue
		{
			get;
			set;
		}

		public static string ConnectionString
		{
			get;
			set;
		}


        public static class ConnectionStringProperties
        {
            private static string _Server;
            private static string _Database;
            private static string _User;
            private static string _Password;

            /// <summary>
            /// Gets the Server name from Micro.Commons.ConnectionString
            /// </summary>
            public static string Server
            {
                get
                {
                    return _Server;
                }
            }

            /// <summary>
            /// Gets the Database name from Micro.Commons.ConnectionString
            /// </summary>
            public static string Database
            {
                get
                {
                    return _Database;
                }
            }

            /// <summary>
            /// Gets the User name from Micro.Commons.ConnectionString
            /// </summary>
            public static string User
            {
                get
                {
                    return _User;
                }
            }

            /// <summary>
            /// Gets the Password from Micro.Commons.ConnectionString
            /// </summary>
            public static string Password
            {
                get
                {
                    return _Password;
                }
            }

            public static void Get()
            {
                string[] ConnectionProperties = ConnectionString.Split(';');

                foreach (string ConnectionProperty in ConnectionProperties)
                {
                    string[] EachProperty = ConnectionProperty.Split('=');

                    switch (EachProperty[0].ToLower())
                    {
                        case "data source":
                        case "server":
                            _Server = EachProperty[1];
                            break;

                        case "initial catalog":
                        case "database":
                            _Database = EachProperty[1];
                            break;

                        case "user id":
                        case "uid":
                            _User = EachProperty[1];
                            break;

                        case "password":
                        case "pwd":
                            _Password = EachProperty[1];
                            break;

                        default:
                            break;
                    }
                }
            }
        }

    }

	public class TheCurrentUser
	{
		public User SignedInUser
		{
			get;
			set;
		}
	}
}