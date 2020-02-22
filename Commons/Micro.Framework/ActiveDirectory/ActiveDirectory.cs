using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;

namespace Micro.Framework.ActiveDirectory
{
    public static class ActiveDirectory
    {
        /// <summary>
        /// Returns a list of ActiveDiretoryUser within the current domain name
        /// where user name like userName
        /// </summary>
        /// <param name="userName">Complete user name</param>
        /// <returns>List of ActiveDiretoryUser</returns>
        public static List<ActiveDiretoryUser> SearchActiveDirectoryUser(string userName)
        {
            List<ActiveDiretoryUser> UserList = new List<ActiveDiretoryUser>();
            ActiveDiretoryUser User;
            DirectoryEntry AdDirecEntry;
            DirectorySearcher AdDirecSearch;
            SearchResultCollection Results;

            try
            {
                // Get the current domain
                DirectoryEntry EntryRoot = new DirectoryEntry("GC://RootDSE");
                string Domain = "DC=cma-cgm,DC=com";

                // Connecting to the domain
                AdDirecEntry = new DirectoryEntry("GC://" + Domain);

                // Creating search
                AdDirecSearch = new DirectorySearcher(AdDirecEntry);

                // Set the search scope
                AdDirecSearch.SearchScope = SearchScope.Subtree;

                AdDirecSearch.Filter = "(&(objectClass=User)(name=" + userName + "*))";

                // Get all users
                Results = AdDirecSearch.FindAll();

                if (Results != null)
                {
                    foreach (SearchResult ResultDetail in Results)
                    {
                        User = new ActiveDiretoryUser();

                        User.UserEmail = GetPropertyValue(ResultDetail.Properties["mail"]);
                        User.UserLogin = GetPropertyValue(ResultDetail.Properties["samaccountname"]);
                        User.UserLastName = GetPropertyValue(ResultDetail.Properties["sn"]);
                        User.UserFirstName = GetPropertyValue(ResultDetail.Properties["givenName"]);

                        string domain = GetPropertyValue(ResultDetail.Properties["DistinguishedName"]);
                        string[] domaineProperties = domain.Split(',');
                        for (int i = 0; i < domaineProperties.GetUpperBound(0); i++)
                        {
                            if (domaineProperties[i].Contains("DC="))
                            {
                                User.UserDomain = domaineProperties[i].Substring(3);
                                break;
                            }
                        }

                        UserList.Add(User);
                    }
                }
            }
            catch
            {
                UserList = null;
            }

            return UserList;
        }

        /// <summary>
        /// Returns a list of ActiveDiretoryUser within the current domain name
        /// where user name like userName
        /// </summary>
        /// <param name="userName">Complete user name</param>
        /// <returns>List of ActiveDiretoryUser</returns>
        public static List<ActiveDiretoryUser> SearchActiveDirectoryByUserLogin(string userFullLogin)
        {
            List<ActiveDiretoryUser> UserList = new List<ActiveDiretoryUser>();
            ActiveDiretoryUser User;
            DirectoryEntry AdDirecEntry;
            DirectorySearcher AdDirecSearch;
            SearchResultCollection Results;

            try
            {
                // Get the current domain
                DirectoryEntry EntryRoot = new DirectoryEntry("GC://RootDSE");
                string Domain = "DC=MLFL,DC=com";

                // Connecting to the domain
                AdDirecEntry = new DirectoryEntry("GC://" + Domain);

                // Creating search
                AdDirecSearch = new DirectorySearcher(AdDirecEntry);

                // Set the search scope
                AdDirecSearch.SearchScope = SearchScope.Subtree;

                AdDirecSearch.Filter = "(&(objectClass=User)(samaccountname=" + userFullLogin.Substring((userFullLogin.IndexOf(@"\") + 1), ((userFullLogin.Length - (userFullLogin.IndexOf(@"\") + 1)))) + "))";

                // Get all users
                Results = AdDirecSearch.FindAll();

                if (Results != null)
                {
                    foreach (SearchResult ResultDetail in Results)
                    {
                        User = new ActiveDiretoryUser();

                        User.UserEmail = GetPropertyValue(ResultDetail.Properties["mail"]);
                        User.UserLogin = GetPropertyValue(ResultDetail.Properties["samaccountname"]);
                        User.UserLastName = GetPropertyValue(ResultDetail.Properties["sn"]);
                        User.UserFirstName = GetPropertyValue(ResultDetail.Properties["givenName"]);

                        string domain = GetPropertyValue(ResultDetail.Properties["DistinguishedName"]);
                        string[] domaineProperties = domain.Split(',');
                        for (int i = 0; i < domaineProperties.GetUpperBound(0); i++)
                        {
                            if (domaineProperties[i].Contains("DC="))
                            {
                                User.UserDomain = domaineProperties[i].Substring(3);
                                break;
                            }
                        }

                        if (User.UserDomain == userFullLogin.Substring(0, userFullLogin.IndexOf(@"\")))
                        {
                            UserList.Add(User);
                        }
                    }
                }
            }
            catch
            {
                UserList = null;
            }

            return UserList;
        }



        /// <summary>
        /// Returns string of the first value of the ResultPropertyValueCollection collection
        /// </summary>
        /// <param name="value">ResultPropertyValueCollection where the value is stored</param>
        /// <returns>String of the first value of the collection</returns>
        private static string GetPropertyValue(ResultPropertyValueCollection value)
        {
            foreach (Object Properties in value)
            {
                return Properties.ToString();
            }

            return string.Empty;
        }
    }
}
