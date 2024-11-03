using TheDurkSalus.Constants;
using TheDurkSalus.Interfaces;

namespace TheDurkSalus.Actions.Attacks;

public class Punch : IAttack
{
	public string Name => "Punch";
	public double Damage => AttackDamage.PunchDamage;
}