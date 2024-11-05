using TheDurkSalus.Actions.Attacks;
using TheDurkSalus.Constants;
using TheDurkSalus.Interfaces;
using TheDurkSalus.Models;

namespace TheDurkSalus.Creatures;

public class MainCharacter(string? name) : Creature
{
	public override string? Name { get; } = name;
	public override IAttack StandardAttack => new Punch();
	public override double MaxHp => HealthPoints.PlayerMaxHp;
	public override double CurrentHp { get; protected set; } = HealthPoints.PlayerMaxHp;
}