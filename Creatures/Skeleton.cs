using TheDurkSalus.Actions.Attacks;
using TheDurkSalus.Constants;
using TheDurkSalus.Interfaces;
using TheDurkSalus.Models;

namespace TheDurkSalus.Creatures;

public class Skeleton : Creature
{
	public override string Name => "Skeleton";
	public override IAttack StandardAttack { get; } = new BoneCrunch();
	public override double MaxHp { get; } = HealthPoints.SkeletonMaxHp;
	public override double CurrentHp { get; protected set; } = HealthPoints.SkeletonMaxHp;
}