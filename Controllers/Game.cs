using TheDurkSalus.Creatures;
using TheDurkSalus.Models;
using TheDurkSalus.Players;
using TheDurkSalus.Utils;

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
		Allies = new Team(new ConsolePlayer());
		_enemyArmy = EnemyArmyCreator.CreateArmy();
		Enemies = _enemyArmy[0];
		string? playerName = ConsoleUtils.Prompt("Provide us with your name: ");
		Allies.AddMember(new MainCharacter(playerName));
	}


	public void Run()
	{
		while (!_gameOver)
		{
			CalculateBattleNumber();
			DetermineWinner();
			if (_gameOver) break;
			
			_roundNumber++;
			Enemies = _enemyArmy[_encounterNumber];
			if (_playerTurn)
			{
				TeamAction(Allies);
			}
			else
			{
				TeamAction(Enemies);
			}
			_playerTurn = !_playerTurn;
		}
	}



	private void CalculateBattleNumber()
	{
		if (Enemies.TeamMembers.Count == 0 &&  _encounterNumber < _enemyArmy.Count)
		{
			_encounterNumber++;
		}
	}
	private void DetermineWinner()
	{
		if (_encounterNumber == _enemyArmy.Count && Allies.TeamMembers.Count > 0)
		{
			_gameOver = true;
			ConsoleUtils.WriteLine("Humans Wins!", ConsoleColor.Green);
		}
		else if(Allies.TeamMembers.Count == 0)
		{
			_gameOver = true;
			ConsoleUtils.WriteLine("Monsters win!", ConsoleColor.Red);
		}
	}
	
	private void TeamAction(Team team)
	{
		foreach (var member in team.TeamMembers)
		{
			ConsoleUtils.WriteLine($"Turn of {member.Name}..", ConsoleColor.DarkCyan);
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
	public bool IsEnemy(Creature creature) => !Allies.TeamMembers.Contains(creature);
}