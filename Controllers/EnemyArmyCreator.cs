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
	private static Team _thirdEncounter = new Team(Player);
	
	
	
	public static List<Team> CreateArmy()
	{
		_firstEncounter.AddEnemy<Skeleton>(1);
		_secondEncounter.AddEnemy<Skeleton>(2);
		_thirdEncounter.AddEnemy<FinalBoss>(1);
		List<Team> army = [_firstEncounter, _secondEncounter, _thirdEncounter];
		return army;
	}


	private static void AddEnemy<TEnemy>(this Team team, int amount) where TEnemy : Creature, new()
	{
		for (int i = 0; i < amount; i++)
		{
			team.AddMember(AddEnemy<TEnemy>());
		}
	}
	
	private static Creature AddEnemy<TCreature>() where TCreature : Creature, new()
	{
		return new TCreature();
	}
	
	
}
