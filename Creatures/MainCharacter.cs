using TheDurkSalus.Actions.Attacks;
using TheDurkSalus.Interfaces;
using TheDurkSalus.Models;

namespace TheDurkSalus.Creatures;

public class MainCharacter : Creature
{
	public override string? Name { get; }
	public override IAttack StandardAttack { get; } = new Punch();

	public MainCharacter(string? name, double hp) : base(hp, isEnemy: false)
	{
		Name = name;
	}
}