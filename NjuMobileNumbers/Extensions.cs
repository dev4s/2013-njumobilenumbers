using System.Text.RegularExpressions;

namespace NjuMobileNumbers
{
	public static class Extensions
	{
		public static string RemoveEnters(this string text)
		{
			return Regex.Replace(text, @"(\t\r?\n)\1+", "$1");
		}

		public static string RemoveSpaces(this string text)
		{
			return Regex.Replace(text, @"\s+", " ");
		}

		public static string ReplaceSpecificChars(this string text)
		{
			return Regex.Replace(text, @"&nbsp;", " ");
		}
	}
}