using System.Xml;
using TheDurkSalus.Utils;
using TheDurkSalus.Constants;
using TheDurkSalus.Models;

namespace TheDurkSalus.Controllers;

public static class StatusPrinter
{
	public static string StartingTeamInfo(bool allyTurn)
	{
		Console.Clear();
		return allyTurn ? GameText.AlliesStart : GameText.EnemiesStart;
	}

	public static void TeamsInfo(Team allies, Team enemies, int roundNumber, int encounterNumber, string title)
	{
		List<Creature> teamAllies = allies.TeamMembers;
		List<Creature> teamEnemies = enemies.TeamMembers;
		
		ConsoleUtils.FillLine("=");
		ConsoleUtils.WriteLineMiddle(title);
		ConsoleUtils.WriteLineMiddle($"Round #{roundNumber} | Wave #{encounterNumber + 1}");
		PrintMembersInfo(teamAllies,  ConsoleColor.Blue);
		Console.WriteLine("VS\n", ConsoleColor.Magenta);
		PrintMembersInfo(teamEnemies, ConsoleColor.Red);
		ConsoleUtils.FillLine("=");
		
	}
	
	private static void PrintMembersInfo(List<Creature> members, ConsoleColor color)
	{
		foreach (var member in members)
		{
			ConsoleUtils.WriteLine($"{member.Name} ({member.CurrentHp}/{member.MaxHp})", color);
		}
		Console.WriteLine(String.Empty);
	}
	
	
}