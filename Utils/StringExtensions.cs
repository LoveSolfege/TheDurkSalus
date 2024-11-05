using System.Text.RegularExpressions;

namespace TheDurkSalus.Utils;

public static class StringExtensions
{
	public static string CutOnCapitals(this string text)
	{
		string[] words = Regex.Split(text, "(?=[A-Z])");
		
		return string.Join(" ", words).Trim();
	}
}