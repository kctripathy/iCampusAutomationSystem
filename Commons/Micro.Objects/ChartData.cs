using System;

namespace Micro.Objects
{
	class ChartData
	{
	}

	[Serializable]
	public class YearlyMaturity
	{


		public int OfficeID
		{
			get;
			set;
		}

		public string OfficeName
		{
			get;
			set;
		}

		public int MaturityYear
		{
			get;
			set;
		}

		public double MaturityAmount
		{
			get;
			set;
		}



	}
}
