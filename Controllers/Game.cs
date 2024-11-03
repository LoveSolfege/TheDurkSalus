using TheDurkSalus.Creatures;
using TheDurkSalus.Models;
using TheDurkSalus.Players;

namespace TheDurkSalus.Controllers;

public class Game
{
	private bool _playerTurn = false;
	private bool _gameOver = false;
	private int _roundNumber = 0;
	private int _encounterNumber = 0;
	private Team Allies { get; }
	private Team Enemies {get; set; }
	private List<Team> _enemyArmy;
	
	
	public Game()
	{
		Allies = new Team(new ComputerPlayer());
		_enemyArmy = EnemyArmyCreator.CreateArmy();
		Enemies = _enemyArmy[0];
		Console.WriteLine("Provide us with your name:");
		string? playerName = Console.ReadLine();
		Allies.AddMember(new MainCharacter(playerName));
	}


	public void Run()
	{
		while (!_gameOver)
		{
			Enemies = _enemyArmy[_encounterNumber];
			_roundNumber++;
			if (_playerTurn)
			{
				TeamAction(Allies);
			}
			else
			{
				TeamAction(Enemies);
			}
			_playerTurn = !_playerTurn;
			CalculateBattleNumber();
			DetermineWinner();
			if (_gameOver) break;
		}
	}



	private void CalculateBattleNumber()
	{
		if (Enemies.TeamMembers.Count < 0)
		{
			_encounterNumber++;
		}
	}
	private void DetermineWinner()
	{
		if (_encounterNumber == _enemyArmy.Count && Allies.TeamMembers.Count > 0)
		{
			_gameOver = true;
			Console.WriteLine("Humans Wins!");
		}
		else if(Allies.TeamMembers.Count < 0)
		{
			_gameOver = true;
			Console.WriteLine("Monsters win!");
		}
	}
	
	private void TeamAction(Team team)
	{
		foreach (var member in team.TeamMembers)
		{
			Console.WriteLine($"Turn of {member.Name}..");
			team.Player.ChooseAction(this, member).Run(this, member);
			Console.WriteLine(String.Empty);
		}
	}

	public void RemoveFromTeam(Creature creature, Team team)
	{
		team.TeamMembers.Remove(creature);
	}
	
	public Team GetEnemyTeamFor(Creature creature) => Allies.TeamMembers.Contains(creature) ? Enemies : Allies;
	public Team GetTeamFor(Creature creature) => Allies.TeamMembers.Contains(creature) ? Allies : Enemies;
}