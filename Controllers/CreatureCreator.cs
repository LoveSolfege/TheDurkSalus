using TheDurkSalus.Creatures.Enemies;
using TheDurkSalus.Models;

namespace TheDurkSalus.Controllers;

public static class CreatureCreator
{
	public static List<Creature> CreateCreature(int amount)
	{
		var creatures = new List<Creature>();

		for (int i = 0; i < amount; i++)
		{
			creatures.Add(new Skeleton("SKELETON", 5, true));
		}

		return creatures;
	}
}