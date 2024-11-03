using TheDurkSalus.Constants;
using TheDurkSalus.Interfaces;

namespace TheDurkSalus.Actions.Attacks;

public class BoneCrunch : IAttack
{
	public string Name => Names.Attacks.BoneCrunch;
	public double Damage => AttackDamage.BoneCrunchDamage;
}