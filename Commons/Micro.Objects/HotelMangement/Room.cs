using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.Hotel
{
	[Serializable]
	public partial class Room
	{
		public int RoomID
		{
			get;
			set;
		}

		public string RoomNumber
		{
			get;
			set;
		}

		public int RoomTypeID
		{
			get;
			set;
		}
		
		public int FloorNumber
		{
			get;
			set;
		}
		public char IsOccupied
		{
			get;
			set;
		}
		public bool IsActive
		{
			get;
			set;
		}
		public string RoomTypeDesc
		{
			get;
			set;
		}
		public int CompanyID
		{
			get;
			set;
		}
		public int ModifiedBy
		{
			get;
			set;
		}
		public DateTime DateModified
		{
			get;
			set;
		}
		public int AddedBy
		{
			get;
			set;
		}
		public DateTime DateAdded
		{
			get;
			set;
		}
		public bool IsDeleted
		{
			get;
			set;
		}
		public string Facilities
		{
			get;
			set;
		}
	}


}
