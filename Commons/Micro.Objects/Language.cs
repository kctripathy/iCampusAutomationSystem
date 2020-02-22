
namespace Micro.Objects
{
	public class Language
	{
		public Language(string cultureCode, string languageName)
		{
			CultureCode = cultureCode;
			LanguageName = languageName;
		}

		public string CultureCode
		{
			get;
			set;
		}

		public string LanguageName
		{
			get;
			set;
		}
	}
}
