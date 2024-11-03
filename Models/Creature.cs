using TheDurkSalus.Interfaces;

namespace TheDurkSalus.Models;

public abstract class Creature 
{
	public abstract string? Name { get; }
	public abstract IAttack StandardAttack { get; }
	public abstract double MaxHp { get;}
	public abstract double CurrentHp { get; protected set; }


	public double ReceiveDamage(double damage)
	{
		CurrentHp -= damage;
		return CurrentHp;
	}

	public override string? ToString()
	{
		return Name;
	}
}