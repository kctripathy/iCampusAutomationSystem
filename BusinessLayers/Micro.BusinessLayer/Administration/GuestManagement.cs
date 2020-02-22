using System.Collections.Generic;
using Micro.Objects.Administration;
using Micro.IntegrationLayer.Administration;

namespace Micro.BusinessLayer.Administration
{
    public partial class GuestManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static GuestManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static GuestManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new GuestManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion.

        #region Declaration

        public string DefaultColumn = "GuestName,Address_Present_TownOrCity,Address_Present_Landmark,Address_Present_PinCode,Address_Present_DistrictName,Address_Present_StateName,MobileNumber,OfficialEMailID,PersonalEMailID ";
        public string DisplayMember = "GuestName";
        public string ValueMember = "GuestID";
        #endregion

        #region Methods & Implementation

        public List<Guest> GetGuestList()
        {
            return GuestIntegration.GetGuestList();
        }

        public Guest GetGuestByID(int GuestID)
        {
            return GuestIntegration.GetGuestByID(GuestID);
        }

        public Guest GetGuestByCode(string GuestCode)
        {
            return GuestIntegration.GetGuestByCode(GuestCode);
        }
        public int InsertGuest(Guest theGuest)
        {
            return GuestIntegration.InsertGuest(theGuest);
        }

		public int InsertLoginGuest(Guest theGuest,int CompnanyID)
		{
			return GuestIntegration.InsertLoginGuest(theGuest, CompnanyID);
		}

        public int UpdateGuest(Guest theGuest)
        {
            return GuestIntegration.UpdateGuest(theGuest);
        }

        public int DeleteGuest(Guest theGuest)
        {
            return GuestIntegration.DeleteGuest(theGuest);
        }
        #endregion
    }
}
