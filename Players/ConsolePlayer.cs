using System.Threading.Channels;
using TheDurkSalus.Actions;
using TheDurkSalus.Controllers;
using TheDurkSalus.Interfaces;
using TheDurkSalus.Models;

namespace TheDurkSalus.Players;

public class ConsolePlayer : IPlayer
{
	public IAction ChooseAction(Game game, Creature creature)
	{
		List<MenuChoice> choices = CreateMenuOptions(game, creature);

		return new DoNothingAction();
	}

	private List<MenuChoice> CreateMenuOptions(Game game, Creature creature)
	{
		List<MenuChoice> choices = [];
		Team currentTeam = game.GetTeamFor(creature);
		Team opponentTeam = game.GetEnemyTeamFor(creature);


		if (opponentTeam.TeamMembers.Count > 0)
		{
			
		}
		else
		{
			
		}
		
		
		
		
		return choices;
	}
}