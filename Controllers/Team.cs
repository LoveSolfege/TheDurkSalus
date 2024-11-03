using TheDurkSalus.Interfaces;
using TheDurkSalus.Models;

namespace TheDurkSalus.Controllers;

public class Team
{
	public IPlayer Player { get; }
	public List<Creature> TeamMembers { get; private set; } = [];

	public Team(IPlayer player)
	{
		Player = player;
	}

	public void AddMember(Creature member)
	{
		TeamMembers.Add(member);
	}
}