using TheDurkSalus.Actions;
using TheDurkSalus.Controllers;
using TheDurkSalus.Interfaces;
using TheDurkSalus.Models;

namespace TheDurkSalus.Players;

public class ComputerPlayer : IPlayer
{
	public IAction ChooseAction(Game game, Creature creature)
	{
		Thread.Sleep(500);
		return new AttackAction(creature.StandardAttack, game.GetEnemyTeamFor(creature).TeamMembers[0]);
	}
}