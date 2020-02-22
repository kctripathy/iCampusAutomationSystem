using System;

namespace Micro.Objects.ICAS.ADMIN
{
	[Serializable]
	public class User
	{
		public object UserId;

		public int RoleId;

		public int UserID
		{
			get;
			set;
		}

		public string UserName
		{
			get;
			set;
		}

		public string Password
		{
			get;
			set;
		}

		public int RoleID
		{
			get;
			set;
		}

		public string RoleDescription
		{
			get;
			set;
		}

		public string UserType
		{
			get;
			set;
		}

		public int UserReferenceID
		{
			get;
			set;
		}

		public string UserReferenceName
		{
			get;
			set;
		}


        public string UserFirstName
        {
            get
            {
                string[] arrName;
                string firstName;

                if (this.UserReferenceName.Contains(" ") == true)
                {
                    arrName = this.UserReferenceName.ToString().Split(' ');
                    firstName = string.Format("{0} {1}",arrName[0], arrName[1]);
                }
                else
                {
                    firstName = this.UserName;
                }
                return firstName;
            }
        }

		public string EmailAddress
		{
			get;
			set;
		}

		public int OfficeID
		{
			get;
			set;
		}

		public string OfficeCode
		{
			get;
			set;
		}

		public string OfficeName
		{
			get;
			set;
		}

		public int CompanyID
		{
			get;
			set;
		}

		public string CompanyCode
		{
			get;
			set;
		}

		public string CompanyName
		{
			get;
			set;
		}

		public string CompanyAliasName
		{
			get;
			set;
		}

		public bool CanAccessAllOffices
		{
			get;
			set;
		}

		public int OfficeGroupTemplateID
		{
			get;
			set;
		}

		public string OfficeGroupTemplateName
		{
			get;
			set;
		}

		public string EffectiveDateFrom
		{
			get;
			set;
		}

		public string EffectiveDateTo
		{
			get;
			set;
		}

		public string SecretQuestion
		{
			get;
			set;
		}

		public string SecretQuestionAnswer
		{
			get;
			set;
		}

		public string LoginDateTime
		{
			get;
			set;
		}

        public string ImageUrl_Smallest
        {
            get;
            set;
        }

        public string UserPhoto_SmallSize
        {
            get;
            set;
        }

        public string UserPhoto_MediumSize
        {
            get;
            set;
        }

        public string UserPhoto_BigSize
        {
            get;
            set;
        }
		
	}

	[Serializable]
	public class UserLog
	{
		public int LogID
		{
			get;
			set;
		}

		public int UserID
		{
			get;
			set;
		}

		public int OfficeID
		{
			get;
			set;
		}

		public string ClientComputerName
		{
			get;
			set;
		}

		public string LoggedOnFromSystemIP
		{
			get;
			set;
		}

		public DateTime LoggedOnDateTime
		{
			get;
			set;
		}

		public DateTime LoggedOutDateTime
		{
			get;
			set;
		}

		public string SessionID
		{
			get;
			set;
		}
	}

	//[Serializable]
	//public class UserSetting
	//{
	//    public int UserSettingID
	//    {
	//        get;
	//        set;
	//    }
	//    public int UserID
	//    {
	//        get;
	//        set;
	//    }

	//    public int KeyID
	//    {
	//        get;
	//        set;
	//    }
	//    public string KeyName
	//    {
	//        get;
	//        set;
	//    }
	//    public string KeyValue
	//    {
	//        get;
	//        set;
	//    }
	//}
}
