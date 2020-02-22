using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Micro.Objects.Hotel
{

	[Serializable]
	public class RoomType
	{
		public int RoomTypeID
		{
			get;
			set;
		}

		public string RoomTypeDesc
		{
			get;
			set;
		}

		public decimal RoomTypeTariff
		{
			get;
			set;
		}

		public int NumOfBeds
		{
			get;
			set;
		}

		public bool  IsActive
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
		public int RoomNumber
		{
			get;
			set;
		}
		public int RoomID
		{
			get;
			set;
		}

	}
}
