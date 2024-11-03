using TheDurkSalus.Interfaces;

namespace TheDurkSalus.Models;

public abstract class Creature 
{
	public abstract string? Name { get; }
	public abstract IAttack StandardAttack { get; }
	public abstract double MaxHp { get;}
	public abstract double CurrentHp { get; protected set; }


	public void ReceiveDamage(double damage)
	{
		CurrentHp -= damage;
	}

	public override string? ToString()
	{
		return Name;
	}
}