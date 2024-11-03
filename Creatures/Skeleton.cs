using TheDurkSalus.Actions.Attacks;
using TheDurkSalus.Interfaces;
using TheDurkSalus.Models;

namespace TheDurkSalus.Creatures;

public class Skeleton : Creature
{
	public override string Name => "Skeleton";
	public override IAttack StandardAttack { get; } = new BoneCrunch();

	public Skeleton(double hp, bool isEnemy) : base(hp, isEnemy)
	{
		
	}
	
}