using TheDurkSalus.Creatures;
using TheDurkSalus.Interfaces;
using TheDurkSalus.Models;
using TheDurkSalus.Players;

namespace TheDurkSalus.Controllers;

public static class EnemyArmyCreator
{
	private static readonly IPlayer Player = new ComputerPlayer();
	private static Team _firstEncounter = new Team(Player);
	private static Team _secondEncounter = new Team(Player);
	
	
	
	public static List<Team> CreateArmy()
	{
		_firstEncounter.AddEnemy(1);
		_secondEncounter.AddEnemy(2);
		List<Team> army = [_firstEncounter, _secondEncounter];
		return army;
	}


	private static void AddEnemy(this Team team, int amount)
	{
		BulkAddEnemy(team, amount);
	}
	
	private static void BulkAddEnemy(Team team, int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			team.AddMember(AddEnemy<Skeleton>());
		}
	}
	
	private static Creature AddEnemy<TCreature>() where TCreature : Creature, new()
	{
		return new TCreature();
	}
	
	
}
