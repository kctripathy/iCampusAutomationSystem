using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Framework.ActiveDirectory
{
    [Serializable]
    public class ActiveDiretoryUser
    {
        private string _UserLastName;
        private string _UserFirstName;
        private string _UserEmail;
        private string _UserLogin;

        #region Properties
        public string UserLastName
        {
            get
            {
                return _UserLastName;
            }
            set
            {
                _UserLastName = value;
            }
        }

        public string UserFirstName
        {
            get
            {
                return _UserFirstName;
            }
            set
            {
                _UserFirstName = value;
            }
        }

        public string UserEmail
        {
            get
            {
                return _UserEmail;
            }
            set
            {
                _UserEmail = value;
            }
        }

        public string UserLogin
        {
            get
            {
                return _UserLogin;
            }
            set
            {
                _UserLogin = value;
            }
        }

        public string UserDomain
        {
            get;
            set;
        }

        public string UserFullLogin
        {
            get
            {
                return UserDomain + "\\" + UserLogin;
            }
            set
            {
            }
        }
        #endregion

        #region Contructors
        public ActiveDiretoryUser()
        {
        }

        public ActiveDiretoryUser(string userLastName, string userFirstName, string userEmail, string userLogin)
        {
            this.UserLastName = userLastName;
            this.UserFirstName = userFirstName;
            this.UserEmail = userEmail;
            this.UserLogin = userLogin;
        }

        public ActiveDiretoryUser(string userLastName, string userFirstName, string userEmail, string userLogin, string userDomain)
        {
            this.UserLastName = userLastName;
            this.UserFirstName = userFirstName;
            this.UserEmail = userEmail;
            this.UserLogin = userLogin;
            this.UserDomain = userDomain;
        }
        #endregion
    }

}
