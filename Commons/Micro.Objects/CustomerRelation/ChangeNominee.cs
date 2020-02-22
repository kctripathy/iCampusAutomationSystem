using System;

namespace Micro.Objects.CustomerRelation
{
	[Serializable]
	public partial class ChangeNominee
	{
		public int CustomerNomineeID
		{
			get;
			set;
		}
		public int CustomerAccountID
		{
			get;
			set;
		}
		public string NomineeName
		{
			get;
			set;
		}
		public string Nominee_Permanent_TownOrCity
		{
			get;
			set;
		}
		public string Nominee_Permanent_Landmark
		{
			get;
			set;
		}
		public string Nominee_Permanent_PinCode
		{
			get;
			set;
		}
		public int Nominee_Permanent_DistrictID
		{
			get;
			set;
		}
		public string NomineeRelationship
		{
			get;
			set;
		}
		public int NomineeAge
		{
			get;
			set;
		}
		public string DateAdded
		{
			get;
			set;
		}
		public int AddedBy
		{
			get;
			set;
		}
		public string DateModified
		{
			get;
			set;
		}
		public int ModifiedBy
		{
			get;
			set;
		}
	}
}
