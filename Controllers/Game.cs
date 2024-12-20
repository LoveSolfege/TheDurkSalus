﻿using TheDurkSalus.Constants;
using TheDurkSalus.Creatures;
using TheDurkSalus.Models;
using TheDurkSalus.Players;
using TheDurkSalus.Utils;

namespace TheDurkSalus.Controllers;

public class Game
{
	private int _encounterNumber = 0;
	private bool _playerStarts = Random.Shared.Next(2) != 0; 
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
		StatusPrinter.TeamsInfo(//print initial status, starting team, round number etc
			Allies, Enemies, _roundNumber, _encounterNumber, StatusPrinter.StartingTeamInfo(_playerStarts));
		while (!_gameOver)
		{
			ChangeEncounter();
			DetermineWinner();
			if (_gameOver) break;
			
			_roundNumber++;
			
			if (_playerStarts)
				PlayerStarts();
			else
				EnemyStarts();
		}
	}


	private void PlayerStarts()
	{
		TeamAction(Allies);
		TeamAction(Enemies);
	}

	private void EnemyStarts()
	{
		TeamAction(Enemies);
		TeamAction(Allies);	
	}
	

	private void ChangeEncounter()
	{
		if (Enemies.TeamMembers.Count == 0 &&  _encounterNumber < _enemyArmy.Count)
		{
			_encounterNumber++;
			_playerStarts = true;
			Enemies = _enemyArmy[_encounterNumber];//Select encounter team according to wave (encounter) number
			StatusPrinter.TeamsInfo(Allies, Enemies, _roundNumber, _encounterNumber, GameText.EncounterPassed);
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