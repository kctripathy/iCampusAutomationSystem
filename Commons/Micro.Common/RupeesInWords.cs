using System.Linq;

namespace Micro.Commons
{
	/// <summary>
	/// Indian Style translation of figures into words.
	/// </summary>
	/// <Author>Syed Ameer</Author>
	/// <Date>06-Feb-2012</Date>

	public class RupeesInWords
	{
		const string AllowedDigits = "0123456789.";

		private static string GetAllowedDigits(string currencyAmount)
		{
			string ReturnValue = string.Empty;

			char[] CharArray = currencyAmount.ToCharArray();

			for(int Counter =0;Counter < CharArray.Count();Counter++)
			{
				if(AllowedDigits.Contains(CharArray[Counter]))
				{
					ReturnValue = ReturnValue + CharArray[Counter];
				}
			}

			return ReturnValue;
		}

		private static string CommonWords(int currentDigit)
		{
			switch(currentDigit)
			{
				case 1:
					return " One";
				case 2:
					return " Two";
				case 3:
					return " Three";
				case 4:
					return " Four";
				case 5:
					return " Five";
				case 6:
					return " Six";
				case 7:
					return " Seven";
				case 8:
					return " Eight";
				case 9:
					return " Nine";
				case 10:
					return " Ten";
				case 11:
					return " Eleven";
				case 12:
					return " Twelve";
				case 13:
					return " Thirteen";
				case 14:
					return " Fourteen";
				case 15:
					return " Fifteen";
				case 16:
					return " Sixteen";
				case 17:
					return " Seventeen";
				case 18:
					return " Eighteen";
				case 19:
					return " Nineteen";
				case 20:
					return " Twenty";
				case 30:
					return " Thirty";
				case 40:
					return " Forty";
				case 50:
					return " Fifty";
				case 60:
					return " Sixty";
				case 70:
					return " Seventy";
				case 80:
					return " Eighty";
				case 90:
					return " Ninety";
				default:
					return null;
			}
		}

		private static string DigitGroupingName(int groupType)
		{
			string ReturnValue = string.Empty;

			switch(groupType)
			{
				case 1:
					ReturnValue = "Crore";
					break;
				case 2:
					ReturnValue = "Lakh";
					break;
				case 3:
					ReturnValue = "Thousand";
					break;
				case 4:
					ReturnValue = "Hundred";
					break;
			}

			return ReturnValue;
		}

		private static string DigitGrouping(int currentDigit, int groupType)
		{
			string ReturnValue = string.Empty;
			string WordSuffix = DigitGroupingName(groupType);

			if((currentDigit > 0 && currentDigit <= 20) || currentDigit == 30 || currentDigit == 40 || currentDigit == 50 || currentDigit == 60 || currentDigit == 70 || currentDigit == 80 || currentDigit == 90)
			{
				ReturnValue = (CommonWords(currentDigit) + ' ' + WordSuffix);
			}
			else if(currentDigit > 20)
			{
				ReturnValue = CommonWords(int.Parse((currentDigit.ToString().ElementAt(0)) + "0")) + ' ';
				ReturnValue = ReturnValue + CommonWords(int.Parse(currentDigit.ToString().ElementAt(currentDigit.ToString().Length - 1).ToString())) + ' ' + WordSuffix;
			}

			return ReturnValue;
		}

		private static string Indian(string currencyAmount)
		{
			string ReturnValue = string.Empty;

			string InputString = GetAllowedDigits(currencyAmount);
			int StringLength = InputString.Length;
			int SubStringStartsAt = 0;

			while(StringLength > 0)
			{
				if(StringLength > 14 & StringLength < 16)
				{
					ReturnValue = ReturnValue + ' ' + DigitGrouping(int.Parse(InputString.Substring(SubStringStartsAt, (StringLength - 14))), 1);
					SubStringStartsAt = (SubStringStartsAt + (StringLength - 14));
					StringLength = 14;
				}

				if(StringLength > 12)
				{
					ReturnValue = ReturnValue + ' ' + DigitGrouping(int.Parse(InputString.Substring(SubStringStartsAt, (StringLength - 12))), 2);
					SubStringStartsAt = (SubStringStartsAt + (StringLength - 12));
					StringLength = 12;
				}

				if(StringLength > 10)
				{
					ReturnValue = ReturnValue + ' ' + DigitGrouping(int.Parse(InputString.Substring(SubStringStartsAt, (StringLength - 10))), 3);
					SubStringStartsAt = (SubStringStartsAt + (StringLength - 10));
					StringLength = 10;
				}

				if(StringLength > 9)
				{
					ReturnValue = ReturnValue + ' ' + DigitGrouping(int.Parse(InputString.Substring(SubStringStartsAt, (StringLength - 9))), 4);
					SubStringStartsAt = (SubStringStartsAt + (StringLength - 9));
					StringLength = 9;
				}

				if(StringLength > 7)
				{
					ReturnValue = ReturnValue + ' ' + DigitGrouping(int.Parse(InputString.Substring(SubStringStartsAt, (StringLength - 7))), 1);
					SubStringStartsAt = (SubStringStartsAt + (StringLength - 7));
					StringLength = 7;
				}

				if(StringLength > 5)
				{
					ReturnValue = ReturnValue + ' ' + DigitGrouping(int.Parse(InputString.Substring(SubStringStartsAt, (StringLength - 5))), 2);
					SubStringStartsAt = (SubStringStartsAt + (StringLength - 5));
					StringLength = 5;
				}

				if(StringLength > 3)
				{
					ReturnValue = ReturnValue + ' ' + DigitGrouping(int.Parse(InputString.Substring(SubStringStartsAt, (StringLength - 3))), 3);
					SubStringStartsAt = (SubStringStartsAt + (StringLength - 3));
					StringLength = 3;
				}

				if(StringLength > 2)
				{
					ReturnValue = ReturnValue + ' ' + DigitGrouping(int.Parse(InputString.Substring(SubStringStartsAt, (StringLength - 2))), 4);
					SubStringStartsAt = (SubStringStartsAt + (StringLength - 2));
					StringLength = 2;
				}

				if(StringLength > 0)
				{
					ReturnValue = ReturnValue + ' ' + DigitGrouping(int.Parse(InputString.Substring(SubStringStartsAt, (StringLength))), 5);
					SubStringStartsAt = (SubStringStartsAt + (StringLength - 2));
					StringLength = 0;
				}
			}
			return ReturnValue;
		}

		public static string Indian(string currencyAmount, bool suffixRupees)
		{
			string ReturnValue = string.Empty;

			currencyAmount = GetAllowedDigits(currencyAmount);
			string[] CurrencyParts = currencyAmount.Split('.');
			int Counter = 0;

			for(Counter = 0;Counter < CurrencyParts.Count();Counter++)
			{
				if(Counter < 2)
				{
					if(Counter == 0)
					{
						ReturnValue = Indian(CurrencyParts[Counter]);
					}
					else
					{
						ReturnValue = ReturnValue + "And" + Indian(CurrencyParts[Counter]);
						if(suffixRupees == true)
							ReturnValue = ReturnValue + " Paisa";
					}
				}
			}

			if(suffixRupees == true)
				ReturnValue = "Rupees " + ReturnValue;

			return ReturnValue;
		}
	}
}
