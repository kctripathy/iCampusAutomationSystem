using System;
using System.Collections.Generic;
using System.Linq;
using Micro.Objects.Administration;

namespace Micro.Commons
{
	public class MicroSecurity
	{
		public static string Encrypt(string theString)
		{
			return Micro.Commons.MicroSecuritty.Encrypt(theString);
			//try
			//{
			//    byte[] encData_byte = new byte[theString.Length];
			//    encData_byte = System.Text.Encoding.UTF8.GetBytes(theString);
			//    string encodedData = Convert.ToBase64String(encData_byte);
			//    return encodedData;
			//}
			//catch (Exception ex)
			//{
			//    //throw new Exception("Error in EncryptBase64" + ex.Message);
			//    MicroMessages.ShowDataExceptionErrorMessage(new Exception("Error in DecryptBase64" + ex.Message));
			//    return string.Empty;
			//}
		}

		public static string Decrypt(string theString)
		{
			return Micro.Commons.MicroSecuritty.Decrypt(theString);
			
			//string result = string.Empty;
			//try
			//{
			//    System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
			//    System.Text.Decoder utf8Decode = encoder.GetDecoder();
			//    byte[] todecode_byte = Convert.FromBase64String(theString);
			//    int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
			//    char[] decoded_char = new char[charCount];
			//    utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
			//    result = new String(decoded_char);
			//    return result;
			//}
			//catch (Exception ex)
			//{
			//    //throw new Exception("Error in DecryptBase64" + ex.Message);
			//    MicroMessages.ShowDataExceptionErrorMessage(new Exception("Error in DecryptBase64" + ex.Message));
			//    return result;
			//}

		}


	}
}
