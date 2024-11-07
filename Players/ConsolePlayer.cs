using System.Threading.Channels;
using TheDurkSalus.Actions;
using TheDurkSalus.Controllers;
using TheDurkSalus.Interfaces;
using TheDurkSalus.Models;
using TheDurkSalus.Utils;

namespace TheDurkSalus.Players;

public class ConsolePlayer : IPlayer
{
	public IAction ChooseAction(Game game, Creature creature)
	{
		List<MenuChoice> choices = CreateMenuOptions(game, creature);

		for (int index = 0; index < choices.Count; index++)
			ConsoleUtils.WriteLine($"{index + 1} - {choices[index].Description}",choices[index].Available ? ConsoleColor.Gray : ConsoleColor.DarkGray);

		string choice = ConsoleUtils.Prompt("What do you want to do?");
		int menuIndex = Convert.ToInt32(choice) - 1;

		if (choices[menuIndex].Available) return choices[menuIndex].Action!;

		return new DoNothingAction();
	}

	
	private List<MenuChoice> CreateMenuOptions(Game game, Creature creature)
	{
		List<MenuChoice> choices = [];
		Team currentTeam = game.GetTeamFor(creature);
		Team opponentTeam = game.GetEnemyTeamFor(creature);


		if (opponentTeam.TeamMembers.Count > 0)
		{
			var creatureAttacks = PropertyUtils.GetProperties<IAttack>(creature);
			
			foreach (var attack in creatureAttacks)
			{
				string title = attack.Name;
				IAttack attackObj = (IAttack)attack.Value;

				choices.Add(new MenuChoice(
					$"{title.CutOnCapitals()} - {attackObj.Name}", 
					new AttackAction(attackObj, opponentTeam.TeamMembers[0])
				));
			}
		}
		else
		{
			choices.Add(new MenuChoice($"Standard attack {creature.StandardAttack.Name}", null));
		}
		
		choices.Add(new MenuChoice($"Do nothing", new DoNothingAction()));
		
		
		return choices;
	}
	
	
}