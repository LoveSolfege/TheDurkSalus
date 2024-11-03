using TheDurkSalus.Actions.Attacks;
using TheDurkSalus.Constants;
using TheDurkSalus.Interfaces;
using TheDurkSalus.Models;

namespace TheDurkSalus.Creatures;

public class MainCharacter : Creature
{
	public override string? Name { get; }
	public override IAttack StandardAttack => new Punch();
	public override double MaxHp => HealthPoints.PlayerMaxHp;
	public override double CurrentHp { get; protected set; } = HealthPoints.PlayerMaxHp;

	public MainCharacter(string? name) : base()
	{
		Name = name;
	}
}