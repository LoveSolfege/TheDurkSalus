using TheDurkSalus.Constants;
using TheDurkSalus.Interfaces;

namespace TheDurkSalus.Actions.Attacks;

public class BoneCrunch : IAttack
{
	public string Name => "Bone Crunch";
	public double Damage => AttackDamage.BoneCrunchDamage;
}