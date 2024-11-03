using TheDurkSalus.Enums;
using TheDurkSalus.Interfaces;
using TheDurkSalus.Models;

namespace TheDurkSalus.Controllers;

public class Game
{
	private bool _playerTurn = false;
	private int _roundNumber = 0;
	private List<Creature> _allies;
	private List<Creature> _enemies;
	
	
	public Game()
	{
		_allies = CreatureCreator.CreateCreature(1);
		_enemies = CreatureCreator.CreateCreature(1);
	}


	public void Run()
	{
		
		while (_allies.Count > 0 && _enemies.Count > 0)
		{
			_roundNumber++;
			if (_playerTurn)
			{
				TeamAction(_allies);
			}
			else
			{
				TeamAction(_enemies);
			}
			_playerTurn = !_playerTurn;
		}
	}

	private double TeamAction(List<Creature> team)
	{
		foreach (var member in team)
		{
			Console.WriteLine($"Turn of {member.Name}..");
			if (member is ICreatureAction creature)
			{
				Console.WriteLine($"{member.Name} did nothing.\n");
				Thread.Sleep(5000);
				return creature.DoAction(CreatureAction.Skip);
			}
			
		}

		throw new NotImplementedException();
	}


	private void PrintTeamMembers(params List<Creature>[] args)
	{
		foreach (var team in args)
		{
			foreach (var member in team)
			{
				Console.WriteLine($"{member.Name}\n");
			}
		}
	}
	
	
}