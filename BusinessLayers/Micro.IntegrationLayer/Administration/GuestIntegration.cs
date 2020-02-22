using System;
using System.Collections.Generic;
using Micro.Objects.Administration;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.Administration;

namespace Micro.IntegrationLayer.Administration
{
    public partial class GuestIntegration
    {
        #region Methods & Implementation

        public static Guest DataRowToObject(DataRow dr)
        {
            Guest TheGuest = new Guest();

            TheGuest.GuestID = int.Parse(dr["GuestID"].ToString());
            TheGuest.GuestCode = dr["GuestCode"].ToString();
            TheGuest.Salutation = dr["Salutation"].ToString();
            TheGuest.GuestName = dr["GuestName"].ToString();
            TheGuest.Age = int.Parse(dr["Age"].ToString());
            TheGuest.Gender = dr["Gender"].ToString();
            TheGuest.Address_Present_TownOrCity = dr["Address_Present_TownOrCity"].ToString();
            TheGuest.Address_Present_Landmark = dr["Address_Present_Landmark"].ToString();
            TheGuest.Address_Present_PinCode = dr["Address_Present_PinCode"].ToString();
            TheGuest.Address_Present_DistrictID = int.Parse(dr["Address_Present_DistrictID"].ToString());
            TheGuest.Address_Present_DistrictName = dr["Address_Present_DistrictName"].ToString();
            TheGuest.Address_Present_StateName = dr["Address_Present_StateName"].ToString();
            TheGuest.Address_Present_CountryName = dr["Address_Present_CountryName"].ToString();
            TheGuest.PhoneNumber = dr["PhoneNumber"].ToString();
            TheGuest.MobileNumber = dr["MobileNumber"].ToString();
            TheGuest.OfficialEMailID = dr["OfficialEMailID"].ToString();
            TheGuest.PersonalEMailID = dr["PersonalEMailID"].ToString();
            TheGuest.EffectiveDateFrom = DateTime.Parse(dr["EffectiveDateFrom"].ToString()).ToString(MicroConstants.DateFormat);
            if (!string.IsNullOrEmpty(dr["EffectiveDateTo"].ToString()))
            {
                TheGuest.EffectiveDateTo = DateTime.Parse(dr["EffectiveDateTo"].ToString()).ToString(MicroConstants.DateFormat);
            }
            TheGuest.OfficeID = int.Parse(dr["OfficeID"].ToString());
            TheGuest.OfficeName = dr["OfficeName"].ToString();
            TheGuest.Remarks = dr["Remarks"].ToString();

            return TheGuest;
        }

        public static List<Guest> GetGuestList()
        {
            List<Guest> GuestList = new List<Guest>();
            DataTable GuestTable = GuestDataAccess.GetInstance.GetGuestList();

            foreach (DataRow dr in GuestTable.Rows)
            {
                Guest TheGuest = DataRowToObject(dr);
                GuestList.Add(TheGuest);
            }
            return GuestList;
        }

        public static Guest GetGuestByID(int GuestID)
        {
            DataRow TheGuestRow = GuestDataAccess.GetInstance.GetGuestByID(GuestID);

            Guest TheGuest = DataRowToObject(TheGuestRow);

            return TheGuest;
        }

        public static Guest GetGuestByCode(string GuestCode)
        {
            Guest TheGuest;
            DataRow TheGuestRow = GuestDataAccess.GetInstance.GetGuestByCode(GuestCode);

            if (TheGuestRow != null)
                TheGuest = DataRowToObject(TheGuestRow);
            else
                TheGuest = new Guest();
            return TheGuest;
        }

        public static int InsertGuest(Guest theGuest)
        {
            return GuestDataAccess.GetInstance.InsertGuest(theGuest);
        }

		public static int InsertLoginGuest(Guest theGuest,int CompanyID)
		{
			return GuestDataAccess.GetInstance.InsertLoginGuest(theGuest,CompanyID);
		}

        public static int UpdateGuest(Guest theGuest)
        {
            return GuestDataAccess.GetInstance.UpdateGuest(theGuest);
        }

        public static int DeleteGuest(Guest theGuest)
        {
            return GuestDataAccess.GetInstance.DeleteGuest(theGuest);
        }
        #endregion
    }
}
