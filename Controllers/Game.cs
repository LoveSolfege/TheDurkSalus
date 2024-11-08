using TheDurkSalus.Constants;
using TheDurkSalus.Creatures;
using TheDurkSalus.Models;
using TheDurkSalus.Players;
using TheDurkSalus.Utils;

namespace TheDurkSalus.Controllers;

public class Game
{
	private int _encounterNumber = 0;
	private bool _playerTurn = Random.Shared.Next(2) != 0; 
	private bool _gameOver = false;
	private int _roundNumber = 0;
	private Team Allies { get; }
	private Team Enemies {get; set; }
	private List<Team> _enemyArmy;
	
	
	public Game()
	{
		Allies = new Team(new ConsolePlayer());
		_enemyArmy = EnemyArmyCreator.CreateArmy();
		Enemies = _enemyArmy[0];
		string? playerName = ConsoleUtils.Prompt(GameText.AskForName);
		Allies.AddMember(new MainCharacter(playerName));
	}


	public void Run()
	{
		StatusPrinter.StartingTeam(_playerTurn);
		StatusPrinter.TeamsInfo(Allies, Enemies, _roundNumber, _encounterNumber);
		while (!_gameOver)
		{
			CalculateBattleNumber();
			DetermineWinner();
			if (_gameOver) break;
			
			_roundNumber++;
			Enemies = _enemyArmy[_encounterNumber];//Select encounter team according to wave (encounter) number
			
			
			if (_playerTurn)
			{
				TeamAction(Allies);
				TeamAction(Enemies);
			}
			else
			{
				TeamAction(Enemies);
				TeamAction(Allies);
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
			ConsoleUtils.WriteLine(GameText.AlliesWin, ConsoleColor.Green);
		}
		else if(Allies.TeamMembers.Count == 0)
		{
			_gameOver = true;
			ConsoleUtils.WriteLine(GameText.EnemiesWin, ConsoleColor.Red);
		}
	}
	
	private void TeamAction(Team team)
	{
		foreach (var member in team.TeamMembers)
		{
			ConsoleUtils.WriteLine($"Turn of {member.Name}", ConsoleColor.DarkCyan);
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