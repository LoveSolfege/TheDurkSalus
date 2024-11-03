using TheDurkSalus.Actions.Attacks;
using TheDurkSalus.Constants;
using TheDurkSalus.Interfaces;
using TheDurkSalus.Models;

namespace TheDurkSalus.Creatures;

public class FinalBoss : Creature
{
	
	public override string? Name => Names.Creatures.FinalBossName;
	public override IAttack StandardAttack => new Punch();
	public override double MaxHp => HealthPoints.FinalBossHp;
	public override double CurrentHp { get; protected set; } = HealthPoints.FinalBossHp;

	
}