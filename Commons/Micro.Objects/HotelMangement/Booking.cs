using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.Hotel
{
    [Serializable]
    public class Booking
    {
        public int BookingID
        {
            get;
            set;
        }

        public DateTime BookingDate
        {
            get;
            set;
        }
		public string BookingStatus
		{
			get;
			set;
		}

        public int CustomerID
        {
            get;
            set;
        }

        public int RoomID
        {
            get;
            set;
        }

        public int RoomTypeID
        {
            get;
            set;
        }

        public int RoomTariff
        {
            get;
            set;
        }

        public int NoOfOccupants
        {
            get;
            set;
        }

        public int NoOfAdults
        {
            get;
            set;
        }

        public int NoOfChildren
        {
            get;
            set;
        }

        public string ExpectedCheckInDate
        {
            get;
            set;
        }

        public string ExpectedCheckInTime
        {
            get;
            set;
        }

        public string ExpectedCheckOutDate
        {
            get;
            set;
        }

        public string ExpectedCheckOutTime
        {
            get;
            set;
        }

        public string ActualCheckInDate
        {
            get;
            set;
        }

        public string ActualCheckInTime
        {
            get;
            set;
        }

        public string ActualCheckOutDate
        {
            get;
            set;
        }

        public string ActualCheckOutTime
        {
            get;
            set;
        }

        public DateTime AutomaticCancellationDate
        {
            get;
            set;
        }
		
        public char IsPaymentReceived
        {
            get;
            set;
        }

        public string PaymentType
        {
            get;
            set;
        }

		public decimal AdvancePaid
        {
            get;
            set;
        }

        public decimal DiscountGiven
        {
            get;
            set;
        }

        public decimal TotalBillToBePaid
        {
            get;
            set;
        }
													
        public string CustomerFeedback
		{
            get;
            set;
        }
        
        public bool IsActive
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public DateTime DateAdded
        {
            get;
            set;
        }

        public int AddedBy
        {
            get;
            set;
        }

        public DateTime DateModified
        {
            get;
            set;
        }

        public int ModifiedBy
        {
            get;
            set;
        }

        public int CompanyID
        {
            get;
            set;
        }

        public string RoomTypeDesc
        {
            get;
            set;
        }

        public string RoomNumber
        {
            get;
            set;
        }
        public string FirstName
        {
            get;
            set;
        }
        public string MiddleName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public string CustomerName
        {
            get
            {
                return this.FirstName + " " + this.MiddleName + " " + this.LastName ;
            }
        }
        public string CustomerCode
        {
            get;
            set;
        }

    }
}
