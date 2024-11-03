using TheDurkSalus.Actions.Attacks;
using TheDurkSalus.Constants;
using TheDurkSalus.Interfaces;
using TheDurkSalus.Models;

namespace TheDurkSalus.Creatures;

public class Skeleton : Creature
{
	public override string Name => Names.Creatures.SkeletonName;
	public override IAttack StandardAttack => new BoneCrunch();
	public override double MaxHp => HealthPoints.SkeletonMaxHp;
	public override double CurrentHp { get; protected set; } = HealthPoints.SkeletonMaxHp;
}