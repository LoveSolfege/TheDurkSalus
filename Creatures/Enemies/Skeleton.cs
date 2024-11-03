using TheDurkSalus.Enums;
using TheDurkSalus.Interfaces;
using TheDurkSalus.Models;

namespace TheDurkSalus.Creatures.Enemies;

public class Skeleton : Creature, ICreatureAction
{
	public Skeleton(string name, int hp, bool isEnemy) : base(name, hp, isEnemy)
	{
		
	}

	public double DoAction(CreatureAction action)
	{
		return action switch
		{
			CreatureAction.Skip => 0,
			CreatureAction.Attack => 1,
			_ => throw new ArgumentOutOfRangeException($"{Name} can't do {action}")
		};
	}
}