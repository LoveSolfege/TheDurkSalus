using TheDurkSalus.Creatures;
using TheDurkSalus.Models;
using TheDurkSalus.Players;

namespace TheDurkSalus.Controllers;

public class Game
{
	private bool _playerTurn = false;
	private int _roundNumber = 0;
	private Team Allies { get; }
	private Team Enemies {get;}
	
	
	public Game()
	{
		Allies = new Team(new ComputerPlayer());
		Enemies = new Team(new ComputerPlayer());
		string? playerName = Console.ReadLine();
		Allies.AddMember(new MainCharacter(playerName));
		
		Enemies.AddMember(new Skeleton());
	}


	public void Run()
	{
		while (Allies.TeamMembers.Count > 0 && Enemies.TeamMembers.Count > 0)
		{
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