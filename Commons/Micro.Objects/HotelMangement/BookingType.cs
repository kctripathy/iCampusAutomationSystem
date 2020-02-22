using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.Hotel
{

	[Serializable]
	public partial class BookingType
	{
		public int BookingTypeID
		{
			get;
			set;
		}

		public string BookingTypeDesc
		{
			get;
			set;
		}

	}
}
