using TheDurkSalus.Interfaces;

namespace TheDurkSalus.Models;

public abstract class Creature : IAttack
{
	public abstract string? Name { get; }
	public abstract IAttack StandardAttack { get; }
	public double Hp { get; protected set; }
	public bool IsEnemy { get; protected set; }

	
	protected Creature(double hp, bool isEnemy)
	{
		Hp = hp;
		IsEnemy = isEnemy;
	}

	public override string? ToString()
	{
		return Name;
	}
}