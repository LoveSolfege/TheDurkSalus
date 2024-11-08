namespace TheDurkSalus.Utils;

public static class ConsoleUtils
{
	public static void WriteLine(string text, ConsoleColor color)
	{
		Console.ForegroundColor = color;
		Console.WriteLine(text);
		Console.ResetColor();
	}

	public static void Write(string text, ConsoleColor color)
	{
		Console.ForegroundColor = color;
		Console.Write(text);
		Console.ResetColor();
	}

	public static void ClearAndWriteLine(string text, ConsoleColor color = ConsoleColor.Gray){
		Console.Clear();
		WriteLine(text, color);
	}
	
	public static string Prompt(string questionToAsk)
	{
		Console.ForegroundColor = ConsoleColor.Gray;
		Console.Write(questionToAsk + " ");
		Console.ForegroundColor = ConsoleColor.Cyan;
		string input = Console.ReadLine() ?? "";
		Console.ResetColor();
		return input;
	}

	public static void WriteLineMiddle(string text, ConsoleColor color = ConsoleColor.Gray)
	{
		Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
		WriteLine(text, color);
	}

	
	public static void FillLine(string text)
	{
		int size = Console.WindowWidth - 1;
		ConsoleUtils.WriteLineMiddle(String.Concat(Enumerable.Repeat(text, size)), ConsoleColor.Magenta);
	}
	
}