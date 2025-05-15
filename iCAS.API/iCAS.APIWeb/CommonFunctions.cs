using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace iCAS.APIWeb
{
    public static class CommonFunctions
	{
		//public string GetRequestToken()
		//{
		//	var re = Request;
		//	var headers = re.Headers;
		//	string token = string.Empty;

		//	if (headers.Contains("Token"))
		//	{
		//		token = headers.GetValues("Token").First();
		//	}

		//	return token;
		//}
		public static string getVersion()
        {
			System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
			System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
			string version = fvi.FileVersion;
			return version;
		}
	}
}