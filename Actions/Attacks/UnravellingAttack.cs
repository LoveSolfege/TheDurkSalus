using TheDurkSalus.Constants;
using TheDurkSalus.Interfaces;

namespace TheDurkSalus.Actions.Attacks;

public class UnravellingAttack : IAttack
{
	public double Damage => AttackDamage.UnravellingAttackDamage;
	public string Name => Names.Attacks.UnravellingAttack;
}